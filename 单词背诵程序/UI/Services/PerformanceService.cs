using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace UI.Services
{
    /// <summary>
    /// 性能优化服务类
    /// </summary>
    public static class PerformanceService
    {
        /// <summary>
        /// 优化窗体性能设置
        /// </summary>
        public static void OptimizeFormPerformance(Form form)
        {
            // 双缓冲绘制，减少闪烁
            form.DoubleBuffered = true;
            
            // 设置窗体样式，优化重绘性能
            typeof(Form).GetProperty("DoubleBuffered", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance)
                ?.SetValue(form, true, null);

            // 优化所有控件的双缓冲
            foreach (Control control in form.Controls)
            {
                OptimizeControlPerformance(control);
            }
        }

        /// <summary>
        /// 优化控件性能设置
        /// </summary>
        private static void OptimizeControlPerformance(Control control)
        {
            if (control is Panel || control is UserControl)
            {
                typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                    ?.SetValue(control, true, null);
            }

            // 递归优化子控件
            foreach (Control child in control.Controls)
            {
                OptimizeControlPerformance(child);
            }
        }

        /// <summary>
        /// 异步加载窗体
        /// </summary>
        public static async Task LoadFormAsync(Form form, Action loadAction)
        {
            try
            {
                await Task.Run(() =>
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.UseWaitCursor = true;
                        loadAction?.Invoke();
                    });
                });
            }
            finally
            {
                form.UseWaitCursor = false;
            }
        }

        /// <summary>
        /// 释放窗体资源
        /// </summary>
        public static void CleanupFormResources(Form form)
        {
            // 停止所有计时器
            foreach (Control control in form.Controls)
            {
                if (control is Timer timer)
                {
                    timer.Stop();
                }
            }

            // 释放图片资源
            foreach (Control control in form.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.Image?.Dispose();
                }
            }

            // 取消所有事件订阅
            form.Disposed += (s, e) =>
            {
                foreach (Control control in form.Controls)
                {
                    control.Dispose();
                }
            };
        }
    }
} 