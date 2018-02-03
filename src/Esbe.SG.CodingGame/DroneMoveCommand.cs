namespace Esbe.SG.CodingGame
{
    internal class DroneMoveCommand : IDroneCommand
    {
        /// <summary>
        ///     Commands the specified drone to perform a movement action.
        /// </summary>
        /// <param name="drone">The drone.</param>
        public void Process(IDrone drone)
        {
            drone.Move();
        }
    }
}