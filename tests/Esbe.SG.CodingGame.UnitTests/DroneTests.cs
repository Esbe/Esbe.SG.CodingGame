using System.Drawing;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneTests
    {
        private static readonly Point AnyPosition = new Point(0, 0);
        private static readonly Point OriginPoint = new Point(0, 0);
        private Mock<IPolygon> _polygonMock;

        [SetUp]
        public void SetUp()
        {
            _polygonMock = new Mock<IPolygon>();
        }

        [TestCase(Orientation.N, Orientation.E)]
        [TestCase(Orientation.E, Orientation.S)]
        [TestCase(Orientation.S, Orientation.W)]
        [TestCase(Orientation.W, Orientation.N)]
        public void GivenAnInitialOrientation_WhenTurningRight_ThenWillBeInExpectedOrientation(
            Orientation initialOrientation, Orientation expectedOrientation)
        {
            var point = Drone.FromPoint(AnyPosition, initialOrientation);

            point.TurnRight();

            Assert.That(point.Orientation, Is.EqualTo(expectedOrientation));
        }

        [TestCase(Orientation.N, Orientation.W)]
        [TestCase(Orientation.W, Orientation.S)]
        [TestCase(Orientation.S, Orientation.E)]
        [TestCase(Orientation.E, Orientation.N)]
        public void GivenAnInitialOrientation_WhenTurningLeft_ThenWillPointInExpectedOrientation(
            Orientation initialOrientation, Orientation expectedOrientation)
        {
            var point = Drone.FromPoint(AnyPosition, initialOrientation);

            point.TurnLeft();

            Assert.That(point.Orientation, Is.EqualTo(expectedOrientation));
        }

        [Test]
        public void GivenAnEastOrientation_WhenMovingWithinPolygon_ThenWillIncreaseXBy1()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnEastOrientation_WhenMovingOutsideOfPolygon_ThenWillNotIncreaseX()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenAnEastOrientation_WhenMoving_ThenWillNotChangeYValue()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenAWestOrientation_WhenMovingWithinPolygon_ThenWillDecreaseXBy1()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(-1));
        }

        [Test]
        public void GivenAWestOrientation_WhenMovingOutsideOfPolygon_ThenWillNotDecreaseX()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenAWestOrientation_WhenMoving_ThenWillNotChangeYValue()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenANorthOrientation_WhenMovingWithinPolygon_ThenWillIncreaseYBy1()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(1));
        }

        [Test]
        public void GivenANorthOrientation_WhenMovingOutsideOfPolygon_ThenWillNotIncreaseY()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenANorthOrientation_WhenMoving_ThenWillNotChangeXValue()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenASouthOrientation_WhenMovingWithinPolygon_ThenWillDecreaseYBy1()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.S);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(-1));
        }

        [Test]
        public void GivenASouthOrientation_WhenMovingOutsideOfPolygon_ThenWillNotDecreaseY()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.S);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenASouthOrientation_WhenMoving_ThenWillNotChangeXValue()
        {
            _polygonMock.Setup(x => x.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(0));
        }

        [TestCase(0, int.MaxValue, Orientation.N)]
        [TestCase(int.MaxValue, 0, Orientation.E)]
        [TestCase(0, int.MinValue, Orientation.S)]
        [TestCase(int.MinValue, 0, Orientation.W)]
        public void GivenAPointAtInt32LimitValue_WhenMoving_ThenWillNotChangeValue(int x, int y, Orientation orientation)
        {
            _polygonMock.Setup(p => p.IsOverlapping(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(new Point(x, y), orientation);

            drone.MoveWithin(_polygonMock.Object);

            Assert.That(drone.X, Is.EqualTo(x));
            Assert.That(drone.Y, Is.EqualTo(y));
        }
    }
}