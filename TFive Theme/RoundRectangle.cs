using System.Drawing;
using System.Drawing.Drawing2D;

namespace King99
{
    static class RoundRectangle
    {
        public static GraphicsPath RoundRect(Rectangle rectangle, int curve)
        {
            var p = new GraphicsPath();
            var arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
        public static GraphicsPath RoundRect(int x, int y, int width, int height, int curve)
        {
            var rectangle = new Rectangle(x, y, width, height);
            var p = new GraphicsPath();
            var arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
        //public static GraphicsPath RoundedTopRect(Rectangle rectangle, int curve)
        //{
        //    var p = new GraphicsPath();
        //    var arcRectangleWidth = curve * 2;
        //    p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
        //    p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
        //    p.AddLine(new Point(rectangle.X + rectangle.Width, rectangle.Y + arcRectangleWidth), new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - 1));
        //    p.AddLine(new Point(rectangle.X, rectangle.Height - 1 + rectangle.Y), new Point(rectangle.X, rectangle.Y + curve));
        //    return p;
        //}
    }
}