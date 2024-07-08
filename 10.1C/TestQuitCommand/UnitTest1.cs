using SwinAdventure;

namespace TestQuitCommand
{
    public class Tests
    {
        private QuitCommand quit;
        private Player testPlayer;


        [SetUp]
        public void Setup()
        {
            quit = new QuitCommand();
            testPlayer = new Player("testPlayer", "test player description");
        }

        [Test]
        public void TestQuit()
        {
            string testQuit = quit.Execute(testPlayer, new string[] { "quit" });
            Assert.That(testQuit, Is.EqualTo("Bye."));
        }

        [Test]
        public void TestInvalidQuit()
        {
            string testQuit = quit.Execute(testPlayer, new string[] { "invalid", "quit" });
            Assert.That(testQuit, Is.EqualTo("Error in quit input"));
        }
    }
}