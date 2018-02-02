using System.Drawing;

namespace Esbe.SG.CodingGame
{
    public static class RectangleExtensions
    {
        public static bool IsOverlapping(this Rectangle rectangle, Point position)
        {
            return rectangle.Left <= position.X
                   && rectangle.Right >= position.X
                   && rectangle.Top <= position.Y
                   && rectangle.Bottom >= position.Y;
        }
    }
}