using System;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class BoardParserTests
    {
        [Test]
        public void GivenAParsedAndResolvedTextContent_WhenPrinting_ThenWillNotThrow()
        {
            string content =
                @"5 5
1 1 N
>********<**********
1 2 N
<*<*<*<**
3 3 E
**>**>*>>*";
            var board = Parser.ParseString(content);
            board.Resolve();

            Assert.That(() => board.Print(), Throws.Nothing);
        }

        [Test]
        public void GivenADroneWithNoMovements_WhenParsing_ThenWillThrowFormatException()
        {
            string content =
                @"5 5
1 1 N";
            Assert.That(() => Parser.ParseString(content), Throws.InstanceOf<FormatException>());
        }
    }
}