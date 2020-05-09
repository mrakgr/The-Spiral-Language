// Everything that deals with Spiral project files themselves goes here
module Spiral.Config
open System
open FParsec
open System.Collections.Generic

type FileHierarchy =
    | File of string
    | Directory of string * FileHierarchy list

type Schema = {
    default_name : string option
    files : FileHierarchy list
}

type Pos = int * int
type Range = Pos * Pos
exception DuplicateFiles of (string * Pos []) []
exception DuplicateRecordFields of (string * Pos []) []
exception MissingNecessaryRecordFields of string [] * Range
exception Tabs of Pos []

let raise_if_not_empty exn l = if Array.isEmpty l = false then raise (exn l)
let column (p : CharStream<_>) = p.Column
let pos (p : CharStream<_>) : Pos = int p.Line, int p.Column
let pos' p = Reply(pos p)

let is_big_var_char_starting c = isAsciiUpper c
let is_var_char c = isAsciiLetter c || c = '_' || c = ''' || isDigit c
let file = many1Satisfy2L is_big_var_char_starting is_var_char "uppercase file name"

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

type RecordFields<'a,'s> =
    | Necessary of Parser<'a,'s>
    | Optional of optional_value: 'a * Parser<'a,'s>

type Record<'a,'s> = Map<string,RecordFields<'a,'s>>

let record (schema: Record<_,_>) =
    let record_body p =
        let i = column p
        let indent expr p = if i = column p then expr p else Reply(ReplyStatus.Error,expected "record field on the same indentation as the first one")
        let parsers = 
            Map.toArray schema
            |> Array.map (fun (name,(Necessary field_parser | Optional(_,field_parser))) p -> 
                let pos = pos p
                indent (skipString name >>. spaces >>. skipChar '=' >>. spaces >>. field_parser |>> fun x -> name, pos, x) p
                )
        many (choice parsers) p
    pipe3
        (pos' .>> (skipChar '{' >>. spaces))
        record_body
        (skipChar '{' >>. pos' .>> spaces)
        (fun pos_start l pos_end ->
            let l = List.toArray l |> Array.groupBy (fun (x,_,_) -> x)
            let _ =
                l |> Array.choose (fun (k, v) -> if v.Length > 1 then Some (k, Array.map (fun (_,x,_) -> x) v) else None)
                |> raise_if_not_empty DuplicateRecordFields
            let l = l |> Array.map (fun (k, [|_,_,v|]) -> k, v) |> Map
            let _ =
                schema |> Map.toArray
                |> Array.choose (fun (k,v) -> match v with Necessary _ when Map.containsKey k l = false -> Some k | _ -> None)
                |> raise_if_not_empty (fun fields -> MissingNecessaryRecordFields(fields,(pos_start,pos_end)))
            schema |> Map.map (fun k -> function
                | Necessary _ -> l.[k]
                | Optional(d,_) -> Option.defaultValue d (Map.tryFind k l)
                ))
    .>> spaces

let config str =
    let _ = tab_positions str |> raise_if_not_empty Tabs
    let schema = Map [
        "default_name", Optional(None, file |>> Some)
        "files", Necessary file_hierarchy
        ]
