// Here is the second experiment. I try to get a grip on propagating probabilities here.
// This inference method is called likelihood weighting.

let rng = System.Random()
let bernoulli p _ = if rng.NextDouble() >= p then (1.0 - p), 0 else p, 1

let sample dist score next =
    let prob, value = dist ()
    next (score + log prob) value

let factor value score next = next (score + value) ()
let condition cond score next = if cond then next score () else next -infinity ()

// CPS monad that returns the probabilities at the end of the path.
type ProbBuilder() =
    member __.Bind(a,b) = fun score next -> 
        a score (fun score a' ->
            b a' score next
            )
    member __.Return x = fun score next -> next score x

let prob = new ProbBuilder()

let example = prob {
    let! a = sample (bernoulli 0.5)
    let! b = sample (bernoulli 0.5)
    let! c = sample (bernoulli 0.5)
    let! _ = factor (if a = 1 || b = 1 then 0.0 else -1.0)
    return (a + b + c)
    }

let forward iters program =
    let dict = System.Collections.Generic.Dictionary(HashIdentity.Structural)
    for i = 1 to iters do
        program 0.0 <| fun (score: float) v ->
            match dict.TryGetValue(v) with
            | true, score' -> dict.[v] <- score' + exp score
            | _ -> dict.[v] <- exp score
    
    let ar = Seq.toArray dict
    let sum = ar |> Array.fold (fun s x -> s + x.Value) 0.0
    ar |> Array.map (fun x -> x.Key, x.Value / sum) |> Array.sort

forward 100000 example
