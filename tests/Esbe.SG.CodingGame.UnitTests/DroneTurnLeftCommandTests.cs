using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneTurnLeftCommandTests
    {
        private Mock<IDrone> _droneMock;

        [SetUp]
        public void SetUp()
        {
            _droneMock = new Mock<IDrone>();
        }

        [Test]
        public void GivenADroneTurnLeftCommand_WhenProcessing_ThenWillCallTurnLeftOnce()
        {
            var droneTurnLeftCommand = new DroneTurnLeftCommand();

            droneTurnLeftCommand.Process(_droneMock.Object);

            _droneMock.Verify(x => x.TurnLeft(), Times.Once);
        }
    }
}