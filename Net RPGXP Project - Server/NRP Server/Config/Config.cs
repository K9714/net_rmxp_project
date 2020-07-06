using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRP_Server
{
    class Config
    {
        // Server
        public static string TITLE       = "Net RMXP Prject Server - by. Allfea (allfea_@naver.com)";
        // Socket
        public static int    PORT        = 50002; //건드리시면 일부문제가발생합니다.
        public static int    MAX_NUM     = 100; //최대인원
        // Mysql
        public static string SERVER_IP   = "127.0.0.1"; //꼭 자신의IP로 수정하세요!
        public static string HOST_NAME   = "localhost";
        public static int    SQLPORT     = 3306;
        public static string USER_NAME   = "root"; //DB유저 이름
        public static string PASSWORD    = "apmsetup"; //DB 패스워드
        public static string DATABASE    = "net_rmxp_project"; //DB이름
        // Thread
        public static int    WAIT_TIME   = 100;
        // Costom Variable
        public static string line = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
        // Console Message
        public static string MAIN_MESSAGE = line + "\n\n\tNet RMXP Prject Server (2018.06.12)\n\n" + line;
        public static string SERVER_MESSAGE = "서버를 시작합니다.";
        // Game Version
        public static string VERSION     = "1.00";
    }
}
