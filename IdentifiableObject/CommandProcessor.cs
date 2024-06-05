using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private List<Command> _commands;
        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0]))
                {
                    return command.Execute(p, text);
                }
            }
            return "I don't know how to do that";
        }
    }
}
