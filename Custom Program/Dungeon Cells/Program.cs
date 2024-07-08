using System;
using System.Data;
using System.Threading.Tasks.Sources;
using SplashKitSDK;

namespace DungeonCells
{    
    public enum EntityType
    {
        Empty,
        Player,
        Enemy,
        Treasure,
        Weapon,
        Potion
    }

    public enum Turn
    {
        Player,
        DungeonMaster,
        EndRound
    }

    public class Program
    {
        public static void Main()
        {
            // Load in custom font
            // Switched from using AppContext.BaseDirectory since it is safer
            // AppContext.BaseDirectory gives the directory in which the current main exe resides
            // But if another host or runtime is used, it will return the directory of that host and crash the code due to missing files
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "../../.."));
            string pressStart2PFontPath = Path.Combine(solutionDirectory, "Resources", "fonts", "PressStart2P-Regular.ttf");
            SplashKit.LoadFont("PressStart2P", pressStart2PFontPath);

            // Create a 780x780 window. I picked 780, since it was divisible by 3
            Window window = new Window("Dungeon Cells", 780, 780);

            // Technically I can take a more structured approach to managing gamestates for the screen
            // A global variable can store an enum corresponding to a screen
            // A switchcase can refer to this enum and call update and draw accordingly
            // Using a single object as a screenmanager makes adding screens much more modular
            // This is also arguably more secure as you can use a private field in place of a global variable
            // Although, this has the downside of adding more overhead and classes
            // Of course, I can use one class for the screens instead of multiple screen classes and one screen manager class
            // But in this implementation, it is more readable, and there is more concentration on what each individual screen does
            ScreenManager.Initialise();

            while (!window.CloseRequested)
            {
                // Process button presses and update game data
                SplashKit.ProcessEvents();
                ScreenManager.CurrentScreen.Update();

                // Clear screen, so updated data can be displayed
                SplashKit.ClearScreen();
                ScreenManager.CurrentScreen.Draw();

                // SplashKit seems to be frame based, rather than time based
                // This means sequentially, the loop is only cycled through on each frame
                // I have not specified a refresh rate, so SplashKit should just iterate through the loop as fast as it can
                // This means that the controls should be more responsive
                // This comes at the cost of wasted CPU cycles and higher CPU utilisation
                // But this shouldn't matter, since the game is turn based
                // But in a real time game, it would be better to cap the refresh rate to a specific number such as 60
                SplashKit.RefreshScreen();
            }
        }
    }
}
