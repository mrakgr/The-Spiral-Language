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
        | _ -> failwith "Invalid equality for HashConsed."

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? ConsedNode<'a> as y -> compare x.tag y.tag
            | _ -> failwith "Invalid comparison for HashConsed."

type HashConsTable<'a> =
    {
    mutable table: ResizeArray<GCHandle> []
    mutable total_size: int
    mutable limit: int
    mutable is_finalized: bool
    mutable counter: int
    }

    override x.Finalize() =
        if x.is_finalized = false then
            x.table |> (Array.iter << Seq.iter) (fun x -> x.Free())
            x.is_finalized <- true

let hashcons_create i = {table = Array.init (max 7 i) (fun _ -> ResizeArray(0)); total_size=0; limit=3; is_finalized=false; counter=0}
let hashcons_add (t: HashConsTable<'a>) (x: 'a) =
    let hashcons_resize (t: HashConsTable<'a>) =
        let next_table_length x = x*3/2+3

        let table_length' = next_table_length t.table.Length
        if table_length' <= t.table.Length then failwith "The hash consing table cannot be grown anymore."
        let table' = Array.init table_length' (fun i -> ResizeArray())
        let limit' = t.limit+2
        let total_size' = 
            (0,t.table) ||> (Array.fold << Seq.fold) (fun total_size x ->
                match x.Target with
                | null -> 
                    x.Free()
                    total_size
                | :? ConsedNode<'a> as node -> 
                    let bucket = table'.[node.hkey % table_length']
                    bucket.Add x
                    total_size+1
                | _ -> failwith "impossible"
                )
        t.table <- table'
        t.limit <- limit'
        t.total_size <- total_size'

    let hkey = hash x &&& Int32.MaxValue
    let table = t.table
    let bucket = table.[hkey % Array.length table]
    let sz = bucket.Count

    let rec loop empty_pos i =
        if i < sz then
            match bucket.[i].Target with
            | null -> loop i (i+1)
            | :? ConsedNode<'a> as y when hkey = y.hkey && x = y.node -> y
            | _ -> loop empty_pos (i+1)
        else
            let node = {node=x; hkey=hkey; tag=t.counter}
            t.counter <- t.counter+1
            if empty_pos <> -1 then
                let mutable m = bucket.[empty_pos]
                m.Target <- node
            else
                bucket.Add (GCHandle.Alloc(node,GCHandleType.Weak))
                t.total_size <- t.total_size+1
                if t.total_size > t.limit * Array.length t.table then hashcons_resize t
            node

    loop -1 0 // `-1` indicates the state of no empty bucket

