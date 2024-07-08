using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (!(text.Length == 1 || text.Length == 3 || text.Length == 5))
            {
                return "I don't know how to look like that";
            }
            
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            
            if (text.Length == 1)
            {
                string locationDescription = p.Location.FullDescription;
                return locationDescription;
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }

            if (text.Length == 3)
            {
                string? itemDescription3 = LookAtIn(text[2], p);
                if (itemDescription3 == null)
                {
                    return string.Format("I cannot find the {0}", text[2]);
                }
                return itemDescription3;
            }
            
            // By this point the 1 and 3 element look commands are done
            IHaveInventory? container = FetchContainer(p, text[4]);
            if (container == null)
            {
                return string.Format("I cannot find the {0}", text[4]);
            }
            
            string? itemDescription5 = LookAtIn(text[2], container);
            if (itemDescription5 == null)
            {
                return string.Format("I cannot find the {0} in the {1}", text[2], text[4]);
            }
            return itemDescription5;
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            IHaveInventory? container = p.Locate(containerId) as IHaveInventory;
            return container;
        }

        private string? LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? item = container.Locate(thingId);
            if (item == null)
            {
                return null;
            }
            return item.FullDescription;
        }
    }
}
