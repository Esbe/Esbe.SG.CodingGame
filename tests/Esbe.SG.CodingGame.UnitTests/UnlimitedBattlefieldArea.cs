using System.Drawing;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class UnlimitedBattlefieldAreaTests
    {
        [TestCase(0, 0)]
        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void GivenAnyPoint_WhenCheckingIfContains_ThenWillReturnTrue(int x, int y)
        {
            var battlefieldArea = new UnlimitedBattlefieldArea();

            Assert.That(battlefieldArea.Contains(new Point(x, y)), Is.True);
        }
    }
}