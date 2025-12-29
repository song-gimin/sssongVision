using sssongVision.Property;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sssongVision.Core
{
    // 이진화 Preview 구현
    // 이진화 검사를 위한 Preview를 R,G,B,Mono 별로 보여주는 기능 구현
    // PreviewImage.cs : 이진화 Preview를 구현하는 클래스

    public class PreviewImage
    {
        private Mat _originalTmage = null;
        private Mat _previewImage = null;
        private bool _usePreview = true;

        public void SetImage (Mat image)
        {
            _originalTmage = image;
            _previewImage = new Mat();
        }

        // ShowBinaryMode에 따라 이진화 Preview 진행 (BinaryProp.cs참고)
        public void SetBinary (int lowerValue, int upperValue, bool invert, ShowBinaryMode showBinMode)
        {
            if (_usePreview == false) return;

            if (_originalTmage == null) return;

            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null) return;

            Bitmap bmpImage;
            if (showBinMode == ShowBinaryMode.ShowBinaryNone)
            {
                bmpImage = BitmapConverter.ToBitmap(_originalTmage);
                cameraForm.UpdateDisplay(bmpImage);
                return;
            }

            Rect windowArea = new Rect(0, 0, _originalTmage.Width, _originalTmage.Height);

            Mat orgRoi = _originalTmage[windowArea];

            Mat grayImage = new Mat();
            if (orgRoi.Type() == MatType.CV_8UC3)
            {
                Cv2.CvtColor(orgRoi, grayImage, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                grayImage = orgRoi;
            }

            Mat binaryMask = new Mat();
            Cv2.InRange(grayImage, lowerValue, upperValue, binaryMask);

            if (invert) binaryMask = ~binaryMask;

            // binaryMask는 ROI 사이즈이므로 fullBinaryMask로 확장
            Mat fullBinaryMask = Mat.Zeros(_originalTmage.Size(), MatType.CV_8UC1);
            binaryMask.CopyTo(new Mat(fullBinaryMask, windowArea));

            if (showBinMode == ShowBinaryMode.ShowBinaryOnly)
            {
                if (orgRoi.Type() == MatType.CV_8UC3)
                {
                    Mat colorBinary = new Mat();
                    Cv2.CvtColor(binaryMask, colorBinary, ColorConversionCodes.GRAY2BGR);
                    _previewImage = _originalTmage.Clone();
                    colorBinary.CopyTo(new Mat(_previewImage, windowArea));
                }
                else
                {
                    _previewImage = _originalTmage.Clone();
                    binaryMask.CopyTo(new Mat(_previewImage, windowArea));
                }

                bmpImage = BitmapConverter.ToBitmap(_previewImage);
                cameraForm.UpdateDisplay(bmpImage);
                return;
            }

            Scalar highlightColor;
            if (showBinMode == ShowBinaryMode.ShowBinaryHighlightRed)
            {
                highlightColor = new Scalar(0, 0, 255);
            }
            else if (showBinMode == ShowBinaryMode.ShowBinaryHighlightGreen)
            {
                highlightColor = new Scalar(0, 255, 0);
            }
            else
            {
                highlightColor = new Scalar(255, 0, 0);
            }

            // 원본 이미지 복사본을 만들어 이진화된 부분에만 색을 덧씌우기
            Mat overlayImage;
            if (_originalTmage.Type() == MatType.CV_8UC1)
            {
                overlayImage = new Mat();
                Cv2.CvtColor(_originalTmage, overlayImage, ColorConversionCodes.GRAY2BGR);

                Mat colorOrinal = overlayImage.Clone();

                overlayImage.SetTo(highlightColor, fullBinaryMask); // 빨간색으로 마스킹

                // 원본과 합성 (투명도 적용)
                Cv2.AddWeighted(colorOrinal, 0.7, overlayImage, 0.3, 0, _previewImage);
            }
            else
            {
                overlayImage = _originalTmage.Clone();
                overlayImage.SetTo(highlightColor, fullBinaryMask); // 빨간색으로 마스킹

                // 원본과 합성 (투명도 적용)
                Cv2.AddWeighted(_originalTmage, 0.7, overlayImage, 0.3, 0, _previewImage);
            }

            bmpImage = BitmapConverter.ToBitmap(_previewImage);
            cameraForm.UpdateDisplay(bmpImage);
        }
    }
}
