module Spiral.Compile

open Spiral.Types
open System.Collections.Generic
open Spiral
open Spiral.Codegen
open FParsec.CharParsers
open System.Diagnostics

type ModulePrepassEnv = {
    settings : SpiralCompilerSettings
    seq : ResizeArray<TypedBind>
    context : ResizeArray<TypedData>
    map : Map<string, int>
    time_parse : Stopwatch
    time_prepass : Stopwatch
    time_peval : Stopwatch
    time_codegen : Stopwatch
    }

let inline timeit (d: Stopwatch) f x =
    d.Start()
    let x = f x
    d.Stop()
    x

let raise_compile_error x = raise (CompileError x)
let module_let (env: ModulePrepassEnv) (m: SpiralModule) = 
    let count = env.context.Count
    let context = env.context.ToArray()
    let expr, size = 
        match timeit env.time_parse (Parsing.parse env.settings) m with
        | Success(x,_,_) -> x
        | Failure(x,_,_) -> raise_compile_error x
        |> timeit env.time_prepass (Prepass.prepass {prepass_context=context; prepass_map=env.map; prepass_map_length=count})
    let module_ = 
        let d = {rbeh=AnnotationDive; seq=env.seq; env_global=context; env_stack_ptr=0; env_stack=Array.zeroCreate size; trace=[]; cse=ref Map.empty}
        timeit env.time_peval (PartEval.partial_eval d) expr
    env.context.Add module_
    {env with map=env.map.Add (m.name, count)}

let module_open (env: ModulePrepassEnv) x =
    match env.map.TryFind x with
    | Some x ->
        match env.context.[x] with
        | TyMap x ->
            let map, _ =
                Map.fold (fun (s, count) k v ->
                    env.context.Add v
                    Map.add (Spiral.Parsing.keyword_to_string k) count s, count+1
                    ) (env.map, env.context.Count) x
            {env with map=map}
        | _ -> raise_compile_error <| sprintf "In module_prepass, `open` did not receive a module."
    | _ -> raise_compile_error <| sprintf "In module_prepass, `open` did not find a module named %s in the environment." x

let compile (settings: SpiralCompilerSettings) (m: SpiralModule) =
    let ms =
        let dict = Dictionary(HashIdentity.Reference)
        let ms = ResizeArray()
        let rec loop m =
            memoize dict (fun (m: SpiralModule) ->
                List.iter loop m.prerequisites
                ms.Add m
                ) m
        loop m
        ms.ToArray()

    let env = {
        settings = settings
        context = ResizeArray()
        seq = ResizeArray()
        map = Map.empty
        time_parse = Stopwatch()
        time_prepass = Stopwatch()
        time_peval = Stopwatch()
        time_codegen = Stopwatch()
        }

    let env = module_let env CoreLib.core
    let env = module_open env "Core"
    let env = Array.fold module_let env ms
    env.seq.ToArray() |> timeit env.time_codegen Fsharp.codegen

    //let watch = System.Diagnostics.Stopwatch.StartNew()

    //parse_modules module_main Fail <| fun body -> 
    //    printfn "Running %s." module_name
    //    let parse_time = watch.Elapsed
    //    printfn "Time for parse: %A" parse_time
    //    watch.Restart()
    //    let d = data_empty()
    //    let input = body |> expr_prepass
    //    let prepass_time = watch.Elapsed
    //    printfn "Time for prepass: %A" prepass_time
    //    watch.Restart()
    //    try
    //        let x = !d.seq (expr_peval d input)
    //        let peval_time = watch.Elapsed
    //        printfn "Time for peval was: %A" peval_time
    //        watch.Restart()
    //        let x = spiral_fsharp_codegen x
    //        let codegen_time = watch.Elapsed
    //        printfn "Time for codegen was: %A" codegen_time
    //        Succ (x, {parsing_time=parse_time; prepass_time=prepass_time;peval_time=peval_time; codegen_time=codegen_time})
    //    with
    //    | :? TypeError as e -> 
    //        let trace, message = e.Data0, e.Data1
    //        Fail <| print_type_error trace message


