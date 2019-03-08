#I @"..\..\packages"
#r @"XPlot.Plotly.1.5.0\lib\net45\XPlot.Plotly.dll"
#r @"XPlot.GoogleCharts.1.5.0\lib\net45\XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

let rock = 
    [0.1;0.2;0.2;0.1;0.3]
    |> List.mapi (fun i x -> i,x)

let paper = 
    [0.2;0.3;0.3;0.2;0.1]
    |> List.mapi (fun i x -> i,x)

let scissors =
    List.map2 (fun (_,a) (i,b) -> i,1.0-a-b) rock paper

let inputs = [rock;paper;scissors]

let chart =
    inputs
    |> Chart.Column
    |> Chart.WithOptions(Options(isStacked=true))
    |> Chart.WithLabels ["Rock"; "Paper"; "Scissors"]
    |> Chart.Show
