//let a = 285321827306898791209647125482703629360I
let a = 258I
let ar = a.ToByteArray(true,true)
ar
|> Array.chunkBySize 8
|> Array.map (Array.map (fun x -> System.Convert.ToString(x,2).PadLeft(8,'0')) >> String.concat "")
|> printfn "%A"
