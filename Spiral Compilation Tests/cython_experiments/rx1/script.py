import rx
import rx.disposable
from rx import operators as ops

def f(observer,scheduler):
    observer.on_next("Hello")
rx.create(f)