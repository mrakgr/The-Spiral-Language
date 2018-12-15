let rng = System.Random()

let bernoulli p = if rng.NextDouble() >= p then 0.0 else 1.0
let flip p = if rng.NextDouble() >= p then false else true
let rec geometric p = if flip p then 1.0 + geometric p else 1.0

let binomial _ = 
    let a = bernoulli 0.5
    let b = bernoulli 0.5
    let c = bernoulli 0.5
    // TODO: Add factor and sample.
    a+b+c

binomial()

