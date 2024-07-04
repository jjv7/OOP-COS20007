using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourClock
{
    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;

        public string Time
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}", _hours.Ticks, _minutes.Ticks, _seconds.Ticks);
            }
        }
           
        public Clock()
        {
            _seconds = new Counter("seconds");
            _minutes = new Counter("minutes");
            _hours = new Counter("hours");            
        }

        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Ticks == 60)
            {
                _minutes.Increment();
                _seconds.Reset();
            }
            if (_minutes.Ticks == 60)
            {
                _hours.Increment();
                _minutes.Reset();
            }
            if ( _hours.Ticks == 24)
            {
                _hours.Reset();
            }
        }

        public void Reset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();
        }

    }
}
