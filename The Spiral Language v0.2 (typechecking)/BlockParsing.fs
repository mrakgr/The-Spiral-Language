module Spiral.BlockParsing
open Spiral.ParserCombinators
open Spiral.Tokenize
type Range = {line : int; from : int; nearTo : int}
type Env = {
    tokens : (Range * SpiralToken) []
    comments : Tokenize.LineComment option []
    i : int ref
    semicolon_line : int
    symbol_line : int
    is_top_down : bool
    } with

    member d.Index with get() = d.i.contents and set(i) = d.i := i

type ParserErrors =
    | ExpectedKeyword of TokenKeyword
    | ExpectedOperator'
    | ExpectedOperator of string
    | ExpectedUnaryOperator'
    | ExpectedUnaryOperator of string
    | ExpectedSmallVar
    | ExpectedBigVar
    | ExpectedLit
    | ExpectedSymbolPaired
    | ExpectedSymbol
    | ExpectedBracket of Bracket * BracketState
    | ExpectedStatement
    | ExpectedKeywordPatternInObject
    | ExpectedEob
    | ExpectedFunction
    | ExpectedGlobalFunction
    | StatementLastInBlock
    | InvalidSemicolon
    | InbuiltOpNotFound of string
    | UnexpectedEob
    | TypeForallNotAllowedInTheRealSegment

let inline try_current_template (d : Env) on_succ on_fail =
    let i = d.Index
    if 0 <= i && i < d.tokens.Length then on_succ d.tokens.[i]
    else on_fail()

let inline try_current d f = try_current_template d f (fun () -> Error [])
let print_current d = try_current d (fun x -> printfn "%A" x; Ok()) // For parser debugging purposes.
let inline line_template d f = try_current_template d (fst >> f) (fun _ -> -1)
let col d = line_template d (fun r -> r.from)
let line d = line_template d (fun r -> r.line)
   
let skip' (d : Env) i = d.i := d.i.contents+i
let skip d = skip' d 1

let ok d (p, t) = Ok(t)

let peek_keyword d =
    try_current d <| function
        | p, TokKeyword(t') -> Ok(t')
        | _ -> Error []

let skip_keyword t d =
    try_current d <| function
        | p,TokKeyword t' when t = t' -> skip d; Ok()
        | p, _ -> Error [p, ExpectedKeyword t]

let read_unary_op d =
    try_current d <| function
        | p, TokUnaryOperator t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_op d =
    try_current d <| function
        | p, TokOperator t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedOperator']

let skip_op t d =
    try_current d <| function
        | p, TokOperator t' when t' = t -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedOperator t]

let skip_unary_op t d =
    try_current d <| function
        | p, TokUnaryOperator t' when t' = t -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedUnaryOperator t]

let read_small_var d =
    try_current d <| function
        | p, TokVar t' when System.Char.IsLower(t',0) -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_big_var d =
    try_current d <| function
        | p, TokVar t' when System.Char.IsUpper(t',0) -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedBigVar]

let read_value d =
    try_current d <| function
        | p, TokValue t' -> skip d; Ok(t')
        | p, _ -> Error [p, ExpectedLit]

let read_default_value d =
    try_current d <| function
        | p, TokDefaultValue t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedLit]

let read_symbol_paired d =
    try_current d <| function
        | p, TokSymbolPaired t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedSymbolPaired]

let read_keyword_symbol d =
    try_current d <| function
        | p, TokSymbol t' -> skip d; Ok(t')
        | p, _ -> Error [p, ExpectedSymbol]

let skip_brackets a b d =
    try_current d <| function
        | p, TokBracket(a',b') when a = a' && b = b' -> skip d; Ok()
        | p, _ -> Error [p, ExpectedBracket(a,b)]

type SymbolString = string
type VarString = string

type Literal = Tokenize.Literal

