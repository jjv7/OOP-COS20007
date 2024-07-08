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

        public override string FullDescription
        {
            get
            {
                return string.Format("You are {0}, {1}.\nYou are carrying: {2}", Name, base.FullDescription, Inventory.ItemList);
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
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location();
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject? item = Inventory.Fetch(id);
            if (item != null)
            {
                return item;
            }
            item = Location.Locate(id);
            return item;
        }
    }
}
