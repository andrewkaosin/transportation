using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class DriversForm : Form
    {
        public DriversForm() { InitializeComponent(); }
        private void DriversForm_Load(object sender, EventArgs e) { if (!DesignModeHelper.IsInDesignMode()) LoadDrivers(); }
        // Загружает водителей вместе с ФИО и статусом.
        private void LoadDrivers()
        {
            DataTable table = DbHelper.ExecuteQuery("select d.id, e.full_name as \"ФИО\", d.license_number as \"Номер прав\", d.license_category as \"Категория\", d.driver_status as \"Статус\" from drivers d join employees e on e.id = d.employee_id order by d.id;");
            dgvDrivers.DataSource = table; if (dgvDrivers.Columns.Contains("id")) dgvDrivers.Columns["id"].Visible = false;
        }
        private int GetSelectedDriverId() { return dgvDrivers.CurrentRow == null ? -1 : Convert.ToInt32(dgvDrivers.CurrentRow.Cells["id"].Value); }
        private void btnAdd_Click(object sender, EventArgs e) { using (var form = new DriverEditForm()) { if (form.ShowDialog() == DialogResult.OK) LoadDrivers(); } }
        private void btnEdit_Click(object sender, EventArgs e) { int id = GetSelectedDriverId(); if (id == -1) { MessageBox.Show("Выберите водителя."); return; } using (var form = new DriverEditForm(id)) { if (form.ShowDialog() == DialogResult.OK) LoadDrivers(); } }
        private void btnDelete_Click(object sender, EventArgs e) { int id = GetSelectedDriverId(); if (id == -1) { MessageBox.Show("Выберите водителя."); return; } if (MessageBox.Show("Удалить выбранного водителя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; try { DbHelper.ExecuteNonQuery("delete from drivers where id = @id;", new NpgsqlParameter("@id", id)); LoadDrivers(); } catch (Exception ex) { MessageBox.Show("Не удалось удалить водителя.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadDrivers(); }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
