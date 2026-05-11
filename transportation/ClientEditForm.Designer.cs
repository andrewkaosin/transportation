namespace transportation
{
    partial class ClientEditForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── поля (имена НЕ меняем — ClientEditForm.cs работает без правок) ──
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormIcon;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormSub;

        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblInn;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;

        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtInn;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;

        // метки-ошибки рядом с полями
        private System.Windows.Forms.Label lblErrCompany;
        private System.Windows.Forms.Label lblErrInn;
        private System.Windows.Forms.Label lblErrPhone;
        private System.Windows.Forms.Label lblErrEmail;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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

            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblInn = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtInn = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.lblErrCompany = new System.Windows.Forms.Label();
            this.lblErrInn = new System.Windows.Forms.Label();
            this.lblErrPhone = new System.Windows.Forms.Label();
            this.lblErrEmail = new System.Windows.Forms.Label();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── Форма ───────────────────────────────────────────
            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(500, 570);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Клиент";
            this.Font = UITheme.FontBody;
            this.Load += new System.EventHandler(this.ClientEditForm_Load);

            // ── Синяя вертикальная полоса слева ─────────────────
            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 4;

            // ── Карточка (весь контент) ──────────────────────────
            this.pnlCard.BackColor = UITheme.BgCard;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Size = new System.Drawing.Size(496, 570);
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.Top
                                   | System.Windows.Forms.AnchorStyles.Bottom
                                   | System.Windows.Forms.AnchorStyles.Left
                                   | System.Windows.Forms.AnchorStyles.Right;

            // ── Шапка карточки ───────────────────────────────────
            this.pnlHeader.BackColor = UITheme.BgDark;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(496, 70);
            this.pnlHeader.Paint += (s, e) => {
                using (var p = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(p, 0, 69, 496, 69);
            };

            this.lblFormIcon.Text = "🏢";
            this.lblFormIcon.Font = new System.Drawing.Font("Segoe UI", 20f);
            this.lblFormIcon.AutoSize = true;
            this.lblFormIcon.Location = new System.Drawing.Point(16, 14);
            this.lblFormIcon.BackColor = System.Drawing.Color.Transparent;

            this.lblFormTitle.Text = "Клиент";
            this.lblFormTitle.Font = UITheme.FontBold;
            this.lblFormTitle.ForeColor = UITheme.TextPrimary;
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(58, 16);
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblFormSub.Text = "Заполните данные организации";
            this.lblFormSub.Font = UITheme.FontSmall;
            this.lblFormSub.ForeColor = UITheme.TextMuted;
            this.lblFormSub.AutoSize = true;
            this.lblFormSub.Location = new System.Drawing.Point(60, 38);
            this.lblFormSub.BackColor = System.Drawing.Color.Transparent;

            this.pnlHeader.Controls.Add(this.lblFormIcon);
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Controls.Add(this.lblFormSub);

            // ── Хелперы для полей ────────────────────────────────
            int W = 450; // ширина поля

            System.Action<System.Windows.Forms.Label, string, int, int, bool> mkLbl =
                (lbl, txt, x, y, required) => {
                    lbl.Text = required ? txt + " *" : txt;
                    lbl.Font = UITheme.FontSmall;
                    lbl.ForeColor = UITheme.TextSecondary;
                    lbl.AutoSize = true;
                    lbl.Location = new System.Drawing.Point(x, y);
                    lbl.BackColor = System.Drawing.Color.Transparent;
                };

            System.Action<System.Windows.Forms.TextBox, int, int, int> mkTxt =
                (txt, x, y, w) => {
                    txt.Location = new System.Drawing.Point(x, y);
                    txt.Size = new System.Drawing.Size(w, 28);
                    UITheme.ApplyTextBox(txt);
                    // Подсветка фокуса
                    txt.Enter += (s, e2) => txt.BackColor = UITheme.BgHover;
                    txt.Leave += (s, e2) => txt.BackColor = UITheme.BgControl;
                };

            System.Action<System.Windows.Forms.Label, int, int> mkErr =
                (lbl, x, y) => {
                    lbl.Text = "";
                    lbl.Font = UITheme.FontSmall;
                    lbl.ForeColor = UITheme.StatusCancelled;
                    lbl.AutoSize = true;
                    lbl.Location = new System.Drawing.Point(x, y);
                    lbl.BackColor = System.Drawing.Color.Transparent;
                };

            // ── Поля формы (Y от 80) ─────────────────────────────
            int lx = 22, tx = 22, ey = 0;

            // Название *
            mkLbl(lblCompanyName, "НАЗВАНИЕ ОРГАНИЗАЦИИ", lx, 82, true);
            mkTxt(txtCompanyName, tx, 100, W);
            mkErr(lblErrCompany, tx, 130);

            // ИНН
            mkLbl(lblInn, "ИНН", lx, 148, false);
            mkTxt(txtInn, tx, 166, 200);
            mkErr(lblErrInn, tx, 196);

            // Контактное лицо
            mkLbl(lblContactPerson, "КОНТАКТНОЕ ЛИЦО", lx, 214, false);
            mkTxt(txtContactPerson, tx, 232, W);

            // Телефон
            mkLbl(lblPhone, "ТЕЛЕФОН", lx, 276, false);
            mkTxt(txtPhone, tx, 294, 200);
            mkErr(lblErrPhone, tx, 324);

            // Email
            mkLbl(lblEmail, "EMAIL", lx, 342, false);
            mkTxt(txtEmail, tx, 360, W);
            mkErr(lblErrEmail, tx, 390);

            // Адрес
            mkLbl(lblAddress, "АДРЕС", lx, 408, false);
            mkTxt(txtAddress, tx, 426, W);

            // ── Кнопки ───────────────────────────────────────────
            UITheme.ApplyButtonPrimary(this.btnSave);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(230, 520);
            this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            UITheme.ApplyButtonGhost(this.btnCancel);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(358, 520);
            this.btnCancel.Size = new System.Drawing.Size(110, 34);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── Сборка ──────────────────────────────────────────
            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Controls.Add(this.lblCompanyName);
            this.pnlCard.Controls.Add(this.txtCompanyName);
            this.pnlCard.Controls.Add(this.lblErrCompany);
            this.pnlCard.Controls.Add(this.lblInn);
            this.pnlCard.Controls.Add(this.txtInn);
            this.pnlCard.Controls.Add(this.lblErrInn);
            this.pnlCard.Controls.Add(this.lblContactPerson);
            this.pnlCard.Controls.Add(this.txtContactPerson);
            this.pnlCard.Controls.Add(this.lblPhone);
            this.pnlCard.Controls.Add(this.txtPhone);
            this.pnlCard.Controls.Add(this.lblErrPhone);
            this.pnlCard.Controls.Add(this.lblEmail);
            this.pnlCard.Controls.Add(this.txtEmail);
            this.pnlCard.Controls.Add(this.lblErrEmail);
            this.pnlCard.Controls.Add(this.lblAddress);
            this.pnlCard.Controls.Add(this.txtAddress);
            this.pnlCard.Controls.Add(this.btnSave);
            this.pnlCard.Controls.Add(this.btnCancel);

            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlAccent);

            this.ResumeLayout(false);
        }
    }
}