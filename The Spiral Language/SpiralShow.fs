module Spiral.Show
open Spiral.Types
open System.Collections.Generic
open System
open System.Runtime.CompilerServices
open System.Text

// Globals
let private keyword_to_string_dict = Dictionary(HashIdentity.Structural)
let private string_to_keyword_dict = Dictionary(HashIdentity.Structural)
let private string_to_op_dict = Dictionary(HashIdentity.Structural)
let private code_dict = ConditionalWeakTable()
let mutable private tag_keyword = 0

let _ =
    Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    |> Array.iter (fun x ->
        string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
let string_to_op x = string_to_op_dict.TryGetValue x

let string_to_keyword (x: string) =
    match string_to_keyword_dict.TryGetValue x with
    | true, v -> v
    | false, _ ->
        tag_keyword <- tag_keyword + 1
        string_to_keyword_dict.[x] <- tag_keyword
        keyword_to_string_dict.[tag_keyword] <- x
        tag_keyword
let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.

let keyword_name = string_to_keyword "name"

let show_primt = function
    | UInt8T -> "uint8"
    | UInt16T -> "uint16"
    | UInt32T -> "uint32"
    | UInt64T -> "uint64"
    | Int8T -> "int8"
    | Int16T -> "int16"
    | Int32T -> "int32"
    | Int64T -> "int64"
    | Float32T -> "float32"
    | Float64T -> "float64"
    | BoolT -> "bool"
    | StringT -> "string"
    | CharT -> "char"

let show_value = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

let show_art = function
    | ArtDotNetHeap -> "array"
    | ArtDotNetReference -> "ref"
    | ArtCudaGlobal _ -> "array_cuda_global"
    | ArtCudaShared -> "array_cuda_shared"
    | ArtCudaLocal -> "array_cuda_local"

let show_layout_type = function
    | LayoutStack -> "layout_stack"
    | LayoutHeap -> "layout_heap"
    | LayoutHeapMutable -> "layout_heap_mutable"

let inline show_keyword show (keyword,l: _[]) =
    if l.Length > 0 then
        let a = (keyword_to_string keyword).Split([|':'|], StringSplitOptions.RemoveEmptyEntries)
        Array.map2 (fun a l -> String.concat "" [|a;":(";show l;")"|]) a l
        |> String.concat " "
    else
        keyword_to_string keyword

let inline show_map show v = 
    let body = 
        Map.toArray v
        |> Array.map (fun (k,v) -> sprintf "%s=%s" (keyword_to_string k) (show v))
        |> String.concat "; "

    sprintf "{%s}" body

let inline show_list show l = sprintf "(%s)" (List.map show l |> String.concat ", ")

let (|P|) = function ExprPos(_,x) -> x.Expression | x -> x
let object_name (x: ObjectDict) = 
    match x.TryGetValue keyword_name with
    | true, (P(KeywordTest(_,_,_,P(Lit(_,LitString x)),_)),_) -> x
    | _ -> "<object>"

let rec show_ty = function
    | PrimT x -> show_primt x
    | KeywordT(C(keyword,l)) -> show_keyword show_ty (keyword,l)
    | ListT l -> show_list show_ty l.node
    | MapT v -> show_map show_ty v.node
    | ObjectT(C(a,_)) -> object_name a
    | FunctionT _ | RecFunctionT _ -> "<function>"
    | LayoutT (C(layout_type,body,_)) -> sprintf "%s (%s)" (show_layout_type layout_type) (show_consed_typed_data body)
    | TermCastedFunctionT (a,b) -> sprintf "(%s => %s)" (show_ty a) (show_ty b)
    | UnionT l ->
        let body =
            Set.toArray l.node
            |> Array.map show_ty
            |> String.concat " | "
        sprintf "union (%s)" body
    | RecUnionT (name, _, _) -> name
    | ArrayT (a,b) -> sprintf "%s (%s)" (show_art a) (show_ty b)
    | MacroT x -> show_consed_typed_data x |> sprintf "macro (%s)"

and show_typed_data = function
    | TyT x -> sprintf "type (%s)" (show_ty x)
    | TyV(T(_,t)) -> sprintf "var (%s)" (show_ty t)
    | TyKeyword(keyword,l) -> show_keyword show_typed_data (keyword,l)
    | TyList l -> show_list show_typed_data l
    | TyMap a -> show_map show_typed_data a
    | TyObject(a,_) -> object_name a
    | TyFunction _ | TyRecFunction _ -> "<function>"
    | TyBox(a,b) -> sprintf "(%s : %s)" (show_typed_data a) (show_ty b)
    | TyLit v -> sprintf "lit %s" (show_value v)

and show_consed_typed_data = function
    | CTyT x -> sprintf "type (%s)" (show_ty x)
    | CTyV(_,t) -> sprintf "var (%s)" (show_ty t)
    | CTyKeyword(C(keyword,l)) -> show_keyword show_consed_typed_data (keyword,l)
    | CTyList l -> show_list show_consed_typed_data l.node
    | CTyMap a -> show_map show_consed_typed_data a.node
    | CTyObject(C(a,_)) -> object_name a
    | CTyFunction _ | CTyRecFunction _ -> "<function>"
    | CTyBox(a,b) -> sprintf "(%s : %s)" (show_consed_typed_data a) (show_ty b)
    | CTyLit v -> sprintf "lit %s" (show_value v)

let show_position' (strb: StringBuilder) ({name=name; code=code},line,col) =
    let er_code =
        code
        |> memoize' code_dict (fun file_code -> file_code.Split([|"\r\n";"\r";"\n"|],System.StringSplitOptions.None))
        |> fun x -> x.[int line - 1]

    strb
        .AppendLine(sprintf "Error trace on line: %i, column: %i in module %s." line col name)
        .AppendLine(er_code)
        .Append(' ', col - 1)
        .AppendLine "^"
    |> ignore

let show_position x = show_position' (StringBuilder()) x

let show_trace (settings: SpiralCompilerSettings) (trace: Types.Trace) message = 
    let filter_set = HashSet(settings.filter_list,HashIdentity.Structural)
    
    let error = System.Text.StringBuilder(1024)
    let x =
        List.toArray trace
        |> Array.filter (fun ({name=x},_,_) -> filter_set.Contains x = false)
    if x.Length > 0 then
        x.[0..(min x.Length settings.trace_length - 1 |> max 0)]
        |> Array.rev
        |> Array.iter (show_position' error)
    error.AppendLine message |> ignore
    error.ToString()

open Spiral.Tokenize
open Spiral.ParserCombinators

let show_parser_error = function
    | ExpectedSpecial x ->
        match x with
        | SpecMatch -> "match"
        | SpecFunction -> "function"
        | SpecWith -> "with"
        | SpecWithout -> "without"
        | SpecAs -> "as"
        | SpecWhen -> "when"
        | SpecInl -> "inl"
        | SpecInm -> "inm"
        | SpecInb -> "inb"
        | SpecRec -> "rec"
        | SpecIf -> "if"
        | SpecThen -> "then"
        | SpecElif -> "elif"
        | SpecElse -> "else"
        | SpecJoin -> "join"
        | SpecType -> "type"
        | SpecTypeCatch -> "type_catch"
        | SpecWildcard -> "_"
        | SpecLambda -> "->"
        | SpecOr -> "|"
        | SpecAnd -> "&"
        | SpecTypeUnion -> "\/"
        | SpecColon -> ":"
        | SpecDot -> "."
        | SpecComma -> ","
        | SpecSemicolon -> ";"
        | SpecUnaryOne -> "!"
        | SpecUnaryTwo -> "@"
        | SpecUnaryThree -> "#"
        | SpecUnaryFour -> "$"
        | SpecBracketRoundOpen -> "("
        | SpecBracketCurlyOpen -> "{"
        | SpecBracketSquareOpen -> "["
        | SpecBracketRoundClose -> ")"
        | SpecBracketCurlyClose -> "}"
        | SpecBracketSquareClose -> "]"
        | SpecCuda -> "cuda"
    | ExpectedOperator' -> "operator"
    | ExpectedOperator x -> x
    | ExpectedVar -> "variable"
    | ExpectedLit -> "literal"
    | ExpectedKeyword -> "keyword"
    | ExpectedKeywordUnary -> "unary keyword"
    | ExpectedStatement -> "statement"
    | ExpectedKeywordPatternInObject -> "keyword pattern"
    | ExpectedEof -> "end of file"
    | ExpectedRecursiveFunction -> "recursive function"
    | StatementLastInBlock -> "A block requires an expression in last position."
    | InvalidSemicolon -> "Invalid syntax."
    | InbuiltOpNotFound x -> sprintf "`%s` not found among the inbuilt ops." x
    | UnexpectedEof -> "Unexpected end of file."
    
let is_expected = function
    | StatementLastInBlock | InvalidSemicolon | UnexpectedEof
    | InbuiltOpNotFound _ -> false
    | _ -> true

let show_parser_error_list x = 
    let expected, errors = List.partition (snd >> is_expected) x
    let expected = 
        List.map (snd >> show_parser_error) expected
        |> String.concat ", "
        |> function
            | "" as x -> x
            | x -> sprintf "Expected one of: %s\n" x
    let errors = 
        List.map (snd >> show_parser_error) errors
        |> String.concat "\n"
        |> function
            | "" as x -> x
            | x -> sprintf "Parser errors:\n%s\n" x
    expected + errors
