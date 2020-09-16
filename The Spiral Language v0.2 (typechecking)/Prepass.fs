module Spiral.Prepass

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVars = unit
//type Range = { uri : string; range : Config.VSCRange }
type Range = BlockParsing.Range

type TT = Type | Fun of TT * TT
type TypeVar = Id * TT

type Macro =
    | MText of string
    | MType of T
    | MTerm of E
and TypeMacro =
    | TMText of string
    | TMType of T
and RecordWith =
    | RSymbol of (Range * string) * E
    | RSymbolModify of (Range * string) * E
    | RVar of (Range * E) * E
    | RVarModify of (Range * E) * E
and RecordWithout =
    | WSymbol of Range * string
    | WVar of Range * E
and PatRecordMember =
    | Symbol of (Range * string) * Id
    | Var of (Range * Id) * Id
and E =
    | EB of Range
    | EV of Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * T
    | ESymbolCreate of Range * string
    | EType of Range * T
    | EApply of Range * E * E
    | EFun of Range * FreeVars * Id * E * T
    | ERecursive of E ref
    | EForall of Range * FreeVars * TypeVar * E
    | ERecBlock of Range * (Id * E) list * on_succ: E
    | ERecordWith of Range * E list * RecordWith list * RecordWithout list
    | ERecord of Map<string, E> // Used for modules.
    | EOp of Range * BlockParsing.Op * E list
    | EJoinPoint of Range * E
    | EAnnot of Range * E * T
    | ETypecase of Range * T * (T * E) list
    | EModuleOpen of Range * (Range * Id) * (Range * string) list * on_succ: E
    | EIfThenElse of Range * E * E * E
    | EIfThen of Range * E * E
    | EPairCreate of Range * E * E
    | ESeq of Range * E * E
    | EHeapMutableSet of Range * E * E
    | EReal of Range * E
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
    | TV of Id
    | TPair of Range * T * T
    | TFun of Range * T * T
    | TRecord of Range * Map<string,T>
    | TSymbol of Range * string
    | TApply of Range * T * T
    | TPrim of Range * Config.PrimitiveType
    | TTerm of Range * E
    | TMacro of Range * TypeMacro list
    | TArrow of Range * FreeVars * TypeVar * T
    | THigherOrder of Id

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
    term : {| env : Map<string,E>; i : Id; i_rec : Id |}
    ty : {| env : Map<string,T>; i : Id |}
    }

let add_term (e : Env) k v =
    let term = e.term
    {e with term = {|term with i = term.i+1; env = Map.add k v term.env|} }

let add_term_rec (e : Env) k v =
    let term = e.term
    {e with term = {|term with i_rec = term.i_rec-1; env = Map.add k v term.env|} }

let add_ty (e : Env) k v =
    let ty = e.ty
    {e with ty = {|ty with i = ty.i+1; env = Map.add k v ty.env|} }

let add_term_var (e : Env) k = e.term.i, add_term e k (EV e.term.i)
let add_term_rec_var (e : Env) k = e.term.i_rec, add_term e k (EV e.term.i_rec)
let add_ty_var (e : Env) k = e.ty.i, add_ty e k (TV e.ty.i)

type PrepassError =
    | RecordIndexFailed of string

exception PrepassException of (Range * PrepassError) list

let compile_pattern _ = failwith "TODO"
let compile_typecase _ = failwith "TODO"

