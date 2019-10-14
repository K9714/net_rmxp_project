using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class SkillFunction
    {
        // Range
        public static bool IsRange(int type, int range, Character attacker, Character defender)
        {
            int new_x, new_y, dir;
            dir = attacker.direction;
            switch (type)
            {
                // 범위
                case 0:
                    new_x = Math.Abs(attacker.x - defender.x);
                    new_y = Math.Abs(attacker.y - defender.y);
                    if (new_x + new_y <= range) { return true; }
                    break;

                // 직선
                case 1:
                    new_x = dir == 4 ? -1 : dir == 6 ? 1 : 0;
                    new_y = dir == 2 ? 1 : dir == 8 ? -1 : 0;
                    for (int i = 0; i <= range; i++)
                        if (defender.x == attacker.x + new_x * i && defender.y == attacker.y + new_y * i)
                            return true;
                    break;

                // 삼각
                case 2:
                    new_x = attacker.x - defender.x;
                    new_y = attacker.y - defender.y;
                    if (dir == 6)
                        new_x *= -1;
                    if (dir == 2)
                        new_y *= -1;
                    if (dir == 4 || dir == 6)
                        if (new_x > 0 && Math.Abs(new_x) + Math.Abs(new_y) <= range)
                            return true;
                    if (dir == 2 || dir == 8)
                        if (new_y > 0 && Math.Abs(new_x) + Math.Abs(new_y) <= range)
                            return true;
                    break;

                // 분사
                case 3:
                    new_x = attacker.x - defender.x;
                    new_y = attacker.y - defender.y;
                    new_x += dir == 4 ? -(range + 1) : dir == 6 ? range + 1 : 0;
                    new_y += dir == 2 ? range + 1 : dir == 8 ? -(range + 1) : 0;
                    if (dir == 4)
                        new_x *= -1;
                    if (dir == 8)
                        new_y *= -1;
                    if (dir == 4 || dir == 6)
                        if (new_x > 0 && (Math.Abs(new_x) + Math.Abs(new_y)) <= range)
                            return true;
                    if (dir == 2 || dir == 8)
                        if (new_y > 0 && (Math.Abs(new_x) + Math.Abs(new_y)) <= range)
                            return true;
                    break;

                // 사각
                case 4:
                    new_x = Math.Abs(attacker.x - defender.x);
                    new_y = Math.Abs(attacker.y - defender.y);
                    if (new_x <= range && new_y <= range) { return true; }
                    break;
            }
            return false;
        }

        // Function
        public static void attack(UserCharacter u, UserSkill skill)
        {
            int damage = Convert.ToInt32(skill.skillData.power + skill.level * skill.skillData.level_power + (u.Int + Command.rand.Next(u.luk)) * skill.skillData.power_factor);
            u.animation(skill.skillData.use_animation);
            foreach (Enemy c in u.fieldData.Enemies)
            {
                if (c.IsDead) { continue; }
                if (IsRange(skill.skillData.range_type, skill.skillData.range, u, c))
                {
                    c.animation(skill.skillData.target_animation);
                    c.damage(damage.ToString(), false, u);
                }
            }
        }
    }
}
