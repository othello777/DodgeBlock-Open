using System.Drawing;
using System.Runtime.InteropServices;

namespace DodgeBlockFormsPort
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConsoleRrichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CodeButton = new System.Windows.Forms.Button();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConsoleRrichTextBox
            // 
            this.ConsoleRrichTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConsoleRrichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleRrichTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ConsoleRrichTextBox.Font = new System.Drawing.Font("Courier New", 12F);
            this.ConsoleRrichTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.ConsoleRrichTextBox.Location = new System.Drawing.Point(12, 38);
            this.ConsoleRrichTextBox.Name = "ConsoleRrichTextBox";
            this.ConsoleRrichTextBox.ReadOnly = true;
            this.ConsoleRrichTextBox.Size = new System.Drawing.Size(776, 400);
            this.ConsoleRrichTextBox.TabIndex = 0;
            this.ConsoleRrichTextBox.Text = "DodgeBlock";
            this.ConsoleRrichTextBox.Enter += new System.EventHandler(this.ConsoleRrichTextBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cheater Cheater Lemon Eater!";
            // 
            // CodeButton
            // 
            this.CodeButton.Location = new System.Drawing.Point(12, 9);
            this.CodeButton.Name = "CodeButton";
            this.CodeButton.Size = new System.Drawing.Size(133, 23);
            this.CodeButton.TabIndex = 3;
            this.CodeButton.Text = "Copy Secret Code";
            this.CodeButton.UseVisualStyleBackColor = true;
            this.CodeButton.Click += new System.EventHandler(this.CodeButton_Click);
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(151, 11);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(637, 20);
            this.CodeBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.CodeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConsoleRrichTextBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DodgeBlock - Windows Forms Port";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        public System.Windows.Forms.RichTextBox ConsoleRrichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CodeButton;
        private System.Windows.Forms.TextBox CodeBox;
    }
}

