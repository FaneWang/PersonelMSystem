using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PersonelMSystem.DataClass
{
    class DatabaseUtils
    {
        public string connStr;
        public DatabaseUtils()
        {
            this.connStr = this.getConnStr();
        }

        // 获取数据库连接
        public static SqlConnection getSqlConnection(string connStr)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            return sqlConnection;
        }

        #region 获取配置文件中的数据库连接字符串
        private string getConnStr()
        {
            string configPath = System.Windows.Forms.Application.StartupPath + "\\database.xml";
            XElement xe = XElement.Load(configPath);
            var node = xe.Descendants("databaseConn").Where(xn => xn.Value.Contains("server")).Select(xn => xn.Value);
            return node.FirstOrDefault<string>();
        }
        #endregion
    }
}
