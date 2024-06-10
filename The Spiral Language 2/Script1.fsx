let rec loop (x : int) : int =
    printfn "%i" x
    1 + loop (x+1)

loop 0