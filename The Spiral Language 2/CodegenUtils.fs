module Spiral.CodegenUtils

open Spiral.PartEval.Main
open System.Text

type string_builder_env =
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

[<RequireQualifiedAccess>]
type backend_cpp =
    | CudaDevice
    | CudaHost
    | CppHost

    member t.Name = t.ToString()

open System.Collections.Generic

type codegen_env =
    {
        globals : OrderedDictionary<int, string ResizeArray>
        fwd_dcls_types : OrderedDictionary<int, string ResizeArray>
        fwd_dcls_methods : OrderedDictionary<int, string ResizeArray>
        fwd_dcls_main_defs : OrderedDictionary<int, string ResizeArray>
        types : OrderedDictionary<int, string ResizeArray>
        functions : OrderedDictionary<int, string ResizeArray>
        main_defs : OrderedDictionary<int, string ResizeArray>
    }

    static member Create() =
        {
            globals = OrderedDictionary()
            fwd_dcls_types = OrderedDictionary()
            fwd_dcls_methods = OrderedDictionary()
            fwd_dcls_main_defs = OrderedDictionary()
            types = OrderedDictionary()
            functions = OrderedDictionary()
            main_defs = OrderedDictionary()
        }
