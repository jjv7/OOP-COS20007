using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player? player = null;
            Command lookCommand = new LookCommand();
            Command moveCommand = new MoveCommand();
            
            // Player creation menu
            while (player == null)
            {
                Console.Write("Please enter your name -> ");
                string? playerName = Console.ReadLine();
                Console.Write("How would you describe yourself? -> ");
                string? playerDescription = Console.ReadLine();
                Console.Write("You are {0}, {1}.\nIs this correct? (yes/no) -> ", playerName, playerDescription);
                bool confirmationMenuLoop = true;
                while (confirmationMenuLoop)
                {
                    string? decision = Console.ReadLine().ToLower();
                    switch (decision)
                    {
                        case "yes":
                            player = new Player(playerName, playerDescription);
                            confirmationMenuLoop = false;
                            break;
                        case "no":
                            confirmationMenuLoop = false;
                            break;
                        default:
                            Console.Write("Invalid option: please enter yes or no. -> ");
                            break;
                    }
                }
            }

            // Create Items
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "A sturdy shovel, the perfect tool for digging");
            Item bronzeSword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword forged from bronze");
            Item ruby = new Item(new string[] { "gem", "ruby" }, "a red gem", "A brilliant ruby, glows with a fiery red hue");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "A dusty PC with a flickering screen");
            Item laptop = new Item(new string[] { "laptop" }, "a laptop", "A compact, modern laptop with a matte black finish");
            Item bulletinBoard = new Item(new string[] { "bulletin_board" }, "a bulletin board", "A small bulletin board filled with announcements, flyers, and posters");
            Item server = new Item(new string[] { "server" }, "a server", "A sleek server that hums with activity, the heart of Swin Adventure");

            // Create Bags
            Bag laptopBag = new Bag(new string[] { "laptop_bag", "bag" }, "laptop bag", "A sleek, black laptop bag. Its fabric is slightly worn from use");
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A small bag crafted from supple brown leather, perfect for carrying items");
            
            // Create Locations
            Location classroom = new Location(new string[] { "classroom" }, "the Classroom", "This is a dimly lit classroom.");        // Player will initially be in the classroom
            Location hallway = new Location(new string[] { "hallway" }, "the Hallway", "This is a long well lit hallway, many Swin Adventurers are roaming around.");
            Location serverRoom = new Location(new string[] { "server_room" }, "the Server Room", "This is a dark server room. Rows of humming servers stand within sleek cabinets, bathed in dim light.");
            
            // Create Paths
            Path classroomToHallway = new Path(new string[] { "east", "hallway" }, hallway);
            Path hallwayToClassroom = new Path(new string[] { "west", "classroom" }, classroom);
            
            Path classroomToServerRoom = new Path(new string[] { "west", "server_room" }, serverRoom);
            Path serverRoomToClassroom = new Path(new string[] { "east", "classroom" }, classroom);

            // Add Paths to Locations
            classroom.AddPath(classroomToHallway);
            classroom.AddPath(classroomToServerRoom);
            hallway.AddPath(hallwayToClassroom);
            serverRoom.AddPath(serverRoomToClassroom);

            // Set Player Location
            player.Location = classroom;

            // Distribute Items to Player
            bag.Inventory.Put(ruby);
            player.Inventory.Put(shovel);
            player.Inventory.Put(bronzeSword);
            player.Inventory.Put(bag);

            // Distribute items to Classroom
            laptopBag.Inventory.Put(laptop);
            classroom.Inventory.Put(computer);
            classroom.Inventory.Put(laptopBag);
            
            // Distribute items to Hallway
            hallway.Inventory.Put(bulletinBoard);

            // Distribute items to Server Room
            serverRoom.Inventory.Put(server);

            
            // Introduction text
            Console.WriteLine("------------------------------");
            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine("You have arrived in {0}", player.Location.Name);

            // Game loop
            bool gameLoop = true;
            while (gameLoop)
            {
                Console.Write("Command -> ");
                string? playerInput = Console.ReadLine();
                string[] inputToPass = playerInput.Split(new char[] {  }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("");
                foreach (string input in inputToPass)
                {
                    if (lookCommand.AreYou(input))
                    {
                        Console.WriteLine(lookCommand.Execute(player, inputToPass));
                    }
                    else if (moveCommand.AreYou(input))
                    {
                        Console.WriteLine(moveCommand.Execute(player, inputToPass));
                    }
                }
            }
        }
    }
}
