using SwinAdventure;

namespace TestPath
{
    public class Tests
    {
        private Location hallway;
        private SwinAdventure.Path testPathToHallway;
        private Player p;
        
        [SetUp]
        public void Setup()
        {
            hallway = new Location(new string[] { "hallway" }, "the Hallway", "This is a long well lit hallway, many Swin Adventurers are roaming around.");
            testPathToHallway = new SwinAdventure.Path(new string[] { "east", "hallway" }, hallway);
            p = new Player("Tester", "the mighty test player");
        }

        [Test]
        public void TestPathIsIdentifiable()
        {
            bool testPathIsIdentifiable = testPathToHallway.AreYou("east");
            Assert.That(testPathIsIdentifiable, Is.EqualTo(true));
        }

        [Test]
        public void TestPathMovesPlayer()
        {
            testPathToHallway.MovePlayer(p);
            Assert.That(p.Location, Is.EqualTo(hallway));
        }
    }
}