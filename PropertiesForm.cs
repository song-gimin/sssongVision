using sssongVision.Algorithm;
using sssongVision.Core;
using sssongVision.Property;
using sssongVision.Teach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace sssongVision
{
    public partial class PropertiesForm : DockContent
    {
        // 속성 탭을 관리하기 위한 딕셔너리
        Dictionary<string, TabPage> _allTabs = new Dictionary<string, TabPage>();

        public PropertiesForm()
        {
            InitializeComponent();
        }

        // 속성 탭 생성 : 부모변수로 받음
        // PropertyType에서 InspectType로 변경
        private UserControl CreateUserControl(InspectType inspPropType)
        {
            UserControl curProp = null;

            switch (inspPropType)
            {
                case InspectType.InspBinary:
                    BinaryProp blobProp = new BinaryProp();
                    //#7_BINARY_PREVIEW#8 이진화 속성 변경시 발생하는 이벤트 추가
                    blobProp.RangeChanged += RangeSlider_RangeChanged;
                    blobProp.PropertyChanged += PropertyChanged;
                    curProp = blobProp;
                    break;
                case InspectType.InspFilter:
                    ImageFilterProp filterProp = new ImageFilterProp();
                    curProp = filterProp;
                    break;
                case InspectType.InspAIModule:
                    SaigeAIProp saigeProp = new SaigeAIProp();
                    curProp = saigeProp;
                    break;
                default:
                    MessageBox.Show("유효하지 않은 옵션입니다.");
                    return null;
            }
            return curProp;
        }

        // 속성 탭이 있다면 반환하고, 없다면 새로 생성하기
        // PropertyType에서 InspectType로 변경
        private void LoadOptionControl(InspectType inspType)
        {
            string tabName = inspType.ToString();

            // 이미 탭이 존재하는지 확인
            foreach (TabPage tabPage in tabPropControl.TabPages)
            {
                if (tabPage.Name == tabName) return;
            }

            // 딕셔너리에 있으면 추가
            if (_allTabs.TryGetValue(tabName, out TabPage page))
            {
                tabPropControl.TabPages.Add(page);
                return;
            }

            // 새로운 UserControl 생성
            UserControl _inspProp = CreateUserControl(inspType);
            if (_inspProp == null) return; // UserControl 생성이 실패했을 때 방어

            // 새로운 tab 생성
            TabPage newTab = new TabPage(tabName)
            {
                Dock = DockStyle.Fill
            };

            _inspProp.Dock = DockStyle.Fill;
            newTab.Controls.Add(_inspProp);

            tabPropControl.TabPages.Add(newTab);
            tabPropControl.SelectedTab = newTab; // 새 탭 선택

            _allTabs[tabName] = newTab;
        }

        //#11_MODEL_TREE#3 InspWindow에서 사용하는 알고리즘을 모두 탭에 추가
        public void ShowProperty(InspWindow window)
        {
            foreach (InspAlgorithm algo in window.AlgorithmList)
            {
                LoadOptionControl(algo.InspectType);
            }
        }

        public void ResetProperty()
        {
            tabPropControl.TabPages.Clear();
        }

        // BlobAlgorithm에서 InspWindow로 수정
        public void UpdateProperty(InspWindow window)
        {
            if (window is null) return;

            foreach (TabPage tabPage in tabPropControl.TabPages)
            {
                if (tabPage.Controls.Count > 0)
                {
                    UserControl uc = tabPage.Controls[0] as UserControl;

                    if (uc is BinaryProp binaryProp)
                    {
                        BlobAlgorithm blobAlgo = (BlobAlgorithm)window.FindInspAlgorithm(InspectType.InspBinary);
                        if (blobAlgo is null) continue;
                        binaryProp.SetAlgorithm(blobAlgo);
                    }
                }
            }
        }

        //#7_BINARY_PREVIEW#7 이진화 속성 변경시 발생하는 이벤트 구현
        private void RangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            // 속성값을 이용하여 이진화 임계값 설정
            int lowerValue = e.LowerValue;
            int upperValue = e.UpperValue;
            bool invert = e.Invert;
            ShowBinaryMode showBinMode = e.ShowBinMode;
            Global.Inst.InspStage.PreView?.SetBinary(lowerValue, upperValue, invert, showBinMode);
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            Global.Inst.InspStage.RedrawMainView();
        }
    }
}
