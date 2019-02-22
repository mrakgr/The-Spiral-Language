open System.Runtime.CompilerServices
let t = ConditionalWeakTable()

let f y = t.Add(string 'a',y)
f "5"
f "10"

