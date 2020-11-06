module Spiral.Server

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Blockize
open Spiral.SpiProj

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | Put of string
    | Modify of SpiEdit
    | GetRange of VSCRange * (VSCTokenArray -> unit)
type TokRes = {blocks : Block list; errors : RString []}
type ParserRes = {bundles : Bundle list; parser_errors : RString []; tokenizer_errors : RString []}

let tokenizer req =
    let lines : LineToken [] ResizeArray = ResizeArray([[||]])
    let mutable errors_tokenization = [||]
    let mutable blocks : Block list = []

    let res_text = Src.create()
    let replace edit =
        errors_tokenization <- Tokenize.replace lines errors_tokenization edit // Mutates the lines array
        blocks <- block_separate lines blocks edit
        Src.value res_text {blocks=blocks; errors=errors_tokenization}

    req |> Stream.consumeJob (function 
        | Put text -> replace {|from=0; nearTo=lines.Count; lines=Utils.lines text|}
        | Modify edit -> replace edit
        | GetRange((a,b),res) ->
            let from, near_to = min (lines.Count-1) a.line, min lines.Count (b.line+1)
            vscode_tokens from (lines.GetRange(from,near_to-from |> max 0).ToArray()) |> res
            Job.unit()
        )
    Src.tap res_text

let parse dict is_top_down (a : TokRes) =
    let b = 
        List.map (fun x -> {
            parsed = Utils.memoize dict (block_init is_top_down) x.block
            offset = x.offset
            }) a.blocks
    dict.Clear(); List.iter2 (fun a b -> dict.Add(a.block,b.parsed)) a.blocks b
    let bundles, parser_errors = block_bundle b
    {bundles = bundles; parser_errors = parser_errors; tokenizer_errors = a.errors}

let parser' is_top_down tokens =
    let tokens = Stream.values tokens
    let req = Ch()

    let dict = Dictionary(HashIdentity.Reference)
    let src = Src.create()

    let rec init () = waiting <|> (Ch.give req (Src.tap src) ^=> init)
    and rest p = waiting <|> (Ch.give req (Stream.cons p (Src.tap src)) ^=> fun () -> rest p)
    and parsing x = waiting <|> Alt.prepareJob (fun () -> let p = parse dict is_top_down x in Src.value src p >>-. rest p)
    and waiting = tokens ^=> parsing

    Hopac.start (init ())
    req

//let parser is_top_down tokens = Ch.take (parser' is_top_down tokens) |> Hopac.run
let parser is_top_down tokens = tokens |> Stream.keepPreceding1 |> Stream.mapFun (parse (Dictionary(HashIdentity.Reference)) is_top_down)

type TypecheckerRes = (Bundle * Infer.InferResult * Infer.TopEnv) PersistentVector * bool
let typechecker package_id module_id (req : ParserRes Stream) : TypecheckerRes Stream =
    let req = Stream.values req
    let res = Src.create()
    let r = Src.tap res
    let rec waiting a = req ^=> fun b ->
        let rec loop s i b = 
            match PersistentVector.tryNth i a, b with
            | Some(bundle,_,_ as r), bundle' :: b' when bundle = bundle' -> loop (PersistentVector.conj r s) (i+1) b'
            | _ -> s, b
        loop PersistentVector.empty 0 b.bundles |> processing
    and processing = function
        | a, [] -> Alt.prepare (Src.value res (a,true) >>- fun () -> waiting a)
        | a, b :: b' -> waiting a <|> Alt.prepare (Src.value res (a, false) >>- fun () ->
            let env =
                match PersistentVector.tryLast a with
                | Some(_,_,env) -> env
                | None -> Infer.top_env_default
            let r = Infer.infer package_id module_id env (bundle_top b)
            let a' = PersistentVector.conj (b,r,Infer.union r.top_env_additions env) a
            processing (a', b')
            )
    Hopac.server (waiting PersistentVector.empty)
    r

//type TypecheckerFiles<'a> =
//    | TCFile of name: string * stream: 'a Stream
//    | TCDir of name: string * 'a TypecheckerFiles

