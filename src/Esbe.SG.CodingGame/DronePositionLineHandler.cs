using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal class DronePositionLineHandler : IParserLineHandler
    {
        /// <summary>
        ///     Processes the specified line and loads a drone at a position in the battlefield context.
        /// </summary>
        /// <param name="battlefieldContext">The battlefield context.</param>
        /// <param name="line">The parsed line.</param>
        /// <exception cref="FormatException">
        /// </exception>
        public void Process(IBattlefieldCreationContext battlefieldContext, string line)
        {
            var elements = line
                .Split(' ')
                .Where(element => !string.IsNullOrEmpty(element))
                .ToList();

            ValidateElementsCount(line, elements);
            var x = ValidateIntegerParameter(line, elements[0], "first");
            var y = ValidateIntegerParameter(line, elements[1], "second");
            var orientation = ValidateOrientationParameter(line, elements[2]);

            var drone = Drone.FromPosition(x, y, orientation);
            battlefieldContext.AddDrone(drone);
        }

        [AssertionMethod]
        private static Orientation ValidateOrientationParameter(string line, string element)
        {
            if (!Enum.TryParse(element, out Orientation orientation))
            {
                throw new FormatException($"Invalid drone configuration '{line}': third value must be a valid Orientation in {{{string.Join(", ", Enum.GetNames(typeof(Orientation)))}}}.");
            }

            return orientation;
        }

        [AssertionMethod]
        private static int ValidateIntegerParameter(string line, string element, string positionName)
        {
            if (!int.TryParse(element, out int x))
            {
                throw new FormatException($"Invalid drone configuration '{line}': {positionName} value must be an integer.");
            }

            return x;
        }

        [AssertionMethod]
        private static void ValidateElementsCount(string line, List<string> elements)
        {
            if (elements.Count != 3)
            {
                throw new FormatException($"Invalid drone configuration '{line}': only two integer values and an orientation must be provided.");
            }
        }
    }
}