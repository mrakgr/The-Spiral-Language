from math import sin
from kivy.app import runTouchApp
from kivy.lang import Builder
from kivy_garden.graph import Graph, MeshLinePlot
# graph = Graph(xlabel='X', ylabel='Y', x_ticks_minor=5,
#     x_ticks_major=25, y_ticks_major=1,
#     y_grid_label=True, x_grid_label=True, padding=5,
#     x_grid=True, y_grid=True, xmin=-0, xmax=100, ymin=-1, ymax=1)
# plot = MeshLinePlot(color=[1, 0, 0, 1])
# plot.points = [(x, sin(x / 10.)) for x in range(0, 101)]
# graph.add_plot(plot)

root = Builder.load_string('''
#:import graph kivy_garden.graph
#:import MeshLinePlot kivy_garden.graph.MeshLinePlot
#:import math math
Graph:
    xlabel:'X'
    ylabel:'Y'
    x_ticks_minor:5
    x_ticks_major:25
    y_ticks_major:1
    y_grid_label:True
    x_grid_label:True
    padding:5
    x_grid:True
    y_grid:True
    xmin:-0
    xmax:100
    ymin:-1
    ymax:1
    ps: 
        [
        MeshLinePlot(color=[1,0,0,1], points=[(x, math.sin(x / 10.)) for x in range(0, 101)])
        ]
''')

for plot in root.ps: root.add_plot(plot)
runTouchApp(root)