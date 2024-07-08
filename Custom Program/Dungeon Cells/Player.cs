using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class Player : Entity
    {
        // Entity controlled by the player
        private int _kills;

        public int Kills
        {
            get
            {
                return _kills;
            }
            set
            {
                _kills = value;
            }
        }

        public Player()
        {
            _entityID = EntityType.Player;
            Attack = 5;                     // Player starts with max attack possible, since they may be surrounded by enemies when they start
            Coins = 0;
            _kills = 0;                     // keep track of enemy kills for score
            Health = 10;
            _name = "Player";

            // Get image path for player
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            // Originally player was yellow, but that made the player colour and silhouette look too similar to the coins
            ImagePath = Path.Combine(solutionDirectory, "Resources", "Images", "player_green.png");
        }

        public override void Draw(int x, int y)
        {
            //SplashKit.FillCircle(Color.Green, x, y, 50);

            Bitmap image = SplashKit.LoadBitmap("player", ImagePath);
            DrawingOptions scale = SplashKit.OptionScaleBmp(3.5, 3.5);
            SplashKit.DrawBitmap(image, x - 15, y - 15, scale);
        }
    }
}
