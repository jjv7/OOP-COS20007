using SwinAdventure;

namespace TestPickupCommand
{
    public class Tests
    {
        private PickupCommand pickup;
        private Player testPlayer;
        private Item gem;
        private Bag bag;
        private Location location;

        [SetUp]
        public void Setup()
        {
            pickup = new PickupCommand();
            testPlayer = new Player("testPlayer", "test player description");
            gem = new Item(new string[] { "gem" }, "a gem", "gem's description");
            bag = new Bag(new string[] { "bag" }, "a bag", "bag's description");
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            testPlayer.Location = location;
        }

        [Test]
        public void TestPickupGem()
        {
            location.Inventory.Put(gem);
            string testPickupGem = pickup.Execute(testPlayer, new string[] { "pickup", "gem" });
            Item? testGemInPlayer = testPlayer.Inventory.Fetch("gem");
            Assert.That(testPickupGem, Is.EqualTo("You have taken the gem from the Location"));
            Assert.That(testGemInPlayer, Is.EqualTo(gem));
        }

        [Test]
        public void TestPickupUnknown()
        {
            string testPickupUnknown = pickup.Execute(testPlayer, new string[] { "pickup", "unknown" });
            Assert.That(testPickupUnknown, Is.EqualTo("I cannot find the unknown"));
        }

        [Test]
        public void TestPickupGemInBag()
        {
            bag.Inventory.Put(gem);
            location.Inventory.Put(bag);
            string testPickupGem = pickup.Execute(testPlayer, new string[] { "pickup", "gem", "from", "bag" });
            Item? testGemInPlayer = testPlayer.Inventory.Fetch("gem");
            Assert.That(testPickupGem, Is.EqualTo("You have taken the gem from the bag"));
            Assert.That(testGemInPlayer, Is.EqualTo(gem));
        }

        [Test]
        public void TestPickupGemInNoBag()
        {
            string testPickupGem = pickup.Execute(testPlayer, new string[] { "pickup", "gem", "from", "bag" });
            Assert.That(testPickupGem, Is.EqualTo("I cannot find the bag"));
        }

        [Test]
        public void TestPickupNoGemInBag()
        {
            location.Inventory.Put(bag);
            string testPickupGem = pickup.Execute(testPlayer, new string[] { "pickup", "gem", "from", "bag" });
            Assert.That(testPickupGem, Is.EqualTo("I cannot find the gem in the bag"));
        }

        [Test]
        public void TestPickupGemFromLocation()
        {
            location.Inventory.Put(gem);
            string testPickupGem = pickup.Execute(testPlayer, new string[] { "pickup", "gem", "from", "location" });
            Assert.That(testPickupGem, Is.EqualTo("You have taken the gem from the location"));
        }

        [Test]
        public void TestInvalidPickup()
        {
            string testIncorrectTextLength = pickup.Execute(testPlayer, new string[] { "pickup", "invalid", "length" });
            string testPickupNotFirstWord = pickup.Execute(testPlayer, new string[] { "test", "pickup" });
            string testFromNotThirdWord = pickup.Execute(testPlayer, new string[] { "pickup", "test", "in", "test" });

            Assert.That(testIncorrectTextLength, Is.EqualTo("I don't know how to pickup like that"));
            Assert.That(testPickupNotFirstWord, Is.EqualTo("Error in pickup input"));
            Assert.That(testFromNotThirdWord, Is.EqualTo("What do you want to pickup from?"));
        }
    }
}