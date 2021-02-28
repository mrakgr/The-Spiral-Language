import rx
import rx.disposable
from rx import operators as ops

q = rx.disposable.disposable.Disposable(lambda *x: print("qwe"))
x = rx.disposable.serialdisposable.SerialDisposable()
x.disposable = q
x.disposable = q
x.disposable = q
x.disposable = q