using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to move that";
            }
            foreach(Path pth in p.Location.Path)
            {
                if (pth.AreYou(text[1]))
                {
                    Move(p, pth);
                    return $"You are now in {p.Location.Name}";
                }
            }
            return $"I do not know that place";
        }
        public void Move(Player p, Path pth)
        {
            if (pth.IsBlocked)
            {
                Console.WriteLine("The path is blocked");
                return;
            }
            p.Location = pth.Destination;
        }
    }
}
