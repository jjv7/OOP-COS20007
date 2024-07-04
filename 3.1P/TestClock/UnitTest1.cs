using _24HourClock;

namespace TestClock
{
    public class Tests
    {

        [Test]
        public void TestSecondsToMinutes()
        {
            // testing for 60 seconds
            Clock testClock = new Clock();
            for (int i = 0; i < 60; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time, Is.EqualTo("00:01:00"));
        }

        [Test]
        public void TestMinutesToHours()
        {
            // testing for 60 minutes
            Clock testClock = new Clock();
            for (int i = 0; i < 3600; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time, Is.EqualTo("01:00:00"));
        }

        [Test]
        public void TestMidnightCycle()
        {
            // testing for 24:00:00 changing to 00:00:00
            Clock testClock = new Clock();
            for (int i = 0; i < 86400; i++)
            {
                testClock.Tick();
            }
            Assert.That(testClock.Time, Is.EqualTo("00:00:00"));
        }

        [Test]
        public void TestReset()
        {
            Clock testClock = new Clock();
            for (int i = 0; i < 8642; i++)
            {
                testClock.Tick();
            }
            testClock.Reset();
            Assert.That(testClock.Time, Is.EqualTo("00:00:00"));
        }

    }
}