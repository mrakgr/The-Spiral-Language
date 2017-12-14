let l = lazy (failwith "")

let q =
    (lazy fst l.Value), lazy (snd l.Value)