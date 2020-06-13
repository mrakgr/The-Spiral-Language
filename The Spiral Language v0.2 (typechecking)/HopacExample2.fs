module HopacTimming

open System
open System.Threading
open Hopac
open Hopac.Infixes

let hello what = job {
  for i=1 to 3 do
    do! timeOut (TimeSpan.FromSeconds 1.0)
    do printfn "%s" what
}

run <| job {
  let! j1 = Promise.start (hello "Hello, from a job!")
  do! timeOut (TimeSpan.FromSeconds 0.5)
  let! j2 = Promise.start (hello "Hello, from another job!")
  //do! Promise.read j1
  //do! Promise.read j2
  return ()
}

Console.ReadKey()