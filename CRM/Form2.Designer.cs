namespace CRM
{
    partial class LoginForm
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
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnRegister = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(69, 216);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(136, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(69, 107);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(416, 25);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(69, 173);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(416, 25);
            txtPassword.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(69, 81);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 5;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(69, 147);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(329, 216);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(156, 29);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(194, 28);
            label3.Name = "label3";
            label3.Size = new Size(177, 32);
            label3.TabIndex = 8;
            label3.Text = "Авторизация";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 282);
            Controls.Add(label3);
            Controls.Add(btnRegister);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnRegister;
        private Label label3;
    }
}