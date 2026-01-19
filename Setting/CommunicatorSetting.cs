using OpenCvSharp;
using sssongVision.Sequence;
using sssongVision.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sssongVision.Setting
{
    public partial class CommunicatorSetting : UserControl
    {
        public CommunicatorSetting()
        {
            InitializeComponent();

            LoadSetting(); //최초 로딩시, 환경설정 정보 로딩
        }

        private void LoadSetting()
        {
            cbCommType.DataSource = Enum.GetValues(typeof(CommunicatorType)).Cast<CommunicatorType>().ToList();

            txtMachine.Text = SettingXml.Instance.MachineName;

            //환경설정에서 현재 통신 타입 얻기
            cbCommType.SelectedIndex = (int)SettingXml.Instance.CommType;

            txtIpAddr.Text = SettingXml.Instance.CommIP;
        }

        private void SaveSetting()
        {
            SettingXml.Instance.MachineName = txtMachine.Text;

            //환경설정에 통신 타입 설정
            SettingXml.Instance.CommType = (CommunicatorType)cbCommType.SelectedIndex;

            //통신 IP 설정
            SettingXml.Instance.CommIP = txtIpAddr.Text;

            //환경설정 저장
            SettingXml.Save();

            SLogger.Write($"통신 설정 저장");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
