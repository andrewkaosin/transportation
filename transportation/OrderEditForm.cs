using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class OrderEditForm : Form
    {
        private readonly int? _orderId;
        public OrderEditForm() { InitializeComponent(); }
        public OrderEditForm(int orderId) : this() { _orderId = orderId; }
        private void OrderEditForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; LoadClients(); dtpPlannedDate.Value = DateTime.Today; if (_orderId.HasValue) { Text = "Редактирование заявки"; LoadOrderData(); } else { Text = "Добавление заявки"; ApplyRoleDefaults(); } }
        // Загружает клиентов для выбора в заявке.
        private void LoadClients() { DataTable table = DbHelper.ExecuteQuery("select id, company_name from clients order by company_name;"); cmbClient.DataSource = table; cmbClient.DisplayMember = "company_name"; cmbClient.ValueMember = "id"; }
        // Если заявку создаёт клиент, сразу подставляем его запись и блокируем выбор чужого клиента.
        private void ApplyRoleDefaults() { if (AppSession.CurrentUser != null && AppSession.CurrentUser.RoleName == "client") { object clientId = DbHelper.ExecuteScalar("select id from clients where user_id = @user_id limit 1;", new NpgsqlParameter("@user_id", AppSession.CurrentUser.Id)); if (clientId != null && clientId != DBNull.Value) { cmbClient.SelectedValue = Convert.ToInt32(clientId); cmbClient.Enabled = false; } } }
        // Загружает данные выбранной заявки в форму.
        private void LoadOrderData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select client_id, loading_point, unloading_point, cargo_name, weight_kg, volume_m3, planned_date, price, comment from orders where id = @id;", new NpgsqlParameter("@id", _orderId.Value));
            if (table.Rows.Count == 0) { MessageBox.Show("Заявка не найдена."); Close(); return; }
            DataRow row = table.Rows[0]; cmbClient.SelectedValue = Convert.ToInt32(row["client_id"]); txtLoadingPoint.Text = row["loading_point"].ToString(); txtUnloadingPoint.Text = row["unloading_point"].ToString(); txtCargoName.Text = row["cargo_name"].ToString(); txtWeightKg.Text = Convert.ToDecimal(row["weight_kg"]).ToString(CultureInfo.InvariantCulture); txtVolumeM3.Text = Convert.ToDecimal(row["volume_m3"]).ToString(CultureInfo.InvariantCulture); dtpPlannedDate.Value = Convert.ToDateTime(row["planned_date"]); txtPrice.Text = Convert.ToDecimal(row["price"]).ToString(CultureInfo.InvariantCulture); txtComment.Text = row["comment"].ToString(); ApplyRoleDefaults();
        }
        // Сохраняет заявку через сервисный слой.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedValue == null || string.IsNullOrWhiteSpace(txtLoadingPoint.Text) || string.IsNullOrWhiteSpace(txtUnloadingPoint.Text) || string.IsNullOrWhiteSpace(txtCargoName.Text)) { MessageBox.Show("Заполните клиента, точки маршрута и название груза."); return; }
            if (!decimal.TryParse(txtWeightKg.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal weightKg) || weightKg <= 0) { MessageBox.Show("Некорректный вес груза."); return; }
            if (!decimal.TryParse(txtVolumeM3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal volumeM3) || volumeM3 <= 0) { MessageBox.Show("Некорректный объём груза."); return; }
            if (!decimal.TryParse(txtPrice.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || price < 0) { MessageBox.Show("Некорректная стоимость."); return; }
            try
            {
                if (_orderId.HasValue) OrderService.UpdateOrder(_orderId.Value, Convert.ToInt32(cmbClient.SelectedValue), txtLoadingPoint.Text.Trim(), txtUnloadingPoint.Text.Trim(), txtCargoName.Text.Trim(), weightKg, volumeM3, dtpPlannedDate.Value, price, txtComment.Text.Trim());
                else OrderService.CreateOrder(Convert.ToInt32(cmbClient.SelectedValue), txtLoadingPoint.Text.Trim(), txtUnloadingPoint.Text.Trim(), txtCargoName.Text.Trim(), weightKg, volumeM3, dtpPlannedDate.Value, price, txtComment.Text.Trim());
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при сохранении заявки.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
