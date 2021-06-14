let f x = 
    let q = 1UL <<< x
    q + (q - 1UL)

f 63