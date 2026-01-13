using sssongVision.Core;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using sssongVision.Setting;
using sssongVision.Teach;

namespace sssongVision
{
    public partial class MainForm : Form
    {
        // DockPanel 전역 선언
        private static DockPanel _dockPanel;

        public MainForm()
        {
            InitializeComponent();

            // DockPanel 초기화
            //_dockPanel = new DockPanel();
            //_dockPanel.Dock = DockStyle.Fill;  //아래처럼 한번에 하는게 가독성이 더 좋고, _dockPanel 변수 한번만 써도 되고, 더 추가하기도 좋음

            _dockPanel = new DockPanel()
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_dockPanel);

            // MainForm Tab & DockPanel Tab 안겹치게
            // menuStrip 아래에서 시작하게
            _dockPanel.Location = new System.Drawing.Point(0, mainMenu.Height);
            _dockPanel.Size = new System.Drawing.Size(ClientSize.Width, ClientSize.Height - mainMenu.Height);
            _dockPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            mainMenu.BringToFront();  // 혹시 덮어도 메뉴가 앞으로 오게

            // 도킹 창 테마 설정 (어떤 모양으로 띄울건지)
            _dockPanel.Theme = new VS2015BlueTheme();

            // 도킹 윈도우 로드 메서드 호출
            LoadDockingWindows();

            //전역 인스턴스 초기화
            Global.Inst.InspStage.Initialize();
        }

        // 도킹 윈도우를 로드하는 메서드 생성 (private)
        private void LoadDockingWindows()
        {
            // 카메라 창
            var cameraForm = new CameraForm();
            cameraForm.Show(_dockPanel, DockState.Document); //도킹에 쓰려면 붙이는 애들도 도킹화 시켜야함. CameraForm.cs 상속 바꿔주기

            // 카메라 실행 창 (촬상)
            var runForm = new RunForm();
            runForm.Show(cameraForm.Pane, DockAlignment.Bottom, 0.2);

            //#11_MODEL_TREE#1 검사 결과창 우측에 40% 비율로 모델트리 추가
            var modelTreeWindow = new ModelTreeForm();
            modelTreeWindow.Show(runForm.Pane, DockAlignment.Right, 0.3);

            // 검사 결과 창 (카메라 창 아래 30% 비율로 띄우기)
            //var resusltForm = new ResultForm();
            //resusltForm.Show(cameraForm.Pane, DockAlignment.Bottom, 0.3);

            // 속성 창 (오른쪽에 창 띄우기)
            var propForm = new PropertiesForm();
            propForm.Show(_dockPanel, DockState.DockRight);

            // 속성창에 statistic 창 추가
            //var statisticForm = new StatisticForm();
            //statisticForm.Show(_dockPanel, DockState.DockRight);

            // 로그 창 (우측 속성 창 만든 영역 아래에 50% 비율로 띄우기)
            //var logForm = new LogForm();
            //logForm.Show(propForm.Pane, DockAlignment.Bottom, 0.5);  //위로 띄우고 싶으면 Top 사용하셈~

        }

        // 도킹패널에 쉽게 접근하기 위한 정적 함수
        // 제네릭 함수 사용를 이용해 입력된 타입의 폼 객체 얻기
        public static T GetDockForm<T>() where T : DockContent
        {
            var findForm = _dockPanel.Contents.OfType<T>().FirstOrDefault();
            return findForm;
        }

        // MainForm에서 이미지 열기
        private void imageOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = GetDockForm<CameraForm>();

            if (cameraForm == null) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 파일 선택";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    //#11_MATCHING#12 이미지 로딩함수 변경
                    Global.Inst.InspStage.SetImageBuffer(filePath);
                    Global.Inst.InspStage.CurModel.InspectImagePath = filePath;
                }
            }
        }

        //#9 환경설정창 실행
        private void setupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Inst.Dispose();
        }

        //#12_MODEL SAVE#3 모델 파일 열기,저장, 다른 이름으로 저장 기능 구현
        private string GetMdoelTitle(Model curModel)
        {
            if (curModel is null)
                return "";

            string modelName = curModel.ModelName;
            return $"{Define.PROGRAM_NAME} - MODEL : {modelName}";
        }

        private void modelNewMenuItem_Click(object sender, EventArgs e)
        {
            //신규 모델 추가를 위한 모델 정보를 받기 위한 창 띄우기
            NewModel newModel = new NewModel();
            newModel.ShowDialog();

            Model curModel = Global.Inst.InspStage.CurModel;
            if (curModel != null)
            {
                this.Text = GetMdoelTitle(curModel);
            }
        }

        private void modelOpenMenuItem_Click(object sender, EventArgs e)
        {
            //모델 파일 열기
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "모델 파일 선택";
                openFileDialog.Filter = "Model Files|*.xml;";
                openFileDialog.Multiselect = false;
                openFileDialog.InitialDirectory = SettingXml.Instance.ModelDir;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (Global.Inst.InspStage.LoadModel(filePath))
                    {
                        Model curModel = Global.Inst.InspStage.CurModel;
                        if (curModel != null)
                        {
                            this.Text = GetMdoelTitle(curModel);
                        }
                    }
                }
            }
        }

        private void modelSaveMenuItem_Click(object sender, EventArgs e)
        {
            //모델 파일 저장
            Global.Inst.InspStage.SaveModel("");
        }

        private void modelSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            //다른이름으로 모델 파일 저장
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = SettingXml.Instance.ModelDir;
                saveFileDialog.Title = "모델 파일 선택";
                saveFileDialog.Filter = "Model Files|*.xml;";
                saveFileDialog.DefaultExt = "xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Global.Inst.InspStage.SaveModel(filePath);
                }
            }
        }
    }
}
