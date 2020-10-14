// Everything that deals with Spiral project files themselves goes here
module Spiral.Config
open System
open FParsec

type VSCPos = {line : int; character : int}
type VSCRange = VSCPos * VSCPos
type VSCError = string * VSCRange

type FileHierarchy =
    | File of VSCRange * string
    | Directory of (VSCRange * string) * FileHierarchy []
type ConfigResumableError =
    | DuplicateFiles of VSCRange [] []
    | DuplicateRecordFields of VSCRange [] []
    | MissingNecessaryRecordFields of string [] * VSCRange
    | DirectoryInvalid of string * VSCRange
    | MainMustBeLast of VSCRange
    | MainMustBeAFile of VSCRange
type ConfigFatalError =
    | Tabs of VSCRange []
    | ParserError of string * VSCRange
exception ConfigException of ConfigFatalError

let rec spaces_template s = (spaces >>. optional (followedByString "//" >>. skipRestOfLine true >>. spaces_template)) s
let spaces s = spaces_template s

let raise' x = raise (ConfigException x)
let raise_if_not_empty exn l = if Array.isEmpty l = false then raise' (exn l)
let add_to_exception_list' (p: CharStream<ResizeArray<ConfigResumableError>>) = p.State.UserState.Add
let add_to_exception_list (p: CharStream<ResizeArray<ConfigResumableError>>) exn l = if Array.isEmpty l = false then p.State.UserState.Add (exn l)
let column (p : CharStream<_>) = p.Column
let pos (p : CharStream<_>) : VSCPos = {line=int p.Line - 1; character=int p.Column - 1}
let pos' p = Reply(pos p)
let range f p = pipe3 pos' f pos' (fun a b c -> ((a, c) : VSCRange), b) p

