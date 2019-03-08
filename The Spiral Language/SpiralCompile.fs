module Spiral.Compile

open Spiral.Types
open Spiral.Show
open Spiral.Codegen
open System.Collections.Generic
open System.Diagnostics
open System
open System.Runtime.CompilerServices

// Globals
let prepass_dict = ConditionalWeakTable()

type Timings =
    {
    parse : TimeSpan
    prepass : TimeSpan
    peval : TimeSpan
    codegen : TimeSpan
    }

    member x.Add(y) =
        {
        parse = x.parse + y.parse
        prepass = x.prepass + y.prepass
        peval = x.peval + y.peval
        codegen = x.codegen + y.codegen
        }

type Watches = 
    {
    parse : Stopwatch
    prepass : Stopwatch
    peval : Stopwatch
    codegen : Stopwatch
    }

    member x.Elapsed: Timings =
        {
        parse = x.parse.Elapsed
        prepass = x.prepass.Elapsed
        peval = x.peval.Elapsed
        codegen = x.codegen.Elapsed
        }

let inline timeit (d: Stopwatch) f x =
    d.Start()
    let x = f x
    d.Stop()
    x

type ModulePrepassEnv = {
    settings : SpiralCompilerSettings
    seq : ResizeArray<TypedBind>
    map : Map<string, TypedData>
    timing : Watches
    }

let raise_compile_error x = raise (CompileError x)
let raise_compile_error' pos x = raise (CompileErrorWithPos(pos, x))

let module_open (env: ModulePrepassEnv) opens =
    List.fold (fun (env: ModulePrepassEnv) -> function
        | [] -> env
        | open_ :: open_' as opens ->
            match Map.tryFind open_ env.map with
            | Some s ->
                List.fold (fun (s: TypedData, open_) x ->
                    let opens () = List.rev open_ |> String.concat "."
                    match s with
                    | TyMap s ->
                        match Map.tryFind (string_to_keyword x) s with
                        | Some s -> s, x :: open_
                        | None -> raise_compile_error <| sprintf "Module `%s` does not a have a submodule %s." (opens()) x
                    | s -> raise_compile_error <| sprintf "Expected a module during the opening of %s.\nGot: %s" (opens()) (show_typed_data s)
                    ) (s, [open_]) open_'
            | _ -> raise_compile_error <| sprintf "Module named %s does not exist in the global environment." open_
            |> function
                | TyMap s, _ -> {env with map=Map.foldBack (keyword_to_string >> Map.add) s env.map}
                | s, _ -> raise_compile_error <| sprintf "Expected a module during the opening of %s.\nGot: %s" (String.concat "." opens) (show_typed_data s)
        ) env opens

let module_let (env: ModulePrepassEnv) (m: SpiralModule) =
    let expr, free_vars, stack_size =
        memoize' prepass_dict (fun m -> 
            match timeit env.timing.parse Parsing.parse m with
            | Ok x -> x
            | Fail x -> raise_compile_error x
            //|> fun x -> printfn "%A" x; x
            |> timeit env.timing.prepass Prepass.prepass
            ) m
    let module_ =
        let env = module_open env m.opens
        let unbound_variables =
            Array.choose (fun (name,pos) ->
                match Map.tryFind name env.map with
                | Some x -> None
                | None -> Some(name,pos)
                ) free_vars
        match unbound_variables with
        | [||] -> ()
        | [|var,pos|] -> raise_compile_error' [pos] <| sprintf "The variable %s is unbound." var
        | _ -> 
            let var, pos = Array.unzip unbound_variables
            let var = String.concat ", " var
            raise_compile_error' (Array.rev pos |> Array.toList) <| sprintf "The variables %s are unbound." var
        let context =
            Array.map (fun (name,pos) ->
                match Map.tryFind name env.map with
                | Some x -> x
                | None -> failwith "impossible"
                ) free_vars
        let d = {rbeh=AnnotationDive; seq=env.seq; env_global=context; env_stack_ptr=0; env_stack=Array.zeroCreate stack_size; trace=[]; cse=ref Map.empty}
        //printfn "%A" expr
        timeit env.timing.peval (PartEval.partial_eval d) expr
    {env with map=env.map.Add (m.name, module_)}

let compile (settings: SpiralCompilerSettings) (m: SpiralModule) =
    let env = {
        settings = settings
        seq = ResizeArray()
        map = Map.empty
        timing =
            {
            parse = Stopwatch()
            prepass = Stopwatch()
            peval = Stopwatch()
            codegen = Stopwatch()
            }
        }

    try
        PartEval.part_eval_tag <- 0
        let ms =
            let dict = Dictionary(HashIdentity.Reference)
            let ms = ResizeArray()
            let rec loop (m: SpiralModule) =
                memoize dict (fun (m: SpiralModule) ->
                    List.iter loop m.prerequisites
                    ms.Add m
                    ) m
            
            loop m
            ms.ToArray()

        let env = module_let env CoreLib.core
        let env = module_open env [["Core"]]
        let env = Array.fold module_let env ms
        env.seq.ToArray() 
        //|> fun x -> printfn "%A" x; x
        |> timeit env.timing.codegen Fsharp.codegen
        |> fun x -> Ok (env.timing.Elapsed,x)
    with
        | :? PrepassError as x -> Fail(env.timing.Elapsed, x.Data0)
        | :? PrepassErrorWithPos as x -> Fail(env.timing.Elapsed, show_trace {settings with filter_list=[]} [x.Data0] x.Data1)
        | :? TypeError as x -> Fail(env.timing.Elapsed, show_trace settings x.Data0 x.Data1)
        | :? TypeRaised as x -> Fail(env.timing.Elapsed, sprintf "Uncaught type raise.\nGot: %s" (Show.show_ty x.Data0))
        | :? CodegenError as x -> Fail(env.timing.Elapsed, x.Data0)
        | :? CodegenErrorWithPos as x -> Fail(env.timing.Elapsed, show_trace {settings with filter_list=[]} x.Data0 x.Data1)
        | :? CompileError as x -> Fail(env.timing.Elapsed, x.Data0)
        | :? CompileErrorWithPos as x -> Fail(env.timing.Elapsed, show_trace {settings with filter_list=[]} x.Data0 x.Data1)
        
