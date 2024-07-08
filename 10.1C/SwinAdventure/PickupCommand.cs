using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PickupCommand : Command
    {
        public PickupCommand() : base(new string[] { "pickup", "take" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (!(text.Length == 2 || text.Length == 4))
            {
                return "I don't know how to pickup like that";
            }

            if (!AreYou(text[0]))
            {
                return "Error in pickup input";
            }

            if (text.Length == 4 && text[2] != "from")
            {
                return "What do you want to pickup from?";
            }

            if (text.Length == 2)
            {
                Item? item2 = PickupFrom(text[1], p.Location);
                if (item2 == null)
                {
                    return string.Format("I cannot find the {0}", text[1]);
                }
                p.Inventory.Put(item2);
                return string.Format("You have taken the {0} from {1}", text[1], p.Location.Name);
            }

            // By this point the 2 element pickup command is done
            IHaveInventory? container = FetchContainer(p, text[3]);
            if (container == null)
            {
                return string.Format("I cannot find the {0}", text[3]);
            }

            Item? item5 = PickupFrom(text[1], container);
            if (item5 == null)
            {
                return string.Format("I cannot find the {0} in the {1}", text[1], text[3]);
            }
            p.Inventory.Put(item5);
            return string.Format("You have taken the {0} from the {1}", text[1], text[3]);
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            IHaveInventory? container = p.Locate(containerId) as IHaveInventory;
            return container;
        }

        private Item? PickupFrom(string thingId, IHaveInventory container)
        {
            Item? item = container.Inventory.Take(thingId);
            return item;
        }
    }
}

