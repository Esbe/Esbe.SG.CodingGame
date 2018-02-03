namespace Esbe.SG.CodingGame
{
    internal class DroneTurnRightCommand : IDroneCommand
    {
        public void Process(IDrone drone)
        {
            drone.TurnRight();
        }
    }
}