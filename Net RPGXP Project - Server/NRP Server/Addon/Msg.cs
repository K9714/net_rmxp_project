using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRP_Server
{
    class Msg
    {
        private static object lockObject = new object();

        static public void Error(string msg)
        {
            Write("[" + DateTime.Now.ToString("HH:mm:ss") + "]");
            ColorWrite("[오류] ", ConsoleColor.Red);
            WriteLine(msg);
        }

        static public void Info(string msg)
        {
            Write("[" + DateTime.Now.ToString("HH:mm:ss") + "]");
            ColorWrite("[정보] ", ConsoleColor.Blue);
            WriteLine(msg);
        }

        static public void Connect(string msg)
        {
            Write("[" + DateTime.Now.ToString("HH:mm:ss") + "]");
            ColorWrite("[연결] ", ConsoleColor.Green);
            WriteLine(msg);
        }

        static public void Write(string msg)
        {
            Console.Write(msg);
        }

        static public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        static public void ColorWrite(string msg, ConsoleColor color, bool reset=true)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            if (reset) { Console.ForegroundColor = ConsoleColor.White; }
        }

        static public void ColorWriteLine(string msg, ConsoleColor color, bool reset = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            if (reset) { Console.ForegroundColor = ConsoleColor.White; }
        }
    }
}
