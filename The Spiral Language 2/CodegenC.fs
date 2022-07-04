module Spiral.Codegen.C

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils
open System
open System.Text
open System.Collections.Generic

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let types = ResizeArray()
    let functions = ResizeArray()

    let binds a b = failwith ""
    let main = StringBuilder()
    binds {text=main; indent=0} x

    //let program = StringBuilder()
    //types |> Seq.iteri (fun i x -> program.Append(if i = 0 then "type " else "and ").Append(x) |> ignore)
    //functions |> Seq.iteri (fun i x -> program.Append(if i = 0 then "let rec " else "and ").Append(x) |> ignore)
    //program.Append(main).ToString()

    failwith ""