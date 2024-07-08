using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class HighScoreManager
    {
        // Object for managing the player's highscore
        private const string _highScoreFileName = "highscores.txt";
        private readonly string _highScoreFilePath;

        public HighScoreManager()
        {
            // Get the file path
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            _highScoreFilePath = Path.Combine(solutionDirectory, "Resources", _highScoreFileName);
            
            // Create file if it doesn't exist to make the program happy
            if (!File.Exists(_highScoreFilePath))
            {
                File.Create(_highScoreFilePath).Close();
            }
        }

        public void Save(int newHighScore)
        {
            StreamWriter writer = new StreamWriter(_highScoreFilePath);
            try
            {
                writer.Write(newHighScore);
            }
            finally
            {
                writer.Close();
            }
        }
        public int Load()
        {
            int currentHighScore = 0;
            StreamReader reader = new StreamReader(_highScoreFilePath);
            try
            {
                currentHighScore = Convert.ToInt32(reader.ReadLine());
            }
            finally
            {
                reader.Close();
            }
            return currentHighScore;
        }
    }
}
