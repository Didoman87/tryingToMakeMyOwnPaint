using System;
using System.Drawing;

namespace Draw
{
    public class EllipseShape : Shape
    {
        public EllipseShape(RectangleF oval) : base(oval)
        {
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
		{
		}

        public override bool Contains(PointF point)
        {

            double ellipseEquation =
                ((point.X - (Rectangle.Left + 50)) * (point.X - (Rectangle.Left +50)) / (50 * 50)) +
                ((point.Y - (Rectangle.Top +100)) * (point.Y - (Rectangle.Top +100)) / (100 * 100));
                
            if (base.Contains(point))
            {
                
                if (ellipseEquation < 1)
                {
                    return true;
                }
                return false;
            }
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            
        }
    }
}
