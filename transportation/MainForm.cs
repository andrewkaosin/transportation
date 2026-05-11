using System;
using System.Windows.Forms;

namespace transportation
{
    public partial class MainForm : Form
    {
        private CurrentUser _currentUser;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(CurrentUser currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignModeHelper.IsInDesignMode())
            {
                lblWelcome.Text = "Пользователь: designer";
                lblRole.Text = "Роль: admin";
                return;
            }

            _currentUser = _currentUser ?? AppSession.CurrentUser;
            lblWelcome.Text = "Пользователь: " + (_currentUser != null ? _currentUser.Login : "—");
            lblRole.Text = "Роль: " + (_currentUser != null ? _currentUser.RoleName : "—");
            ConfigureAccess();
        }

        // Показывает только те разделы, которые нужны конкретной роли.
        private void ConfigureAccess()
        {
            btnUsers.Visible = RoleAccess.CanManageUsers();
            btnEmployees.Visible = RoleAccess.CanManageEmployees();
            btnClients.Visible = RoleAccess.CanManageOperationalDirectories();
            btnDrivers.Visible = RoleAccess.CanManageOperationalDirectories();
            btnVehicles.Visible = RoleAccess.CanManageOperationalDirectories();
            btnOrders.Visible = RoleAccess.CanManageOperationalDirectories() || RoleAccess.IsDriver() || RoleAccess.IsClient();
            btnReports.Visible = RoleAccess.CanViewReports();
        }

        private void btnUsers_Click(object sender, EventArgs e) { using (var form = new UsersForm()) { form.ShowDialog(); } }
        private void btnClients_Click(object sender, EventArgs e) { using (var form = new ClientsForm()) { form.ShowDialog(); } }
        private void btnEmployees_Click(object sender, EventArgs e) { using (var form = new EmployeesForm()) { form.ShowDialog(); } }
        private void btnDrivers_Click(object sender, EventArgs e) { using (var form = new DriversForm()) { form.ShowDialog(); } }
        private void btnVehicles_Click(object sender, EventArgs e) { using (var form = new VehiclesForm()) { form.ShowDialog(); } }
        private void btnOrders_Click(object sender, EventArgs e) { using (var form = new OrdersForm()) { form.ShowDialog(); } }
        private void btnReports_Click(object sender, EventArgs e) { using (var form = new ReportsForm()) { form.ShowDialog(); } }
        private void btnLogout_Click(object sender, EventArgs e) { Close(); }
    }
}
