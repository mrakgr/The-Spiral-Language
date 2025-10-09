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
type backend_python =
    | CudaDevice
    | Python

[<RequireQualifiedAccess>]
type backend_cuda =
    | CudaDevice
    | CudaHost

    member t.Name = t.ToString()

// type codegen_env_meta =
//     abstract member backend_name : string
    
type codegen_env =
    {
        globals : string ResizeArray
        fwd_dcls : string ResizeArray
        types : string ResizeArray
        functions : string ResizeArray
        main_defs : string ResizeArray
    }

    static member Create meta =
        {
            globals = ResizeArray()
            fwd_dcls = ResizeArray()
            types = ResizeArray()
            functions = ResizeArray()
            main_defs = ResizeArray()
        }

// let backend_name
//     member t.backend_name = t.backend_type.ToString()
//     member t.backend_type_cpp =
//         match t.backend_type with
//         | backend.CudaDevice -> CppCudaDevice
//         | backend.CudaHost -> CppCudaHost
//         | backend.Python -> failwith "Compiler error: Python isn't a cpp backend."
//     member t.__device__ =
//         match t.backend_type_cpp with
//         | CppCudaDevice -> "__device__ "
//         | CppCudaHost -> ""