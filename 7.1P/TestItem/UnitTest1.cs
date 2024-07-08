using SwinAdventure;
using System.Reflection.Metadata;

namespace TestItem
{
    public class Tests
    {
        [Test]
        public void TestItemIsIdentifiable()
        {
            // testing identifiers of Item object
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            bool testBronzeSwordID1 = bronzeSword.AreYou("sword");
            bool testBronzeSwordID2 = bronzeSword.AreYou("bronze sword");
            Assert.That(testBronzeSwordID1, Is.EqualTo(true));
            Assert.That(testBronzeSwordID2, Is.EqualTo(true));
        }

        [Test]

        public void TestItemShortDescription()
        {
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            string testBronzeSword = bronzeSword.ShortDescription;
            Assert.That(testBronzeSword, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test]

        public void TestItemFullDescription()
        {
            Item bronzeSword = new Item(new string[] { "sword", "bronze sword" }, "a bronze sword", "bronze sword description");
            string testBronzeSword = bronzeSword.FullDescription;
            Assert.That(testBronzeSword, Is.EqualTo("bronze sword description"));
        }
    }
}