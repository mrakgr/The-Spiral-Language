import random
from typing import TypeVar

class static_array_list(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)
        self.length = length

static_array = list
def foo(x : static_array_list):
    pass

x = static_array_list(10)
x[0] = 123
print(x[1])