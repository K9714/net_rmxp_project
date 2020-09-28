using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace NRP_Server
{
    class Program
    {
        public static Handler SocketObject;
        static void Main(string[] args)
        {
            // Title
            Config.LoadConfigData();
            Console.Title = Config.TITLE;

            // Welcome Message
            Msg.ColorWriteLine(Config.line + "\n", ConsoleColor.White);
            Msg.ColorWriteLine("\t" + Config.MAIN_MESSAGE, ConsoleColor.Gray);
            Msg.ColorWriteLine("\n" + Config.line, ConsoleColor.White);
            Msg.Info(Config.SERVER_MESSAGE + " (포트 :" + Config.PORT + ")");

            // Socket Set
            SocketObject = new Handler();
            SocketObject.Start();
        }
    }
}
