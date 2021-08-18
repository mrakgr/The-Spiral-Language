type T() = class end
let a = T()
let b = T()
System.Object.ReferenceEquals(a,b)