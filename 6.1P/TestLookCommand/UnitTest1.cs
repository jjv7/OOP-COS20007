using SwinAdventure;


namespace TestLookCommand
{
    public class Tests
    {
        private LookCommand look;
        private Player testPlayer;
        private Item gem;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            testPlayer = new Player("testPlayer", "test player description");
            gem = new Item(new string[] { "gem" }, "a gem", "gem's description");
            bag = new Bag(new string[] { "bag" }, "a bag", "bag's description");
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
    }
}