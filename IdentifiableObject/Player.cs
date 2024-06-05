using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        private string _name;
        private string _description;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _name = name;
            _description = desc;
            _location = new Location(new string[] { "bedroom" }, "bedroom", "this is your workspace");
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if(_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {_name}, {_description}. You are carrying:\n    {Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}
