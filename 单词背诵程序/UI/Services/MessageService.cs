using System.Windows.Forms;

namespace UI.Services
{
    /// <summary>
    /// 消息服务类，用于统一管理提示信息
    /// </summary>
    public static class MessageService
    {
        /// <summary>
        /// 显示确认对话框
        /// </summary>
        public static bool ShowConfirmation(string message, string title = "确认")
        {
            return MessageBox.Show(message, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// 显示警告对话框
        /// </summary>
        public static bool ShowWarning(string message, string title = "警告")
        {
            return MessageBox.Show(message, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        /// <summary>
        /// 显示错误对话框
        /// </summary>
        public static void ShowError(string message, string title = "错误")
        {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示信息对话框
        /// </summary>
        public static void ShowInfo(string message, string title = "提示")
        {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示退出确认对话框
        /// </summary>
        public static bool ShowExitConfirmation()
        {
            return ShowWarning("确定要退出吗？未保存的进度将会丢失！");
        }

        /// <summary>
        /// 显示返回确认对话框
        /// </summary>
        public static bool ShowNavigateBackConfirmation()
        {
            return ShowConfirmation("确定要返回上一页吗？");
        }

        /// <summary>
        /// 显示游客登录确认对话框
        /// </summary>
        public static bool ShowVisitorLoginConfirmation()
        {
            return ShowWarning("确定要以游客身份登录吗？您的数据将不会被保存！");
        }
    }
} 