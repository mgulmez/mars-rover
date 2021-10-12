using System;
using System.Collections.Generic;

namespace MarsRover
{
    /// <summary>
    /// Bir veya daha çok komut içeren pakettir.
    /// </summary>
    public class CommandPackage
    {
        public CommandPackage(params CommandKey[] commands)
        {
            Commands = commands;
        }
        public CommandKey[] Commands { get; }


        public static CommandPackage Parse(string info)
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

            return new CommandPackage(keys.ToArray());
        }



        public Position ComputePosition(Position position)
        {

            var currentPos = position; // Başlangıç Pozisyonu
            foreach (var command in Commands)
            {
                switch (command)
                {
                    case CommandKey.L:
                    case CommandKey.R:
                        currentPos.Direction = currentPos.Direction.ChangeDirection(command);
                        break;
                    case CommandKey.M:
                        switch (currentPos.Direction)
                        {
                            case DirectionKey.N:
                                currentPos.Y++;
                                break;
                            case DirectionKey.E:
                                currentPos.X++;
                                break;
                            case DirectionKey.S:
                                currentPos.Y--;
                                break;
                            case DirectionKey.W:
                                currentPos.X--;
                                break;
                        }
                        break;
                }
            }
            return currentPos;
        }
    }
}
