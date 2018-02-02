using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class OrientationHelperTests
    {
        [TestCase("N", Orientation.N)]
        [TestCase("E", Orientation.E)]
        [TestCase("S", Orientation.S)]
        [TestCase("W", Orientation.W)]
        public void GivenAValidOrientationAbbreviation_WhenTryingParse_ThenWillSetOrientationEnum(string value, Orientation expectedOrientation)
        {
            var wasParsed = OrientationHelper.TryParse(value, out Orientation orientation);

            Assert.That(wasParsed, Is.True);
            Assert.That(orientation, Is.EqualTo(expectedOrientation));
        }

        [TestCase("North", Orientation.N)]
        [TestCase("East", Orientation.E)]
        [TestCase("South", Orientation.S)]
        [TestCase("West", Orientation.W)]
        public void GivenAValidOrientationValue_WhenTryingParse_ThenWillSetOrientationEnum(string value, Orientation expectedOrientation)
        {
            var wasParsed = OrientationHelper.TryParse(value, out Orientation orientation);

            Assert.That(wasParsed, Is.True);
            Assert.That(orientation, Is.EqualTo(expectedOrientation));
        }
    }
}