module Spiral.StreamServer

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral.Tokenize
open Spiral.TypecheckingUtils
open Spiral.Infer
open Spiral.Blockize
open Spiral.SpiProj
open Spiral.ServerUtils

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type TokReq =
    | DocumentAll of string
    | DocumentEdit of SpiEdit
type TokRes = {blocks : Block list; errors : RString list}

let job_thunk_with f x = Job.thunk (fun () -> f x)
let promise_thunk_with f x = Hopac.memo (job_thunk_with f x)
let promise_thunk f = Hopac.memo (Job.thunk f)

type TokenizerStream = abstract member Run: TokReq -> TokRes * TokenizerStream

let tokenizer =
    let rec loop (lines, errors, blocks) = {new TokenizerStream with
        member t.Run req =
            let replace edit =
                let lines, errors = Tokenize.replace lines errors edit
                let blocks = block_separate lines blocks edit
                lines, errors, blocks

            let next (_,errors,blocks as x) = {blocks=blocks; errors=errors}, loop x
            match req with
            | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=Utils.lines text|} |> next
            | DocumentEdit edit -> replace edit |> next
            }
    loop (PersistentVector.singleton PersistentVector.empty,[],[])

let parse is_top_down (s : (LineTokens * ParsedBlock) list) (x : Block list) =
    let dict = Dictionary(HashIdentity.Reference)
    List.iter (fun (a,b) -> dict.Add(a,b.parsed)) s
    List.map (fun x -> x.block, {
        parsed = Utils.memoize dict (block_init is_top_down) x.block
        offset = x.offset
        }) x

type ParserRes = {lines : LineTokens; bundles : Bundle list; parser_errors : RString list; tokenizer_errors : RString list}
type ParserStream = abstract member Run : TokRes -> ParserRes Promise * ParserStream
let parser is_top_down =
    let run s req =
        let s = promise_thunk <| fun () -> parse is_top_down s req.blocks
        let a = s >>-* fun s ->
            let lines, bundles, parser_errors = block_bundle s
            {lines = lines; bundles = bundles; parser_errors = parser_errors; tokenizer_errors = req.errors}
        a, s
    let rec loop s =
        {new ParserStream with
            member t.Run(req) =
                let s = s()
                let a,s' = run s req
                a, loop (fun () -> if Promise.Now.isFulfilled s' then Promise.Now.get s' else s)
                }
    loop (fun () -> [])

let cons_fulfilled l = 
    let rec loop olds = function
        | Cons(old,next) when Promise.Now.isFulfilled next -> loop (PersistentVector.conj old olds) (Promise.Now.get next)
        | _ -> olds
    loop PersistentVector.empty l
