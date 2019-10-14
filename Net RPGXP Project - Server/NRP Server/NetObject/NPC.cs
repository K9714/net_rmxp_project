using System;
using System.Collections.Generic;
using System.Data;

namespace NRP_Server
{
    // DB 정보를 기반으로 txt 파일 로드
    class NPC : Character
    {
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        public int id { get; private set; }
        public int pattern { get; private set; }
        public int default_action { get; private set; }

        public Dictionary<int, Message> Messages = new Dictionary<int, Message>();
        public Dictionary<int, Action> Actions = new Dictionary<int, Action>();
        public Dictionary<int, StoreCommand> Stores = new Dictionary<int, StoreCommand>();
        public Dictionary<int, FunctionCommand> Functions = new Dictionary<int, FunctionCommand>();

        public NPC(DataRow rs)
        {
            no = ToInt(rs["no"]);
            name = rs["name"].ToString();
            image = rs["image"].ToString();
            id = ToInt(rs["id"]);
            mapid = ToInt(rs["map_id"]);
            x = ToInt(rs["map_x"]);
            y = ToInt(rs["map_y"]);
            direction = ToInt(rs["direction"]);
            pattern = ToInt(rs["pattern"]);
            move_speed = ToInt(rs["move_speed"]);
            default_action = ToInt(rs["default_action"]);
            loadData();
        }

        public bool loadData() 
        {
            try
            {
                Command message = new Command("MESSAGE=([0-9]+),([0-9]+|[0-9]\\[(.*)\\]),(.*)");
                Command action = new Command("ACTION=([0-9]+),(.*),(.*)");
                Command button = new Command("([0-9]+)\\[(.*)\\]");
                Command store = new Command("STORE=([0-9]+),([0-9]+),([0-9]+)");
                Command function = new Command("FUNCTION=([0-9]+),([0-9]+),(.*)");

                int[] buttons;
                int i;

                string filePath = $"./NPCData/NPC{no}.dat";
                string fileData = System.IO.File.ReadAllText(filePath).Replace("\r", "");

                string[] readData = fileData.Split('\n');
                string[] matchData;

                foreach (string cmd in readData)
                {
                    // 메세지 커맨드
                    if (message.isMatch(cmd))
                    {
                        Message obj;
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
                            obj = new Message(this, ToInt(matchData[1]), buttons, matchData[4]);
                            obj.button = true;
                        }
                        // 메세지 버튼 데이터 없는 경우
                        else
                        {
                            buttons = new int[1];
                            buttons[0] = ToInt(matchData[2]);
                            obj = new Message(this, ToInt(matchData[1]), buttons, matchData[4]);
                        }
                        Messages.Add(obj.index, obj);
                    }
                    // 액션 커맨드
                    if (action.isMatch(cmd))
                    {
                        Action obj;
                        matchData = action.MatchData(cmd);

                        obj = new Action(this, ToInt(matchData[1]), matchData[2], matchData[3]);
                        Actions.Add(obj.index, obj);
                    }
                    // 상점 커맨드
                    if (store.isMatch(cmd))
                    {
                        StoreCommand obj;
                        matchData = store.MatchData(cmd);

                        obj = new StoreCommand(this, Store.List[ToInt(matchData[2])], ToInt(matchData[1]), ToInt(matchData[3]));
                        Stores.Add(obj.index, obj);
                    }
                    // 함수 커맨드
                    if (function.isMatch(cmd))
                    {
                        FunctionCommand obj;
                        matchData = function.MatchData(cmd);

                        obj = new FunctionCommand(this, ToInt(matchData[1]), ToInt(matchData[2]), matchData[3], cmd);
                        Functions.Add(obj.index, obj);
                    }
                }
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
                return false;
            }
            return true;
        }


