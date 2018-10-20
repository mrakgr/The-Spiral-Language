/// A small TD(0) example.

type SR = {state : int32; reward : float}
open System.Collections.Generic

let final = -1
let learning_rate = 0.2
let ar = 
    [|
    [|{state=1;reward=1.0}; {state=3;reward=0.0}; {state=4; reward=1.0}; {state=final; reward=0.0}|]
    [|{state=1;reward=1.0}; {state=3;reward=0.0}; {state=5; reward=10.0}; {state=final; reward=0.0}|]
    [|{state=1;reward=1.0}; {state=3;reward=0.0}; {state=4; reward=1.0}; {state=final; reward=0.0}|]
    [|{state=1;reward=1.0}; {state=3;reward=0.0}; {state=4; reward=1.0}; {state=final; reward=0.0}|]
    [|{state=2;reward=2.0}; {state=3;reward=0.0}; {state=5; reward=10.0}; {state=final; reward=0.0}|]
    |]

let value_of (values: Dictionary<_,_>) s =
    match values.TryGetValue s with
    | true, v -> v
    | false, _ -> 0.0

let add_value (values: Dictionary<_,_>) (s,v') =
    match values.TryGetValue s with
    | true, v -> values.[s] <- v + learning_rate * v'
    | false, _ -> values.[s] <- learning_rate * v'

let update_column (values: Dictionary<_,_>) col =
    let num_rows = ar.Length
    let updates =
        [|
        for row=0 to num_rows-1 do
            let {state=s; reward=r} = ar.[row].[col]
            let {state=s'} = ar.[row].[col+1]
            yield s, r + value_of values s' - value_of values s
        |]
    //printfn "%A" updates

    /// Performing the update inside the loop would make this algorithm serial.
    /// Doing it here makes it parallel.
    Array.iter (add_value values) updates
    
let values = Dictionary()

for i=0 to 50 do
    update_column values 2
    update_column values 1
    update_column values 0
    printfn "%A" (values |> Seq.toArray)

