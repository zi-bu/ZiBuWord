using System.ComponentModel;

namespace UI;

partial class UiSelectionOrder
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
        Choice1 = new Button();
        Choice2 = new Button();
        Choice3 = new Button();
        Choice4 = new Button();
        SuspendLayout();
        // 
        // Question
        // 
        Question.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Question.Location = new Point(237, 47);
        Question.Name = "Question";
        Question.Size = new Size(320, 80);
        Question.TabIndex = 0;
        Question.Text = "label1";
        Question.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Choice1
        // 
        Choice1.Location = new Point(63, 165);
        Choice1.Name = "Choice1";
        Choice1.Size = new Size(300, 100);
        Choice1.TabIndex = 1;
        Choice1.Text = "button1";
        Choice1.UseVisualStyleBackColor = true;
        Choice1.Click += Choice1_Click;
        // 
        // Choice2
        // 
        Choice2.Location = new Point(430, 165);
        Choice2.Name = "Choice2";
        Choice2.Size = new Size(300, 100);
        Choice2.TabIndex = 2;
        Choice2.Text = "button2";
        Choice2.UseVisualStyleBackColor = true;
        Choice2.Click += Choice2_Click;
        // 
        // Choice3
        // 
        Choice3.Location = new Point(63, 308);
        Choice3.Name = "Choice3";
        Choice3.Size = new Size(300, 100);
        Choice3.TabIndex = 3;
        Choice3.Text = "button3";
        Choice3.UseVisualStyleBackColor = true;
        Choice3.Click += Choice3_Click;
        // 
        // Choice4
        // 
        Choice4.Location = new Point(430, 308);
        Choice4.Name = "Choice4";
        Choice4.Size = new Size(300, 100);
        Choice4.TabIndex = 4;
        Choice4.Text = "button4";
        Choice4.UseVisualStyleBackColor = true;
        Choice4.Click += Choice4_Click;
        // 
        // UiSelectionOrder
        // 
        AutoScaleDimensions = new SizeF(11F, 24F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 467);
        Controls.Add(Choice4);
        Controls.Add(Choice3);
        Controls.Add(Choice2);
        Controls.Add(Choice1);
        Controls.Add(Question);
        Name = "UiSelectionOrder";
        Text = "UiSelectionOrder";
        Load += SelectionOrder_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button Choice2;
    private System.Windows.Forms.Button Choice3;
    private System.Windows.Forms.Button Choice4;

    private System.Windows.Forms.Label Question;
    private System.Windows.Forms.Button Choice1;

    #endregion
}