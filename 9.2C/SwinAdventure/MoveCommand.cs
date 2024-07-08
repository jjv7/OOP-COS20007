using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to move like that";
            }

            if (!AreYou(text[0]))
            {
                return "Error in move input";
            }

            Path? path;
            string direction;
            switch (text[1].ToLower())
            {
                case string north when north == "north" || north == "n":
                    direction = "north";
                    break;
                case string northEast when northEast == "north_east" || northEast == "ne":
                    direction = "north_east";
                    break;
                case string northWest when northWest == "north_west" || northWest == "nw":
                    direction = "north_west";
                    break;
                case string south when south == "south" || south == "s":
                    direction = "south";
                    break;
                case string southEast when southEast == "south_east" || southEast == "se":
                    direction = "south_east";
                    break;
                case string southWest when southWest == "south_west" || southWest == "sw":
                    direction = "south_west";
                    break;
                case string east when east == "east" || east == "e":
                    direction = "east";
                    break;
                case string west when west == "west" || west == "w":
                    direction = "west";
                    break;
                case "up":
                    direction = text[1];
                    break;
                case "down":
                    direction = text[1];
                    break;
                default:
                    return "I don't know that direction";
            }
            path = p.Location.FetchPath(direction);

            if (path == null)
            {
                return string.Format("I cannot move {0}", text[1]);
            }

            path.MovePlayer(p);
            return string.Format("You head {0}\nYou have arrived in {1}", path.FirstID, path.Destination.Name);
        }
    }
}
