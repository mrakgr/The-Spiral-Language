from math import sin
from kivy.app import runTouchApp
from kivy.lang import Builder
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.button import Button
from kivy_garden.graph import Graph, MeshLinePlot

class ChartButton(Button):
    def add_points(self,chart):
        def sin_points(l): return [(l+x, sin(x / 10.)) for x in range(0, 100)]
        self.meshline.points.extend(sin_points(len(self.meshline.points)))
        chart.xmax = len(self.meshline.points)-1
        chart.add_plot(self.meshline)

root = Builder.load_string('''
#:import graph kivy_garden.graph
#:import MeshLinePlot kivy_garden.graph.MeshLinePlot
BoxLayout:
    orientation: 'vertical'
    ChartButton:
        text: 'Add'
        size_hint_y: None
        height: dp(50)
        meshline: MeshLinePlot(color=[1,0,0,1])
        on_press: self.add_points(chart)
    Graph:
        id: chart
        xlabel:'X'
        ylabel:'Y'
        x_ticks_minor:5
        x_ticks_major:1
        y_ticks_major:1
        y_grid_label:True
        x_grid_label:True
        padding:5
        x_grid:True
        y_grid:True
        xmin:0
        xmax:10
        ymin:-1
        ymax:1
''')

# for plot in root.ps: root.add_plot(plot)
runTouchApp(root)