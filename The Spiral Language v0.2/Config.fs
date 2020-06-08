// Everything that deals with Spiral project files themselves goes here
module Spiral.Config
open System
open FParsec

type FileHierarchy =
    | File of string
    | Directory of string * FileHierarchy []

type Pos = {Line : int; Column : int}
type Range = {Start : Pos; End: Pos}
type ConfigResumableError =
    | DuplicateFiles of (string * Pos []) []
    | DuplicateRecordFields of (string * Pos []) []
    | MissingNecessaryRecordFields of string [] * Range
    | DirectoryInvalid of string * Pos
    | MainMustBeLast of Pos
    | MainMustBeAFile of Pos
type ConfigFatalError =
    | Tabs of Pos []
    | ConfigCannotReadProjectFile of string
    | ConfigProjectDirectoryPathInvalid of string
    | ParserError of string * Pos
    | UnexpectedException of string
exception ConfigException of ConfigFatalError

let spaces = Tokenize.spaces

let raise' x = raise (ConfigException x)
let raise_if_not_empty exn l = if Array.isEmpty l = false then raise' (exn l)
let add_to_exception_list' (p: CharStream<ResizeArray<ConfigResumableError>>) = p.State.UserState.Add
let add_to_exception_list (p: CharStream<ResizeArray<ConfigResumableError>>) exn l = if Array.isEmpty l = false then p.State.UserState.Add (exn l)
let column (p : CharStream<_>) = p.Column
let pos (p : CharStream<_>) : Pos = {Line=int p.Line; Column=int p.Column}
let pos' p = Reply(pos p)

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
                l |> Array.map (fun (a,(File b | Directory(b,_))) -> b,a)
                |> Array.groupBy fst
                |> Array.choose (fun (a,b) -> if b.Length > 1 then Some (a, Array.map snd b) else None)
                |> add_to_exception_list p DuplicateFiles
            let _ =
                l |> Array.tryFindIndex (function (_, File "Main") -> true | _ -> false)
                |> Option.iter (fun i -> if i <> l.Length - 1 then fst l.[i] |> MainMustBeLast |> add_to_exception_list' p)

            Array.map snd l
            ) p

    and file_or_directory p =
        pipe3 pos' file'
            (opt (skipChar '/' >>. spaces >>. file_hierarchy_list) .>> spaces)
            (fun pos name -> function
                | Some files -> 
                    if name = "Main" then MainMustBeAFile pos |> add_to_exception_list' p 
                    pos, Directory(name,files)
                | None -> pos, File name
                ) p

    let rec flatten prefix = function
        | File x -> [|IO.Path.Join(prefix, x)|]
        | Directory(x,l) -> Array.collect (flatten (IO.Path.Join(prefix,x))) l

    (file_hierarchy_list |>> Array.collect (flatten "")) p

let tab_positions (str : string): Pos [] =
    Utils.lines str
    |> Array.mapi (fun line x -> {Line=line+1; Column=x.IndexOf("\t")+1})
    |> Array.filter (fun x -> x.Column <> 0)

let record_reduce (field: Parser<'schema -> 'schema, _>) s =
    let record_body p =
        let i = column p
        let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
        many (indent field) p
    pipe3 pos' record_body pos' (fun pos_start l pos_end -> {Start=pos_start; End=pos_end}, List.fold (|>) s l)

let record_field (name, p) = 
    pipe2 pos'
        (skipString name >>. skipChar ':' >>. spaces >>. p)
        (fun pos f (s,l) -> f s, (pos, name) :: l)

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
            |> Array.choose (fun (k, v) -> if v.Length > 1 then Some (k, Array.map fst v) else None)
            |> add_to_exception_list p DuplicateRecordFields

        Reply(schema)

type Schema = {
    dirSource : string
    dirOut : string
    name : string
    version : string
    files : string []
}

type ConfigError = ResumableError of ConfigResumableError [] | FatalError of ConfigFatalError

open System.IO
let config spiproj_dir spiproj_text =
    try 
        let project_directory =
            try DirectoryInfo(spiproj_dir).FullName
            with e -> raise' (ConfigProjectDirectoryPathInvalid e.Message)

        let _ = tab_positions spiproj_text |> raise_if_not_empty Tabs

        let directory p = 
            pipe2 pos' (restOfLine true .>> spaces) (fun pos b ->
                try DirectoryInfo(Path.Combine(project_directory,b)).FullName
                with e -> add_to_exception_list' p (DirectoryInvalid (e.Message, pos)); ""
                ) p

        let fields = [
            "dirSource", directory |>> fun x s -> {s with dirSource=x}
            "dirOut", directory |>> fun x s -> {s with dirOut=x}
            "version", restOfLine true .>> spaces |>> fun x s -> {s with version=x.TrimEnd()}
            "name", file |>> fun x s -> {s with name=x}
            "files", file_hierarchy |>> fun x s -> {s with files=x}
            ]
        let necessary = ["name"; "files"]

        let schema: Schema = {
            dirSource=project_directory
            dirOut=project_directory
            name=""
            version=""
            files=[||]
            }

        match runParserOnString (spaces >>. record fields necessary schema .>> eof) (ResizeArray()) "spiral.config" spiproj_text with
        | Success(a,userstate,_) -> 
            if userstate.Count > 0 then userstate.ToArray() |> ResumableError |> Result.Error else Result.Ok a
        | Failure(messages,error,_) ->
            ParserError(messages, {Line=int error.Position.Line; Column=int error.Position.Column}) |> FatalError |> Result.Error
    with 
        | :? ConfigException as e -> e.Data0 |> FatalError |> Result.Error
        | e -> e.Message |> UnexpectedException |> FatalError |> Result.Error
