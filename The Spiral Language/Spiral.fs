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

    let rec module_prepass (env: ModulePrepassEnv) expr = 
        let error x = raise (PrepassError x)
        
        match expr with
        | ModPreLet(x,a,b) ->
            let count = env.modpre_context.Count
            let context = env.modpre_context.ToArray()
            let expr, size = prepass {prepass_context=context; prepass_map=env.modpre_map; prepass_map_length=count} a
            let module_ = partial_eval {rbeh=AnnotationDive; seq=env.modpre_seq; env_global=context; env_stack=Array.zeroCreate size; trace=[] } expr
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
                | _ -> error <| sprintf "In module_prepass, `open` did not receive a module."
            | _ -> error <| sprintf "In module_prepass, `open` did not find a module named %s in the environment." x
                        
            
    and prepass (env: PrepassEnv) expr = 
        let tag () = tag_prepass <- tag_prepass + 1; tag_prepass
        let prepass_memo_dict = Dictionary(HashIdentity.Reference)
        let error x = raise (PrepassError x)

        let string_to_var env x =
            match Map.tryFind x env with
            | Some x -> x
            | None -> error <| sprintf "Variable %s not bound." x

        let rec loop (env: PrepassEnv) expr = 
            memoize prepass_memo_dict (function
                | RawV x -> let tag = tag() in V(tag, string_to_var env.prepass_map x), Set.singleton tag, 0
                | RawLit x -> let tag = tag() in Lit(tag, x), Set.empty, 0
                | RawOpen(n,on_succ) ->
                    let module_name = n.[0]
                    let submodule_names = n.[1..]
                    match env.prepass_map.TryFind module_name with
                    | Some name ->
                        if name < env.prepass_context.Length then
                            let env' =
                                Array.fold (fun (name, s) x ->
                                    match s with
                                    | TyMap s ->
                                        match Map.tryFind (string_to_keyword x) s with
                                        | Some s -> sprintf "%s.%s" name x,s
                                        | None -> error <| sprintf "Module %s does not have a submodule named %s." name x
                                    | _ -> error <| sprintf "The variable %s being opened is not a module." name
                                    ) (module_name, env.prepass_context.[name]) submodule_names
                                |> function
                                    | _, TyMap s -> s
                                    | name, _ -> error <| sprintf "The variable %s being opened is not a module." name
                            let on_succ, free_vars, stack_size = 
                                let map, length = 
                                    Map.fold (fun (map, length) k _ ->
                                        Map.add (keyword_to_string k) length map, length + 1 
                                        ) (env.prepass_map, env.prepass_map_length) env'
                                loop {env with prepass_map=map; prepass_map_length=length} on_succ
                            let free_vars, stack_size =
                                Map.fold (fun (free_vars, stack_size) k _ -> Set.remove k free_vars, stack_size + 1) 
                                    (free_vars, stack_size) env'
                            Open(tag(), name, Array.map string_to_keyword submodule_names, on_succ), free_vars, stack_size
                        else
                            error <| sprintf "Module %s is not a proper module or might have been shadowed. Only records returned from previously compiled modules can be opened." module_name
                    | None -> error <| sprintf "Module %s is not bound." module_name
                ) expr
        
        let expr, free_vars, stack_size = loop env expr
        expr, stack_size
        
        
    and partial_eval _ = failwith ""
    ()