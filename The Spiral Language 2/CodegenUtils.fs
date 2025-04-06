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

type backend_type =
    | CudaDevice
    | CudaHost
    | Python
    
type codegen_env =
    {
        globals : string ResizeArray
        fwd_dcls : string ResizeArray
        types : string ResizeArray
        functions : string ResizeArray
        main_defs : string ResizeArray
        backend_type : backend_type
    }

    static member Create backend_type =
        {
            globals = ResizeArray()
            fwd_dcls = ResizeArray()
            types = ResizeArray()
            functions = ResizeArray()
            main_defs = ResizeArray()
            backend_type = backend_type
        }

    member t.backend_name = t.backend_type.ToString()
    member t.__device__ =
        match t.backend_type with
        | CudaDevice -> "__device__"
        | Python | CudaHost -> ""