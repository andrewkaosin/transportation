using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class EmployeeEditForm : Form
    {
        private readonly int? _employeeId;
        public EmployeeEditForm() { InitializeComponent(); }
        public EmployeeEditForm(int employeeId) : this() { _employeeId = employeeId; }
        private void EmployeeEditForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; if (_employeeId.HasValue) { Text = "Редактирование сотрудника"; LoadEmployeeData(); } else { Text = "Добавление сотрудника"; dtpHireDate.Value = DateTime.Today; chkIsActive.Checked = true; } }
        // Подтягивает данные выбранного сотрудника в поля формы для редактирования.
        private void LoadEmployeeData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select full_name, position, phone, hire_date, is_active from employees where id = @id;", new NpgsqlParameter("@id", _employeeId.Value));
            if (table.Rows.Count == 0) { MessageBox.Show("Сотрудник не найден."); Close(); return; }
            DataRow row = table.Rows[0]; txtFullName.Text = row["full_name"].ToString(); txtPosition.Text = row["position"].ToString(); txtPhone.Text = row["phone"].ToString(); dtpHireDate.Value = Convert.ToDateTime(row["hire_date"]); chkIsActive.Checked = Convert.ToBoolean(row["is_active"]);
        }
        // Сохраняет сотрудника: создаёт нового или обновляет существующего.
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim(); string position = txtPosition.Text.Trim(); string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(position)) { MessageBox.Show("Заполните ФИО и должность."); return; }
            try
            {
                if (_employeeId.HasValue)
                    DbHelper.ExecuteNonQuery(@"update employees set full_name = @full_name, position = @position, phone = @phone, hire_date = @hire_date, is_active = @is_active where id = @id;", new NpgsqlParameter("@full_name", fullName), new NpgsqlParameter("@position", position), new NpgsqlParameter("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone), new NpgsqlParameter("@hire_date", dtpHireDate.Value.Date), new NpgsqlParameter("@is_active", chkIsActive.Checked), new NpgsqlParameter("@id", _employeeId.Value));
                else
                    DbHelper.ExecuteNonQuery(@"insert into employees (full_name, position, phone, hire_date, is_active) values (@full_name, @position, @phone, @hire_date, @is_active);", new NpgsqlParameter("@full_name", fullName), new NpgsqlParameter("@position", position), new NpgsqlParameter("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone), new NpgsqlParameter("@hire_date", dtpHireDate.Value.Date), new NpgsqlParameter("@is_active", chkIsActive.Checked));
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при сохранении сотрудника.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
