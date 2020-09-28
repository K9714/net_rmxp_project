using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server.Storage
{
    class QuestData
    {
        public UserCharacter userData;
        public Quest questData;
        public bool IsStart { get; private set; }
        public bool IsComplete { get; private set; }
        public int count { get; private set; }

        public QuestData(UserCharacter u, Quest q)
        {
            userData = u;
            questData = q;
            start();
        }

        public void start()
        {
            // 조건 세팅
            IsStart = true;
            IsComplete = false;
            // 타입별로 분기(조건별로 분기)
            /* Quest.type
             * 0 : [몬스터 처치] Quest.count_no 몬스터 Quest.count 마리 잡기
             * 1 : [아이템 수집] Quest.count_no 아이템 Quest.count 개 모으기
             * 2 : [특정 NPC 대화] Quest.count_no NPC와 대화
             */
            switch (questData.type)
            {
                case 0:
                    EnemyEvent.DelegateQuestEvent += EnemyDeadEvent;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        // 총괄
        public void clear()
        {
            if (IsComplete)
            {

            }
        }

        // 임시로 테스트 (유저 구분자 있어야 함.)
        public void EnemyDeadEvent(Enemy e, UserCharacter u)
        {
            if (userData != u) { return; }
            if (e.no != questData.count_no) { return; }
            count++;
            if (count >= questData.count)
            {
                // 모든 조건이 완료되었다면 앞서 추가했던 deleagte 제거
                EnemyEvent.DelegateQuestEvent -= EnemyDeadEvent;
                IsComplete = true;
            }
        }

       
    }
}
