using System.ComponentModel;
using BLL;
using DAL;
using static BLL.ListClass;

namespace UI;

partial class MemorizerSelection
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
        label1 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button5 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(49, 31);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(194, 46);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(36, 98);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(346, 70);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(38, 211);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(343, 59);
        button2.TabIndex = 2;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(411, 101);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(238, 66);
        button3.TabIndex = 3;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(413, 202);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(235, 67);
        button4.TabIndex = 4;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        button5.Location = new System.Drawing.Point(51, 317);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(221, 73);
        button5.TabIndex = 5;
        button5.Text = "启用测试";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // MemorizerSelection
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Text = "Memorizer";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button5;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Label label1;

    #endregion
}