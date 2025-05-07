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
            this.FormClosing += Form2_FormClosing; // 绑定 FormClosing 事件
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
            Form2_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        /// <summary>
        /// 这是关闭窗口的事件处理函数。
        /// </br>这段代码是由```子布```编写的。
        /// （可能会被改写成一个函数，或者直接删除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要退出吗？未保存的进度将会丢失！", "警告！", MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true; // 取消关闭事件
            }
            else
            {
                System.Environment.Exit(0); // 退出程序
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("要返回登录界面吗", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Login login = new Login();//创建一个新的登录窗口对象
                login.StartPosition = FormStartPosition.Manual;//固定窗口位置
                login.Location = this.Location;//对齐窗口位置
                login.Show();//显示登录窗口
                this.Hide();//隐藏当前窗口
            }
        }

        private void btnStartReview_Click(object sender, EventArgs e)
        {
            Review review = new Review();//创建一个新的复习窗口对象
            review.StartPosition = FormStartPosition.Manual;
            review.Location = this.Location;
            review.Show();//显示复习窗口
            this.Hide();//隐藏当前窗口
        }

        private void btnStartMemory_Click(object sender, EventArgs e)
        {
            MemorizerSelection memorizerSelection = new MemorizerSelection();
            memorizerSelection.StartPosition = FormStartPosition.Manual;
            memorizerSelection.Location = this.Location;
            memorizerSelection.Show();//显示背诵选择窗口
            this.Hide();
            throw new System.NotImplementedException();
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            Favorite favorite = new Favorite();
            favorite.StartPosition = FormStartPosition.Manual;
            favorite.Location = this.Location;
            favorite.Show();//显示收藏夹窗口
            this.Hide();
        }
    }
}
