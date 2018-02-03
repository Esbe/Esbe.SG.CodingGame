using System.Collections.Generic;
using System.Drawing;

namespace Esbe.SG.CodingGame
{
    internal enum Orientation
    {
        N = 0, // North
        E = 1, // East
        S = 2, // South
        W = 3 // West
    }

    internal static class OrientationExtensions
    {
        private static readonly Dictionary<Orientation, Size> OrientationSizes = new Dictionary<Orientation, Size>
        {
            { Orientation.N, new Size(0, 1) },
            { Orientation.E, new Size(1, 0) },
            { Orientation.S, new Size(0, -1) },
            { Orientation.W, new Size(-1, 0) }
        };

        public static Orientation Right90Degrees(this Orientation orientation)
        {
            return orientation == Orientation.W
                ? Orientation.N
                : orientation + 1;
        }

        public static Orientation Left90Degrees(this Orientation orientation)
        {
            return orientation == Orientation.N
                ? Orientation.W
                : orientation - 1;
        }

        public static Size Size(this Orientation orientation)
        {
            return OrientationSizes[orientation];
        }
    }
}