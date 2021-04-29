let alg1 means vars =
    let len = float (List.length vars)
    let stds = List.map2 (fun mean var -> var - mean * mean |> sqrt) means vars
    let average_std = List.sum stds / len
    let eps = 2.0 ** -7.0
    List.map (fun x -> 
        if average_std = 0.0 then 0.0 else
        average_std / (eps * average_std + (1.0 - eps) * x)
        ) stds

let alg2 vars =
    let len = float (List.length vars)
    let stds = List.map sqrt vars
    let average_std = List.sum stds / len
    let eps = 2.0 ** -7.0
    List.map (fun x -> 
        if average_std = 0.0 then 0.0 else
        average_std / (eps * average_std + (1.0 - eps) * x)
        ) stds

let r = alg1 [1.0;2.0;3.0] [1.0; 12.0; 15.0]