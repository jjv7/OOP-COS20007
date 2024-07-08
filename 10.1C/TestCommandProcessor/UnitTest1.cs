using SwinAdventure;

namespace TestCommandProcessor
{
    public class Tests
    {
        private CommandProcessor command;
        private Player testPlayer;
        private Location location;
        
        [SetUp]
        public void Setup()
        {
            command = new CommandProcessor();
            testPlayer = new Player("testPlayer", "test player description");
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            testPlayer.Location = location;
        }

        [Test]
        public void TestProcessorExecutesLook()
        {
            string? testLook = command.Execute(testPlayer, "look");
            Assert.That(testLook, Is.EqualTo("You are in the Location\nThis is a test location\nIn this room you can see:"));
        }

        [Test]
        public void TestProcessorExecutesMove()
        {
            string? testMove = command.Execute(testPlayer, "move");
            Assert.That(testMove, Is.EqualTo("I don't know how to move like that"));
        }

        [Test]
        public void TestProcessorExecutesPickup()
        {
            string? testPickup = command.Execute(testPlayer, "pickup");
            Assert.That(testPickup, Is.EqualTo("I don't know how to pickup like that"));
        }

        [Test]
        public void TestProcessorExecutesPut()
        {
            string? testPut = command.Execute(testPlayer, "put");
            Assert.That(testPut, Is.EqualTo("I don't know how to put like that"));
        }

        [Test]
        public void TestProcessorExecutesQuit()
        {
            string? testQuit = command.Execute(testPlayer, "quit");
            Assert.That(testQuit, Is.EqualTo("Bye."));
        }

        [Test]
        public void TestProcessorDoesNotExecuteUnknownInput()
        {
            string? testUnknown = command.Execute(testPlayer, "unknown");
            Assert.That(testUnknown, Is.EqualTo("I can't understand unknown"));
        }

        [Test]
        public void TestProcessorDoesNotExecuteNoInput()
        {
            string? testEmpty = command.Execute(testPlayer, "");
            Assert.That(testEmpty, Is.EqualTo(null));

        }
    }
}