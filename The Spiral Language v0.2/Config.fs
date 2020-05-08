// Everything that deals with Spiral project files themselves goes here
module Config

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

let column (p : CharStream<_>) = p.Column

let is_big_var_char_starting c = isAsciiUpper c
let is_var_char c = isAsciiLetter c || c = '_' || c = ''' || isDigit c

let file_hierarchy p =
    let s = HashSet(HashIdentity.Structural)

    let rec file_hierarchy_list p =
        let i = column p
        let expr p = if i <= column p then file_or_directory p else Reply(ReplyStatus.Error,expected "file or directory on the same indentation")
        between (skipChar '[' >>. spaces) (skipChar ']' >>. spaces) (many expr) p

    and file_or_directory p =
        pipe2 
            (many1Satisfy2L is_big_var_char_starting is_var_char "uppercase file" >>= fun x p ->
                if s.Add x then Reply(x) else Reply(ReplyStatus.Error, messageError <| sprintf "The module %s has already been declared." x)
                )
            (opt (skipChar ':' >>. spaces >>. file_hierarchy_list))
            (fun name -> function
                | Some files -> Directory(name,files)
                | None -> File name
                ) p

    file_hierarchy_list p

