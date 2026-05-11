using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class DocumentsForm : Form
    {
        private readonly int _orderId; public DocumentsForm() { InitializeComponent(); } public DocumentsForm(int orderId) : this() { _orderId = orderId; }
        private void DocumentsForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; Text = "Документы по заявке №" + _orderId; LoadDocuments(); }
        // Загружает документы, которые уже созданы для выбранной заявки.
        private void LoadDocuments() { DataTable table = DbHelper.ExecuteQuery("select id, doc_type as \"Тип\", doc_number as \"Номер\", amount as \"Сумма\", created_at as \"Создан\", payment_status as \"Оплата\" from documents where order_id = @order_id order by id;", new NpgsqlParameter("@order_id", _orderId)); dgvDocuments.DataSource = table; if (dgvDocuments.Columns.Contains("id")) dgvDocuments.Columns["id"].Visible = false; }
        private void btnGenerate_Click(object sender, EventArgs e) { try { OrderService.GenerateDocuments(_orderId); LoadDocuments(); } catch (Exception ex) { MessageBox.Show("Не удалось сгенерировать документы.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        // Помечает все документы заявки как оплаченные.
        private void btnMarkPaid_Click(object sender, EventArgs e) { try { DbHelper.ExecuteNonQuery("update documents set payment_status = 'paid' where order_id = @order_id;", new NpgsqlParameter("@order_id", _orderId)); LoadDocuments(); } catch (Exception ex) { MessageBox.Show("Не удалось обновить оплату.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
