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

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("要返回登录界面吗", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Login f1 = new Login();//创建一个新的Form1对象
                f1.Show();//显示Form1窗口
                this.Hide();//隐藏当前窗口
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Review f3 = new Review();//创建一个新的Form3对象
            f3.Show();//显示Form3窗口
            this.Hide();//隐藏当前窗口
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemorizerSelection memorizerSelection = new MemorizerSelection();
            memorizerSelection.Show();
            this.Hide();
            throw new System.NotImplementedException();
        }
    }
}
