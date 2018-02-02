using System.Drawing;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class RectangularPolygonTests
    {
        [Test]
        public void GivenAPointInsideRectangle_WhenValidatingIfIsOverlapping_ThenWillReturnTrue()
        {
            var rectangularPolygon = RectangularPolygon.FromLTRB(0, 0, 2, 2);
            var point = new Point(1, 1);

            Assert.That(rectangularPolygon.IsOverlapping(point), Is.True);
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(0, 1)]
        public void GivenAPointAtEdge_WhenValidatingIfIsOverlapping_ThenWillReturnTrue(int x, int y)
        {
            var rectangularPolygon = RectangularPolygon.FromLTRB(0, 0, 2, 2);
            var point = new Point(x, y);

            Assert.That(rectangularPolygon.IsOverlapping(point), Is.True);
        }

        [TestCase(1, -1)]
        [TestCase(3, 1)]
        [TestCase(1, 3)]
        [TestCase(-1, 1)]
        public void GivenAPointOutsideOfRectangle_WhenValidatingIfIsOverlapping_ThenWillReturnFalse(int x, int y)
        {
            var rectangularPolygon = RectangularPolygon.FromLTRB(0, 0, 2, 2);
            var point = new Point(x, y);

            Assert.That(rectangularPolygon.IsOverlapping(point), Is.False);
        }
    }
}