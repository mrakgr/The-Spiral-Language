let normal mu sigma x = 
    let sqr x = x*x
    exp -(sqr (x - mu) / (2.0 * sqr sigma)) / (sqrt (2.0 * System.Math.PI * sqr sigma))

normal 0.0 1.0 0.0
