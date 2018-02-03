using System;
using Moq;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class BattlefieldLineHandlerTests
    {
        private Mock<IBattlefieldCreationContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            _contextMock = new Mock<IBattlefieldCreationContext>();
        }

        [Test]
        public void GivenATopRightPointInPositiveQuadrant_WhenProcessing_ThenWillAddBoard()
        {
            var handler = new BattlefieldLineHandler();

            handler.Process(_contextMock.Object, "1 1");

            _contextMock.Verify(x => x.SetBattlefieldArea(It.IsNotNull<IBattlefieldArea>()));
        }

        [Test]
        public void GivenAValidConfigurationWithExtraWhitespaces_WhenProcessing_ThenWillAddBoard()
        {
            var handler = new BattlefieldLineHandler();

            handler.Process(_contextMock.Object, " 1  1 ");

            _contextMock.Verify(x => x.SetBattlefieldArea(It.IsNotNull<IBattlefieldArea>()));
        }

        [Test]
        public void GivenATopRightPointAtOrigin_WhenProcessing_ThenWillAddBoard()
        {
            var handler = new BattlefieldLineHandler();

            handler.Process(_contextMock.Object, "0 0");

            _contextMock.Verify(x => x.SetBattlefieldArea(It.IsNotNull<IBattlefieldArea>()));
        }

        [Test]
        public void GivenAnEmptyConfiguration_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new BattlefieldLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, ""), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerXPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new BattlefieldLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "a 0"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANegativeXPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new BattlefieldLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "-1 1"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANonIntegerYPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new BattlefieldLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "0 a"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void GivenANegativeYPosition_WhenProcessing_ThenWillThrowFormatException()
        {
            var handler = new BattlefieldLineHandler();

            Assert.That(() => handler.Process(_contextMock.Object, "1 -1"), Throws.InstanceOf<FormatException>());
        }
    }
}