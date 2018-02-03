using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Esbe.SG.CodingGame
{
    public class Parser
    {
        private readonly Dictionary<Predicate<int>, IParserLineHandler> _lineHandlers = new Dictionary<Predicate<int>, IParserLineHandler>
        {
            { line => line == 1, new BattlefieldLineHandler() },
            { line => line > 1 && line % 2 == 0, new DronePositionLineHandler() },
            { line => line > 1 && line % 2 == 1, new DroneMovementLineHandler() }
        };

        private IBattlefieldContext Parse(TextReader textReader)
        {
            BattlefieldContext battlefieldContext = new BattlefieldContext();
            string line;
            int lineNumber = 1;
            while ((line = textReader.ReadLine()) != null)
            {
                var number = lineNumber;
                var handler = _lineHandlers.FirstOrDefault(kv => kv.Key(number));
                handler.Value.Process(battlefieldContext, line);
                lineNumber++;
            }

            return battlefieldContext;
        }

        /// <summary>
        ///     Parses the string content and loads the battlefield context object. This response object can be resolved to execute
        ///     all drone movements.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">content</exception>
        public IBattlefieldContext ParseString([NotNull] string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using (var stringReader = new StringReader(content))
            {
                return Parse(stringReader);
            }
        }
    }
}