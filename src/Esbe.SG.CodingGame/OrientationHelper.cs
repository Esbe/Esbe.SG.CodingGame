using System;

namespace Esbe.SG.CodingGame
{
    public static class OrientationHelper
    {
        public static bool TryParse(string value, out Orientation orientation)
        {
            switch (value.Trim())
            {
                case "N":
                    orientation = Orientation.N;
                    return true;
                case "E":
                    orientation = Orientation.E;
                    return true;
                case "S":
                    orientation = Orientation.S;
                    return true;
                case "W":
                    orientation = Orientation.W;
                    return true;
                default:
                    return Enum.TryParse(value, out orientation);
            }
        }
    }
}