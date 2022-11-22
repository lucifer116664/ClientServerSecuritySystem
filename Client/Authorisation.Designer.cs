namespace Client
{
    partial class Authorisation
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorisation));
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.logInButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.showPicture = new System.Windows.Forms.PictureBox();
            this.hidePicture = new System.Windows.Forms.PictureBox();
            this.quitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTextBox.Location = new System.Drawing.Point(280, 162);
            this.loginTextBox.Multiline = true;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(251, 43);
            this.loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(280, 235);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(251, 43);
            this.passwordTextBox.TabIndex = 1;
            // 
            // logInButton
            // 
            this.logInButton.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInButton.Location = new System.Drawing.Point(316, 321);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(185, 45);
            this.logInButton.TabIndex = 2;
            this.logInButton.Text = "Log in";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 75);
            this.label1.TabIndex = 3;
            this.label1.Text = "YurkoSecurity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Login:   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // showPicture
            // 
            this.showPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showPicture.Image = ((System.Drawing.Image)(resources.GetObject("showPicture.Image")));
            this.showPicture.Location = new System.Drawing.Point(553, 235);
            this.showPicture.Name = "showPicture";
            this.showPicture.Size = new System.Drawing.Size(43, 43);
            this.showPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPicture.TabIndex = 6;
            this.showPicture.TabStop = false;
            this.showPicture.Click += new System.EventHandler(this.showPicture_Click);
            // 
            // hidePicture
            // 
            this.hidePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hidePicture.Image = ((System.Drawing.Image)(resources.GetObject("hidePicture.Image")));
            this.hidePicture.Location = new System.Drawing.Point(553, 235);
            this.hidePicture.Name = "hidePicture";
            this.hidePicture.Size = new System.Drawing.Size(43, 43);
            this.hidePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hidePicture.TabIndex = 7;
            this.hidePicture.TabStop = false;
            this.hidePicture.Click += new System.EventHandler(this.hidePicture_Click);
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
            // Authorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.showPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.hidePicture);
            this.Name = "Authorisation";
            this.Text = "Authorisation";
            this.Load += new System.EventHandler(this.Authorisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox showPicture;
        private System.Windows.Forms.PictureBox hidePicture;
        private System.Windows.Forms.Button quitButton;
    }
}

