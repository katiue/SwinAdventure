using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private string _name;
        private string _description;
        private List<Path> _paths;
        public Location(string [] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _name = name;
            _description = desc;
            _paths = new List<Path>();
        }

        public Inventory Inventory { get { return _inventory; } }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            foreach(Path pth in _paths)
            {
                if (pth.AreYou(id))
                {
                    return pth;
                }
            }
            return _inventory.Fetch(id);
        }
        public List<Path> Path
        {
            get
            {
                return _paths;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are in {_name}, {_description}. This place has\n    {Inventory.ItemList}This place have the current paths: {PathList}";

            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
        public string PathList
        {
            get
            {
                string PathList = "";
                foreach (Path i in Path)
                {
                    PathList += i.ShortDescription + "\n";
                }
                return PathList;
            }
        }
    }
}
