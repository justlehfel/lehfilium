using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LoveChecker
{
    public class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(grPath);

            // Fill the background
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.FillEllipse(new SolidBrush(this.BackColor), 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            // Draw the text
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
