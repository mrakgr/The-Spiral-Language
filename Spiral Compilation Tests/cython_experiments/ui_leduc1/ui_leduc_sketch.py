from kivy.uix.gridlayout import GridLayout
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.widget import Widget
from kivy.uix.floatlayout import FloatLayout
from kivy.uix.scrollview import ScrollView
from kivy.core.window import Window
from kivy.properties import NumericProperty
from kivy.app import runTouchApp
from kivy.lang import Builder

class Stack(Label):
    chips = NumericProperty(0)

root = Builder.load_string('''
<Table@FloatLayout>:
    canvas:
        Line:
            width: 2
            rectangle: self.x, self.y, self.width, self.height
    Stack: # Stack
        id: my_stack
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        text: 'Stack: ' + str(self.chips)
        x: root.x + root.width * 0.075
        y: root.y + root.height * 0.075
        font_size: sp(30)
        size_hint: None, None
        size: self.texture_size
    Label: # Card
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        color: 1,0,0,1
        font_name: 'RobotoMono-Regular'
        text: 'K'
        x: my_stack.right + dp(20)
        y: my_stack.y
        font_size: sp(70)
        size_hint: None, None
        size: self.texture_size
    Label: # Card
        id: op_card
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        color: 1,0,0,1
        font_name: 'RobotoMono-Regular'
        text: ' '
        x: root.x + root.width * 0.6
        y: root.y + root.height * 0.925 - self.height
        font_size: sp(70)
        size_hint: None, None
        size: self.texture_size
    Stack: # Stack
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        text: 'Stack: ' + str(self.chips)
        x: op_card.right + dp(20)
        y: op_card.top - self.height
        font_size: sp(30)
        size_hint: None, None
        size: self.texture_size
    Label: # Card
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        color: 1,0,0,1
        font_name: 'RobotoMono-Regular'
        text: 'Q'
        x: root.center_x - self.width/2
        y: root.center_y - self.height/2
        font_size: sp(70)
        size_hint: None, None
        size: self.texture_size
    Stack: # Pot
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        text: 'Pot: ' + str(self.chips)
        x: root.center_x - self.width / 2
        y: root.y + root.height / 4
        font_size: sp(30)
        size_hint: None, None
        size: self.texture_size
    Stack: # Pot
        canvas:
            Line: 
                rectangle: self.x, self.y, self.width, self.height
        text: 'Pot: ' + str(self.chips)
        x: root.center_x - self.width / 2
        y: root.y + root.height * 3 / 4 - self.height
        font_size: sp(30)
        size_hint: None, None
        size: self.texture_size
<Actions@BoxLayout>:
    canvas:
        Line:
            rectangle: self.x, self.y, self.width, self.height
    Button:
        font_size: sp(60)
        text: 'Call'
    Button:
        font_size: sp(60)
        text: 'Fold'
    Button:
        font_size: sp(60)
        text: 'Raise'
        disabled: True
BoxLayout:
    padding: dp(20), dp(20)
    spacing: dp(10)
    BoxLayout:
        orientation: 'vertical'
        spacing: dp(10)
        Table
        Actions:
            size_hint_y: 0.15
    ScrollView:
        canvas:
            Line:
                rectangle: self.x, self.y, self.width, self.height
        size_hint_x: 0.3
        Label:
            size_hint: None,None
            size: self.texture_size
            font_size: sp(18)
            text: 'Player One raises.'
''')

if __name__ == '__main__': runTouchApp(root)