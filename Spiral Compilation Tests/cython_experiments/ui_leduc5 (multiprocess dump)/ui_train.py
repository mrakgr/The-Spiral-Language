from random import randint

from kivy.app import App
from kivy.base import runTouchApp
from kivy.clock import Clock
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
    buffer_view: rv
    chart: chart
    progress_bar: progress_bar
    canvas:
        Color:
            rgba: 0.0, 0.0, 0.0, 1
        Rectangle:
            size: self.size
            pos: self.pos
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
            on_press: root.train(num_iter.value)
        Button:
            text: 'Stop'
            on_press: root.stop()
        Button:
            text: 'Play'
            on_press: root.play()
    Accordion:
        orientation: 'vertical'
        min_space: dp(30)
        AccordionItem:
            min_space: self.parent.min_space
            title: 'Dictionary'
            collapse: False
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
                y_ticks_major:1
                y_grid_label:True
                x_grid_label:True
                padding:5
                x_grid:True
                y_grid:True
                xmin:0
                xmax:5
                ymin:-15
                ymax:15
    ProgressBar:
        id: progress_bar
        max: 10
        value: 5
        size_hint_y: None
        height: dp(20)
""")

def msg(x):
    def f():
        chart = root.chart
        root.progress_bar.value = x['from']
        root.progress_bar.max = x['nearTo']
        reward = x['reward']
        root.buffer_view.data = x['buffer']
        m = chart.meshline
        chart.add_plot(m)
        m.points.extend([(len(m.points),reward)])
        chart.xmax = max(1,len(m.points))
    Clock.schedule_once(f)

def run(train,stop):
    root.train = train
    root.stop = stop
    runTouchApp(root)

if __name__ == '__main__': 
    runTouchApp(root)