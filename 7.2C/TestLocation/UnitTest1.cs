using SwinAdventure;

namespace TestLocation
{
    public class Tests
    {
        Location location;
        Item ruby;

        [SetUp]
        public void Setup()
        {
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
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
            string testLocationFullDescription = location.FullDescription;
            Assert.That(testLocationFullDescription, Is.EqualTo("You are in the Location\nThis is a test location\nIn this room you can see:\n  a red gem (gem)"));
        }
    }
}