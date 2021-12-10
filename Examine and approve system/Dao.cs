using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Examine_and_approve_system
{
    class Dao
    {
        MySqlConnection sqlcon1;
        public MySqlConnection connect()
        {
            string constring = "datasource=localhost ; user = root; password = 123456; database = approval_sys;";
            sqlcon1 = new MySqlConnection(constring);
            sqlcon1.Open();
            return sqlcon1;
        }
        public MySqlCommand command(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)//更新操作，int是返回的行数的数据类型
        {
            return command(sql).ExecuteNonQuery();
        }
        public MySqlDataReader read(string sql)//读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sqlcon1.Close();//关闭数据库链接
        }
    }
}