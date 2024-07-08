using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonCells
{
    public class Cell
    {
        // Makes up the dungeon, knows which entity it contains
        private Entity _entityInCell;
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public Entity Entity
        {
            get
            {
                return _entityInCell;
            }
            set
            {
                _entityInCell = value;
            }
        }

        public Cell(int x, int y)
        {
            // x and y values for calculating borders for drawing
            _x = x;
            _y = y;
            _entityInCell = EntityFactory.GetInstance().CreateEntity(EntityType.Empty);
        }

        public void Draw()
        {
            // Draw cell borders
            SplashKit.DrawLine(Color.Black, _x * 260, _y * 260, _x * 260 + 260, _y * 260);                      // Top border
            SplashKit.DrawLine(Color.Black, _x * 260, _y * 260 + 260, _x * 260 + 260, _y * 260 + 260);          // Bottom border
            SplashKit.DrawLine(Color.Black, _x * 260, _y * 260, _x * 260, _y * 260 + 260);                      // Left border
            SplashKit.DrawLine(Color.Black, _x * 260 + 260, _y * 260, _x * 260 + 260, _y * 260 + 260);          // Right border
            
            // Draw entity stats depending on the type of entity in the cell
            if (_entityInCell.EntityType == EntityType.Player || _entityInCell.EntityType == EntityType.Enemy || _entityInCell.EntityType == EntityType.Potion)
            {
                SplashKit.DrawText(_entityInCell.Health.ToString(), Color.Red, "PressStart2P", 16, _x * 260 + 260 - 34, _y * 260 + 17);
            }
            if (_entityInCell.EntityType == EntityType.Player || _entityInCell.EntityType == EntityType.Weapon)
            {
                SplashKit.DrawText(_entityInCell.Attack.ToString(), Color.Blue, "PressStart2P", 16, _x * 260 + 260 - 34, _y * 260 + 260 - 31);
            }
            if (_entityInCell.EntityType == EntityType.Player || _entityInCell.EntityType == EntityType.Treasure)
            {
                SplashKit.DrawText(_entityInCell.Coins.ToString(), Color.Yellow, "PressStart2P", 16, _x * 260 + 21, _y * 260 + 260 - 31);
            }

            // Draw entity name. This is an if else, because the player and potion have a different number of characters in their name from the other entities
            if (_entityInCell.EntityType == EntityType.Player || _entityInCell.EntityType == EntityType.Potion)
            {
                SplashKit.DrawText(_entityInCell.Name, Color.Black, "PressStart2P", 16, _x * 260 + 83, _y * 260 + 200);
            }
            else
            {
                SplashKit.DrawText(_entityInCell.Name, Color.Black, "PressStart2P", 16, _x * 260 + 92, _y * 260 + 200);
            }

            // Draw the entity image
            _entityInCell.Draw(_x * 260 + 130, _y * 260 + 130);
        }

        public void Clear()
        {
            _entityInCell = EntityFactory.GetInstance().CreateEntity(EntityType.Empty);
        }
    }
}
