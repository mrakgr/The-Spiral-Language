from random import randint

from kivy.app import App
from kivy.base import runTouchApp
from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
from kivy.properties import StringProperty

class RowFields(BoxLayout):
    trace = StringProperty('')
    reward = StringProperty('')
    prob_self = StringProperty('')
    prob_op = StringProperty('')
    actions = StringProperty('')

class Main(BoxLayout):
    def populate(self): self.buffer_view.data = self.populate_call()
    def clear(self):
        self.buffer_view.data = []

root = Builder.load_string("""
<FieldLabel@Label>:
    font_name: 'RobotoMono-Regular'
    text_size: self.size
    halign: 'left'
    valign: 'center'

<RowFields>:
    size_hint_y: None
    height: dp(40)
    FieldLabel:
        size_hint_x: 0.4
        text: root.trace
        markup: True
    FieldLabel:
        size_hint_x: 0.2
        text: root.reward
    FieldLabel:
        size_hint_x: 0.25
        text: root.prob_self
    FieldLabel:
        size_hint_x: 0.25
        text: root.prob_op
    FieldLabel:
        size_hint_x: 0.2
        text: root.actions

<Row@RecycleDataViewBehavior+RowFields>:
    canvas.before:
        Color:
            rgba: 0.5, 0.5, 0.5, 1
        Rectangle:
            size: self.size
            pos: self.pos

Main:
    canvas:
        Color:
            rgba: 0.3, 0.3, 0.3, 1
        Rectangle:
            size: self.size
            pos: self.pos
    buffer_view: rv
    orientation: 'vertical'
    GridLayout:
        cols: 3
        rows: 2
        size_hint_y: None
        height: dp(108)
        padding: dp(8)
        spacing: dp(16)
        Button:
            text: 'Populate list'
            on_press: root.populate()
        Button:
            text: 'Clear list'
            on_press: root.clear()

    Label:
        canvas.before:
            Color:
                rgba: 0.6, 0.6, 0.6, 1
            Rectangle:
                size: self.size
                pos: self.pos
        size_hint_y: None
        height: dp(30)
        text: "Count: " + str(len(rv.data))

    RowFields: 
        canvas.before:
            Color:
                rgba: 0.7, 0.7, 0.7, 1
            Rectangle:
                size: self.size
                pos: self.pos
        trace: 'Trace'
        reward: 'Reward'
        prob_self: 'Probability (Self)'
        prob_op: 'Probability (Opponent)'
        actions: 'Actions'

    RecycleView:
        id: rv
        scroll_type: ['bars', 'content']
        scroll_wheel_distance: dp(114)
        bar_width: dp(10)
        viewclass: 'Row'
        RecycleBoxLayout:
            default_size: None, dp(26)
            default_size_hint: 1, None
            size_hint_y: None
            height: self.minimum_height
            orientation: 'vertical'
            spacing: dp(2)
""")

def run(populate_call):
    root.populate_call = populate_call
    runTouchApp(root)

if __name__ == '__main__': runTouchApp(root)