module Spiral.Codegen.Fsharp
open Spiral.PartEval
open System
open System.Text
open System.Collections.Generic

type H<'a when 'a: equality>(x : 'a) = 
    let h = hash x

    member _.Item = x
    override a.Equals(b) =
        match b with
        | :? H<'a> as b -> h = hash b && x = b.Item
        | _ -> false
    override a.GetHashCode() = h

type Tagger<'a when 'a : equality>() = 
    let dict = Dictionary<H<'a>, int>(HashIdentity.Structural)
    let queue = Queue<'a * int>()

    member t.Tag ty = Spiral.Utils.memoize dict (fun _ -> let x = dict.Count in queue.Enqueue(ty,x); x) (H ty)
    member t.QueuedCount = queue.Count
    member t.Dequeue = queue.Dequeue()

type CodegenEnv =
    {
    stmts : StringBuilder
    indent : int
    join_points : Tagger<JoinPointKey>
    types : Tagger<Ty>
    }

    member x.NewDefinition = {x with stmts = StringBuilder()}
    member x.Statement s =
        x.stmts
            .Append(' ', x.indent)
            .AppendLine s
        |> ignore

    member x.Text s = x.Statement s
    member x.Indent = {x with indent=x.indent+4}

let codegen join_point_method join_point_close (x : TypedBind []) =
    failwith ""