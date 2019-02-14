#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsecCs.dll"
#r @"..\packages\FParsec.1.0.3\lib\net40-client\FParsec.dll"

open FParsec
open FParsec.CharParsers

let skipChar x = skipChar x >>. spaces
let var_name = many1SatisfyL (fun x -> isAsciiLetter x || isDigit x || x = '_') "variable" .>> spaces
let let_ = skipString "let" >>. spaces >>. var_name .>> skipChar '='
let name = between (skipChar '"') (skipChar '"') var_name .>> spaces
let prerequisites = 
    skipChar ',' >>. between (skipChar '[') (skipChar ']') (sepBy var_name (skipChar ','))
    |>> String.concat ", "
let description = skipChar ',' >>. between (skipChar '"') (skipChar '"') (manySatisfy (fun x -> x <> '"'))
let code = skipChar ',' >>. skipString "\"\"" >>. manyCharsTill anyChar (skipString "\"\"")
let parser =
    pipe5 let_ name prerequisites description code (
        sprintf "let %s: SpiralModule =\n    {\n    name=\"%s\"\n    prerequisites=[%s]\n    description=\"%s\"\n    code=\n    \"\"\"%s\"\"\"\n    }\n"
        )


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

run (spaces >>. parser) qwe