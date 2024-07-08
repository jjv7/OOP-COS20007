using SwinAdventure;

namespace TestMoveCommand
{
    public class Tests
    {
        private MoveCommand move;
        private Player testPlayer;
        private Location location;
        private Location hallway;
        private SwinAdventure.Path testPathToHallway;


        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            testPlayer = new Player("testPlayer", "test player description");
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            hallway = new Location(new string[] { "hallway" }, "the Hallway", "This is a long well lit hallway, many Swin Adventurers are roaming around.");
            testPathToHallway = new SwinAdventure.Path(new string[] { "east", "hallway" }, hallway);
            testPlayer.Location = location;
            location.AddPath(testPathToHallway);
        }

        [Test]
        public void TestMovePlayerToValidDirection()
        {
            string testMoveToDirection = move.Execute(testPlayer, new string[] { "move", "east" });
            Assert.That(testMoveToDirection, Is.EqualTo("You head east\nYou have arrived in the Hallway"));
            Assert.That(testPlayer.Location, Is.EqualTo(hallway));
        }

        [Test]
        public void TestMovePlayerToInvalidDirection()
        {
            string testMoveToDirection = move.Execute(testPlayer, new string[] { "move", "west" });
            Assert.That(testMoveToDirection, Is.EqualTo("I cannot move west"));
            Assert.That(testPlayer.Location, Is.EqualTo(location));
        }

        [Test]
        public void TestInvalidMove()
        {
            string testTextLengthNot2 = move.Execute(testPlayer, new string[] { "move", "test", "length", "not", "two" });
            string testMoveIsNotFirstWord = move.Execute(testPlayer, new string[] { "test", "move" });
            string testMoveToUnknownDirection = move.Execute(testPlayer, new string[] { "move", "unknown" });
            
            Assert.That(testTextLengthNot2, Is.EqualTo("I don't know how to move like that"));
            Assert.That(testMoveIsNotFirstWord, Is.EqualTo("Error in move input"));
            Assert.That(testMoveToUnknownDirection, Is.EqualTo("I don't know that direction"));
            Assert.That(testPlayer.Location, Is.EqualTo(location));                                     // Player stays in current location
        }
    }
}