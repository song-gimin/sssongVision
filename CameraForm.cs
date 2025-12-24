using OpenCvSharp;
using OpenCvSharp.Extensions;
using sssongVision.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace sssongVision
{
    public partial class CameraForm : DockContent
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        //private Mat _curMat;
        //public Mat CurMat => _curMat;

        // 이미지 Open하면, PictureBox에 로드한 이미지 띄우기
        public void LoadImage(string filePath)
        {
            if (File.Exists(filePath) == false) return;

            Image bitmap = Image.FromFile(filePath);

            imageViewer.LoadBitmap((Bitmap)bitmap);

            /*using (var bitmap = new Bitmap(filePath))
            {
                imageViewer.LoadBitmap((Bitmap)bitmap);

                _curMat?.Dispose();
                _curMat = BitmapConverter.ToMat(bitmap);
            }*/
        }

        private void CameraForm_Resize(object sender, EventArgs e)
        {
            int margin = 0;
            imageViewer.Width = this.Width - margin * 2;
            imageViewer.Height = this.Height - margin * 2;

            imageViewer.Location = new System.Drawing.Point(margin, margin);
        }

        public void UpdateDisplay(Bitmap bitmap = null)
        {
            if (bitmap == null)
            {
                //#6_INSP_STAGE#3 업데이트시 bitmap이 없다면 InspSpace에서 가져온다
                bitmap = Global.Inst.InspStage.GetBitmap(0);
                if (bitmap == null)
                    return;
            }

            if (imageViewer != null)
                imageViewer.LoadBitmap(bitmap);
        }

        public Bitmap GetDisplayImage()
        {
            Bitmap curImage = null;

            if (imageViewer != null)
                curImage = imageViewer.GetCurBitmap();

            return curImage;
        }
    }
}
