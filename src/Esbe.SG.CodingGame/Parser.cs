using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Esbe.SG.CodingGame
{
    public class Parser
    {
        private static Battlefield Parse(TextReader textReader)
        {
            var boardConfigurationLine = textReader.ReadLine();
            var board = ParseBoard(boardConfigurationLine);
            ParseDrones(textReader, board);
            return board;
        }

        private static void ParseDrones(TextReader textReader, Battlefield board)
        {
            string droneConfigurationLine;
            while ((droneConfigurationLine = textReader.ReadLine()) != null)
            {
                var drone = ParseDrone(droneConfigurationLine);
                var droneMovementLine = textReader.ReadLine();
                if (droneMovementLine == null)
                {
                    throw new FormatException("Missing movement line.");
                }

                var movements = ParseMovements(droneMovementLine);
                board.AddDrone(drone, movements);
            }
        }

        internal static string ParseMovements(string droneMovementLine)
        {
            if (droneMovementLine.Except(new List<char> { '>', '<', '*' }).Any())
            {
                throw new FormatException($"Invalid drone movement '{droneMovementLine}': only the characters {{'>', '<', '*'}} are permitted.");
            }

            return droneMovementLine;
        }

        internal static Drone ParseDrone(string droneConfigurationLine)
        {
            var elements = droneConfigurationLine
                .Split(' ')
                .Where(element => !string.IsNullOrEmpty(element))
                .ToList();
            if (elements.Count != 3)
            {
                throw new FormatException($"Invalid drone configuration '{droneConfigurationLine}': only two integer values and an orientation must be provided.");
            }

            if (!int.TryParse(elements[0], out int x))
            {
                throw new FormatException($"Invalid drone configuration '{droneConfigurationLine}': first value must be an integer.");
            }

            if (!int.TryParse(elements[1], out int y))
            {
                throw new FormatException($"Invalid drone configuration '{droneConfigurationLine}': second value must be an integer.");
            }

            if (!Enum.TryParse(elements[2], out Orientation orientation))
            {
                throw new FormatException($"Invalid drone configuration '{droneConfigurationLine}': third value must be a valid Orientation in {{'N', 'E', 'S', 'W'}}.");
            }

            return Drone.FromPosition(x, y, orientation);
        }

        internal static Battlefield ParseBoard(string boardConfigurationLine)
        {
            var elements = boardConfigurationLine
                .Split(' ')
                .Where(element => !string.IsNullOrEmpty(element))
                .ToList();
            if (elements.Count != 2)
            {
                throw new FormatException($"Invalid board configuration '{boardConfigurationLine}': only two positive integer values must be provided.");
            }

            if (!int.TryParse(elements[0], out int x))
            {
                throw new FormatException($"Invalid board configuration '{boardConfigurationLine}': first value is not an integer.");
            }

            if (x < 0)
            {
                throw new FormatException($"Invalid board configuration '{boardConfigurationLine}': first value is not a positive integer.");
            }

            if (!int.TryParse(elements[1], out int y))
            {
                throw new FormatException($"Invalid board configuration '{boardConfigurationLine}': second value is not an integer.");
            }

            if (y < 0)
            {
                throw new FormatException($"Invalid board configuration '{boardConfigurationLine}': second value is not a positive integer.");
            }

            return Battlefield.FromLTRB(0, 0, x, y);
        }

        public static Battlefield ParseString(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                return Parse(stringReader);
            }
        }

        public static Battlefield FromPath(string path)
        {
            throw new NotImplementedException();
        }
    }

    public interface IParserLineHandler
    {
        void Process(IContext context, string line);
    }

    public class BattlefieldLineHandler : IParserLineHandler
    {
        public void Process(IContext context, string line)
        {
            var elements = line
                .Split(' ')
                .Where(element => !string.IsNullOrEmpty(element))
                .ToList();

            if (elements.Count != 2)
            {
                throw new FormatException($"Invalid board configuration '{line}': only two positive integer values must be provided.");
            }

            if (!int.TryParse(elements[0], out int x))
            {
                throw new FormatException($"Invalid board configuration '{line}': first value is not an integer.");
            }

            if (x < 0)
            {
                throw new FormatException($"Invalid board configuration '{line}': first value is not a positive integer.");
            }

            if (!int.TryParse(elements[1], out int y))
            {
                throw new FormatException($"Invalid board configuration '{line}': second value is not an integer.");
            }

            if (y < 0)
            {
                throw new FormatException($"Invalid board configuration '{line}': second value is not a positive integer.");
            }

            var battlefield = Battlefield.FromLTRB(0, 0, x, y);
            context.AddBattlefield(battlefield);
        }
    }

    public class DronePositionLineHandler : IParserLineHandler
    {
        public void Process(IContext context, string line)
        {
            var elements = line
                .Split(' ')
                .Where(element => !string.IsNullOrEmpty(element))
                .ToList();

            if (elements.Count != 3)
            {
                throw new FormatException($"Invalid drone configuration '{line}': only two integer values and an orientation must be provided.");
            }

            if (!int.TryParse(elements[0], out int x))
            {
                throw new FormatException($"Invalid drone configuration '{line}': first value must be an integer.");
            }

            if (!int.TryParse(elements[1], out int y))
            {
                throw new FormatException($"Invalid drone configuration '{line}': second value must be an integer.");
            }

            if (!Enum.TryParse(elements[2], out Orientation orientation))
            {
                throw new FormatException($"Invalid drone configuration '{line}': third value must be a valid Orientation in {{'N', 'E', 'S', 'W'}}.");
            }

            var drone = Drone.FromPosition(x, y, orientation);
            context.AddDrone(drone);
        }
    }

    public class DroneMovementLineHandler : IParserLineHandler
    {
        private readonly Dictionary<char, IDroneMovementHandler> _movementHandlers = new Dictionary<char, IDroneMovementHandler>
        {
            { '>', new DroneTurnRightHandler() },
            { '<', new DroneTurnLeftHandler() },
            { '*', new DroneMoveHandler() }
        };
        public void Process(IContext context, string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            foreach (var key in line)
            {
                if(!_movementHandlers.TryGetValue(key, out IDroneMovementHandler droneMovementHandler))
                {
                    throw new FormatException($"Invalid character '{key}' in line '{line}': only the characters {{{string.Join(", ", _movementHandlers.Keys)}}} are permitted.");
                }
                droneMovementHandler.Process(context);
            }
        }
    }

    public interface IDroneMovementHandler
    {
        void Process(IContext context);
    }

    public class DroneTurnRightHandler : IDroneMovementHandler
    {

        public void Process(IContext context)
        {
            context.AddDroneCommand(new DroneTurnRightCommand());
        }
    }

    public class DroneTurnLeftHandler : IDroneMovementHandler
    {

        public void Process(IContext context)
        {
            context.AddDroneCommand(new DroneTurnLeftCommand());
        }
    }

    public class DroneMoveHandler : IDroneMovementHandler
    {

        public void Process(IContext context)
        {
            context.AddDroneCommand(new DroneMoveCommand());
        }
    }


    public interface IContext
    {
        void AddBattlefield(Battlefield battlefield);
        void AddDrone(Drone drone);
        void AddDroneCommand(IDroneCommand command);
    }

    public interface IDroneCommand
    {
        void Process(Drone drone);
    }

    public class DroneTurnRightCommand : IDroneCommand
    {
        public void Process(Drone drone)
        {
            drone.TurnRight();
        }
    }
    public class DroneTurnLeftCommand : IDroneCommand
    {
        public void Process(Drone drone)
        {
            drone.TurnLeft();
        }
    }
    public class DroneMoveCommand : IDroneCommand
    {
        public void Process(Drone drone)
        {
            drone.Move();
        }
    }

    public class Parser2
    {
        private readonly Dictionary<Predicate<int>, IParserLineHandler> _lineHandlers = new Dictionary<Predicate<int>, IParserLineHandler>
        {
            { line => line == 1, new BattlefieldLineHandler() },
            { line => line > 1 && line % 2 == 0, new DronePositionLineHandler() },
            { line => line > 1 && line % 2 == 1, new DroneMovementLineHandler() }
        };

        private IContext Parse(TextReader textReader)
        {
            IContext context = null;
            string line;
            int lineNumber = 1;
            while ((line = textReader.ReadLine()) != null)
            {
                var number = lineNumber;
                var handler = _lineHandlers.FirstOrDefault(kv => kv.Key(number));
                handler.Value.Process(context, line);
                lineNumber++;
            }
            return context;
        }

        public IContext ParseString(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                return Parse(stringReader);
            }
        }
    }
}