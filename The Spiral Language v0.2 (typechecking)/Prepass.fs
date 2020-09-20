module Spiral.Prepass
open Infer

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVars = unit
//type Range = { uri : string; range : Config.VSCRange }
type Range = BlockParsing.Range

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
    | Var of (Range * E) * Id
and E =
    | EB of Range
    | EV of Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * T
    | ESymbolCreate of Range * string
    | EType of Range * T
    | EApply of Range * E * E
    | ETypeApply of Range * E * T
    | EFun of Range * FreeVars * Id * E * T option
    | ERecursive of E ref
    | EForall of Range * FreeVars * Id * E
    | ERecBlock of Range * (Id * E) list * on_succ: E
    | ERecordWith of Range * E list * RecordWith list * RecordWithout list
    | ERecord of Map<string, E> // Used for modules.
    | EOp of Range * BlockParsing.Op * E list
    | EPatternMiss
    | EJoinPoint of Range * FreeVars * E * T option
    | EAnnot of Range * E * T
    | ETypecase of Range * T * (T * E) list
    | EModuleOpen of Range * (Range * Id) * (Range * string) list * on_succ: E
    | EIfThenElse of Range * E * E * E
    | EIfThen of Range * E * E
    | EPairCreate of Range * E * E
    | ESeq of Range * E * E
    | EHeapMutableSet of Range * E * E
    | EReal of Range * E
    | EMacro of Range * Macro list * T
    | EPrototypeApply of Range * Id * T
    | EPatternMemo of E
    // Regular pattern matching
    | ELet of Range * Id * E * E
    | EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ESymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
    | ERecordTest of Range * PatRecordMember list * bind: Id * on_succ: E * on_fail: E
    | EAnnotTest of Range * T * bind: Id * on_succ: E * on_fail: E
    | ELitTest of Range * Tokenize.Literal * bind: Id * on_succ: E * on_fail: E
    | EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
    | ENominalTest of Range * T * bind: Id * pat: Id * on_succ: E * on_fail: E
    | EDefaultLitTest of Range * string * T * bind: Id * on_succ: E * on_fail: E
    // Typecase
    | ETypeLet of Range * Id * T * E
    | ETypePairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeFunTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeSymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
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
    | TUnion of Range * Map<string,T>
    | TSymbol of Range * string
    | TApply of Range * T * T
    | TPrim of Range * Config.PrimitiveType
    | TTerm of Range * E
    | TMacro of Range * TypeMacro list
    | TArrow of Range * FreeVars * Id * T
    | TNominal of Id
    | TArray of Range * T
    | TLayout of Range * T * BlockParsing.Layout

open FSharpx.Collections

open BlockParsing
open TypecheckingUtils
type TopEnv = {
    prototypes : Map<int,E> PersistentVector
    nominals : {|body : T; name : string|} PersistentVector
    term : Map<string,E>
    ty : Map<string,T>
    }

type Env = {
    term : {| env : Map<string,E>; i : Id; i_rec : Id |}
    ty : {| env : Map<string,T>; i : Id |}
    }

let add_term (e : Env) k v = let term = e.term in {e with term = {|term with i = term.i+1; env = Map.add k v term.env|} }
let add_term_rec (e : Env) k v = let term = e.term in {e with term = {|term with i_rec = term.i_rec-1; env = Map.add k v term.env|} }
let add_ty (e : Env) k v = let ty = e.ty in {e with ty = {|ty with i = ty.i+1; env = Map.add k v ty.env|} }

let add_term_var (e : Env) k = e.term.i, add_term e k (EV e.term.i)
let fresh_term_var (e : Env) = e.term.i, (let term = e.term in {e with term = {|term with i = term.i+1|} })
let add_term_rec_var (e : Env) k = e.term.i_rec, add_term e k (EV e.term.i_rec)
let add_ty_var (e : Env) k = e.ty.i, add_ty e k (TV e.ty.i)

type PrepassError =
    | RecordIndexFailed of string

exception PrepassException of (Range * PrepassError) list
open System.Collections.Generic

type CompilePatternEnv = {vars : Dictionary<VarString,Id>; envs : Dictionary<Pattern,Env> }
let make_compile_pattern_env (env : Env) x = 
    let vars = Dictionary(HashIdentity.Structural)
    let envs = Dictionary(HashIdentity.Reference)
    let rec f env x = 
        match x with
        | PatValue | PatDefaultValue | PatSymbol | PatE | PatB -> env
        | PatVar(_,a) -> let id,l = add_term_var env a in vars.Add(a,id); l
        | PatOr(_,a,_) | PatDyn(_,a) | PatUnbox(_,a) -> f env a
        | PatFilledDefaultValue -> envs.Add(x,env); env
        | PatNominal(_,_,a) | PatAnnot(_,a,_) -> envs.Add(x,env); f env a
        | PatWhen(_,a,_) -> let env = f env a in envs.Add(x,env); env
        | PatAnd(_,a,b) | PatPair(_,a,b) -> f (f env a) b
        | PatRecordMembers(_,l) -> envs.Add(x,env); List.fold (fun s (PatRecordMembersSymbol(_,x) | PatRecordMembersInjectVar(_,x)) -> f s x) env l
            
    {vars=vars; envs=envs}, f env x

