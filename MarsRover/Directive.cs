using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Directive
    {
        public Directive(params CommandKey[] commands)
        {
            Commands = commands;
        }
        public CommandKey[] Commands { get; }


        public static Directive Parse(string info)
        {
            var keys = new List<CommandKey>();
            var command = info.Trim();

            // fazla boşlukları al
            while (command.Contains(" ")) command = command.Replace(" ", "");

            var commandsArr = command.ToCharArray();
            foreach (var cmd in commandsArr)
            {
                if (!Enum.TryParse(typeof(CommandKey), cmd.ToString(), out var commandKey)) throw new Exception($"{cmd} komutu anlaşılamadı.");
                else keys.Add((CommandKey)commandKey);
            }

            return new Directive(keys.ToArray());
        }


        public static explicit operator Position(Directive directive)
        {
            return new Position(1, 1, DirectionKey.E);
        }
    }
}
