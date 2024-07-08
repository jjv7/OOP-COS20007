using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class Empty : Entity
    {
        // This entity is the default for the cells so the program doesn't try to draw a null entity
        public Empty()
        {
            _entityID = EntityType.Empty;
        }

        public override void Draw(int x, int y)
        {
            SplashKit.FillCircle(Color.Black, x, y, 50);
        }
    }
}
