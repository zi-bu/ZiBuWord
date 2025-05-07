namespace UI
{
    partial class Review
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
            btnYes = new Button();
            btnNo = new Button();
            textTranslation = new TextBox();
            panel1 = new Panel();
            btnReturn = new Button();
            labelDict = new Label();
            textExample = new TextBox();
            labelWord = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Location = new Point(123, 290);
            btnYes.Margin = new Padding(4);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(115, 49);
            btnYes.TabIndex = 0;
            btnYes.Text = "认识";
            btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(437, 290);
            btnNo.Margin = new Padding(4);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(115, 49);
            btnNo.TabIndex = 2;
            btnNo.Text = "不认识";
            btnNo.UseVisualStyleBackColor = true;
            // 
            // textTranslation
            // 
            textTranslation.Location = new Point(123, 125);
            textTranslation.Margin = new Padding(4);
            textTranslation.Multiline = true;
            textTranslation.Name = "textTranslation";
            textTranslation.Size = new Size(429, 40);
            textTranslation.TabIndex = 3;
            textTranslation.Text = "词义";
            textTranslation.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(labelDict);
            panel1.Controls.Add(textExample);
            panel1.Controls.Add(labelWord);
            panel1.Controls.Add(textTranslation);
            panel1.Controls.Add(btnNo);
            panel1.Controls.Add(btnYes);
            panel1.Location = new Point(136, 55);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(673, 410);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(581, 34);
            btnReturn.Margin = new Padding(4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(61, 35);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "首页";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // labelDict
            // 
            labelDict.AutoSize = true;
            labelDict.Location = new Point(67, 44);
            labelDict.Margin = new Padding(4, 0, 4, 0);
            labelDict.Name = "labelDict";
            labelDict.Size = new Size(46, 24);
            labelDict.TabIndex = 7;
            labelDict.Text = "词库";
            labelDict.Click += label2_Click;
            // 
            // textExample
            // 
            textExample.Location = new Point(123, 187);
            textExample.Margin = new Padding(4);
            textExample.Multiline = true;
            textExample.Name = "textExample";
            textExample.Size = new Size(429, 62);
            textExample.TabIndex = 5;
            textExample.Text = "例句";
            // 
            // labelWord
            // 
            labelWord.AutoSize = true;
            labelWord.Location = new Point(309, 74);
            labelWord.Margin = new Padding(4, 0, 4, 0);
            labelWord.Name = "labelWord";
            labelWord.Size = new Size(46, 24);
            labelWord.TabIndex = 4;
            labelWord.Text = "单词";
            labelWord.Click += label1_Click;
            // 
            // Review
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 540);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "Review";
            Text = "复习";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnYes;
        private Button btnNo;
        private TextBox textTranslation;
        private Panel panel1;
        private Label labelWord;
        private Button btnReturn;
        private Label labelDict;
        private TextBox textExample;
    }
}