using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private string _name;
        private string _description;

        private Location _source;
        private Location _destination;
        
        private bool _isBlocked;
        public Path(string[] ids, string name, string desc, Location source, Location destination, bool IsBlocked) : base(ids, name, desc)
        {
            _source = source;
            _destination = destination;
            _description = desc;
            _name = name;
            _isBlocked = IsBlocked;
        }

        public Location Source { get { return _source; } }
        public Location Destination { get { return _destination; } }
        public override string FullDescription
        {
            get
            {
                if(_isBlocked)
                {
                    return $"This is a path from {_source.Name} to {_destination.Name}. {_description} the path is blocked.";
                }
                else
                {
                    return $"This is a path from {_source.Name} to {_destination.Name}. {_description} the path is not blocked.";
                }
            }
        }
        public bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                _isBlocked = value;
            }
        }

    }
}
