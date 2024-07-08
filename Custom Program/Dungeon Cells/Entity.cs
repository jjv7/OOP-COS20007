using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace DungeonCells
{
    public abstract class Entity
    {
        // Template for an entity
        protected static Random _rng = new Random();
        private int _health;
        private int _coins;
        private int _attack;
        protected string _name;
        protected EntityType _entityID;                 // Subclasses need to be able to access this to set their own ID
        private string _imagePath;

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
            }
        }

        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public EntityType EntityType
        {
            get
            {
                return _entityID;
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        public abstract void Draw(int x, int y);
    }
}
