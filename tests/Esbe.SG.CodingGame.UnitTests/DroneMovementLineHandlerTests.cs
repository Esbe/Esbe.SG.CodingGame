using System;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class DroneMovementLineHandlerTests
    {
        private Mock<IBattlefieldCreationContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            _contextMock = new Mock<IBattlefieldCreationContext>();
        }

        [Test]
        public void GivenAnEmptyLine_WhenProcessing_ThenWillNotAddDroneCommands()
        {
            var handler = new DroneMovementLineHandler();

            handler.Process(_contextMock.Object, "");

            _contextMock.Verify(x => x.AddDroneCommand(It.IsAny<IDroneCommand>()), Times.Never);
        }

        [Test]
        public void GivenALineWithValidCharacters_WhenProcessing_ThenWillAddDroneCommands()
        {
            var handler = new DroneMovementLineHandler();
            var commands = "<<>>**<<>>**";

            handler.Process(_contextMock.Object, commands);

            _contextMock.Verify(x => x.AddDroneCommand(It.IsNotNull<IDroneCommand>()), Times.Exactly(commands.Length));
        }

        [Test]
        public void GivenALineWithExtraSpace_WhenParsingDroneMovement_ThenWillReturnDroneMovements()
        {
            var handler = new DroneMovementLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, " "), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenALineWithAnInvalidCharacter_WhenParsingDroneMovement_ThenWillThrowFormatException()
        {
            var handler = new DroneMovementLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "<<>>**A<<>>**"), Throws.InstanceOf<FormatException>());
        }
    }
}