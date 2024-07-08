using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class TitleScreen : IScreen
    {
        // Logic for the title screen
        public void Update()
        {
            if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                // Sets the game to an initial state, in case the user is coming from the death screen
                DungeonMaster.GetInstance().StartNewGame();
                Console.WriteLine("Player turn");
                ScreenManager.CurrentScreen = new GameScreen();
            }
            if (SplashKit.KeyReleased(KeyCode.EscapeKey))
            {
                System.Environment.Exit(0);
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(Color.Black);

            SplashKit.DrawText("Dungeon Cells", Color.White, "PressStart2P", 52, 60, 275);
            SplashKit.DrawText("Press SPACE to start", Color.White, "PressStart2P", 16, 230, 450);
        }
    }
}
