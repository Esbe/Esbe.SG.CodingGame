using System.Drawing;

namespace Esbe.SG.CodingGame
{
    public interface IPolygon
    {
        bool IsOverlapping(Point point);
    }
}