namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object.");

            myMessage.Print();

            List<Message> messages = new List<Message>();
            messages.Add(new Message("Hi Jayden, how are you?"));     // First Greeting
            messages.Add(new Message("Hi Enoch, how are you?"));      // Second Greeting
            messages.Add(new Message("Hi Joel, how are you?"));       // Third Greeting
            messages.Add(new Message("Hi Eric, how are you?"));       // Fourth Greeting
            messages.Add(new Message("Welcome, nice to meet you"));   // Standard Greeting

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            if (name.ToLower() == "jayden")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "enoch")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "joel")
            {
                messages[2].Print();
            }
            else if (name.ToLower() == "eric")
            {
                messages[3].Print();
            }
            else
            {
                messages[4].Print();
            }
        }
    }
}
