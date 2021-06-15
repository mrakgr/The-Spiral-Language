from kivy.uix.gridlayout import GridLayout
from kivy.uix.popup import Popup
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

class Stack(Label):
    chips = NumericProperty(0)

init_data = {'my_card': ' ', 'op_card': ' ', 'my_pot': 0, 'community_card': ' ', 'op_pot': 0}
class Table(FloatLayout):
    data = ObjectProperty(init_data)

init_actions = {'call': False, 'fold': False, 'raise': False}
class Actions(BoxLayout):
    actions = ObjectProperty(init_actions)

class Top(BoxLayout):
    data = ObjectProperty({'trace': '', 'actions': init_actions, 'table_data': init_data})

class Action(Button):
    action = ObjectProperty(False)
    def on_press(self): 
        if self.action: self.action()

class ShowB(Button):
    shown = BooleanProperty(False)
    def on_press(self): self.shown = not self.shown

Builder.load_string('''
<CardDef@Widget>:
    canvas:
        Line: 
            rectangle: self.x, self.y, self.width, self.height
    color: 1,1,1,1
    background_color: 0.59,0.295,0,1
    font_name: 'RobotoMono-Regular'
    font_size: sp(70)
    size_hint: None, None
    size: self.texture_size

<SwitchCard@ShowB+CardDef>
<Card@Label+CardDef>

<Stack>:
    canvas:
        Line:
            rectangle: self.x, self.y, self.width, self.height
    text: 'Stack: ' + str(self.chips)
    font_size: sp(30)
    size_hint: None, None
    size: self.texture_size

<Table>:
    canvas:
        Line:
            width: 2
            rectangle: self.x, self.y, self.width, self.height
    Card:
        text: root.data['my_card']
        pos_hint: {'x': 0.075, 'y': 0.075}
    SwitchCard:
        shown: False
        text: root.data['op_card'] if self.shown else ' '
        pos_hint: {'right': 0.925, 'top': 0.925}
    Card:
        id: community_card
        text: root.data['community_card']
        pos_hint: {'center_x': 0.5, 'center_y': 0.5}
    Stack: # My Pot
        chips: root.data['my_pot']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5}
        top: community_card.y - dp(10)
    Stack: # Opponent Pot
        chips: root.data['op_pot']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5}
        y: community_card.top + dp(10)

<Action>:
    font_size: sp(60)
    disabled: self.action == False

<Actions>:
    canvas:
        Line:
            rectangle: self.x, self.y, self.width, self.height
    Action:
        action: root.actions['fold']
        text: 'Fold'
    Action:
        action: root.actions['call']
        text: 'Call'
    Action:
        action: root.actions['raise']
        text: 'Raise'

<Top>:
    orientation: 'vertical'
    BoxLayout:
        padding: dp(20), dp(20)
        spacing: dp(10)
        BoxLayout:
            orientation: 'vertical'
            spacing: dp(10)
            Table:
                data: root.data['table_data']
            Actions:
                actions: root.data['actions']
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
                text: root.data['trace']
    Button:
        text: 'Start Game'
        font_size: sp(50)
        size_hint_y: 0.15
        on_press: root.start_game() # Should be monkey patched.
''')

def start_game(root,runner):
    root.start_game = runner
    runTouchApp(root)

if __name__ == '__main__':
    runTouchApp(Top())