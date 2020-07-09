module Spiral.BlockParsing
open Spiral.ParserCombinators

type Env = {
    l : Tokenize.LineToken [] []
    row : int ref
    col : int ref
    semicolon_line : int
    keyword_line : int
    is_top_down : bool
    } with

    member t.Index with get() = t.row.contents, t.col.contents and set(row,col) = t.row := row; t.col := col

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
    | PatUnit
    | PatE
    | PatVar of VarString
    | PatOperator of VarString // Isn't actually a pattern. Is just here to help the inl/let statement parser.
    | PatBox of Pattern
    | PatAnnot of Pattern * RawTExpr

    | PatPair of Pattern * Pattern
    | PatKeyword of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of KeywordString * Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatValue of Literal
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr

and RawExpr =
    | RawB
    | RawV of VarString
    | RawLit of Literal
    | RawDefaultLit of string
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawType of RawTExpr
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Pos * Op * RawExpr []
    //| RawTypedOp of ret_type: RawTExpr * Op * RawExpr []
    | RawJoinPoint of RawTExpr option * RawExpr
    | RawAnnot of RawTExpr * RawExpr
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of string * (OpenKind * string option) list option * on_succ: RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr
    | RawPairTest of var0: VarString * var1: VarString * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawAnnotTest of do_boxing : bool * RawTExpr * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawValueTest of Literal * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawDefaultLitTest of string * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnionTest of name: KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawUnitTest of bind: VarString * on_succ: RawExpr * on_fail: RawExpr
and RawTExpr =
    | RawTVar of VarString
    | RawTPair of RawTExpr * RawTExpr
    | RawTFun of RawTExpr * RawTExpr
    | RawTConstraint of RawTExpr * RawTExpr
    | RawTDepConstraint of RawTExpr * RawTExpr
    | RawTRecord of Map<string,RawTExpr>
    | RawTKeyword of KeywordString * RawTExpr []
    | RawTApply of RawTExpr * RawTExpr
    | RawTForall of (VarString * RawKindExpr) * RawTExpr
    | RawTUnit
    | RawTPrim of PrimitiveType
    | RawTArray of RawTExpr
and RawKindExpr =
    | RawKindStar
    | RawKindFun of RawKindExpr * RawKindExpr

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let top_let s = failwith "TODO" s
let top_inl s = failwith "TODO" s
let top_nominal s = failwith "TODO" s
let top_proto s = failwith "TODO" s
let top_union s = failwith "TODO" s
let comments s = failwith "TODO" s

let top_statement s =
    let i = index s
    let inline (+) a b = alt i a b
    comments (top_let + top_inl + top_nominal + top_proto + top_union) s