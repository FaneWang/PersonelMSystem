using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelMSystem
{
    public partial class LoginForm : Form
    {
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
        // 窗体加载的时候连接数据库，因为登录需要验证
        private void loginFormLoad(Object obj,EventArgs eventArgs)
        {

        }
        #endregion
    }
}
