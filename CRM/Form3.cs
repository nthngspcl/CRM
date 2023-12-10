using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class RegistrationForm : Form
    {
        public string RegisteredUsername { get; private set; }
        public string RegisteredPassword { get; private set; }

        public RegistrationForm()
        {
            InitializeComponent();
            btnRegister.Click += btnRegister_Click;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtNewUsername.Text.Trim().ToLower();
            string enteredPassword = txtNewPassword.Text;

            // Простая проверка наличия имени пользователя и пароля
            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Введите имя пользователя и пароль.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Производим регистрацию нового пользователя
            try
            {
                using (var postgresConnection = new NpgsqlConnection("Host=localhost:5432;Username=postgres;Password=123;Database=crm"))
                {
                    postgresConnection.Open();

                    // Создаем таблицу Users, если её нет
                    using (var postgresCommand = new NpgsqlCommand("CREATE TABLE IF NOT EXISTS Users (Id SERIAL PRIMARY KEY, Username TEXT, Password TEXT)", postgresConnection))
                    {
                        postgresCommand.ExecuteNonQuery();
                    }

                    // Вставляем нового пользователя в таблицу Users
                    using (var postgresCommand = new NpgsqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", postgresConnection))
                    {
                        postgresCommand.Parameters.AddWithValue("@Username", enteredUsername);
                        postgresCommand.Parameters.AddWithValue("@Password", enteredPassword);
                        postgresCommand.ExecuteNonQuery();
                    }
                }

                // Успешная регистрация
                RegisteredUsername = enteredUsername;
                RegisteredPassword = enteredPassword;

                MessageBox.Show($"Пользователь {enteredUsername} успешно зарегистрирован.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
