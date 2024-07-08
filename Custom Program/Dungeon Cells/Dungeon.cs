using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DungeonCells
{
    public class Dungeon
    {
        // Object which controls all the cells. Doesn't know what is in the cells directly. Can create entities for the cells.
        private static Random _rng = new Random();              // Tried using SplashKit's inbuilt random function, but it seemed to be less random, or the documentation might be wrong
        private Cell[,] _grid;
        private int _enemies;
        private int _items;

        public Cell[,] Grid
        {
            get
            {
                return _grid;
            }
        }
        
        public Dungeon()
        {
            _enemies = 0;
            _items = 0;
            _grid = new Cell[3, 3];                        // Generates a 3x3 dungeon
        }

        private void InitialiseGrid()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    _grid[i, j] = new Cell(i, j);           // rows = j, columns = i
                }
            }
            
            _grid[_rng.Next(0, 3), _rng.Next(0, 3)].Entity = EntityFactory.GetInstance().CreateEntity(EntityType.Player);
        }

        public Cell SearchPlayerCell()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_grid[i, j].Entity.EntityType == EntityType.Player)
                    {
                        return _grid[i, j];
                    }
                }
            }
            throw new InvalidOperationException("Player cell not found in the grid");
        }

        // I split this method into multiple methods since it was getting hard to read because of all the indentation
        public void FillGrid()
        {
            CountExistingNonPlayerEntities();                                                           // Determines which entities can be spawned in

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_grid[i, j].Entity.EntityType == EntityType.Empty)
                    {
                        EntityType typeToCreate = DetermineTypeToCreate();
                        _grid[i, j].Entity = EntityFactory.GetInstance().CreateEntity(typeToCreate);
                    }
                }
            }
        }

        private void CountExistingNonPlayerEntities()
        {
            // We need to see what currently exists in the dungeon to determine what entities are able to be spawned in
            _enemies = 0;
            _items = 0;

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_grid[i, j].Entity.EntityType == EntityType.Enemy)
                    {
                        _enemies++;
                    }
                    else if (_grid[i, j].Entity.EntityType == EntityType.Treasure || _grid[i, j].Entity.EntityType == EntityType.Weapon || _grid[i, j].Entity.EntityType == EntityType.Potion)
                    {
                        _items++;
                    }
                }
            }
        }

        private EntityType DetermineTypeToCreate()
        {
            if (_enemies < 5 && _items < 3)
            {
                // If enemies and items are both below entity limit, or if only items are below entity limit
                // This condition should only be triggered when generating a new dungeon
                // 50% chance to create an enemy, or 50% chance to create an item
                return _rng.Next(0, 2) == 0 ? CreateEnemy() : CreateItem();
            }
            else if (_enemies < 5)
            {
                // If only enemies are below the entity limit
                return CreateEnemy();
            }
            else if (_items < 3)
            {
                // If only items are below the entity limit
                return CreateItem();
            }
            return EntityType.Empty;                                                                    // Default case, although this should not happen
        }

        private EntityType CreateEnemy()
        {
            _enemies++;
            return EntityType.Enemy;
        }

        private EntityType CreateItem()
        {
            EntityType itemType;

            // Made it so that there is a 45% chance to spawn either a treasure or a weapon, and a 10% chance to spawn a potion
            // This weapons are fairly balanced
            // Potions are too strong, and can make it so that the player cannot die, so they need to spawn less
            switch (_rng.Next(1, 101))
            {
                case int a when a > 0 && a < 46:
                    itemType = EntityType.Treasure;
                    break;
                case int b when b > 45 && b < 91:
                    itemType = EntityType.Weapon;
                    break;
                case int c when c > 90 && c < 101:
                    itemType = EntityType.Potion;
                    break;
                default:
                    itemType = EntityType.Empty;         // Default to empty if something goes wrong
                    break;
            }
            _items++;
            return itemType;
        }

        public void Draw()
        {
            // Draw grey background, then tell each cell to draw
            SplashKit.ClearScreen(Color.DimGray);
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    _grid[i, j].Draw();
                }
            }
        }

        public void Reset()
        {
            InitialiseGrid();
            FillGrid();
        }

        // Methods below relate to shifting the enemies into empty cells
        // Because of how there can only ever be 5 enemies at a time on the dungeon,
        // the player can just farm coins by moving between two cells containing item entities (weapon or treasure)
        // Shifting an enemy helps prevents this strategy

        public Cell? GetAdjacentEmptyCell(Cell playerCell)
        {
            int x = playerCell.X;
            int y = playerCell.Y;

            // Check adjacent cells (up, down, left, right)
            // Technically this function isn't needed and I could just use the cell left behind by the player in the program
            // But if I want to have something in the future that could obliterate multiple enemies in a row,
            // I can just modify this method for an easy implementation
            if (x > 0 && _grid[x - 1, y].Entity.EntityType == EntityType.Empty) return _grid[x - 1, y];
            if (x < 2 && _grid[x + 1, y].Entity.EntityType == EntityType.Empty) return _grid[x + 1, y];
            if (y > 0 && _grid[x, y - 1].Entity.EntityType == EntityType.Empty) return _grid[x, y - 1];
            if (y < 2 && _grid[x, y + 1].Entity.EntityType == EntityType.Empty) return _grid[x, y + 1];

            return null;
        }

        public List<Cell> GetAdjacentEnemyCells(Cell emptyCell)
        {
            List<Cell> enemyCells = new List<Cell>();
            int x = emptyCell.X;
            int y = emptyCell.Y;

            // Add adjacent enemy cells to the list
            if (x > 0 && _grid[x - 1, y].Entity.EntityType == EntityType.Enemy) enemyCells.Add(_grid[x - 1, y]);
            if (x < 2 && _grid[x + 1, y].Entity.EntityType == EntityType.Enemy) enemyCells.Add(_grid[x + 1, y]);
            if (y > 0 && _grid[x, y - 1].Entity.EntityType == EntityType.Enemy) enemyCells.Add(_grid[x, y - 1]);
            if (y < 2 && _grid[x, y + 1].Entity.EntityType == EntityType.Enemy) enemyCells.Add(_grid[x, y + 1]);

            return enemyCells;
        }

        // This actually creates the illusion of the enemies chasing the player around the dungeon
        public void MoveEnemyToEmptyCell(Cell emptyCell)
        {
            List<Cell> enemyCells = GetAdjacentEnemyCells(emptyCell);

            if (enemyCells.Count > 0)
            {
                // Select a random enemy to move to the empty cell to give the effect of the dungeon trying to chase the player
                Cell selectedEnemyCell = enemyCells[_rng.Next(enemyCells.Count)];

                // Move the enemy to the empty cell
                emptyCell.Entity = selectedEnemyCell.Entity;
                selectedEnemyCell.Clear();
            }
        }       
    }
}
