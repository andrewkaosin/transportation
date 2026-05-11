using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class OrdersForm : Form
    {
        public OrdersForm() { InitializeComponent(); }
        private void OrdersForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; LoadOrders(); ConfigureAccess(); }
        // Настраивает доступные действия по заявкам в зависимости от роли пользователя.
        private void ConfigureAccess()
        {
            string role = AppSession.CurrentUser != null ? AppSession.CurrentUser.RoleName : string.Empty; bool isAdminOrDispatcher = role == "admin" || role == "dispatcher"; bool isClient = role == "client"; bool isDriver = role == "driver";
            btnAdd.Visible = isAdminOrDispatcher || isClient; btnEdit.Visible = isAdminOrDispatcher || isClient; btnDelete.Visible = isAdminOrDispatcher; btnAssign.Visible = isAdminOrDispatcher; btnCancelOrder.Visible = isAdminOrDispatcher || isClient; btnStart.Visible = isAdminOrDispatcher || isDriver; btnComplete.Visible = isAdminOrDispatcher || isDriver; btnDocuments.Visible = isAdminOrDispatcher;
        }
        // Загружает заявки, при этом для клиента и водителя показывает только свои записи.
        private void LoadOrders()
        {
            string role = AppSession.CurrentUser != null ? AppSession.CurrentUser.RoleName : string.Empty; string whereClause = string.Empty; NpgsqlParameter[] parameters = null;
            if (role == "driver") { int driverId = GetDriverIdForCurrentUser(); whereClause = "where oa.driver_id = @driver_id"; parameters = new[] { new NpgsqlParameter("@driver_id", driverId) }; }
            else if (role == "client") { int clientId = GetClientIdForCurrentUser(); whereClause = "where o.client_id = @client_id"; parameters = new[] { new NpgsqlParameter("@client_id", clientId) }; }
            string query = "select o.id, c.company_name as \"Клиент\", o.loading_point as \"Пункт погрузки\", o.unloading_point as \"Пункт выгрузки\", o.cargo_name as \"Груз\", o.weight_kg as \"Вес, кг\", o.volume_m3 as \"Объем, м3\", o.planned_date as \"Плановая дата\", o.status as \"Статус\", o.price as \"Стоимость\", coalesce(e.full_name, '') as \"Водитель\", coalesce(v.plate_number, '') as \"Транспорт\" from orders o join clients c on c.id = o.client_id left join order_assignments oa on oa.order_id = o.id left join drivers d on d.id = oa.driver_id left join employees e on e.id = d.employee_id left join vehicles v on v.id = oa.vehicle_id " + whereClause + " order by o.id desc;";
            DataTable table = parameters == null ? DbHelper.ExecuteQuery(query) : DbHelper.ExecuteQuery(query, parameters); dgvOrders.DataSource = table; if (dgvOrders.Columns.Contains("id")) dgvOrders.Columns["id"].Visible = false;
        }
        private int GetSelectedOrderId() { return dgvOrders.CurrentRow == null ? -1 : Convert.ToInt32(dgvOrders.CurrentRow.Cells["id"].Value); }
        private string GetSelectedOrderStatus() { return dgvOrders.CurrentRow == null ? string.Empty : Convert.ToString(dgvOrders.CurrentRow.Cells["Статус"].Value); }
        private int GetDriverIdForCurrentUser() { object value = DbHelper.ExecuteScalar(@"select d.id from drivers d join employees e on e.id = d.employee_id where e.user_id = @user_id limit 1;", new NpgsqlParameter("@user_id", AppSession.CurrentUser.Id)); return value == null || value == DBNull.Value ? -1 : Convert.ToInt32(value); }
        private int GetClientIdForCurrentUser() { object value = DbHelper.ExecuteScalar(@"select id from clients where user_id = @user_id limit 1;", new NpgsqlParameter("@user_id", AppSession.CurrentUser.Id)); return value == null || value == DBNull.Value ? -1 : Convert.ToInt32(value); }
        private void btnAdd_Click(object sender, EventArgs e) { using (var form = new OrderEditForm()) { if (form.ShowDialog() == DialogResult.OK) LoadOrders(); } }
        private void btnEdit_Click(object sender, EventArgs e) { int id = GetSelectedOrderId(); if (id == -1) { MessageBox.Show("Выберите заявку."); return; } using (var form = new OrderEditForm(id)) { if (form.ShowDialog() == DialogResult.OK) LoadOrders(); } }
        private void btnDelete_Click(object sender, EventArgs e) { int id = GetSelectedOrderId(); if (id == -1) { MessageBox.Show("Выберите заявку."); return; } if (MessageBox.Show("Удалить выбранную заявку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; try { OrderService.DeleteOrder(id); LoadOrders(); } catch (Exception ex) { MessageBox.Show("Не удалось удалить заявку.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnAssign_Click(object sender, EventArgs e) { int id = GetSelectedOrderId(); if (id == -1) { MessageBox.Show("Выберите заявку."); return; } using (var form = new AssignOrderForm(id)) { if (form.ShowDialog() == DialogResult.OK) LoadOrders(); } }
        private void btnStart_Click(object sender, EventArgs e) { ChangeSelectedOrderStatus("in_progress", "Заявка переведена в работу."); }
        private void btnComplete_Click(object sender, EventArgs e) { ChangeSelectedOrderStatus("completed", "Заявка завершена."); }
        private void btnCancelOrder_Click(object sender, EventArgs e) { ChangeSelectedOrderStatus("cancelled", "Заявка отменена."); }
        // Меняет статус у выбранной заявки и обновляет таблицу.
        private void ChangeSelectedOrderStatus(string newStatus, string comment)
        {
            int id = GetSelectedOrderId(); if (id == -1) { MessageBox.Show("Выберите заявку."); return; } string currentStatus = GetSelectedOrderStatus(); if (currentStatus == "completed" || currentStatus == "cancelled") { MessageBox.Show("У этой заявки уже конечный статус."); return; }
            try { OrderService.ChangeStatus(id, newStatus, comment); LoadOrders(); } catch (Exception ex) { MessageBox.Show("Не удалось изменить статус.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnDocuments_Click(object sender, EventArgs e) { int id = GetSelectedOrderId(); if (id == -1) { MessageBox.Show("Выберите заявку."); return; } using (var form = new DocumentsForm(id)) { form.ShowDialog(); } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadOrders(); }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
