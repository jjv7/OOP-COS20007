using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class GameScreen : IScreen
    {
        // Logic for when the game is running
        private DungeonMaster _dungeonMaster;
        private Cell _playerCell;
        private Player _player;
        private Turn _turn;

        public GameScreen()
        {
            _dungeonMaster = DungeonMaster.GetInstance();
            _playerCell = _dungeonMaster.FetchPlayerCell();
            _player = _playerCell.Entity as Player;
            _turn = Turn.Player;
        }        

        public void Update()
        {
            if (_turn == Turn.Player)
            {
                Cell? otherCell = null;             // Second cell to use for interactions with the player cell

                // check for directional keypress (arrow keys and WASD keys supported)
                if (SplashKit.KeyReleased(KeyCode.UpKey) || SplashKit.KeyReleased(KeyCode.WKey))
                {
                    otherCell = _dungeonMaster.FetchCellToMovePlayerTo("up", _playerCell);
                }
                else if (SplashKit.KeyReleased(KeyCode.DownKey) || SplashKit.KeyReleased(KeyCode.SKey))
                {
                    otherCell = _dungeonMaster.FetchCellToMovePlayerTo("down", _playerCell);
                }
                else if (SplashKit.KeyReleased(KeyCode.LeftKey) || SplashKit.KeyReleased(KeyCode.AKey))
                {
                    otherCell = _dungeonMaster.FetchCellToMovePlayerTo("left", _playerCell);
                }
                else if (SplashKit.KeyReleased(KeyCode.RightKey) || SplashKit.KeyReleased(KeyCode.DKey))
                {
                    otherCell = _dungeonMaster.FetchCellToMovePlayerTo("right", _playerCell);
                }

                // Pause the game is ESC key is pressed
                if (SplashKit.KeyReleased(KeyCode.EscapeKey))
                {
                    ScreenManager.CurrentScreen = new PauseScreen();
                }

                // Attempt to move player to other cell if specified from the keypress and movement is valid
                if (otherCell != null)
                {
                    // Implementation of strategy pattern with the context being what entity is in the cell the player is trying to move into
                    switch (otherCell.Entity.EntityType)
                    {
                        case EntityType.Enemy:
                            _dungeonMaster.SetPlayerMovementStrategy = new EnemyInCell();
                            break;
                        case EntityType.Treasure:
                            _dungeonMaster.SetPlayerMovementStrategy = new TreasureInCell();
                            break;
                        case EntityType.Weapon:
                            _dungeonMaster.SetPlayerMovementStrategy = new WeaponInCell();
                            break;
                        case EntityType.Potion:
                            _dungeonMaster.SetPlayerMovementStrategy = new PotionInCell();
                            break;
                        case EntityType.Empty:
                            _dungeonMaster.SetPlayerMovementStrategy = new EmptyInCell();
                            break;
                    }
                    _dungeonMaster.MovePlayer(_playerCell, otherCell);
                }

                // If player is not in the cell, set the new player cell to the other cell (movement was likely 99.999...% successful)
                if (_playerCell.Entity.EntityType != EntityType.Player)
                {
                    _playerCell = otherCell;             // playerCell would be otherCell if the player moved, so we don't need to do another fetchPlayerCell
                    _turn = Turn.DungeonMaster;
                }
            }
            else if (_turn == Turn.DungeonMaster)
            {
                // Move enemy cells into empty cell left from the player's turn
                Console.WriteLine("Dungeon Master turn");
                _dungeonMaster.DungeonMasterTurn(_playerCell);
                _turn = Turn.EndRound;
            }
            else
            {
                // Fill empty cells with new enemies/items, depending on the number of different types of existing entities
                Console.WriteLine("Preparing for next round");
                _dungeonMaster.PrepareForNextRound();
                _turn = Turn.Player;
                Console.WriteLine("Player turn");
            }

            if (_player.Health <= 0)
            {
                // Player is dead, calculate score and move to the deathscreen
                _dungeonMaster.CalculatePlayerScore(_player);
                ScreenManager.CurrentScreen = new DeathScreen();
            }
        }

        public void Draw()
        {
            _dungeonMaster.DrawGame();
        }
    }
}
