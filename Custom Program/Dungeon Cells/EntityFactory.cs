using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace DungeonCells
{
    public class EntityFactory
    {
        // Factory pattern. A class, rather than just a method, so it can be used across multiple areas of the program
        // Mainly used to generate enemies and items for the dungeon, but could be used for the player as well
        private readonly Dictionary<EntityType, Func<Entity>> _entities;
        private static EntityFactory? _instance;
        
        private EntityFactory()
        {
            _entities = new Dictionary<EntityType, Func<Entity>>
            {
                // EntityTypes are keys for lambda expressions which return an entity instance
                // just putting new Entity() would return the same entity instance every time
                { EntityType.Player, () => new Player() },
                { EntityType.Enemy, () => new Enemy() },
                { EntityType.Treasure, () => new Treasure() },
                { EntityType.Weapon, () => new Weapon() },
                { EntityType.Potion, () => new Potion() },
                { EntityType.Empty, () => new Empty() }
            };
        }

        // Singleton pattern implemented here more for convenience, so I don't need to create a new instance every time
        public static EntityFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EntityFactory();
            }
            return _instance;
        }

        public Entity CreateEntity(EntityType entityType)
        {
            // Get the entity specified, otherwise create an empty entity
            Func<Entity> createEntity;

            if (_entities.TryGetValue(entityType, out createEntity))
            {
                return createEntity();
            }
            return new Empty();
        }
    }
}
