using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();//创建一个新的主页窗口对象
            homepage.Show();//显示主页窗口
            this.Hide();//隐藏当前窗口
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
