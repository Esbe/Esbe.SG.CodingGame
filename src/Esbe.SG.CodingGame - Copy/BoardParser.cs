using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Esbe.SG.CodingGame
{
    public class BoardParser
    {
        private static Board Parse(TextReader textReader)
        {
            var boardConfigurationLine = textReader.ReadLine();
            var board = ParseBoard(boardConfigurationLine);
            string dronePositionLine;
            while ((dronePositionLine = textReader.ReadLine()) != null)
            {
                var drone = ParseDrone(dronePositionLine);
                var droneMovementLine = textReader.ReadLine();
                if (droneMovementLine == null) throw new FormatException("Missing movement line.");
                var movements = ParseMovements(droneMovementLine);
                board.AddDrone(drone, movements);
            }

            return board;
        }

        private static string ParseMovements(string droneMovementLine)
        {
            if (droneMovementLine.Except(new List<char> {'>', '<', '*'}).Any()) throw new FormatException();
            return droneMovementLine;
        }

        private static Drone ParseDrone(string dronePositionLine)
        {
            var elements = dronePositionLine.Split(' ');
            if (elements.Length != 3) throw new FormatException();
            if (!int.TryParse(elements[0], out int x)) throw new FormatException();
            if (!int.TryParse(elements[1], out int y)) throw new FormatException();
            if (!Enum.TryParse(elements[2], true, out Orientation orientation)) throw new FormatException();
            return Drone.FromPosition(x, y, orientation);
        }

        private static Board ParseBoard(string boardConfigurationLine)
        {
            var elements = boardConfigurationLine.Split(' ');
            if (elements.Length != 2) throw new FormatException();
            if (!int.TryParse(elements[0], out int x)) throw new FormatException();
            if (x < 0) throw new FormatException();
            if (!int.TryParse(elements[1], out int y)) throw new FormatException();
            if (y < 0) throw new FormatException();
            return Board.FromLTRB(0, 0, x, y);
        }

        public static Board ParseString(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                return Parse(stringReader);
            }
        }

        public static Board FromPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}