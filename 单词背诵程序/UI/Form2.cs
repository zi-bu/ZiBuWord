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
    public partial class Form2 : Form
    {
        public Form2()
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
    }
}
