#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"

open FParsec
open FParsec.CharParsers
open System

let skipChar x = skipChar x >>. spaces
let skipString' x = skipString x
let skipString x = skipString x >>. spaces
let rounds x = between (skipChar '(') (skipChar ')') x
let squares x = between (skipChar '[') (skipChar ']') x
let curlies x = between (skipChar '{') (skipChar '}') x
let generic_unary_string = 
    let x = "\""
    skipString' x >>. charsTillString x true Int32.MaxValue .>> spaces
let generic_triple_string = 
    let x = "\"\"\""
    skipString' x >>. charsTillString x true Int32.MaxValue .>> spaces
let var_name = many1SatisfyL (fun x -> isAsciiLetter x || isDigit x || x = '_' || x = ''') "variable" .>> spaces

let let_ = skipString "let" >>. var_name .>> skipString ": SpiralModule ="
let name = skipString "name=" >>. generic_unary_string
let prerequisites = skipString "prerequisites=" >>. squares (sepBy var_name (skipChar ';')) |>> String.concat "; "
let description = skipString "description=" >>. generic_unary_string
let code = skipString "code=" >>. generic_triple_string
let body = curlies (tuple4 name prerequisites description code)
let parser s =
    s |> pipe2 let_ body (fun name (name',prerequisites,description,code) ->
        sprintf "let %s: SpiralModule =\n    {\n    name=\"%s\"\n    prerequisites=[%s]\n    opens=[]\n    description=\"%s\"\n    code=\n    \"\"\"%s\"\"\"\n    }\n" name name' prerequisites description code
        )

let file = @"C:\Users\Marko\Source\Repos\The Spiral Language\The Spiral Language\TextFile1.txt"
let out = @"C:\Users\Marko\Source\Repos\The Spiral Language\The Spiral Language\TextFile1'.txt"
match runParserOnFile (spaces >>. many parser .>> eof) () file System.Text.Encoding.Unicode with
| Success(x,_,_) -> x
| Failure(x,_,_) -> [x]
|> fun x -> System.IO.File.WriteAllText(out,String.concat "\n" x)

