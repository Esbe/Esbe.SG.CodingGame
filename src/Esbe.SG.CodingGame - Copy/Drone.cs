using SixLabors.Primitives;
using SixLabors.Shapes;

namespace Esbe.SG.CodingGame
{
    public class Drone
    {
        private Point _position;

        public Drone(Point position, Orientation orientation)
        {
            _position = position;
            Orientation = orientation;
        }

        public int X => _position.X;
        public int Y => _position.Y;

        public Orientation Orientation { get; private set; }

        public void MoveWithin(IPath polygon)
        {
//            switch (Orientation)
//            {
//                case Orientation.N:
//                    if (_position.Y < rectangle.Top) _position.Y++;
//                    return;
//                case Orientation.E:
//                    if (_position.X < rectangle.Right) _position.X++;
//                    return;
//                case Orientation.S:
//                    if (_position.Y > rectangle.Bottom) _position.Y--;
//                    return;
//                case Orientation.W:
//                    if (_position.X > rectangle.Left) _position.X--;
//                    return;
//            }
            var movePosition = CalculateMovePosition();
            if (polygon.Contains(movePosition)) _position = movePosition;
        }

        private Point CalculateMovePosition()
        {
            switch (Orientation)
            {
                case Orientation.N:
                    return new Point(_position.X, _position.Y + 1);
                case Orientation.E:
                    return new Point(_position.X + 1, _position.Y);
                case Orientation.S:
                    return new Point(_position.X, _position.Y - 1);
                default:
                    return new Point(_position.X - 1, _position.Y);
            }
        }

        public void TurnRight()
        {
            Orientation = Orientation == Orientation.W
                ? Orientation.N
                : Orientation + 1;
        }

        public void TurnLeft()
        {
            Orientation = Orientation == Orientation.N
                ? Orientation.W
                : Orientation - 1;
        }

        public bool IsWithinRegion(IPath polygon)
        {
            return polygon.Contains(_position);
//            return rectangle.IsOverlapping(_position);
        }

        public static Drone FromPosition(int x, int y, Orientation orientation)
        {
            return new Drone(new Point(x, y), Orientation.E);
        }
    }
}