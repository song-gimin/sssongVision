using Common.Util.Helpers;
using sssongVision.Grab;
using sssongVision.Sequence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sssongVision.Setting
{

    // #9 SetUp 환경설정을 해봅시다~ 환경설정 파일을 불러오고 저장하는 기능 구현
    // 환경설정 정보를 xml 방식으로 저장하고, singleton 방식으로 어디서나 호출하여 사용하도록 구현
    // 환경설정 파일은 실행파일 폴더 안에 Setup/Setting.xml 파일로 저장할거임
    // XmlHelper.cs (Util)는 복사해오고, SettingXml.cs (Setting) 구현 (환경설정 정보를 xml로 저장하고 불러오는 클래스)
    // Setting 폴더 안에 사용자정의컨트롤 클래스들도 같이 생성&구현 : CameraSetting.cs PathSetting.cs
    // SetupForm.cs에 TabControl을 추가하고, CameraSetting과 PathSetting UserControl을 탭으로 추가
    
    public class SettingXml
    {
        // 환경 설정 파일 저장 경로
        private const string SETTING_DIR = "Setup";
        private const string SETTING_FILE_NAME = @"Setup\Setting.xml";

        #region Singleton Instance
        private static SettingXml _setting;

        public static SettingXml Instance
        {
            get
            {
                if (_setting == null)
                    Load();

                return _setting;
            }
        }
        #endregion

        // 환경 설정 로딩 Load();
        public static void Load()
        {
            if (_setting != null) return;

            // 환경 설정 경로 생성
            string settingFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, SETTING_FILE_NAME);
            // 환경설정 파일이 있다면, XmlHelper를 이용해 로딩
            if (File.Exists(settingFilePath) == true)
            {
                _setting = XmlHelper.LoadXml<SettingXml>(settingFilePath);
            }
            // 환경설정 파일이 없다면 새로 생성
            if (_setting == null)
            {
                _setting = CreateDefaultInstance();
            }
        }

        // 최초 환경설정 파일 생성
        private static SettingXml CreateDefaultInstance()
        {
            SettingXml setting = new SettingXml();
            setting.ModelDir = @"d:\model";
            return setting;
        }

        // 환경설정 저장
        public static void Save()
        {
            string settingFilePath = Path.Combine(Environment.CurrentDirectory, SETTING_FILE_NAME);
            if (!File.Exists(settingFilePath))
            {
                //Setup 폴더가 없다면 생성
                string setupDir = Path.Combine(Environment.CurrentDirectory, SETTING_DIR);

                if (!Directory.Exists(setupDir))
                    Directory.CreateDirectory(setupDir);

                //Setting.xml 파일이 없다면 생성
                FileStream fs = File.Create(settingFilePath);
                fs.Close();
            }

            //XmlHelper를 이용해 Xml로 환경설정 정보 저장
            XmlHelper.SaveXml(settingFilePath, Instance);
        }

        public SettingXml() { }

        public string MachineName { get; set; } = "Sssong";

        public string ModelDir { get; set; } = "";
        public string ImageDir { get; set; } = "";

        public CameraType CamType { get; set; } = CameraType.WebCam;

        //#15_INSP_WORKER#1 연속 검사 모드
        public bool CycleMode { get; set; } = false;

        //#19_VISION_SEQUENCE#1 통신타입, IP 설정
        public CommunicatorType CommType { get; set; }
        public string CommIP { get; set; } = "127.0.0.1";
    }
}
