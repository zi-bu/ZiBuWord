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
            button4 = new Button();
            dataGridViewFavorites = new DataGridView();
            colWord = new DataGridViewTextBoxColumn();
            colTranslation = new DataGridViewTextBoxColumn();
            colDict = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFavorites).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(786, 25);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(61, 35);
            button4.TabIndex = 9;
            button4.Text = "首页";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridViewFavorites
            // 
            dataGridViewFavorites.AllowUserToResizeColumns = false;
            dataGridViewFavorites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFavorites.Columns.AddRange(new DataGridViewColumn[] { colWord, colTranslation, colDict, colRemove });
            dataGridViewFavorites.Location = new Point(6, 67);
            dataGridViewFavorites.Name = "dataGridViewFavorites";
            dataGridViewFavorites.ReadOnly = true;
            dataGridViewFavorites.RowHeadersVisible = false;
            dataGridViewFavorites.RowHeadersWidth = 62;
            dataGridViewFavorites.Size = new Size(841, 736);
            dataGridViewFavorites.TabIndex = 10;
            // 
            // colWord
            // 
            colWord.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colWord.DataPropertyName = "Word";
            colWord.HeaderText = "单词";
            colWord.MinimumWidth = 8;
            colWord.Name = "colWord";
            colWord.ReadOnly = true;
            colWord.Width = 82;
            // 
            // colTranslation
            // 
            colTranslation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTranslation.DataPropertyName = "Translation";
            colTranslation.HeaderText = "释义";
            colTranslation.MinimumWidth = 8;
            colTranslation.Name = "colTranslation";
            colTranslation.ReadOnly = true;
            // 
            // colDict
            // 
            colDict.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDict.DataPropertyName = "DictionaryType";
            colDict.HeaderText = "词典类型";
            colDict.MinimumWidth = 8;
            colDict.Name = "colDict";
            colDict.ReadOnly = true;
            colDict.Width = 118;
            // 
            // colRemove
            // 
            colRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colRemove.HeaderText = "移除";
            colRemove.MinimumWidth = 8;
            colRemove.Name = "colRemove";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 52;
            // 
            // Favorite
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(860, 809);
            Controls.Add(dataGridViewFavorites);
            Controls.Add(button4);
            Name = "Favorite";
            Text = "Favorite";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFavorites).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button4;
        private DataGridView dataGridViewFavorites;
        private DataGridViewTextBoxColumn colWord;
        private DataGridViewTextBoxColumn colTranslation;
        private DataGridViewTextBoxColumn colDict;
        private DataGridViewButtonColumn colRemove;
    }
}