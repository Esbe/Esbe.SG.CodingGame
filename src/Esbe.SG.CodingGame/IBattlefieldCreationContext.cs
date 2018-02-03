using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal interface IBattlefieldCreationContext
    {
        /// <summary>
        ///     Sets the battlefield area. If drones were already added to this context, their battlefield area will be updated and
        ///     re-validated.
        /// </summary>
        /// <param name="battlefieldArea">The battlefield area.</param>
        void SetBattlefieldArea([NotNull] IBattlefieldArea battlefieldArea);

        /// <summary>
        ///     Adds a drone to the context.
        /// </summary>
        /// <param name="drone">The drone.</param>
        void AddDrone([NotNull] IDrone drone);

        /// <summary>
        ///     Adds a drone command to the lastly added drone. This command will only be executed when a call to Resolve is made.
        /// </summary>
        /// <param name="command">The command.</param>
        void AddDroneCommand([NotNull] IDroneCommand command);
    }
}