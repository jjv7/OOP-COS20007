using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public interface IScreen
    {
        // Each screen object requires update to take user inputs and change values
        // Each screen object also requires draw to present the updated output to the window
        public void Update();

        public void Draw();
    }
}
