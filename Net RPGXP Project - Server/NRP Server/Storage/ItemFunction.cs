using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class ItemFunction
    {
        // Recovery Value
        public static bool RecoveryHpValue(UserCharacter u, Item item, int value)
        {
            u.animation(item.animation_id);
            u.damage((-value).ToString(), false);
            return true;
        }
        public static bool RecoveryMpValue(UserCharacter u, Item item, int value)
        {
            return true;
        }
        public static bool RecoveryAllValue(UserCharacter u, Item item, int value)
        {
            return true;
        }

        // Recovery Rate
        public static bool RecoveryHpRate(UserCharacter u, Item item, int value)
        {
            return true;
        }
        public static bool RecoveryMpRate(UserCharacter u, Item item, int value)
        {
            return true;
        }
        public static bool RecoveryAllRate(UserCharacter u, Item item, int value)
        {
            return true;
        }

        // Skill Book
        public static bool LearnCharacterSkill(UserCharacter u, Item item, int value)
        {
            if (!u.Skills.ContainsKey(Skill.Skills[value]))
            {
                u.learnSkill(Skill.Skills[value]);
            }
            else
            {
                u.userData.clientData.SendPacket(Packet.Dialog(0, "아이템 사용 불가", "이미 배운 스킬입니다."));
                return false;
            }
            return true;
        }

        // Enemy
        public static bool addEnemy(UserCharacter u, Item item, int value)
        {
            u.fieldData.addEnemy(value, u.x, u.y - 1);
            return true;
        }
    }
}
