// Here is the second experiment. I try to get a grip on propagating probabilities here.

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
    let! a = sample (bernoulli 0.01)
    let! b = sample (bernoulli 0.5)
    let! c = sample (bernoulli 0.5)
    let! _ = condition (a+b+c >= 2)
    return a
    }

let forward iters program =
    let dict = System.Collections.Generic.Dictionary(HashIdentity.Structural)
    for i = 1 to iters do
        program 0.0 <| fun (score: float) v ->
            match dict.TryGetValue(v) with
            | true, (score', n) -> dict.[v] <- (score' + exp score, n+1)
            | _ -> dict.[v] <- (exp score, 1)
    
    let ar = 
        dict 
        |> Seq.toArray
        |> Array.map (fun x -> x.Key, fst x.Value / float (snd x.Value))

    let sum = Array.fold (fun s (_,x) -> s + x) 0.0 ar
    Array.map (fun (a,b) -> a, b / sum) ar |> Array.sort

forward 10000 example
