open System

let rand = new Random(); //reuse this if you are generating many
let x = byte 1

let randNormal mean stdDev = 
    let u1 = 1.0-rand.NextDouble(); //uniform(0,1] random doubles
    let u2 = 1.0-rand.NextDouble();
    let randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
    mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

let size = 128000
let ar = Array.init size (fun x -> randNormal 0.0 1.0 / sqrt (float size))

let mean ar = Array.sum ar / float ar.Length
let std x = 
    let m = mean x
    let v = Array.map (fun x -> x - m) x
    Array.sum (Array.map (fun x -> x*x) v) |> sqrt
    //Array.map (fun v -> v / norm) v

std ar