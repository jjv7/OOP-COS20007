namespace _24HourClock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock myClock = new Clock();
            for (int i = 0; i < 3661; i++)
            {
                myClock.Tick();                 // Advances the clock forward by 3661 seconds
            }
            Console.WriteLine(myClock.Time);    // Should read "01:01:01"
        }
    }
}
