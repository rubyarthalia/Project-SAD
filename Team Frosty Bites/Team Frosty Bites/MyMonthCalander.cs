using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Frosty_Bites
{
    internal class MyMonthCalander : MonthCalendar
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(Handle, string.Empty, string.Empty);
            base.OnHandleCreated(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Call base paint for default handling if needed

            // Custom Drawing
            Graphics g = e.Graphics;

            // Fill Background with White
            g.Clear(Color.White);

            // Draw Text (Placeholder for Actual Calendar Elements)
            using (Font titleFont = new Font(Font.FontFamily, 12, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                g.DrawString("December 2024", titleFont, textBrush, new PointF(10, 10));
                g.DrawString("Sun Mon Tue Wed Thu Fri Sat", this.Font, textBrush, new PointF(10, 30));

                // Simulate calendar grid (you can enhance it further)
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 7; col++)
                    {
                        Rectangle cell = new Rectangle(10 + col * 30, 50 + row * 30, 30, 30);
                        g.DrawRectangle(Pens.Black, cell);
                        g.DrawString(((row * 7) + col + 1).ToString(), this.Font, textBrush, cell.Location);
                    }
                }
            }
        }
    }
}
