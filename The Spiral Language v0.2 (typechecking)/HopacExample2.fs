module HopacTimming

open System
open System.Threading
open Hopac
open Hopac.Infixes

let verbose alt = Alt.withNackJob <| fun nack ->
    printf "Instantiated and "
    Job.start (nack >>- fun () -> printfn "aborted.") 
    >>-. (alt ^-> fun x -> printfn "committed to." ; x)

let rnd = Random()
Alt.choose [
    //Alt.always () ^=> (Alt.never >> Job.start)
    verbose <| (Alt.prepareFun (fun () -> if rnd.Next(2) = 0 then Alt.never () else Alt.always()))
    Alt.always ()
    ]
|> run

Console.ReadKey()