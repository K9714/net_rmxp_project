using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NRP_Server
{
    class UserSkill
    {
        public int no { get; private set; }
        public int skill_no { get; private set; }
        public int level { get; private set; }
        
        public Skill skillData { get; private set; }
        // 
        public int wait_time { get; set; }
        public bool IsActive { get; set; }
        public int count { get; set; }
        public int delay { get; set; }

        public UserSkill(Skill skill, DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            skill_no = Convert.ToInt32(rs["skill_no"]);
            level = Convert.ToInt32(rs["level"]);
            wait_time = Convert.ToInt32(rs["wait_time"]);
            skillData = skill;
            IsActive = false;
        }

        public UserSkill(Skill skill)
        {
            no = 0;
            skill_no = skill.no;
            level = 1;
            wait_time = 0;
            skillData = skill;
            IsActive = false;
        }

        public void active(UserCharacter u)
        {
            if (!IsActive && wait_time == 0)
            {
                IsActive = true;
                count = skillData.count;
                delay = 0;
                // MP 깎아야됨
                if (!Skill.userData.ContainsKey(u.no))
                    Skill.userData.Add(u.no, u);                
            }
            else
            {
                // 대기중 또는 사용중
            }
        }
    }
}
