using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public override string FullDescription
        {
            get
            {
                string description = string.Format("You are in {0}\n{1}", Name, base.FullDescription);
                if (Paths.Count > 0) 
                {
                    description += "\nThere are exits to the ";
                    int lastIndex = Paths.Count - 1;
                    int i = 0;
                    foreach (Path path in Paths)
                    {
                        if (Paths.Count > 1)
                        {
                            if (i < lastIndex)
                            {
                                description += string.Format("{0}, ", path.FirstID);
                            }
                            else
                            {
                                description += string.Format("and {0}.", path.FirstID);
                            }
                            i++;
                        }
                        else
                        {
                            description += string.Format("{0}.", path.FirstID);
                        }
                    }
                }                
                description += string.Format("\nIn this room you can see:{0}", Inventory.ItemList);
                return description;
            }
        }
        public Inventory Inventory
        {
            get 
            { 
                return _inventory; 
            }
        }

        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }
        
        public Location() : this(new string[] { "unknown" }, "an unknown location", "This is a mysterious location") { }           // Default constructor, to make sure the player has a location if not allocated one
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            AddIdentifier("room");
            AddIdentifier("here");
            AddIdentifier("location");
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return Inventory.Fetch(id);
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public Path? FetchPath(string direction)
        {
            foreach (Path path in Paths)
            {
                if (path.AreYou(direction))
                {
                    return path;
                }
            }
            return null;
        }
    }
}