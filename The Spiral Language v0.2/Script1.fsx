open System.Runtime.CompilerServices

[<MethodImpl(MethodImplOptions.NoInlining)>]
let f x = System.Object.ReferenceEquals(x,x)

f id