using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class Treasure : Entity
    {
        // Entity which gives a player coins
        
        // Naturally spawn a treasure entity with coin value between 1 and 5
        public Treasure() : this(_rng.Next(1, 6)) { }

        // Overloaded, so enemy can initialise the Treasure entity with their coin value
        public Treasure(int coins)
        {
            _entityID = EntityType.Treasure;
            Coins = coins;
            _name = "Coins";

            // Get image path for treasure
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            ImagePath = Path.Combine(solutionDirectory, "Resources", "Images", "coin.png");
        }

        public override void Draw(int x, int y)
        {
            //SplashKit.FillCircle(Color.Yellow, x, y, 50);

            Bitmap image = SplashKit.LoadBitmap("coin", ImagePath);
            DrawingOptions scale = SplashKit.OptionScaleBmp(3.5, 3.5);
            SplashKit.DrawBitmap(image, x - 15, y - 16, scale);
        }
    }
}
