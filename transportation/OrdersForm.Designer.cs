namespace transportation
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;

   
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlToolbar;   
        private System.Windows.Forms.Panel pnlTopBar;    
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlAccent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();


            this.BackColor = UITheme.BgDark;
            this.ClientSize = new System.Drawing.Size(1200, 620);
            this.MinimumSize = new System.Drawing.Size(1000, 560);
            this.Font = UITheme.FontBody;
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заявки";
            this.Load += new System.EventHandler(this.OrdersForm_Load);

  
            this.pnlAccent.BackColor = UITheme.Accent;
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 3;

            this.pnlTopBar.BackColor = UITheme.BgCard;
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 52;
            this.pnlTopBar.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 51, pnlTopBar.Width, 51);
            };

            this.lblFormTitle.Text = "📦  Управление заявками";
            this.lblFormTitle.Font = UITheme.FontBold;
            this.lblFormTitle.ForeColor = UITheme.TextPrimary;
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(16, 17);
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopBar.Controls.Add(this.lblFormTitle);

            this.dgvOrders.Anchor = (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right);
            this.dgvOrders.Location = new System.Drawing.Point(0, 52);
            this.dgvOrders.Size = new System.Drawing.Size(1197, 510);
            UITheme.ApplyGrid(this.dgvOrders);

            this.pnlToolbar.BackColor = UITheme.BgCard;
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolbar.Height = 58;
            this.pnlToolbar.Paint += (s, e) => {
                using (var pen = new System.Drawing.Pen(UITheme.BorderColor))
                    e.Graphics.DrawLine(pen, 0, 0, pnlToolbar.Width, 0);
            };

          
            PlaceBtn(this.btnAdd, "＋ Добавить", 12, 12, true, false);
            PlaceBtn(this.btnEdit, "✎ Изменить", 124, 12, false, false);
            PlaceBtn(this.btnAssign, "→ Назначить", 236, 12, true, false);
            PlaceBtn(this.btnStart, "▶ В работу", 348, 12, false, false);
            PlaceBtn(this.btnComplete, "✓ Завершить", 460, 12, true, false);
       
            PlaceBtn(this.btnDelete, "✕ Удалить", 572, 12, false, true);
            PlaceBtn(this.btnCancelOrder, "⊘ Отменить", 684, 12, false, true);
          
            PlaceBtn(this.btnDocuments, "📄 Документы", 796, 12, false, false);
            PlaceBtn(this.btnRefresh, "↺ Обновить", 920, 12, false, false);
            PlaceBtn(this.btnClose, "Закрыть", 1080, 12, false, false);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnEdit, this.btnAssign, this.btnStart, this.btnComplete,
                this.btnDelete, this.btnCancelOrder, this.btnDocuments, this.btnRefresh, this.btnClose
            });

            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlAccent);

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        private void PlaceBtn(System.Windows.Forms.Button btn, string text, int x, int y, bool primary, bool danger)
        {
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(108, 34);
            if (danger) UITheme.ApplyButtonDanger(btn);
            else if (primary) UITheme.ApplyButtonPrimary(btn);
            else UITheme.ApplyButtonGhost(btn);
        }
    }
}