let is_big_var_char_starting c = isAsciiUpper c
let is_var_char c = isAsciiLetter c || c = '_' || c = ''' || isDigit c
let file' p = many1Satisfy2L is_big_var_char_starting is_var_char "capitalized variable name" p
let file p = (file' .>> spaces) p

let file_hierarchy p =
    let rec file_hierarchy_list p =
        let i = column p
        let expr p = if i = column p then file_or_directory p else Reply(ReplyStatus.Error,expected "file or directory on the same or greater indentation as the first one")
        (many expr |>> fun l ->
            let l = l |> List.toArray
            let _ = 
                l |> Array.map (fun (File(a,b) | Directory((a,b),_)) -> b,a)
                |> Array.groupBy fst
                |> Array.choose (fun (a,b) -> if b.Length > 1 then Some (Array.map snd b) else None)
                |> add_to_exception_list p DuplicateFiles
            let _ =
                l |> Array.tryFindIndex (function (File(_,"Main")) -> true | _ -> false)
                |> Option.iter (fun i -> 
                    if i <> l.Length - 1 then 
                        let (File(r,_) | Directory((r,_),_)) = l.[i]
                        r |> MainMustBeLast |> add_to_exception_list' p
                        )
            l
            ) p

    and file_or_directory p =
        pipe2 (range file')
            (opt (skipChar '/' >>. spaces >>. file_hierarchy_list) .>> spaces)
            (fun (r,name) -> function
                | Some files -> 
                    if name = "Main" then MainMustBeAFile r |> add_to_exception_list' p 
                    Directory((r,name),files)
                | None -> File(r,name)
                ) p

    let rec flatten prefix = function
        | File(r,x) -> [|{|uri=IO.Path.Join(prefix, x); range=r|}|]
        | Directory((_,x),l) -> Array.collect (flatten (IO.Path.Join(prefix,x))) l

    (file_hierarchy_list |>> Array.collect (flatten "file://")) p

let tab_positions (str : string): VSCRange [] =
    let mutable line = -1
    Utils.lines str |> Array.choose (fun x -> 
        line <- line + 1
        let x = {line=line; character=x.IndexOf("\t")}
        if x.character <> -1 then Some(x,{x with character=x.character+1}) else None
        )

let record_reduce (field: Parser<'schema -> 'schema, _>) s =
    let record_body p =
        let i = column p
        let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
        many (indent field) p
    pipe3 pos' record_body pos' (fun pos_start l pos_end -> (pos_start, pos_end), List.fold (|>) s l)

let record_field (name, p) = 
    (skipString name >>. skipChar ':' >>. spaces >>. range p)
    |>> (fun (r,f) (s,l) -> f s, (r, name) :: l)

let record fields fields_necessary schema =
    let fields = choice (List.map record_field fields)
    record_reduce fields (schema, []) >>= fun (range,(schema,l)) p ->
        let l = List.toArray l
        let _ =
            let names = Array.map snd l
            Set fields_necessary - Set names
            |> Set.toArray
            |> add_to_exception_list p (fun fields -> MissingNecessaryRecordFields(fields,range))
        let _ =
            Array.groupBy snd l
            |> Array.choose (fun (k, v) -> if v.Length > 1 then Some (Array.map fst v) else None)
            |> add_to_exception_list p DuplicateRecordFields

        Reply(schema)

type PrimitiveType =
    | UInt8T
    | UInt16T
    | UInt32T
    | UInt64T
    | Int8T
    | Int16T
    | Int32T
    | Int64T
    | Float32T
    | Float64T
    | BoolT
    | StringT
    | CharT

let default_int = 
    [ "i8", Int8T; "i16", Int16T; "i32", Int32T; "i64", Int64T; "u8", UInt8T; "u16", UInt16T; "u32", UInt32T; "u64", UInt64T ] 
    |> List.map (fun (a,b) -> pstring a >>% b) |> choice
let default_float = [ "f32", Float32T; "f64", Float64T ] |> List.map (fun (a,b) -> pstring a >>% b) |> choice

type Schema = {
    dirSource : string
    dirOut : string
    name : string
    version : string
    files : {|uri : string; range : VSCRange|} []
    defaultInt : PrimitiveType
    defaultFloat : PrimitiveType
}

type ConfigError = ResumableError of ConfigResumableError [] | FatalError of ConfigFatalError

open System.IO
let config (uri : string) text =
    try 
        let project_directory = FileInfo(Uri(uri).LocalPath).Directory.FullName

        let _ = tab_positions text |> raise_if_not_empty Tabs

        let directory p = 
            (range (restOfLine true .>> spaces) |>> (fun (r,b) ->
                try DirectoryInfo(Path.Combine(project_directory,b)).FullName
                with e -> add_to_exception_list' p (DirectoryInvalid (e.Message, r)); ""
                )) p

        let fields = [
            "dirSource", directory |>> fun x s -> {s with dirSource=x}
            "dirOut", directory |>> fun x s -> {s with dirOut=x}
            "version", restOfLine true .>> spaces |>> fun x s -> {s with version=x.TrimEnd()}
            "name", file |>> fun x s -> {s with name=x}
            "files", file_hierarchy |>> fun x s -> {s with files=x}
            "defaultInt", default_int |>> fun x s -> {s with defaultInt=x}
            "defaultFloat", default_float |>> fun x s -> {s with defaultFloat=x}
            ]
        let necessary = ["name"; "files"]

        let schema: Schema = {
            dirSource=project_directory
            dirOut=project_directory
            name=""
            version=""
            files=[||]
            defaultInt=Int32T
            defaultFloat=Float64T
            }

        match runParserOnString (spaces >>. record fields necessary schema .>> eof) (ResizeArray()) "spiral.config" text with
        | Success(a,userstate,_) -> 
            if userstate.Count > 0 then userstate.ToArray() |> ResumableError |> Result.Error else Result.Ok a
        | Failure(messages,error,_) ->
            let x = {line=int error.Position.Line - 1; character=int error.Position.Column - 1}
            ParserError(messages, (x,{x with character=x.character+1})) |> FatalError |> Result.Error
    with 
        | :? ConfigException as e -> e.Data0 |> FatalError |> Result.Error

    |> Result.mapError (fun x ->
        let fatal_error = function
            | Tabs l -> l |> Array.map (fun x -> "Tab not allowed.", x)
            | ParserError(x,p) -> [|(Utils.lines x).[3..] |> String.concat "\n", p|]
        let inline duplicate er = Array.collect (fun l -> let er = er (Array.length l) in Array.map (fun x -> er, x) l)
        let resumable_error = function
            | DuplicateFiles l -> duplicate (sprintf "Duplicate name. Count: %i") l
            | DuplicateRecordFields l -> duplicate (sprintf "Duplicate record field. Count: %i") l
            | MissingNecessaryRecordFields (l,p) -> [|sprintf "Record is missing the fields: %s" (String.concat ", " l), p|]
            | DirectoryInvalid(x,p) -> [|x, p|]
            | MainMustBeLast p -> [|"The module Main must be the last one in the directory.", p|]
            | MainMustBeAFile p -> [|"The module Main must be a file.", p|]
        match x with
        | ResumableError x -> Array.collect resumable_error x
        | FatalError x -> fatal_error x
        )