module ParserFSharp

let example () = 
    /// Converts a string to a parser stream.
    /// string -> parser_stream
    /// Note: The functionality of this functions needs to be pared down in F# due to lack of intensional polymorphism.
    let string_stream (str: string) (idx, on_succ, on_fail) =
        if idx >= 0 && idx < str.Length then on_succ str.[idx] else on_fail "string index out of bounds" 

    /// Runs a parser given the string and the expected return type.
    /// string -> t parser -> t
    let run str parser = 
        let stream = string_stream str

        let d = 
            stream
            ,fun x state -> id x
            ,fun x state -> failwith x

        parser d 0

    /// Reads a char.
    /// char parser
    let stream_char (stream, on_succ, on_fail) pos =
        stream 
            (pos
            ,fun c -> on_succ c (pos+1)
            ,fun msg -> on_fail msg pos
            )

    let is_digit x = x >= '0' && x <= '9'
    let is_whitespace x = x = ' '
    let is_newline x = x = '\n' || x = '\r'

    /// Reads a digit.
    /// char parser
    let digit (stream, on_succ, on_fail) state =
        stream_char ( 
            stream 
            ,fun x state' -> 
                if is_digit x then on_succ x state'
                else on_fail "digit" state
            ,on_fail
            ) state
            

    /// Reads an 64-bit integer parser.
    /// uint64 parser
    let puint64 (stream, on_succ, on_fail) state =
        let error state = on_fail "puint64" state
        let rec loop i on_fail state =
            digit (
                stream
                ,fun c state ->
                    let max = 1844674407370955161UL // max of uint64 / 10u64
                    if i <= max then
                        let i' = i * 10UL + System.Convert.ToUInt64 c - System.Convert.ToUInt64 '0'
                        if i < i' then loop i' on_succ state
                        else error state
                    else error state
                ,fun _ state -> on_fail i state
                ) state
        loop 0UL (fun _ state -> error state) state

    /// The skips an all the whitespaces (including newlines) before succeeding.
    /// unit parser
    let rec spaces (stream, on_succ, on_fail as d) state =
        stream_char (
            stream
            ,fun c state' -> 
                if is_whitespace c || is_newline c then spaces d state'
                else on_succ () state
            ,fun _ state -> on_succ () state
            ) state

    /// Runs the first and then the second parser before returning the result of the second parser.
    /// a parser -> b parser -> b parser
    let (>>.) a b (stream,on_succ,on_fail as d) state = a (stream,(fun _ state -> b d state), on_fail) state
    /// Runs the first and then the second parser before returning the result of the first parser.
    /// a parser -> b parser -> a parser
    let (.>>) a b (stream,on_succ,on_fail) state = 
        a (stream, (fun a state -> b (stream, (fun _ state -> on_succ a state),on_fail) state), on_fail) state

    /// Runs the tuple of parsers before returning their result.
    /// tuple parser
    /// Note: This one is ugly. It is impossible to make a generic tuple without great type hackery in F#. 
    /// Check out FParsec.Pipes library to see how that might be done.
    let tuple3 (a,b,c) (stream,on_succ,on_fail) =
        a (
            stream 
            ,fun a ->
                b (
                    stream
                    ,fun b ->
                        c (
                            stream
                            ,fun c ->
                                on_succ (a,b,c)
                            ,on_fail)
                    ,on_fail)
            ,on_fail)

    /// Parses an unsigned 64-bit integer and returns it after parsing whitespaces.
    /// uint64 parser
    let num = puint64 .>> spaces

    run "123 456 789" (tuple3 (num, num, num))