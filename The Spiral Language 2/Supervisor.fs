module Spiral.Supervisor

open VSCTypes
open Graph
open Spiral.ServerUtils

open System
open System.IO

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

let dir uri = FileInfo(Uri(uri).LocalPath).Directory.FullName
let file uri = FileInfo(Uri(uri).LocalPath).FullName
let supervisor_server (errors : SupervisorErrorSources) req =
    let loop (s : SupervisorState) = req >>- function
        | ProjectFileChange x | ProjectFileOpen x -> 
            let packages,dirty_packages,modules = loader_package s.packages s.modules (dir x.uri,Some x.spiprojText)
            let package_ids = package_ids_update packages s.package_ids dirty_packages
            let dirty_packages = revalidate_parents packages dirty_packages
            let graph = graph_update packages s.graph dirty_packages
            let order,socs = Graph.circular_nodes graph dirty_packages
            let packages = ss_validate packages modules (order,socs)
            let packages_infer = wdiff_projenvr_update_packages_tc (fst package_ids) packages modules s.packages_infer (dirty_packages, order)
            { packages = packages; modules = modules; packages_infer = packages_infer; packages_prepass = s.packages_prepass; graph = graph; package_ids = package_ids }
        | ProjectFileLinks(x,res) -> failwith ""
        | ProjectCodeActions(x,res) -> failwith ""
        | ProjectCodeActionExecute(x,res) -> failwith ""
        | FileOpen x -> failwith ""
        | FileChange x -> failwith ""
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
