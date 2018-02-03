using System.IO;
using NUnit.Framework;

namespace Esbe.SG.CodingGame
{
    public class ParserTests
    {
        [Test]
        public void GivenAParsedAndResolvedTextContent_WhenPrinting_ThenWillCorrectlyResolve()
        {
            string content =
                @"5 5
1 1 N
>********<**********
1 2 N
<*<*<*<**
3 3 E
**>**>*>>*";
            var board = new Parser().ParseString(content);
            board.Resolve();
            var stringWriter = new StringWriter();

            board.Print(stringWriter);

            Assert.That(stringWriter.GetStringBuilder().ToString(), Is.EqualTo(@"5 5 N
1 3 N
5 1 E
"));
        }

        [Test]
        public void GivenADroneWithNoMovements_WhenParsing_ThenWillNotThrow()
        {
            string content =
                @"5 5
1 1 N";
            Assert.That(() => new Parser().ParseString(content), Throws.Nothing);
        }
    }
}