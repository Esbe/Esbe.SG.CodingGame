using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal interface IDroneCommand
    {
        /// <summary>
        ///     Commands the specified drone to perform an action.
        /// </summary>
        /// <param name="drone">The drone.</param>
        void Process([NotNull] IDrone drone);
    }
}