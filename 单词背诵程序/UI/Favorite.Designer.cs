namespace UI
{
    partial class Favorite
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
            dataGridView1 = new DataGridView();
            单词原文 = new DataGridViewTextBoxColumn();
            单词释义 = new DataGridViewTextBoxColumn();
            取消收藏 = new DataGridViewButtonColumn();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 单词原文, 单词释义, 取消收藏 });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(767, 744);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // 单词原文
            // 
            单词原文.HeaderText = "单词原文";
            单词原文.MinimumWidth = 8;
            单词原文.Name = "单词原文";
            单词原文.ReadOnly = true;
            单词原文.Width = 150;
            // 
            // 单词释义
            // 
            单词释义.HeaderText = "单词释义";
            单词释义.MinimumWidth = 8;
            单词释义.Name = "单词释义";
            单词释义.ReadOnly = true;
            单词释义.Width = 300;
            // 
            // 取消收藏
            // 
            取消收藏.HeaderText = "操作";
            取消收藏.MinimumWidth = 8;
            取消收藏.Name = "取消收藏";
            取消收藏.Text = "";
            取消收藏.Width = 150;
            // 
            // button4
            // 
            button4.Location = new Point(786, 13);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(61, 35);
            button4.TabIndex = 9;
            button4.Text = "首页";
            button4.UseVisualStyleBackColor = true;
            // 
            // Favorite
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 809);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Name = "Favorite";
            Text = "Favorite";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn 单词原文;
        private DataGridViewTextBoxColumn 单词释义;
        private DataGridViewButtonColumn 取消收藏;
        private Button button4;
    }
}