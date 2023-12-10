namespace CRM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // ¬ зависимости от выбранной роли, вы можете создать соответствующую форму.
                    bool isAdmin = loginForm.SelectedRole == "Admin";
                    Application.Run(new Form1(isAdmin, loginForm.SelectedRole,loginForm.Username));
                }
            }
        }
    }
}