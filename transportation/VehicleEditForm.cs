using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class VehicleEditForm : Form
    {
        private readonly int? _vehicleId;
        public VehicleEditForm() { InitializeComponent(); }
        public VehicleEditForm(int vehicleId) : this() { _vehicleId = vehicleId; }
        private void VehicleEditForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; cmbTechnicalStatus.Items.Clear(); cmbTechnicalStatus.Items.AddRange(new object[] { "ok", "repair" }); cmbWorkStatus.Items.Clear(); cmbWorkStatus.Items.AddRange(new object[] { "free", "busy" }); if (_vehicleId.HasValue) { Text = "Редактирование транспорта"; LoadVehicleData(); } else { Text = "Добавление транспорта"; cmbTechnicalStatus.SelectedIndex = 0; cmbWorkStatus.SelectedIndex = 0; } }
        // Загружает транспорт в форму редактирования.
        private void LoadVehicleData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select plate_number, brand, model, capacity_kg, volume_m3, technical_status, work_status from vehicles where id = @id;", new NpgsqlParameter("@id", _vehicleId.Value));
            if (table.Rows.Count == 0) { MessageBox.Show("Транспорт не найден."); Close(); return; }
            DataRow row = table.Rows[0]; txtPlateNumber.Text = row["plate_number"].ToString(); txtBrand.Text = row["brand"].ToString(); txtModel.Text = row["model"].ToString(); txtCapacityKg.Text = Convert.ToDecimal(row["capacity_kg"]).ToString(CultureInfo.InvariantCulture); txtVolumeM3.Text = Convert.ToDecimal(row["volume_m3"]).ToString(CultureInfo.InvariantCulture); cmbTechnicalStatus.SelectedItem = row["technical_status"].ToString(); cmbWorkStatus.SelectedItem = row["work_status"].ToString();
        }
        // Сохраняет данные транспорта после базовой валидации.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text) || string.IsNullOrWhiteSpace(txtBrand.Text) || string.IsNullOrWhiteSpace(txtModel.Text)) { MessageBox.Show("Заполните госномер, марку и модель."); return; }
            if (!decimal.TryParse(txtCapacityKg.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal capacityKg) || capacityKg <= 0) { MessageBox.Show("Некорректная грузоподъёмность."); return; }
            if (!decimal.TryParse(txtVolumeM3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal volumeM3) || volumeM3 <= 0) { MessageBox.Show("Некорректный объём кузова."); return; }
            try
            {
                if (_vehicleId.HasValue)
                    DbHelper.ExecuteNonQuery(@"update vehicles set plate_number = @plate_number, brand = @brand, model = @model, capacity_kg = @capacity_kg, volume_m3 = @volume_m3, technical_status = @technical_status, work_status = @work_status where id = @id;", new NpgsqlParameter("@plate_number", txtPlateNumber.Text.Trim()), new NpgsqlParameter("@brand", txtBrand.Text.Trim()), new NpgsqlParameter("@model", txtModel.Text.Trim()), new NpgsqlParameter("@capacity_kg", capacityKg), new NpgsqlParameter("@volume_m3", volumeM3), new NpgsqlParameter("@technical_status", cmbTechnicalStatus.Text), new NpgsqlParameter("@work_status", cmbWorkStatus.Text), new NpgsqlParameter("@id", _vehicleId.Value));
                else
                    DbHelper.ExecuteNonQuery(@"insert into vehicles (plate_number, brand, model, capacity_kg, volume_m3, technical_status, work_status) values (@plate_number, @brand, @model, @capacity_kg, @volume_m3, @technical_status, @work_status);", new NpgsqlParameter("@plate_number", txtPlateNumber.Text.Trim()), new NpgsqlParameter("@brand", txtBrand.Text.Trim()), new NpgsqlParameter("@model", txtModel.Text.Trim()), new NpgsqlParameter("@capacity_kg", capacityKg), new NpgsqlParameter("@volume_m3", volumeM3), new NpgsqlParameter("@technical_status", cmbTechnicalStatus.Text), new NpgsqlParameter("@work_status", cmbWorkStatus.Text));
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при сохранении транспорта.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
