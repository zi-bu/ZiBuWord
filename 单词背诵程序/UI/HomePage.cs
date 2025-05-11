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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.FormClosing += FormHelper.Form2_FormClosing; // 绑定 FormClosing 事件
        }

        /// <summary>
        /// 这是退出登录按钮的点击事件处理函数。
        /// </br>这段代码是由```子布```编写的。
        /// (可能会被改写成一个函数，或者直接删除)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            FormHelper.Form2_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("要返回登录界面吗", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Login login = new Login();
                FormHelper.ShowNewForm(this, login);
            }
        }

        private void btnStartReview_Click(object sender, EventArgs e)
        {
            Review review = new Review();
            FormHelper.ShowNewForm(this, review);
        }

        private void btnStartMemory_Click(object sender, EventArgs e)
        {
            MemorizerSelection memorizerSelection = new MemorizerSelection();
            FormHelper.ShowNewForm(this, memorizerSelection);
            throw new System.NotImplementedException();
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            Favorite favorite = new Favorite();
            FormHelper.ShowNewForm(this, favorite);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
