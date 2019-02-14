#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"

open FParsec
open FParsec.CharParsers

let skipChar x = skipChar x >>. spaces
let var_name = many1SatisfyL (fun x -> isAsciiLetter x || isDigit x || x = '_' || x = ''') "variable" .>> spaces
let let_ = skipString "let" >>. spaces >>. var_name .>> skipChar '=' .>> optional (skipString "//") .>> spaces .>> optional (skipChar '(')
let name = between (skipChar '"') (skipChar '"') var_name .>> spaces
let prerequisites = 
    skipChar ',' >>. between (skipChar '[') (skipChar ']') (sepBy var_name (skipChar ';'))
    |>> String.concat "; "
let description = skipChar ',' >>. between (skipChar '"') (skipChar '"') (manySatisfy (fun x -> x <> '"'))
let code = skipChar ',' >>. skipString "\"\"\"" >>. manyCharsTill anyChar (skipString "\"\"\"")
let parser =
    pipe5 let_ name prerequisites description code (
        sprintf "let %s: SpiralModule =\n    {\n    name=\"%s\"\n    prerequisites=[%s]\n    description=\"%s\"\n    code=\n    \"\"\"%s\"\"\"\n    }\n"
        )
let parser' = parser .>> spaces .>> skipChar ')' .>> skipString "|>" .>> spaces .>> skipString "module_"

let qwe = 
    """
let test1 = 
    "test1",[asd, wqe],"Does it run?",
    ""
inl a = 5
inl b = 10
a + b
    ""
    """

let file = @"C:\Users\Marko\Source\Repos\The Spiral Language\The Spiral Language\TextFile1.txt"
let out = @"C:\Users\Marko\Source\Repos\The Spiral Language\The Spiral Language\TextFile1'.txt"
match runParserOnFile (spaces >>. many (parser .>> spaces) .>> eof) () file System.Text.Encoding.Unicode with
| Success(x,_,_) -> 
    System.IO.File.WriteAllText(out,String.concat "\n" x)
| Failure(x,_,_) ->
    ()