type TypecheckerStream = abstract member Run : ParserRes Promise -> InferResult Stream * TypecheckerStream
let typechecker package_id module_id top_env =
    let rec run old_results env i (bs : Bundle list) = 
        match bs with
        | b :: bs ->
            match PersistentVector.tryNth i old_results with
            | Some (b', _, env as s) when b = b' -> Cons(s,Promise(run old_results env (i+1) bs))
            | _ ->
                let x = Infer.infer package_id module_id env (bundle_top b)
                let _,_,env as s = b,x,Infer.union x.top_env_additions env
                Cons(s,promise_thunk (fun () -> run old_results env (i+1) bs))
        | [] -> Nil
    let rec loop old_results =
        {new TypecheckerStream with
            member _.Run(res) =
                let r = 
                    top_env >>=* fun top_env ->
                    res >>= fun res ->
                    // Doing the memoization like this has the disadvantage of always focing the evaluation of the previous 
                    // streams' first item, but on the plus side will reuse old state.
                    old_results >>- fun old_results ->
                    run (cons_fulfilled old_results) top_env 0 res.bundles
                let a = Stream.mapFun (fun (_,x,_) -> x) r
                a, loop r
            }
    loop Stream.nil

type MultiFileInState = {
    module_id : int
    top_env : TopEnv Promise
    }
type MultiFileOutState = {
    module_id : int
    top_env_additions : TopEnv Promise
    }
type DiffableFileHierarchy =
    | File of path: string * name: string * meta: MultiFileOutState option * ParserRes Promise * tc: TypecheckerStream option
    | Directory of name: string * DiffableFileHierarchy list

type MultiFileStream = 
    abstract member Run : DiffableFileHierarchy list -> Map<string,InferResult Stream> * TopEnv Promise * MultiFileStream

// Rather than just throwing away the old results, diff returns the new tree with as much useful info from the old tree as is possible.
let diff_order_changed old new' =
    let mutable same_files = true
    let mutable same_order = true
    let rec elem (o,n) = 
        match o,n with
        // In `n`, `meta` and `tc` fields are None.
        | File(path,name,meta,p,tc) & o,File(path',name',_,p',_) when path = path' && name = name' -> 
            if same_files && Object.ReferenceEquals(p,p') then o
            else same_files <- false; File(path,name,None,p',tc)
        | Directory(name,l), Directory(name',l') when name = name' -> Directory(name,list (l,l'))
        | _, n -> same_order <- false; n
    and list = function
        | o :: o', n :: n' -> elem (o,n) :: (if same_order then list (o', n') else n')
        | [], [] -> []
        | _, n -> same_order <- false; n
    list (old,new')

let union a b = a >>=* fun a -> b >>- fun b -> Infer.union a b
let multi_file package_id top_env =
    let rec create files' =
        let run files = 
            let mutable changed_files = Map.empty
            let rec changed (i : MultiFileInState) x =
                match x with
                | File(_,_,Some o,_,_) -> x, o
                | File(path,name,None,results_parser,tc) ->
                    let tc = match tc with Some tc -> tc | None -> typechecker package_id i.module_id i.top_env
                    let r,tc = tc.Run(results_parser)
                    changed_files <- Map.add path r changed_files
                    let top_env_additions = Stream.foldFromFun top_env_empty (fun a (b : InferResult) -> Infer.union a b.top_env_additions) r >>-* Infer.in_module name
                    let o = {module_id=i.module_id+1; top_env_additions=top_env_additions}
                    File(path,name,Some o,results_parser,Some tc),o
                | Directory(name,l) ->
                    let l,o = changed_list i l
                    let o : MultiFileOutState = {o with top_env_additions=o.top_env_additions >>-* Infer.in_module name}
                    Directory(name,l),o
            and changed_list i l =
                let o = {module_id=i.module_id; top_env_additions=Promise(top_env_empty)}
                let l,(_,o) =
                    List.mapFold (fun (top_env, o : MultiFileOutState) x ->
                        let i = {module_id=o.module_id; top_env=top_env}
                        let x,o' = changed i x
                        let top_env = union o'.top_env_additions top_env
                        let o = {o with top_env_additions=union o'.top_env_additions o.top_env_additions}
                        x,(top_env,o)
                        ) (i.top_env,o) l
                l,o
            let i = {module_id=0; top_env=top_env}
            let l,o = changed_list i files 
            changed_files, o.top_env_additions, create l
        {new MultiFileStream with member _.Run files = diff_order_changed files' files |> run}
    create []

type AddPackageInput = {links : Map<string,{|name : string|}>; files : DiffableFileHierarchy list}
type PackageCoreStream =
    abstract member ReplacePackages : (string * AddPackageInput) list * string Set -> Map<string,InferResult Stream> * PackageCoreStream

type PackageCoreStateItem = {
    links : Map<string,{|name : string|}>
    rev_links : string Set
    top_env_in : TopEnv Promise
    top_env_out : TopEnv Promise
    stream : MultiFileStream
    }

type PackageCoreState = {
    packages : Map<string,PackageCoreStateItem>
    package_ids : PersistentHashMap<string,int>
    }

let inline link_op f dir s k = 
    match Map.tryFind k s.packages with 
    | Some x -> {s with packages = Map.add k {x with rev_links = f dir x.rev_links} s.packages}
    | None -> s
/// Removes the current package from its parents' reverse links.
let links_rev_remove links dir s = links |> Map.fold (fun s k _ -> link_op Set.remove dir s k) s
/// Adds the current package to its parents' reverse links.
let links_rev_add links dir s = links |> Map.fold (fun s k _ -> link_op Set.add dir s k) s

let add_package (s : PackageCoreState, infer_results' : Map<string,InferResult Stream>, dirty_nodes : Set<string>) (dir, x : AddPackageInput) =
    let old_package = Map.tryFind dir s.packages
    let is_dirty = x.links |> Map.exists (fun k _ -> Set.contains k dirty_nodes)
    let top_env_in =
        let f() = 
            let l = x.links |> Map.fold (fun l k v -> (s.packages.[k].top_env_out >>-* in_module v.name) :: l) [] |> Job.conCollect
            l >>-* Seq.reduce Infer.union
        if is_dirty then f()
        else match old_package with Some x -> x.top_env_in | None -> f()
    
    let (infer_results, top_env_out, stream), package_ids =
        match old_package with
        | Some _ when is_dirty -> 
            let id, package_ids = s.package_ids.[dir], s.package_ids
            (multi_file id top_env_in).Run(x.files), package_ids
        | Some p -> p.stream.Run(x.files), s.package_ids
        | None -> 
            let id, package_ids = 
                if PersistentHashMap.containsKey dir s.package_ids then s.package_ids.[dir], s.package_ids
                else s.package_ids.Count, s.package_ids.Add(dir,s.package_ids.Count)
            (multi_file id top_env_in).Run(x.files), package_ids
    
    let s = // Remove the current package dir from the parents based on the old links.
        let old_links = match old_package with Some x -> x.links | None -> Map.empty
        links_rev_remove old_links dir s
        // Add the current package dir to the parents based on the new links.
        |> links_rev_add x.links dir
    
    let infer_results = Map.foldBack Map.add infer_results infer_results'

    let package = {
        links = x.links
        rev_links = match old_package with Some x -> x.rev_links | None -> Set.empty
        top_env_in = top_env_in
        top_env_out = top_env_out
        stream = stream
        }
    
    { packages = Map.add dir package s.packages; package_ids = package_ids }, infer_results, Set.add dir dirty_nodes

let remove_package (s : PackageCoreState) x =
    let package = s.packages.[x]
    let s = links_rev_remove package.links x s
    {s with packages = Map.remove x s.packages}

let package_core =
    let rec loop (s : PackageCoreState) =
        {new PackageCoreStream with
            member _.ReplacePackages(adds,removes) =
                let s,b,_ = List.fold add_package (s,Map.empty,Set.empty) adds
                b, loop (Set.fold remove_package s removes)
            }
    loop {packages=Map.empty; package_ids=PersistentHashMap.empty}

type PackageDiffStream =
    abstract member Run : string [] * PackageSchema ResultMap * MirroredGraph * Map<string,ParserRes Promise> -> Map<string, InferResult Stream> * PackageDiffStream

type PackageDiffState = { changes : string Set; errors : string Set; core : PackageCoreStream }
let get_adds_and_removes (schema : PackageSchema ResultMap) ((abs,bas) : MirroredGraph) (parsers : Map<string,ParserRes Promise>) (changes : string Set) =
    let sort_order, _ = topological_sort bas changes
    Seq.foldBack (fun dir (adds,removes) ->
        match Map.tryFind dir schema with
        | Some(Ok p) ->
            let names = p.schema.schema.packages // TODO: Extend the parser for packages and separate out the names and locations.
            let links = p.schema.packages
            let files =
                let rec elem = function
                    | ValidatedFileHierarchy.File(a,b) -> File(a,b,None,parsers.[a],None)
                    | ValidatedFileHierarchy.Directory(a,b) -> Directory(a,list b)
                and list l = List.map elem l
                list p.schema.files
            (dir,{links=Map(List.map2 (fun (_,a) (_,b) -> a, {|name=b|}) links names); files=files}) :: adds, removes
        | _ -> adds, Set.add dir removes
        ) sort_order ([], Set.empty)

let package_diff =
    let rec loop (s : PackageDiffState) =
        {new PackageDiffStream with
            member _.Run(order,schemas,graph,parsers) =
                let changes = Array.foldBack Set.add order s.changes
                let errors = 
                    Array.fold (fun s x ->
                        let has_error =
                            match Map.tryFind x schemas with
                            | Some(Ok x) -> (List.isEmpty x.package_errors && List.isEmpty x.schema.errors) = false
                            | _ -> false
                        if has_error then Set.add x s else Set.remove x s
                        ) s.errors order
                if Set.isEmpty errors && Set.isEmpty changes = false then 
                    let adds,removes = get_adds_and_removes schemas graph parsers changes
                    let x,core = s.core.ReplacePackages(adds,removes)
                    x,loop {changes=Set.empty; errors=errors; core=core}
                else Map.empty, loop {s with changes=changes; errors=errors}
            }
    loop {changes=Set.empty; errors=Set.empty; core=package_core}

type FileState = {
    tokenizer : TokenizerStream
    parser : ParserStream
    typechecker : TypecheckerStream
    cancellation_start : unit IVar
    cancellation_done : unit Promise
    }

let token_range (r_par : ParserRes) ((a,b) : VSCRange) =
    let from, near_to = min (r_par.lines.Length-1) a.line, min r_par.lines.Length (b.line+1)
    vscode_tokens from near_to r_par.lines

let handle_token_range r_par canc req =
    r_par >>= fun (r_par : ParserRes) ->
    let rec loop () = canc <|> (req ^=> fun (r,res) -> IVar.fill res (token_range r_par r) >>= loop)
    loop()

let hover (l : Infer.InferResult PersistentVector) (pos : VSCPos) =
    l |> PersistentVector.tryFindBack (fun x -> x.offset <= pos.line)
    |> Option.bind (fun x ->
         x.hovers |> Array.tryPick (fun ((a,b),r) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            ))

let handle_hover_at r_typ canc req =
    r_typ >>= fun r_typ ->
    // TODO: It might be better if the hover handler tugged on the stream rather than just sampling it like now.
    let rec loop () = canc <|> (req ^=> fun (pos,res) -> IVar.fill res (hover (cons_fulfilled r_typ) pos) >>= loop) 
    loop ()

let handle_typ uri type_errors r_typ canc =
    let rec loop ers = function
        | Nil -> Alt.unit()
        | Cons(a : Infer.InferResult,next) ->
            canc <|> (Alt.unit() ^=> fun () ->
                let errors = List.append a.errors ers
                Src.value type_errors {|uri=uri; errors=errors|} >>=.
                next >>= loop errors
                )
    r_typ >>= loop []

let file_server tokenizer_errors parser_errors type_errors (uri : string) req req_token_range req_hover_at =
    let cancel (s : FileState) = IVar.fill s.cancellation_start () >>=. s.cancellation_done
    let loop s =
        req >>= fun x ->
        let rec try_more x = Ch.Try.take req >>= function
            | Some x -> try_more (s.tokenizer.Run(x))
            | None -> Job.result x
        try_more (s.tokenizer.Run(x)) >>= fun (r_tok,tok) ->
        cancel s >>= fun () ->
        let r_par,par = s.parser.Run(r_tok)
        let r_typ,typ = s.typechecker.Run(r_par)
        let canc = IVar()
        Promise.start (Job.conIgnore [ 
            Src.value tokenizer_errors {|uri=uri; errors=r_tok.errors|}
            r_par >>= fun r_par -> Src.value parser_errors {|uri=uri; errors=r_par.parser_errors|}
            handle_token_range r_par canc req_token_range
            handle_typ uri type_errors r_typ canc
            handle_hover_at r_typ canc req_hover_at
            ]) >>- fun canc_done ->
        { tokenizer=tok; parser=par; typechecker=typ; cancellation_start=canc; cancellation_done=canc_done }
    Job.iterateServer {
        tokenizer=tokenizer
        parser=parser (System.IO.Path.GetExtension(uri) = ".spi")
        typechecker=typechecker 0 0 (Promise(Infer.top_env_default))
        cancellation_start=IVar()
        cancellation_done=Promise(())
        } loop
    
type AllFileReq =
    | FileOpen of {|uri : string; spiText : string|}
    | FileChanged of {|uri : string; spiEdit : SpiEdit|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * VSCTokenArray IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar

let all_file_server tokenizer_errors parser_errors type_errors req =
    let dict = Dictionary()
    let file_server' uri =
        match dict.TryGetValue(uri) with
        | true, v -> false, v
        | false, _ ->
            let x = {|req=Ch(); req_token_range=Ch(); req_hover_at=Ch()|}
            Hopac.start (file_server tokenizer_errors parser_errors type_errors uri x.req x.req_token_range x.req_hover_at)
            dict.[uri] <- x
            true, x
    let file_server uri = file_server' uri |> snd
    let loop = req >>= function
        | FileOpen x ->
            let is_new, s = file_server' x.uri
            if is_new then s.req *<+ DocumentAll(x.spiText)
            else Job.unit()
        | FileChanged x ->
            let s = file_server x.uri
            s.req *<+ DocumentEdit(x.spiEdit)
        | FileTokenRange(x, res) ->
            let s = file_server x.uri
            s.req_token_range *<+ (x.range, res)
        | HoverAt(x,res) -> 
            let s = file_server x.uri
            s.req_hover_at *<+ (x.pos, res)
    Job.forever loop

type PackageSupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileDelete of {|uri : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let supervisor_server fatal_errors package_errors req =
    let m = ref {schemas=Map.empty; links=mirrored_graph_empty; loads=Map.empty}
    let change is_open dir text = change is_open !m dir text >>= fun (ers,m') -> m := m'; Array.iterJob (Src.value package_errors) ers

    let loop = req >>= function
        | ProjectFileOpen x -> change true (dir x.uri) (Some x.spiprojText)
        | ProjectFileChange x -> change false (dir x.uri) (Some x.spiprojText)
        | ProjectFileDelete x -> change false (dir x.uri) None
        | ProjectFileLinks(x,res) -> 
            match m.contents.schemas.[dir x.uri] with
            | Ok x -> IVar.fill res (List.append x.schema.links x.package_links)
            | Error _ -> IVar.fill res []
        | ProjectCodeActions(x,res) ->
            match m.contents.schemas.[dir x.uri] with
            | Ok x -> IVar.fill res x.schema.actions
            | Error _ -> IVar.fill res []
        | ProjectCodeActionExecute x -> 
            match code_action_execute x.action with
            | Some er -> Src.value fatal_errors er
            | None -> Job.unit()

    Job.foreverServer loop
       
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
    | PackageErrors of {|uri : string; errors : RString list|}
    | TokenizerErrors of {|uri : string; errors : RString list|}
    | ParserErrors of {|uri : string; errors : RString list|}
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

    let consumed_source msg =
        let x = Src.create()
        Src.tap x |> Stream.consumeFun (msg >> queue_client.Enqueue)
        x
    let fatal_errors = consumed_source FatalError
    let package_errors = consumed_source PackageErrors
    let tokenizer_errors = consumed_source TokenizerErrors
    let parser_errors = consumed_source ParserErrors
    let type_errors = consumed_source TypeErrors
    let file = Ch()
    Hopac.start (all_file_server tokenizer_errors parser_errors type_errors file)
    let supervisor = Ch()
    Hopac.start (supervisor_server fatal_errors package_errors supervisor)

    let buffer = Dictionary()
    let last_id = ref 0
    use __ = server.ReceiveReady.Subscribe(fun s ->
        let rec loop () = Utils.remove buffer !last_id (body(NetMQMessage 3)) id
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
            let job_null job = Hopac.start job; send_back null
            let job_val job = let res = IVar() in Hopac.start (job res >>=. IVar.read res >>- send_back_via_queue)
            match x with
            | ProjectFileOpen x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileOpen x)
            | ProjectFileChange x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileChange x)
            | ProjectFileDelete x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectFileDelete x)
            | ProjectCodeActionExecute x -> job_null (supervisor *<+ PackageSupervisorReq.ProjectCodeActionExecute x)
            | ProjectFileLinks x -> job_val (fun res -> supervisor *<+ PackageSupervisorReq.ProjectFileLinks(x,res))
            | ProjectCodeActions x -> job_val (fun res -> supervisor *<+ PackageSupervisorReq.ProjectCodeActions(x,res))
            | FileOpen x -> job_null (file *<+ AllFileReq.FileOpen x)
            | FileChanged x -> job_null (file *<+ AllFileReq.FileChanged x)
            | FileTokenRange x -> job_val (fun res -> file *<+ AllFileReq.FileTokenRange(x,res))
            | HoverAt x -> job_val (fun res -> file *<+ AllFileReq.HoverAt(x,res))
            | BuildFile x -> // TODO: This case is just a stump for now.
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