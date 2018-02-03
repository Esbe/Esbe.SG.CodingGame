using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneTurnRightCommandTests
    {
        private Mock<IDrone> _droneMock;

        [SetUp]
        public void SetUp()
        {
            _droneMock = new Mock<IDrone>();
        }

        [Test]
        public void GivenADroneTurnRightCommand_WhenProcessing_ThenWillCallTurnRightOnce()
        {
            var droneTurnLeftCommand = new DroneTurnRightCommand();

            droneTurnLeftCommand.Process(_droneMock.Object);

            _droneMock.Verify(x => x.TurnRight(), Times.Once);
        }
    }
}