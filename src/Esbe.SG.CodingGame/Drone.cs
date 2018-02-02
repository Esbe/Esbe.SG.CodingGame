using System.Drawing;

namespace Esbe.SG.CodingGame
{
    public class Drone
    {
        private Point _point;

        private Drone(Point point, Orientation orientation)
        {
            _point = point;
            Orientation = orientation;
        }

        public int X => _point.X;
        public int Y => _point.Y;

        public Orientation Orientation { get; private set; }

        /// <summary>
        ///     Moves the drone by Turns the drone right (clockwise) by 90 degrees.
        /// </summary>
        public void MoveWithin(IPolygon polygon)
        {
            //            switch (Orientation)
            //            {
            //                case Orientation.N:
            //                    if (_point.Y < rectangle.Top)
            //                    {
            //                        _point.Y++;
            //                    }
            //
            //                    return;
            //                case Orientation.E:
            //                    if (_point.X < rectangle.Right)
            //                    {
            //                        _point.X++;
            //                    }
            //
            //                    return;
            //                case Orientation.S:
            //                    if (_point.Y > rectangle.Bottom)
            //                    {
            //                        _point.Y--;
            //                    }
            //
            //                    return;
            //                case Orientation.W:
            //                    if (_point.X > rectangle.Left)
            //                    {
            //                        _point.X--;
            //                    }
            //
            //                    return;
            //            }

            var movePoint = CalculateMovePoint();
            if (polygon.IsOverlapping(movePoint))
            {
                _point = movePoint;
            }
        }

        private Point CalculateMovePoint()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    if (_point.Y == int.MaxValue)
                    {
                        return _point;
                    }

                    return new Point(_point.X, _point.Y + 1);
                case Orientation.E:
                    if (_point.X == int.MaxValue)
                    {
                        return _point;
                    }

                    return new Point(_point.X + 1, _point.Y);
                case Orientation.S:
                    if (_point.Y == int.MinValue)
                    {
                        return _point;
                    }

                    return new Point(_point.X, _point.Y - 1);
                default:
                    if (_point.X == int.MinValue)
                    {
                        return _point;
                    }

                    return new Point(_point.X - 1, _point.Y);
            }
        }

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

        public bool IsWithinPolygon(IPolygon polygon)
        {
            return polygon.IsOverlapping(_point);
        }

        public static Drone FromPoint(Point point, Orientation orientation)
        {
            return new Drone(point, orientation);
        }

        public static Drone FromPosition(int x, int y, Orientation orientation)
        {
            return new Drone(new Point(x, y), orientation);
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}