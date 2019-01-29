module Spiral.Main

// Global open
open System
open System.Collections.Generic
open HashConsing
open Types

// Parser open
open FParsec

// Codegen open
open System.Text

// #Main
let spiral_compile (settings: CompilerSettings) (Module(N(module_name,_,_,_)) as module_main) = 
    let mutable prepass_tag = 0
    let prepass (global_env: Dictionary<string,VarTag>) expr =
        let tag () = prepass_tag <- prepass_tag + 1; prepass_tag
        let prepass_memo_dict = Dictionary(HashIdentity.Reference)

        let rename local_env x =
            match global_env x with
            | Some y -> y
            | None ->
                match local_env x with
                | Some y -> y
                | None -> raise (PrepassUnboundVariable x)
                    

        let rec loop env expr = memoize prepass_memo_dict (eval env) expr
        and eval env = function
            | RawV x -> V(tag(), rename env x)
        
        loop expr
    ()