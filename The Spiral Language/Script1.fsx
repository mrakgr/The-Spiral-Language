#r @"C:\Users\Marko\Source\Repos\The Spiral Language\packages\FSharpx.Collections.2.0.0-beta3\lib\net45\FSharpx.Collections.dll"

open FSharpx.Collections

let f () = 
    let a = PersistentHashMap.empty

    PersistentHashMap.add 1 () a
    |> PersistentHashMap.add 2 ()
    |> PersistentHashMap.add 3 ()

f () = f ()