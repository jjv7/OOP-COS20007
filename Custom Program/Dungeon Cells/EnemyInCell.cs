using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace DungeonCells
{
    public class EnemyInCell : IPlayerMovement
    {
        // Player interaction with an enemy cell
        public void Execute(Cell playerCell, Cell enemyCell)
        {
            // Check that the entities in the cells are as expected
            Player? player = playerCell.Entity as Player;
            Enemy? enemy = enemyCell.Entity as Enemy;
            if (player != null && enemy != null)
            {
                // If the player has attack, use it to decrease enemy health
                if (player.Attack > 0)
                {
                    int durabilityDecrease = enemy.Health;
                    enemy.Health -= player.Attack;
                    player.Attack -= durabilityDecrease;        // Makes the player need to keep picking up weapons

                    // For if enemy health is greater than the player's attack
                    if (player.Attack < 0)
                    {
                        player.Attack = 0;
                    }
                }
                else
                {
                    // If player has no attack, they will compensate with their own health. This is how you can die in the game
                    int healthDecrease = enemy.Health;
                    enemy.Health -= player.Health;
                    player.Health -= healthDecrease;
                }

                // Enemy is dead if health is 0 or below
                if (enemy.Health <= 0)
                {
                    player.Kills++;
                        
                    // Creating a treasure entity in the place of an enemy allows for more strategy from the player
                    // Do they risk putting themself in a bad position by taking the treasure for a higher score, or do they come back for it later?
                    // I can't use the factory in this case, since this is a different initialisation of a treasure entity which is not defined in the factory's dictionary
                    // I would also need to make a different key and EntityType enum which would be a hassle
                    enemyCell.Entity = new Treasure(enemy.Coins);
                }
            }
            else
            {
                Console.WriteLine("Failed to perform operation: Player or enemy entity is missing.");
            }
        }
    }
}
