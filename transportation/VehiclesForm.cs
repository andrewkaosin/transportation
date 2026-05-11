using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class VehiclesForm : Form
    {
        public VehiclesForm() { InitializeComponent(); }
        private void VehiclesForm_Load(object sender, EventArgs e) { if (!DesignModeHelper.IsInDesignMode()) LoadVehicles(); }
        // Загружает автопарк в таблицу.
        private void LoadVehicles()
        {
            DataTable table = DbHelper.ExecuteQuery("select id, plate_number as \"Госномер\", brand as \"Марка\", model as \"Модель\", capacity_kg as \"Грузоподъемность, кг\", volume_m3 as \"Объем кузова, м3\", technical_status as \"Тех. статус\", work_status as \"Рабочий статус\" from vehicles order by id;");
            dgvVehicles.DataSource = table; if (dgvVehicles.Columns.Contains("id")) dgvVehicles.Columns["id"].Visible = false;
        }
        private int GetSelectedVehicleId() { return dgvVehicles.CurrentRow == null ? -1 : Convert.ToInt32(dgvVehicles.CurrentRow.Cells["id"].Value); }
        private void btnAdd_Click(object sender, EventArgs e) { using (var form = new VehicleEditForm()) { if (form.ShowDialog() == DialogResult.OK) LoadVehicles(); } }
        private void btnEdit_Click(object sender, EventArgs e) { int id = GetSelectedVehicleId(); if (id == -1) { MessageBox.Show("Выберите транспорт."); return; } using (var form = new VehicleEditForm(id)) { if (form.ShowDialog() == DialogResult.OK) LoadVehicles(); } }
        private void btnDelete_Click(object sender, EventArgs e) { int id = GetSelectedVehicleId(); if (id == -1) { MessageBox.Show("Выберите транспорт."); return; } if (MessageBox.Show("Удалить выбранный транспорт?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; try { DbHelper.ExecuteNonQuery("delete from vehicles where id = @id;", new NpgsqlParameter("@id", id)); LoadVehicles(); } catch (Exception ex) { MessageBox.Show("Не удалось удалить транспорт.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadVehicles(); }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
