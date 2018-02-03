using System.Drawing;

namespace Esbe.SG.CodingGame
{
    internal class UnlimitedBattlefieldArea : IBattlefieldArea
    {
        /// <summary>
        /// Determines whether this battlefield area contains the specified point, which with this object is always.
        /// </summary>
        /// <param name="point">The point with coordinates x,y.</param>
        /// <returns>
        ///   <c>true</c> if the battlefield area contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Point point)
        {
            return true;
        }
    }
}