let for' from nearTo body state =
    let rec loop i s = if i > nearTo then loop (i-1) (body i s) else s
    loop from state

// Folds over the range in an downwards direction.
let forUp nearFrom to' body state = for' to' nearFrom (fun i -> body ((to'-i)+nearFrom+1)) state

forUp 2 5 (fun i () -> printfn "%i" i) ()