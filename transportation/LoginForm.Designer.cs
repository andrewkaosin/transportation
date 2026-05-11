namespace transportation
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlLeft;     
        private System.Windows.Forms.Label lblVersion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();

            this.SuspendLayout();
            this.panel1.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransFlow — Вход";
            this.Name = "LoginForm";
            this.Font = UITheme.FontBody;
            this.Load += new System.EventHandler(this.LoginForm_Load);

            this.pnlLeft.BackColor = UITheme.Accent;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(0, 500);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;

            this.panel1.BackColor = UITheme.BgCard;
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(230, 80);
            this.panel1.Size = new System.Drawing.Size(400, 340);
            this.panel1.TabIndex = 0;

            this.panel1.Paint += (s, e) => {
                UITheme.DrawRoundedBorder(e.Graphics,
                    new System.Drawing.Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1),
                    8, UITheme.BorderColor);
            };

            this.lblTitle.Text = "Вход в систему";
            this.lblTitle.Font = UITheme.FontTitle;
            this.lblTitle.ForeColor = UITheme.TextPrimary;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(40, 38);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitle.Text = "ИС управления грузоперевозками";
            this.lblSubtitle.Font = UITheme.FontSubtitle;
            this.lblSubtitle.ForeColor = UITheme.TextSecondary;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(42, 75);
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;

            this.lblLogin.Text = "ЛОГИН";
            this.lblLogin.Font = UITheme.FontSmall;
            this.lblLogin.ForeColor = UITheme.TextSecondary;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(40, 118);
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;

            this.txtLogin.Location = new System.Drawing.Point(40, 136);
            this.txtLogin.Size = new System.Drawing.Size(320, 28);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.BackColor = UITheme.BgControl;
            this.txtLogin.ForeColor = UITheme.TextPrimary;
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Font = UITheme.FontBody;

            this.lblPassword.Text = "ПАРОЛЬ";
            this.lblPassword.Font = UITheme.FontSmall;
            this.lblPassword.ForeColor = UITheme.TextSecondary;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 180);
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;

            this.txtPassword.Location = new System.Drawing.Point(40, 198);
            this.txtPassword.Size = new System.Drawing.Size(320, 28);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BackColor = UITheme.BgControl;
            this.txtPassword.ForeColor = UITheme.TextPrimary;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = UITheme.FontBody;

            this.btnLogin.Text = "Войти";
            this.btnLogin.Location = new System.Drawing.Point(40, 252);
            this.btnLogin.Size = new System.Drawing.Size(148, 36);
            this.btnLogin.TabIndex = 2;
            UITheme.ApplyButtonPrimary(this.btnLogin);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.btnExit.Text = "Выход";
            this.btnExit.Location = new System.Drawing.Point(212, 252);
            this.btnExit.Size = new System.Drawing.Size(148, 36);
            this.btnExit.TabIndex = 3;
            UITheme.ApplyButtonGhost(this.btnExit);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = UITheme.TextMuted;
            this.lblHint.Font = UITheme.FontSmall;
            this.lblHint.Location = new System.Drawing.Point(40, 302);
            this.lblHint.BackColor = System.Drawing.Color.Transparent;
            this.lblHint.Click += new System.EventHandler(this.lblHint_Click);

            this.lblVersion.Text = "TransFlow v1.0  ·  .NET Framework 4.7.2  ·  PostgreSQL";
            this.lblVersion.Font = UITheme.FontSmall;
            this.lblVersion.ForeColor = UITheme.TextMuted;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(20, 472);


            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblSubtitle);
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblHint);

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.lblVersion);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

