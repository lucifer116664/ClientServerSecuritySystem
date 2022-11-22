namespace Client
{
    partial class DeleteGuardians
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
            this.quitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guardiansCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(708, 12);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 41);
            this.quitButton.TabIndex = 28;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(317, 370);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(142, 45);
            this.deleteButton.TabIndex = 29;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(52, 45);
            this.backButton.TabIndex = 32;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 75);
            this.label1.TabIndex = 31;
            this.label1.Text = "YurkoSecurity";
            // 
            // guardiansCheckedListBox
            // 
            this.guardiansCheckedListBox.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardiansCheckedListBox.FormattingEnabled = true;
            this.guardiansCheckedListBox.Location = new System.Drawing.Point(205, 164);
            this.guardiansCheckedListBox.Name = "guardiansCheckedListBox";
            this.guardiansCheckedListBox.Size = new System.Drawing.Size(374, 174);
            this.guardiansCheckedListBox.TabIndex = 33;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(12, 405);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(58, 36);
            this.loginLabel.TabIndex = 34;
            this.loginLabel.Text = "login";
            // 
            // DeleteGuardians
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.guardiansCheckedListBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.quitButton);
            this.Name = "DeleteGuardians";
            this.Text = "Delete guardians";
            this.Load += new System.EventHandler(this.DeleteGuardians_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox guardiansCheckedListBox;
        private System.Windows.Forms.Label loginLabel;
    }
}