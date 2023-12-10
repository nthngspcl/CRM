namespace CRM
{
    partial class RegistrationForm
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
            txtNewUsername = new TextBox();
            txtNewPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnRegister = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new Point(93, 116);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(405, 25);
            txtNewUsername.TabIndex = 0;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(93, 179);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(405, 25);
            txtNewPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(93, 90);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 6;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(93, 153);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 7;
            label2.Text = "Пароль";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(218, 228);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(137, 42);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(82, 32);
            label3.Name = "label3";
            label3.Size = new Size(438, 32);
            label3.TabIndex = 9;
            label3.Text = "Регистрация нового пользователя";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 338);
            Controls.Add(label3);
            Controls.Add(btnRegister);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNewPassword);
            Controls.Add(txtNewUsername);
            Name = "RegistrationForm";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewUsername;
        private TextBox txtNewPassword;
        private Label label1;
        private Label label2;
        private Button btnRegister;
        private Label label3;
    }
}