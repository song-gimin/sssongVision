using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sssongVision.Core
{
    // #8_INSPECT_BINARY# 이진화 검사 구현
    // Define.cs : 프로그램 전체적으로 전역 설정이나, 타입을 정의하기 위한 클래스
    
    public enum DecisionType
    {
        None = 0,
        Good,           //양품
        Defect,         //불량
        Info,
        Error,          //오류
        Timeout         //타임아웃
    }

    internal class Define
    {
        //# SAVE ROI#4 전역적으로, ROI 저장 파일명을 설정
        //Define.cs 클래스 생성 먼저 할것
        public static readonly string ROI_IMAGE_NAME = "RoiImage.png";
    }
}
