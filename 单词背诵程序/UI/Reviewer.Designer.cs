using System.ComponentModel;

namespace UI;

partial class Reviewer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        Question = new Label();
        btnYes = new Button();
        btnNo = new Button();
        SuspendLayout();
        // 
        // Question
        // 
        Question.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Question.Location = new Point(235, 100);
        Question.Name = "Question";
        Question.Size = new Size(320, 80);
        Question.TabIndex = 1;
        Question.Text = "label1";
        Question.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnYes
        // 
        btnYes.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnYes.Location = new Point(89, 244);
        btnYes.Name = "btnYes";
        btnYes.Size = new Size(240, 120);
        btnYes.TabIndex = 2;
        btnYes.Text = "认识";
        btnYes.UseVisualStyleBackColor = true;
        // 
        // btnNo
        // 
        btnNo.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 134);
        btnNo.Location = new Point(464, 244);
        btnNo.Name = "btnNo";
        btnNo.Size = new Size(240, 120);
        btnNo.TabIndex = 3;
        btnNo.Text = "不认识";
        btnNo.UseVisualStyleBackColor = true;
        // 
        // Reviewer
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(800, 450);
        Controls.Add(btnNo);
        Controls.Add(btnYes);
        Controls.Add(Question);
        Location = new Point(22, 22);
        Name = "Reviewer";
        Text = "Reviewer";
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox textBox1;

    #endregion

    private Label Question;
    private Button btnYes;
    private Button btnNo;
}