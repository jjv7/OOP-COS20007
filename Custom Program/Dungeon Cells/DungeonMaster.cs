using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DungeonCells
{
    public class DungeonMaster
    {
        // Everything to do with the dungeon and the game goes through this
        private static DungeonMaster? _instance;
        private Dungeon _dungeon;
        private int _playerScore;
        private IPlayerMovement _playerMovementStrategy;

        public int PlayerScore
        {
            get
            {
                return _playerScore;
            }
        }

        public IPlayerMovement SetPlayerMovementStrategy
        {
            set
            {
                _playerMovementStrategy = value;
            }
        }
        
        private DungeonMaster()
        {
            _dungeon = new Dungeon();
            _playerScore = 0;
            _playerMovementStrategy = new EmptyInCell();
        }

        // Singleton pattern
        public static DungeonMaster GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DungeonMaster();
            }
            return _instance;
        }

        public void MovePlayer(Cell playerCell, Cell otherCell)
        {
            _playerMovementStrategy.Execute(playerCell, otherCell);
        }

        public Cell FetchPlayerCell()
        {
            return _dungeon.SearchPlayerCell();
        }

        // For the player's turn
        public Cell? FetchCellToMovePlayerTo(string direction, Cell playerCell)
        {
            Cell? otherCell = null;

            // We need to check if the player is on the borders before moving, otherwise we might try to get a cell outside of the array and C# will get angry
            switch (direction)
            {
                case "up":
                    if (playerCell.Y > 0)
                    {
                        otherCell = _dungeon.Grid[playerCell.X, playerCell.Y - 1];
                    }
                    break;
                case "down":
                    if (playerCell.Y < 2)
                    {
                        otherCell = _dungeon.Grid[playerCell.X, playerCell.Y + 1];
                    }
                    break;
                case "left":
                    if (playerCell.X > 0)
                    {
                        otherCell = _dungeon.Grid[playerCell.X - 1, playerCell.Y];
                    }
                    break;
                case "right":
                    if (playerCell.X < 2)
                    {
                        otherCell = _dungeon.Grid[playerCell.X + 1, playerCell.Y];
                    }
                    break;
            }
            return otherCell;
        }

        public void CalculatePlayerScore(Player player)
        {
            // Kills are worth double points, so the player is incentivised to kill enemies, rather than run away (not that they can)
            _playerScore = player.Kills * 2 + player.Coins;
        }

        // For the dungeon master's turn. It can only move one enemy to an empty cell
        public void DungeonMasterTurn(Cell playerCell)
        {
            SplashKit.Delay(350);                                           // Delay to create the illusion that the dungeon master is thinking, otherwise gameplay is jarring
            Cell? emptyCell = _dungeon.GetAdjacentEmptyCell(playerCell);

            // Move an enemy towards the player if the emptyCell next to the player exists
            if (emptyCell != null)
            {
                _dungeon.MoveEnemyToEmptyCell(emptyCell);
            }
        }

        // I separated this from the Dungeon Master's turn, to make it easier to see which enemy the dungeonMaster moves
        public void PrepareForNextRound()
        {
            SplashKit.Delay(350);                                           // Delay, so it is easier to see the enemy movement
            _dungeon.FillGrid();
        }

        public void DrawGame()
        {
            _dungeon.Draw();
        }

        // This is needed to reset everything to an initial state if the player wants to play more than one game
        public void StartNewGame()
        {
            _playerScore = 0;
            _playerMovementStrategy = new EmptyInCell();
            _dungeon.Reset();
        }
    }
}
