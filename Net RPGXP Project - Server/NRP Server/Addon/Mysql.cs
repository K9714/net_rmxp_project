using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System;

namespace NRP_Server
{
    internal class Mysql
    {
        static private MySqlConnection connection;
        static private string strConn;

        static public void connect(string ip, string db, string uid, string pass)
        {

            Mysql.strConn = "Server=" + ip + ";";
            Mysql.strConn += "Database=" + db + ";";
            Mysql.strConn += "Uid=" + uid + ";";
            Mysql.strConn += "Pwd=" + pass + ";";

            connection = new MySqlConnection(strConn);
            connection.Open();
        }
        static public void disconnect()
        {
            connection.Close();
        }
        static public bool ping()
        {
            if (connection == null)
                return false;
            return connection.Ping();
        }

        // 쿼리문 실행
        static public DataTable Query(string cmd)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd + ";", connection);
                adapter.Fill(ds, "Data");
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return dt;
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
                return null;
            }

        }
        /*
            MySqlDataReader rs = Mysql.Query("쿼리문;");
            rs["데이터"] 로 읽기.

            여러 개의 데이터의 경우 rs.Read() 를 호출하면 됨.
            while (rs.Read())
            {
                Msg.Info(rs["name"].ToString());
            }
            이런 식.
        */
    }

}
