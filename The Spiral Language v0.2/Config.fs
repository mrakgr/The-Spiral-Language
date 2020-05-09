// Everything that deals with Spiral project files themselves goes here
module Spiral.Config
open System
open FParsec

type FileHierarchy =
    | File of string
    | Directory of string * FileHierarchy list

type Pos = int * int
type Range = Pos * Pos
type ConfigError =
    | DuplicateFiles of (string * Pos []) []
    | DuplicateRecordFields of (string * Pos []) []
    | MissingNecessaryRecordFields of string [] * Range
    | Tabs of Pos []
    | DirectoryInvalid of string * Pos
exception ConfigException of ConfigError

let raise x = raise (ConfigException x)
let raise_if_not_empty exn l = if Array.isEmpty l = false then raise (exn l)
let column (p : CharStream<_>) = p.Column
let pos (p : CharStream<_>) : Pos = int p.Line, int p.Column
let pos' p = Reply(pos p)

let is_big_var_char_starting c = isAsciiUpper c
let is_var_char c = isAsciiLetter c || c = '_' || c = ''' || isDigit c
let file p = many1Satisfy2L is_big_var_char_starting is_var_char "uppercase file name" p

let file_hierarchy p =
    let rec file_hierarchy_list p =
        let i = column p
        let expr p = if i <= column p then file_or_directory p else Reply(ReplyStatus.Error,expected "file or directory on the same or greater indentation as the first one")
        between (skipChar '[' >>. spaces) (skipChar ']') (many expr |>> fun l ->
            let _ = 
                l |> List.toArray
                |> Array.map (fun (a,(File b | Directory(b,_))) -> b,a)
                |> Array.groupBy fst
                |> Array.choose (fun (a,b) -> if b.Length > 1 then Some (a, Array.map snd b) else None)
                |> raise_if_not_empty DuplicateFiles

            List.map snd l
            ) p

    and file_or_directory p =
        pipe3 pos' file
            (opt (skipChar ':' >>. spaces >>. file_hierarchy_list) .>> spaces)
            (fun pos name -> function
                | Some files -> pos, Directory(name,files)
                | None -> pos, File name
                ) p

    file_hierarchy_list p

let tab_positions (str : string): Pos [] =
    Utils.lines str
    |> Array.mapi (fun line x -> line+1, x.IndexOf("\t")+1)
    |> Array.filter (fun (_,col) -> col <> 0)

let directory p = 
    pipe2 pos' (restOfLine true .>> spaces) (fun pos b ->
        let r x = raise (DirectoryInvalid (x, pos))
        try IO.DirectoryInfo(b)
        with 
            | :? Security.SecurityException -> r "The caller does not have the required permission to access this directory."
            | :? ArgumentException -> r "The path contains invalid characters such as \", <, >, or |."
            | :? IO.PathTooLongException -> r "The specified path, file name, or both exceed the system-defined maximum length.") p

let record_reduce (field: Parser<'schema -> 'schema, _>) s =
    let record_body p =
        let i = column p
        let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
        chainl (indent field) (preturn (>>)) id p
    pipe3
        (pos' .>> (skipChar '{' >>. spaces))
        record_body
        (skipChar '{' >>. pos' .>> spaces)
        (fun pos_start l pos_end -> (pos_start, pos_end), l s)

let record_field (name, p) = 
    pipe2 pos'
        (skipString name >>. spaces >>. skipChar '=' >>. spaces >>. p)
        (fun pos f (s,l) -> f s, (pos, name) :: l)

let record fields fields_necessary schema =
    let fields = choice (List.map record_field fields)
    record_reduce fields (schema, []) |>> fun (range,(schema,l)) ->
        let l = List.toArray l
        let _ =
            let names = Array.map snd l
            Set fields_necessary - Set names
            |> Set.toArray
            |> raise_if_not_empty (fun fields -> MissingNecessaryRecordFields(fields,range))
        let _ =
            Array.groupBy snd l
            |> Array.choose (fun (k, v) -> if v.Length > 1 then Some (k, Array.map fst v) else None)
            |> raise_if_not_empty DuplicateRecordFields

        schema

type Schema = {
    dir_source : IO.DirectoryInfo
    dir_out : IO.DirectoryInfo
    name : string
    version : string
    files : FileHierarchy list
}

let config str =
    let _ = tab_positions str |> raise_if_not_empty Tabs

    let fields = [
        "dir_source", directory |>> fun x s -> {s with dir_source=x}
        "dir_out", directory |>> fun x s -> {s with dir_out=x}
        "version", restOfLine true .>> spaces |>> fun x s -> {s with version=x.TrimEnd()}
        "name", file |>> fun x s -> {s with name=x}
        "files", file_hierarchy |>> fun x s -> {s with files=x}
        ]
    let necessary = ["name"; "files"]
    if Set.isSubset (Set(necessary)) (Set(List.map fst fields)) = false then failwith "Compiler error: necessary <: fields = false"

    let schema: Schema = {
        dir_source=IO.DirectoryInfo("")
        dir_out=IO.DirectoryInfo("")
        name=""
        version=""
        files=[]
        }

    record fields necessary schema
