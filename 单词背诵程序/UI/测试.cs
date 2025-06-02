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
            FormClosing += FormHelper.CloseForm; // 绑定关闭事件
        }
    }
}
