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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            
        }

        private void formLoad(object sender, EventArgs e)
        {
            MessageBox.Show("哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Brush br = new SolidBrush(Color.Red);
            Rectangle rc = new Rectangle(10,10,615,100);
            graphics.FillRectangle(br, rc);

            Pen pen = new Pen(Color.Black, 1);
            Point point1 = new Point(10, 10);
            Point point2 = new Point(615, 100);
            graphics.DrawLine(pen, point1, point2);

            this.button1.Hide();
        }
    }
}
