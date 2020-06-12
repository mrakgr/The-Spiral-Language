module HopacTimming

open System
open System.Threading
open Hopac
open Hopac.Infixes

let server = Job.delay <| fun () ->
    let c = Ch ()
    let rec loop i =
        (timeOutMillis 1000 ^=> fun () -> printfn "%i..." i; loop (i+1))
        <|> (Ch.take c ^=> fun x -> printfn "Got message: %s" x; loop i)

    Job.server (loop 0) >>-. c

job {
    let! req = server
    while true do
        let! _ = Job.fromTask (fun () -> Tasks.Task.Run(fun () -> Console.ReadKey()))
        do! Ch.give req "Hello"
    }
|> run
    