using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class AssignOrderForm : Form
    {
        private readonly int _orderId; private decimal _requiredWeight; private decimal _requiredVolume;
        public AssignOrderForm() { InitializeComponent(); }
        public AssignOrderForm(int orderId) : this() { _orderId = orderId; }
        private void AssignOrderForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; Text = "Назначение водителя и транспорта"; LoadOrderRequirements(); LoadDrivers(); LoadVehicles(); }
        // Подтягивает параметры груза, чтобы отфильтровать подходящий транспорт.
        private void LoadOrderRequirements() { DataTable table = DbHelper.ExecuteQuery("select weight_kg, volume_m3 from orders where id = @id;", new NpgsqlParameter("@id", _orderId)); if (table.Rows.Count == 0) throw new Exception("Заявка не найдена."); _requiredWeight = Convert.ToDecimal(table.Rows[0]["weight_kg"]); _requiredVolume = Convert.ToDecimal(table.Rows[0]["volume_m3"]); lblInfo.Text = string.Format("Требования заявки: {0} кг, {1} м3", _requiredWeight, _requiredVolume); }
        // Загружает свободных водителей.
        private void LoadDrivers() { DataTable table = DbHelper.ExecuteQuery(@"select d.id, e.full_name from drivers d join employees e on e.id = d.employee_id where d.driver_status = 'free' or d.id = (select driver_id from order_assignments where order_id = @order_id) order by e.full_name;", new NpgsqlParameter("@order_id", _orderId)); cmbDriver.DataSource = table; cmbDriver.DisplayMember = "full_name"; cmbDriver.ValueMember = "id"; }
        // Загружает свободный и подходящий транспорт по весу, объёму и техсостоянию.
        private void LoadVehicles() { DataTable table = DbHelper.ExecuteQuery(@"select id, plate_number || ' — ' || brand || ' ' || model as vehicle_name from vehicles where technical_status = 'ok' and capacity_kg >= @weight_kg and volume_m3 >= @volume_m3 and (work_status = 'free' or id = (select vehicle_id from order_assignments where order_id = @order_id)) order by plate_number;", new NpgsqlParameter("@weight_kg", _requiredWeight), new NpgsqlParameter("@volume_m3", _requiredVolume), new NpgsqlParameter("@order_id", _orderId)); cmbVehicle.DataSource = table; cmbVehicle.DisplayMember = "vehicle_name"; cmbVehicle.ValueMember = "id"; }
        // Сохраняет назначение водителя и машины на выбранную заявку.
        private void btnSave_Click(object sender, EventArgs e) { if (cmbDriver.SelectedValue == null || cmbVehicle.SelectedValue == null) { MessageBox.Show("Выберите водителя и транспорт."); return; } try { OrderService.AssignOrder(_orderId, Convert.ToInt32(cmbDriver.SelectedValue), Convert.ToInt32(cmbVehicle.SelectedValue)); DialogResult = DialogResult.OK; Close(); } catch (Exception ex) { MessageBox.Show("Ошибка при назначении ресурсов.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
