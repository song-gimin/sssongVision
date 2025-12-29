using sssongVision.Core;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sssongVision.Algorithm
{
    // 이진화 Preview 구현
    // 이진화 검사를 위한 Preview를 R,G,B,Mono 별로 보여주는 기능 구현
    // InspAlgorithm.cs : 검사 알고리즘을 위한 추상화 클래스

    // 검사 알고리즘 타입
    public enum InspectType
    {
        InspNone = -1,
        InspBinary,
        InspCount
    }

    public abstract class InspAlgorithm
    {
        // 알고리즘 타입 정의
        public InspectType InspectType { get; set; } = InspectType.InspNone;

        // 알고리즘 사용할지 여부 결정
        public bool IsUse { get; set; } = true;

        // 검사가 완료되었는지 판단
        public bool IsInspected { get; set; } = false;

        // 검사할 원본 이미지
        protected Mat _srcImage = null;

        // 검사 결과 정보
        public List<string> ResultString { get; set; } = new List<string>();

        // 불량 여부 확인
        public bool IsDefect { get; set; }

        // 검사 함수로, 상속받는 클래스 필수 구현 필요.
        public abstract bool DoInspect();

        // 검사 결과 정보 초기화
        public virtual void ResetResult()
        {
            IsInspected = false;
            IsDefect = false;
            ResultString.Clear();
        }
    }
}
