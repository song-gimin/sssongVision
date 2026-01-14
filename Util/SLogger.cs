using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using static sssongVision.Util.SLogger;

namespace sssongVision.Util
{
    //#14_LOGFORM#
    //Util/SLogger.cs : log4net을 이용한 로그 저장 클래스
    public static class SLogger
    {
        // 로그의 종류 : 필요시 추가하기
        public enum LogType
        {
            Info,
            Error,
            Debug
        }

        // 로그 기록을 위한 인터페이스
        private static readonly ILog _log = LogManager.GetLogger(nameof(_log));

        // 로그가 추가될 때 발생하는 이벤트
        public static event Action<string> LogUpdated;

        static SLogger()
        {
        }

        // 로그를 기록하고, 이벤트 발생
        public static void Write(string message, LogType type = LogType.Info)
        {
            // 로그 파일에는 자동으로 시간이 기록됨. 타입과 메세지만 기록하면 됨.
            string logMessage = $"[{type}] {message}";

            // 파일 로그 기록
            switch (type)
            {
                case LogType.Error:
                    _log.Error(logMessage);
                    break;
                case LogType.Debug:
                    _log.Debug(logMessage);
                    break;
                default:
                    _log.Info(logMessage);
                    break;
            }

            // UI에 시간이 표시되도록 설정
            logMessage = $"[{DateTime.Now:MM-dd HH:mm:ss}] {logMessage}";

            // 로그가 추가되었음을 알려줌
            LogUpdated?.Invoke(logMessage);
        }
    }
}
