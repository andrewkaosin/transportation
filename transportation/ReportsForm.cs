using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace transportation
{
    public partial class ReportsForm : Form
    {
        public ReportsForm() { InitializeComponent(); }
        private void ReportsForm_Load(object sender, EventArgs e) { if (DesignModeHelper.IsInDesignMode()) return; if (!RoleAccess.CanViewReports()) { MessageBox.Show("У вас нет доступа к отчётам."); Close(); return; } cmbReportType.Items.Clear(); cmbReportType.Items.AddRange(new object[] { "Заказы по статусам", "Работа водителей", "Использование транспорта", "Выручка по клиентам" }); cmbReportType.SelectedIndex = 0; dtpFrom.Value = DateTime.Today.AddMonths(-1); dtpTo.Value = DateTime.Today; }
        // Строит выбранный отчёт за указанный период и показывает его в таблице.
        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                string reportType = cmbReportType.Text; DataTable table;
                if (reportType == "Работа водителей") table = DbHelper.ExecuteQuery("select e.full_name as \"Водитель\", count(o.id) as \"Количество заявок\", coalesce(sum(case when o.status = 'completed' then o.price else 0 end), 0) as \"Выручка\" from drivers d join employees e on e.id = d.employee_id left join order_assignments oa on oa.driver_id = d.id left join orders o on o.id = oa.order_id and o.planned_date between @date_from and @date_to group by e.full_name order by e.full_name;", new NpgsqlParameter("@date_from", dtpFrom.Value.Date), new NpgsqlParameter("@date_to", dtpTo.Value.Date));
                else if (reportType == "Использование транспорта") table = DbHelper.ExecuteQuery("select v.plate_number as \"Госномер\", v.brand || ' ' || v.model as \"Транспорт\", count(o.id) as \"Количество заявок\" from vehicles v left join order_assignments oa on oa.vehicle_id = v.id left join orders o on o.id = oa.order_id and o.planned_date between @date_from and @date_to group by v.plate_number, v.brand, v.model order by v.plate_number;", new NpgsqlParameter("@date_from", dtpFrom.Value.Date), new NpgsqlParameter("@date_to", dtpTo.Value.Date));
                else if (reportType == "Выручка по клиентам") table = DbHelper.ExecuteQuery("select c.company_name as \"Клиент\", count(o.id) as \"Количество заявок\", coalesce(sum(case when o.status = 'completed' then o.price else 0 end), 0) as \"Выручка\" from clients c left join orders o on o.client_id = c.id and o.planned_date between @date_from and @date_to group by c.company_name order by c.company_name;", new NpgsqlParameter("@date_from", dtpFrom.Value.Date), new NpgsqlParameter("@date_to", dtpTo.Value.Date));
                else table = DbHelper.ExecuteQuery("select status as \"Статус\", count(*) as \"Количество\", coalesce(sum(price), 0) as \"Сумма\" from orders where planned_date between @date_from and @date_to group by status order by status;", new NpgsqlParameter("@date_from", dtpFrom.Value.Date), new NpgsqlParameter("@date_to", dtpTo.Value.Date));
                dgvReport.DataSource = table;
            }
            catch (Exception ex) { MessageBox.Show("Не удалось построить отчёт.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
    }
}
