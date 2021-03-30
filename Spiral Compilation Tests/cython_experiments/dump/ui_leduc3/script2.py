from random import random
from kivy.app import runTouchApp
from kivy.lang.builder import Builder
from kivy.uix.widget import Widget
from kivy.uix.slider import Slider
from kivy.graphics import Color, Ellipse, Line, ClearBuffers
from kivy.properties import BoundedNumericProperty,NumericProperty

class MyPaintWidget(Widget):
    diameter = NumericProperty(30)
    def add_elipse(self,touch):
        color = (random(), random(), 1.0)
        with self.canvas:
            Color(*color,mode='hsv')
            d = self.diameter
            y = touch.y - d / 2
            Ellipse(pos=(touch.x - d / 2, y - d / 4), size=(d, d/1.5))
            Ellipse(pos=(touch.x - d / 2, y), size=(d, d/2))
            Ellipse(pos=(touch.x - d / 2, y + d / 4), size=(d, d/1.5))
            
    def on_touch_down(self, touch):
        self.add_elipse(touch)
        with self.canvas: self.line = Line(points=(touch.x, touch.y))

    def on_touch_move(self, touch): self.line.points += [touch.x, touch.y]
    def on_touch_up(self, touch): self.add_elipse(touch)
    def clear(self): self.canvas.add(ClearBuffers())

root = Builder.load_string('''
BoxLayout:
    orientation: 'vertical'
    MyPaintWidget:
        id: paint
        diameter: slider.value
    BoxLayout:
        orientation: 'horizontal'
        size_hint_y: 0.07
        Button:
            size_hint_x: 0.15
            text: 'Clear Canvas'
            on_press: paint.clear()
        Slider:
            id: slider
            min: 1
            max: 100
            value: 30
''')

if __name__ == '__main__': runTouchApp(root)