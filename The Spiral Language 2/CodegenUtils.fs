module Spiral.CodegenUtils

open Spiral.PartEval.Main
open System.Text

type CodegenEnv =
    {
    text : StringBuilder
    indent : int
    }

let line x (s : string) = x.text.Append(' ', x.indent).AppendLine s |> ignore
let indent x = {x with indent=x.indent+4}
let add_dec_point (x : string) = if x.IndexOf('.') = -1 then x + ".0" else x

exception CodegenError of PartEval.Prepass.Range option * string
exception CodegenErrorWithPos of Trace * string
let raise_codegen_error x = raise (CodegenError (None,x))
let raise_codegen_error_backend r x = raise (CodegenError (Some r,x))
let raise_codegen_error' trace (r,x) = raise (CodegenErrorWithPos(Option.fold (fun s x -> x :: s) trace r,x))