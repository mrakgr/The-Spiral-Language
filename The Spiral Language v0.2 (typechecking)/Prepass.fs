module Spiral.Prepass

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVars = unit
type Range = { uri : string; range : Config.VSCRange }

type TT = Type | Fun of TT * TT
type TypeVar = Id * TT

type Macro =
    | MText of Range * string
    | MTypeVar of Range * Id
    | MTermVar of Range * Id
type RecordWith =
    | RSymbol of (Range * string) * E
    | RSymbolModify of (Range * string) * E
    | RVar of (Range * Id) * E
    | RVarModify of (Range * Id) * E
and RecordWithout =
    | WSymbol of Range * string
    | WVar of Range * Id
and PatRecordMember =
    | Symbol of (Range * string) * Id
    | Var of (Range * Id) * Id
and E =
    | EB of Range
    | EV of Range * Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * T
    | ESymbolCreate of Range * string
    | EType of Range * T
    | EFun of Range * FreeVars * Id * E * T
    | ERecursive of E ref
    | EForall of Range * FreeVars * TypeVar * E
    | ERecBlock of Range * ((Range * Id) * E) list * on_succ: E
    | ERecordWith of Range * E list * RecordWith list * RecordWithout list
    | EOp of Range * BlockParsing.Op * E list
    | EJoinPoint of Range * E
    | EAnnot of Range * E * T
    | ETypecase of Range * T * (T * E) list
    | EModuleOpen of Range * (Range * Id) * (Range * string) list * on_succ: E
    | EMacro of Range * Macro list
    | EInline of Range * FreeVars * E
    // Regular pattern matching
    | ELet of Range * Id * E * E
    | EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | EKeywordTest of Range * string * bind: Id * on_succ: E * on_fail: E
    | ERecordTest of Range * PatRecordMember list * bind: Id * on_succ: E * on_fail: E
    | EAnnotTest of Range * T * bind: Id * on_succ: E * on_fail: E
    | ELitTest of Range * Tokenize.Literal * bind: Id * on_succ: E * on_fail: E
    | EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
    | EHigherOrderTest of Range * ho: Id * bind: Id * on_succ: E * on_fail: E
    // Typecase
    | ETypeLet of Range * Id * E * E
    | ETypePairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeFunTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeKeywordTest of Range * string * bind: Id * on_succ: E * on_fail: E
    | ETypeRecordTest of Range * Map<string,Id> * bind: Id * on_succ: E * on_fail: E
    | ETypeUnitTest of Range * bind: Id * on_succ: E * on_fail: E
    | ETypeHigherOrderTest of Range * ho: Id * bind: Id * on_succ: E * on_fail: E
    | ETypeHigherOrderDestruct of Range * pat: Id list * bind: Id * on_succ: E * on_fail: E
and T =
    | TUnit of Range
    | TVar of Range * Id
    | TPair of Range * T * T
    | TArrow of Range * T * T
    | TRecord of Range * Map<string,T>
    | TSymbol of Range * string
    | TApply of Range * T * T
    | TPrim of Range * Config.PrimitiveType
    | TTerm of Range * E
    | TMacro of Range * Macro list
    | TFun of Range * FreeVars * TypeVar * T
    | THigherOrder of Range * TypeVar

open FSharpx.Collections

type HigherOrderCases =
    | Union of name: string * TypeVar list * Map<string,T>
    | Nominal of name: string * TypeVar list * T

type TopEnv = {
    prototypes : Map<int,{|prefix : TT list; body : E|}> PersistentVector
    hoc : HigherOrderCases PersistentVector
    tern : Map<string,E>
    ty : Map<string,T>
    }

open BlockParsing
open TypecheckingUtils
let prepass (top_env : TopEnv) expr =
    match expr with
    | BundleType(r,a,b,c) -> ()
        