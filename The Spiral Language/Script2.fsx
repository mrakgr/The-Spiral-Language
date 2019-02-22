open System.Runtime.CompilerServices
let t = ConditionalWeakTable()

let x = string 'a'
let y = string 'a'

t.Add(x,"5")
t.Add(y,"y")

let s = Set.union (Set.singleton x) (Set.singleton y)
let [s'] = Set.toList s

t.GetOrCreateValue(s')