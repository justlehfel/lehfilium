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
            base.OnPaint(pevent);
        }
    }
}
