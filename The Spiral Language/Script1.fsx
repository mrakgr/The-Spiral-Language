open System
open System.Collections.Generic

type TaggedDictionary<'a,'b when 'a: equality>(tag: int) =
    inherit Dictionary<'a,'b>()

    member __.Tag = tag

    override __.Equals(b) =
        match b with
        | :? TaggedDictionary<'a,'b> as b -> tag = b.Tag
        | _ -> failwith "Invalid equality for TaggedDictionary."

    override __.GetHashCode() = tag

    interface IComparable with
        member x.CompareTo(y) = 
            match y with
            | :? TaggedDictionary<'a,'b> as y -> compare tag y.Tag
            | _ -> failwith "Invalid comparison for TaggedDictionary."


