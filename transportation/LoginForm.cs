using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace transportation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Выполняет вход в систему и открывает главное меню с учётом роли пользователя.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CurrentUser user = AuthService.Login(login, password);
                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AppSession.CurrentUser = user;
                MainForm mainForm = new MainForm(user);
                mainForm.FormClosed += delegate
                {
                    AppSession.Clear();
                    txtPassword.Clear();
                    this.Show();
                };

                Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (DesignModeHelper.IsInDesignMode())
                return;

            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        private void lblHint_Click(object sender, EventArgs e)
        {

        }
    }
}