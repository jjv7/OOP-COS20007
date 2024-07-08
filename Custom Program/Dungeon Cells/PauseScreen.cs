using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class PauseScreen : IScreen
    {
        // Screen for when the game is paused
        public void Update()
        {
            if (SplashKit.KeyReleased(KeyCode.EscapeKey))
            {
                ScreenManager.CurrentScreen = new GameScreen();             // I don't need to specify a turn to return to, since the player can only pause on their turn
            }
            if (SplashKit.KeyReleased(KeyCode.RKey))
            {
                // Same logic as the title screen for resetting the game
                DungeonMaster.GetInstance().StartNewGame();
                Console.WriteLine("Player turn");
                ScreenManager.CurrentScreen = new GameScreen();
            }
            if (SplashKit.KeyReleased(KeyCode.ReturnKey))
            {
                System.Environment.Exit(0);
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(Color.Black);

            SplashKit.DrawText("Pause Menu", Color.White, "PressStart2P", 40, 190, 225);
            SplashKit.DrawText("Press ESC to resume", Color.White, "PressStart2P", 16, 238, 400);
            SplashKit.DrawText("Press R to start a new game", Color.White, "PressStart2P", 16, 175, 450);
            SplashKit.DrawText("Press ENTER to quit the game", Color.White, "PressStart2P", 16, 166, 500);
        }
    }
}
