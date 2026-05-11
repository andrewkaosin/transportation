using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace transportation
{
    

    public static class UITheme
    {
 
        public static readonly Color BgDark = Color.FromArgb(18, 18, 24);    
        public static readonly Color BgCard = Color.FromArgb(26, 28, 38);    
        public static readonly Color BgControl = Color.FromArgb(35, 38, 52);    
        public static readonly Color BgHover = Color.FromArgb(42, 46, 62);    
        public static readonly Color BgHeader = Color.FromArgb(22, 25, 35);    

        public static readonly Color Accent = Color.FromArgb(59, 130, 246);  
        public static readonly Color AccentHover = Color.FromArgb(37, 99, 235);   
        public static readonly Color AccentLight = Color.FromArgb(30, 58, 138);   

        public static readonly Color TextPrimary = Color.FromArgb(220, 230, 245); 
        public static readonly Color TextSecondary = Color.FromArgb(120, 135, 165); 
        public static readonly Color TextMuted = Color.FromArgb(70, 82, 110);   

        public static readonly Color BorderColor = Color.FromArgb(45, 52, 72);    
        public static readonly Color BorderFocus = Color.FromArgb(59, 130, 246);  

        public static readonly Color StatusNew = Color.FromArgb(59, 130, 246);
        public static readonly Color StatusAssigned = Color.FromArgb(168, 85, 247);
        public static readonly Color StatusProgress = Color.FromArgb(245, 158, 11);
        public static readonly Color StatusDone = Color.FromArgb(34, 197, 94);
        public static readonly Color StatusCancelled = Color.FromArgb(239, 68, 68);

        public static readonly Color BtnDanger = Color.FromArgb(185, 28, 28);
        public static readonly Color BtnDangerHov = Color.FromArgb(220, 38, 38);
        public static readonly Color BtnGhost = Color.FromArgb(35, 38, 52);
        public static readonly Color BtnGhostHov = Color.FromArgb(45, 50, 68);

        public static readonly Font FontTitle = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontBold = new Font("Segoe UI Semibold", 10f);
        public static readonly Font FontBody = new Font("Segoe UI", 9.5f);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.5f);
        public static readonly Font FontMono = new Font("Consolas", 9f);
        public static readonly Font FontButton = new Font("Segoe UI Semibold", 9.5f);

 
        public static void ApplyForm(Form form)
        {
            form.BackColor = BgDark;
            form.ForeColor = TextPrimary;
            form.Font = FontBody;
        }


        public static void ApplyGrid(DataGridView grid)
        {
            grid.BackgroundColor = BgCard;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = BorderColor;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ScrollBars = ScrollBars.Both;
            grid.Font = FontBody;

            grid.ColumnHeadersDefaultCellStyle.BackColor = BgHeader;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondary;
            grid.ColumnHeadersDefaultCellStyle.Font = FontSmall;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = BgHeader;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextSecondary;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 36;


            grid.DefaultCellStyle.BackColor = BgCard;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = AccentLight;
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            grid.DefaultCellStyle.Font = FontBody;

            grid.AlternatingRowsDefaultCellStyle.BackColor = BgDark;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = AccentLight;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextPrimary;

            grid.RowTemplate.Height = 36;

            grid.CellFormatting += Grid_StatusColoring;
        }

        private static void Grid_StatusColoring(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0) return;
            if (!grid.Columns.Contains("Статус")) return;
            if (grid.Columns[e.ColumnIndex].Name != "Статус") return;

            string status = e.Value?.ToString() ?? "";
            switch (status)
            {
                case "new": e.Value = "Новая"; e.CellStyle.ForeColor = StatusNew; break;
                case "assigned": e.Value = "Назначена"; e.CellStyle.ForeColor = StatusAssigned; break;
                case "in_progress": e.Value = "В пути"; e.CellStyle.ForeColor = StatusProgress; break;
                case "completed": e.Value = "Завершена"; e.CellStyle.ForeColor = StatusDone; break;
                case "cancelled": e.Value = "Отменена"; e.CellStyle.ForeColor = StatusCancelled; break;
            }
            e.FormattingApplied = true;
        }

        public static void ApplyButtonPrimary(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Accent;
            btn.ForeColor = Color.White;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AccentHover;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);
            btn.Height = 34;
        }

        public static void ApplyButtonGhost(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = BtnGhost;
            btn.ForeColor = TextSecondary;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = BorderColor;
            btn.FlatAppearance.MouseOverBackColor = BtnGhostHov;
            btn.FlatAppearance.MouseDownBackColor = BtnGhost;
            btn.Height = 34;
        }


        public static void ApplyButtonDanger(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = BtnDanger;
            btn.ForeColor = Color.White;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = BtnDangerHov;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 27, 27);
            btn.Height = 34;
        }

        public static void ApplyTextBox(TextBox txt)
        {
            txt.BackColor = BgControl;
            txt.ForeColor = TextPrimary;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FontBody;
            txt.Height = 28;
        }

        public static void ApplyComboBox(ComboBox cmb)
        {
            cmb.BackColor = BgControl;
            cmb.ForeColor = TextPrimary;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = FontBody;
        }

        public static void ApplyDatePicker(DateTimePicker dtp)
        {
            dtp.CalendarForeColor = TextPrimary;
            dtp.CalendarMonthBackground = BgCard;
            dtp.CalendarTitleBackColor = Accent;
            dtp.CalendarTitleForeColor = Color.White;
            dtp.Font = FontBody;
        }

        public static void PaintAccentBar(Panel panel, PaintEventArgs e)
        {
            using (var br = new SolidBrush(Accent))
                e.Graphics.FillRectangle(br, 0, 0, 3, panel.Height);
        }


        public static void DrawRoundedBorder(Graphics g, Rectangle rect, int radius, Color color)
        {
            using (var pen = new Pen(color, 1))
            using (var path = RoundedRect(rect, radius))
                g.DrawPath(pen, path);
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.Right - radius * 2, bounds.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static (Color color, string label) GetStatusStyle(string status)
        {
            switch (status)
            {
                case "new": return (StatusNew, "Новая");
                case "assigned": return (StatusAssigned, "Назначена");
                case "in_progress": return (StatusProgress, "В пути");
                case "completed": return (StatusDone, "Завершена");
                case "cancelled": return (StatusCancelled, "Отменена");
                default: return (TextMuted, status);
            }
        }
    }
}
