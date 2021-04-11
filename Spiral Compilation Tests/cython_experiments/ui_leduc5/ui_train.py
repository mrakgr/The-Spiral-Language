from random import randint

from kivy.app import App
from kivy.base import runTouchApp
from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.textinput import TextInput
import numpy as np
from kivy.properties import StringProperty, BooleanProperty, NumericProperty

class RowFields(BoxLayout):
    trace = StringProperty('')
    avg_policy = StringProperty('')
    regret = StringProperty('')

class Main(BoxLayout):
    def train(self,chart,progress_bar,num_iter): 
        # self.buffer_view.data = self.train_call()
        self.buffer_view.data = [
            {'trace': 'KCR', 'avg_policy': 'F: 0.25000\nC: 0.25000\nR: 0.50000', 'regret': 'F: -3.12345\nC: 2.25000\nR: 4.50000'}
            ]
        m = chart.meshline
        chart.add_plot(m)
        p = m.points
        p.extend([(len(p),np.random.rand())])
        chart.ymax = max(p,key=lambda x: x[1])[1]
        chart.xmax = max(1,len(p))
        progress_bar.max = chart.xmax
        progress_bar.value_normalized = np.random.rand()

    def play(self):
        print('playing')

class U64Input(TextInput):
    is_valid = BooleanProperty(True)
    value = NumericProperty(1)
    def on_text(self,ins,text):
        try: 
            self.value = int(text)
            self.is_valid = 0 <= self.value <= 18446744073709551615
        except ValueError: 
            self.is_valid = False

root = Builder.load_string("""
#:import graph kivy_garden.graph
#:import MeshLinePlot kivy_garden.graph.MeshLinePlot

<U64Input>:
    text: '1'
    multiline: False
    valign: 'center'
    foreground_color: [0,0,0,1] if self.is_valid else [1,0,0,1]

<FieldLabel@Label>:
    font_name: 'RobotoMono-Regular'
    text_size: self.size
    halign: 'left'
    valign: 'center'

<RowFields>:
    FieldLabel:
        size_hint_x: 0.3
        text: root.trace
        markup: True
    FieldLabel:
        size_hint_x: 0.4
        text: root.avg_policy
    FieldLabel:
        size_hint_x: 0.4
        text: root.regret

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
            rgba: 0.0, 0.0, 0.0, 1
        Rectangle:
            size: self.size
            pos: self.pos
    buffer_view: rv
    orientation: 'vertical'
    BoxLayout:
        size_hint_y: None
        height: dp(45)
        padding: dp(8)
        spacing: dp(16)
        Label:
            text: 'Num iterations:'
            size_hint_x: None
            size: self.texture_size
        U64Input:
            id: num_iter
        Button:
            text: 'Train'
            disabled: not(num_iter.is_valid)
            on_press: root.train(chart,progress_bar,num_iter.value)
        Button:
            text: 'Play'
            on_press: root.play()
    Accordion:
        orientation: 'vertical'
        min_space: dp(30)
        AccordionItem:
            min_space: self.parent.min_space
            title: 'Dictionary'
            BoxLayout:
                orientation: 'vertical'
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
                    size_hint_y: None
                    height: dp(40)
                    trace: 'Trace'
                    avg_policy: 'Average Policy'
                    regret: 'Regret'
                RecycleView:
                    id: rv
                    scroll_type: ['bars', 'content']
                    scroll_wheel_distance: dp(114)
                    bar_width: dp(10)
                    viewclass: 'Row'
                    RecycleBoxLayout:
                        default_size_hint: 1, None
                        default_size: None, dp(80)
                        size_hint_y: None
                        height: self.minimum_height
                        orientation: 'vertical'
                        spacing: dp(2)
        AccordionItem:
            min_space: self.parent.min_space
            title: "Chart"
            Graph:
                id: chart
                meshline: MeshLinePlot(color=[1,0,0,1])
                xlabel:'X'
                ylabel:'Y'
                x_ticks_minor:5
                x_ticks_major:5
                y_ticks_major:0.2
                y_grid_label:True
                x_grid_label:True
                padding:5
                x_grid:True
                y_grid:True
                xmin:0
                xmax:5
                ymin:0
                ymax:1
    ProgressBar:
        id: progress_bar
        max: 10
        value: 5
        size_hint_y: None
        height: dp(20)
""")

if __name__ == '__main__': runTouchApp(root)