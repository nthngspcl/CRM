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
    public partial class LoginForm : Form
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "adminpass";

        private const string WorkerUsername = "worker";
        private const string WorkerPassword = "workerpass";

        private Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
        private const string ConnectionString = "Host=localhost:5432;Username=postgres;Password=123;Database=crm";
        public string SelectedRole { get; private set; }
        public string Username { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            btnRegister.Click += btnRegister_Click;

            registeredUsers.Add(AdminUsername, AdminPassword);
            registeredUsers.Add(WorkerUsername, WorkerPassword);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text.Trim().ToLower();
            string enteredPassword = txtPassword.Text;

            try
            {
                if (AuthenticateUser(enteredUsername, enteredPassword))
                {
                    Username = enteredUsername;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            if ((username == AdminUsername && password == AdminPassword) ||
                (username == WorkerUsername && password == WorkerPassword) ||
                (registeredUsers.ContainsKey(username) && registeredUsers[username] == password))
            {
                // Аутентификация прошла успешно
                if (username == AdminUsername)
                    SelectedRole = "Admin";
                else if (username == WorkerUsername || registeredUsers.ContainsKey(username))
                    SelectedRole = "Worker";

                return true;
            }

            return false;
        }
        private bool CheckUserInDatabase(string username, string password)
        {
            using (var postgresConnection = new NpgsqlConnection(ConnectionString))
            {
                postgresConnection.Open();

                using (var postgresCommand = new NpgsqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", postgresConnection))
                {
                    postgresCommand.Parameters.AddWithValue("@Username", username);
                    postgresCommand.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(postgresCommand.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var registrationForm = new RegistrationForm())
            {
                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    string newUsername = registrationForm.RegisteredUsername;
                    string newPassword = registrationForm.RegisteredPassword;

                    // Добавление нового пользователя в словарь
                    registeredUsers.Add(newUsername, newPassword);

                    MessageBox.Show($"Пользователь {newUsername} успешно зарегистрирован.", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
