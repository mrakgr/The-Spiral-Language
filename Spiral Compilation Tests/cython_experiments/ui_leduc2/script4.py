from kivy.app import runTouchApp
from kivy.lang.builder import Builder

root = Builder.load_string('''
BoxLayout:
    orientation: 'vertical'
    Slider:
        id: slider
        size_hint_y: 0.1
        min: 0.1
        max: 10
        value: 0.5
    StencilView:
        canvas:
            PushMatrix
            Translate:
                xy: self.pos
            Scale:
                xyz: slider.value,slider.value,slider.value
            Color:
                rgba: 1,0,0,1
            Triangle:
                points: 50,0,0,50,50,100
            PopMatrix
    Button:
        size_hint_y: None
        height: 150
        text: 'x'
''')

if __name__ == '__main__': runTouchApp(root)