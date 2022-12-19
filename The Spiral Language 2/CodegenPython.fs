module Spiral.Codegen.Python

open Spiral
open Spiral.Tokenize
open Spiral.BlockParsing
open Spiral.PartEval.Main
open Spiral.CodegenUtils

open System
open System.Text
open System.Collections.Generic

let lit = function
    | LitInt8 x -> sprintf "%i" x
    | LitInt16 x -> sprintf "%i" x
    | LitInt32 x -> sprintf "%i" x
    | LitInt64 x -> sprintf "%i" x
    | LitUInt8 x -> sprintf "%i" x
    | LitUInt16 x -> sprintf "%i" x
    | LitUInt32 x -> sprintf "%i" x
    | LitUInt64 x -> sprintf "%i" x
    | LitFloat32 x -> 
        if x = infinityf then "float('inf')"
        elif x = -infinityf then "float('-inf')"
        elif Single.IsNaN x then "float()"
        else x.ToString("R") |> add_dec_point
    | LitFloat64 x ->
        if x = infinity then "float('inf')"
        elif x = -infinity then "float('-inf')"
        elif Double.IsNaN x then "float()"
        else x.ToString("R") |> add_dec_point
    | LitString x -> 
        let strb = StringBuilder(x.Length+2)
        strb.Append '"' |> ignore
        String.iter (function
            | '"' -> strb.Append "\\\"" 
            | '\b' -> strb.Append @"\b"
            | '\t' -> strb.Append @"\t"
            | '\n' -> strb.Append @"\n"
            | '\r' -> strb.Append @"\r"
            | '\\' -> strb.Append @"\\"
            | x -> strb.Append x
            >> ignore 
            ) x
        strb.Append '"' |> ignore
        strb.ToString()
    | LitChar x -> 
        match x with
        | '\b' -> @"\b"
        | '\n' -> @"\n"
        | '\t' -> @"\t"
        | '\r' -> @"\r"
        | '\\' -> @"\\"
        | x -> string x
        |> sprintf "'%s'"
    | LitBool x -> if x then "True" else "False"
let show_w = function WV(L(i,_)) -> sprintf "v%i" i | WLit a -> lit a

type BindsReturn =
    | BindsTailEnd
    | BindsLocal of TyV []

let line x s = if s <> "" then x.text.Append(' ', x.indent).AppendLine s |> ignore
let line' x s = line x (String.concat "; " s)

let codegen (env : PartEvalResult) (x : TypedBind []) =
    let imports = ResizeArray()
    let types = ResizeArray()
    let functions = ResizeArray()


    let rec binds_start (args : TyV []) (s : CodegenEnv) (x : TypedBind []) = binds (Codegen.C.refc_prepass' false (Set args) x).g_decr s BindsTailEnd x
    and binds g_decr (s : CodegenEnv) (ret : BindsReturn) (stmts : TypedBind []) = 
        let tup_destruct (a,b) =
            if 0 < Array.length a then
                let a = Array.map (fun (L(i,_)) -> $"v{i}") a |> String.concat ", "
                let b = Array.map show_w (data_term_vars b) |> String.concat ", "
                sprintf "%s = %s" a b |> line s
        Array.iter (fun x ->
            let _ =
                let f (g : Dictionary<_,_>) = match g.TryGetValue(x) with true, x -> Seq.toArray x | _ -> [||]
                (f g_decr) |> Seq.map (fun (L(i,_)) -> $"del v{i}") |> line' s
            match x with
            | TyLet(d,trace,a) ->
                try op g_decr s (BindsLocal (data_free_vars d)) a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnOp(trace,a,_) ->
                try op g_decr s ret a
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            | TyLocalReturnData(d,trace) ->
                try match ret with
                    | BindsLocal l -> tup_destruct (l, d)
                    | BindsTailEnd -> line s $"return {tup_data d}"
                with :? CodegenError as e -> raise_codegen_error' trace e.Data0
            ) stmts
    and op g_decr s (ret : BindsReturn) a =
        failwith ""
    and tup_term_vars x =
        let args = Array.map show_w x |> String.concat ", "
        if 1 < x.Length then sprintf "(%s)" args else args
    and tup_data x = tup_term_vars (data_term_vars x)

    "Hello."
