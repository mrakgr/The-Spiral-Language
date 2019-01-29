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
    let mutable tag_prepass = 0
    let mutable tag_keyword = 0

    let keyword_to_string_dict = d0()
    let string_to_keyword_dict = d0()
    
    let string_to_keyword (x: string) =
        match string_to_keyword_dict.TryGetValue x with
        | true, v -> v
        | false, _ ->
            tag_keyword <- tag_keyword + 1
            string_to_keyword_dict.[x] <- tag_keyword
            keyword_to_string_dict.[tag_keyword] <- x
            tag_keyword
    let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.

    let rec module_prepass (env: ModulePrepassEnv) = function
        | ModPreLet(x,a,b) ->
            let count = env.modpre_context.Count
            let context = env.modpre_context.ToArray()
            let expr, size = prepass {prepass_context=context; prepass_map=env.modpre_map} a
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
                        
            
    and prepass (env: PrepassEnv) expr = 
        let tag () = tag_prepass <- tag_prepass + 1; tag_prepass
        let prepass_memo_dict = Dictionary(HashIdentity.Reference)

        let string_to_var env x =
            match Map.tryFind x env with
            | Some x -> x
            | None -> raise (PrepassUnboundVariable x)

        let rec loop (env: PrepassEnv) expr = 
            memoize prepass_memo_dict (function
                | RawV x -> V(tag(), string_to_var env.prepass_map x), 0
                
                ) expr
        
        loop env expr
        
        
    and partial_eval _ = failwith ""
    ()