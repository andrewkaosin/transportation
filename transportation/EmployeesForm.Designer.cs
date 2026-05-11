namespace transportation
{
    partial class EmployeesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEmployees;
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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(940, 560);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Font = UITheme.FontBody;
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);

            FormBuilder.BuildStandardLayout(pnlAccent, pnlTopBar, pnlToolbar, lblFormTitle, "👥  Сотрудники");

            this.dgvEmployees.Anchor =  FormBuilder.AllAnchors();
            this.dgvEmployees.Location = new System.Drawing.Point(0, 52);
            this.dgvEmployees.Size = new System.Drawing.Size(937, 450);
            UITheme.ApplyGrid(this.dgvEmployees);

            FormBuilder.SetToolbarButton(btnAdd, "＋ Добавить", 12, 12, true, false);
            FormBuilder.SetToolbarButton(btnEdit, "✎ Изменить", 124, 12, false, false);
            FormBuilder.SetToolbarButton(btnDelete, "✕ Удалить", 236, 12, false, true);
            FormBuilder.SetToolbarButton(btnRefresh, "↺ Обновить", 348, 12, false, false);
            FormBuilder.SetToolbarButton(btnClose, "Закрыть", 810, 12, false, false);

            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] { btnAdd, btnEdit, btnDelete, btnRefresh, btnClose });
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlAccent);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