let prepass (top_env : TopEnv) (expr : FilledTop) =
    let v_term (env : Env) x = Map.tryFind x env.term.env |> Option.defaultWith (fun () -> top_env.term.[x])
    let v_ty (env : Env) x =  Map.tryFind x env.ty.env |> Option.defaultWith (fun () -> top_env.ty.[x])
    let rec compile_pattern id (l : (CompilePatternEnv * Pattern * E) list) =
        let loop (ve : CompilePatternEnv, pat, on_succ) on_fail =
            let var_count = ref (id + ve.vars.Count)
            let patvar () = let x = !var_count in incr var_count; x
            let rec cp id pat on_succ on_fail =
                let step pat on_succ = 
                    match pat with
                    | PatVar(_,x) -> ve.vars.[x], on_succ
                    | _ -> let id = patvar() in id, cp id pat on_succ on_fail
                match pat with
                | PatDefaultValue -> failwith "Compiler error: The default value should be filled."
                | PatE -> on_succ
                | PatB r -> EUnitTest(r,id,on_succ,on_fail)
                | PatVar(r,a) -> ELet(r,ve.vars.[a],EV id,on_succ)
                | PatAnnot(r,a,b) -> EAnnotTest(r,ty ve.envs.[pat] b,id,cp id a on_succ on_fail,on_fail)
                | PatPair(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    EPairTest(r,id,a,b,on_succ,on_fail)
                | PatSymbol(r,a) -> ESymbolTest(r,a,id,on_succ,on_fail)
                | PatRecordMembers(r,items) ->
                    let env = ve.envs.[pat]
                    let binds, on_succ =
                        List.mapFoldBack (fun item on_succ ->
                            match item with
                            | PatRecordMembersSymbol(keyword,name) -> let arg, on_succ = step name on_succ in Symbol(keyword,arg), on_succ
                            | PatRecordMembersInjectVar((r,var),name) -> let arg, on_succ = step name on_succ in Var((r,v_term env var),arg), on_succ
                            ) items on_succ
                    ERecordTest(r,binds,id,on_succ,on_fail)
                | PatOr(r,a,b) -> let on_succ = EPatternMemo on_succ in cp id a on_succ (cp id b on_succ on_fail)
                | PatAnd(r,a,b) -> let on_fail = EPatternMemo on_fail in cp id a (cp id b on_succ on_fail) on_fail
                | PatValue(r,x) -> ELitTest(r,x,id,on_succ,on_fail)
                | PatWhen(r,p,e) -> cp id p (EIfThenElse(r, term ve.envs.[pat] e, on_succ, on_fail)) on_fail
                | PatNominal(r,(_,a),b) ->
                    let id', on_succ = step b on_succ
                    ENominalTest(r,v_ty ve.envs.[pat] a,id,id',on_succ,on_fail)
                | PatFilledDefaultValue(r,a,b) -> EDefaultLitTest(r,a,ty ve.envs.[pat] b,id,on_succ,on_fail)
                | PatDyn(r,a) -> let id' = patvar() in ELet(r,id',EOp(r,Dyn,[EV id]),cp id' a on_succ on_fail)
                | PatUnbox(r,a) -> EOp(r,Unbox,[EV id; cp id a on_succ on_fail])

            cp id pat on_succ on_fail
        List.foldBack loop l EPatternMiss
    and pattern (env : Env) body clauses =
        let r () = List.head clauses |> fst |> range_of_pattern
        let l env = clauses |> List.map (fun (pat,on_succ) -> let x,env = make_compile_pattern_env env pat in x,pat,EPatternMemo(term env on_succ))
        match body, clauses with
        | Some body, [PatVar(r,x), on_succ] ->
            let id,env = add_term_var env x
            ELet(r,id,body,term env on_succ)
        | Some body, _ ->
            let id,env = fresh_term_var env
            ELet(r(),id,body,compile_pattern id (l env))
        | None, [PatVar(r,x), on_succ] ->
            let id,env = add_term_var env x
            EFun(r,(),id,term env on_succ,None)
        | None, _ ->
            let id,env = fresh_term_var env
            EFun(r(),(),id,compile_pattern id (l env),None)
    and typecase _ = failwith "TODO"
    and ty (env : Env) x =
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
        | RawTUnion(r,l) -> TUnion(r,Map.map (fun _ -> f) l)
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
                | RawMacroTypeVar(r,a) -> TMType(f a)
                | RawMacroTermVar _ -> failwith "Compiler error: Term vars should not appear on the type level."
            TMacro(r,List.map f l)
        | RawTArray(r,a) -> TArray(r,f a)
        | RawTFilledNominal(r,a) -> TNominal a
        | RawTLayout(r,a,b) -> TLayout(r,f a,b)
    and term env x =
        let f = term env
        match x with
        | RawDefaultLit(r,a) -> failwith "Compiler error: Default values should have been annotated in `fill` by prepass time."
        | RawAnnot(_,RawDefaultLit(r,a),b) -> EDefaultLit(r,a,ty env b) // TODO: Don't forget the rest of the annotation cases.
        | RawB r -> EB r
        | RawV(r,a) -> v_term env a
        | RawBigV(r,a) -> EApply(r,v_term env a,EB r)
        | RawLit(r,a) -> ELit(r,a)
        | RawSymbolCreate(r,a) -> ESymbolCreate(r,a)
        | RawType(r,a) -> EType(r,ty env a)
        | RawMatch(r,a,b) -> pattern env (Some (f a)) b
        | RawFun(r,a) -> pattern env None a
        | RawAnnot(_,RawFun(_,a),t) -> 
            match pattern env None a with
            | EFun(r,a,b,c,_) -> EFun(r,a,b,c,Some (ty env t))
            | _ -> failwith "Compiler error: RawFun should result in a function."
        | RawTypecase(r,a,b) -> typecase a b
        | RawFilledForall(r,name,b)
        | RawForall(r,((_,(name,_)),_),b) -> 
            let id, env = add_ty_var env name
            EForall(r,(),id,term env b)
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
        | RawJoinPoint(r,a) -> EJoinPoint(r,(),f a,None)
        | RawAnnot(_,RawJoinPoint(r,a),b) -> EJoinPoint(r,(),f a,Some (ty env b))
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
            | a,EType(_,b) -> ETypeApply(r,a,b)
            | a,b -> EApply(r,a,b)
        | RawIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | RawIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | RawPairCreate(r,a,b) -> EPairCreate(r,f a,f b)
        | RawSeq(r,a,b) -> ESeq(r,f a,f b)
        | RawHeapMutableSet(r,a,b) -> EHeapMutableSet(r,f a,f b)
        | RawReal(r,a) -> f a
        | RawMacro -> failwith "Compiler error: The macro's annotation should have been added during `fill`."
        | RawAnnot(_,RawMacro(r,a),b) ->
            let a = a |> List.map (function
                | RawMacroText(r,a) -> MText a
                | RawMacroTermVar(r,a) -> MTerm(f a)
                | RawMacroTypeVar(r,a) -> MType(ty env a)
                )
            EMacro(r,a,ty env b)
        | RawMissingBody _ -> failwith "Compiler error: The missing body cases should have been validated."
        | RawAnnot(r,a,b) -> EAnnot(r,f a,ty env b)

    let env =
        {
        term = {|env=Map.empty; i=0; i_rec= -1|}
        ty = {|env=Map.empty; i=0|}
        }

    let eval_type ((r,(name,kind)) : HoVar) on_succ env =
        let id, env = add_ty_var env name
        TArrow(r,(),id,on_succ env)
    let eval_type' env l body = List.foldBack eval_type l (fun env -> ty env body) env
    match expr with
    | FType(r,(_,name),l,body) -> {top_env with ty = Map.add name (eval_type' env l body) top_env.ty}
    | FNominal l ->
        let env,_ = List.fold (fun (env,i) (r,(_,name),l,body) -> add_ty env name (TNominal i), i+1) (env, top_env.nominals.Length) l
        let ty,nominals = 
            List.fold (fun (ty, nominals) (r,(_,name),l,body) -> 
                let x = eval_type' env l body
                Map.add name x ty, PersistentVector.conj {|body=x; name=name|} nominals
                ) (top_env.ty, top_env.nominals) l
        {top_env with ty = ty; nominals = nominals}
    | FInl(_,(_,name),body) ->
        {top_env with term = Map.add name (term env body) top_env.term}
    | FRecInl l ->
        let l, env = 
            List.mapFold (fun env (_,(_,name),_ as x) -> 
                let r = ref Unchecked.defaultof<_>
                (x,r), add_term_rec env name (ERecursive r)
                ) env l
        let term = 
            List.fold (fun top_env_term ((_,(_,name),body),r) ->
                r := term env body
                Map.add name !r top_env_term
                ) top_env.term l
        {top_env with term = term}
    | FPrototype(r,(_,name),_,_,_) ->
        let x = EForall(r,(),0,EPrototypeApply(r,top_env.prototypes.Length,TV 0))
        {top_env with term = Map.add name x top_env.term; prototypes = PersistentVector.conj Map.empty top_env.prototypes}
    | FInstance(r,(_,prot_id),(_,ins_id),l,body) ->
        let env = l |> List.fold (fun s x -> add_ty_var s (typevar_name x) |> snd) env
        let body = term env body
        {top_env with prototypes = PersistentVector.update prot_id (Map.add ins_id body top_env.prototypes.[prot_id]) top_env.prototypes}
        