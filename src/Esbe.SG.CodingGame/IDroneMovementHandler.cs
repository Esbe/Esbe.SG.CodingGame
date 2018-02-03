using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal interface IDroneMovementHandler
    {
        /// <summary>
        ///     Processes and loads the appropriate movements in the battlefield context.
        /// </summary>
        /// <param name="battlefieldContext">The battlefield context.</param>
        void Process([NotNull] IBattlefieldCreationContext battlefieldContext);
    }
}