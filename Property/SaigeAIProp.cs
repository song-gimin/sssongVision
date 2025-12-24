using sssongVision.Core;
using sssongVision.Inspect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace sssongVision.Property
{
    public partial class SaigeAIProp : UserControl
    {
        SaigeAI _saigeAI;
        ModelType _modelType;
        string _modelPath = string.Empty;

        public SaigeAIProp()
        {
            InitializeComponent();

            cbModelType.DataSource = Enum.GetValues(typeof(ModelType)).Cast<ModelType>().ToList();
            cbModelType.SelectedIndex = 0;
        }

        private void btnSelectModel_Click(object sender, EventArgs e)
        {
            string filter = "AI Files|*.*;";

            switch (_modelType)
            {
                case ModelType.IAD:
                    filter = "Image Anomaly Detection Files|*.saigeiad;";
                    break;
                case ModelType.DET:
                    filter = "Detection Files|*.saigedet;";
                    break;
                case ModelType.SEG:
                    filter = "Segmentation Files|*.saigeseg;";
                    break;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "AI 모델 파일 선택";
                openFileDialog.Filter = filter;
                openFileDialog.Multiselect = false;
                openFileDialog.InitialDirectory = @"C:\Saige\SaigeVision\engine\Examples\data\sfaw2023\models";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _modelPath = openFileDialog.FileName;
                    txtModelPath.Text = _modelPath;
                }
            }
        }

        private void cbModelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelType modelType = (ModelType)cbModelType.SelectedItem;

            if (modelType != _modelType)
            {
                if (_saigeAI != null)
                {
                    _saigeAI.Dispose();
                    _saigeAI = null;
                }

                _modelPath = string.Empty;
                txtModelPath.Text = string.Empty;

            }

            _modelType = modelType;

            bool showArea = modelType == ModelType.DET || modelType == ModelType.SEG;

             labelArea.Visible = showArea;
             numArea.Visible = showArea;
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_modelPath))
            {
                MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_saigeAI == null)
            {
                _saigeAI = Global.Inst.InspStage.AIModule;
            }

            _saigeAI.LoadEngine(_modelPath, _modelType);
            MessageBox.Show("모델이 성공적으로 로드되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInspModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_modelPath))
            {
                MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_saigeAI == null)
            {
                MessageBox.Show("AI 모듈이 초기화되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap bitmap = Global.Inst.InspStage.GetCurrentImage();
            if (bitmap is null)
            {
                MessageBox.Show("현재 이미지가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saigeAI.InspAIModule(bitmap);

            Bitmap resultImage = _saigeAI.GetResultImage();

            Global.Inst.InspStage.UpdateDisplay(resultImage);
        }

    }
}
