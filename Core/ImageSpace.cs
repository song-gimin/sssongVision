using OpenCvSharp;
using sssongVision.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sssongVision.Core
{
    //검사와 관련된 이미지 버퍼를 관리하는 클래스
    public enum eImageChannel : int
    {
        Color,
        Gray,
        Red,
        Green,
        Blue,
        ChannelCount = 5,
    }
    public class ImageSpace : IDisposable
    {
        private class ImageInfo : IDisposable
        {
            private Bitmap _bitmap;
            private Bitmap _tempBitmap;

            private PixelFormat Format { get; set; }

            public byte[] ImageData { get; set; }

            public int PixelBpp { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public SizeF PixelResolution { get; set; }

            public IntPtr Buffer { get; set; }

            public GCHandle Handle { get; set; }

            public int Stride { get; set; }

            public Bitmap ToBitmap()
            {
                if (_bitmap == null)
                {
                    _bitmap = new Bitmap(Width, Height,
                        (PixelBpp == 8 ?
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed :
                        System.Drawing.Imaging.PixelFormat.Format24bppRgb));

                    Format = _bitmap.PixelFormat;
                    Width = _bitmap.Width;
                    Height = _bitmap.Height;

                    Handle = GCHandle.Alloc(ImageData, GCHandleType.Pinned);
                    IntPtr pointer = Handle.AddrOfPinnedObject();

                    var bufferAndStride = _bitmap.ToBufferAndStride();
                    Buffer = pointer;
                    Stride = bufferAndStride.Item2;
                }

                if (_tempBitmap != null)
                    _tempBitmap = null;

                _tempBitmap = new Bitmap(Width, Height, Stride, Format, Buffer);

                if (_tempBitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    ColorPalette pal = _tempBitmap.Palette;
                    // Generate grayscale colours:
                    for (Int32 i = 0; i < 256; i++)
                        pal.Entries[i] = Color.FromArgb(i, i, i);
                    // Assign the edited palette to the bitmap.
                    _tempBitmap.Palette = pal;
                }
                return _tempBitmap;
            }

            public Mat ToMat()
            {
                MatType matType = PixelBpp == 8 ? MatType.CV_8UC1 : MatType.CV_8UC3;
                Mat mat = Mat.FromPixelData(Height, Width, matType, ImageData);

                return mat;
            }

            #region Disposable
            private bool disposed = false; // to detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        if (ImageData != null)
                            ImageData = null;

                        // Dispose managed resources.
                    }

                    // Dispose unmanaged managed resources.

                    disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion Disposable
        }

        public class ImagePtr
        {
            public IntPtr Ptr { get; set; }
            public long Length { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Step { get; set; }
            public int Bpp { get; set; }

            public ImagePtr(IntPtr ptr, long length, int width, int height, int step, int bpp)
            {
                Ptr = ptr;
                Length = length;
                Width = width;
                Height = height;
                Step = step;
                Bpp = bpp;
            }

            public Mat ToMat()
            {
                var type = Bpp == 1 ? MatType.CV_8UC1 : MatType.CV_8UC3;
                //return new Mat(Height, Width, type, Ptr);
                return Mat.FromPixelData(Height, Width, type, Ptr);
            }

            private static readonly ImagePtr _zero = new ImagePtr(IntPtr.Zero, 0, 0, 0, 0, 0);
            public static ImagePtr Zero => _zero;
        }

        private ImageInfo _inspectionImage = new ImageInfo();
        private Dictionary<int, ImageInfo> _imageInfo = new Dictionary<int, ImageInfo>();
        private Dictionary<int, Dictionary<eImageChannel, ImageInfo>> _imageByChannel = new Dictionary<int, Dictionary<eImageChannel, ImageInfo>>();

        protected byte[] _ImageData;
        public virtual byte[] ImageData
        {
            get
            {
                return _ImageData;
            }
            set
            {
                _ImageData = value;
            }
        }
        public bool UseImageSplit { get; set; } = true;
        public int BufferCount { get; set; } = 0;

        public ImageSpace()
        {
        }

        public void SetImageInfo(int inspectionPixelBpp, int inspectionWidth, int inspectionHeight, int inspectionStride)
        {
            _inspectionImage.PixelBpp = inspectionPixelBpp;
            _inspectionImage.Width = inspectionWidth;
            _inspectionImage.Height = inspectionHeight;
            _inspectionImage.Stride = inspectionStride;
        }

        public void InitImageSpace(int bufferCount)
        {
            if (_inspectionImage.Width == 0 || _inspectionImage.Height == 0)
                return;

            Dispose();

            Func<int, ImageInfo> newImageInfo = (x) =>
            {
                var imageInfo = new ImageInfo();
                imageInfo.PixelBpp = x;
                imageInfo.Width = _inspectionImage.Width;
                imageInfo.Height = _inspectionImage.Height;

                int bpp = 1;
                if (imageInfo.PixelBpp == 24)
                    bpp = 3;

                imageInfo.Stride = imageInfo.Width * bpp;
                imageInfo.PixelResolution = _inspectionImage.PixelResolution;
                imageInfo.ImageData = new byte[imageInfo.Stride * imageInfo.Height];

                GCHandle Handle = GCHandle.Alloc(imageInfo.ImageData, GCHandleType.Pinned);
                imageInfo.Buffer = Handle.AddrOfPinnedObject();
                imageInfo.Handle = Handle;

                return imageInfo;
            };

            for (int i = 0; i < bufferCount; ++i)
            {
                #region Origin Image buffer Set

                if (_imageInfo.ContainsKey(i) == true)
                    continue;

                var imageInfo = newImageInfo(_inspectionImage.PixelBpp);
                _imageInfo.Add(i, imageInfo);

                if (_inspectionImage.PixelBpp == 24)
                {
                    Dictionary<eImageChannel, ImageInfo> imageByChannel = new Dictionary<eImageChannel, ImageInfo>
                    {
                        { eImageChannel.Color, imageInfo },
                        { eImageChannel.Red, newImageInfo(8) },
                        { eImageChannel.Green, newImageInfo(8) },
                        { eImageChannel.Blue, newImageInfo(8) },
                        { eImageChannel.Gray, newImageInfo(8) }
                    };

                    _imageByChannel.Add(i, imageByChannel);
                }

                #endregion Origin Image Buffer Set
            }

            BufferCount = bufferCount;
        }

        #region Property

        #endregion Property



        #region Disposable
        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_inspectionImage != null)
                    {
                        _inspectionImage.Dispose();
                    }

                    if (_imageInfo != null)
                    {
                        foreach (var image in _imageInfo)
                        {
                            image.Value.Dispose();
                        }
                    }

                    if (_imageByChannel != null)
                    {
                        foreach (var image in _imageByChannel)
                        {
                            foreach (var innerImage in image.Value)
                            {
                                innerImage.Value.Dispose();
                            }
                        }
                    }

                    // Dispose managed resources.
                }

                // Dispose unmanaged managed resources.

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Disposable
    }
}
