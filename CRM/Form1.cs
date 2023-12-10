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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRM
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection postgresConnection;
        private NpgsqlCommand postgresCommand;
        private NpgsqlDataAdapter postgresDataAdapter;
        private DataTable dataTable;

        private bool isAdmin;
        private string userRole;
        private string currentUser;
        public Form1(bool isAdmin, string userRole, string currentUser)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.userRole = userRole;

            InitializeDatabase();
            LoadTimeRecords();

            if (isAdmin)
            {
                btnGenerateReport.Visible = false; // Скрываем кнопку для администратора
                btnViewReport.Visible = true;
            }
            else
            {
                btnGenerateReport.Visible = true;
                btnViewReport.Visible = false;
            }
            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;
            btnViewReport.Click += btnViewReport_Click;
            this.currentUser = currentUser;
        }
        private void InitializeDatabase()
        {
            string connectionString = "Host=localhost:5432;Username=postgres;Password=123;Database=crm";
            postgresConnection = new NpgsqlConnection(connectionString);

            try
            {
                postgresConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии соединения с базой данных: " + ex.Message);
                Environment.Exit(1);
            }

            postgresCommand = new NpgsqlCommand("CREATE TABLE IF NOT EXISTS TimeRecord (Id SERIAL PRIMARY KEY, Username TEXT, TaskName TEXT, StartTime TIMESTAMP, EndTime TIMESTAMP)", postgresConnection);
            postgresCommand.ExecuteNonQuery();
        }

        private void LoadTimeRecords()
        {
            string query = isAdmin
        ? "SELECT * FROM TimeRecord"
        : $"SELECT * FROM TimeRecord WHERE Username = '{currentUser}'";

            postgresDataAdapter = new NpgsqlDataAdapter(query, postgresConnection);

            dataTable = new DataTable();
            postgresDataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

        }

        private int GetCurrentUserId()
        {
            // Замените на ваш код для определения текущего пользователя
            return 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (NpgsqlTransaction transaction = postgresConnection.BeginTransaction())
            {
                try
                {
                    string taskName = txtTaskName.Text;
                    DateTime startTime = DateTime.Now;

                    postgresCommand = new NpgsqlCommand("INSERT INTO TimeRecord (Username, TaskName, StartTime) VALUES (@Username, @TaskName, @StartTime)", postgresConnection, transaction);
                    postgresCommand.Parameters.AddWithValue("@Username", currentUser);
                    postgresCommand.Parameters.AddWithValue("@TaskName", taskName);
                    postgresCommand.Parameters.AddWithValue("@StartTime", startTime);
                    postgresCommand.ExecuteNonQuery();

                    MessageBox.Show("Работа начата.");

                    LoadTimeRecords();

                    transaction.Commit(); // Фиксация транзакции после успешного выполнения
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Откат транзакции в случае ошибки
                    MessageBox.Show($"Ошибка при начале работы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            using (NpgsqlTransaction transaction = postgresConnection.BeginTransaction())
            {
                try
                {
                    DateTime endTime = DateTime.Now;

                    postgresCommand = new NpgsqlCommand("UPDATE TimeRecord SET EndTime = @EndTime WHERE Id = (SELECT MAX(Id) FROM TimeRecord WHERE Username = @Username AND EndTime IS NULL)", postgresConnection, transaction);
                    postgresCommand.Parameters.AddWithValue("@Username", currentUser);
                    postgresCommand.Parameters.AddWithValue("@EndTime", endTime);
                    postgresCommand.ExecuteNonQuery();

                    MessageBox.Show("Работа завершена.");

                    LoadTimeRecords();

                    transaction.Commit(); // Фиксация транзакции после успешного выполнения
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Откат транзакции в случае ошибки
                    MessageBox.Show($"Ошибка при завершении работы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void GenerateReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("Отчет по времени работы:");

            foreach (DataRow row in dataTable.Rows)
            {
                string taskName = row["TaskName"].ToString();
                DateTime startTime = Convert.ToDateTime(row["StartTime"]);
                string userName = row["Username"].ToString();
                // Check if "EndTime" is DBNull.Value before converting
                DateTime? endTime = row["EndTime"] != DBNull.Value ? Convert.ToDateTime(row["EndTime"]) : (DateTime?)null;

                TimeSpan? taskDuration = endTime - startTime;
                report.AppendLine($"Работник: {userName}");
                report.AppendLine($"Задача: {taskName}");
                report.AppendLine($"Время начала: {startTime}");

                if (endTime.HasValue)
                {
                    report.AppendLine($"Время завершения: {endTime}");
                    report.AppendLine($"Длительность: {taskDuration?.TotalHours ?? 0} часов");
                }
                else
                {
                    report.AppendLine("Задача еще не завершена");
                }

                if (dataTable.Rows.IndexOf(row) < dataTable.Rows.Count - 1)
                {
                    DateTime nextStartTime = Convert.ToDateTime(dataTable.Rows[dataTable.Rows.IndexOf(row) + 1]["StartTime"]);
                    TimeSpan breakDuration = nextStartTime - (endTime ?? startTime);

                    report.AppendLine($"Перерыв между задачами: {breakDuration.TotalMinutes} минут");
                }

                report.AppendLine();
            }

            MessageBox.Show(report.ToString(), "Генерация отчета");
        }



        private void ViewReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("Ваш отчет по времени работы:");

            foreach (DataRow row in dataTable.Rows)
            {
                string userName = row["Username"].ToString();
                string taskName = row["TaskName"].ToString();
                DateTime startTime = Convert.ToDateTime(row["StartTime"]);
                DateTime endTime = Convert.ToDateTime(row["EndTime"]);

                TimeSpan taskDuration = endTime - startTime;
                report.AppendLine($"Работник: {userName}");
                report.AppendLine($"Задача: {taskName}");
                report.AppendLine($"Время начала: {startTime}");
                report.AppendLine($"Время завершения: {endTime}");
                report.AppendLine($"Длительность: {taskDuration.TotalHours} часов");

                if (dataTable.Rows.IndexOf(row) < dataTable.Rows.Count - 1)
                {
                    DateTime nextStartTime = Convert.ToDateTime(dataTable.Rows[dataTable.Rows.IndexOf(row) + 1]["StartTime"]);
                    TimeSpan breakDuration = nextStartTime - endTime;

                    report.AppendLine($"Перерыв между задачами: {breakDuration.TotalMinutes} минут");
                }

                report.AppendLine();
            }

            MessageBox.Show(report.ToString(), "Просмотр отчета");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            postgresConnection.Close();
        }
    }
}
