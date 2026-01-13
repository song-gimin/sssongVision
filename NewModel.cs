using sssongVision.Core;
using sssongVision.Setting;
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


namespace sssongVision
{
    //#12_MODEL SAVE# - XmlHelper를 이용한 모델 저장
    // MainForm.cs에 ModelNew, ModelOpen, ModelSavem ModelSaveAs 메뉴 추가
    // NewModel WinForm : 신규 모델 생성시, 모델 이름과 모델 정보를 입력받아, 모델을 생성하고 저장
    public partial class NewModel : Form
    {
        public NewModel()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text.Trim();
            if (modelName == "")
            {
                MessageBox.Show("모델 이름을 입력하세요.");
                return;
            }

            string modelDir = SettingXml.Instance.ModelDir;
            if (Directory.Exists(modelDir) == false)
            {
                MessageBox.Show("모델 저장 폴더가 존재하지 않습니다.");
                return;
            }

            string modelPath = Path.Combine(modelDir, modelName, modelName + ".xml");
            if (File.Exists(modelPath))
            {
                MessageBox.Show("이미 존재하는 모델 이름입니다.");
                return;
            }

            string saveDir = Path.Combine(modelDir, modelName);
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);

            string modelInfo = txtModelInfo.Text.Trim();

            Global.Inst.InspStage.CurModel.CreateModel(modelPath, modelName, modelInfo);
            Global.Inst.InspStage.CurModel.Save();
            this.Close();
        }
    }
}
