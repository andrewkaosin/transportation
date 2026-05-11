namespace transportation
{
    partial class DriverEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard, pnlAccent, pnlHeader;
        private System.Windows.Forms.Label lblFormIcon, lblFormTitle, lblFormSub;
        private System.Windows.Forms.Label lblEmployee, lblLicenseNumber, lblLicenseCategory, lblStatus;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.TextBox txtLicenseNumber, txtLicenseCategory;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblErrEmployee, lblErrLicense, lblErrCategory;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormIcon = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFormSub = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.lblLicenseCategory = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.txtLicenseCategory = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblErrEmployee = new System.Windows.Forms.Label();
            this.lblErrLicense = new System.Windows.Forms.Label();
            this.lblErrCategory = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Водитель";
            this.Font = UITheme.FontBody;
            this.Load += new System.EventHandler(this.DriverEditForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 4;

            this.pnlCard.BackColor = UITheme.BgCard;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Size = new System.Drawing.Size(496, 420);
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Шапка
            this.pnlHeader.BackColor = UITheme.BgDark;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(496, 70);
            this.pnlHeader.Paint += (s, e) => {
                using (var p = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(p, 0, 69, 496, 69);
            };
            this.lblFormIcon.Text = "🧑‍✈️"; this.lblFormIcon.Font = new System.Drawing.Font("Segoe UI", 20f);
            this.lblFormIcon.AutoSize = true; this.lblFormIcon.Location = new System.Drawing.Point(16, 14); this.lblFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = UITheme.FontBold; this.lblFormTitle.ForeColor = UITheme.TextPrimary;
            this.lblFormTitle.AutoSize = true; this.lblFormTitle.Location = new System.Drawing.Point(58, 16); this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormSub.Font = UITheme.FontSmall; this.lblFormSub.ForeColor = UITheme.TextMuted;
            this.lblFormSub.AutoSize = true; this.lblFormSub.Location = new System.Drawing.Point(60, 38); this.lblFormSub.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblFormIcon);
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Controls.Add(this.lblFormSub);

            int lx = 22;
            System.Action<System.Windows.Forms.Label, string, int, int, bool> mL = (l, t, x, y, r) => { l.Text = r ? t + " *" : t; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.TextSecondary; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };
            System.Action<System.Windows.Forms.TextBox, int, int, int> mT = (t, x, y, w) => { t.Location = new System.Drawing.Point(x, y); t.Size = new System.Drawing.Size(w, 28); UITheme.ApplyTextBox(t); t.Enter += (s, e2) => t.BackColor = UITheme.BgHover; t.Leave += (s, e2) => t.BackColor = UITheme.BgControl; };
            System.Action<System.Windows.Forms.Label, int, int> mE = (l, x, y) => { l.Text = ""; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.StatusCancelled; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };

            mL(lblEmployee, "СОТРУДНИК", lx, 82, true);
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(lx, 100); this.cmbEmployee.Size = new System.Drawing.Size(450, 28);
            UITheme.ApplyComboBox(this.cmbEmployee);
            mE(lblErrEmployee, lx, 130);

            mL(lblLicenseNumber, "НОМЕР ВОДИТЕЛЬСКОГО УДОСТОВЕРЕНИЯ", lx, 148, true);
            mT(txtLicenseNumber, lx, 166, 450);
            mE(lblErrLicense, lx, 196);

            mL(lblLicenseCategory, "КАТЕГОРИЯ (B, C, CE…)", lx, 214, true);
            mT(txtLicenseCategory, lx, 232, 200);
            mE(lblErrCategory, lx, 262);

            mL(lblStatus, "СТАТУС ВОДИТЕЛЯ", lx, 280, false);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(lx, 298); this.cmbStatus.Size = new System.Drawing.Size(200, 28);
            UITheme.ApplyComboBox(this.cmbStatus);

            UITheme.ApplyButtonPrimary(this.btnSave);
            this.btnSave.Text = "Сохранить"; this.btnSave.Location = new System.Drawing.Point(250, 364); this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            UITheme.ApplyButtonGhost(this.btnCancel);
            this.btnCancel.Text = "Отмена"; this.btnCancel.Location = new System.Drawing.Point(378, 364); this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Controls.Add(this.lblEmployee); this.pnlCard.Controls.Add(this.cmbEmployee); this.pnlCard.Controls.Add(this.lblErrEmployee);
            this.pnlCard.Controls.Add(this.lblLicenseNumber); this.pnlCard.Controls.Add(this.txtLicenseNumber); this.pnlCard.Controls.Add(this.lblErrLicense);
            this.pnlCard.Controls.Add(this.lblLicenseCategory); this.pnlCard.Controls.Add(this.txtLicenseCategory); this.pnlCard.Controls.Add(this.lblErrCategory);
            this.pnlCard.Controls.Add(this.lblStatus); this.pnlCard.Controls.Add(this.cmbStatus);
            this.pnlCard.Controls.Add(this.btnSave); this.pnlCard.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlCard); this.Controls.Add(this.pnlAccent);
            this.ResumeLayout(false);
        }
    }
}