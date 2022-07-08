module Spiral.CodegenUtils

open Spiral.PartEval.Main
open System.Text

type CodegenEnv =
    {
    text : StringBuilder
    indent : int
    }

let line x s = x.text.Append(' ', x.indent).AppendLine s |> ignore
let indent x = {x with indent=x.indent+4}
let add_dec_point (x : string) = if x.IndexOf('.') = -1 then x + ".0" else x

exception CodegenError of string
exception CodegenErrorWithPos of Trace * string
let raise_codegen_error x = raise (CodegenError x)
let raise_codegen_error' trace x = raise (CodegenErrorWithPos(trace,x))