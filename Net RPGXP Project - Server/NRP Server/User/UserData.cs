using System;
using System.Collections.Generic;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;

namespace NRP_Server
{
    class UserData
    {
        #region 컨버터
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        #endregion
        // static
        public static Dictionary<ClientInfo, UserData> Users = new Dictionary<ClientInfo, UserData>();
        public static ArrayList getArray()
        {
            ArrayList ary = new ArrayList(Users.Values);
            return ary;
        }

        // public Variable
        public ClientInfo clientData;
        public Dictionary<int, UserCharacter> characters;

        // property Variable
        public int no { get; private set; }
        public UserCharacter character { get; private set; }
        public bool admin { get; set; }

        // Object
        public UserData(ClientInfo c)
        {
            clientData = c;
        }

        // 유저 정보 세팅
        public void loadData(DataRow rs)
        {
            // 데이터 로드
            no = ToInt(rs["no"]);

            // 캐릭터 로드
            loadCharacter();
        }
        public void loadCharacter()
        {
            int index = 0;
            UserCharacter _char;

            characters = new Dictionary<int, UserCharacter>();
            DataTable u = Mysql.Query($"SELECT * FROM user_character WHERE user_no ='{no}'");
            if (u == null) { return; }
            foreach (DataRow c in u.Rows)
            {
                _char = new UserCharacter(this, index);
                _char.loadData(c);
                characters.Add(index, _char);
                index++;
            }
        }

        // 유저 정보 저장
        public void saveData(bool shutdown=false)
        {
            // 오프라인으로 변경
            if (shutdown)
            {
                Mysql.Query($"UPDATE user_information SET online = '0' WHERE no = '{no}'");
                if (character != null)
                    character.fieldData.leave(character.no);

                foreach (UserCharacter c in characters.Values)
                    c.saveData();
            }

        }

        // 캐릭터 선택
        public bool selectCharacter(int _index)
        {
            if (character != null)
                return false;
            if (!characters.ContainsKey(_index))
                return false;
            character = characters[_index];
            character.loadItems();
            character.loadSkills();
            Map.Maps[character.mapid].Fields[0].join(character, character.x, character.y);
            return true;
        }

        // 캐릭터 삭제
        public bool deleteCharacter(int _index)
        {
            int no;
            if (character != null)
                return false;
            if (!characters.ContainsKey(_index))
                return false;
            no = characters[_index].no;
            // 소지품 정보 제거
            Mysql.Query($"DELETE FROM user_inventory WHERE char_no = '{no}'");
            // 장비 정보 제거
            Mysql.Query($"DELETE FROM user_equipment WHERE char_no = '{no}'");
            // 캐릭터 정보 제거
            Mysql.Query($"DELETE FROM user_character WHERE no = '{no}'");
            // 마지막은 캐릭터 로드
            loadCharacter();
            return true;
        }
    }
}
