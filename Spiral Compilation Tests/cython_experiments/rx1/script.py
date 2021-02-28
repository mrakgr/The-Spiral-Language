# import rx
# import rx.disposable
# import rx.subject
# from rx import operators as ops

q = rx.subject.behaviorsubject.BehaviorSubject(4)
print(q.value)
