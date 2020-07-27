module Spiral.BlockParsingError
open Spiral.Tokenize
open Spiral.BlockParsing

let show_parser_error = function
    | ExpectedKeyword x ->
        match x with
        | SpecIn -> "in"
        | SpecAnd -> "and"
        | SpecFun -> "fun"
        | SpecMatch -> "match"
        | SpecTypecase -> "typecase"
        | SpecFunction -> "function"
        | SpecWith -> "with"
        | SpecWithout -> "without"
        | SpecAs -> "as"
        | SpecWhen -> "when"
        | SpecInl -> "inl"
        | SpecLet -> "let"
        | SpecForall -> "forall"
        | SpecInm -> "inm"
        | SpecInb -> "inb"
        | SpecRec -> "rec"
        | SpecIf -> "if"
        | SpecThen -> "then"
        | SpecElif -> "elif"
        | SpecElse -> "else"
        | SpecJoin -> "join"
        | SpecType -> "type"
        | SpecNominal -> "nominal"
        | SpecReal -> "real"
        | SpecUnion -> "union"
        | SpecOpen -> "open"
        | SpecWildcard -> "_"
        | SpecInstance -> "instance"
        | SpecPrototype -> "prototype"
    | ExpectedParenthesis(Round,Open) -> "("
    | ExpectedParenthesis(Curly,Open) -> "{"
    | ExpectedParenthesis(Square,Open) -> "["
    | ExpectedParenthesis(Round,Close) -> ")"
    | ExpectedParenthesis(Curly,Close) -> "}"
    | ExpectedParenthesis(Square,Close) -> "]"
    | ExpectedOpenParenthesis -> "(, { or ["
    | ExpectedOperator' -> "operator"
    | ExpectedOperator x -> x
    | ExpectedUnaryOperator' -> "unary operator"
    | ExpectedUnaryOperator x -> x
    | ExpectedUnit -> "()"
    | ExpectedSmallVar -> "lowercase variable"
    | ExpectedBigVar -> "uppercase variable"
    | ExpectedVar -> "variable"
    | ExpectedLit -> "literal"
    | ExpectedSymbol -> "symbol"
    | ExpectedSymbolPaired -> "paired symbol"
    | ExpectedStatement -> "statement"
    | ExpectedFunctionAsBodyOfRecStatement -> "Rec statements should all return functions known at parse time."
    | ExpectedGlobalFunction -> "Global inl/let statements should all return functions known at parse time."
    | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp -> "Unexpected pattern."
    | ExpectedVarOrOpAsNameOfGlobalStatement -> "The first pattern of a global statement should either be a variable or compile down to it."
    | ExpectedVarOrOpAsNameOfRecStatement -> "The first pattern of a recursive statement should either be a variable or compile down to it."
    | MissingFunctionBody -> "Missing function body."
    | ExpectedExpression -> "A sequence of statements should end in an expression."
    | InbuiltOpNotFound -> "Not found among the inbuilt operations."
    | UnknownOperator -> "Operator does not have known precedence and associativity."
    | ForallNotAllowed -> "Forall not allowed here."
    | InvalidPattern DisjointOrPatternVar -> "Both branches of an or pattern have have the same variables. This one is disjoint."
    | InvalidPattern DuplicateVar -> "Duplicate pattern variable."
    | InvalidPattern ShadowedVar -> "Shadowed pattern variable."
    | MetavarNotAllowed -> "Metavariable is not allowed here."
    | SymbolPairedShouldStartWithUppercase -> "Paired symbol should start with uppercase here."
    | TermNotAllowed -> "The term is not allowed here."
    | TypecaseNotAllowed -> "Typecase is not allowed here."
    | UnexpectedAndInlRec -> "The first statement of a recursive block has to be marked as recursive."
    | ExpectedEob -> "Failed to parse this token."
    | UnexpectedEob -> "Unexpected end of block past this token."
    | ExpectedAtLeastOneToken -> "At least one (non-comment) token should be present in a block."
    | UnknownError -> "Compiler error: Parsing failed at this position with no error message and without consuming all the tokens in a block."
    | DuplicateRecordTypeVar -> "Duplicate record type variable."
    | DuplicateForallVar -> "Duplicate forall variable."
    | InvalidPattern DuplicateRecordSymbol
    | DuplicateTermRecordSymbol -> "Duplicate record symbol."
    | InvalidPattern DuplicateRecordInjection
    | DuplicateTermRecordInjection -> "Duplicate record injection."
    | DuplicateRecFunctionName -> "Shadowing of functions by the members of the same mutually recursive block is not allowed."
    
let show_block_parsing_error line (l : (Config.VSCRange * ParserErrors) list) =
    l |> List.groupBy fst
    |> List.map (fun ((a,b),v) -> 
        let k = {a with line=line+a.line}, {b with line=line+b.line}
        let v = List.toArray v |> Array.map (snd >> show_parser_error)
        Tokenize.process_error (k, v)
        )