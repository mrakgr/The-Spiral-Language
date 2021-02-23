from tkinter import *
root = Tk()
myLabel1 = Label(text="Hello World!")
myLabel2 = Label(text="My name is mrakgr!")

myLabel1.grid(row=0,column=0)
myLabel2.grid(row=1,column=0)
myLabel1.master = root
myLabel2.master = root

root.mainloop()