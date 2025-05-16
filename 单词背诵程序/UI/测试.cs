using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.IO;

namespace UI
{
    public partial class 测试 : Form
    {
        public 测试()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            // 确保 WebView2 环境已初始化
            await webView21.EnsureCoreWebView2Async(null);
            
            // 设置允许访问本地文件
            webView21.CoreWebView2.Settings.AreHostObjectsAllowed = true;
            webView21.CoreWebView2.Settings.IsWebMessageEnabled = true;
            
            // 获取应用程序根目录
            string appPath = Application.StartupPath;
            
            // 组合 build 文件夹的完整路径（使用 Path.Combine 确保跨平台兼容）
            string buildPath = Path.Combine(appPath, "build");
            
            // 如果 build 目录不在应用根目录，而是在项目中的其他位置，请调整路径
            if (!Directory.Exists(buildPath))
            {
                // 尝试向上级目录查找
                buildPath = Path.Combine(Directory.GetParent(appPath).FullName, "build");
                // 如果有特定位置，可以直接指定
                // buildPath = @"D:\项目路径\小组项目\小组项目（单词背诵程序）\单词背诵程序\build";
            }
            
            // 确保目录存在
            if (Directory.Exists(buildPath))
            {
                // 找到 index.html 或你的主 HTML 文件
                string htmlFile = Path.Combine(buildPath, "index.html");
                
                if (File.Exists(htmlFile))
                {
                    // 使用 file:// 协议加载本地文件
                    webView21.Source = new Uri($"file:///{htmlFile.Replace("\\", "/")}");
                }
                else
                {
                    MessageBox.Show($"HTML 文件未找到: {htmlFile}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"build 目录未找到: {buildPath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