type Op =
    // Type
    | TypeAnnot
    | TypeToVar
    | Box

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice

    // Tuple
    | TupleCreate

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Braching
    | If
    | While

    // BinOps
    | Add
    | Sub
    | Mult 
    | Div 
    | Mod 
    | Pow
    | LTE
    | LT
    | EQ
    | NEQ
    | GT
    | GTE 
    | BoolAnd
    | BoolOr
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor
    | ShiftLeft
    | ShiftRight

    // Application related
    | Apply

    // Array
    | ArrayCreate
    | ArrayLength
    | ArrayIndex
    | ArrayIndexSet
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | LitIs
    | PrimIs
    | SymbolIs
    | EqType

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | NanIs

    // Infinity
    | Infinity

type PrimitiveType =
    | UInt8T
    | UInt16T
    | UInt32T
    | UInt64T
    | Int8T
    | Int16T
    | Int32T
    | Int64T
    | Float32T
    | Float64T
    | BoolT
    | StringT
    | CharT

type RawRecordTestPattern =
    | RawRecordTestSymbol of symbol: SymbolString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern =
    | RawRecordWithSymbol of SymbolString * RawExpr
    | RawRecordWithSymbolModify of SymbolString * RawExpr
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithInjectSymbolModify of SymbolString * RawExpr
    | RawRecordWithoutSymbol of SymbolString
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersSymbol of symbol: SymbolString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern

and Pattern =
    | PatB
    | PatE
    | PatVar of VarString
    | PatOperator of VarString // Isn't actually a pattern. Is just here to help the inl/let statement parser.
    | PatBox of Pattern
    | PatAnnot of Pattern * RawTExpr

    | PatPair of Pattern * Pattern
    | PatSymbol of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of SymbolString * Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatValue of Literal
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr
    | PatNominal of VarString * Pattern

and RawExpr =
    | RawB
    | RawV of VarString
    | RawLit of Literal
    | RawDefaultLit of string
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawType of RawTExpr
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawSymbolCreate of SymbolString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawJoinPoint of RawTExpr option * RawExpr
    | RawAnnot of RawTExpr * RawExpr
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of VarString list * on_succ: RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr
    | RawPairTest of var0: VarString * var1: VarString * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawSymbolTest of SymbolString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnnotTest of RawTExpr * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawValueTest of Literal * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawDefaultLitTest of string * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnionTest of name: SymbolString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawBTest of bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnd of RawExpr
and RawTExpr =
    | RawTVar of VarString
    | RawTPair of RawTExpr * RawTExpr
    | RawTFun of RawTExpr * RawTExpr

    | RawTRecord of Map<string,RawTExpr>
    | RawTSymbol of SymbolString * RawTExpr []
    | RawTApply of RawTExpr * RawTExpr
    | RawTForall of (VarString * RawKindExpr) * RawTExpr
    | RawTB
    | RawTPrim of PrimitiveType
    | RawTArray of RawTExpr
and RawKindExpr =
    | RawKindStar
    | RawKindFun of RawKindExpr * RawKindExpr

let rounds a d = (skip_brackets Round Open >>. a .>> skip_brackets Round Close) d
let curlies a d = (skip_brackets Curly Open >>. a .>> skip_brackets Curly Close) d
let squares a d = (skip_brackets Square Open >>. a .>> skip_brackets Square Close) d

let eof d = 
    let i = index d
    let len = d.tokens.Length
    if i = len then Ok() 
    elif 0 <= i && i < len then let r,_ = d.tokens.[i] in Error [{line=r.line; from=r.nearTo; nearTo=r.nearTo+1}, ExpectedEob]
    else failwith "Compiler error: The block parser's pointer is out of bounds in the eof parser."

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let comments line_near_to character (s : Env) = 
    let rec loop line d =
        if line < 0 then 
            match s.comments.[line] with
            | Some(r,text) when r.from = character -> loop (line-1) (text :: d)
            | _ -> d
        else d
    loop (line_near_to-1) []
    |> String.concat "\n"
    |> fun x -> x.TrimEnd()

let top_let s = failwith "TODO" s
let top_inl s = failwith "TODO" s

let top_statement s =
    let i = index s
    let inline (+) a b = alt i a b
    (top_let + top_inl) s