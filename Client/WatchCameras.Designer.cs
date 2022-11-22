namespace Client
{
    partial class WatchCameras
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
            this.cameraChooseComboBox = new System.Windows.Forms.ComboBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(12, 405);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(58, 36);
            this.loginLabel.TabIndex = 16;
            this.loginLabel.Text = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 75);
            this.label1.TabIndex = 15;
            this.label1.Text = "YurkoSecurity";
            // 
            // watchCamerasButton
            // 
            this.watchCamerasButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchCamerasButton.Location = new System.Drawing.Point(424, 237);
            this.watchCamerasButton.Name = "watchCamerasButton";
            this.watchCamerasButton.Size = new System.Drawing.Size(142, 45);
            this.watchCamerasButton.TabIndex = 14;
            this.watchCamerasButton.Text = "Watch";
            this.watchCamerasButton.UseVisualStyleBackColor = true;
            this.watchCamerasButton.Click += new System.EventHandler(this.watchCamerasButton_Click);
            // 
            // cameraChooseComboBox
            // 
            this.cameraChooseComboBox.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraChooseComboBox.FormattingEnabled = true;
            this.cameraChooseComboBox.Items.AddRange(new object[] {
            "Hallway",
            "Kitchen",
            "Livingroom",
            "Bedroom",
            "Playroom"});
            this.cameraChooseComboBox.Location = new System.Drawing.Point(242, 238);
            this.cameraChooseComboBox.Name = "cameraChooseComboBox";
            this.cameraChooseComboBox.Size = new System.Drawing.Size(142, 44);
            this.cameraChooseComboBox.TabIndex = 18;
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(708, 12);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 41);
            this.quitButton.TabIndex = 27;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(52, 45);
            this.backButton.TabIndex = 28;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 36);
            this.label2.TabIndex = 29;
            this.label2.Text = "Camera";
            // 
            // WatchCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.cameraChooseComboBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.watchCamerasButton);
            this.Name = "WatchCameras";
            this.Text = "Watch cameras";
            this.Load += new System.EventHandler(this.WatchCameras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button watchCamerasButton;
        private System.Windows.Forms.ComboBox cameraChooseComboBox;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label2;
    }
}