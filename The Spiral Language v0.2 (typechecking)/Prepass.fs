module Spiral.Prepass

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVars = unit
//type Range = { uri : string; range : Config.VSCRange }
type Range = BlockParsing.Range

type TT = Type | Fun of TT * TT
type TypeVar = Id * TT

type Macro =
    | MText of Range * string
    | MType of T
    | MTerm of E
and TypeMacro =
    | TMText of Range * string
    | TMType of T
and RecordWith =
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
    | EApply of Range * E * E
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
    | TFun of Range * T * T
    | TRecord of Range * Map<string,T>
    | TSymbol of Range * string
    | TApply of Range * T * T
    | TPrim of Range * Config.PrimitiveType
    | TTerm of Range * E
    | TMacro of Range * TypeMacro list
    | TArrow of Range * FreeVars * TypeVar * T
    | THigherOrder of Range * TypeVar

open FSharpx.Collections

type HigherOrderCases =
    | Union of name: string * TypeVar list * Map<string,T>
    | Nominal of name: string * TypeVar list * T

open BlockParsing
open TypecheckingUtils
type TopEnv = {
    prototypes : Map<int,{|prefix : TT list; body : E|}> PersistentVector
    hoc : HigherOrderCases PersistentVector
    term : Map<string,E>
    ty : Map<string,T>
    }

type Env = {
    term : PersistentHashMap<string,E>
    ty : PersistentHashMap<string,T>
    }

type PrepassError =
    | RecordIndexFailed of string

exception PrepassException of (Range * PrepassError) list

let compile_pattern _ = failwith "TODO"
let compile_typecase _ = failwith "TODO"

let prepass (top_env : TopEnv) expr =
    let v_term env x = if PersistentHashMap.containsKey x env.term then env.term.[x] else top_env.term.[x]
    let v_ty env x = if PersistentHashMap.containsKey x env.ty then env.ty.[x] else top_env.ty.[x]
    let rec ty (env : Env) x =
        let f = ty env
        match x with
        | RawTWildcard _ -> failwith "Compiler error: Annotation with wildcards should have been stripped."
        | RawTMetaVar _ -> failwith "Compiler error: This should have been compiled away in typecase."
        | RawTForall _ -> failwith "Compiler error: Foralls are not allowed at the type level."
        | RawTB r -> TUnit r
        | RawTVar(r,a) -> v_ty env a
        | RawTPair(r,a,b) -> TPair(r,f a,f b)
        | RawTFun(r,a,b) -> TFun(r,f a,f b)
        | RawTRecord(r,l) -> TRecord(r,Map.map (fun _ -> f) l)
        | RawTSymbol(r,a) -> TSymbol(r,a)
        | RawTApply(r,a,b) ->
            match f a, f b with
            | TRecord(_,a), TSymbol(_,b) ->
                match Map.tryFind b a with
                | Some x -> x
                | None -> raise (PrepassException [r,RecordIndexFailed b])
            | a,b -> TApply(r,a,b)
        | RawTPrim(r,a) -> TPrim(r,a)
        | RawTTerm(r,a) -> TTerm(r,term env a)
        | RawTMacro(r,l) -> 
            let f = function 
                | RawMacroText(r,a) -> TMText(r,a)
                | RawMacroTypeVar(r,a) -> TMType(v_ty env a)
                | RawMacroTermVar _ -> failwith "Compiler error: Term vars should not appear on the type level."
            TMacro(r,List.map f l)
    and term env x =
        let f = term env
        match x with
        | RawB r -> EB r
        | RawV(r,a) -> v_term env a
        | RawBigV(r,a) -> EApply(r,v_term env a,EB r)
        | RawLit(r,a) -> ELit(r,a)
        | RawDefaultLit(r,a) -> failwith "TODO"
        | RawSymbolCreate(r,a) -> ESymbolCreate(r,a)
        | RawType(r,a) -> EType(r,ty env a)
        | RawMatch(r,a,b) -> compile_pattern (Some a) b
        | RawFun(r,a) -> compile_pattern None a
        | RawForall(r,a,b) -> failwith "TODO"
        //| RawRecBlock of Range * ((Range * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
        //| RawRecordWith of Range * RawExpr list * RawRecordWith list * RawRecordWithout list
        //| RawOp of Range * Op * RawExpr list
        //| RawJoinPoint of Range * RawExpr
        //| RawAnnot of Range * RawExpr * RawTExpr
        //| RawTypecase of Range * RawTExpr * (RawTExpr * RawExpr) list
        //| RawModuleOpen of Range * (Range * VarString) * (Range * SymbolString) list * on_succ: RawExpr
        //| RawApply of Range * RawExpr * RawExpr
        //| RawIfThenElse of Range * RawExpr * RawExpr * RawExpr
        //| RawIfThen of Range * RawExpr * RawExpr
        //| RawPairCreate of Range * RawExpr * RawExpr
        //| RawSeq of Range * RawExpr * RawExpr
        //| RawHeapMutableSet of Range * RawExpr * RawExpr
        //| RawReal of Range * RawExpr
        //| RawMacro of Range * RawMacro list
        //| RawMissingBody of Range
        //| RawInline of Range * RawExpr // Acts like a join point during the prepass.

    ()
    //match expr with
    //| BundleType(r,a,b,c) -> ()
        