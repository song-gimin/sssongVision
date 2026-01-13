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


    }
}
