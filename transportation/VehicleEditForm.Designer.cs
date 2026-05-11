namespace transportation
{
    partial class VehicleEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard, pnlAccent, pnlHeader;
        private System.Windows.Forms.Label lblFormIcon, lblFormTitle, lblFormSub;
        private System.Windows.Forms.Label lblPlateNumber, lblBrand, lblModel, lblCapacityKg, lblVolumeM3, lblTechnicalStatus, lblWorkStatus;
        private System.Windows.Forms.TextBox txtPlateNumber, txtBrand, txtModel, txtCapacityKg, txtVolumeM3;
        private System.Windows.Forms.ComboBox cmbTechnicalStatus, cmbWorkStatus;
        private System.Windows.Forms.Label lblErrPlate, lblErrBrand, lblErrCapacity, lblErrVolume;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel(); this.pnlAccent = new System.Windows.Forms.Panel(); this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormIcon = new System.Windows.Forms.Label(); this.lblFormTitle = new System.Windows.Forms.Label(); this.lblFormSub = new System.Windows.Forms.Label();
            this.lblPlateNumber = new System.Windows.Forms.Label(); this.lblBrand = new System.Windows.Forms.Label(); this.lblModel = new System.Windows.Forms.Label();
            this.lblCapacityKg = new System.Windows.Forms.Label(); this.lblVolumeM3 = new System.Windows.Forms.Label();
            this.lblTechnicalStatus = new System.Windows.Forms.Label(); this.lblWorkStatus = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox(); this.txtBrand = new System.Windows.Forms.TextBox(); this.txtModel = new System.Windows.Forms.TextBox();
            this.txtCapacityKg = new System.Windows.Forms.TextBox(); this.txtVolumeM3 = new System.Windows.Forms.TextBox();
            this.cmbTechnicalStatus = new System.Windows.Forms.ComboBox(); this.cmbWorkStatus = new System.Windows.Forms.ComboBox();
            this.lblErrPlate = new System.Windows.Forms.Label(); this.lblErrBrand = new System.Windows.Forms.Label();
            this.lblErrCapacity = new System.Windows.Forms.Label(); this.lblErrVolume = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button(); this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark; this.ClientSize = new System.Drawing.Size(500, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Транспортное средство"; this.Font = UITheme.FontBody;
            this.Load += new System.EventHandler(this.VehicleEditForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent; this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left; this.pnlAccent.Width = 0;
            this.pnlCard.BackColor = UITheme.BgCard; this.pnlCard.Location = new System.Drawing.Point(4, 0); this.pnlCard.Size = new System.Drawing.Size(496, 520);
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlHeader.BackColor = UITheme.BgDark; this.pnlHeader.Location = new System.Drawing.Point(0, 0); this.pnlHeader.Size = new System.Drawing.Size(496, 70);
            this.pnlHeader.Paint += (s, e) => { using (var p = new System.Drawing.Pen(UITheme.BorderColor)) e.Graphics.DrawLine(p, 0, 69, 496, 69); };
            this.lblFormIcon.Text = "🚛"; this.lblFormIcon.Font = new System.Drawing.Font("Segoe UI", 20f); this.lblFormIcon.AutoSize = true; this.lblFormIcon.Location = new System.Drawing.Point(16, 14); this.lblFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = UITheme.FontBold; this.lblFormTitle.ForeColor = UITheme.TextPrimary; this.lblFormTitle.AutoSize = true; this.lblFormTitle.Location = new System.Drawing.Point(58, 16); this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormSub.Font = UITheme.FontSmall; this.lblFormSub.ForeColor = UITheme.TextMuted; this.lblFormSub.AutoSize = true; this.lblFormSub.Location = new System.Drawing.Point(60, 38); this.lblFormSub.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblFormIcon); this.pnlHeader.Controls.Add(this.lblFormTitle); this.pnlHeader.Controls.Add(this.lblFormSub);

            System.Action<System.Windows.Forms.Label, string, int, int, bool> mL = (l, t, x, y, r) => { l.Text = r ? t + " *" : t; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.TextSecondary; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };
            System.Action<System.Windows.Forms.TextBox, int, int, int> mT = (t, x, y, w) => { t.Location = new System.Drawing.Point(x, y); t.Size = new System.Drawing.Size(w, 28); UITheme.ApplyTextBox(t); t.Enter += (s, e2) => t.BackColor = UITheme.BgHover; t.Leave += (s, e2) => t.BackColor = UITheme.BgControl; };
            System.Action<System.Windows.Forms.Label, int, int> mE = (l, x, y) => { l.Text = ""; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.StatusCancelled; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };

            int lx = 22;
      
            mL(lblPlateNumber, "ГОСУДАРСТВЕННЫЙ НОМЕР", lx, 82, true); mT(txtPlateNumber, lx, 100, 220); mE(lblErrPlate, lx, 130);
   
            mL(lblBrand, "МАРКА", lx, 148, true); mT(txtBrand, lx, 166, 200); mE(lblErrBrand, lx, 196);
            mL(lblModel, "МОДЕЛЬ", 240, 148, false); mT(txtModel, 240, 166, 232);

            mL(lblCapacityKg, "ГРУЗОПОДЪЁМНОСТЬ, КГ", lx, 214, true); mT(txtCapacityKg, lx, 232, 200); mE(lblErrCapacity, lx, 262);

            mL(lblVolumeM3, "ОБЪЁМ КУЗОВА, М³", 240, 214, true); mT(txtVolumeM3, 240, 232, 232); mE(lblErrVolume, 240, 262);
       
            mL(lblTechnicalStatus, "ТЕХНИЧЕСКИЙ СТАТУС", lx, 280, false);
            this.cmbTechnicalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnicalStatus.Location = new System.Drawing.Point(lx, 298); this.cmbTechnicalStatus.Size = new System.Drawing.Size(200, 28); UITheme.ApplyComboBox(this.cmbTechnicalStatus);
         
            mL(lblWorkStatus, "РАБОЧИЙ СТАТУС", 240, 280, false);
            this.cmbWorkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkStatus.Location = new System.Drawing.Point(240, 298); this.cmbWorkStatus.Size = new System.Drawing.Size(232, 28); UITheme.ApplyComboBox(this.cmbWorkStatus);

            UITheme.ApplyButtonPrimary(this.btnSave); this.btnSave.Text = "Сохранить"; this.btnSave.Location = new System.Drawing.Point(252, 464); this.btnSave.Size = new System.Drawing.Size(120, 34); this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            UITheme.ApplyButtonGhost(this.btnCancel); this.btnCancel.Text = "Отмена"; this.btnCancel.Location = new System.Drawing.Point(378, 464); this.btnCancel.Size = new System.Drawing.Size(100, 34); this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblPlateNumber, txtPlateNumber, lblErrPlate, lblBrand, txtBrand, lblErrBrand, lblModel, txtModel, lblCapacityKg, txtCapacityKg, lblErrCapacity, lblVolumeM3, txtVolumeM3, lblErrVolume, lblTechnicalStatus, cmbTechnicalStatus, lblWorkStatus, cmbWorkStatus, btnSave, btnCancel });
            this.Controls.Add(this.pnlCard); this.Controls.Add(this.pnlAccent);
            this.ResumeLayout(false);
        }
    }
}