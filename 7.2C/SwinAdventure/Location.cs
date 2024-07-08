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

        public override string FullDescription
        {
            get
            {
                return string.Format("You are in {0}\n{1}\nIn this room you can see:{2}", Name, base.FullDescription, Inventory.ItemList);
            }
        }
        public Inventory Inventory
        {
            get 
            { 
                return _inventory; 
            }
        }
        
        public Location() : this(new string[] { "location", "unknown" }, "an unknown location", "This is a mysterious location") { }           // Default constructor, to make sure the player has a location if not allocated one
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return Inventory.Fetch(id);
        }
    }
}
