using System;
using System.Data;

namespace NRP_Server
{
    class Exp
    {
        public static int[] list;
        public static void loadData()
        {
            DataTable ds = Mysql.Query($"SELECT * FROM level_up");
            list = new int[ds.Rows.Count];
            foreach (DataRow rs in ds.Rows)
                list[Convert.ToInt32(rs["no"])-1] = Convert.ToInt32(rs["next_exp"]);
            Msg.Info($"[경험치] {ds.Rows.Count}개 로드 완료.");
        }

        public static int getLevel(int level)
        {
            return list[level];
        }

        public static int[] getList()
        {
            return list;
        }
    }
}
