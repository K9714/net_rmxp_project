using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Manager
{
    public class NPCData
    {
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        public ArrayList List;

        public NPCData(string path, int no, NPC nData)
        {
            loadData(path, no, nData);
        }

        private void loadData(string path, int no, NPC nData)
        {
            
            List = new ArrayList();
            try {
                string filePath = $"{path}\\NPC{no}.dat";
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, "");
                string fileData = File.ReadAllText(filePath).Replace("\r", "");

                string[] readData = fileData.Split('\n');

                foreach (string cmd in readData)
                    addData(cmd, nData);
            }
            catch(Exception e)
            {
                Console.warning(e.ToString());
            }
        }
        public void addData(string cmd, NPC nData=null)
        {
            try
            {
                Command message = new Command("MESSAGE=([0-9]+),([0-9]+|[0-9]\\[(.*)\\]),(.*)");
                Command action = new Command("ACTION=([0-9]+),(.*),(.*)");
                Command button = new Command("([0-9]+)\\[(.*)\\]");
                Command store = new Command("STORE=([0-9]+),([0-9]+),([0-9]+)");
                Command function = new Command("FUNCTION=([0-9]+),([0-9]+),(.*)");
                string[] matchData;
                int[] buttons;
                int i;

                // 메세지 커맨드
                if (message.isMatch(cmd))
                {
                    NPCMessage obj;
                    matchData = message.MatchData(cmd);

                    // 메세지 버튼 데이터 있는 경우
                    if (button.isMatch(matchData[2]))
                    {
                        i = 0;
                        buttons = new int[ToInt(button.MatchData(matchData[2])[1])];
                        foreach (string action_id in matchData[3].Split(','))
                        {
                            buttons[i] = ToInt(action_id);
                            i++;
                        }
                        obj = new NPCMessage(nData, ToInt(matchData[1]), buttons, matchData[4], cmd);
                        obj.button = true;
                    }
                    // 메세지 버튼 데이터 없는 경우
                    else
                    {
                        buttons = new int[1];
                        buttons[0] = ToInt(matchData[2]);
                        obj = new NPCMessage(nData, ToInt(matchData[1]), buttons, matchData[4], cmd);
                    }
                    List.Add(obj);
                }
                // 액션 커맨드
                if (action.isMatch(cmd))
                {
                    NPCAction obj;
                    matchData = action.MatchData(cmd);

                    obj = new NPCAction(nData, ToInt(matchData[1]), matchData[2], matchData[3], cmd);
                    List.Add(obj);
                }
                // 상점 커맨드
                if (store.isMatch(cmd))
                {
                    NPCStore obj;
                    matchData = store.MatchData(cmd);

                    obj = new NPCStore(nData, ToInt(matchData[2]), ToInt(matchData[1]), ToInt(matchData[3]), cmd);
                    List.Add(obj);
                }
                // 함수 커맨드
                if (function.isMatch(cmd))
                {
                    NPCFunction obj;
                    matchData = function.MatchData(cmd);

                    obj = new NPCFunction(nData, ToInt(matchData[1]), ToInt(matchData[2]), matchData[3], cmd);
                    List.Add(obj);
                }
            }
            catch (Exception e)
            {
                Console.warning(e.ToString());
            }
        }
        public void delData(object obj)
        {
            if (List.Contains(obj))
                List.Remove(obj);
        }
    }

    public class NPCMessage
    {
        public NPC npcData { get; private set; }
        public int index { get; private set; }
        public int[] actions { get; private set; }
        public string text { get; private set; }
        public bool button { get; set; }
        public string string_command { get; private set; }

        public NPCMessage(NPC _npc, int _index, int[] _action, string _text, string _strcmd)
        {
            npcData = _npc;
            index = _index;
            actions = _action;
            text = _text;
            button = false;
            string_command = _strcmd;
        }
    }
    public class NPCAction
    {
        public NPC npcData { get; private set; }
        public int index { get; private set; }
        public string text { get; private set; }
        public string command { get; private set; }
        public string[] split_command { get; private set; }
        public string string_command { get; private set; }

        public NPCAction(NPC _npc, int _index, string _text, string _cmd, string _strcmd)
        {
            npcData = _npc;
            index = _index;
            text = _text;
            command = _cmd;
            split_command = _cmd.Split(':');
            string_command = _strcmd;
        }
    }
    public class NPCStore
    {
        public NPC npcData { get; private set; }
        public int store_no { get; private set; }
        public int index { get; private set; }
        public int action { get; private set; }
        public string string_command { get; private set; }

        public NPCStore(NPC _npc, int _store_no, int _index, int _action, string _strcmd)
        {
            npcData = _npc;
            store_no = _store_no;
            index = _index;
            action = _action;
            string_command = _strcmd;
        }
    }
    public class NPCFunction
    {
        public NPC npcData { get; private set; }
        public string func { get; private set; }
        public int index { get; private set; }
        public int action { get; private set; }
        public string string_command { get; private set; }

        public NPCFunction(NPC _npc, int _index, int _action, string _func, string _strcmd)
        {
            npcData = _npc;
            index = _index;
            action = _action;
            func = _func;
            string_command = _strcmd;
        }
    }
}
