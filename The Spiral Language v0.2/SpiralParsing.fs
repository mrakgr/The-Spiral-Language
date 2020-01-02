module Spiral.Parsing
open Spiral.Tokenize
open Spiral.ParserCombinators
open System
open System.Text

type Associativity = FParsec.Associativity

type VarString = string * PosKey
type KeywordString = string

type Pos<'a>(pos : PosKey, expr : 'a) =
    member _.Expression = expr
    member _.Pos = pos
    override _.ToString() = sprintf "%A" expr

type Op =
    // Type
    | TypeExpr

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice
    | StringFormat
    | StringConcat

    // Pair
    | PairCreate

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

    // Join points
    | JoinPointEntryMethod
    | JoinPointAnnotEntryMethod
    
    // Application related
    | Apply
    | TermCast // Term cast also places the closure join point directly.
    | TypeAnnot

    // Array
    | ArrayCreateDotNet
    | ReferenceCreate
    | ArrayLength

    // Getters
    | GetArray
    | GetReference

    // Setters
    | SetArray
    | SetReference
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | IsNan

    // Infinity
    | Infinity

type RawRecordTestPattern = 
    | RawRecordTestKeyword of keyword: KeywordString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern = 
    | RawRecordWithKeyword of KeywordString * RawExpr 
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithoutKeyword of KeywordString 
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersKeyword of keyword: KeywordString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern

and Pattern =
    | PatVar of VarString
    | PatVarBox of VarString
    | PatVarAnnot of VarString * RawTypeExpr
    | PatVarAnnotBox of VarString * RawTypeExpr
    | PatForallAnnot of VarString * RawTypeExpr

    | PatPair of Pattern * Pattern
    | PatKeyword of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatLit of Value
    | PatDefaultLit of string
    | PatWhen of Pattern * RawExpr
    | PatPos of Pos<Pattern>

and RawExpr =
    | RawB
    | RawV of VarString 
    | RawLit of Value
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawTypeInl of VarString * RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawCase of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) []
    | RawPairTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawPos of Pos<RawExpr>
    | RawPattern of (VarString * (Pattern * RawExpr) []) // These parenthesis are here so the pattern compilation can be memoized via reference identity.
and RawTypeExpr =
    | RawTPair of RawTypeExpr * RawTypeExpr
    | RawTFun of RawTypeExpr * RawTypeExpr
    | RawTConstraint of RawTypeExpr * RawTypeExpr
    | RawTDepConstraint of RawTypeExpr * string
    | RawTRecord of Map<string,RawTypeExpr>
    | RawTKeyword of string * RawTypeExpr []
    | RawTVar of string
    | RawTApply of RawTypeExpr * RawTypeExpr
    | RawTForall of RawTypeExpr [] * RawTypeExpr
    | RawTUnit
    | RawTPos of Pos<RawTypeExpr>

type ParserExpr =
    | ParserStatement of (RawExpr -> RawExpr)
    | ParserExpr of RawExpr

let v x = RawV x
let lit x = RawLit x
let inline_ = function RawInline _ as x -> x | x -> RawInline x
let inl x y = RawInl(y,x)
let keyword_ k l = RawKeywordCreate(k,l)
let keyword_unary_ k = RawKeywordCreate(k,[||])
let l bind body on_succ = RawLet(bind,body,on_succ)
let case bind body on_succ = RawCase(bind,body,on_succ)
let if_ cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
let pair_test x bind on_succ on_fail = RawPairTest(x,bind,on_succ,on_fail)
let keyword_test keyword x bind on_succ on_fail = RawKeywordTest(keyword,x,bind,on_succ,on_fail)
let record_test x bind on_succ on_fail = RawRecordTest(x,bind,on_succ,on_fail)
let record_with binds patterns = RawRecordWith(binds,patterns)
    
let op x args = RawOp(x,args)
//let vv x = op ListCreate x
let B = RawB
//let pattern arg clauses = RawPattern(arg,clauses)

let unop op' a = op op' [|a|]
let binop op' a b = op op' [|a;b|]
let eq x y = binop EQ x y
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l

// The seemingly useless function application is there to filter unused arguments from the environment and move the rest to `env_global`.
let join_point_entry_method y = inline_ (op JoinPointEntryMethod [|y|])

let inline expr_indent i op expr d = if op i (col d) then expr d else Error []

let semicolon (d: ParserEnv) = if d.Line <> d.semicolon_line then semicolon' d else d.FailWith(InvalidSemicolon) 

let exprpos expr d =
    let expr_pos pos x = RawPos(Pos(pos,x))
    let pos = pos' d
    (expr |>> function RawInline _ | RawRecBlock _ | RawInl _ | RawForall _ | RawTypeInl _ as x -> x | x -> expr_pos pos x) d
let patpos expr d =
    let pat_pos pos x = PatPos(Pos(pos,x))
    (expr |>> pat_pos (pos' d)) d

let inline concat_keyword'' x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun ((str : string, pos : PosKey as strpos), pat) -> 
            strb.Append(str).Append(':') |> ignore
            match pat with
            | None -> PatVar strpos
            | Some pat -> pat
            ) x
    strb.ToString(), pattern

let rec pair_from_end f = function [] -> failwith "impossible" | [x] -> x | x :: xs -> f (x,pair_from_end f xs)

let type_ (d : ParserEnv) =
    let unit_ = bracket_round_open >>. bracket_round_close >>. preturn RawTUnit
    let pairs next = sepBy1 next product |>> function [x] -> x | x -> pair_from_end RawTPair x
    let arr_funs next = sepBy1 next arr_fun |>> function [x] -> x | x -> pair_from_end RawTFun x
    let arr_cons next = sepBy1 next arr_fun |>> function [x] -> x | x -> List.rev x |> function x :: xs -> RawTConstraintSet(Set.ofList xs,x) | [] -> failwith "impossible"


    ()