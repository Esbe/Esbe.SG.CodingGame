using System;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DronePositionLineHandlerTests
    {
        private Mock<IBattlefieldCreationContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            _contextMock = new Mock<IBattlefieldCreationContext>();
        }

        [Test]
        public void GivenAValidConfiguration_WhenProcessing_ThenWillAddDrone()
        {
            var handler = new DronePositionLineHandler();

            handler.Process(_contextMock.Object, "0 0 N");

            _contextMock.Verify(x => x.AddDrone(It.IsNotNull<Drone>()), Times.Once());
        }

        [Test]
        public void GivenAValidConfigurationWithExtraWhitespaces_WhenProcessing_ThenWillAddDrone()
        {
            var handler = new DronePositionLineHandler();

            handler.Process(_contextMock.Object, " 1  1  N ");

            _contextMock.Verify(x => x.AddDrone(It.IsNotNull<Drone>()), Times.Once());
        }

        [Test]
        public void GivenANegativeXPosition_WhenProcessing_ThenWillAddDrone()
        {
            var handler = new DronePositionLineHandler();

            handler.Process(_contextMock.Object, "-1 0 N");

            _contextMock.Verify(x => x.AddDrone(It.IsNotNull<Drone>()), Times.Once());
        }

        [Test]
        public void GivenANegativeYPosition_WhenProcessing_ThenWillAddDrone()
        {
            var handler = new DronePositionLineHandler();

            handler.Process(_contextMock.Object, "0 -1 N");

            _contextMock.Verify(x => x.AddDrone(It.IsNotNull<Drone>()), Times.Once());
        }

        [Test]
        public void GivenAnEmptyConfiguration_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new DronePositionLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, ""), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerXPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new DronePositionLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "a 0 N"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerYPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new DronePositionLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "0 a N"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAnInvalidOrientation_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new DronePositionLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "0 0 X"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAnInvalidCasingOrientation_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new DronePositionLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "0 0 n"), Throws.InstanceOf<FormatException>());
        }
    }
}