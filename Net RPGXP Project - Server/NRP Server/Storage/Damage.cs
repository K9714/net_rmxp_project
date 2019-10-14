using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class Damage
    {
        public static string atk(Character attacker, Character defender, bool critical)
        {
            int dex_deffer, dmg;
            int cri = critical ? 2 : 1;
            string string_dmg;

            dex_deffer = defender.dex - attacker.dex;
            dmg = (attacker.str + Command.rand.Next(attacker.luk) - defender.pdef) * cri;
            string_dmg = dmg < 0 ? "0" : dmg.ToString();
            if (dex_deffer > 0 && dex_deffer < 500)
                string_dmg = (Command.rand.Next(500) + 1 > dex_deffer ? string_dmg : "Miss");
            else if (dex_deffer >= 500)
                string_dmg = "Miss";
            return string_dmg;
        }
    }
}
