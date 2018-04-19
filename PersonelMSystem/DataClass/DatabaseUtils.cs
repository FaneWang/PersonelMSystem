using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Windows.Forms;
using PersonelMSystem.Utils;

namespace PersonelMSystem.DataClass
{
    class DatabaseUtils
    {
        //获取数据库连接字符串
        public static string connStr;
        // 数据库连接可以采用单例模式
        private static SqlConnection sqlConnection;
        //因为用户名密码在真个程序运行期间共享，定义全局变量保存
        public static string loginId = "";
        public static string loginName = "";
        // 控制登录与重新登录，0表示初始化/1表示第一次登录/2表示重新登录/3表示其他状态（已登录或取消登录等）
        public static int loginFlag = 0;

        public DatabaseUtils()
        {
            connStr = getConnStr();
            try
            {
                sqlConnection = new SqlConnection(connStr);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("数据库连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogUtils.log2txt(e.StackTrace);
                Application.Exit();
            }
        }

        #region 获取数据库连接
        public static SqlConnection getSqlConnection()
        {
            return sqlConnection;
        }
        #endregion

        #region 打开数据库连接
        public void open(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogUtils.log2txt(e.StackTrace);
                Application.Exit();
            }
        }
        #endregion

        #region 关闭数据库连接
        public void close(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogUtils.log2txt(e.StackTrace);
                Application.Exit();
            }
        }
        #endregion

        #region 获取SQLCommand
        public SqlCommand getSqlCommand(string sqlStr,SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(sqlStr, connection);
            return sqlCommand;
        }
        #endregion

        #region 获取dataReader
        public SqlDataReader getDataReader(SqlCommand sqlCommand)
        {
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                LogUtils.log2txt(e.StackTrace);
                return null;
            }
        }
        #endregion

        #region 获取配置文件中的数据库连接字符串
        private string getConnStr()
        {
            try
            {
                string configPath = System.Windows.Forms.Application.StartupPath + "\\Config\\database.xml";
                XElement xe = XElement.Load(configPath);
                var node = xe.Descendants("databaseConn").Where(xn => xn.Value.Contains("server")).Select(xn => xn.Value);
                MessageBox.Show(node.FirstOrDefault<string>());
                return node.FirstOrDefault<string>();
            }
            catch (Exception e)
            {
                LogUtils.log2txt(e.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
