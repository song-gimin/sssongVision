using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sssongVision.Algorithm;
using OpenCvSharp;
using System.IO;
using System.Xml.Serialization;
using sssongVision.Core;

namespace sssongVision.Teach
{
    /*
    #10_INSPWINDOW# - <<<검사 ROI>>> 
    검사할 영역을 정의하는 클래스로, 검사 알고리즘을 포함하고 있다.
    1) Teach / InspWindow; 클래스 생성 - 검사 영역을 정의하는 클래스
    2) Teach / InspWindowFactory 클래스 생성 - InspWindow 객체를 생성하는 팩토리 클래스
    3) Teach / Model 클래스 생성 - InspWindowList를 관리하는 클래스로, 검사를 위한 모델 정보를 저장한다.
    4) Teach / DiagramEntity 클래스 생성 - InspWindow를 ImageViewCtrl에 표시하기 위한 클래스
    */

    public class InspWindow
    {
        public InspWindowType InspWindowType { get; set; }

        public string Name { get; set; }

        public string UID { get; set; }

        public Rect WindowArea { get; set; }

        public Rect InspArea { get; set; }

        public bool IsTeach { get; set; } = false;

        public List<InspAlgorithm> AlgorithmList { get; set; } = new List<InspAlgorithm>();


    }
}
