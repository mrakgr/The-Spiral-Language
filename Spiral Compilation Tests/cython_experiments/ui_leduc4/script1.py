from random import sample, randint
from string import ascii_lowercase

from kivy.app import App
from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
# from kivy.garden import 


kv = """
<Row@RecycleKVIDsDataViewBehavior+BoxLayout>:
    canvas.before:
        Color:
            rgba: 0.5, 0.5, 0.5, 1
        Rectangle:
            size: self.size
            pos: self.pos
    value: ''
    Label:
        canvas.before:
            Color:
                rgba: 1,0,0,0.3
            Rectangle:
                size: self.size
                pos: self.pos
        id: index
        font_name: 'RobotoMono-Regular'
        size_hint_x: None
        width: dp(30)
        text_size: self.size
        halign: 'right'
    Label:
        id: name
        font_name: 'RobotoMono-Regular'
    Label:
        text: root.value
        font_name: 'RobotoMono-Regular'

<Test>:
    canvas:
        Color:
            rgba: 0.3, 0.3, 0.3, 1
        Rectangle:
            size: self.size
            pos: self.pos
    rv: rv
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
            text: 'Sort list'
            on_press: root.sort()
        Button:
            text: 'Clear list'
            on_press: root.clear()
        BoxLayout:
            spacing: dp(8)
            Button:
                text: 'Insert new item'
                on_press: root.insert(new_item_input.text)
            TextInput:
                id: new_item_input
                size_hint_x: 0.6
                hint_text: 'value'
                padding: dp(10), dp(10), 0, 0
        BoxLayout:
            spacing: dp(8)
            Button:
                text: 'Update first item'
                on_press: root.update(update_item_input.text)
            TextInput:
                id: update_item_input
                size_hint_x: 0.6
                hint_text: 'new value'
                padding: dp(10), dp(10), 0, 0
        Button:
            text: 'Remove first item'
            on_press: root.remove()

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
"""

Builder.load_string(kv)


class Test(BoxLayout):

    def populate(self):
        self.rv.data = [
            {
            'index.text': str(x),
            'name.text': ''.join(sample(ascii_lowercase, 6)),
            'value': str(randint(0, 2000))
            }
            for x in range(50)]

    def sort(self):
        self.rv.data = sorted(self.rv.data, key=lambda x: x['name.text'])

    def clear(self):
        self.rv.data = []

    def insert(self, value):
        self.rv.data.insert(0, {
            'index': str(len(self.rv.data)),
            'name.text': value or 'default value', 
            'value': 'unknown'}
            )

    def update(self, value):
        if self.rv.data:
            self.rv.data[0]['name.text'] = value or 'default new value'
            self.rv.refresh_from_data()

    def remove(self):
        if self.rv.data:
            self.rv.data.pop(0)


class TestApp(App):
    def build(self):
        return Test()


if __name__ == '__main__':
    TestApp().run()