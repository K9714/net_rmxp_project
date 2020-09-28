using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class EnemyEvent
    {
        public delegate void QuestEvent(Enemy e, UserCharacter u);
        public static QuestEvent DelegateQuestEvent;
        public static void Dead(Enemy e, UserCharacter u)
        {
            // delegate 호출
            DelegateQuestEvent?.Invoke(e, u);
        }
    }
}
