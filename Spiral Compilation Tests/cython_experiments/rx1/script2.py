from kivy.app import App
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.boxlayout import BoxLayout

class TestApp(App):
    def build(self):
        lay = BoxLayout(orientation='horizontal')
        btn = Button(text='Press me.')
        btn.size_hint_y = 0.1
        label = Label(text="Press the button.")
        lay.add_widget(btn,index=1)
        lay.add_widget(label,index=0)
        def f(args): 
            args.text = "X"
            label.text = "The button has been pressed."
        btn.fbind("on_press",f)
        return lay

TestApp().run()