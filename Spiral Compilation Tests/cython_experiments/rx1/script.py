import rx
import rx.disposable
from rx import operators as ops

def qwe():
    x = rx.disposable.serialdisposable.SerialDisposable()
    def f(): print("disposed")
    x.disposable = rx.disposable.disposable.Disposable(f)
    del x
qwe()