//let tc_file req = failwith "TODO"
//let tc_dir req = failwith "TODO"
//let multi_file_pipe package_id module_id (env : Infer.TopEnv) (req : ParserRes TypecheckerFiles): TypecheckerRes TypecheckerFiles =
//    let rec loop = function
//        | TCFile(name,s) -> failwith ""
//    failwith ""

let hover (req : (VSCPos * (string option -> unit)) Stream) (req_tc : TypecheckerRes Stream) =
    let req, req_tc = Stream.values req, Stream.values req_tc
    let rec processing ((x,_ as r) : TypecheckerRes) = waiting <|> (req ^=> fun (pos,ret) ->
        let rec block_from i = 
            if 0 <= i then 
                let a,b,_ = x.[i]
                if (List.head a).offset <= pos.line then b.hovers else block_from (i-1)
            else [||]
        block_from (x.Length-1) |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ) |> ret
        processing r
        )
    and waiting = req_tc ^=> processing
    Hopac.server waiting

type Graph = Dictionary<string,string HashSet>
type MirroredGraph = Graph * Graph

let create_mirrored_graph() = Graph(), Graph()

let add_link (s : Graph) a b = (Utils.memoize s (fun _ -> HashSet()) a).Add(b) |> ignore
let add_link' (s : MirroredGraph) a b = add_link (fst s) a b; add_link (snd s) b a

let remove_link (s : Graph) a b = 
    match s.TryGetValue(a) with
    | true, v -> (if v.Count <= 1 then s.Remove(a) else v.Remove(b)) |> ignore
    | _ -> ()
let remove_link' (s : MirroredGraph) a b = remove_link (fst s) a b; remove_link (snd s) b a

let remove_links ((fwd,rev) : MirroredGraph) a = 
    let mutable a_links = Unchecked.defaultof<_>
    if fwd.Remove(a,&a_links) then Seq.iter (fun b -> remove_link rev b a) a_links
let add_links s a b = List.iter (add_link' s a) b
let replace_links (s : MirroredGraph) a b = remove_links s a; add_links s a b
let get_links (s : Graph) a = match s.TryGetValue(a) with true, x -> x | _ -> HashSet()

let circular_nodes ((fwd,rev) : MirroredGraph) dirty_nodes =
    let sort_order = Stack()
    let sort_visited = HashSet()
    let rec dfs_rev a = if sort_visited.Add(a) then Seq.iter dfs_rev (get_links rev a); sort_order.Push(a)
    Seq.iter dfs_rev dirty_nodes
    let order = sort_order.ToArray()

    let visited = HashSet()
    let circular_nodes = HashSet()
    order |> Array.iter (fun a ->
        let ar = ResizeArray()
        let rec dfs a = if sort_visited.Contains(a) && visited.Add(a) then Seq.iter dfs (get_links fwd a); ar.Add a
        dfs a
        if 1 < ar.Count then ar |> Seq.iter (fun x -> circular_nodes.Add(x) |> ignore)
        )
    order, circular_nodes

type ProjectCodeAction = 
    | CreateFile of {|filePath : string|}
    | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
    | RenameFile of {|filePath : string; target : string|}
    | CreateDirectory of {|dirPath : string|}
    | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
    | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

let code_action_execute a =
    try match a with
        | CreateDirectory a -> Directory.CreateDirectory(a.dirPath) |> ignore; None
        | DeleteDirectory a -> Directory.Delete(a.dirPath,true); None
        | RenameDirectory a ->
            if a.validate_as_file then
                match FParsec.CharParsers.run file_verify a.target with
                | FParsec.CharParsers.ParserResult.Success _ -> Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); None
                | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Some er
            else
                Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); None
        | CreateFile a ->
            if File.Exists(a.filePath) then Some "File already exists."
            else File.Create(a.filePath).Dispose(); None
        | DeleteFile a -> File.Delete(a.filePath); None
        | RenameFile a ->
            match FParsec.CharParsers.run file_verify a.target with
            | FParsec.CharParsers.ParserResult.Success _ -> File.Move(a.filePath,Path.Combine(a.filePath,"..",a.target+Path.GetExtension(a.filePath)),false); None
            | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Some er
    with e -> Some e.Message

