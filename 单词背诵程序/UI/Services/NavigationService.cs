using System;
using System.Windows.Forms;

namespace UI.Services
{
    /// <summary>
    /// 导航服务类，用于统一管理界面跳转
    /// </summary>
    public static class NavigationService
    {
        /// <summary>
        /// 导航到新窗体
        /// </summary>
        /// <param name="currentForm">当前窗体</param>
        /// <param name="newForm">目标窗体</param>
        /// <param name="hideCurrent">是否隐藏当前窗体</param>
        public static void NavigateTo(Form currentForm, Form newForm, bool hideCurrent = true)
        {
            if (hideCurrent)
            {
                currentForm.Hide();
            }
            newForm.Show();
        }

        /// <summary>
        /// 返回上一级窗体
        /// </summary>
        /// <param name="currentForm">当前窗体</param>
        /// <param name="previousForm">上一级窗体</param>
        public static void NavigateBack(Form currentForm, Form previousForm)
        {
            currentForm.Hide();
            previousForm.Show();
        }

        /// <summary>
        /// 关闭当前窗体并退出应用
        /// </summary>
        /// <param name="currentForm">当前窗体</param>
        public static void ExitApplication(Form currentForm)
        {
            if (MessageBox.Show("真的要退出吗？未保存的进度将会丢失！", "警告！", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                currentForm.Close();
                Application.Exit();
            }
        }
    }
} 