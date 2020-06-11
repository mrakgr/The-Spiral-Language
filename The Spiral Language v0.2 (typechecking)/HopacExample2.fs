module HopacExample2

open System
open Hopac
open Hopac.Infixes

let hello what = job {
  for i=1 to 3 do
    do! timeOut (TimeSpan.FromSeconds 1.0)
    do printfn "%s" what
}

[
timeOut (TimeSpan.FromSeconds 0.0) >>=. hello "Hello, from first job!"
timeOut (TimeSpan.FromSeconds 0.3) >>=. hello "Hello, from second job!"
timeOut (TimeSpan.FromSeconds 0.6) >>=. hello "Hello, from third job"
] |> Job.conIgnore |> run