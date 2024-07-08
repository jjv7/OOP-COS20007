using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            Command look = new LookCommand();
            Command move = new MoveCommand();
            Command pickup = new PickupCommand();
            Command put = new PutCommand();
            Command quit = new QuitCommand();
            _commands = new List<Command>() { look, move, pickup, put, quit };
        }

        public string? Execute(Player p, string text)
        {
            string[] input = text.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length > 0)
            {
                foreach (Command command in _commands)
                {
                    if (command.AreYou(input[0]))
                    {
                        string response = command.Execute(p, input);
                        return response;
                    }
                }
                return string.Format("I can't understand {0}", text);
            }
            return null;
        }
    }
}
