from counter import Counter

class Clock:
    def __init__(self):
        self._seconds = Counter("seconds")
        self._minutes = Counter("minutes")
        self._hours = Counter("hours")
    
    @property
    def time(self):
        return "{:02d}:{:02d}:{:02d}".format(self._hours.ticks, self._minutes.ticks, self._seconds.ticks)
    
    def tick(self):
        self._seconds.increment()
        if self._seconds.ticks == 60:
            self._minutes.increment()
            self._seconds.reset()
            if self._minutes.ticks == 60:
                self._hours.increment()
                self._minutes.reset()
                if self._hours.ticks == 24:
                    self._hours.reset()
    
    def reset(self):
        self._seconds.reset()
        self._minutes.reset()
        self._hours.reset()
        