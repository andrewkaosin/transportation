using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm() { InitializeComponent(); }
        private void EmployeesForm_Load(object sender, EventArgs e) { if (!DesignModeHelper.IsInDesignMode()) { ConfigureAccess(); LoadEmployees(); } }
        // У сотрудников доступ только у администратора, поэтому прячем кнопки для других ролей.
        private void ConfigureAccess()
        {
            bool canManage = RoleAccess.CanManageEmployees();
            btnAdd.Visible = canManage;
            btnEdit.Visible = canManage;
            btnDelete.Visible = canManage;
        }
        // Загружает сотрудников в таблицу, чтобы их было удобно просматривать и редактировать.
        private void LoadEmployees()
        {
            string query = "select id, full_name as \"ФИО\", position as \"Должность\", coalesce(phone, '') as \"Телефон\", hire_date as \"Дата приема\", case when is_active then 'Да' else 'Нет' end as \"Активен\" from employees order by id;";
            DataTable table = DbHelper.ExecuteQuery(query); dgvEmployees.DataSource = table; if (dgvEmployees.Columns.Contains("id")) dgvEmployees.Columns["id"].Visible = false;
        }
        private int GetSelectedEmployeeId() { return dgvEmployees.CurrentRow == null ? -1 : Convert.ToInt32(dgvEmployees.CurrentRow.Cells["id"].Value); }
        private void btnAdd_Click(object sender, EventArgs e) { using (var form = new EmployeeEditForm()) { if (form.ShowDialog() == DialogResult.OK) LoadEmployees(); } }
        private void btnEdit_Click(object sender, EventArgs e) { int id = GetSelectedEmployeeId(); if (id == -1) { MessageBox.Show("Выберите сотрудника."); return; } using (var form = new EmployeeEditForm(id)) { if (form.ShowDialog() == DialogResult.OK) LoadEmployees(); } }
        private void btnDelete_Click(object sender, EventArgs e) { int id = GetSelectedEmployeeId(); if (id == -1) { MessageBox.Show("Выберите сотрудника."); return; } if (MessageBox.Show("Удалить выбранного сотрудника?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; try { DbHelper.ExecuteNonQuery("delete from employees where id = @id;", new NpgsqlParameter("@id", id)); LoadEmployees(); } catch (Exception ex) { MessageBox.Show("Не удалось удалить сотрудника.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadEmployees(); }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
