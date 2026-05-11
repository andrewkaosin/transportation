namespace transportation
{
    partial class DocumentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.Button btnGenerate, btnMarkPaid, btnClose;
        private System.Windows.Forms.Panel pnlAccent, pnlTopBar, pnlToolbar;
        private System.Windows.Forms.Label lblFormTitle;

        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.SuspendLayout();

            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Font = UITheme.FontBody;
            this.Name = "DocumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Документы";
            this.Load += new System.EventHandler(this.DocumentsForm_Load);

            FormBuilder.BuildStandardLayout(pnlAccent, pnlTopBar, pnlToolbar, lblFormTitle, "📄  Документы по заявке");

            this.dgvDocuments.Anchor = FormBuilder.AllAnchors();
            this.dgvDocuments.Location = new System.Drawing.Point(0, 52);
            this.dgvDocuments.Size = new System.Drawing.Size(837, 410);
            UITheme.ApplyGrid(this.dgvDocuments);

            FormBuilder.SetToolbarButton(btnGenerate, "📄 Сформировать комплект", 12, 12, true, false);
            btnGenerate.Width = 210;
            FormBuilder.SetToolbarButton(btnMarkPaid, "✓ Пометить оплаченным", 230, 12, false, false);
            btnMarkPaid.Width = 200;
            FormBuilder.SetToolbarButton(btnClose, "Закрыть", 710, 12, false, false);

            btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] { btnGenerate, btnMarkPaid, btnClose });
            this.Controls.Add(this.dgvDocuments);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlAccent);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
