using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DB_Manager
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
            connection = null;
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
                Console.warning(e.ToString());
                return null;
            }

        }
    }
}
