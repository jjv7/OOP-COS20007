using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class DeathScreen : IScreen
    {
        // Screen for when the game ends and the player has died
        private Player _player;
        private int _score;
        private int _highscore;

        public DeathScreen()
        {
            _player = DungeonMaster.GetInstance().FetchPlayerCell().Entity as Player;
            _score = DungeonMaster.GetInstance().PlayerScore;

            // See if player score is higher than the highscore and change it accordingly
            HighScoreManager highScoreFile = new HighScoreManager();
            _highscore = highScoreFile.Load();
            if (_score > _highscore)
            {
                _highscore = _score;
                highScoreFile.Save(_highscore);
            }
        }

        public void Update()
        {
            if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                ScreenManager.CurrentScreen = new TitleScreen();
            }
            if (SplashKit.KeyReleased(KeyCode.EscapeKey))
            {
                System.Environment.Exit(0);
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(Color.Black);

            // Print out score and stats, self explanatory
            SplashKit.DrawText("You Died!", Color.White, "PressStart2P", 64, 110, 100);
            SplashKit.DrawText($"Coins: {_player.Coins}", Color.White, "PressStart2P", 16, 250, 250);
            SplashKit.DrawText($"Kills: {_player.Kills}", Color.White, "PressStart2P", 16, 250, 300);
            SplashKit.DrawText($"Final Score: {_score}", Color.White, "PressStart2P", 16, 250, 350);
            SplashKit.DrawText($"High Score: {_highscore}", Color.White, "PressStart2P", 16, 250, 400);
            SplashKit.DrawText("Press SPACE to return to title", Color.White, "PressStart2P", 16, 151, 525);
            SplashKit.DrawText("Press ESC to quit the game", Color.White, "PressStart2P", 16, 183, 575);
        }
    }
}
