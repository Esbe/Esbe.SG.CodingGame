using System;

namespace Esbe.SG.CodingGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new Parser();
            var context = parser.ParseString(@"5 5
1 1 N
>********<**********
1 2 N
<*<*<*<**
3 3 E
**>**>*>>*");
            context.Resolve();
            context.Print(Console.Out);

            Console.ReadLine();
        }
    }
}