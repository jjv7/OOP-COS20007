using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public string Name { get; }

        public Inventory Inventory { get; }

        public GameObject? Locate(string id);
    }
}
