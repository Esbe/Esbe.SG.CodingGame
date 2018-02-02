namespace Esbe.SG.CodingGame
{
    public struct OrientedPoint
    {
        public long X { get; private set; }
        public long Y { get; private set; }
        public Orientation Orientation { get; private set; }

        public OrientedPoint(long x, long y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

//        public void Apply(char movement)
//        {
//            switch (movement)
//            {
//                case '>':
//                    TurnRight();
//                    break;
//                case '<':
//                    TurnLeft();
//                    break;
//                case '*':
//                    Move();
//                    break;
//                default:
//                    throw new InvalidOperationException($"Movement '{movement}' is not supported.");
//            }
//        }

        public bool CanMoveWithin(long x, long y)
        {
            switch (Orientation)
            {
                case Orientation.North:
                    return Y < y;
                case Orientation.East:
                    return X < x;
                case Orientation.South:
                    return Y > 0;
                default:
                    return X > 0;
            }
        }

        public void Move()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    Y += 1;
                    break;
                case Orientation.East:
                    X += 1;
                    break;
                case Orientation.South:
                    Y -= 1;
                    break;
                case Orientation.West:
                    X -= 1;
                    break;
            }
        }

        public void TurnRight()
        {
            Orientation = Orientation == Orientation.West
                ? Orientation.North
                : Orientation + 1;

//            var orientation = ((int)Orientation + 1) % 4;
//            Orientation =(Orientation)orientation;

//            switch (Orientation)
//            {
//                case Orientation.North:
//                    Orientation = Orientation.East;
//                    break;
//                case Orientation.East:
//                    Orientation = Orientation.South;
//                    break;
//                case Orientation.South:
//                    Orientation = Orientation.West;
//                    break;
//                case Orientation.West:
//                    Orientation = Orientation.North;
//                    break;
//            }
        }

        public void TurnLeft()
        {
            Orientation = Orientation == Orientation.North
                ? Orientation.West
                : Orientation - 1;

//            if (Orientation == O)
//            var orientation = Orientation - 1;
//            Orientation = (int)orientation == -1 ? (Orientation)3 : orientation;

//            Orientation = (Orientation) (3 - (int) Orientation);
            //            switch (Orientation)
            //            {
            //                case Orientation.North:
            //                    Orientation = Orientation.West;
            //                    break;
            //                case Orientation.West:
            //                    Orientation = Orientation.South;
            //                    break;
            //                case Orientation.South:
            //                    Orientation = Orientation.East;
            //                    break;
            //                case Orientation.East:
            //                    Orientation = Orientation.North;
            //                    break;
            //            }
        }
    }
}