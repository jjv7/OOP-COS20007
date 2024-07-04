using SwinAdventure;

namespace TestInventory
{
    public class Tests
    {

        [Test]
        public void TestFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            Inventory testInventory = new Inventory();
            testInventory.Put(shovel);
            testInventory.Put(bronzeSword);

            bool testShovel = testInventory.HasItem("shovel");
            bool testBronzeSword = testInventory.HasItem("sword");
            Assert.That(testShovel, Is.EqualTo(true));
            Assert.That(testBronzeSword, Is.EqualTo(true));
        }

        [Test]
        public void TestNoItemFind()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            Inventory testInventory = new Inventory();
            testInventory.Put(shovel);
            testInventory.Put(bronzeSword);

            bool testSmallComputer = testInventory.HasItem("pc");
            Assert.That(testSmallComputer, Is.EqualTo(false));
        }

        [Test]
        public void TestFetchItem() 
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            Inventory testInventory = new Inventory();
            testInventory.Put(shovel);
            testInventory.Put(bronzeSword);

            Item testShovel = testInventory.Fetch("shovel");
            Item testBronzeSword = testInventory.Fetch("sword");
            Assert.That(testShovel, Is.EqualTo(shovel));
            Assert.That(testBronzeSword, Is.EqualTo(bronzeSword));
        }

        [Test]
        public void TestTakeItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            Inventory testInventory = new Inventory();
            testInventory.Put(shovel);
            testInventory.Put(bronzeSword);

            Item testFetchShovel = testInventory.Take("shovel");
            bool testShovelInInventory = testInventory.HasItem("shovel");
            Assert.That(testFetchShovel, Is.EqualTo(shovel));
            Assert.That(testShovelInInventory, Is.EqualTo(false));
        }

        [Test]
        public void TestItemList()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            Inventory testInventory = new Inventory();
            testInventory.Put(shovel);
            testInventory.Put(bronzeSword);

            string testInventoryList = testInventory.ItemList;
            Assert.That(testInventoryList, Is.EqualTo("\n  a shovel (shovel)\n  a bronze sword (sword)"));
        }
    }
}