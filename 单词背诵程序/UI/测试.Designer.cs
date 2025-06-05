namespace UI
{
    partial class 测试
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            SuspendLayout();
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(0, 0);
            webView2.Margin = new Padding(5, 4, 5, 4);
            webView2.Name = "webView2";
            webView2.Size = new Size(940, 1144);
            webView2.Source = new Uri(" http://localhost:5173/", UriKind.Absolute);
            webView2.TabIndex = 0;
            webView2.ZoomFactor = 1D;
            webView2.Click += webView2_Click;
            // 
            // 测试
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 1144);
            Controls.Add(webView2);
            Margin = new Padding(5, 4, 5, 4);
            MaximumSize = new Size(962, 1200);
            MinimumSize = new Size(962, 1200);
            Name = "测试";
            Text = "测试";
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
    }
}