from kivy.uix.gridlayout import GridLayout
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.widget import Widget
from kivy.uix.floatlayout import FloatLayout
from kivy.uix.scrollview import ScrollView
from kivy.core.window import Window
from kivy.app import runTouchApp
from kivy.lang import Builder

class MyWidget(Widget): pass

root = Builder.load_string('''
FloatLayout:
    canvas:
        Color:
            rgba: 0,0.8,0,1
        Rectangle:
            pos: self.pos
            size: self.size
    MyWidget:
        pos_hint: {'top': 0.99, 'right': 0.99}
        size_hint: 0.2,0.2

<MyWidget>:
    canvas:
        Color:
            rgba: 1,0,0,0.5
        Rectangle:
            pos: self.pos
            size: self.size
''')

if __name__ == '__main__': 
    # q = FloatLayout()
    # def f(x,b): print('size is',b)
    # q.bind(size=f)
    runTouchApp(root)