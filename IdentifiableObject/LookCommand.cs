using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 3)
            {
                _container = (IHaveInventory)p;
                return LookAtIn(text[2], _container);
            }
            if (text[3] != "in")
            {
                return "What do you want to look in?";
            }
            _container = FetchContainer(p, text[4]);
            if (_container == null)
            {
                return $"I cannot find the {text[4]}";
            }
            return LookAtIn(text[2], _container);
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject obj = container.Locate(thingId);
            if (obj == null)
            {
                return $"I cannot find the {thingId}";
            }
            return obj.FullDescription;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
    }
}
