import multiprocessing
def f(): print("ok")

cpdef main():
    multiprocessing.Process(target=f).start()
    print("done")

if __name__ == '__main__':
    multiprocessing.freeze_support()

