namespace transportation
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete, btnRefresh, btnClose;
        private System.Windows.Forms.Panel pnlAccent, pnlTopBar, pnlToolbar;
        private System.Windows.Forms.Label lblFormTitle;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(840, 500);
            this.MinimumSize = new System.Drawing.Size(800, 460);
            this.Font = UITheme.FontBody;
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователи и роли";
            this.Load += new System.EventHandler(this.UsersForm_Load);

            FormBuilder.BuildStandardLayout(pnlAccent, pnlTopBar, pnlToolbar, lblFormTitle, "🔐  Пользователи и роли");

            this.dgvUsers.Anchor = FormBuilder.AllAnchors();
            this.dgvUsers.Location = new System.Drawing.Point(0, 52);
            this.dgvUsers.Size = new System.Drawing.Size(837, 390);
            UITheme.ApplyGrid(this.dgvUsers);

            FormBuilder.SetToolbarButton(btnAdd, "＋ Добавить", 12, 12, true, false);
            FormBuilder.SetToolbarButton(btnEdit, "✎ Изменить", 124, 12, false, false);
            FormBuilder.SetToolbarButton(btnDelete, "✕ Удалить", 236, 12, false, true);
            FormBuilder.SetToolbarButton(btnRefresh, "↺ Обновить", 348, 12, false, false);
            FormBuilder.SetToolbarButton(btnClose, "Закрыть", 710, 12, false, false);

            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, btnClose });
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlAccent);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
