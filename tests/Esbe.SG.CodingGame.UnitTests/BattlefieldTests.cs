using System;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class BattlefieldTests
    {
        private readonly string AnyMovements = "";

        [Test]
        public void GivenADroneInsideOfBoard_WhenAddingDrone_ThenWillNotThrowAnyException()
        {
            var drone = Drone.FromPosition(1, 1, Orientation.E);
            var board = Battlefield.FromLTRB(0, 0, 10, 10);

            Assert.That(() => board.AddDrone(drone, AnyMovements), Throws.Nothing);
        }

        [Test]
        public void GivenADroneOutsideOfBoard_WhenAddingDrone_ThenWillThrowInvalidOperationException()
        {
            var drone = Drone.FromPosition(1, 1, Orientation.E);
            var board = Battlefield.FromLTRB(0, 0, 0, 0);

            Assert.That(() => board.AddDrone(drone, AnyMovements), Throws.InstanceOf<InvalidOperationException>());
        }
    }
}