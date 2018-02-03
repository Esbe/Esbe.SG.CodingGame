using System.Drawing;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    internal class DroneTests
    {
        private static readonly Point AnyPosition = new Point(0, 0);
        private static readonly Point OriginPoint = new Point(0, 0);
        private Mock<IBattlefieldArea> _battlefieldAreaMock;

        [SetUp]
        public void SetUp()
        {
            _battlefieldAreaMock = new Mock<IBattlefieldArea>();
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
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnEastOrientation_WhenMovingOutsideOfPolygon_ThenWillNotIncreaseX()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenAnEastOrientation_WhenMoving_ThenWillNotChangeYValue()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.E);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenAWestOrientation_WhenMovingWithinPolygon_ThenWillDecreaseXBy1()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(-1));
        }

        [Test]
        public void GivenAWestOrientation_WhenMovingOutsideOfPolygon_ThenWillNotDecreaseX()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenAWestOrientation_WhenMoving_ThenWillNotChangeYValue()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.W);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenANorthOrientation_WhenMovingWithinPolygon_ThenWillIncreaseYBy1()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(1));
        }

        [Test]
        public void GivenANorthOrientation_WhenMovingOutsideOfPolygon_ThenWillNotIncreaseY()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenANorthOrientation_WhenMoving_ThenWillNotChangeXValue()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(0));
        }

        [Test]
        public void GivenASouthOrientation_WhenMovingWithinPolygon_ThenWillDecreaseYBy1()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.S);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(-1));
        }

        [Test]
        public void GivenASouthOrientation_WhenMovingOutsideOfPolygon_ThenWillNotDecreaseY()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(false);
            var drone = Drone.FromPoint(OriginPoint, Orientation.S);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenASouthOrientation_WhenMoving_ThenWillNotChangeXValue()
        {
            _battlefieldAreaMock.Setup(x => x.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(OriginPoint, Orientation.N);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(0));
        }

        [TestCase(0, int.MaxValue, Orientation.N)]
        [TestCase(int.MaxValue, 0, Orientation.E)]
        [TestCase(0, int.MinValue, Orientation.S)]
        [TestCase(int.MinValue, 0, Orientation.W)]
        public void GivenAPointAtInt32LimitValue_WhenMoving_ThenWillNotChangeValue(int x, int y, Orientation orientation)
        {
            _battlefieldAreaMock.Setup(p => p.Contains(It.IsAny<Point>())).Returns(true);
            var drone = Drone.FromPoint(new Point(x, y), orientation);
            drone.SetBattlefieldArea(_battlefieldAreaMock.Object);

            drone.Move();

            Assert.That(drone.Point.X, Is.EqualTo(x));
            Assert.That(drone.Point.Y, Is.EqualTo(y));
        }

        [Test]
        public void GivenADrone_WhenConvertingToString_ThenWillBeInExpectedFormat()
        {
            var drone = Drone.FromPoint(new Point(1, 2), Orientation.N);

            var stringValue = drone.ToString();

            Assert.That(stringValue, Is.EqualTo("1 2 N"));
        }
    }
}