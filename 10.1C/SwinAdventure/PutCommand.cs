using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (!(text.Length == 2 || text.Length == 4))
            {
                return "I don't know how to put like that";
            }

            if (!AreYou(text[0]))
            {
                return "Error in put input";
            }

            if (text.Length == 4 && text[2] != "in")
            {
                return "What do you want to put in?";
            }

            Item? item = p.Inventory.Take(text[1]);
            if (item == null)
            {
                return string.Format("I cannot find the {0}", text[1]);
            }

            if (text.Length == 2)
            {                
                p.Location.Inventory.Put(item);
                return string.Format("You have put the {0} in {1}", text[1], p.Location.Name);
            }

            // By this point the 2 element put command is done
            IHaveInventory? container = FetchContainer(p, text[3]);
            if (container == null)
            {
                return string.Format("I cannot find the {0}", text[3]);
            }

            container.Inventory.Put(item);
            return string.Format("You have put the {0} in the {1}", text[1], text[3]);
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            IHaveInventory? container = p.Locate(containerId) as IHaveInventory;
            return container;
        }
    }
}
