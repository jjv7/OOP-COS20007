namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player? player = null;
            Command lookCommand = new LookCommand();
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

            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "A sturdy shovel, the perfect tool for digging");
            Item bronzeSword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword forged from bronze");
            Item ruby = new Item(new string[] { "gem", "ruby" }, "a red gem", "A brilliant ruby, glows with a fiery red hue");
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "Crafted from supple brown leather, this small bag is perfect for carrying items");
            Item computer = new Item(new string[] { "pc" }, "a small computer", "A dusty PC with a flickering screen");
            Bag laptopBag = new Bag(new string[] { "laptop_bag", "bag" }, "laptop bag", "A sleek, black laptop bag. Its fabric is slightly worn from use");
            Item laptop = new Item(new string[] { "laptop" }, "a laptop", "A compact, modern laptop with a matte black finish");
            Location classroom = new Location(new string[] { "classroom", "location" }, "the Classroom", "This is a dimly lit classroom");        // Player will initially be in the classroom

            player.Location = classroom;
            laptopBag.Inventory.Put(laptop);
            player.Location.Inventory.Put(computer);
            player.Location.Inventory.Put(laptopBag);
            bag.Inventory.Put(ruby);
            player.Inventory.Put(shovel);
            player.Inventory.Put(bronzeSword);
            player.Inventory.Put(bag);

            Console.WriteLine("------------------------------");
            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine("You have arrived in {0}", player.Location.Name);

            bool gameLoop = true;
            while (gameLoop)
            {
                Console.Write("Command -> ");
                string? playerInput = Console.ReadLine();
                string[] inputToPass = playerInput.Split(new char[] {  }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("");
                Console.WriteLine(lookCommand.Execute(player, inputToPass));
            }
        }
    }
}