        public void startEvent(UserCharacter u)
        {
            if (!u.isMessage)
            {
                u.isMessage = true;
                u.page = default_action;
                u.npcData = this;
            }
            if (u.page != 0)
                Actions[u.page].start(u);
            else
                u.resetMessage();
        }
    }

    // NPC - Message & Action
    class Message
    {
        public NPC npcData { get; private set; }
        public int index { get; private set; }
        public int[] actions { get; private set; }
        public string text { get; private set; }
        public bool button { get; set; }

        public Message(NPC _npc, int _index, int[] _action, string _text)
        {
            npcData = _npc;
            index = _index;
            actions = _action;
            text = _text;
            button = false;
        }
    }
    class Action
    {
        public NPC npcData { get; private set; }
        public int index { get; private set; }
        public string text { get; private set; }
        public string command { get; private set; }
        public string[] split_command { get; private set; }

        public Action(NPC _npc, int _index, string _text, string _cmd)
        {
            npcData = _npc;
            index = _index;
            text = _text;
            command = _cmd;
            split_command = _cmd.Split(':');
        }

        public void start(UserCharacter u)
        {
            string[] cmd;
            int index;

            cmd = split_command;
            // IF:INT:strUNE0:
            if (cmd[0] == "IF")
            {
                string[] data = command.Split(';');
                Command con = new Command("IF:(.*)\\[(.*)\\](.*)");
                string[] conData = con.MatchData(data[0]);
                // 조건 비교
                #region 안보는거 추천
                switch (conData[2])
                {
                    // EQU (equal ==)
                    case "EQU":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) == Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        catch
                        {
                            if (u.GetType().GetProperty(conData[1]).GetValue(u, null) == u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        
                        break;
                    // UNE (unequal !=)
                    case "UNE":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) != Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        catch
                        {
                            if (u.GetType().GetProperty(conData[1]).GetValue(u, null) != u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        break;
                    // MOR (>=)
                    case "MOR":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) >= Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                            
                        }
                        catch
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) >= (int)u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        break;
                    // BEL (<=)
                    case "BEL":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) <= Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');

                        }
                        catch
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) <= (int)u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        break;
                    // EXC (>)
                    case "EXC":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) > Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');

                        }
                        catch
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) > (int)u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        break;
                    // UND (<)
                    case "UND":
                        try
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) < Convert.ToInt32(conData[3]))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');

                        }
                        catch
                        {
                            if ((int)u.GetType().GetProperty(conData[1]).GetValue(u, null) < (int)u.GetType().GetProperty(conData[3]).GetValue(u, null))
                                cmd = data[1].Split(':');
                            else
                                cmd = data[2].Split(':');
                        }
                        break;
                }
                #endregion
            }
            // command 로 분기
            switch (cmd[0])
            {
                case "MESSAGE":
                    index = Convert.ToInt32(cmd[1]);
                    u.action = npcData.Messages[index].actions;
                    u.userData.clientData.SendPacket(Packet.EventTrigger(npcData.Messages[index]));
                    break;

                case "END":
                    u.resetMessage();
                    break;

                case "STORE":
                    index = Convert.ToInt32(cmd[1]);
                    u.page = npcData.Stores[index].action;
                    Store.Show(u, npcData.Stores[index].storeData.no);
                    npcData.startEvent(u);
                    break;

                case "FUNCTION":
                    index = Convert.ToInt32(cmd[1]);
                    u.page = npcData.Functions[index].action;
                    if (typeof(NPCFunction).GetMethod(npcData.Functions[index].func) != null)
                    {
                        object[] args = { u, npcData };
                        typeof(NPCFunction).GetMethod(npcData.Functions[index].func).Invoke(null, args);
                    }
                    npcData.startEvent(u);
                    break;
            }
        }
    }

    // Store
    class StoreCommand
    {
        public NPC npcData { get; private set; }
        public Store storeData { get; private set; }
        public int index { get; private set; }
        public int action { get; private set; }

        public StoreCommand(NPC _npc, Store _store, int _index, int _action)
        {
            npcData = _npc;
            storeData = _store;
            index = _index;
            action = _action;
        }
    }

    // Function
    class FunctionCommand
    { 
        public NPC npcData { get; private set; }
        public string func { get; private set; }
        public int index { get; private set; }
        public int action { get; private set; }
        public string string_command { get; private set; }

        public FunctionCommand(NPC _npc, int _index, int _action, string _func, string _strcmd)
        {
            npcData = _npc;
            index = _index;
            action = _action;
            func = _func;
            string_command = _strcmd;
        }
    }
}
