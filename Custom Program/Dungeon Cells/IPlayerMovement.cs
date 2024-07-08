using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DungeonCells
{
    public interface IPlayerMovement
    {
        // Interface for the strategy pattern for player interactions
        public void Execute(Cell playerCell, Cell cellToMoveInto);
    }
}
