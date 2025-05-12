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
        Question = new System.Windows.Forms.Label();
        Choice1 = new System.Windows.Forms.Button();
        Choice2 = new System.Windows.Forms.Button();
        Choice3 = new System.Windows.Forms.Button();
        Choice4 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // Question
        // 
        Question.Location = new System.Drawing.Point(49, 46);
        Question.Name = "Question";
        Question.Size = new System.Drawing.Size(357, 77);
        Question.TabIndex = 0;
        Question.Text = "label1";
        // 
        // Choice1
        // 
        Choice1.Location = new System.Drawing.Point(49, 166);
        Choice1.Name = "Choice1";
        Choice1.Size = new System.Drawing.Size(285, 108);
        Choice1.TabIndex = 1;
        Choice1.Text = "button1";
        Choice1.UseVisualStyleBackColor = true;
        // 
        // Choice2
        // 
        Choice2.Location = new System.Drawing.Point(487, 174);
        Choice2.Name = "Choice2";
        Choice2.Size = new System.Drawing.Size(270, 99);
        Choice2.TabIndex = 2;
        Choice2.Text = "button2";
        Choice2.UseVisualStyleBackColor = true;
        // 
        // Choice3
        // 
        Choice3.Location = new System.Drawing.Point(58, 319);
        Choice3.Name = "Choice3";
        Choice3.Size = new System.Drawing.Size(276, 98);
        Choice3.TabIndex = 3;
        Choice3.Text = "button3";
        Choice3.UseVisualStyleBackColor = true;
        // 
        // Choice4
        // 
        Choice4.Location = new System.Drawing.Point(487, 325);
        Choice4.Name = "Choice4";
        Choice4.Size = new System.Drawing.Size(270, 92);
        Choice4.TabIndex = 4;
        Choice4.Text = "button4";
        Choice4.UseVisualStyleBackColor = true;
        // 
        // UiSelectionOrder
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(Choice4);
        Controls.Add(Choice3);
        Controls.Add(Choice2);
        Controls.Add(Choice1);
        Controls.Add(Question);
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