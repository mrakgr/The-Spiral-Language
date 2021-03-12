module Spiral.Supervisor

open VSCTypes
open Graph
open Spiral.ServerUtils

open System
open System.IO
open System.Collections.Generic

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type LocalizedErrors = {|uri : string; errors : RString list|}
type TracedError = {|trace : string list; message : string|}
type SupervisorErrorSources = {
    fatal : string Src
    tokenizer : LocalizedErrors Src
    parser : LocalizedErrors Src
    typer : LocalizedErrors Src
    package : LocalizedErrors Src
    traced : TracedError Src
    }

type SupervisorReq =
    | ProjectFileOpen of {|uri : string; spiprojText : string|}
    | ProjectFileChange of {|uri : string; spiprojText : string|}
    | ProjectFileLinks of {|uri : string|} * RString list IVar
    | ProjectCodeActions of {|uri : string|} * RAction list IVar
    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|} * {|result : string option|} IVar
    | FileOpen of {|uri : string; spiText : string|}
    | FileChange of {|uri : string; spiEdit : SpiEdit|}
    | FileDelete of {|uris : string []|}
    | FileTokenRange of {|uri : string; range : VSCRange|} * int [] IVar
    | HoverAt of {|uri : string; pos : VSCPos|} * string option IVar
    | BuildFile of {|uri : string; backend : string|}

type SupervisorState = {
    packages : SchemaEnv
    modules : ModuleEnv
    packages_infer : ResultMap<PackageId,WDiff.ProjStateTC>
    packages_prepass : ResultMap<PackageId,WDiff.Prepass.ProjStatePrepass>
    graph : MirroredGraph
    package_ids : Map<string,int> * Map<int,string>
    }

let proj_validate s dirty_packages =
    let order,socs = Graph.circular_nodes s.graph dirty_packages
    let packages = ss_validate s.packages s.modules (order,socs)
    let packages_infer = wdiff_projenvr_tc (fst s.package_ids) packages s.modules s.packages_infer (dirty_packages, order)
    {s with packages_infer = packages_infer}

let proj_graph_update s dirty_packages =
    let package_ids = package_ids_update s.packages s.package_ids dirty_packages
    let graph = graph_update s.packages s.graph dirty_packages
    proj_validate {s with graph = graph; package_ids = package_ids} dirty_packages

let proj_open s (dir, text) =
    let packages,dirty_packages,modules = loader_package s.packages s.modules (dir,text)
    proj_graph_update {s with packages = packages; modules = modules} dirty_packages

let proj_revalidate_owner s file =
    let rec loop (x : DirectoryInfo) =
        if x = null then s
        elif Map.containsKey x.FullName s.packages then proj_validate s (HashSet([x.FullName]))
        elif File.Exists(Path.Combine(x.FullName,"package.spiproj")) then proj_open s (x.FullName,None)
        else loop x.Parent
    loop (Directory.GetParent(file))

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let supervisor_server (errors : SupervisorErrorSources) req =
    let loop (s : SupervisorState) = req >>- function
        | ProjectFileChange x | ProjectFileOpen x -> proj_open s (dir x.uri,Some x.spiprojText)
        | ProjectFileLinks(x,res) -> failwith ""
        | ProjectCodeActions(x,res) -> failwith ""
        | ProjectCodeActionExecute(x,res) -> failwith ""
        | FileOpen x -> 
            let file = file x.uri
            match Map.tryFind file s.modules with
            | Some m -> WDiff.wdiff_module_all m x.spiText
            | None -> WDiff.wdiff_module_init_all (is_top_down file) x.spiText
            |> fun v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file
        | FileChange x ->
            let file = file x.uri
            match Map.tryFind file s.modules with
            | None -> Hopac.start (Src.value errors.fatal "It is not possible to apply a change to a file that is not present in the environment. Try reopening it in the editor."); s
            | Some m -> 
                match WDiff.wdiff_module_edit m x.spiEdit with
                | Ok v -> proj_revalidate_owner {s with modules = Map.add file v s.modules} file
                | Error er -> Hopac.start (Src.value errors.fatal er); s
        | FileDelete x -> failwith ""
        | FileTokenRange(x, res) -> failwith ""
        | HoverAt(x,res) -> failwith ""
        | BuildFile x -> failwith ""

    Job.iterateServer {
        packages = Map.empty
        modules = Map.empty
        packages_infer = {ok=Map.empty; error=Map.empty}
        packages_prepass = {ok=Map.empty; error=Map.empty}
        graph = mirrored_graph_empty
        package_ids = Map.empty, Map.empty
        } loop
