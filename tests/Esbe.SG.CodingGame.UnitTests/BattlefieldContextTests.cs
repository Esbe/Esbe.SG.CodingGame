using System;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class BattlefieldContextTests
    {
        private Mock<IBattlefieldArea> _battlefieldAreaMock;
        private Mock<IDroneCommand> _droneCommandMock;
        private Mock<IDrone> _droneMock;

        [SetUp]
        public void SetUp()
        {
            _battlefieldAreaMock = new Mock<IBattlefieldArea>();
            _droneMock = new Mock<IDrone>();
            _droneCommandMock = new Mock<IDroneCommand>();
        }

        [Test]
        public void GivenADroneInsideDefaultUnlimitedBattlefieldArea_WhenAddingDrone_ThenWillNotThrowAnyException()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(true);
            var battlefieldContext = new BattlefieldContext();

            Assert.That(() => battlefieldContext.AddDrone(_droneMock.Object), Throws.Nothing);
        }

        [Test]
        public void GivenAnUnsetBattlefieldArea_WhenAddingDrone_ThenWillAssignUnlimitedBattlefieldArea()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(true);
            var battlefieldContext = new BattlefieldContext();

            battlefieldContext.AddDrone(_droneMock.Object);

            _droneMock.Verify(x => x.SetBattlefieldArea(It.IsAny<UnlimitedBattlefieldArea>()), Times.Once);
        }

        [Test]
        public void GivenASettedBattlefieldArea_WhenAddingDrone_ThenWillAssignBattlefieldArea()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(true);
            var battlefieldContext = new BattlefieldContext();
            battlefieldContext.SetBattlefieldArea(_battlefieldAreaMock.Object);

            battlefieldContext.AddDrone(_droneMock.Object);

            _droneMock.Verify(x => x.SetBattlefieldArea(_battlefieldAreaMock.Object), Times.Once);
        }

        [Test]
        public void GivenAnInsertedDrone_WhenUpdatingBattlefieldArea_ThenWillSetBattlefieldAreaOfDrone()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(true);
            var battlefieldContext = new BattlefieldContext();
            battlefieldContext.AddDrone(_droneMock.Object);

            battlefieldContext.SetBattlefieldArea(_battlefieldAreaMock.Object);

            _droneMock.Verify(x => x.SetBattlefieldArea(_battlefieldAreaMock.Object), Times.Once);
        }

        [Test]
        public void GivenAnInsertedDroneOutsideOfFutureArea_WhenUpdatingBattlefieldArea_ThenWillThrowInvalidOperationException()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(true);
            var battlefieldContext = new BattlefieldContext();
            battlefieldContext.AddDrone(_droneMock.Object);
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(false);

            Assert.That(() => battlefieldContext.SetBattlefieldArea(_battlefieldAreaMock.Object), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void GivenADroneOutsideOfBattlefieldArea_WhenAddingDrone_ThenWillThrowInvalidOperationException()
        {
            _droneMock.Setup(x => x.IsInBattlefieldArea()).Returns(false);
            var battlefieldContext = new BattlefieldContext();

            Assert.That(() => battlefieldContext.AddDrone(_droneMock.Object), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void GivenNoAddedDrones_WhenAddingDroneCommand_ThenWillThrowInvalidOperationException()
        {
            var battlefieldContext = new BattlefieldContext();

            Assert.That(() => battlefieldContext.AddDroneCommand(_droneCommandMock.Object), Throws.InstanceOf<InvalidOperationException>());
        }
    }
}