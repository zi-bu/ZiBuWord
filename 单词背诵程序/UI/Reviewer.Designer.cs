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
        Question = new System.Windows.Forms.Label();
        ButtonYes = new MaterialSkin.Controls.MaterialButton();
        ButtonNo = new MaterialSkin.Controls.MaterialButton();
        Context = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // Question
        // 
        Question.BackColor = System.Drawing.Color.Transparent;
        Question.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        Question.Location = new System.Drawing.Point(251, 169);
        Question.Name = "Question";
        Question.Size = new System.Drawing.Size(266, 88);
        Question.TabIndex = 1;
        Question.Text = "label1";
        Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ButtonYes
        // 
        ButtonYes.AccentTextColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)64)), ((int)((byte)129)));
        ButtonYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        ButtonYes.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
        ButtonYes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        ButtonYes.Depth = 0;
        ButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
        ButtonYes.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        ButtonYes.HighEmphasis = true;
        ButtonYes.Icon = null;
        ButtonYes.Location = new System.Drawing.Point(99, 930);
        ButtonYes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
        ButtonYes.MaximumSize = new System.Drawing.Size(250, 100);
        ButtonYes.MinimumSize = new System.Drawing.Size(250, 100);
        ButtonYes.MouseState = MaterialSkin.MouseState.HOVER;
        ButtonYes.Name = "ButtonYes";
        ButtonYes.NoAccentTextColor = System.Drawing.Color.Empty;
        ButtonYes.Size = new System.Drawing.Size(250, 100);
        ButtonYes.TabIndex = 2;
        ButtonYes.Text = "认识";
        ButtonYes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        ButtonYes.UseAccentColor = false;
        ButtonYes.UseVisualStyleBackColor = true;
        ButtonYes.Click += ButtonYes_Click;
        // 
        // ButtonNo
        // 
        ButtonNo.AccentTextColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)64)), ((int)((byte)129)));
        ButtonNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        ButtonNo.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
        ButtonNo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        ButtonNo.Depth = 0;
        ButtonNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
        ButtonNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)134));
        ButtonNo.HighEmphasis = true;
        ButtonNo.Icon = null;
        ButtonNo.Location = new System.Drawing.Point(437, 930);
        ButtonNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
        ButtonNo.MinimumSize = new System.Drawing.Size(250, 100);
        ButtonNo.MouseState = MaterialSkin.MouseState.HOVER;
        ButtonNo.Name = "ButtonNo";
        ButtonNo.NoAccentTextColor = System.Drawing.Color.Empty;
        ButtonNo.Size = new System.Drawing.Size(250, 100);
        ButtonNo.TabIndex = 3;
        ButtonNo.Text = "不认识";
        ButtonNo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        ButtonNo.UseAccentColor = false;
        ButtonNo.UseVisualStyleBackColor = true;
        ButtonNo.Click += ButtonNo_Click;
        // 
        // Context
        // 
        Context.BackColor = System.Drawing.Color.White;
        Context.BorderStyle = System.Windows.Forms.BorderStyle.None;
        Context.Cursor = System.Windows.Forms.Cursors.Arrow;
        Context.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
        Context.Location = new System.Drawing.Point(99, 301);
        Context.Multiline = true;
        Context.Name = "Context";
        Context.Size = new System.Drawing.Size(588, 558);
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
        FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_64;
        Location = new System.Drawing.Point(22, 22);
        Padding = new System.Windows.Forms.Padding(3, 88, 3, 3);
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