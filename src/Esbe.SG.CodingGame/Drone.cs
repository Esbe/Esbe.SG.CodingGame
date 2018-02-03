using System.Drawing;
using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal class Drone : IDrone
    {
        private IBattlefieldArea _battlefieldArea = new UnlimitedBattlefieldArea();

        private Drone(Point point, Orientation orientation)
        {
            Point = point;
            Orientation = orientation;
        }

        /// <summary>
        ///     Gets the current drone x,y position.
        /// </summary>
        /// <value>
        ///     The current drone x,y position.
        /// </value>
        public Point Point { get; private set; }

        /// <summary>
        ///     Gets the current drone cardinal position.
        /// </summary>
        /// <value>
        ///     The current drone cardinal position.
        /// </value>
        public Orientation Orientation { get; private set; }

        /// <summary>
        ///     Turns the drone right (clockwise) by 90 degrees.
        /// </summary>
        public void TurnRight()
        {
            Orientation = Orientation == Orientation.W
                ? Orientation.N
                : Orientation + 1;
        }

        /// <summary>
        ///     Turns the drone left (counter-clockwise) by 90 degrees.
        /// </summary>
        public void TurnLeft()
        {
            Orientation = Orientation == Orientation.N
                ? Orientation.W
                : Orientation - 1;
        }

        /// <summary>
        ///     Sets the battlefield area in which the drone is allowed to move.
        /// </summary>
        /// <param name="battlefieldArea">The battlefield area.</param>
        public void SetBattlefieldArea([NotNull] IBattlefieldArea battlefieldArea)
        {
            _battlefieldArea = battlefieldArea;
        }

        /// <summary>
        ///     Moves the drone by one unit in the orientation it is facing, within the limits of the battlefield area.
        /// </summary>
        public void Move()
        {
            var movePoint = CalculateMovePoint();
            if (_battlefieldArea.Contains(movePoint))
            {
                Point = movePoint;
            }
        }

        /// <summary>
        ///     Determines whether the drone is in battlefield area.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if is in battlefield area; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInBattlefieldArea()
        {
            return _battlefieldArea.Contains(Point);
        }

        /// <summary>
        ///     Calculates the position the drone will be in after having moved, without any consideration for the battlefield
        ///     area.
        /// </summary>
        /// <returns>The potential position of the drone after having moved.</returns>
        private Point CalculateMovePoint()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    if (Point.Y == int.MaxValue)
                    {
                        return Point;
                    }

                    return new Point(Point.X, Point.Y + 1);
                case Orientation.E:
                    if (Point.X == int.MaxValue)
                    {
                        return Point;
                    }

                    return new Point(Point.X + 1, Point.Y);
                case Orientation.S:
                    if (Point.Y == int.MinValue)
                    {
                        return Point;
                    }

                    return new Point(Point.X, Point.Y - 1);
                default:
                    if (Point.X == int.MinValue)
                    {
                        return Point;
                    }

                    return new Point(Point.X - 1, Point.Y);
            }
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Point.X} {Point.Y} {Orientation}";
        }

        /// <summary>
        ///     Creates a new instance of drone with the specified point and orientation.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="orientation">The orientation.</param>
        /// <returns></returns>
        public static Drone FromPoint(Point point, Orientation orientation)
        {
            return new Drone(point, orientation);
        }

        /// <summary>
        ///     Creates a new instance of drone with the specified x, y and orientation.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="orientation">The orientation.</param>
        /// <returns></returns>
        public static Drone FromPosition(int x, int y, Orientation orientation)
        {
            return new Drone(new Point(x, y), orientation);
        }
    }
}