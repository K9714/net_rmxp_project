using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NRP_Server
{
    class StringConverter
    {
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        // 완성 형식은 Hashtable 이며
        // key:value|key:value|...
        // 위와 같이 함
        // int형     : \i
        // double형  : \f
        public static string Encode(Hashtable data)
        {
            string sendData = "";
            string convert;
            foreach (DictionaryEntry de in data)
            {
                sendData += de.Key + ":";
                if (de.Value.GetType().ToString().Equals("System.Int32")) { sendData += "\\i"; }
                if (de.Value.GetType().ToString().Equals("System.Double")) { sendData += "\\d"; }
                convert = de.Value.ToString();
                convert.Replace(":", "\\cm");
                convert.Replace("|", "\\v");
                sendData += convert + "|";
            }
            return sendData;
        }

        public static Hashtable Decode(string data)
        {
            Hashtable recvData = new Hashtable();
            try
            {
                string[] dataLine;
                string[] kvLine;

                dataLine = data.Split('|');
                foreach (string kv in dataLine)
                {
                    if (kv != "")
                    {
                        kvLine = kv.Split(':');
                        kvLine[1].Replace("\\cm", ":");
                        kvLine[1].Replace("\\v", "|");
                        if (kvLine[1].Contains("\\i"))
                        {
                            kvLine[1] = kvLine[1].Replace("\\i", "");
                            recvData.Add(kvLine[0], Convert.ToInt32(kvLine[1]));
                        }
                        else if (kvLine[1].Contains("\\d"))
                        {
                            kvLine[1] = kvLine[1].Replace("\\d", "");
                            recvData.Add(kvLine[0], Convert.ToDouble(kvLine[1]));
                        }
                        else
                        {
                            recvData.Add(kvLine[0], kvLine[1]);
                        }

                    }
                }
            }
            catch(Exception e)
            {
                Msg.Error(e.ToString());
            }
            return recvData;
        }
    }
}
