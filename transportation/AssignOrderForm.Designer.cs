namespace transportation
{
    partial class AssignOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInfo, lblDriver, lblVehicle;
        private System.Windows.Forms.ComboBox cmbDriver, cmbVehicle;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Panel pnlAccent, pnlCard;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.cmbDriver = new System.Windows.Forms.ComboBox();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(500, 290);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = UITheme.FontBody;
            this.Name = "AssignOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Назначение";
            this.Load += new System.EventHandler(this.AssignOrderForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 3;

            this.pnlCard.BackColor = UITheme.BgCard;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Size = new System.Drawing.Size(497, 290);

            // Инфо-строка (требования заявки)
            this.lblInfo.Text = "Требования заявки: загрузка...";
            this.lblInfo.Font = UITheme.FontBody;
            this.lblInfo.ForeColor = UITheme.Accent;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(24, 20);
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;

            // Водитель
            this.lblDriver.Text = "ВОДИТЕЛЬ";
            this.lblDriver.Font = UITheme.FontSmall;
            this.lblDriver.ForeColor = UITheme.TextSecondary;
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(24, 58);
            this.lblDriver.BackColor = System.Drawing.Color.Transparent;

            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.Location = new System.Drawing.Point(24, 76);
            this.cmbDriver.Size = new System.Drawing.Size(449, 28);
            UITheme.ApplyComboBox(this.cmbDriver);

            // Транспорт
            this.lblVehicle.Text = "ТРАНСПОРТ";
            this.lblVehicle.Font = UITheme.FontSmall;
            this.lblVehicle.ForeColor = UITheme.TextSecondary;
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Location = new System.Drawing.Point(24, 120);
            this.lblVehicle.BackColor = System.Drawing.Color.Transparent;

            this.cmbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicle.Location = new System.Drawing.Point(24, 138);
            this.cmbVehicle.Size = new System.Drawing.Size(449, 28);
            UITheme.ApplyComboBox(this.cmbVehicle);

            // Кнопки
            UITheme.ApplyButtonPrimary(this.btnSave);
            this.btnSave.Text = "Назначить";
            this.btnSave.Location = new System.Drawing.Point(230, 220);
            this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            UITheme.ApplyButtonGhost(this.btnCancel);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(358, 220);
            this.btnCancel.Size = new System.Drawing.Size(115, 34);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblInfo, lblDriver, cmbDriver, lblVehicle, cmbVehicle, btnSave, btnCancel
            });
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlAccent);
            this.ResumeLayout(false);
        }
    }
}