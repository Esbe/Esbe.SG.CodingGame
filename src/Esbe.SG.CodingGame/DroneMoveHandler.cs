namespace Esbe.SG.CodingGame
{
    internal class DroneMoveHandler : IDroneMovementHandler
    {
        /// <summary>
        ///     Processes and loads the appropriate movements in the battlefield context.
        /// </summary>
        /// <param name="battlefieldContext">The battlefield context.</param>
        public void Process(IBattlefieldCreationContext battlefieldContext)
        {
            battlefieldContext.AddDroneCommand(new DroneMoveCommand());
        }
    }
}