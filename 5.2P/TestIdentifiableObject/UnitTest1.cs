using SwinAdventure;

namespace TestIdentifiableObject
{
    public class Tests
    {

        [Test]
        public void TestAreYou()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] { "fred", "bob" });

            bool fred = myIdents.AreYou("fred");
            Assert.That(fred, Is.EqualTo(true));
            bool bob = myIdents.AreYou("bob");
            Assert.That(bob, Is.EqualTo(true));
        }

        [Test]

        public void TestNotAreYou()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] { "fred", "bob" });
            
            bool wilma = myIdents.AreYou("wilma");
            Assert.That(wilma, Is.EqualTo(false));
            bool boby = myIdents.AreYou("boby");
            Assert.That(boby, Is.EqualTo(false));
        }

        [Test]

        public void TestCaseSensitive()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] { "fred", "bob" });
            
            bool fred = myIdents.AreYou("FRED");
            Assert.That(fred, Is.EqualTo(true));
            bool bob = myIdents.AreYou("bOB");
            Assert.That(bob, Is.EqualTo(true));
        }

        [Test]

        public void TestFirstID()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] { "fred", "bob" });
            
            string firstID = myIdents.FirstID;
            Assert.That(firstID, Is.EqualTo("fred"));
        }

        [Test]

        public void TestFirstIDNoIDs()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] {});

            string firstID = myIdents.FirstID;
            Assert.That(firstID, Is.EqualTo(""));
        }

        [Test]

        public void TestAddIDs()
        {
            IdentifiableObject myIdents = new IdentifiableObject(new string[] { "fred", "bob" });
            myIdents.AddIdentifier("wilma");

            bool fred = myIdents.AreYou("fred");
            Assert.That(fred, Is.EqualTo(true));
            bool bob = myIdents.AreYou("bob");
            Assert.That(bob, Is.EqualTo(true));
            bool wilma = myIdents.AreYou("wilma");
            Assert.That(wilma, Is.EqualTo(true));
        }
    }
}