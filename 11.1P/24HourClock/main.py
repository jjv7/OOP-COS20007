from clock import Clock

my_clock = Clock()
for i in range(3661):
    my_clock.tick()
    # print(my_clock.time)
print(my_clock.time)      # Prints 01:01:01
