namespace Esbe.SG.CodingGame
{
    internal class DroneTurnRightHandler : IDroneMovementHandler
    {
        public void Process(IBattlefieldCreationContext battlefieldContext)
        {
            battlefieldContext.AddDroneCommand(new DroneTurnRightCommand());
        }
    }
}