using SwinAdventure;

namespace TestPlayer
{
    public class Tests
    {
        Location location;
        Item ruby;
        Player p;
        Item shovel;
        Item bronzeSword;

        [SetUp]
        public void Setup()
        {
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            ruby = new Item(new string[] { "gem", "ruby" }, "a red gem", "A brilliant ruby, glows with a fiery red hue");
            p = new Player("Tester", "the mighty test player");
            shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
        }


        [Test]
        public void TestPlayerIsIdentifiable()
        {
            bool testPMe = p.AreYou("me");
            bool testPInventory = p.AreYou("inventory");
            Assert.That(testPMe, Is.EqualTo(true));
            Assert.That(testPInventory, Is.EqualTo(true));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            GameObject? testLocateShovel = p.Locate("shovel");
            GameObject? testLocateBronzeSword = p.Locate("sword");
            Assert.That(testLocateShovel, Is.EqualTo(shovel));
            Assert.That(testLocateBronzeSword, Is.EqualTo(bronzeSword));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            GameObject? testLocatePMe = p.Locate("me");
            GameObject? testLocatePInventory = p.Locate("inventory");
            Assert.That(testLocatePMe, Is.EqualTo(p));
            Assert.That(testLocatePInventory, Is.EqualTo(p));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            GameObject? testLocateNothing = p.Locate("nothing");
            Assert.That(testLocateNothing, Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            string testFullDescription = p.FullDescription;
            Assert.That(testFullDescription, Is.EqualTo("You are Tester, the mighty test player.\nYou are carrying: \n  a shovel (shovel)\n  a bronze sword (sword)"));
        }

        [Test]
        public void TestPlayerLocatesItemsInLocation()
        {
            location.Inventory.Put(ruby);
            p.Location = location;

            GameObject? testPlayerLocatesRubyInLocation = p.Locate("ruby");
            Assert.That(testPlayerLocatesRubyInLocation, Is.EqualTo(ruby));
        }

        [Test]
        public void TestPlayerLocatesNoItemsInLocation()
        {
            p.Location = location;

            GameObject? testPlayerLocatesNothingInLocation = p.Locate("nothing");
            Assert.That(testPlayerLocatesNothingInLocation, Is.EqualTo(null));
        }
    }
}