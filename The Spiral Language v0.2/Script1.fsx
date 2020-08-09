let inline (+) (a : 't) (b : 't) : 't = a + b

let inline f (a,b) =
    let inline g (q,w) = (a+q,b+w)
    ()