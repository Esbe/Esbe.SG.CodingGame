namespace Esbe.SG.CodingGame
{
    internal class DroneTurnLeftCommand : IDroneCommand
    {
        public void Process(IDrone drone)
        {
            drone.TurnLeft();
        }
    }
}