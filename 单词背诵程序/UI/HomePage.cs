using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Services;

namespace UI
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing; // 绑定 FormClosing 事件
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            // 性能优化设置
            PerformanceService.OptimizeFormPerformance(this);

            // 异步加载数据
            await PerformanceService.LoadFormAsync(this, () =>
            {
                // 在这里添加需要异步加载的初始化代码
                // 例如：加载用户数据、配置等
            });
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
            if (MessageService.ShowExitConfirmation())
            {
                PerformanceService.CleanupFormResources(this);
                Application.Exit();
            }
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
            if (!MessageService.ShowExitConfirmation())
            {
                e.Cancel = true; // 取消关闭事件
            }
            else
            {
                PerformanceService.CleanupFormResources(this);
                System.Environment.Exit(0); // 退出程序
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageService.ShowNavigateBackConfirmation())
            {
                PerformanceService.CleanupFormResources(this);
                Login loginForm = new Login();
                NavigationService.NavigateTo(this, loginForm);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PerformanceService.CleanupFormResources(this);
            Review reviewForm = new Review();
            NavigationService.NavigateTo(this, reviewForm);
        }
    }
}
