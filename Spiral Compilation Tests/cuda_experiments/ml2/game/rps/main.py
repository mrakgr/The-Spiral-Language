kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
import collections
def Closure0():
    def inner() -> string:
        v0 = random.choice(["Rock", "Paper", "Scissors"])
        return v0
    return inner
def main():
    v0 = Closure0()
    v1 = collections.namedtuple("Functions",['random_action'])(v0)
    del v0
    return v1

if __name__ == '__main__': print(main().random_action())
