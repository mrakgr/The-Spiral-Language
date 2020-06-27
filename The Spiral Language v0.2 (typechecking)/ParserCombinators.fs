module Spiral.ParserCombinators

let inline index d = (^a : (member Index: int) d)
let inline index_set i d = (^a : (member set_Index: int -> unit) (d,i))

let inline (.>>.) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok (a,b)
        | Error x -> Error x
    | Error x -> Error x   

let inline tuple3 a b c d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (a, b, c)
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline tuple4 a b c d' d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (a, b, c, d')
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline tuple5 a b c d' e d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> 
                    match e d with
                    | Ok e -> Ok (a, b, c, d', e)
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe2 a b f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok (f a b)
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe3 a b c f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> Ok (f a b c)
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe4 a b c d' f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> Ok (f a b c d')
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline pipe5 a b c d' e f d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> 
            match c d with
            | Ok c -> 
                match d' d with
                | Ok d' -> 
                    match e d with
                    | Ok e -> Ok (f a b c d' e)
                    | Error x -> Error x
                | Error x -> Error x
            | Error x -> Error x
        | Error x -> Error x
    | Error x -> Error x  

let inline (.>>) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok a
        | Error x -> Error x
    | Error x -> Error x   

let inline (>>.) a b d =
    match a d with
    | Ok a ->
        match b d with
        | Ok b -> Ok b
        | Error x -> Error x
    | Error x -> Error x   

let inline opt a d =
    let s = index d
    match a d with
    | Ok a -> Ok(Some a)
    | Error x -> 
        if s = index d then Ok(None)
        else Error x

let inline optional a d = 
    let s = index d
    match a d with
    | Ok a -> Ok()
    | Error x -> 
        if s = index d then Ok()
        else Error x

let inline (|>>) a b d =
    match a d with
    | Ok a -> Ok(b a)
    | Error x -> Error x

let inline (>>%) a b d =
    match a d with
    | Ok a -> Ok(b)
    | Error x -> Error x
        
let inline (>>=) a b d =
    match a d with
    | Ok a -> b a d
    | Error x -> Error x

let inline (>>=?) a b d =
    let i = index d
    match a d with
    | Ok a -> 
        let i' = index d
        match b a d with
        | Ok x -> Ok x
        | x when i' = index d -> index_set i d; x
        | x -> x
    | Error x -> Error x

let inline many a d =
    let s = index d
    let rec loop () =
        match a d with
        | Ok x ->
            if s = index d then failwith "The parser succeeded without changing the parser index in 'many'. Had an exception not been raised the parser would have diverged."
            else 
                match loop() with
                | Ok x' -> Ok (x :: x')
                | Error x -> Error x
        | Error x -> Ok []
    loop ()

let inline sepBy1 a b d =
    match a d with
    | Ok a' -> (many (b >>. a) |>> fun b -> a' :: b) d
    | Error x -> Error x

let inline many1 a d =
    match a d with
    | Ok a' -> (many a |>> fun b -> a' :: b) d
    | Error x -> Error x

let inline attempt a d =
    let s = index d
    match a d with
    | Ok x -> Ok x
    | Error a as a' -> index_set s d; a'

let inline (<|>) a b d =
    let s = index d
    match a d with
    | Ok x -> Ok x
    | Error a as a' -> 
        if s = index d then
            match b d with
            | Ok x -> Ok x
            | Error b -> Error(List.append a b)
        else
            a'

let inline (<|>%) a b d =
    let s = index d
    match a d with
    | Ok x -> Ok x
    | Error _ as a' -> if s = index d then Ok b else a'

let inline choice ar d =
    let s = index d
    let rec loop i =
        if i < Array.length ar then
            match ar.[i] d with
            | Ok x -> Ok x
            | Error a as a' -> 
                if s = index d then
                    match loop (i+1) with
                    | Ok x -> Ok x
                    | Error b -> Error(List.append a b)
                else
                    a'
        else
            Error []
    loop 0
