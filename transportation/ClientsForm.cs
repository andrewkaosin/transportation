using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class ClientsForm : Form
    {
        public ClientsForm() { InitializeComponent(); }
        private void ClientsForm_Load(object sender, EventArgs e) { if (!DesignModeHelper.IsInDesignMode()) LoadClients(); }
        // Загружает список клиентов в таблицу.
        private void LoadClients()
        {
            string query = "select id, company_name as \"Название\", coalesce(inn, '') as \"ИНН\", coalesce(contact_person, '') as \"Контактное лицо\", coalesce(phone, '') as \"Телефон\", coalesce(email, '') as \"Email\", coalesce(address, '') as \"Адрес\" from clients order by id;";
            DataTable table = DbHelper.ExecuteQuery(query); dgvClients.DataSource = table; if (dgvClients.Columns.Contains("id")) dgvClients.Columns["id"].Visible = false;
        }
        private int GetSelectedClientId() { return dgvClients.CurrentRow == null ? -1 : Convert.ToInt32(dgvClients.CurrentRow.Cells["id"].Value); }
        private void btnAdd_Click(object sender, EventArgs e) { using (var form = new ClientEditForm()) { if (form.ShowDialog() == DialogResult.OK) LoadClients(); } }
        private void btnEdit_Click(object sender, EventArgs e) { int clientId = GetSelectedClientId(); if (clientId == -1) { MessageBox.Show("Выберите клиента."); return; } using (var form = new ClientEditForm(clientId)) { if (form.ShowDialog() == DialogResult.OK) LoadClients(); } }
        private void btnDelete_Click(object sender, EventArgs e) { int clientId = GetSelectedClientId(); if (clientId == -1) { MessageBox.Show("Выберите клиента."); return; } if (MessageBox.Show("Удалить выбранного клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; try { DbHelper.ExecuteNonQuery("delete from clients where id = @id;", new NpgsqlParameter("@id", clientId)); LoadClients(); } catch (Exception ex) { MessageBox.Show("Не удалось удалить клиента.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadClients(); }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
