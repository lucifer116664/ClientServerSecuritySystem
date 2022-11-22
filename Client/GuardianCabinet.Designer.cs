namespace Client
{
    partial class GuardianCabinet
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.watchCamerasButton = new System.Windows.Forms.Button();
            this.checkSensorsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(12, 405);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(58, 36);
            this.loginLabel.TabIndex = 12;
            this.loginLabel.Text = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 75);
            this.label1.TabIndex = 11;
            this.label1.Text = "YurkoSecurity";
            // 
            // watchCamerasButton
            // 
            this.watchCamerasButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchCamerasButton.Location = new System.Drawing.Point(138, 241);
            this.watchCamerasButton.Name = "watchCamerasButton";
            this.watchCamerasButton.Size = new System.Drawing.Size(185, 45);
            this.watchCamerasButton.TabIndex = 10;
            this.watchCamerasButton.Text = "Watch cameras";
            this.watchCamerasButton.UseVisualStyleBackColor = true;
            this.watchCamerasButton.Click += new System.EventHandler(this.watchCamerasButton_Click);
            // 
            // checkSensorsButton
            // 
            this.checkSensorsButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSensorsButton.Location = new System.Drawing.Point(490, 241);
            this.checkSensorsButton.Name = "checkSensorsButton";
            this.checkSensorsButton.Size = new System.Drawing.Size(185, 45);
            this.checkSensorsButton.TabIndex = 13;
            this.checkSensorsButton.Text = "Check sensors";
            this.checkSensorsButton.UseVisualStyleBackColor = true;
            this.checkSensorsButton.Click += new System.EventHandler(this.checkSensorsButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(708, 12);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 41);
            this.quitButton.TabIndex = 21;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // GuardianCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.checkSensorsButton);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.watchCamerasButton);
            this.Name = "GuardianCabinet";
            this.Text = "Guardian cabinet";
            this.Load += new System.EventHandler(this.GuardianCabinet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button watchCamerasButton;
        private System.Windows.Forms.Button checkSensorsButton;
        private System.Windows.Forms.Button quitButton;
    }
}