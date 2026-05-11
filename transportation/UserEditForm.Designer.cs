namespace transportation
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard, pnlAccent, pnlHeader;
        private System.Windows.Forms.Label lblFormIcon, lblFormTitle, lblFormSub;
        private System.Windows.Forms.Label lblLogin, lblPassword, lblRole;
        private System.Windows.Forms.TextBox txtLogin, txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblErrLogin, lblErrPassword, lblPasswordHint;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel(); this.pnlAccent = new System.Windows.Forms.Panel(); this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormIcon = new System.Windows.Forms.Label(); this.lblFormTitle = new System.Windows.Forms.Label(); this.lblFormSub = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label(); this.lblPassword = new System.Windows.Forms.Label(); this.lblRole = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox(); this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox(); this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblErrLogin = new System.Windows.Forms.Label(); this.lblErrPassword = new System.Windows.Forms.Label(); this.lblPasswordHint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button(); this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark; this.ClientSize = new System.Drawing.Size(460, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователь"; this.Font = UITheme.FontBody;
            this.Load += new System.EventHandler(this.UserEditForm_Load);

            this.pnlAccent.BackColor = UITheme.Accent; this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left; this.pnlAccent.Width = 0;
            this.pnlCard.BackColor = UITheme.BgCard; this.pnlCard.Location = new System.Drawing.Point(4, 0); this.pnlCard.Size = new System.Drawing.Size(456, 420);
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlHeader.BackColor = UITheme.BgDark; this.pnlHeader.Location = new System.Drawing.Point(0, 0); this.pnlHeader.Size = new System.Drawing.Size(456, 70);
            this.pnlHeader.Paint += (s, e) => { using (var p = new System.Drawing.Pen(UITheme.BorderColor)) e.Graphics.DrawLine(p, 0, 69, 456, 69); };
            this.lblFormIcon.Text = "🔐"; this.lblFormIcon.Font = new System.Drawing.Font("Segoe UI", 20f); this.lblFormIcon.AutoSize = true; this.lblFormIcon.Location = new System.Drawing.Point(16, 14); this.lblFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = UITheme.FontBold; this.lblFormTitle.ForeColor = UITheme.TextPrimary; this.lblFormTitle.AutoSize = true; this.lblFormTitle.Location = new System.Drawing.Point(58, 16); this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormSub.Font = UITheme.FontSmall; this.lblFormSub.ForeColor = UITheme.TextMuted; this.lblFormSub.AutoSize = true; this.lblFormSub.Location = new System.Drawing.Point(60, 38); this.lblFormSub.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblFormIcon); this.pnlHeader.Controls.Add(this.lblFormTitle); this.pnlHeader.Controls.Add(this.lblFormSub);

            System.Action<System.Windows.Forms.Label, string, int, int, bool> mL = (l, t, x, y, r) => { l.Text = r ? t + " *" : t; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.TextSecondary; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };
            System.Action<System.Windows.Forms.TextBox, int, int, int> mT = (t, x, y, w) => { t.Location = new System.Drawing.Point(x, y); t.Size = new System.Drawing.Size(w, 28); UITheme.ApplyTextBox(t); t.Enter += (s, e2) => t.BackColor = UITheme.BgHover; t.Leave += (s, e2) => t.BackColor = UITheme.BgControl; };
            System.Action<System.Windows.Forms.Label, int, int> mE = (l, x, y) => { l.Text = ""; l.Font = UITheme.FontSmall; l.ForeColor = UITheme.StatusCancelled; l.AutoSize = true; l.Location = new System.Drawing.Point(x, y); l.BackColor = System.Drawing.Color.Transparent; };
            int lx = 22;

            mL(lblLogin, "ЛОГИН", lx, 82, true); mT(txtLogin, lx, 100, 300); mE(lblErrLogin, lx, 130);
            mL(lblPassword, "ПАРОЛЬ", lx, 148, false); mT(txtPassword, lx, 166, 300);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblPasswordHint.Text = "При редактировании: оставьте пустым, чтобы не менять";
            this.lblPasswordHint.Font = UITheme.FontSmall; this.lblPasswordHint.ForeColor = UITheme.TextMuted;
            this.lblPasswordHint.AutoSize = true; this.lblPasswordHint.Location = new System.Drawing.Point(lx, 196); this.lblPasswordHint.BackColor = System.Drawing.Color.Transparent;
            mE(lblErrPassword, lx, 210);
            mL(lblRole, "РОЛЬ", lx, 228, true);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(lx, 246); this.cmbRole.Size = new System.Drawing.Size(300, 28); UITheme.ApplyComboBox(this.cmbRole);

            this.chkIsActive.Text = "Аккаунт активен"; this.chkIsActive.Checked = true;
            this.chkIsActive.Font = UITheme.FontBody; this.chkIsActive.ForeColor = UITheme.TextPrimary;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent; this.chkIsActive.Location = new System.Drawing.Point(lx, 298); this.chkIsActive.AutoSize = true;

            UITheme.ApplyButtonPrimary(this.btnSave); this.btnSave.Text = "Сохранить"; this.btnSave.Location = new System.Drawing.Point(220, 364); this.btnSave.Size = new System.Drawing.Size(120, 34); this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            UITheme.ApplyButtonGhost(this.btnCancel); this.btnCancel.Text = "Отмена"; this.btnCancel.Location = new System.Drawing.Point(346, 364); this.btnCancel.Size = new System.Drawing.Size(100, 34); this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.pnlCard.Controls.Add(this.pnlHeader);
            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblLogin, txtLogin, lblErrLogin, lblPassword, txtPassword, lblPasswordHint, lblErrPassword, lblRole, cmbRole, chkIsActive, btnSave, btnCancel });
            this.Controls.Add(this.pnlCard); this.Controls.Add(this.pnlAccent);
            this.ResumeLayout(false);
        }
    }
}