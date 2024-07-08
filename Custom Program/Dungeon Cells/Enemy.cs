using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class Enemy : Entity
    {
        // Enemy entities, does damage to the player if player has no attack, can be moved by dungeon master
        public Enemy()
        {
            _entityID = EntityType.Enemy;
            Health = _rng.Next(1, 7);
            Coins = Health;                     // Value to initialise treasure entity when enemy dies
            _name = "Enemy";

            // Get image path for enemy
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            ImagePath = Path.Combine(solutionDirectory, "Resources", "Images", "enemy.png");
        }

        public override void Draw(int x, int y)
        {
            //SplashKit.FillCircle(Color.Red, x, y, 50);

            Bitmap image = SplashKit.LoadBitmap("enemy", ImagePath);
            DrawingOptions scale = SplashKit.OptionScaleBmp(3.5, 3.5);
            SplashKit.DrawBitmap(image, x - 15, y - 15, scale);
        }
    }
}
