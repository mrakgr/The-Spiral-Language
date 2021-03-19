from kivy.uix.gridlayout import GridLayout
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.scrollview import ScrollView
from kivy.core.window import Window
from kivy.app import runTouchApp
from kivy.lang import Builder

# Builder.load_string ('''
# <ScrollableLabel>:
#     Label:
#         text: 'some really really long string \\n' * 100
#         # text_size: self.width, None
#         size_hint_y: None
#         height: self.texture_size[1]
# ''')

# class ScrollableLabel(ScrollView): pass

# runTouchApp(ScrollableLabel())

layout = Label()
layout.text = 'really some amazing text\n' * 100
layout.size_hint_y = None
def f(c,x): c.height = x[1]
layout.fbind('texture_size',f)

root = ScrollView()
root.add_widget(layout)
runTouchApp(root)
