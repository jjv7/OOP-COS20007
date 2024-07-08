using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { "quit" }) { }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 1)
            {
                return "Error in quit input";
            }

            return "Bye.";
        }
    }
}
