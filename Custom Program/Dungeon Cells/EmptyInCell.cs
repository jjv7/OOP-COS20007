using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace DungeonCells
{
    public class EmptyInCell : IPlayerMovement
    {
        // Player interaction with an empty cell, should never be used
        public void Execute(Cell playerCell, Cell emptyCell)
        {
            // Check that the entities in the cells are as expected
            Player? player = playerCell.Entity as Player;
            Empty? empty = emptyCell.Entity as Empty;
            if (player != null && empty != null)
            {
                MovePlayer(playerCell, emptyCell);
            }
            else
            {
                Console.WriteLine("Failed to perform movement to empty cell: Player entity is missing or non-empty entity exists in other cell.");
            }
        }

        public void MovePlayer(Cell playerCell, Cell emptyCell)
        {
            emptyCell.Entity = playerCell.Entity;
            playerCell.Clear();
        }
    }
}
