module Spiral.Prepass

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVars = unit
type Range = { uri : string; range : Config.VSCRange }

type Macro =
    | MacroText of Range * string
    | MacroTypeVar of Range * Id
    | MacroTermVar of Range * Id
type RecordWith =
    | RecordWithSymbol of (Range * string) * Expr
    | RecordWithSymbolModify of (Range * string) * Expr
    | RecordWithInjectVar of (Range * Id) * Expr
    | RecordWithInjectVarModify of (Range * Id) * Expr
and RecordWithout =
    | RecordWithoutSymbol of Range * string
    | RecordWithoutInjectVar of Range * Id
and PatRecordMember =
    | PatRecordMembersSymbol of (Range * string) * Id
    | PatRecordMembersInjectVar of (Range * Id) * Id
and Expr =
    | B of Range
    | V of Range * Id
    | Lit of Range * Tokenize.Literal
    | DefaultLit of Range * string * TExpr
    | SymbolCreate of Range * string
    | Type of Range * TExpr
    | Fun of Range * FreeVars * Id * Expr
    | Recursive of (Range * FreeVars * Id * Expr) ref
    | Forall of Range * FreeVars * Id * Expr
    | RecBlock of Range * ((Range * Id) * Expr) list * on_succ: Expr
    | RecordWith of Range * Expr list * RecordWith list * RecordWithout list
    | Op of Range * BlockParsing.Op * Expr list
    | JoinPoint of Range * FreeVars * Expr
    | Annot of Range * Expr * TExpr
    | Typecase of Range * TExpr * (TExpr * Expr) list
    | ModuleOpen of Range * (Range * Id) * (Range * string) list * on_succ: Expr
    
    | Macro of Range * Macro list
    | Inline of Range * FreeVars * Expr
    // Regular pattern matching
    | Let of Range * Id * Expr * Expr
    | PairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: Expr * on_fail: Expr
    | KeywordTest of Range * string * bind: Id * on_succ: Expr * on_fail: Expr
    | RecordTest of Range * PatRecordMember list * bind: Id * on_succ: Expr * on_fail: Expr
    | AnnotTest of Range * TExpr * bind: Id * on_succ: Expr * on_fail: Expr
    | LitTest of Range * Tokenize.Literal * bind: Id * on_succ: Expr * on_fail: Expr
    | UnitTest of Range * bind: Id * on_succ: Expr * on_fail: Expr
    | HigherOrderTest of Range * ho: Id * bind: Id * on_succ: Expr * on_fail: Expr
    // Typecase
    | TypeLet of Range * Id * Expr * Expr
    | TypePairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: Expr * on_fail: Expr
    | TypeFunTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: Expr * on_fail: Expr
    | TypeKeywordTest of Range * string * bind: Id * on_succ: Expr * on_fail: Expr
    | TypeRecordTest of Range * Map<string,Id> * bind: Id * on_succ: Expr * on_fail: Expr
    | TypeUnitTest of Range * bind: Id * on_succ: Expr * on_fail: Expr
    | TypeHigherOrderTest of Range * ho: Id * bind: Id * on_succ: Expr * on_fail: Expr
    | TypeHigherOrderDestruct of Range * pat: Id list * bind: Id * on_succ: Expr * on_fail: Expr
and TExpr =
    | B of Range
    | Var of Range * Id
    | Pair of Range * TExpr * TExpr
    | Arrow of Range * TExpr * TExpr
    | Record of Range * Map<string,TExpr>
    | Symbol of Range * string
    | Apply of Range * TExpr * TExpr
    | Prim of Range * Config.PrimitiveType
    | Term of Range * Expr
    | Macro of Range * Macro list
    | Fun of Range * FreeVars * Id * TExpr
    | HigherOrder of Range * Id

//type TopEnv = {
    
//    } 

let fill_and_rename top_env (expr : BlockParsing.RawExpr) =
    ()

