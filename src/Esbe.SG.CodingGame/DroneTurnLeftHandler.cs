namespace Esbe.SG.CodingGame
{
    internal class DroneTurnLeftHandler : IDroneMovementHandler
    {
        public void Process(IBattlefieldCreationContext battlefieldContext)
        {
            battlefieldContext.AddDroneCommand(new DroneTurnLeftCommand());
        }
    }
}