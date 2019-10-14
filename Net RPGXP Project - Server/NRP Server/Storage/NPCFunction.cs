using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class NPCFunction
    {
        public static void testFunction(UserCharacter u, NPC npcData)
        {
            Msg.Info(u.name);
            Msg.Info(npcData.name);
        }
    }
}
