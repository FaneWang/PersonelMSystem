using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PersonelMSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainFormLoad(object sender, EventArgs e)
        {
            
        }

        private void buttonClick(object sender, EventArgs e)
        {
            int i = 0;
            while (i < 10)
            {
                Form4 form4 = new Form4();
                form4.MdiParent = this;
                form4.Show();
                Thread.Sleep(100);
                Form3 form3 = new Form3();
                form3.MdiParent = this;
                form3.Show();
                Thread.Sleep(100);
                Form2 form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
                Thread.Sleep(100);
                Form1 form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
                i++;
            }

            this.button1.Hide();
            Form5 form5 = new Form5();
            form5.MdiParent = this;
            form5.Show();

            
            
        }

    }
}
