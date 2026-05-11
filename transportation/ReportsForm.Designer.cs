namespace transportation
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblReportType, lblFrom, lblTo;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DateTimePicker dtpFrom, dtpTo;
        private System.Windows.Forms.Button btnBuild, btnClose;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Panel pnlAccent, pnlTopBar, pnlFilter, pnlToolbar;
        private System.Windows.Forms.Label lblFormTitle;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Font = UITheme.FontBody;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёты";
            this.Load += new System.EventHandler(this.ReportsForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 3;

 
            this.pnlTopBar.BackColor = UITheme.BgCard;
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 52;
            this.pnlTopBar.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 51, pnlTopBar.Width, 51);
            };
            this.lblFormTitle.Text = "📊  Аналитические отчёты";
            this.lblFormTitle.Font = UITheme.FontBold;
            this.lblFormTitle.ForeColor = UITheme.TextPrimary;
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(16, 17);
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.Controls.Add(this.lblFormTitle);

 
            this.pnlFilter.BackColor = UITheme.BgCard;
            this.pnlFilter.Location = new System.Drawing.Point(3, 52);
            this.pnlFilter.Size = new System.Drawing.Size(937, 64);
            this.pnlFilter.Anchor = System.Windows.Forms.AnchorStyles.Top
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.pnlFilter.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 63, pnlFilter.Width, 63);
            };

            this.lblReportType.Text = "ТИП ОТЧЁТА";
            this.lblReportType.Font = UITheme.FontSmall;
            this.lblReportType.ForeColor = UITheme.TextSecondary;
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(16, 10);
            this.lblReportType.BackColor = System.Drawing.Color.Transparent;

            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Location = new System.Drawing.Point(16, 28);
            this.cmbReportType.Size = new System.Drawing.Size(260, 24);
            UITheme.ApplyComboBox(this.cmbReportType);


            this.lblFrom.Text = "С";
            this.lblFrom.Font = UITheme.FontSmall;
            this.lblFrom.ForeColor = UITheme.TextSecondary;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(296, 10);
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;

            this.dtpFrom.Location = new System.Drawing.Point(296, 28);
            this.dtpFrom.Size = new System.Drawing.Size(160, 24);
            UITheme.ApplyDatePicker(this.dtpFrom);


            this.lblTo.Text = "ПО";
            this.lblTo.Font = UITheme.FontSmall;
            this.lblTo.ForeColor = UITheme.TextSecondary;
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(470, 10);
            this.lblTo.BackColor = System.Drawing.Color.Transparent;

            this.dtpTo.Location = new System.Drawing.Point(470, 28);
            this.dtpTo.Size = new System.Drawing.Size(160, 24);
            UITheme.ApplyDatePicker(this.dtpTo);

            this.btnBuild.Text = "▶ Построить";
            this.btnBuild.Location = new System.Drawing.Point(648, 20);
            this.btnBuild.Size = new System.Drawing.Size(130, 34);
            UITheme.ApplyButtonPrimary(this.btnBuild);
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblReportType, this.cmbReportType, this.lblFrom, this.dtpFrom,
                this.lblTo, this.dtpTo, this.btnBuild
            });

            this.dgvReport.Anchor =  FormBuilder.AllAnchors();
            this.dgvReport.Location = new System.Drawing.Point(0, 116);
            this.dgvReport.Size = new System.Drawing.Size(937, 446);
            UITheme.ApplyGrid(this.dgvReport);

       
            this.pnlToolbar.BackColor = UITheme.BgCard;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolbar.Height = 58;
            this.pnlToolbar.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 0, pnlToolbar.Width, 0);
            };
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(810, 12);
            this.btnClose.Size = new System.Drawing.Size(110, 34);
            UITheme.ApplyButtonGhost(this.btnClose);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.pnlToolbar.Controls.Add(this.btnClose);

            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlAccent);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
