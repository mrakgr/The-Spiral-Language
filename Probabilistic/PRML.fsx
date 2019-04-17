// The third exercise from the Pattern Matching and Machine Learning book.

type Box =
    | Red
    | Green
    | Blue

type Fruit =
    | Orange
    | Lime
    | Apple

let normalize_ints x = 
    let total = Array.fold (fun s (_,num_items) -> s + num_items) 0 x
    Array.map (fun (dsc,num_items) -> dsc, float num_items / float total) x

let boxes =
    [|
    Red, normalize_ints [|Apple, 3; Lime, 3; Orange, 4|]
    Blue, normalize_ints [|Apple, 1; Lime, 0; Orange, 1|]
    Green, normalize_ints [|Apple, 3; Lime, 4; Orange, 3|]
    |]

