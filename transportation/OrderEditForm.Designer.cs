namespace transportation
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblClient, lblLoadingPoint, lblUnloadingPoint;
        private System.Windows.Forms.Label lblCargoName, lblWeightKg, lblVolumeM3;
        private System.Windows.Forms.Label lblPlannedDate, lblPrice, lblComment;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.TextBox txtLoadingPoint, txtUnloadingPoint, txtCargoName;
        private System.Windows.Forms.TextBox txtWeightKg, txtVolumeM3, txtPrice, txtComment;
        private System.Windows.Forms.DateTimePicker dtpPlannedDate;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Panel pnlMain, pnlAccent;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblLoadingPoint = new System.Windows.Forms.Label();
            this.lblUnloadingPoint = new System.Windows.Forms.Label();
            this.lblCargoName = new System.Windows.Forms.Label();
            this.lblWeightKg = new System.Windows.Forms.Label();
            this.lblVolumeM3 = new System.Windows.Forms.Label();
            this.lblPlannedDate = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.txtLoadingPoint = new System.Windows.Forms.TextBox();
            this.txtUnloadingPoint = new System.Windows.Forms.TextBox();
            this.txtCargoName = new System.Windows.Forms.TextBox();
            this.txtWeightKg = new System.Windows.Forms.TextBox();
            this.txtVolumeM3 = new System.Windows.Forms.TextBox();
            this.dtpPlannedDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = UITheme.FontBody;
            this.Name = "OrderEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заявка";
            this.Load += new System.EventHandler(this.OrderEditForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 3;

            this.pnlMain.BackColor = UITheme.BgCard;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Size = new System.Drawing.Size(597, 520);
            this.pnlMain.Anchor = FormBuilder.AllAnchors();

            System.Action<System.Windows.Forms.Label, string, int, int> mkLbl = (lbl, txt, x, y) => {
                lbl.Text = txt;
                lbl.Font = UITheme.FontSmall;
                lbl.ForeColor = UITheme.TextSecondary;
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(x, y);
                lbl.BackColor = System.Drawing.Color.Transparent;
            };

            System.Action<System.Windows.Forms.TextBox, int, int, int> mkTxt = (txt, x, y, w) => {
                txt.Location = new System.Drawing.Point(x, y);
                txt.Size = new System.Drawing.Size(w, 28);
                UITheme.ApplyTextBox(txt);
            };

            mkLbl(lblClient, "КЛИЕНТ", 24, 20);
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Location = new System.Drawing.Point(24, 38);
            this.cmbClient.Size = new System.Drawing.Size(549, 28);
            UITheme.ApplyComboBox(this.cmbClient);

            mkLbl(lblLoadingPoint, "ПУНКТ ПОГРУЗКИ", 24, 80);
            mkTxt(txtLoadingPoint, 24, 98, 549);

            mkLbl(lblUnloadingPoint, "ПУНКТ ВЫГРУЗКИ", 24, 140);
            mkTxt(txtUnloadingPoint, 24, 158, 549);

            mkLbl(lblCargoName, "НАИМЕНОВАНИЕ ГРУЗА", 24, 200);
            mkTxt(txtCargoName, 24, 218, 549);

            mkLbl(lblWeightKg, "ВЕС, КГ", 24, 260);
            mkTxt(txtWeightKg, 24, 278, 160);

            mkLbl(lblVolumeM3, "ОБЪЁМ, М³", 204, 260);
            mkTxt(txtVolumeM3, 204, 278, 160);

            mkLbl(lblPlannedDate, "ПЛАНОВАЯ ДАТА", 384, 260);
            this.dtpPlannedDate.Location = new System.Drawing.Point(384, 278);
            this.dtpPlannedDate.Size = new System.Drawing.Size(189, 28);
            UITheme.ApplyDatePicker(this.dtpPlannedDate);

            mkLbl(lblPrice, "СТОИМОСТЬ, ₽", 24, 320);
            mkTxt(txtPrice, 24, 338, 160);

            mkLbl(lblComment, "КОММЕНТАРИЙ", 24, 380);
            this.txtComment.Location = new System.Drawing.Point(24, 398);
            this.txtComment.Size = new System.Drawing.Size(549, 64);
            this.txtComment.Multiline = true;
            UITheme.ApplyTextBox(this.txtComment);

            // Кнопки снизу
            UITheme.ApplyButtonPrimary(this.btnSave);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(338, 476);
            this.btnSave.Size = new System.Drawing.Size(114, 34);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            UITheme.ApplyButtonGhost(this.btnCancel);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(459, 476);
            this.btnCancel.Size = new System.Drawing.Size(114, 34);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlMain.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblClient, cmbClient,
                lblLoadingPoint, txtLoadingPoint,
                lblUnloadingPoint, txtUnloadingPoint,
                lblCargoName, txtCargoName,
                lblWeightKg, txtWeightKg,
                lblVolumeM3, txtVolumeM3,
                lblPlannedDate, dtpPlannedDate,
                lblPrice, txtPrice,
                lblComment, txtComment,
                btnSave, btnCancel
            });

            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlAccent);
            this.ResumeLayout(false);
        }
    }
}