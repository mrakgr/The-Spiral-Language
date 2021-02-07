// Adapted from: https://github.com/backtracking/ocaml-hashcons
// Type-Safe Modular Hash-Consing: https://www.lri.fr/~filliatr/ftp/publis/hash-consing2.pdf

module Spiral.HashConsing

open System
open System.Runtime.InteropServices

[<CustomComparison;CustomEquality;StructuredFormatDisplay("{AsString}")>]
type ConsedNode<'a> =
    {
    node: 'a
    tag: int
    hkey: int
    }

    override x.ToString() = sprintf "<tag %i>" x.tag
    member x.AsString = x.ToString()
    override x.GetHashCode() = x.hkey
    override x.Equals(y) = 
        match y with 
        | :? ConsedNode<'a> as y -> x.tag = y.tag
        | _ -> false

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? ConsedNode<'a> as y -> compare x.tag y.tag
            | _ -> raise <| ArgumentException "Invalid comparison for HashConsed."

type HashConsTable() =
    let mutable table: ResizeArray<GCHandle> [] = Array.init 7 (fun _ -> ResizeArray(0))
    let mutable total_size: int = 0
    let mutable limit: int = 3
    let mutable is_finalized: bool = false
    let mutable counter: int = 0

    member private t.Resize() =
        let next_table_length x = x*3/2+3

        let table_length' = next_table_length table.Length
        if table_length' <= table.Length then failwith "The hash consing table cannot be grown anymore."
        let table' = Array.init table_length' (fun i -> ResizeArray())
        let limit' = limit+2
        let total_size' = 
            let mutable total_size=0
            for i=0 to table.Length-1 do
                let table = table.[i]
                for i=0 to table.Count-1 do
                    let x = table.[i]
                    total_size <-
                        match x.Target with
                        | null -> 
                            x.Free()
                            total_size
                        | a -> 
                            let bucket = table'.[(hash a &&& Int32.MaxValue) % table_length']
                            bucket.Add x
                            total_size+1
            total_size
        table <- table'
        limit <- limit'
        total_size <- total_size'

    member t.Add(x: 'a): ConsedNode<'a> =
        let hkey = hash x
        let table = table
        let bucket = table.[(hkey &&& Int32.MaxValue) % Array.length table]
        let sz = bucket.Count

        let rec loop empty_pos i =
            if i < sz then
                match bucket.[i].Target with
                | null -> loop i (i+1)
                | :? ConsedNode<'a> as y when hkey = y.hkey && x = y.node -> y
                | _ -> loop empty_pos (i+1)
            else
                let node = {node=x; hkey=hkey; tag=counter}
                counter <- counter+1
                if empty_pos <> -1 then
                    let mutable m = bucket.[empty_pos]
                    m.Target <- node
                else
                    bucket.Add (GCHandle.Alloc(node,GCHandleType.Weak))
                    total_size <- total_size+1
                    if total_size > limit * Array.length table then t.Resize()
                node

        loop -1 0 // `-1` indicates the state of no empty bucket

    override __.Finalize() =
        if is_finalized = false then
            table |> (Array.iter << Seq.iter) (fun x -> x.Free())
            is_finalized <- true