let prepass (top_env : TopEnv) expr =
    let v_term (env : Env) x = Map.tryFind x env.term.env |> Option.defaultWith (fun () -> top_env.term.[x])
    let v_ty (env : Env) x =  Map.tryFind x env.ty.env |> Option.defaultWith (fun () -> top_env.ty.[x])
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
                | RawMacroText(r,a) -> TMText a
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
        | RawTypecase(r,a,b) -> compile_typecase a b
        | RawForall(r,((_,(name,_)),_),b) -> 
            let tt = failwith "TODO"
            let id, env = add_ty_var env name
            EForall(r,(),(id,tt),term env b)
        | RawRecBlock(r,l,on_succ) ->
            let l,env = List.mapFold (fun env ((r,name),body) -> let id,env = add_term_rec_var env name in (id,body), env) env l
            ERecBlock(r,List.map (fun (id,body) -> id, term env body) l,term env on_succ)
        | RawRecordWith(r,a,b,c) ->
            let a = List.map f a
            let b = b |> List.map (function
                | RawRecordWithSymbol((r,a),b) -> RSymbol((r,a),f b)
                | RawRecordWithSymbolModify((r,a),b) -> RSymbolModify((r,a),f b)
                | RawRecordWithInjectVar((r,a),b) -> RVar((r,v_term env a),f b)
                | RawRecordWithInjectVarModify((r,a),b) -> RVarModify((r,v_term env a),f b))
            let c = c |> List.map (function
                | RawRecordWithoutSymbol(r,a) -> WSymbol(r,a)
                | RawRecordWithoutInjectVar(r,a) -> WVar(r,v_term env a))
            ERecordWith(r,a,b,c)
        | RawOp(r,a,b) -> EOp(r,a,List.map f b)
        | RawJoinPoint(r,a) -> EJoinPoint(r,f a)
        | RawAnnot(r,a,b) -> EAnnot(r,f a,ty env b)
        | RawModuleOpen (r,a,l,on_succ) ->
            let a,b = 
                match top_env.term.[snd a], top_env.ty.[snd a] with
                | ERecord a, TRecord(_, b) ->
                    List.fold (fun (a,b) (_,x) ->
                        match Map.find x a, Map.find x b with
                        | ERecord a, TRecord(_, b) -> a,b
                        | _ -> failwith "Compiler error: Module open's symbol index should have been validated."
                        ) (a,b) l
                | _ -> failwith "Compiler error: Module open should have been validated."
            let env =
                let combine e m = Map.foldBack Map.add m e
                {
                term = {|env.term with env = combine env.term.env a|}
                ty = {|env.ty with env = combine env.ty.env b|}
                }
            term env on_succ
        | RawApply(r,a,b) ->
            match f a, f b with
            | ERecord a, ESymbolCreate(_,b) ->
                match Map.tryFind b a with
                | Some x -> x
                | None -> raise (PrepassException [r,RecordIndexFailed b])
            | a,b -> EApply(r,a,b)
        | RawIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | RawIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | RawPairCreate(r,a,b) -> EPairCreate(r,f a,f b)
        | RawSeq(r,a,b) -> ESeq(r,f a,f b)
        | RawHeapMutableSet(r,a,b) -> EHeapMutableSet(r,f a,f b)
        | RawReal(r,a) -> EReal(r,f a)
        | RawMacro(r,a) -> // TODO: Don't forget to fill in the types for the macros.
            let a = a |> List.map (function
                | RawMacroText(r,a) -> MText a
                | RawMacroTermVar(r,a) -> MTerm(v_term env a)
                | RawMacroTypeVar(r,a) -> MType(v_ty env a)
                )
            EMacro(r,a)
        | RawMissingBody _ -> failwith "Compiler error: The missing body cases should have been validated."
        | RawInline(r,a) -> EInline(r,(),f a)

    let env =
        {
        term = {|env=Map.empty; i=0; i_rec= -1|}
        ty = {|env=Map.empty; i=0|}
        }

    let eval_type ((r,(name,kind)) : HoVar) on_succ env =
        let tt = failwith "TODO"
        let id, env = add_ty_var env name
        TArrow(r,(),(id,tt),on_succ env)
    let eval_type' name l body top_env_ty = Map.add name (List.foldBack eval_type l (fun env -> ty env body) env) top_env_ty
    match expr with
    | BundleType(r,(_,name),l,body) -> 
        {top_env with ty = eval_type' name l body top_env.ty}
    //| BundleRecType l ->
    //    let env,_ =
    //        List.fold (fun (env, i) -> function
    //            | BundleUnion(r,(_,name),b,c) -> add_ty env name (THigherOrder i), i+1
    //            | BundleNominal(r,(_,name),b,c) -> add_ty env name (THigherOrder i), i+1
    //            ) (env, top_env.hoc.Length) l
    //    let ty =
    //        List.fold (fun ty -> function
    //            | BundleUnion(r,(_,name),l,body) -> eval_type' name l body ty
    //            | BundleNominal(r,(_,name),l,body) -> eval_type' name l body ty
    //            ) top_env.ty l
    //    { top_env with  ty = ty
    //                    hoc = failwith "TODO"
    //                    }
    //| BundleInl of Range * (Range * VarString) * RawExpr * is_top_down: bool
    //| BundleRecTerm of BundleRecTerm list
    //| BundlePrototype of Range * (Range * VarString) * (Range * VarString) * TypeVar list * RawTExpr
    //| BundleInstance of Range * (Range * VarString) * (Range * VarString) * TypeVar list * RawExpr
        