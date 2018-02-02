using System;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class ParserTests
    {
        [Test]
        public void GivenATopRightPointInPositiveQuadrant_WhenParsingBoard_ThenWillReturnABoard()
        {
            Assert.That(() => Parser.ParseBoard("1 1"), Is.Not.Null.And.InstanceOf<Battlefield>());
        }

        [Test]
        public void GivenAValidConfigurationWithExtraWhitespaces_WhenParsingBoard_ThenWillReturnABoard()
        {
            Assert.That(() => Parser.ParseBoard(" 1  1 "), Is.Not.Null.And.InstanceOf<Battlefield>());
        }

        [Test]
        public void GivenATopRightPointAtOrigin_WhenParsingBoard_ThenWillReturnABoard()
        {
            Assert.That(() => Parser.ParseBoard("0 0"), Is.Not.Null.And.InstanceOf<Battlefield>());
        }

        [Test]
        public void GivenAnEmptyConfiguration_WhenParsingBoard_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseBoard(""), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerXPosition_WhenParsingBoard_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseBoard("a 0"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANegativeXPosition_WhenParsingBoard_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseBoard("-1 1"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerYPosition_WhenParsingBoard_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseBoard("0 a"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANegativeYPosition_WhenParsingBoard_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseBoard("1 -1"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAValidConfiguration_WhenParsingDrone_ThenWillReturnADrone()
        {
            Assert.That(() => Parser.ParseDrone("0 0 N"), Is.Not.Null.And.InstanceOf<Drone>());
        }

        [Test]
        public void GivenAValidConfigurationWithExtraWhitespaces_WhenParsingDrone_ThenWillReturnADrone()
        {
            Assert.That(() => Parser.ParseDrone(" 1  1  N "), Is.Not.Null.And.InstanceOf<Drone>());
        }

        [Test]
        public void GivenANegativeXPosition_WhenParsingDrone_ThenWillReturnADrone()
        {
            Assert.That(() => Parser.ParseDrone("-1 0 N"), Is.Not.Null.And.InstanceOf<Drone>());
        }

        [Test]
        public void GivenANegativeYPosition_WhenParsingDrone_ThenWillReturnADrone()
        {
            Assert.That(() => Parser.ParseDrone("0 -1 N"), Is.Not.Null.And.InstanceOf<Drone>());
        }

        [Test]
        public void GivenAnEmptyConfiguration_WhenParsingDrone_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseDrone(""), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerXPosition_WhenParsingDrone_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseDrone("a 0 N"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerYPosition_WhenParsingDrone_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseDrone("0 a N"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAnInvalidOrientation_WhenParsingDrone_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseDrone("0 0 X"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAnInvalidCasingOrientation_WhenParsingDrone_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseDrone("0 0 n"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenAnEmptyLine_WhenParsingDroneMovement_ThenWillReturnDroneMovements()
        {
            Assert.That(() => Parser.ParseMovements(""), Is.Not.Null.And.InstanceOf<string>());
        }

        [Test]
        public void GivenALineWithExtraSpace_WhenParsingDroneMovement_ThenWillReturnDroneMovements()
        {
            Assert.That(() => Parser.ParseMovements(" "), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenALineWithValidCharacters_WhenParsingDroneMovement_ThenWillReturnDroneMovements()
        {
            Assert.That(() => Parser.ParseMovements("<<>>**<<>>**"), Is.Not.Null.And.InstanceOf<string>());
        }

        [Test]
        public void GivenALineWithAnInvalidCharacter_WhenParsingDroneMovement_ThenWillThrowFormatException()
        {
            Assert.That(() => Parser.ParseMovements("<<>>**A<<>>**"), Throws.InstanceOf<FormatException>());
        }
    }
}