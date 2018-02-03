using System.Drawing;

namespace Esbe.SG.CodingGame
{
    internal class RectangularBattlefieldArea : IBattlefieldArea
    {
        private readonly Rectangle _rectangle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RectangularBattlefieldArea" /> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        private RectangularBattlefieldArea(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        /// <summary>
        ///     Determines whether this battlefield area contains the specified point. This also returns true if the point is
        ///     touching any of the area's edges.
        /// </summary>
        /// <param name="point">The point with coordinates x,y.</param>
        /// <returns>
        ///     <c>true</c> if the battlefield area contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Point point)
        {
            return _rectangle.Left <= point.X
                   && _rectangle.Right >= point.X
                   && _rectangle.Top <= point.Y
                   && _rectangle.Bottom >= point.Y;
        }

        public override string ToString()
        {
            return $"RectangularBattlefieldArea: {_rectangle}";
        }

        /// <summary>
        ///     Creates a new instance of RectangularBattlefieldArea. Please note that this uses the windows viewscreen axis, so
        ///     the y axis increases down !
        /// </summary>
        /// <param name="left">The left x axis value.</param>
        /// <param name="top">The top y axis value (in usual x,y axises this would be bottom).</param>
        /// <param name="right">The right x axis value.</param>
        /// <param name="bottom">The bottom y axis value (in usual x,y axises this would be top).</param>
        /// <returns></returns>
        public static RectangularBattlefieldArea FromLTRB(int left, int top, int right, int bottom)
        {
            return new RectangularBattlefieldArea(Rectangle.FromLTRB(left, top, right, bottom));
        }
    }
}