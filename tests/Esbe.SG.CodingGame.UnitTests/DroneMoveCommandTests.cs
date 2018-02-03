using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneMoveCommandTests
    {
        private Mock<IDrone> _droneMock;

        [SetUp]
        public void SetUp()
        {
            _droneMock = new Mock<IDrone>();
        }

        [Test]
        public void GivenADroneMoveCommand_WhenProcessing_ThenWillCallMoveOnce()
        {
            var droneMoveCommand = new DroneMoveCommand();

            droneMoveCommand.Process(_droneMock.Object);

            _droneMock.Verify(x => x.Move(), Times.Once);
        }
    }
}