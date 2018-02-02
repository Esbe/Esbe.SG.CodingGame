using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.Primitives;
using SixLabors.Shapes;

namespace Esbe.SG.CodingGame
{
    public class Board
    {
        private readonly List<Tuple<Drone, string>> _drones = new List<Tuple<Drone, string>>();
        private readonly IPath _polygon;

        private Board(IPath polygon)
        {
            _polygon = polygon;
        }

        public void AddDrone(Drone drone, string movements)
        {
            if (!drone.IsWithinRegion(_polygon)) throw new InvalidOperationException("Drone not within rectangle.");
            _drones.Add(new Tuple<Drone, string>(drone, movements));
        }

        public void Resolve()
        {
            foreach (var drone in _drones) ApplyMovementWithin(drone, _polygon);
        }

        private void Apply(Drone drone, char movement, IPath polygon)
        {
            switch (movement)
            {
                case '>':
                    drone.TurnRight();
                    break;
                case '<':
                    drone.TurnLeft();
                    break;
                case '*':
                    drone.MoveWithin(polygon);
                    break;
                default: throw new InvalidOperationException($"Movement '{movement}' is not supported.");
            }
        }

        internal void ApplyMovementWithin(Tuple<Drone, string> drone, IPath polygon)
        {
            foreach (char movement in drone.Item2) Apply(drone.Item1, movement, polygon);
        }

        public static Board FromLTRB(int left, int top, int right, int bottom)
        {
            return new Board(new RectangularePolygon(RectangleF.FromLTRB(left, top, right, bottom)));
        }

        public void Print()
        {
            _drones.Select((x, index) => $"Drone {index}: {x.Item1.X} {x.Item1.Y} {x.Item1.Orientation}").ToList().ForEach(Console.WriteLine);
        }
    }
}