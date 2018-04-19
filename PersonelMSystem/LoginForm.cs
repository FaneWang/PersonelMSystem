using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelMSystem
{
    public partial class LoginForm : Form
    {
        DataClass.DatabaseUtils dataUtils = new DataClass.DatabaseUtils();

        public LoginForm()
        {
            InitializeComponent();
        }

        #region private func（events）
        // 窗体加载的时候焦点移动到用户名输入框上
        private void loginFormActived(Object obj,EventArgs eventArgs)
        {
            textBox1.Focus();
        }
        // 窗体加载的时候试开数据库
        private void loginFormLoad(Object obj,EventArgs eventArgs)
        {
            SqlConnection conn = DataClass.DatabaseUtils.getSqlConnection();
            dataUtils.open(conn);
            dataUtils.close(conn);
            // 加载时清空输入框
            textBox1.Text = "";
            textBox2.Text = "";

        }

        // 登录逻辑
        private void loginButtonClick(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = "select * from tb_login where name = @name and password = @password";
                SqlConnection conn = DataClass.DatabaseUtils.getSqlConnection();
                dataUtils.open(conn);
                SqlCommand comm = dataUtils.getSqlCommand(sql, conn);
                comm.CommandText = sql;
                comm.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                comm.Parameters.AddWithValue("@password", textBox2.Text.Trim());
                SqlDataReader reader = dataUtils.getDataReader(comm);
                if(reader == null)
                {
                    MessageBox.Show("擦，程序初始化失败了，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                if (reader.Read())
                {
                    DataClass.DatabaseUtils.loginId = reader.GetString(0);
                    DataClass.DatabaseUtils.loginName = textBox1.Text.Trim();

                    //DataClass.DatabaseUtils.loginFlag = (int)(this.Tag);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                reader.Close();
                dataUtils.close(conn);
            }
            else
            {
                MessageBox.Show("请将信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 取消登录逻辑
        private void cancelButtonClick(object sender, EventArgs e)
        {
            //if((int)(this.Tag) == 1)
            //{
            //    DataClass.DatabaseUtils.loginFlag = 3;
            //    Application.Exit();
            //}
            //else
            //{
            //    if((int)(this.Tag) == 2)
            //    {
            //        this.Close();
            //    }
            //}
            this.Close();
        }
        #endregion

        
    }
}
