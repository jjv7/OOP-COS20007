using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCells
{
    public class ScreenManager
    {
        // Stores the current screen being displayed to the player
        private static ScreenManager? _instance;
        private static IScreen _currentScreen;

        public static IScreen CurrentScreen
        {
            get 
            { 
                return _currentScreen;
            }
            set 
            { 
                _currentScreen = value; 
            }
        }

        private ScreenManager()
        {
            _currentScreen = new TitleScreen();
        }

        // Singleton pattern, because you don't want more than one screen to be displayed
        public static ScreenManager Initialise()
        {
            if (_instance == null)
            {
                _instance = new ScreenManager();
            }
            return _instance;
        }
    }
}
