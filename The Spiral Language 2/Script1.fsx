open System.Text



let x = "Arg"
System.Object.ReferenceEquals(x, unintern x)
|> printfn "%b"