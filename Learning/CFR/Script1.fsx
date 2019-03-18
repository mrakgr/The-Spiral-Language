open System

let code = System.IO.File.ReadAllText(@"C:\Users\Marko\Source\Repos\The Spiral Language\Learning\CFR\TextFile1.txt")
let x = code.Split([|Environment.NewLine|],StringSplitOptions.None)
x
|> Array.map (fun x -> x.[3..])
|> String.concat "\n"
|> fun x -> System.IO.File.WriteAllText(@"C:\Users\Marko\Source\Repos\The Spiral Language\Learning\CFR\TextFile2.txt", x)