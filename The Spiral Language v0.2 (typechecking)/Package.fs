module Spiral.Package

//open System
//open System.IO
//open System.Collections.Generic
//open FSharpx.Collections

//open Spiral.Config

//open Hopac
//open Hopac.Infixes
//open Hopac.Extensions
//open Hopac.Stream

//type ProjectCodeAction = 
//    | CreateFile of {|filePath : string|}
//    | DeleteFile of {|range: VSCRange; filePath : string|} // The range here includes the postfix operators.
//    | RenameFile of {|filePath : string; target : string|}
//    | CreateDirectory of {|dirPath : string|}
//    | DeleteDirectory of {|range: VSCRange; dirPath : string|} // The range here is for the whole tree, not just the code action activation.
//    | RenameDirectory of {|dirPath : string; target : string; validate_as_file : bool|}

//type ClientReq =
//    | ProjectFileOpen of {|uri : string; spiprojText : string|}
//    | ProjectFileChange of {|uri : string; spiprojText : string|}
//    | ProjectFileDelete of {|uri : string|}
//    | ProjectFileLinks of {|uri : string|}
//    | ProjectCodeActionExecute of {|uri : string; action : ProjectCodeAction|}
//    | ProjectCodeActions of {|uri : string|}

//type PackageId = int

//let package (req : ClientReq Stream) =
//    let package_id = Dictionary<string,PackageId>()
//    let package_id' = ResizeArray<string>()


