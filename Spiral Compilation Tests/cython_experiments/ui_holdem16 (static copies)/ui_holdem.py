from functools import partial
from kivy.uix.gridlayout import GridLayout
from kivy.uix.layout import Layout
from kivy.uix.popup import Popup
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.widget import Widget
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.floatlayout import FloatLayout
from kivy.uix.scrollview import ScrollView
from kivy.uix.accordion import Accordion
from kivy.core.window import Window
from kivy.properties import NumericProperty, StringProperty, ObjectProperty, DictProperty, BooleanProperty
from kivy.app import App
from kivy.lang import Builder
from kivy.metrics import dp
from belief import model_exploit
import torch

class Stack(Label):
    chips = NumericProperty(0)

init_data = {'my_stack': 0,'my_pot': 0,'my_card': '  ','op_stack': 0,'op_pot': 0,'op_card': '  ','community_card': ''}
class Table(FloatLayout):
    data = ObjectProperty(init_data)

init_actions = {'call': False,'fold': False,'raise_to': False,'raise_min': 3,'raise_max': 5}
class Actions(BoxLayout):
    actions = ObjectProperty(init_actions)

init_top = {'trace': '','actions': init_actions,'table_data': init_data}
class Top(FloatLayout):
    data = ObjectProperty(init_top)

    def set_data(self,x): 
        self.data = x

class Action(Button):
    action = ObjectProperty(False)

class ShowB(Button):
    shown = BooleanProperty(False)
    def on_press(self): self.shown = not self.shown

Builder.load_string('''
#:import math math
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

<SwitchCard@ShowB+CardDef>:
    markup: True
<Card@Label+CardDef>
    markup: True

<PowTwoSlider@Slider>:
    pow_value: round(2 ** self.value)

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
        text: root.data['op_card'] if self.shown else '  '
        pos_hint: {'right': 0.925, 'top': 0.925}
    Card:
        id: community_card
        text: root.data['community_card']
        pos_hint: {'center_x': 0.5, 'center_y': 0.5}
    Stack: # My Stack
        chips: root.data['my_stack']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5, 'y': 0.075}
    Stack: # My Pot
        chips: root.data['my_pot']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5}
        top: community_card.y - dp(10)
    Stack: # Opponent Stack
        chips: root.data['op_stack']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5, 'top': 0.925}
    Stack: # Opponent Pot
        chips: root.data['op_pot']
        text: str(self.chips)
        pos_hint: {'center_x': 0.5}
        y: community_card.top + dp(10)

<Action>:
    font_size: sp(30)
    disabled: self.action == False

<Actions>:
    canvas:
        Line:
            rectangle: self.x, self.y, self.width, self.height
    Action:
        action: root.actions['fold']
        text: 'Fold'
        size_hint_x: 0.3
        on_press: self.action()
    Action:
        action: root.actions['call']
        text: 'Call'
        size_hint_x: 0.3
        on_press: self.action()
    Action:
        action: root.actions['raise_to']
        text: 'Raise ' + str(round(slider.value))
        size_hint_x: 0.6
        on_press: self.action(round(slider.value))
    Slider:
        id: slider
        min: root.actions['raise_min']
        max: root.actions['raise_max']
        step: 1
        value: root.actions['raise_min']

<Top>:
    Accordion:
        orientation: 'vertical'
        min_space: dp(30)
        AccordionItem:
            min_space: self.parent.min_space
            collapse: False
            title: 'Game'
            BoxLayout:
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
                        size_hint_x: 0.5
                        Label:
                            size_hint: None,None
                            size: self.texture_size
                            font_size: sp(18)
                            markup: True
                            text: root.data['trace']
                Button:
                    text: 'Start Game'
                    font_size: sp(50)
                    size_hint_y: 0.15
                    on_press: 
                        b = 0 if is_p1.active else 1
                        is_p1.active = is_p1.active == False if is_toggle_player.active else is_p1.active
                        if gm_holdem.active: game_mode = 0
                        elif gm_flop.active: game_mode = 1
                        elif gm_river.active: game_mode = 2
                        else: raise Exception('One of the game mode buttons should be active.')
                        root.start_game(game_mode,sb.pow_value,bb.pow_value,stack_size.pow_value,b,root.set_data) # start_game should be monkey patched.
        AccordionItem:
            min_space: self.parent.min_space
            title: 'Settings'
            BoxLayout:
                orientation: 'vertical'
                size_hint_y: 0.25
                BoxLayout:
                    Label:
                        text: 'Toggle position on new game:'
                        size_hint_x: 0.4
                    CheckBox:
                        id: is_toggle_player
                        active: True
                BoxLayout:
                    Label:
                        text: 'Start in first position:'
                        size_hint_x: 0.4
                    CheckBox:
                        id: is_p1
                        active: True
                BoxLayout:
                    Label:
                        text: 'Small Blind(' + str(sb.pow_value) + '):'
                        size_hint_x: 0.4
                    PowTwoSlider:
                        id: sb
                        min: 0
                        max: math.log2(bb.pow_value)
                        value: math.log2(10)
                BoxLayout:
                    Label:
                        text: 'Big Blind(' + str(bb.pow_value) + '):'
                        size_hint_x: 0.4
                    PowTwoSlider:
                        id: bb
                        min: math.log2(sb.pow_value)
                        max: math.log2(1000)
                        value: math.log2(20)
                BoxLayout:
                    Label:
                        text: 'Stack Size(' + str(stack_size.pow_value) + '):'
                        size_hint_x: 0.4
                    PowTwoSlider:
                        id: stack_size
                        min: math.log2(1)
                        max: math.log2(1000)
                        value: math.log2(1000)
                BoxLayout:
                    Label:
                        text: 'Game Mode'
                    Label:
                        text: 'Holdem'
                    CheckBox:
                        group: 'gm'
                        id: gm_holdem
                        active: True
                    Label:
                        text: 'Flop'
                    CheckBox:
                        group: 'gm'
                        id: gm_flop
                    Label:
                        text: 'River'
                    CheckBox:
                        group: 'gm'
                        id: gm_river
''')

def load_neural(path,neural):
    with open(path,'rb') as f: 
        return neural.handler(partial(model_exploit,None,*torch.load(f),False,False))

if __name__ == '__main__':
    from kivy.core.window import Window
    Window.left = dp(120)
    Window.top = dp(40)
    Window.size = dp(1000), dp(600)

    app = App()
    app.root = Top()
    app.title = "HU Holdem Poker"
    
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_holdem import main
    args = main()

    ui = args['ui']
    train = args['train']
    player = train['player']
    neural_player = load_neural('dump holdem/nn_agent_19.nnreg',train['neural'])

    app.root.start_game = ui(neural_player)
    app.run()