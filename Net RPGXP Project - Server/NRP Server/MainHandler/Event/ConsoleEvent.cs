using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NRP_Server
{
    public static class ConsoleEvent
    {
        public static void Initialize()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CloseEvent);
        }

        // Close Event
        public static void CloseEvent(object sender, ConsoleCancelEventArgs e)
        {
            Msg.Close("서버 종료 준비중...");
            foreach (UserData u in UserData.Users.Values)
                u.saveData(true);
            Msg.Close("유저 데이터 저장 완료.");
            ServerThread.Stop();
            Msg.Close("멀티 쓰레드 종료 완료.");
            Program.SocketObject.ShutDown();
        }
    }
}
