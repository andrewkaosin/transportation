using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class DriverEditForm : Form
    {
        private readonly int? _driverId;
        public DriverEditForm() { InitializeComponent(); }
        public DriverEditForm(int driverId) : this() { _driverId = driverId; }
        private void DriverEditForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; cmbStatus.Items.Clear(); cmbStatus.Items.AddRange(new object[] { "free", "busy", "inactive" }); LoadEmployees(); if (_driverId.HasValue) { Text = "Редактирование водителя"; LoadDriverData(); } else { Text = "Добавление водителя"; if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0; } }
        // Загружает сотрудников, которых можно выбрать как водителя.
        private void LoadEmployees()
        {
            string query = _driverId.HasValue ? @"select e.id, e.full_name from employees e where e.id not in (select employee_id from drivers where id <> @driver_id) order by e.full_name;" : @"select e.id, e.full_name from employees e where e.id not in (select employee_id from drivers) order by e.full_name;";
            DataTable table = _driverId.HasValue ? DbHelper.ExecuteQuery(query, new NpgsqlParameter("@driver_id", _driverId.Value)) : DbHelper.ExecuteQuery(query);
            cmbEmployee.DataSource = table; cmbEmployee.DisplayMember = "full_name"; cmbEmployee.ValueMember = "id";
        }
        // Загружает данные водителя для редактирования.
        private void LoadDriverData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select employee_id, license_number, license_category, driver_status from drivers where id = @id;", new NpgsqlParameter("@id", _driverId.Value));
            if (table.Rows.Count == 0) { MessageBox.Show("Водитель не найден."); Close(); return; }
            DataRow row = table.Rows[0]; cmbEmployee.SelectedValue = Convert.ToInt32(row["employee_id"]); txtLicenseNumber.Text = row["license_number"].ToString(); txtLicenseCategory.Text = row["license_category"].ToString(); cmbStatus.SelectedItem = row["driver_status"].ToString();
        }
        // Сохраняет водителя и привязку к сотруднику.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null) { MessageBox.Show("Выберите сотрудника."); return; }
            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text) || string.IsNullOrWhiteSpace(txtLicenseCategory.Text)) { MessageBox.Show("Заполните номер прав и категорию."); return; }
            try
            {
                if (_driverId.HasValue)
                    DbHelper.ExecuteNonQuery(@"update drivers set employee_id = @employee_id, license_number = @license_number, license_category = @license_category, driver_status = @driver_status where id = @id;", new NpgsqlParameter("@employee_id", Convert.ToInt32(cmbEmployee.SelectedValue)), new NpgsqlParameter("@license_number", txtLicenseNumber.Text.Trim()), new NpgsqlParameter("@license_category", txtLicenseCategory.Text.Trim()), new NpgsqlParameter("@driver_status", cmbStatus.Text), new NpgsqlParameter("@id", _driverId.Value));
                else
                    DbHelper.ExecuteNonQuery(@"insert into drivers (employee_id, license_number, license_category, driver_status) values (@employee_id, @license_number, @license_category, @driver_status);", new NpgsqlParameter("@employee_id", Convert.ToInt32(cmbEmployee.SelectedValue)), new NpgsqlParameter("@license_number", txtLicenseNumber.Text.Trim()), new NpgsqlParameter("@license_category", txtLicenseCategory.Text.Trim()), new NpgsqlParameter("@driver_status", cmbStatus.Text));
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при сохранении водителя.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
