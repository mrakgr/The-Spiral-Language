module HopacExample2

open System
open Hopac
open Hopac.Infixes

let get c = Ch.take c
let put c (x: 'a) = Ch.give c x

run <| job {
    let c = Ch ()
    let print () = Job.start (get c >>- fun i -> printf "%i\n" i)
    let put i = Job.start (put c i)
    for i=1 to 6 do
        do! print()
        do! put i
    }

Console.ReadKey()