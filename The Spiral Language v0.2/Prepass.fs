module Spiral.Prepass

type VarTag = int
type FreeVars = VarTag []
type StackSize = int
type KeywordTag = int

type ExprData = {free_vars_type : int []; free_vars_value : int []; stack_size_type : StackSize; stack_size_value : StackSize}

type [<ReferenceEquality>] Expr =
    | B
    | V of VarTag
    | Value of Tokenize.Value
    | Inline of Expr * ExprData // Acts as a join point for the prepass specifically.
    | Type of TExpr * ExprData
    | Inl of Expr * ExprData
    | Forall of Expr * ExprData
    | KeywordCreate of KeywordTag * Expr []
    | RecordWith of Expr [] * RecordWithPattern []
    | Op of Parsing.Op * Expr []
    | TypedOp of ret_type: TExpr * Parsing.Op * Expr []
    | Typecase of TExpr * (TExpr * Expr) []
    | ModuleOpen of string * (string * string option) list option * on_succ: Expr
    | Let of bind: Expr * on_succ: Expr
    | RecBlock of Expr [] * on_succ: Expr
    | PairTest of bind: VarTag * on_succ: Expr * on_fail: Expr
    | KeywordTest of KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordTest of RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    | AnnotTest of do_boxing : bool * TExpr * bind: VarTag * on_succ: Expr * on_fail: Expr
    | ValueTest of Tokenize.Value * bind: VarTag * on_succ: Expr * on_fail: Expr
    | DefaultValueTest of string * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnionTest of name: KeywordTag * vars: int * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnitTest of bind: VarTag * on_succ: Expr * on_fail: Expr
    | Pos of Parsing.Pos<Expr>
and [<ReferenceEquality>] TExpr =
    | TVar of VarTag
    | TPair of TExpr * TExpr
    | TFun of TExpr * TExpr
    | TRecord of Map<string,TExpr>
    | TKeyword of KeywordTag * TExpr []
    | TApply of TExpr * TExpr
    | TInl of Parsing.RawTTExpr * TExpr
    | TUnit
    | TPrim of Parsing.PrimitiveType
    | TArray of TExpr
    | TPos of Parsing.Pos<TExpr>


//type [<ReferenceEquality>] Expr =
//    | V of VarTag
//    | Lit of Tokenize.Value
//    | Inline of Expr * FreeVars * StackSize
//    | Function of Expr * FreeVars * StackSize
//    | RecFunction of Expr * FreeVars * StackSize
//    | KeywordCreate of KeywordTag * Expr []
//    | Let of bind: Expr * on_succ: Expr
//    | Case of bind: Expr * on_succ: Expr
//    | ListTakeAllTest of StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
//    | ListTakeNTest of StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
//    | KeywordTest of KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
//    | RecordTest of RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
//    | RecordWith of Expr [] * RecordWithPattern []
//    | ExprPos of Parsing.Pos<Expr>
//    | Op of Parsing.Op * Expr []

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: VarTag
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of Parsing.VarString * var: VarTag * Expr // VarString here is for error messages in the partial evaluator.
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of Parsing.VarString * var: VarTag

let prepass () x = 
    