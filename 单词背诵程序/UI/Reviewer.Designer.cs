using System.ComponentModel;
using MaterialSkin.Controls;

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
        ButtonYes = new MaterialButton();
        ButtonNo = new MaterialButton();
        Context = new TextBox();
        SuspendLayout();
        // 
        // Question
        // 
        Question.BackColor = Color.Transparent;
        Question.Font = new Font("Microsoft YaHei UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Question.Location = new Point(205, 141);
        Question.Margin = new Padding(2, 0, 2, 0);
        Question.Name = "Question";
        Question.Size = new Size(218, 73);
        Question.TabIndex = 1;
        Question.Text = "label1";
        Question.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ButtonYes
        // 
        ButtonYes.AccentTextColor = Color.FromArgb(255, 64, 129);
        ButtonYes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ButtonYes.CharacterCasing = MaterialButton.CharacterCasingEnum.Normal;
        ButtonYes.Density = MaterialButton.MaterialButtonDensity.Default;
        ButtonYes.Depth = 0;
        ButtonYes.FlatStyle = FlatStyle.System;
        ButtonYes.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 134);
        ButtonYes.HighEmphasis = true;
        ButtonYes.Icon = null;
        ButtonYes.Location = new Point(81, 775);
        ButtonYes.Margin = new Padding(3, 5, 3, 5);
        ButtonYes.MaximumSize = new Size(205, 83);
        ButtonYes.MinimumSize = new Size(205, 83);
        ButtonYes.MouseState = MaterialSkin.MouseState.HOVER;
        ButtonYes.Name = "ButtonYes";
        ButtonYes.NoAccentTextColor = Color.Empty;
        ButtonYes.Size = new Size(205, 83);
        ButtonYes.TabIndex = 2;
        ButtonYes.Text = "认识";
        ButtonYes.Type = MaterialButton.MaterialButtonType.Contained;
        ButtonYes.UseAccentColor = false;
        ButtonYes.UseVisualStyleBackColor = true;
        ButtonYes.Click += ButtonYes_Click;
        // 
        // ButtonNo
        // 
        ButtonNo.AccentTextColor = Color.FromArgb(255, 64, 129);
        ButtonNo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ButtonNo.CharacterCasing = MaterialButton.CharacterCasingEnum.Normal;
        ButtonNo.Density = MaterialButton.MaterialButtonDensity.Default;
        ButtonNo.Depth = 0;
        ButtonNo.FlatStyle = FlatStyle.System;
        ButtonNo.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 134);
        ButtonNo.HighEmphasis = true;
        ButtonNo.Icon = null;
        ButtonNo.Location = new Point(358, 775);
        ButtonNo.Margin = new Padding(3, 5, 3, 5);
        ButtonNo.MinimumSize = new Size(205, 83);
        ButtonNo.MouseState = MaterialSkin.MouseState.HOVER;
        ButtonNo.Name = "ButtonNo";
        ButtonNo.NoAccentTextColor = Color.Empty;
        ButtonNo.Size = new Size(205, 83);
        ButtonNo.TabIndex = 3;
        ButtonNo.Text = "不认识";
        ButtonNo.Type = MaterialButton.MaterialButtonType.Contained;
        ButtonNo.UseAccentColor = false;
        ButtonNo.UseVisualStyleBackColor = true;
        ButtonNo.Click += ButtonNo_Click;
        // 
        // Context
        // 
        Context.BackColor = Color.White;
        Context.BorderStyle = BorderStyle.None;
        Context.Font = new Font("Microsoft YaHei UI", 15F);
        Context.Location = new Point(81, 251);
        Context.Margin = new Padding(2, 2, 2, 2);
        Context.Multiline = true;
        Context.Name = "Context";
        Context.Size = new Size(481, 465);
        Context.TabIndex = 4;
        Context.TextChanged += Context_TextChanged;
        // 
        // Reviewer
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(655, 918);
        Controls.Add(Context);
        Controls.Add(ButtonNo);
        Controls.Add(ButtonYes);
        Controls.Add(Question);
        FormStyle = FormStyles.ActionBar_64;
        Location = new Point(22, 22);
        Margin = new Padding(2, 2, 2, 2);
        Name = "Reviewer";
        Padding = new Padding(2, 73, 2, 2);
        Text = "Reviewer";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox Context;

    #endregion

    private System.Windows.Forms.Label Question;
    private MaterialSkin.Controls.MaterialButton ButtonYes;
    private MaterialSkin.Controls.MaterialButton ButtonNo;
    
}