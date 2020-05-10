// Everything that deals with Spiral project files themselves goes here
module Spiral.Config
open System
open FParsec

type FileHierarchy =
    | File of string
    | Directory of string * FileHierarchy list

type Pos = int * int
type Range = Pos * Pos
type ConfigResumableError =
    | DuplicateFiles of (string * Pos []) []
    | DuplicateRecordFields of (string * Pos []) []
    | MissingNecessaryRecordFields of string [] * Range
    | DirectoryInvalid of string * Pos
type ConfigFatalError =
    | Tabs of Pos []
    | ConfigCannotReadProjectFile of string
    | ConfigProjectDirectoryPathInvalid of string
    | ParserError of string * Pos

exception ConfigException of ConfigFatalError

let spaces = Tokenize.spaces

let raise' x = raise (ConfigException x)
let raise_if_not_empty exn l = if Array.isEmpty l = false then raise' (exn l)
let add_to_exception_list' (p: CharStream<ResizeArray<ConfigResumableError>>) = p.State.UserState.Add
let add_to_exception_list (p: CharStream<ResizeArray<ConfigResumableError>>) exn l = if Array.isEmpty l = false then p.State.UserState.Add (exn l)
let column (p : CharStream<_>) = p.Column
let pos (p : CharStream<_>) : Pos = int p.Line, int p.Column
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
            let _ = 
                l |> List.toArray
                |> Array.map (fun (a,(File b | Directory(b,_))) -> b,a)
                |> Array.groupBy fst
                |> Array.choose (fun (a,b) -> if b.Length > 1 then Some (a, Array.map snd b) else None)
                |> add_to_exception_list p DuplicateFiles

            List.map snd l
            ) p

    and file_or_directory p =
        pipe3 pos' file'
            (opt (skipChar '/' >>. spaces >>. file_hierarchy_list) .>> spaces)
            (fun pos name -> function
                | Some files -> pos, Directory(name,files)
                | None -> pos, File name
                ) p

    file_hierarchy_list p

let tab_positions (str : string): Pos [] =
    Utils.lines str
    |> Array.mapi (fun line x -> line+1, x.IndexOf("\t")+1)
    |> Array.filter (fun (_,col) -> col <> 0)

let record_reduce (field: Parser<'schema -> 'schema, _>) s =
    let record_body p =
        let i = column p
        let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
        many (indent field) p
    pipe3 pos' record_body pos' (fun pos_start l pos_end -> (pos_start, pos_end), List.fold (|>) s l)

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
    dir_source : IO.DirectoryInfo
    dir_out : IO.DirectoryInfo
    name : string
    version : string
    files : FileHierarchy list
}

open System.IO
let config project_directory =
    let project_directory =
        try DirectoryInfo(project_directory)
        with e -> raise' (ConfigProjectDirectoryPathInvalid e.Message)

    let config = 
        try File.ReadAllText(Path.Combine(project_directory.FullName,"package.spiproj"))
        with e -> raise' (ConfigCannotReadProjectFile e.Message)
    let _ = tab_positions config |> raise_if_not_empty Tabs

    let directory p = 
        pipe2 pos' (restOfLine true .>> spaces) (fun pos b ->
            try DirectoryInfo(Path.Combine(project_directory.FullName,b))
            with e -> add_to_exception_list' p (DirectoryInvalid (e.Message, pos)); null
            ) p

    let fields = [
        "dir_source", directory |>> fun x s -> {s with dir_source=x}
        "dir_out", directory |>> fun x s -> {s with dir_out=x}
        "version", restOfLine true .>> spaces |>> fun x s -> {s with version=x.TrimEnd()}
        "name", file |>> fun x s -> {s with name=x}
        "files", file_hierarchy |>> fun x s -> {s with files=x}
        ]
    let necessary = ["name"; "files"]

    let schema: Schema = {
        dir_source=project_directory
        dir_out=project_directory
        name=""
        version=""
        files=[]
        }

    match runParserOnString (spaces >>. record fields necessary schema .>> eof) (ResizeArray()) "spiral.config" config with
    | Success(a,userstate,_) -> 
        if userstate.Count > 0 then sprintf "Errors:%A" (userstate.ToArray()) else sprintf "%A" a
    | Failure(messages,b,c) ->
        let pos = int b.Position.Line, int b.Position.Column
        sprintf "%A" (ParserError(messages,pos))

let p = @"c:\Users\Marko\Source\Repos\The Spiral Language\VS Code Plugin\out" 
try printfn "%s" (config p) 
with :? ConfigException as e -> printfn "%A" e.Data0
