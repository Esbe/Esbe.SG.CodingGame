using System.IO;
using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    public interface IBattlefieldContext
    {
        /// <summary>
        ///     Resolves the commands to process for each drone.
        /// </summary>
        void Resolve();

        /// <summary>
        ///     Prints the current battlefield context to the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        void Print([NotNull] TextWriter textWriter);
    }
}