namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });    // Example of Identifiable Object
            Player player = new Player("Jayden", "the mighty programmer");                    // Example of Player object
        }
    }
}
