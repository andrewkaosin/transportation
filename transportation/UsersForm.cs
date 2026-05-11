using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            if (DesignModeHelper.IsInDesignMode())
                return;

            if (!RoleAccess.CanManageUsers())
            {
                MessageBox.Show("Этот раздел доступен только администратору.");
                Close();
                return;
            }

            LoadUsers();
        }

        // Загружает список пользователей вместе с ролью и статусом аккаунта.
        private void LoadUsers()
        {
            string query = @"
                select
                    u.id,
                    u.login as ""Логин"",
                    r.name as ""Роль"",
                    case when u.is_active then 'Да' else 'Нет' end as ""Активен"",
                    u.created_at as ""Создан""
                from users u
                join roles r on r.id = u.role_id
                order by u.id;";

            DataTable table = DbHelper.ExecuteQuery(query);
            dgvUsers.DataSource = table;

            if (dgvUsers.Columns.Contains("id"))
                dgvUsers.Columns["id"].Visible = false;
        }

        private int GetSelectedUserId()
        {
            return dgvUsers.CurrentRow == null ? -1 : Convert.ToInt32(dgvUsers.CurrentRow.Cells["id"].Value);
        }

        private string GetSelectedLogin()
        {
            return dgvUsers.CurrentRow == null ? string.Empty : Convert.ToString(dgvUsers.CurrentRow.Cells["Логин"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new UserEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int userId = GetSelectedUserId();
            if (userId == -1)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }

            using (var form = new UserEditForm(userId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int userId = GetSelectedUserId();
            if (userId == -1)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }

            string login = GetSelectedLogin();
            if (login == "admin")
            {
                MessageBox.Show("Нельзя удалить основного администратора.");
                return;
            }

            if (MessageBox.Show("Удалить выбранного пользователя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                DbHelper.ExecuteNonQuery("delete from users where id = @id;", new NpgsqlParameter("@id", userId));
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить пользователя.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
