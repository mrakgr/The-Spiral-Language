# from numpy import ndarray
# import numpy as np
# from dataclasses import dataclass
# from typing import NamedTuple, Union, Callable, Tuple
# i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

# MList = Union["Nil", "Cons"]
# class Nil(NamedTuple): pass
# class Cons(NamedTuple):
#     """
#     qwe
#     """
#     head : int
#     tail : MList

# def f(a: int):
#     def inner(b: int) -> int:
#         return a+b
#     return inner

# def g(x : Callable[[int],int]) -> int:
#     return x(1)

# def h(x : MList):
#     (q,w) = (1,2)
#     match x:
#         case Cons(a,b):
#             return a + h(b)
#         case Nil():
#             return 0

# h(Cons(1,Cons(2,Cons(3,Nil()))))

# from typing import TypeVar, Generic
# T = TypeVar('T')

# @dataclass 
# class Rec(Generic[T]):
#     a : int
#     b : T

# q = Rec(1,"2.5")
# q.a = 4
# q

from numpy import ndarray
a : ndarray[int] = 1
q = a