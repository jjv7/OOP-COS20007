using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class Potion : Entity
    {
        // Entity which gives a player health
        public Potion()
        {
            _entityID = EntityType.Potion;
            Health = _rng.Next(1, 4);           // This will determine how much health they give the player
            _name = "Potion";

            // Get image path for potion
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            ImagePath = Path.Combine(solutionDirectory, "Resources", "Images", "health_potion.png");
        }

        public override void Draw(int x, int y)
        {
            //SplashKit.FillCircle(Color.Red, x, y, 50);

            Bitmap image = SplashKit.LoadBitmap("potion", ImagePath);
            DrawingOptions scale = SplashKit.OptionScaleBmp(3.5, 3.5);
            SplashKit.DrawBitmap(image, x - 15, y - 16, scale);
        }
    }
}
