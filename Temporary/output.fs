module SpiralExample.Main

open System.Collections.Generic

let q = Dictionary()
q.Add(1,2)

let t = ref 0

match q.TryGetValue(0,t) with
| true -> !t
| false -> -1