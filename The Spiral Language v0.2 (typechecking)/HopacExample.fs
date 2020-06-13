module HopacPromiseNonblocking

open System
open Hopac
open Hopac.Infixes

Alt.choose [
    //Alt.always 1 ^=>. Alt.never () // blocks forever
    memo (Alt.always 1 ^=>. Alt.never ()) :> _ Alt // does not block
    Alt.always 1 >>=*. Alt.never () :> _ Alt // same as above, does not block
    Alt.always 2
    ]
|> run
|> printfn "%i" // prints 2

Console.ReadKey()