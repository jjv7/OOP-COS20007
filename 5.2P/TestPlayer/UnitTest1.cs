using SwinAdventure;

namespace TestPlayer
{
    public class Tests
    {
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Player p = new Player("Tester", "the mighty test player");
            
            bool testPMe = p.AreYou("me");
            bool testPInventory = p.AreYou("inventory");
            Assert.That(testPMe, Is.EqualTo(true));
            Assert.That(testPInventory, Is.EqualTo(true));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Player p = new Player("Tester", "the mighty test player");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            GameObject testLocateShovel = p.Locate("shovel");
            GameObject testLocateBronzeSword = p.Locate("sword");
            Assert.That(testLocateShovel, Is.EqualTo(shovel));
            Assert.That(testLocateBronzeSword, Is.EqualTo(bronzeSword));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Player p = new Player("Tester", "the mighty test player");

            GameObject testLocatePMe = p.Locate("me");
            GameObject testLocatePInventory = p.Locate("inventory");
            Assert.That(testLocatePMe, Is.EqualTo(p));
            Assert.That(testLocatePInventory, Is.EqualTo(p));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Player p = new Player("Tester", "the mighty test player");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            GameObject testLocateNothing = p.Locate("nothing");
            Assert.That(testLocateNothing, Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player p = new Player("Tester", "the mighty test player");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            p.Inventory.Put(shovel);
            p.Inventory.Put(bronzeSword);

            string testFullDescription = p.FullDescription;
            Assert.That(testFullDescription, Is.EqualTo("You are Tester, the mighty test player.\nYou are carrying: \n  a shovel (shovel)\n  a bronze sword (sword)"));

        }
    }
}