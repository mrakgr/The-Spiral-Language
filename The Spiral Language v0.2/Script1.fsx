let x =
    [
    "pat_when" 
    "pat_as"
    "pat_or"
    "pat_keyword"
    "pat_pair"
    "pat_and"
    "pat_type"
    "choice [|pat_wildcard; pat_var; pat_active recurse; pat_union recurse; pat_value; pat_record recurse; pat_keyword_unary; pat_rounds recurse|]"
    ]

List.rev x |> String.concat " |> " |> printfn "%s"