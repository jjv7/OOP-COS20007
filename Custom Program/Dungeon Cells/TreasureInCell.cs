using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DungeonCells
{
    public class TreasureInCell : IPlayerMovement
    {
        // Player interaction with a treasure cell
        public void Execute(Cell playerCell, Cell treasureCell)
        {
            // Check that the entities in the cells are as expected
            Player? player = playerCell.Entity as Player;
            Treasure? treasure = treasureCell.Entity as Treasure;
            if (player != null && treasure != null)
            {
                player.Coins += treasure.Coins;                    // Coin value of treasure entity is added to player coins
                MovePlayer(playerCell, treasureCell);
            }
            else
            {
                Console.WriteLine("Failed to perform operation: Player or treasure entity is missing.");
            }
        }

        public void MovePlayer(Cell playerCell, Cell treasureCell)
        {
            treasureCell.Entity = playerCell.Entity;
            playerCell.Clear();
        }
    }
}
