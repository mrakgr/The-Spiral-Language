import rx
import numpy as np
from rx import operators as ops
import rx.operators

source = rx.from_iterable(["Alpha", "Beta", "Gamma", "Delta", "Epsilon"])

def qwe(x): return x
composed = source.pipe(
    ops.map(qwe)
)
composed.subscribe(lambda value: print("Received {0}".format(value)))
