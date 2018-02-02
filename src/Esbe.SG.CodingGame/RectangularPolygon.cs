using System.Drawing;

namespace Esbe.SG.CodingGame
{
    public class RectangularPolygon : IPolygon
    {
        private readonly Rectangle _rectangle;

        public RectangularPolygon(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public bool IsOverlapping(Point point)
        {
            return _rectangle.Left <= point.X
                   && _rectangle.Right >= point.X
                   && _rectangle.Top <= point.Y
                   && _rectangle.Bottom >= point.Y;
        }

        public static RectangularPolygon FromLTRB(int left, int top, int right, int bottom)
        {
            return new RectangularPolygon(Rectangle.FromLTRB(left, top, right, bottom));
        }
    }
}