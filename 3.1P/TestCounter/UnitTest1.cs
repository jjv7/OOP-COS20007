using _24HourClock;

namespace TestCounter
{
    public class Tests
    {

        [Test]
        public void TestInitialisation()
        {
            Counter testCounter = new Counter("test");
            int value = testCounter.Ticks;
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void TestSingleIncrement() 
        {
            Counter testCounter = new Counter("test");
            testCounter.Increment();
            int value = testCounter.Ticks;
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void TestMultipleIncrements()
        {
            Counter testCounter = new Counter("test");
            for (int i = 0; i < 10; i++)
            {
                testCounter.Increment();

            }
            int value = testCounter.Ticks;
            Assert.That(value, Is.EqualTo(10));
        }

        [Test]
        public void TestReset()
        {
            Counter testCounter = new Counter("test");
            for (int i = 0; i < 10; i++)
            {
                testCounter.Increment();

            }
            testCounter.Reset();
            int value = testCounter.Ticks;
            Assert.That(value, Is.EqualTo(0));
        }
    }
}