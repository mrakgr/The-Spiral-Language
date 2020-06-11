module HopacExample

open System
open Hopac
open Hopac.Infixes

type Cell<'a> = {
    takeCh : Ch<'a>
    putCh : Ch<'a>
    }

let get c = Ch.take c.takeCh
let put c (x: 'a) = Ch.give c.putCh x

let cell x = Job.delay <| fun () ->
    let c = {takeCh = Ch (); putCh = Ch ()}
    let server x = 
        Alt.choose [
            Ch.take c.putCh
            Ch.give c.takeCh x ^->. x]
    
    Job.iterateServer x server >>-. c

run <| job {
    let! c = cell 1
    let print () = Job.start (get c >>- fun i -> printf "%i\n" i)
    let put i = Job.start (put c i)
    do! print()
    do! put 2
    do! print()
    do! put 3
    do! print()
    do! put 4
    do! print()
    do! put 5
    do! print()
    do! put 6
    do! print()
    }

Console.ReadKey()