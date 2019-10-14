using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NRP_Server
{
    class Chat
    {
        public static string Filter(string msg)
        {
            return msg;
        }

        public static bool Command(ClientInfo clientData, string msg)
        {
            Command admin = new Command("/admin");
            // /give user_name item_no item_num
            Command give = new Command("/give (.*) ([0-9]+) ([0-9]+)");

            if (admin.isMatch(msg))
                if (Packet.ADMIN.Contains(UserData.Users[clientData].character.name))
                {
                    UserData.Users[clientData].admin = true;
                    clientData.SendPacket(Packet.UserChat("\\C[50,250,50][관리] 관리자 모드로 변경되었습니다."));
                    return true;
                }

            if (give.isMatch(msg))
                if (UserData.Users[clientData].admin)
                {
                    string[] data = give.MatchData(msg);

                    // 데이터 검사
                    DataTable rs = Mysql.Query($"SELECT * FROM storage_item WHERE no = '{data[2]}'");
                    if (rs.Rows.Count == 0)
                    {
                        clientData.SendPacket(Packet.UserChat("\\C[50,250,50][관리] 존재하지 않는 아이템 식별 번호입니다."));
                        return true;
                    }

                    foreach (UserData u in UserData.Users.Values)
                    {
                        if (u.character == null) { continue; }
                        if (u.character.name == data[1])
                        {
                            if (Item.Items[Convert.ToInt32(data[2])] != null)
                            {
                                NRP_Server.Command.gainItem(u.character, Convert.ToInt32(data[2]), Convert.ToInt32(data[3]));
                                clientData.SendPacket(Packet.UserChat("\\C[50,250,50][관리] 성공적으로 아이템을 보냈습니다."));
                                u.clientData.SendPacket(Packet.UserChat("\\C[50,250,50][관리] 관리자에게서 아이템을 받았습니다."));
                                return true;
                            }
                        }
                    }
                    clientData.SendPacket(Packet.UserChat("\\C[50,250,50][관리] 유저가 접속중이 아닙니다."));
                    return true;
                }

            return false;
        }
    }
}
