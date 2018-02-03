using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    internal interface IParserLineHandler
    {
        /// <summary>
        ///     Processes the specified line and loads the appropriate resources in the battlefield context.
        /// </summary>
        /// <param name="battlefieldContext">The battlefield context.</param>
        /// <param name="line">The parsed line.</param>
        void Process([NotNull] IBattlefieldCreationContext battlefieldContext, [NotNull] string line);
    }
}