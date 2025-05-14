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
        Question = new System.Windows.Forms.Label();
        ButtonYes = new System.Windows.Forms.Button();
        ButtonNo = new System.Windows.Forms.Button();
        Context = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // Question
        // 
        Question.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        Question.Location = new System.Drawing.Point(334, 97);
        Question.Name = "Question";
        Question.Size = new System.Drawing.Size(115, 80);
        Question.TabIndex = 1;
        Question.Text = "label1";
        Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ButtonYes
        // 
        ButtonYes.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        ButtonYes.Location = new System.Drawing.Point(99, 906);
        ButtonYes.Name = "ButtonYes";
        ButtonYes.Size = new System.Drawing.Size(240, 120);
        ButtonYes.TabIndex = 2;
        ButtonYes.Text = "认识";
        ButtonYes.UseVisualStyleBackColor = true;
        ButtonYes.Click += ButtonYes_Click;
        // 
        // ButtonNo
        // 
        ButtonNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        ButtonNo.Location = new System.Drawing.Point(447, 906);
        ButtonNo.Name = "ButtonNo";
        ButtonNo.Size = new System.Drawing.Size(240, 120);
        ButtonNo.TabIndex = 3;
        ButtonNo.Text = "不认识";
        ButtonNo.UseVisualStyleBackColor = true;
        ButtonNo.Click += ButtonNo_Click;
        // 
        // Context
        // 
        Context.Location = new System.Drawing.Point(99, 232);
        Context.Multiline = true;
        Context.Name = "Context";
        Context.Size = new System.Drawing.Size(588, 625);
        Context.TabIndex = 4;
        // 
        // Reviewer
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 1164);
        Controls.Add(Context);
        Controls.Add(ButtonNo);
        Controls.Add(ButtonYes);
        Controls.Add(Question);
        Location = new System.Drawing.Point(22, 22);
        Text = "Reviewer";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox Context;

    #endregion

    private System.Windows.Forms.Label Question;
    private System.Windows.Forms.Button ButtonYes;
    private System.Windows.Forms.Button ButtonNo;
}