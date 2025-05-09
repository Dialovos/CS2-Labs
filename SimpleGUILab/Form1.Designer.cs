namespace SimpleGUILab
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
            this.components = new System.ComponentModel.Container();
            this.namePromptLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.greetButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.greetingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // namePromptLabel
            // 
            this.namePromptLabel.Location = new System.Drawing.Point(309, 45);
            this.namePromptLabel.Name = "namePromptLabel";
            this.namePromptLabel.Size = new System.Drawing.Size(174, 29);
            this.namePromptLabel.TabIndex = 0;
            this.namePromptLabel.Text = "Enter Your Name:";
            this.namePromptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(313, 77);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(170, 26);
            this.nameTextBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nameTextBox, "Enter your first and last name here.");
            // 
            // greetButton
            // 
            this.greetButton.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.greetButton.Location = new System.Drawing.Point(313, 124);
            this.greetButton.Name = "greetButton";
            this.greetButton.Size = new System.Drawing.Size(105, 34);
            this.greetButton.TabIndex = 2;
            this.greetButton.Text = "Greet Me";
            this.greetButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.greetButton, "Click this button after entering your name to see a greeting.");
            this.greetButton.UseVisualStyleBackColor = true;
            this.greetButton.Click += new System.EventHandler(this.greetButton_Click);
            // 
            // greetingLabel
            // 
            this.greetingLabel.Location = new System.Drawing.Point(313, 191);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(212, 44);
            this.greetingLabel.TabIndex = 3;
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.greetingLabel.Click += new System.EventHandler(this.greetingLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.greetingLabel);
            this.Controls.Add(this.greetButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.namePromptLabel);
            this.Name = "Form1";
            this.Text = "Greeting App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namePromptLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button greetButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label greetingLabel;
    }
}

