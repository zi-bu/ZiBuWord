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
            colRemove = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFavorites).BeginInit();
            SuspendLayout();
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
            button4.Click += button4_Click;
            // 
            // dataGridViewFavorites
            // 
            dataGridViewFavorites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFavorites.Columns.AddRange(new DataGridViewColumn[] { colRemove });
            dataGridViewFavorites.Location = new Point(6, 67);
            dataGridViewFavorites.Name = "dataGridViewFavorites";
            dataGridViewFavorites.RowHeadersWidth = 62;
            dataGridViewFavorites.Size = new Size(360, 225);
            dataGridViewFavorites.TabIndex = 10;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "移除";
            colRemove.MinimumWidth = 8;
            colRemove.Name = "colRemove";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 150;
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
        private DataGridViewButtonColumn colRemove;
    }
}