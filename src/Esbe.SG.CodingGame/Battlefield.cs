using System;
using System.Collections.Generic;
using System.Linq;

namespace Esbe.SG.CodingGame
{
    public class Battlefield
    {
        private readonly List<Tuple<Drone, string>> _drones = new List<Tuple<Drone, string>>();
        private readonly IPolygon _polygon;

        private Battlefield(IPolygon polygon)
        {
            _polygon = polygon;
        }

        public void AddDrone(Drone drone, string movements)
        {
            if (!drone.IsWithinPolygon(_polygon))
            {
                throw new InvalidOperationException("Drone not within polygon.");
            }

            _drones.Add(new Tuple<Drone, string>(drone, movements));
        }

        public void Resolve()
        {
            foreach (var drone in _drones)
            {
                ApplyMovementWithin(drone, _polygon);
            }
        }

        private void Apply(Drone drone, char movement, IPolygon polygon)
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

        internal void ApplyMovementWithin(Tuple<Drone, string> drone, IPolygon polygon)
        {
            foreach (char movement in drone.Item2)
            {
                Apply(drone.Item1, movement, polygon);
            }
        }

        public static Battlefield FromLTRB(int left, int top, int right, int bottom)
        {
            return new Battlefield(RectangularPolygon.FromLTRB(left, top, right, bottom));
        }

        public void Print()
        {
            _drones.Select((x, index) => $"Drone {index + 1}: {x.Item1.X} {x.Item1.Y} {x.Item1.Orientation}").ToList().ForEach(Console.WriteLine);
        }
    }
}