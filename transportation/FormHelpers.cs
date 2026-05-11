namespace transportation
  {
      using System.Drawing;
      using System.Windows.Forms;

      // Методы-хелперы, доступные всем Designer-файлам через partial class
      static class FormBuilder
      {
          public static void BuildStandardLayout(
              Panel pnlAccent, Panel pnlTopBar, Panel pnlToolbar,
              Label lblTitle, string title)
          {
              pnlAccent.BackColor = UITheme.Accent;
              pnlAccent.Dock      = DockStyle.Left;
              pnlAccent.Width     = 3;
             pnlTopBar.BackColor = UITheme.BgCard;
              pnlTopBar.Dock      = DockStyle.Top;
              pnlTopBar.Height    = 52;
              pnlTopBar.Paint    += (s, e) => {
                  using (var pen = new Pen(UITheme.BorderColor))
                      e.Graphics.DrawLine(pen, 0, 51, pnlTopBar.Width, 51);
              };
              lblTitle.Text      = title;
              lblTitle.Font      = UITheme.FontBold;
              lblTitle.ForeColor = UITheme.TextPrimary;
              lblTitle.AutoSize  = true;
              lblTitle.Location  = new Point(16, 17);
              lblTitle.BackColor = Color.Transparent;
              pnlTopBar.Controls.Add(lblTitle);

              pnlToolbar.BackColor = UITheme.BgCard;
              pnlToolbar.Dock      = DockStyle.Bottom;
              pnlToolbar.Height    = 58;
              pnlToolbar.Paint    += (s, e) => {
                  using (var pen = new Pen(UITheme.BorderColor))
                      e.Graphics.DrawLine(pen, 0, 0, pnlToolbar.Width, 0);
              };
          }
          public static void SetToolbarButton(
              Button btn, string text, int x, int y, bool primary, bool danger)
          {
              btn.Text     = text;
              btn.Location = new Point(x, y);
              btn.Size     = new Size(108, 34);
              if      (danger)   UITheme.ApplyButtonDanger(btn);
              else if (primary)  UITheme.ApplyButtonPrimary(btn);
              else               UITheme.ApplyButtonGhost(btn);
          }

          public static AnchorStyles AllAnchors() =>
              AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      }
  }
//
// ВАЖНО: После добавления FormHelpers.cs замените вызовы
//   BuildStandardLayout(...)  →  FormBuilder.BuildStandardLayout(...)
//   SetToolbarButton(...)      →  FormBuilder.SetToolbarButton(...)
//   AllAnchors()               →  FormBuilder.AllAnchors()
// в каждом Designer.cs выше.
 