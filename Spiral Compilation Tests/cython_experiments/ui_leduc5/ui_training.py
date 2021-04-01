from kivy.uix.gridlayout import GridLayout
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.widget import Widget
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.floatlayout import FloatLayout
from kivy.uix.scrollview import ScrollView
from kivy.core.window import Window
from kivy.properties import NumericProperty, StringProperty, ObjectProperty, DictProperty, BooleanProperty
from kivy.app import runTouchApp
from kivy.lang import Builder

root = Builder.load_string('''

''')

if __name__ == '__main__': 
    runTouchApp(root)