namespace transportation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Те же имена контролов — MainForm.cs работает без изменений!
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.GroupBox groupBox1;   // оставляем для совместимости (скрыт)
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;

        // Новые элементы оформления
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlAccentBar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppSub;
        private System.Windows.Forms.Label lblSectionOps;
        private System.Windows.Forms.Label lblSectionAdmin;
        private System.Windows.Forms.Label lblSectionSystem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlAccentBar = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();

            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.lblSectionOps = new System.Windows.Forms.Label();
            this.lblSectionAdmin = new System.Windows.Forms.Label();
            this.lblSectionSystem = new System.Windows.Forms.Label();

            this.btnUsers = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnVehicles = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();


            this.SuspendLayout();


            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.MinimumSize = new System.Drawing.Size(860, 560);
            this.Font = UITheme.FontBody;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransFlow — Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);


            this.pnlAccentBar.BackColor = UITheme.Accent;
            this.pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccentBar.Width = 0;

   
            this.pnlSidebar.BackColor = UITheme.BgCard;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlSidebar.Anchor = (System.Windows.Forms.AnchorStyles.Top
                                       | System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left);
            this.pnlSidebar.Height = 560;

            this.lblAppName.Text = "TransFlow";
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = UITheme.TextPrimary;
            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(20, 24);
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;

            this.lblAppSub.Text = "Управление грузоперевозками";
            this.lblAppSub.Font = UITheme.FontSmall;
            this.lblAppSub.ForeColor = UITheme.TextMuted;
            this.lblAppSub.AutoSize = true;
            this.lblAppSub.Location = new System.Drawing.Point(22, 54);
            this.lblAppSub.BackColor = System.Drawing.Color.Transparent;

            this.pnlSidebar.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                {
                    e.Graphics.DrawLine(pen, 0, 82, 220, 82);
                    e.Graphics.DrawLine(pen, 220, 0, 220, pnlSidebar.Height);
                }
            };

            this.lblSectionOps.Text = "ОПЕРАЦИИ";
            this.lblSectionOps.Font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lblSectionOps.ForeColor = UITheme.TextMuted;
            this.lblSectionOps.AutoSize = true;
            this.lblSectionOps.Location = new System.Drawing.Point(20, 98);
            this.lblSectionOps.BackColor = System.Drawing.Color.Transparent;


            SetupNavButton(this.btnOrders, "📦  Заявки", new System.Drawing.Point(8, 118));
            SetupNavButton(this.btnDrivers, "🧑‍✈️  Водители", new System.Drawing.Point(8, 158));
            SetupNavButton(this.btnVehicles, "🚛  Транспорт", new System.Drawing.Point(8, 198));
            SetupNavButton(this.btnClients, "🏢  Клиенты", new System.Drawing.Point(8, 238));

            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            this.btnVehicles.Click += new System.EventHandler(this.btnVehicles_Click);
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);

            this.lblSectionAdmin.Text = "УПРАВЛЕНИЕ";
            this.lblSectionAdmin.Font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lblSectionAdmin.ForeColor = UITheme.TextMuted;
            this.lblSectionAdmin.AutoSize = true;
            this.lblSectionAdmin.Location = new System.Drawing.Point(20, 290);
            this.lblSectionAdmin.BackColor = System.Drawing.Color.Transparent;

            SetupNavButton(this.btnEmployees, "👥  Сотрудники", new System.Drawing.Point(8, 308));
            SetupNavButton(this.btnUsers, "🔐  Пользователи", new System.Drawing.Point(8, 348));
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);


            this.lblSectionSystem.Text = "АНАЛИТИКА";
            this.lblSectionSystem.Font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            this.lblSectionSystem.ForeColor = UITheme.TextMuted;
            this.lblSectionSystem.AutoSize = true;
            this.lblSectionSystem.Location = new System.Drawing.Point(20, 400);
            this.lblSectionSystem.BackColor = System.Drawing.Color.Transparent;

            SetupNavButton(this.btnReports, "📊  Отчёты", new System.Drawing.Point(8, 418));
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);


            this.btnLogout.Text = "Выйти";
            this.btnLogout.Size = new System.Drawing.Size(204, 36);
            this.btnLogout.Location = new System.Drawing.Point(8, 505);
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            UITheme.ApplyButtonDanger(this.btnLogout);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

        
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.lblAppSub);
            this.pnlSidebar.Controls.Add(this.lblSectionOps);
            this.pnlSidebar.Controls.Add(this.btnOrders);
            this.pnlSidebar.Controls.Add(this.btnDrivers);
            this.pnlSidebar.Controls.Add(this.btnVehicles);
            this.pnlSidebar.Controls.Add(this.btnClients);
            this.pnlSidebar.Controls.Add(this.lblSectionAdmin);
            this.pnlSidebar.Controls.Add(this.btnEmployees);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.lblSectionSystem);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnLogout);


            this.pnlHeader.BackColor = UITheme.BgCard;
            this.pnlHeader.Location = new System.Drawing.Point(223, 0);
            this.pnlHeader.Size = new System.Drawing.Size(637, 64);
            this.pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.pnlHeader.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 63, pnlHeader.Width, 63);
            };


            this.lblWelcome.Text = "Пользователь: —";
            this.lblWelcome.Font = UITheme.FontBold;
            this.lblWelcome.ForeColor = UITheme.TextPrimary;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(24, 16);
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;


            this.lblRole.Text = "Роль: —";
            this.lblRole.Font = UITheme.FontSmall;
            this.lblRole.ForeColor = UITheme.Accent;
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(26, 38);
            this.lblRole.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblRole);


            this.groupBox1.Visible = false;
            this.groupBox1.Size = new System.Drawing.Size(1, 1);

            this.Controls.Add(this.pnlAccentBar);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.groupBox1);   

            this.ResumeLayout(false);
            this.PerformLayout();
        }

      
        private void SetupNavButton(System.Windows.Forms.Button btn, string text, System.Drawing.Point loc)
        {
            btn.Text = text;
            btn.Location = loc;
            btn.Size = new System.Drawing.Size(204, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = UITheme.TextSecondary;
            btn.Font = UITheme.FontBody;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = UITheme.BgHover;
            btn.FlatAppearance.MouseDownBackColor = UITheme.AccentLight;

            btn.MouseEnter += (s, e) => btn.ForeColor = UITheme.TextPrimary;
            btn.MouseLeave += (s, e) => btn.ForeColor = UITheme.TextSecondary;
        }
    }
}

