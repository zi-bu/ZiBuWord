using System.ComponentModel;
using BLL;
using DAL;


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
        label1 = new Label();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        button5 = new Button();
        btnReturn = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
        label1.Location = new Point(60, 37);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(240, 60);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // button1
        // 
        button1.Location = new Point(44, 142);
        button1.Margin = new Padding(4);
        button1.Name = "button1";
        button1.Size = new Size(320, 80);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // button2
        // 
        button2.Location = new Point(44, 260);
        button2.Margin = new Padding(4);
        button2.Name = "button2";
        button2.Size = new Size(320, 80);
        button2.TabIndex = 2;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new Point(436, 142);
        button3.Margin = new Padding(4);
        button3.Name = "button3";
        button3.Size = new Size(320, 80);
        button3.TabIndex = 3;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new Point(436, 260);
        button4.Margin = new Padding(4);
        button4.Name = "button4";
        button4.Size = new Size(320, 80);
        button4.TabIndex = 4;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        button5.Location = new Point(44, 402);
        button5.Margin = new Padding(4);
        button5.Name = "button5";
        button5.Size = new Size(270, 88);
        button5.TabIndex = 5;
        button5.Text = "启用测试";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // btnReturn
        // 
        btnReturn.Location = new Point(860, 13);
        btnReturn.Margin = new Padding(4);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(61, 35);
        btnReturn.TabIndex = 9;
        btnReturn.Text = "首页";
        btnReturn.UseVisualStyleBackColor = true;
        btnReturn.Click += btnReturn_Click;
        // 
        // MemorizerSelection
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(934, 540);
        Controls.Add(btnReturn);
        Controls.Add(button5);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Margin = new Padding(4);
        Name = "MemorizerSelection";
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

    private Button btnReturn;
}