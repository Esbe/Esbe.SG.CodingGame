using System.Drawing;

namespace Esbe.SG.CodingGame
{
    internal interface IBattlefieldArea
    {
        /// <summary>
        ///     Determines whether this battlefield area contains the specified point. This also returns true if the point is
        ///     touching any of the area's edges.
        /// </summary>
        /// <param name="point">The point with coordinates x,y.</param>
        /// <returns>
        ///     <c>true</c> if the battlefield area contains the specified point; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(Point point);
    }
}