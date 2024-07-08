using SwinAdventure;

namespace TestLocation
{
    public class Tests
    {
        private Location location;
        private Item ruby;
        private SwinAdventure.Path testPathToHallway;
        private Location hallway;


        [SetUp]
        public void Setup()
        {
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            hallway = new Location(new string[] { "hallway" }, "the Hallway", "This is a long well lit hallway, many Swin Adventurers are roaming around.");
            testPathToHallway = new SwinAdventure.Path(new string[] { "east", "hallway" }, hallway);
            ruby = new Item(new string[] { "gem", "ruby" }, "a red gem", "A brilliant ruby, glows with a fiery red hue");
            location.Inventory.Put(ruby);
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            GameObject? testLocationId = location.Locate("location");
            Assert.That(testLocationId, Is.EqualTo(location));
        }

        [Test]
        public void TestLocationLocatesItems()
        {
            GameObject? testLocationLocatesRuby = location.Locate("ruby");
            Assert.That(testLocationLocatesRuby, Is.EqualTo(ruby));
        }

        [Test]
        public void TestLocationLocatesItself()
        {
            GameObject? testLocationLocatesItself = location.Locate("location");
            Assert.That(testLocationLocatesItself, Is.EqualTo(location));
        }

        [Test]
        public void TestLocationlocatesNothing()
        {
            GameObject? testLocationLocatesItself = location.Locate("nothing");
            Assert.That(testLocationLocatesItself, Is.EqualTo(null));
        }

        [Test]
        public void TestLocationFullDescription()
        {
            location.AddPath(testPathToHallway);
            string testLocationFullDescription = location.FullDescription;
            Assert.That(testLocationFullDescription, Is.EqualTo("You are in the Location\nThis is a test location\nThere are exits to the east.\nIn this room you can see:\n  a red gem (gem)"));
        }

        [Test]
        public void TestLocationFetchesPath()
        {
            location.AddPath(testPathToHallway);
            SwinAdventure.Path? testFetchPath = location.FetchPath("east");
            Assert.That(testFetchPath, Is.EqualTo(testPathToHallway));
        }

        [Test]
        public void TestLocationFetchesNoPath()
        {
            SwinAdventure.Path? testFetchPath = location.FetchPath("east");
            Assert.That(testFetchPath, Is.EqualTo(null));
        }
    }
}