using SwinAdventure;

namespace TestPutCommand
{
    public class Tests
    {
        private PutCommand put;
        private Player testPlayer;
        private Item gem;
        private Bag bag;
        private Location location;

        [SetUp]
        public void Setup()
        {
            put = new PutCommand();
            testPlayer = new Player("testPlayer", "test player description");
            gem = new Item(new string[] { "gem" }, "a gem", "gem's description");
            bag = new Bag(new string[] { "bag" }, "a bag", "bag's description");
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            testPlayer.Location = location;
            testPlayer.Inventory.Put(gem);
        }

        [Test]
        public void TestPutGem()
        {
            string testPutGem = put.Execute(testPlayer, new string[] { "put", "gem" });
            Item? testGemInLocation = location.Inventory.Fetch("gem");
            Item? testGemInPlayer = testPlayer.Inventory.Fetch("gem");
            Assert.That(testPutGem, Is.EqualTo("You have put the gem in the Location"));
            Assert.That(testGemInLocation, Is.EqualTo(gem));
            Assert.That(testGemInPlayer, Is.EqualTo(null));
        }

        [Test]
        public void TestPutUnknown()
        {
            string testPutUnknown = put.Execute(testPlayer, new string[] { "put", "unknown" });
            Assert.That(testPutUnknown, Is.EqualTo("I cannot find the unknown"));
        }

        [Test]
        public void TestPutGemInBag()
        {
            location.Inventory.Put(bag);
            string testPutGem = put.Execute(testPlayer, new string[] { "put", "gem", "in", "bag" });
            Item? testGemInBag = bag.Inventory.Fetch("gem");
            Item? testGemInPlayer = testPlayer.Inventory.Fetch("gem");
            Assert.That(testPutGem, Is.EqualTo("You have put the gem in the bag"));
            Assert.That(testGemInBag, Is.EqualTo(gem));
            Assert.That(testGemInPlayer, Is.EqualTo(null));
        }

        [Test]
        public void TestPutGemInNoBag() 
        {
            string testPutUnknown = put.Execute(testPlayer, new string[] { "put", "gem", "in", "bag" });
            Assert.That(testPutUnknown, Is.EqualTo("I cannot find the bag"));
        }

        [Test]
        public void TestPutGemInLocation()
        {
            string testPutGem = put.Execute(testPlayer, new string[] { "put", "gem", "in", "location" });
            Item? testGemInLocation = location.Inventory.Fetch("gem");
            Item? testGemInPlayer = testPlayer.Inventory.Fetch("gem");
            Assert.That(testPutGem, Is.EqualTo("You have put the gem in the location"));
            Assert.That(testGemInLocation, Is.EqualTo(gem));
            Assert.That(testGemInPlayer, Is.EqualTo(null));
        }

        [Test]
        public void TestInvalidPut()
        {
            string testIncorrectTextLength = put.Execute(testPlayer, new string[] { "put", "invalid", "length" });
            string testPutNotFirstWord = put.Execute(testPlayer, new string[] { "test", "put" });
            string testInNotThirdWord = put.Execute(testPlayer, new string[] { "put", "test", "and", "test" });

            Assert.That(testIncorrectTextLength, Is.EqualTo("I don't know how to put like that"));
            Assert.That(testPutNotFirstWord, Is.EqualTo("Error in put input"));
            Assert.That(testInNotThirdWord, Is.EqualTo("What do you want to put in?"));
        }
    }
}