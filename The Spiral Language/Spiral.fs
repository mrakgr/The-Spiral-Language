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
    let keyword_to_string _ = failwith ""
    let string_to_keyword _ = failwith ""

    let rec module_prepass (env: ModulePrepassEnv) = function
        | ModPreLet(x,a,b) ->
            let count = env.modpre_context.Count
            let context = env.modpre_context.ToArray()
            let expr, size = prepass {prepass_context=context; prepass_map=env.modpre_map}
            let module_ = partial_eval {rbeh=AnnotationDive; seq=env.modpre_seq; env_global=context; env_cur=Array.zeroCreate size; trace=[] } expr
            env.modpre_context.Add module_
            module_prepass {env with modpre_map=env.modpre_map.Add (x, count)} b
        | ModPreOpen(x,b) ->
            match env.modpre_map.TryFind x with
            | Some x ->
                match env.modpre_context.[x] with
                | TyMap x ->
                    let map, _ =
                        Map.fold (fun (s, count) k v ->
                            env.modpre_context.Add v
                            Map.add (keyword_to_string k) count s, count+1
                            ) (env.modpre_map, env.modpre_context.Count) x
                    module_prepass {env with modpre_map=map} b
                | _ -> failwith "In module_prepass, `open` did not receive a module."
            | _ -> failwithf "In module_prepass, `open` did not find a module named %s in the environment." x
                        
            
    and prepass _ = failwith ""
    and partial_eval _ = failwith ""
    ()