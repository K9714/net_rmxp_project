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
        public static string TITLE;
        // Socket
        public static int PORT;
        public static int MAX_NUM;
        // Mysql
        public static string SERVER_IP;
        public static string HOST_NAME;
        public static int DBPORT;
        public static string USER_NAME;
        public static string PASSWORD;
        public static string DATABASE;
        // Thread
        public static int WAIT_TIME;
        // Costom Variable
        public static string line = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
        // Console Message
        public static string MAIN_MESSAGE;
        public static string SERVER_MESSAGE;
        // Game Version
        public static string VERSION;

        public static void LoadConfigData()
        {
            try
            {
                string filePath = "./Config/ServerConfig.txt";
                string fileData = System.IO.File.ReadAllText(filePath);

                string[] readData = fileData.Split('\n');
                Command title = new Command("[Tt][Ii][Tt][Ll][Ee](.*)=(.*)");
                Command port = new Command("(.*)[Pp][Oo][Rr][Tt](.*)=(.*)");
                Command max_num = new Command("[Mm][Aa][Xx]_[Nn][Uu][Mm](.*)=(.*)");

                Command server_ip = new Command("[Ss][Ee][Rr][Vv][Ee][Rr]_[Ii][Pp](.*)=(.*)");
                Command host = new Command("[Hh][Oo][Ss][Tt]_[Nn][Aa][Mm][Ee](.*)=(.*)");
                Command dbport = new Command("[Dd][Bb][Pp][Oo][Rr][Tt](.*)=(.*)");
                Command user = new Command("[Uu][Ss][Ee][Rr]_[Nn][Aa][Mm][Ee](.*)=(.*)");
                Command password = new Command("[Pp][Aa][Ss][Ss][Ww][Oo][Rr][Dd](.*)=(.*)");
                Command database = new Command("[Dd][Aa][Tt][Aa][Bb][Aa][Ss][Ee](.*)=(.*)");

                Command thread = new Command("[Ww][Aa][Ii][Tt]_[Tt][Ii][Mm][Ee](.*)=(.*)");

                Command main_message = new Command("[Mm][Aa][Ii][Nn]_[Mm][Ee][Ss][Ss][Aa][Gg][Ee](.*)=(.*)");
                Command server_message = new Command("[Ss][Ee][Rr][Vv][Ee][Rr]_[Mm][Ee][Ss][Ss][Aa][Gg][Ee](.*)=(.*)");

                Command version = new Command("[Vv][Ee][Rr][Ss][Ii][Oo][Nn](.*)=(.*)");

                foreach (string msg in readData)
                {
                    if (title.isMatch(msg))
                        TITLE = title.MatchData(msg)[2].Replace("\r", "");
                    if (port.isMatch(msg) && port.MatchData(msg)[1].Equals(""))
                        PORT = Convert.ToInt32(port.MatchData(msg)[3]);
                    if (max_num.isMatch(msg))
                        MAX_NUM = Convert.ToInt32(max_num.MatchData(msg)[2]);

                    if (server_ip.isMatch(msg))
                        SERVER_IP = server_ip.MatchData(msg)[2].Replace("\r", "");
                    if (host.isMatch(msg))
                        HOST_NAME = host.MatchData(msg)[2].Replace("\r", "");
                    if (dbport.isMatch(msg))
                        DBPORT = Convert.ToInt32(dbport.MatchData(msg)[2]);
                    if (user.isMatch(msg))
                        USER_NAME = user.MatchData(msg)[2].Replace("\r", "");
                    if (password.isMatch(msg))
                        PASSWORD = password.MatchData(msg)[2].Replace("\r", "");
                    if (database.isMatch(msg))
                        DATABASE = database.MatchData(msg)[2].Replace("\r", "");

                    if (thread.isMatch(msg))
                        WAIT_TIME = Convert.ToInt32(thread.MatchData(msg)[2]);

                    if (main_message.isMatch(msg))
                        MAIN_MESSAGE = main_message.MatchData(msg)[2].Replace("\r", "");
                    if (server_message.isMatch(msg))
                        SERVER_MESSAGE = server_message.MatchData(msg)[2].Replace("\r", "");

                    if (version.isMatch(msg))
                        VERSION = version.MatchData(msg)[2].Replace("\r", "");
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
