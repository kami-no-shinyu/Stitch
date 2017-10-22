using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Stitch
{
    class ProgressBarCustom : ProgressBar
    {
        
        public ProgressBarCustom()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            Brush brush = new SolidBrush(Color.FromArgb(64, 144, 225));
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
       
    }
}
