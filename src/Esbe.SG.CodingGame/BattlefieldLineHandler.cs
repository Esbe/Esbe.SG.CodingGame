using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal class BattlefieldLineHandler : IParserLineHandler
    {
        /// <summary>
        ///     Processes the specified line and loads the appropriate resources in the battlefield context.
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
            ValidatePositiveInteger(line, x, "first");
            var y = ValidateIntegerParameter(line, elements[1], "second");
            ValidatePositiveInteger(line, y, "second");

            var battlefield = RectangularBattlefieldArea.FromLTRB(0, 0, x, y);
            battlefieldContext.SetBattlefieldArea(battlefield);
        }

        [AssertionMethod]
        private static void ValidatePositiveInteger(string line, int value, string positionName)
        {
            if (value < 0)
            {
                throw new FormatException($"Invalid board configuration '{line}': {positionName} value is not a positive integer.");
            }
        }

        [AssertionMethod]
        private static int ValidateIntegerParameter(string line, string element, string positionName)
        {
            if (!int.TryParse(element, out int x))
            {
                throw new FormatException($"Invalid board configuration '{line}': {positionName} value is not an integer.");
            }

            return x;
        }

        [AssertionMethod]
        private static void ValidateElementsCount(string line, List<string> elements)
        {
            if (elements.Count != 2)
            {
                throw new FormatException($"Invalid board configuration '{line}': only two positive integer values must be provided.");
            }
        }
    }
}