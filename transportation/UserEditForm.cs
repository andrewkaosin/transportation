using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class UserEditForm : Form
    {
        private readonly int? _userId;

        public UserEditForm()
        {
            InitializeComponent();
            _userId = null;
        }

        public UserEditForm(int userId) : this()
        {
            _userId = userId;
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            if (DesignModeHelper.IsInDesignMode())
                return;

            LoadRoles();

            if (_userId.HasValue)
            {
                Text = "Редактирование пользователя";
                LoadUserData();
                txtPassword.PlaceholderTextSafe("Оставьте пустым, чтобы не менять пароль");
            }
            else
            {
                Text = "Добавление пользователя";
            }
        }

        private void LoadRoles()
        {
            DataTable table = DbHelper.ExecuteQuery("select id, name from roles order by id;");
            cmbRole.DataSource = table;
            cmbRole.DisplayMember = "name";
            cmbRole.ValueMember = "id";
        }

        private void LoadUserData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select login, role_id, is_active from users where id = @id;", new NpgsqlParameter("@id", _userId.Value));
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь не найден.");
                Close();
                return;
            }

            DataRow row = table.Rows[0];
            txtLogin.Text = Convert.ToString(row["login"]);
            cmbRole.SelectedValue = Convert.ToInt32(row["role_id"]);
            chkIsActive.Checked = Convert.ToBoolean(row["is_active"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин.");
                return;
            }
            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Выберите роль.");
                return;
            }
            if (!_userId.HasValue && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль для нового пользователя.");
                return;
            }

            try
            {
                if (_userId.HasValue)
                {
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        DbHelper.ExecuteNonQuery(@"update users set login = @login, role_id = @role_id, is_active = @is_active where id = @id;",
                            new NpgsqlParameter("@login", login),
                            new NpgsqlParameter("@role_id", Convert.ToInt32(cmbRole.SelectedValue)),
                            new NpgsqlParameter("@is_active", chkIsActive.Checked),
                            new NpgsqlParameter("@id", _userId.Value));
                    }
                    else
                    {
                        DbHelper.ExecuteNonQuery(@"update users set login = @login, password_hash = @password_hash, role_id = @role_id, is_active = @is_active where id = @id;",
                            new NpgsqlParameter("@login", login),
                            new NpgsqlParameter("@password_hash", PasswordHasher.HashPassword(password)),
                            new NpgsqlParameter("@role_id", Convert.ToInt32(cmbRole.SelectedValue)),
                            new NpgsqlParameter("@is_active", chkIsActive.Checked),
                            new NpgsqlParameter("@id", _userId.Value));
                    }
                }
                else
                {
                    DbHelper.ExecuteNonQuery(@"insert into users (login, password_hash, role_id, is_active) values (@login, @password_hash, @role_id, @is_active);",
                        new NpgsqlParameter("@login", login),
                        new NpgsqlParameter("@password_hash", PasswordHasher.HashPassword(password)),
                        new NpgsqlParameter("@role_id", Convert.ToInt32(cmbRole.SelectedValue)),
                        new NpgsqlParameter("@is_active", chkIsActive.Checked));
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить пользователя.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    internal static class TextBoxExtensions
    {

        public static void PlaceholderTextSafe(this TextBox textBox, string text)
        {
            if (textBox == null) return;
            textBox.Tag = text;
        }
    }
}