type RAction = VSCRange * ProjectCodeAction
type ValidatedSchema = {
    schema : Schema
    packages : RString list
    links : RString []
    actions : RAction []
    errors : RString []
    }
let schema project_dir x =
    let errors = ResizeArray()
    let actions = ResizeArray()
    let validate_dir dir =
        match dir with
        | Some (r,dir) ->
            try let x = DirectoryInfo(Path.Combine(project_dir,dir))
                if x = null then errors.Add (r, "Directory is rootless.")
                elif x.Exists then
                    actions.Add (r, RenameDirectory {|dirPath=x.FullName; target=null; validate_as_file=false|})
                    actions.Add (r, DeleteDirectory {|dirPath=x.FullName; range=r|})
                else
                    errors.Add (r, "Directory does not exist.")
                    actions.Add (r, CreateDirectory {|dirPath=x.FullName|})
                x.FullName
            with e -> errors.Add (r, e.Message); project_dir
        | None -> project_dir

    let moduleDir = validate_dir x.moduleDir
    let links = ResizeArray()
    if 0 = errors.Count then
        let rec validate_ownership (r,dir : DirectoryInfo) =
            if dir = null then errors.Add(r, "The directory should be a subdirectory of the current project file.")
            else 
                let p = Path.Combine(dir.FullName,"package.spiproj")
                if File.Exists(p) then
                    if dir.FullName <> project_dir then 
                        errors.Add(r, "This module directory belongs to a different project.")
                        links.Add(r, "file:///" + p)
                else validate_ownership (r,dir.Parent)
        x.moduleDir |> Option.iter (fun (r,dir) -> try validate_ownership (r,DirectoryInfo(Path.Combine(project_dir,dir))) with e -> errors.Add (r, e.Message))

    if 0 = errors.Count then 
        let rec validate_file prefix = function
            | File(r',(r,a),is_top_down,_) -> 
                try let x = FileInfo(Path.Combine(prefix,a + (if is_top_down then ".spi" else ".spir")))
                    if x.Exists then 
                        links.Add (r, "file:///" + x.FullName)
                        actions.Add (r, RenameFile {|filePath=x.FullName; target=null|})
                        actions.Add (r, DeleteFile {|range=r'; filePath=x.FullName|})
                    else 
                        errors.Add (r, "File does not exist.")
                        actions.Add (r, CreateFile {|filePath=x.FullName|})
                with e -> errors.Add (r, e.Message)
            | Directory(r',(r,a),b) ->
                try let x = DirectoryInfo(Path.Combine(prefix,a))
                    let p = Path.Combine(x.FullName,"package.spiproj")
                    if File.Exists(p) then 
                        errors.Add(r, "This directory belongs to a different project.")
                        links.Add (r, "file:///" + p)
                    elif x.Exists then
                        Array.iter (validate_file x.FullName) b
                        actions.Add (r, RenameDirectory {|dirPath=x.FullName; target=null; validate_as_file=true|})
                        actions.Add (r, DeleteDirectory {|dirPath=x.FullName; range=r'|})
                    else
                        errors.Add (r, "Directory does not exist.")
                        actions.Add (r, CreateDirectory {|dirPath=x.FullName|})
                with e -> errors.Add (r, e.Message)
        Array.iter (validate_file moduleDir) x.modules
    let outDir = validate_dir x.outDir
    let packages =
        let packages = HashSet()
        let validate_package d (r,x) =
            try let x = DirectoryInfo(Path.Combine(d,x)).FullName
                if project_dir = x then errors.Add(r,"Self references are not allowed."); None
                // The validator needs the backwards links even for files that are currently missing, but might exist.
                elif packages.Add(x) then Some(r, x)
                else errors.Add(r,"Duplicates are not allowed."); None
            with e -> errors.Add(r, e.Message); None
        match x.packageDir with
        | Some(r,n) -> 
            try let d = DirectoryInfo(Path.Combine(project_dir,n))
                if d.Exists = false then errors.Add(r, "The directory does not exist.")
                List.choose (validate_package d.FullName) x.packages
            with e -> errors.Add (r, e.Message); []
        | None -> List.choose (validate_package (Path.Combine(project_dir,".."))) x.packages
    {schema=x; packages=packages; links=links.ToArray(); actions=actions.ToArray(); errors=errors.ToArray()}

let load_from_string project_dir text =
    match config text with
    | Ok x -> schema project_dir x |> Ok
    | Error er -> {schema=schema_def; packages=[]; links=[||]; actions=[||]; errors=er} |> Ok

let load_from_file project_dir =
    let p = Path.Combine(project_dir,"package.spiproj")
    if File.Exists(p) then 
        Job.catch (Job.fromTask (fun () -> File.ReadAllTextAsync(p))) >>- function
        | Choice1Of2 text -> load_from_string project_dir text
        | Choice2Of2 er -> Error er.Message
    else Job.result (Error "The package file does not exist.")

type LoadedSchemas = Map<string,Result<ValidatedSchema,string>>
let load (m : LoadedSchemas) text project_dir =
    let m = Map.remove project_dir m
    let waiting = MVar(Set.empty)
    let finished = MVar(m)
    let rec loop text project_dir =
        match Map.tryFind project_dir m with
        | Some _ -> Job.unit()
        | None ->
            MVar.modifyFun (fun waiting ->
                if Set.contains project_dir waiting then waiting, Job.unit()
                else 
                    let process_packages = function
                        | Ok x -> Seq.Con.iterJob (snd >> loop None) x.packages
                        | Error _ -> Job.unit()
                    Set.add project_dir waiting,
                    match text with
                    | None -> 
                        load_from_file project_dir >>= fun x ->
                        Job.start (MVar.mutateFun (Map.add project_dir x) finished) >>=.
                        process_packages x
                    | Some text -> Job.delay <| fun () ->
                        let x = load_from_string project_dir text 
                        Job.start (MVar.mutateFun (Map.add project_dir x) finished) >>=.
                        process_packages x
                ) waiting >>= Job.Ignore
    loop text project_dir >>=. MVar.take finished

type PackageSchema = {
    schema : ValidatedSchema
    package_links : RString []
    package_errors : RString []
    }

let spiproj_link dir = sprintf "file:///%s/package.spiproj" dir

let validate (schemas : Dictionary<string, Result<PackageSchema, string>>) (links : MirroredGraph) (loads : LoadedSchemas) project_dir =
    let potential_floating_garbage = 
        project_dir :: 
        match schemas.TryGetValue(project_dir) with 
        | true, Ok v -> List.map snd v.schema.packages
        | _ -> []
    let cleanup () = 
        List.fold (fun m project_dir ->
            match schemas.[project_dir] with
            | Error _ when (fst links).ContainsKey(project_dir) = false && (snd links).ContainsKey(project_dir) = false ->
                schemas.Remove(project_dir) |> ignore
                Map.remove project_dir m
            | _ -> m
            ) loads potential_floating_garbage

    let dirty_nodes = HashSet()
    let rec loop project_dir =
        match loads.[project_dir] with 
        | Ok x -> List.iter (fun (r,x) -> add_link' links project_dir x; check x) x.packages 
        | Error _ -> ()
    and check project_dir = if schemas.ContainsKey(project_dir) = false && dirty_nodes.Add(project_dir) then loop project_dir

    schemas.Remove(project_dir) |> ignore
    remove_links links project_dir
    dirty_nodes.Add(project_dir) |> ignore
    loop project_dir 

    let order, circular_nodes = circular_nodes links dirty_nodes
    order |> Array.iter (fun cur ->
        match loads.[cur] with
        | Ok v ->
            let is_circular = circular_nodes.Contains(cur)
            let links = ResizeArray()
            let errors = ResizeArray()
            v.packages |> List.iter (fun (r,sub) ->
                if circular_nodes.Contains(sub) then 
                    let rest = if is_circular then " and the current package is a part of that loop." else "."
                    errors.Add(r,sprintf "This package is circular%s" rest)
                else 
                    match schemas.[sub] with // Note: This key index might fail if the circularity check is not done first.
                    | Ok x when 0 < x.schema.errors.Length || 0 < x.package_errors.Length -> errors.Add(r,"The package or the chain it is a part of has an error.") 
                    | Ok _ -> links.Add(r,spiproj_link sub)
                    | Error x -> errors.Add(r,x)
                )
            schemas.[cur] <- Ok {schema=v; package_links=links.ToArray(); package_errors=errors.ToArray()}
        | Error x ->
            schemas.[cur] <- Error x
        )
   
    order, cleanup()

type PackageSupervisorReq =
    | SOpen of dir: string * text: string option
    | SChange of dir: string * text: string option
    | SLinks of dir: string * RString [] IVar
    | SCodeActions of dir: string * RAction [] IVar
    | SCodeActionExecute of ProjectCodeAction

let change (schemas : Dictionary<_,_>) links loads errors is_open dir text =
    match schemas.TryGetValue(dir) with
    | true, Ok _ when is_open -> Job.unit()
    | _ ->
        load !loads text dir >>= fun m ->
        let dirty_nodes, m = validate schemas links m dir
        loads := m
        Array.iterJob (fun dir ->
            match schemas.TryGetValue(dir) with
            | true, Ok x -> Src.value errors {|uri=spiproj_link dir; errors=Array.append x.schema.errors x.package_errors|}
            | _ -> Job.unit()
            ) dirty_nodes

let supervisor fatal_errors errors =
    let req = Src.create()
    let schemas = Dictionary()
    let links = create_mirrored_graph()
    let loads = ref Map.empty
    let change = change schemas links loads errors

    Src.tap req |> consumeJob (function
        | SOpen(dir,text) -> change true dir text
        | SChange(dir,text) -> change false dir text
        | SLinks(dir,res) -> 
            match schemas.[dir] with
            | Ok x -> IVar.fill res (Array.append x.schema.links x.package_links)
            | Error _ -> IVar.fill res [||]
        | SCodeActions(dir,res) ->
            match schemas.[dir] with
            | Ok x -> IVar.fill res x.schema.actions
            | Error _ -> IVar.fill res [||]
        | SCodeActionExecute a -> 
            match code_action_execute a with
            | Some er -> Src.value fatal_errors er
            | None -> Job.unit()
        )

    req

type ClientReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|}
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
    | ProjectCodeActions of {|uri : string|}
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|}
    | HoverAt of {|uri : string; pos : VSCPos|}
    | BuildFile of {|uri : string|}

type ClientErrorsRes =
    | FatalError of string
    | PackageErrors of {|uri : string; errors : RString []|}
    | TokenizerErrors of {|uri : string; errors : RString []|}
    | ParserErrors of {|uri : string; errors : RString []|}
    | TypeErrors of {|uri : string; errors : RString list|}

let port = 13805
let uri_server = sprintf "tcp://*:%i" port
let uri_client = sprintf "tcp://localhost:%i" (port+1)

open FSharp.Json
open NetMQ
open NetMQ.Sockets

let [<EntryPoint>] main _ =
    use poller = new NetMQPoller()
    use server = new RouterSocket()
    poller.Add(server)
    server.Options.ReceiveHighWatermark <- System.Int32.MaxValue
    server.Bind(uri_server)
    printfn "Server bound to: %s" uri_server

    use queue_server = new NetMQQueue<NetMQMessage>()
    poller.Add(queue_server)

    use queue_client = new NetMQQueue<ClientErrorsRes>()
    poller.Add(queue_client)

    let file = Utils.memoize (Dictionary()) <| fun (uri : string) ->
        let s = {|token = Src.create(); hover = Src.create()|}
        let token = tokenizer (Src.tap s.token)
        let parse = parser (System.IO.Path.GetExtension(uri) = ".spi") token
        let ty = typechecker 0 0 parse
        hover (Src.tap s.hover) ty

        token |> Stream.consumeFun (fun x -> queue_client.Enqueue(TokenizerErrors {|uri=uri; errors=x.errors|}))
        parse |> Stream.consumeFun (fun x -> queue_client.Enqueue(ParserErrors {|uri=uri; errors=x.parser_errors|}))
        ty |> Stream.consumeFun (fun (x,_) -> 
            let errors = PersistentVector.foldBack (fun (_,x : Infer.InferResult,_) errors -> List.append errors x.errors) x []
            queue_client.Enqueue(TypeErrors {|errors=errors; uri=uri|})
            )
        s

    let fatal_errors = Src.create()
    Src.tap fatal_errors |> Stream.consumeFun (FatalError >> queue_client.Enqueue)
    let package_errors = Src.create()
    Src.tap package_errors |> Stream.consumeFun (PackageErrors >> queue_client.Enqueue)
    let supervisor = supervisor fatal_errors package_errors
    let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName

    let buffer = Dictionary()
    let last_id = ref 0
    use __ = server.ReceiveReady.Subscribe(fun s ->
        let rec loop () = Utils.remove buffer !last_id (body <| NetMQMessage 3) id
        and body (msg : NetMQMessage) (address : NetMQFrame, x) =
            incr last_id
            let push_back (x : obj) = 
                match x with
                | :? Option<string> as x -> 
                    match x with 
                    | None -> msg.Push("null") 
                    | Some x -> msg.Push(sprintf "\"%s\"" x)
                | _ -> msg.Push(Json.serialize x)
                msg.PushEmptyFrame(); msg.Push(address)
            let send_back x = push_back x; server.SendMultipartMessage(msg)
            let send_back_via_queue x = push_back x; queue_server.Enqueue(msg)
            let send_ivar_back_via_queue () = let res = IVar() in Hopac.start (IVar.read res >>- send_back_via_queue); res

            match x with
            | ProjectFileOpen x -> Src.value supervisor (SOpen(dir x.uri, Some x.spiprojText)) |> Hopac.start; send_back null
            | ProjectFileChange x -> Src.value supervisor (SChange(dir x.uri, Some x.spiprojText)) |> Hopac.start; send_back null
            | ProjectFileDelete x -> Src.value supervisor (SChange(dir x.uri, None)) |> Hopac.start; send_back null
            | ProjectFileLinks x -> Src.value supervisor (SLinks(dir x.uri, send_ivar_back_via_queue())) |> Hopac.start
            | ProjectCodeActionExecute x -> Src.value supervisor (SCodeActionExecute x.action) |> Hopac.start; send_back null
            | ProjectCodeActions x -> Src.value supervisor (SCodeActions(dir x.uri, send_ivar_back_via_queue())) |> Hopac.start
            | FileOpen x -> Src.value (file x.uri).token (TokReq.Put(x.spiText)) |> Hopac.start; send_back null
            | FileChanged x -> Src.value (file x.uri).token (TokReq.Modify(x.spiEdit)) |> Hopac.start; send_back null
            | FileTokenRange x -> Hopac.start (timeOutMillis 30 >>=. Src.value (file x.uri).token (TokReq.GetRange(x.range,send_back_via_queue)))
            | HoverAt x -> Hopac.start (Src.value (file x.uri).hover (x.pos, send_back_via_queue))
            | BuildFile x ->
                let x = Uri(x.uri).LocalPath
                match IO.Path.GetExtension(x) with
                | ".spi" | ".spir" -> IO.File.WriteAllText(IO.Path.ChangeExtension(x,"fsx"), "// Compiled with Spiral v0.2.")
                | _ -> ()
                send_back null
            loop ()
        let msg = server.ReceiveMultipartMessage(3)
        let address = msg.Pop()
        msg.Pop() |> ignore
        let (id : int), x = Json.deserialize(Text.Encoding.Default.GetString(msg.Pop().Buffer))
        if !last_id = id then body msg (address, x)
        else buffer.Add(id,(address,x))
        )

    use client = new RequestSocket()
    client.Connect(uri_client)

    use __ = queue_client.ReceiveReady.Subscribe(fun x -> 
        x.Queue.Dequeue() |> Json.serialize |> client.SendFrame
        client.ReceiveMultipartMessage() |> ignore
        )

    use __ = queue_server.ReceiveReady.Subscribe(fun x -> x.Queue.Dequeue() |> server.SendMultipartMessage)

    poller.Run()
    0