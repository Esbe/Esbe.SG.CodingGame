using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneTurnRightHandlerTests
    {
        private Mock<IBattlefieldCreationContext> _battlefieldContextMock;

        [SetUp]
        public void SetUp()
        {
            _battlefieldContextMock = new Mock<IBattlefieldCreationContext>();
        }

        [Test]
        public void GivenAContext_WhenProcessing_ThenWillAddASingleDroneCommand()
        {
            var droneMoveHandler = new DroneTurnRightHandler();

            droneMoveHandler.Process(_battlefieldContextMock.Object);

            _battlefieldContextMock.Verify(x => x.AddDroneCommand(It.IsAny<DroneTurnRightCommand>()), Times.Once);
        }
    }
}