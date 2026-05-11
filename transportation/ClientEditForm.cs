using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class ClientEditForm : Form
    {
        private readonly int? _clientId;
        public ClientEditForm() { InitializeComponent(); }
        public ClientEditForm(int clientId) : this() { _clientId = clientId; }
        private void ClientEditForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; Text = _clientId.HasValue ? "Редактирование клиента" : "Добавление клиента"; if (_clientId.HasValue) LoadClientData(); }
        // Загружает данные клиента в поля формы, когда открыто редактирование.
        private void LoadClientData()
        {
            DataTable table = DbHelper.ExecuteQuery(@"select company_name, inn, contact_person, phone, email, address from clients where id = @id;", new NpgsqlParameter("@id", _clientId.Value));
            if (table.Rows.Count == 0) { MessageBox.Show("Клиент не найден."); Close(); return; }
            DataRow row = table.Rows[0]; txtCompanyName.Text = row["company_name"].ToString(); txtInn.Text = row["inn"].ToString(); txtContactPerson.Text = row["contact_person"].ToString(); txtPhone.Text = row["phone"].ToString(); txtEmail.Text = row["email"].ToString(); txtAddress.Text = row["address"].ToString();
        }
        // Сохраняет клиента после проверки обязательных полей.
        private void btnSave_Click(object sender, EventArgs e)
        {
            string companyName = txtCompanyName.Text.Trim(); if (string.IsNullOrWhiteSpace(companyName)) { MessageBox.Show("Введите название клиента."); return; }
            try
            {
                if (_clientId.HasValue)
                    DbHelper.ExecuteNonQuery(@"update clients set company_name = @company_name, inn = @inn, contact_person = @contact_person, phone = @phone, email = @email, address = @address where id = @id;", new NpgsqlParameter("@company_name", companyName), new NpgsqlParameter("@inn", EmptyToDbNull(txtInn.Text)), new NpgsqlParameter("@contact_person", EmptyToDbNull(txtContactPerson.Text)), new NpgsqlParameter("@phone", EmptyToDbNull(txtPhone.Text)), new NpgsqlParameter("@email", EmptyToDbNull(txtEmail.Text)), new NpgsqlParameter("@address", EmptyToDbNull(txtAddress.Text)), new NpgsqlParameter("@id", _clientId.Value));
                else
                    DbHelper.ExecuteNonQuery(@"insert into clients (company_name, inn, contact_person, phone, email, address) values (@company_name, @inn, @contact_person, @phone, @email, @address);", new NpgsqlParameter("@company_name", companyName), new NpgsqlParameter("@inn", EmptyToDbNull(txtInn.Text)), new NpgsqlParameter("@contact_person", EmptyToDbNull(txtContactPerson.Text)), new NpgsqlParameter("@phone", EmptyToDbNull(txtPhone.Text)), new NpgsqlParameter("@email", EmptyToDbNull(txtEmail.Text)), new NpgsqlParameter("@address", EmptyToDbNull(txtAddress.Text)));
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка при сохранении клиента.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private object EmptyToDbNull(string value) { return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim(); }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
    }
}
