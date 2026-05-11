using System;
using Npgsql;

namespace transportation
{
    public static class OrderService
    {

        public static void CreateOrder(int clientId, string loadingPoint, string unloadingPoint, string cargoName, decimal weightKg, decimal volumeM3, DateTime plannedDate, decimal price, string comment)
        {
            using (var connection = DbHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertOrder = @"insert into orders (client_id, loading_point, unloading_point, cargo_name, weight_kg, volume_m3, planned_date, status, price, comment) values (@client_id, @loading_point, @unloading_point, @cargo_name, @weight_kg, @volume_m3, @planned_date, 'new', @price, @comment) returning id;";
                        int orderId;
                        using (var cmd = new NpgsqlCommand(insertOrder, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@client_id", clientId); cmd.Parameters.AddWithValue("@loading_point", loadingPoint); cmd.Parameters.AddWithValue("@unloading_point", unloadingPoint); cmd.Parameters.AddWithValue("@cargo_name", cargoName); cmd.Parameters.AddWithValue("@weight_kg", weightKg); cmd.Parameters.AddWithValue("@volume_m3", volumeM3); cmd.Parameters.AddWithValue("@planned_date", plannedDate.Date); cmd.Parameters.AddWithValue("@price", price); cmd.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(comment) ? (object)DBNull.Value : comment); orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        InsertHistory(connection, transaction, orderId, null, "new", "Заявка создана."); transaction.Commit();
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
        }

        public static void UpdateOrder(int orderId, int clientId, string loadingPoint, string unloadingPoint, string cargoName, decimal weightKg, decimal volumeM3, DateTime plannedDate, decimal price, string comment)
        {
            DbHelper.ExecuteNonQuery(@"update orders set client_id = @client_id, loading_point = @loading_point, unloading_point = @unloading_point, cargo_name = @cargo_name, weight_kg = @weight_kg, volume_m3 = @volume_m3, planned_date = @planned_date, price = @price, comment = @comment where id = @id;", new NpgsqlParameter("@client_id", clientId), new NpgsqlParameter("@loading_point", loadingPoint), new NpgsqlParameter("@unloading_point", unloadingPoint), new NpgsqlParameter("@cargo_name", cargoName), new NpgsqlParameter("@weight_kg", weightKg), new NpgsqlParameter("@volume_m3", volumeM3), new NpgsqlParameter("@planned_date", plannedDate.Date), new NpgsqlParameter("@price", price), new NpgsqlParameter("@comment", string.IsNullOrWhiteSpace(comment) ? (object)DBNull.Value : comment), new NpgsqlParameter("@id", orderId));
        }

        public static void DeleteOrder(int orderId)
        {
            using (var connection = DbHelper.GetConnection())
            {
                connection.Open(); using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string status; using (var cmd = new NpgsqlCommand("select status from orders where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", orderId); status = Convert.ToString(cmd.ExecuteScalar()); }
                        if (status == "in_progress" || status == "completed") throw new Exception("Нельзя удалить заявку, которая уже в работе или завершена.");
                        ReleaseResourcesIfAssigned(connection, transaction, orderId);
                        using (var cmd = new NpgsqlCommand("delete from orders where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", orderId); cmd.ExecuteNonQuery(); }
                        transaction.Commit();
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
        }

        public static void AssignOrder(int orderId, int driverId, int vehicleId)
        {
            using (var connection = DbHelper.GetConnection())
            {
                connection.Open(); using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string currentStatus = GetOrderStatus(connection, transaction, orderId);
                        if (currentStatus == "completed" || currentStatus == "cancelled") throw new Exception("Нельзя назначить ресурсы на завершённую или отменённую заявку.");
                        using (var deleteCmd = new NpgsqlCommand("delete from order_assignments where order_id = @order_id;", connection, transaction)) { deleteCmd.Parameters.AddWithValue("@order_id", orderId); deleteCmd.ExecuteNonQuery(); }
                        using (var insertCmd = new NpgsqlCommand("insert into order_assignments (order_id, driver_id, vehicle_id, assigned_at) values (@order_id, @driver_id, @vehicle_id, now());", connection, transaction)) { insertCmd.Parameters.AddWithValue("@order_id", orderId); insertCmd.Parameters.AddWithValue("@driver_id", driverId); insertCmd.Parameters.AddWithValue("@vehicle_id", vehicleId); insertCmd.ExecuteNonQuery(); }
                        using (var driverCmd = new NpgsqlCommand("update drivers set driver_status = 'busy' where id = @id;", connection, transaction)) { driverCmd.Parameters.AddWithValue("@id", driverId); driverCmd.ExecuteNonQuery(); }
                        using (var vehicleCmd = new NpgsqlCommand("update vehicles set work_status = 'busy' where id = @id;", connection, transaction)) { vehicleCmd.Parameters.AddWithValue("@id", vehicleId); vehicleCmd.ExecuteNonQuery(); }
                        using (var orderCmd = new NpgsqlCommand("update orders set status = 'assigned' where id = @id;", connection, transaction)) { orderCmd.Parameters.AddWithValue("@id", orderId); orderCmd.ExecuteNonQuery(); }
                        InsertHistory(connection, transaction, orderId, currentStatus, "assigned", "Назначены водитель и транспорт."); transaction.Commit();
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
        }

        public static void ChangeStatus(int orderId, string newStatus, string comment)
        {
            using (var connection = DbHelper.GetConnection())
            {
                connection.Open(); using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string oldStatus = GetOrderStatus(connection, transaction, orderId);
                        using (var orderCmd = new NpgsqlCommand("update orders set status = @status where id = @id;", connection, transaction)) { orderCmd.Parameters.AddWithValue("@status", newStatus); orderCmd.Parameters.AddWithValue("@id", orderId); orderCmd.ExecuteNonQuery(); }
                        if (newStatus == "completed") { ReleaseResourcesIfAssigned(connection, transaction, orderId); EnsureDocuments(connection, transaction, orderId); } else if (newStatus == "cancelled") { ReleaseResourcesIfAssigned(connection, transaction, orderId); } else if (newStatus == "assigned") { OccupyResources(connection, transaction, orderId); }
                        InsertHistory(connection, transaction, orderId, oldStatus, newStatus, comment); transaction.Commit();
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
        }

        public static void GenerateDocuments(int orderId)
        {
            using (var connection = DbHelper.GetConnection())
            {
                connection.Open(); using (var transaction = connection.BeginTransaction()) { try { EnsureDocuments(connection, transaction, orderId); transaction.Commit(); } catch { transaction.Rollback(); throw; } }
            }
        }

        private static string GetOrderStatus(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId) { using (var cmd = new NpgsqlCommand("select status from orders where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", orderId); return Convert.ToString(cmd.ExecuteScalar()); } }
        private static void InsertHistory(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId, string oldStatus, string newStatus, string comment) { using (var cmd = new NpgsqlCommand(@"insert into order_status_history (order_id, old_status, new_status, changed_by_user_id, comment) values (@order_id, @old_status, @new_status, @changed_by_user_id, @comment);", connection, transaction)) { cmd.Parameters.AddWithValue("@order_id", orderId); cmd.Parameters.AddWithValue("@old_status", string.IsNullOrWhiteSpace(oldStatus) ? (object)DBNull.Value : oldStatus); cmd.Parameters.AddWithValue("@new_status", newStatus); cmd.Parameters.AddWithValue("@changed_by_user_id", AppSession.CurrentUser != null ? (object)AppSession.CurrentUser.Id : DBNull.Value); cmd.Parameters.AddWithValue("@comment", string.IsNullOrWhiteSpace(comment) ? (object)DBNull.Value : comment); cmd.ExecuteNonQuery(); } }
        private static void ReleaseResourcesIfAssigned(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId) { int? driverId = null; int? vehicleId = null; using (var cmd = new NpgsqlCommand("select driver_id, vehicle_id from order_assignments where order_id = @order_id limit 1;", connection, transaction)) { cmd.Parameters.AddWithValue("@order_id", orderId); using (var reader = cmd.ExecuteReader()) { if (reader.Read()) { driverId = reader.GetInt32(0); vehicleId = reader.GetInt32(1); } } } if (driverId.HasValue) using (var cmd = new NpgsqlCommand("update drivers set driver_status = 'free' where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", driverId.Value); cmd.ExecuteNonQuery(); } if (vehicleId.HasValue) using (var cmd = new NpgsqlCommand("update vehicles set work_status = 'free' where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", vehicleId.Value); cmd.ExecuteNonQuery(); } }
        private static void OccupyResources(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId) { int? driverId = null; int? vehicleId = null; using (var cmd = new NpgsqlCommand("select driver_id, vehicle_id from order_assignments where order_id = @order_id limit 1;", connection, transaction)) { cmd.Parameters.AddWithValue("@order_id", orderId); using (var reader = cmd.ExecuteReader()) { if (reader.Read()) { driverId = reader.GetInt32(0); vehicleId = reader.GetInt32(1); } } } if (driverId.HasValue) using (var cmd = new NpgsqlCommand("update drivers set driver_status = 'busy' where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", driverId.Value); cmd.ExecuteNonQuery(); } if (vehicleId.HasValue) using (var cmd = new NpgsqlCommand("update vehicles set work_status = 'busy' where id = @id;", connection, transaction)) { cmd.Parameters.AddWithValue("@id", vehicleId.Value); cmd.ExecuteNonQuery(); } }
        private static void EnsureDocuments(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId) { decimal amount = 0m; using (var amountCmd = new NpgsqlCommand("select coalesce(price, 0) from orders where id = @id;", connection, transaction)) { amountCmd.Parameters.AddWithValue("@id", orderId); amount = Convert.ToDecimal(amountCmd.ExecuteScalar()); } EnsureDocument(connection, transaction, orderId, "waybill", "ТН", amount); EnsureDocument(connection, transaction, orderId, "invoice", "СЧ", amount); EnsureDocument(connection, transaction, orderId, "act", "АКТ", amount); }
        private static void EnsureDocument(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId, string docType, string prefix, decimal amount) { using (var existsCmd = new NpgsqlCommand("select count(*) from documents where order_id = @order_id and doc_type = @doc_type;", connection, transaction)) { existsCmd.Parameters.AddWithValue("@order_id", orderId); existsCmd.Parameters.AddWithValue("@doc_type", docType); if (Convert.ToInt32(existsCmd.ExecuteScalar()) > 0) return; } string docNumber = string.Format("{0}-{1:0000}", prefix, orderId); using (var insertCmd = new NpgsqlCommand("insert into documents (order_id, doc_type, doc_number, amount, created_at, payment_status) values (@order_id, @doc_type, @doc_number, @amount, now(), 'unpaid');", connection, transaction)) { insertCmd.Parameters.AddWithValue("@order_id", orderId); insertCmd.Parameters.AddWithValue("@doc_type", docType); insertCmd.Parameters.AddWithValue("@doc_number", docNumber); insertCmd.Parameters.AddWithValue("@amount", amount); insertCmd.ExecuteNonQuery(); } }
    }
}
