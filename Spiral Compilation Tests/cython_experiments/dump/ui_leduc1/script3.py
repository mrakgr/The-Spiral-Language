from random import random
from kivy.app import runTouchApp
from kivy.lang.builder import Builder

from kivy.uix.widget import Widget
from kivy.uix.button import Button
from kivy.animation import Animation
from kivy.clock import Clock
from kivy.properties import ListProperty

class AnimRect(Widget):
    def anim_to_random_pos(self):
        Animation.cancel_all(self)
        x = random() * (self.parent.width - self.width)
        y = random() * (self.parent.height - self.height)
        anim = Animation(x=x, y=y, duration=4,t='out_elastic')
        anim.start(self)

    def on_touch_down(self, touch):
        if self.collide_point(*touch.pos): self.anim_to_random_pos()

root = Builder.load_string('''
FloatLayout:
    Slider:
        size_hint_y: None
        top: self.parent.height
        height: 50
        id: slider
        min: 0
        max: 360
        value: 0
    AnimRect:
        size_hint: None,None
        canvas.before:
            Color:
                rgba: 1,0,0,1
            PushMatrix
            Rotate:
                angle: slider.value
                origin: self.center
            Line:
                width: 20.
                ellipse: (self.x, self.y, self.width, self.height)
        canvas.after:
            PopMatrix
        size: 50,25
''')

if __name__ == '__main__': runTouchApp(root)