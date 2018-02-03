using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Esbe.SG.CodingGame
{
    internal class BattlefieldContext : IBattlefieldCreationContext, IBattlefieldContext
    {
        private readonly List<Tuple<IDrone, Queue<IDroneCommand>>> _dronesAndCommands = new List<Tuple<IDrone, Queue<IDroneCommand>>>();
        private IBattlefieldArea _battlefieldArea = new UnlimitedBattlefieldArea();

        /// <summary>
        ///     Resolves the commands to process for each drone.
        /// </summary>
        public void Resolve()
        {
            // This can be moved into a strategy
            foreach (var droneAndCommands in _dronesAndCommands)
            {
                while (droneAndCommands.Item2.Count > 0)
                {
                    var command = droneAndCommands.Item2.Dequeue();
                    command.Process(droneAndCommands.Item1);
                }
            }
        }

        /// <summary>
        ///     Prints the current battlefield context to the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void Print(TextWriter textWriter)
        {
            _dronesAndCommands
                .Select(x => x.Item1)
                .ToList()
                .ForEach(textWriter.WriteLine);
        }

        /// <summary>
        ///     Sets the battlefield area. If drones were already added to this context, their battlefield area will be updated and
        ///     re-validated.
        /// </summary>
        /// <param name="battlefieldArea">The battlefield area.</param>
        public void SetBattlefieldArea(IBattlefieldArea battlefieldArea)
        {
            _battlefieldArea = battlefieldArea;
            foreach (var drone in _dronesAndCommands.Select(x => x.Item1))
            {
                AssociateBattlefieldAreaAndValidate(drone);
            }
        }

        /// <summary>
        ///     Adds a drone to the context.
        /// </summary>
        /// <param name="drone">The drone.</param>
        public void AddDrone(IDrone drone)
        {
            AssociateBattlefieldAreaAndValidate(drone);
            _dronesAndCommands.Add(new Tuple<IDrone, Queue<IDroneCommand>>(drone, new Queue<IDroneCommand>()));
        }

        /// <summary>
        ///     Adds a drone command to the lastly added drone. This command will only be executed when a call to Resolve is made.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="System.InvalidOperationException">No drones have been added yet.</exception>
        public void AddDroneCommand(IDroneCommand command)
        {
            var lastDroneAndCommands = _dronesAndCommands.LastOrDefault();
            if (lastDroneAndCommands == null)
            {
                throw new InvalidOperationException("No drones have been added yet.");
            }

            lastDroneAndCommands.Item2.Enqueue(command);
        }

        /// <summary>
        ///     Associates the drone to the battlefield area and validates that it is inside of it.
        /// </summary>
        /// <param name="drone">The drone.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        private void AssociateBattlefieldAreaAndValidate(IDrone drone)
        {
            drone.SetBattlefieldArea(_battlefieldArea);
            if (!drone.IsInBattlefieldArea())
            {
                throw new InvalidOperationException($"Drone '{drone}' not within battlefield area {_battlefieldArea}.");
            }
        }
    }
}