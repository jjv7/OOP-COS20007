using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace DungeonCells
{
    public class WeaponInCell : IPlayerMovement
    {
        // Player interaction with a weapon cell
        public void Execute(Cell playerCell, Cell weaponCell)
        {
            // Check that the entities in the cells are as expected
            Player? player = playerCell.Entity as Player;
            Weapon? weapon = weaponCell.Entity as Weapon;
            if (player != null && weapon != null)
            {
                // Player's attack gets replaced by weapon attack, so player can't just stack attack
                // Means players have to be more strategic in the use of their weapons
                player.Attack = weapon.Attack;                      
                MovePlayer(playerCell, weaponCell);
            }
            else
            {
                Console.WriteLine("Failed to perform operation: Player or weapon entity is missing.");
            }
        }

        public void MovePlayer(Cell playerCell, Cell weaponCell)
        {
            weaponCell.Entity = playerCell.Entity;
            playerCell.Clear();
        }
    }
}
