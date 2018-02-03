using System;
using System.Collections.Generic;

namespace Esbe.SG.CodingGame
{
    internal class DroneMovementLineHandler : IParserLineHandler
    {
        private readonly Dictionary<char, IDroneMovementHandler> _movementHandlers = new Dictionary<char, IDroneMovementHandler>
        {
            { '>', new DroneTurnRightHandler() },
            { '<', new DroneTurnLeftHandler() },
            { '*', new DroneMoveHandler() }
        };

        /// <summary>
        ///     Processes the specified line by splitting it into characters, and then processing each one into a second command
        ///     handler pipeline.
        /// </summary>
        /// <param name="battlefieldContext">The battlefield context.</param>
        /// <param name="line">The parsed line.</param>
        /// <exception cref="FormatException"></exception>
        public void Process(IBattlefieldCreationContext battlefieldContext, string line)
        {
            foreach (var key in line)
            {
                if (!_movementHandlers.TryGetValue(key, out IDroneMovementHandler droneMovementHandler))
                {
                    throw new FormatException($"Invalid character '{key}' in line '{line}': only the characters {{{string.Join(", ", _movementHandlers.Keys)}}} are permitted.");
                }

                droneMovementHandler.Process(battlefieldContext);
            }
        }
    }
}