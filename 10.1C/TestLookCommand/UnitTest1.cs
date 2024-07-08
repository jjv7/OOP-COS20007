using SwinAdventure;


namespace TestLookCommand
{
    public class Tests
    {
        private LookCommand look;
        private Player testPlayer;
        private Item gem;
        private Bag bag;
        private Location location;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            testPlayer = new Player("testPlayer", "test player description");
            gem = new Item(new string[] { "gem" }, "a gem", "gem's description");
            bag = new Bag(new string[] { "bag" }, "a bag", "bag's description");
            location = new Location(new string[] { "location" }, "the Location", "This is a test location");
            testPlayer.Location = location;
        }

        [Test]
        public void TestLookAtMe()
        {
            string testLookAtInventory = look.Execute(testPlayer, new string[] { "look", "at", "inventory" });
            Assert.That(testLookAtInventory, Is.EqualTo("You are testPlayer, test player description.\nYou are carrying: "));
        }

        [Test]
        public void TestLookAtGem()
        {
            testPlayer.Inventory.Put(gem);
            string testLookAtGem = look.Execute(testPlayer, new string[] { "look", "at", "gem" });
            Assert.That(testLookAtGem, Is.EqualTo("gem's description"));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            string testLookAtUnknown = look.Execute(testPlayer, new string[] { "look", "at", "gem" });
            Assert.That(testLookAtUnknown, Is.EqualTo("I cannot find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            testPlayer.Inventory.Put(gem);
            string testLookAtGem = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.That(testLookAtGem, Is.EqualTo("gem's description"));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            testPlayer.Inventory.Put(bag);
            string testLookAtGemInBag = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(testLookAtGemInBag, Is.EqualTo("gem's description"));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string testLookAtGemInNoBag = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(testLookAtGemInNoBag, Is.EqualTo("I cannot find the bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            testPlayer.Inventory.Put(bag);
            string testLookAtNoGemInBag = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(testLookAtNoGemInBag, Is.EqualTo("I cannot find the gem in the bag"));
        }

        [Test]
        public void TestInvalidLook()
        {
            string testIncorrectTextLength = look.Execute(testPlayer, new string[] { "testing", "incorrect", "text", "length" });
            string testLookNotFirstWord = look.Execute(testPlayer, new string[] { "testing", "look", "is", "not", "first" });
            string testAtNotSecondWord = look.Execute(testPlayer, new string[] { "look", "test", "at", "not", "second" });
            string testInNotFourthWord = look.Execute(testPlayer, new string[] { "look", "at", "in", "not", "fourth" });
            Assert.That(testIncorrectTextLength, Is.EqualTo("I don't know how to look like that"));
            Assert.That(testLookNotFirstWord, Is.EqualTo("Error in look input"));
            Assert.That(testAtNotSecondWord, Is.EqualTo("What do you want to look at?"));
            Assert.That(testInNotFourthWord, Is.EqualTo("What do you want to look in?"));
        }

        [Test]
        public void TestLook()
        {
            location.Inventory.Put(gem);
            string testLook = look.Execute(testPlayer, new string[] { "look" });
            Assert.That(testLook, Is.EqualTo("You are in the Location\nThis is a test location\nIn this room you can see:\n  a gem (gem)"));
        }

        [Test]
        public void TestLookAtLocation()
        {
            location.Inventory.Put(gem);
            string testLookAtLocation = look.Execute(testPlayer, new string[] { "look", "at", "location" });
            Assert.That(testLookAtLocation, Is.EqualTo("You are in the Location\nThis is a test location\nIn this room you can see:\n  a gem (gem)"));
        }

        [Test]
        public void TestLookAtGemInLocation()
        {
            location.Inventory.Put(gem);
            string testLookAtGem = look.Execute(testPlayer, new string[] { "look", "at", "gem" });
            string testLookAtGemInLocation = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "location" });
            Assert.That(testLookAtGem, Is.EqualTo("gem's description"));
            Assert.That(testLookAtGemInLocation, Is.EqualTo("gem's description"));
        }

        [Test]
        public void TestLookAtNoGemInLocation()
        {
            string testLookAtGemInLocation = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "location" });
            Assert.That(testLookAtGemInLocation, Is.EqualTo("I cannot find the gem in the location"));
        }

        [Test]
        public void TestLookAtGemInBagInLocation()
        {
            bag.Inventory.Put(gem);
            location.Inventory.Put(bag);
            string testLookAtGemInBag = look.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(testLookAtGemInBag, Is.EqualTo("gem's description"));
        }
    }
}