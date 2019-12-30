open System
open System.Runtime.CompilerServices

type ClassData() = 
    member val CreationTime = DateTime.Now with get, set

[<AllowNullLiteral>]
type ManagedClass() = class end

let cwt = new ConditionalWeakTable<_,_>();
let f () =
    let mc1 = new ManagedClass()
    let mc2 = new ManagedClass()
    let mc3 = new ManagedClass()

    cwt.Add(mc1, ref (1, mc1))          
    cwt.Add(mc2, ref (2, mc2))
    cwt.Add(mc3, ref (3, mc3))
    
    new WeakReference(mc2)

let wr2 = f()

GC.Collect()
      
if wr2.Target = null then
    Console.WriteLine("No strong reference to mc2 exists.")
else 
    match cwt.TryGetValue(wr2.Target :?> _) with
    | true, data -> Console.WriteLine("Data created.")
    | false, _ -> Console.WriteLine("mc2 not found in the table.")