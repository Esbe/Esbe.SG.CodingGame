using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SixLabors.Primitives;

namespace Prototype
{
    public class Class1
    {
        [Test]
        public void GWT()
        {
            var polygon = new SixLabors.Shapes.RectangularePolygon(0, 0, 2, 2);
            Assert.That(polygon.Contains(new PointF(0.01f, 0.01f)), Is.True);
            Assert.That(polygon.Contains(new PointF(0, 0)), Is.True);
            Assert.That(polygon.Contains(new PointF(2, 0)), Is.True);
            Assert.That(polygon.Contains(new PointF(0, 2)), Is.True);
            Assert.That(polygon.Contains(new PointF(2, 2)), Is.True);
            Assert.That(polygon.Contains(new PointF(2.01f, 2)), Is.False);
        }

    }
}
