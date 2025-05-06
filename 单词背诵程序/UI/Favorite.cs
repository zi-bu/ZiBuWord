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
    public partial class Favorite : Form
    {
        public Favorite()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.StartPosition = FormStartPosition.Manual;//固定窗口位置
            homePage.Location = this.Location;//对齐窗口位置
            homePage.Show();//显示主页面
            this.Hide();
        }
    }
}
