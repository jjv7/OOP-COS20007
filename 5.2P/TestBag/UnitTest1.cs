using SwinAdventure;

namespace TestBag
{
    public class Tests
    {
        [Test]
        public void TestBagLocatesItems()
        {
            Bag testBag = new Bag(new string[] { "bag", "testingBag"}, "test bag", "this is the test bag's description");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            testBag.Inventory.Put(shovel);

            GameObject testLocateShovel = testBag.Locate("shovel");
            GameObject testShovelRemainsInBag = testBag.Locate("shovel");
            Assert.That(testLocateShovel, Is.EqualTo(shovel));
            Assert.That(testShovelRemainsInBag, Is.EqualTo(shovel));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Bag testBag = new Bag(new string[] { "bag", "testingBag" }, "test bag", "this is the test bag's description");

            GameObject testLocateBagID1 = testBag.Locate("bag");
            GameObject testLocateBagID2 = testBag.Locate("testingBag");
            Assert.That(testLocateBagID1, Is.EqualTo(testBag));
            Assert.That(testLocateBagID2, Is.EqualTo(testBag));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Bag testBag = new Bag(new string[] { "bag", "testingBag" }, "test bag", "this is the test bag's description");

            GameObject testLocateShovel = testBag.Locate("shovel");
            Assert.That(testLocateShovel, Is.EqualTo(null));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Bag testBag = new Bag(new string[] { "bag", "testingBag" }, "test bag", "this is the test bag's description");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            testBag.Inventory.Put(shovel);
            testBag.Inventory.Put(bronzeSword);

            string testBagFullDescription = testBag.FullDescription;
            Assert.That(testBagFullDescription, Is.EqualTo("In the test bag you can see: \n  a shovel (shovel)\n  a bronze sword (sword)"));
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "bag", "testingBag1" }, "test bag 1", "this is test bag 1's description");
            Bag b2 = new Bag(new string[] { "bag", "testingBag2" }, "test bag 2", "this is test bag 2's description");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "shovel description");
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            b1.Inventory.Put(shovel);
            b2.Inventory.Put(bronzeSword);
            b1.Inventory.Put(b2);

            GameObject testB1LocatesB2 = b1.Locate("testingBag2");
            GameObject testB1LocatesShovel = b1.Locate("shovel");
            GameObject testB1LocatesBronzeSword = b1.Locate("sword");
            Assert.That(testB1LocatesB2, Is.EqualTo(b2));
            Assert.That(testB1LocatesShovel, Is.EqualTo(shovel));
            Assert.That(testB1LocatesBronzeSword, Is.EqualTo(null));
        }
    }
}