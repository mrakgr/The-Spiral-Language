module Spiral.Prototyping

open System
open Hopac
open Hopac.Infixes

let hello what = job {
  for i=1 to 3 do
    do! timeOut (TimeSpan.FromSeconds 1.0)
    do printfn "%s" what
}

run <| job {
    do! Job.start (hello "Hello, from a job!")
    do! timeOut (TimeSpan.FromSeconds 0.5)
    do! Job.start (hello "Hello, from another job!")
    }

Console.ReadKey()