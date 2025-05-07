using System;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// 窗体辅助类，提供窗体操作的通用方法
    /// mingfeng
    /// </summary>
    public static class FormHelper
    {
        /// <summary>
        /// 显示新窗口并隐藏当前窗口
        /// </summary>
        /// <param name="currentForm">当前窗口</param>
        /// <param name="newForm">要显示的新窗口</param>
        public static void ShowNewForm(Form currentForm, Form newForm)
        {
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = currentForm.Location;
            newForm.Show();
            currentForm.Hide();
        }
    }
} 