open System

// Gets the standard deviation of a Gaussian distribution at a given top percentile.
let get_std_of_percentile percentile =

    // Parameters for the normal distribution
    let mean = 0.0
    let standardDeviation = 1.0

    // Number of samples
    let sampleSize = 1 <<< 22

    // Initialize the random number generator
    let random = Random()

    // Generate the sample
    let normalSample =
        Array.init sampleSize (fun _ ->
            let z = random.NextDouble() // Generate a random number between 0 and 1
            mean + standardDeviation * Math.Sqrt(-2.0 * Math.Log(z)) * Math.Cos(2.0 * Math.PI * random.NextDouble())
        )

    (Array.sort normalSample)[int((1.0 - percentile) * float normalSample.Length)]

get_std_of_percentile (1.0 / 8.0)