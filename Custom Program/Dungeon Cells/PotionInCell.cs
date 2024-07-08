using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class PotionInCell : IPlayerMovement
    {
        // Player interaction with a potion cell
        public void Execute(Cell playerCell, Cell potionCell)
        {
            // Check that the entities in the cells are as expected
            Player? player = playerCell.Entity as Player;
            Potion? potion = potionCell.Entity as Potion;
            if (player != null && potion != null)
            {
                // Player health gets increased by potion health
                player.Health += potion.Health;

                // Max player health is 10, so the player can't stack a lot of health
                // Also, allows for more strategy, since potions that will heal them above 10 will have some wastage
                if (player.Health > 10)
                {
                    player.Health = 10;
                }

                MovePlayer(playerCell, potionCell);
            }
            else
            {
                Console.WriteLine("Failed to perform operation: Player or potion entity is missing.");
            }
        }

        public void MovePlayer(Cell playerCell, Cell potionCell)
        {
            potionCell.Entity = playerCell.Entity;
            playerCell.Clear();
        }
    }
}
