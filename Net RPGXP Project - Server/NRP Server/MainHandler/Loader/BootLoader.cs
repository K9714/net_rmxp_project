using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    public static class BootLoader
    {
        public static void Initialize()
        {
            MysqlDataLoad();
        }

        public static void MysqlDataLoad()
        {
            Mysql.connect(Config.SERVER_IP, Config.DATABASE, Config.USER_NAME, Config.PASSWORD);
            Msg.Connect("MySQL 서버에 연결되었습니다.");
            // 경험치 로드
            Exp.loadData();
            // 아이템 등등 로드
            Item.loadData();
            Store.loadData();
            // 스킬 로드
            Skill.loadData();
            // 맵 세팅
            Map.loadData();
        }
    }
}
