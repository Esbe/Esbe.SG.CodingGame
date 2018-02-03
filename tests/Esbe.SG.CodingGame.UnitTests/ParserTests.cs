using System;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class BoardParserTests
    {
        [Test]
        public void GivenANullContent_WhenParsing_ThenWillThrowArgumentNullException()
        {
            var parser = new Parser();

            Assert.That(() => parser.ParseString(null), Throws.InstanceOf<ArgumentNullException>());
        }
    }
}