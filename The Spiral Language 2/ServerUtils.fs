module Spiral.ServerUtils
open System
open System.IO
open System.Collections.Generic

open VSCTypes
open Graph
open Spiral.SpiProj

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

type ProjectCodeAction = 
    | CreateFile of {|filePath : string|}
    | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
    | RenameFile of {|filePath : string; target : string|}
    | CreateDirectory of {|dirPath : string|}
    | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
    | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

let code_action_execute a =
    try match a with
        | CreateDirectory a -> Directory.CreateDirectory(a.dirPath) |> ignore; Ok null
        | DeleteDirectory a -> Directory.Delete(a.dirPath,true); Ok a.dirPath
        | RenameDirectory a ->
            if a.validate_as_file then
                match FParsec.CharParsers.run file_verify a.target with
                | FParsec.CharParsers.ParserResult.Success _ -> Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
                | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
            else
                Directory.Move(a.dirPath,Path.Combine(a.dirPath,"..",a.target)); Ok a.dirPath
        | CreateFile a ->
            if File.Exists(a.filePath) then Error "File already exists."
            else File.Create(a.filePath).Dispose(); Ok null
        | DeleteFile a -> File.Delete(a.filePath); Ok a.filePath
        | RenameFile a ->
            match FParsec.CharParsers.run file_verify a.target with
            | FParsec.CharParsers.ParserResult.Success _ -> File.Move(a.filePath,Path.Combine(a.filePath,"..",a.target+Path.GetExtension(a.filePath)),false); Ok a.filePath
            | FParsec.CharParsers.ParserResult.Failure(er,_,_) -> Error er
    with e -> Error e.Message

type RAction = VSCRange * ProjectCodeAction

open WDiff

type SchemaState = { schema : Schema; errors_modules : RString list; errors_packages : RString list}
type SchemaEnv = Map<string,SchemaState>
type ModuleEnv = Map<string,ModuleState>

let ss_validate_modules' (modules : ModuleEnv) (x : SchemaState) =
    let errors = ResizeArray()
    let rec loop = function
        | SpiProj.FileHierarchy.Directory(_,_,_,l) -> list l
        | SpiProj.FileHierarchy.File(_,(r,path),_) -> if Map.containsKey path modules = false then errors.Add(r,"Module not found.")
    and list l = List.iter loop l
    list x.schema.modules
    
    Seq.toList errors
let ss_validate_modules modules (x : SchemaState) = {x with errors_modules=ss_validate_modules' modules x}

let ss_has_error x = (List.isEmpty x.errors_modules && List.isEmpty x.errors_packages) = false
let ss_validate_packages (packages : SchemaEnv) (x : SchemaState) (order : string [], circulars : Dictionary<string,int>) =
    Array.fold (fun s path ->
        match Map.tryFind path s with
        | Some (x : SchemaState) -> 
            let c p = match circulars.TryGetValue(p) with true,b -> b | false,_ -> -1
            let is_circular x = x <> -1
            let are_in_same_strong_component a b = is_circular a && is_circular b && a = b
            let ers =
                let cpath = c path
                (x.schema.packages, []) ||> List.foldBack (fun {path=r,p} ers ->
                    let cp = c p
                    if are_in_same_strong_component cpath cp then (r,"Package is circular and loops through the current one.") :: ers
                    else
                        match Map.tryFind p s with
                        | Some s' when ss_has_error s' -> (r,"Package has an error.") :: ers
                        | Some _ -> ers
                        | None -> (r,"Package not found.") :: ers
                    ) 
            Map.add path {x with errors_packages=ers} s
        | _ -> s
        ) packages order