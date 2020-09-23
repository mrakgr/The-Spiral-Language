module Spiral.Prepass
open Infer

type Id = int32
//type FreeVars = {|ty : int; term : int|}
type FreeVarsEnv = {|free_vars : int []; stack_size : int|} // The stack size does not include the size of free vars.
type FreeVars = {term : FreeVarsEnv; ty : FreeVarsEnv}
//type Range = { uri : string; range : Config.VSCRange }
type Range = BlockParsing.Range

type Macro<'free_vars> =
    | MText of string
    | MType of T
    | MTerm of 'free_vars E
and TypeMacro<'free_vars> =
    | TMText of string
    | TMType of 'free_vars T
and RecordWith<'free_vars> =
    | RSymbol of (Range * string) * 'free_vars E
    | RSymbolModify of (Range * string) * 'free_vars E
    | RVar of (Range * 'free_vars E) * 'free_vars E
    | RVarModify of (Range * 'free_vars E) * 'free_vars E
and RecordWithout<'free_vars> =
    | WSymbol of Range * string
    | WVar of Range * 'free_vars E
and PatRecordMember<'free_vars> =
    | Symbol of (Range * string) * Id
    | Var of (Range * 'free_vars E) * Id
and E<'free_vars> =
    | EB of Range
    | EV of Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * 'free_vars T
    | ESymbolCreate of Range * string
    | EType of Range * 'free_vars T
    | EApply of Range * 'free_vars E * 'free_vars E
    | ETypeApply of Range * 'free_vars E * 'free_vars T
    | EFun of Range * 'free_vars * Id * 'free_vars E * 'free_vars T option
    | ERecursive of 'free_vars E ref
    | EForall of Range * 'free_vars * Id * 'free_vars E
    | ERecBlock of Range * (Id * 'free_vars E) list * on_succ: 'free_vars E
    | ERecordWith of Range * 'free_vars E list * 'free_vars RecordWith list * 'free_vars RecordWithout list
    | ERecord of Map<string, 'free_vars E> // Used for modules.
    | EOp of Range * BlockParsing.Op * 'free_vars E list
    | EPatternMiss
    | EJoinPoint of Range * FreeVars * E * T option
    | EAnnot of Range * E * T
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
    | ETypeRecordTest of Range * Map<string,Id> * bind: Id * on_succ: E * on_fail: E
    | ETypeApplyTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeArrayTest of Range * bind: Id * pat: Id * on_succ: E * on_fail: E
    | ETypeEq of Range * T * bind: Id * on_succ: E * on_fail: E
and T<'free_vars> =
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
let fresh_ty_var (e : Env) = e.ty.i, (let ty = e.ty in {e with ty = {|ty with i = ty.i+1|} })
let add_term_rec_var (e : Env) k = e.term.i_rec, add_term e k (EV e.term.i_rec)
let add_ty_var (e : Env) k = e.ty.i, add_ty e k (TV e.ty.i)

type PrepassError =
    | RecordIndexFailed of string

exception PrepassException of (Range * PrepassError) list
open System.Collections.Generic

type PropagatedVarsEnv = {| vars : Set<int>; max_var : int |}
type PropagatedVars = {term : PropagatedVarsEnv; ty : PropagatedVarsEnv}

let free_vars i (env : Env) (x : PropagatedVars) : FreeVars = {
    term = {|free_vars = Set.toArray x.term.vars; stack_size = max 0 (x.term.max_var-env.term.i) + i |}
    ty = {|free_vars = Set.toArray x.ty.vars; stack_size = max 0 (x.ty.max_var-env.ty.i) + i |}
    }
let propagate env x annot =
    let dict = Dictionary(HashIdentity.Reference)
    let (+) (a : PropagatedVars) (b : PropagatedVars) : PropagatedVars = {
        term = {|vars = Set.union a.term.vars b.term.vars; max_var = max a.term.max_var b.term.max_var |} 
        ty = {|vars = Set.union a.ty.vars b.ty.vars; max_var = max a.ty.max_var b.ty.max_var |} 
        }
    let (-) (a : PropagatedVars) i = {a with term = {|vars = Set.remove i a.term.vars; max_var = max i a.term.max_var |} }
    let (-.) (a : PropagatedVars) i = {a with ty = {|vars = Set.remove i a.ty.vars; max_var = max i a.ty.max_var |} }
    let empty = {term = {|vars = Set.empty; max_var=0|}; ty = {|vars = Set.empty; max_var=0|}}
    let singleton_term i = {term = {|vars = Set.singleton i; max_var=0|}; ty = {|vars = Set.empty; max_var=0|}}
    let singleton_ty i = {ty = {|vars = Set.singleton i; max_var=0|}; term = {|vars = Set.empty; max_var=0|}}
    let propagated_vars (a : FreeVars) : PropagatedVars = {term = {|vars = Set(a.term.free_vars); max_var = 0|}; ty = {|vars = Set(a.ty.free_vars); max_var = 0|}}
    let rec term x =
        let singleton = singleton_term
        match x with
        | EPatternMiss | ERecord | ERecursive | ESymbolCreate | ELit | EB -> empty
        | EV i -> singleton i
        | EPrototypeApply(_,_,a) | EType(_,a) | EDefaultLit(_,_,a) -> ty a
        | EHeapMutableSet(_,a,b) | ESeq(_,a,b) | EPairCreate(_,a,b) | EIfThen(_,a,b) | EApply(_,a,b) -> term a + term b
        | EAnnot(_,a,b) | ETypeApply(_,a,b) -> term a + ty b
        | EForall(_,a,_,_) | EJoinPoint(_,a,_,_) | EFun(_,a,_,_,_) -> propagated_vars a // No need to eval the optional types for join points and functions.
        | ERecBlock(_,l,on_succ) ->
            let s = List.fold (fun s (_,body) -> s + term body) (term on_succ) l
            List.fold (fun s (id,_) -> s - id) s l
        | ERecordWith(_,a,b,c) ->
            let fold f a b = List.fold f b a
            List.fold (fun s a -> s + term a) empty a
            |> fold (fun s -> function
                    | RSymbolModify(_,a) | RSymbol(_,a) -> s + term a
                    | RVar((_,a),b) | RVarModify((_,a),b) -> s + term a + term b
                    ) b
            |> fold (fun s -> function
                | WSymbol -> s
                | WVar(_,a) -> s + term a
                ) c
        | EOp(_,_,a) -> List.fold (fun s a -> s + term a) empty a
        | EIfThenElse(r,a,b,c) -> term a + term b + term c
        | EReal(_,a) -> term a
        | EMacro(_,a,b) -> List.fold (fun s -> function MType x -> s + ty x | MTerm x -> s + term x | MText -> s) (ty b) a
        | EPatternMemo a -> Utils.memoize dict term a
        // Regular pattern matching
        | ELet(_,a,b,c) -> (term b - a) + term c
        | EPairTest(_,bind,pat1,pat2,on_succ,on_fail) -> singleton bind + (term on_succ - pat1 - pat2) + term on_fail
        | ESymbolTest(_,_,bind,on_succ,on_fail) 
        | EUnitTest(_,bind,on_succ,on_fail) 
        | ELitTest(_,_,bind,on_succ,on_fail) -> singleton bind + term on_succ + term on_fail
        | ERecordTest(r,a,bind,on_succ,on_fail) ->
            let on_succ_and_injects =
                let on_succ = List.fold (fun s (Symbol(_,a) | Var(_,a)) -> s - a) (term on_succ) a
                List.fold (fun s -> function Var((_,a),_) -> s + term a | Symbol -> s) on_succ a // Though it is less efficient, I am using two passes here to guard against future changes to pattern compilation breaking this part by accident.
            singleton bind + term on_fail + on_succ_and_injects
        | EDefaultLitTest(_,_,t,bind,on_succ,on_fail)
        | EAnnotTest(_,t,bind,on_succ,on_fail) -> singleton bind + ty t + term on_succ + term on_fail
        | ENominalTest(_,t,bind,pat,on_succ,on_fail) -> singleton bind + ty t + (term on_succ - pat) + term on_fail
        // Typecase
        | ETypeLet(_,a,b,c) -> (ty b -. a) + term c
        | ETypeApplyTest(_,bind,pat1,pat2,on_succ,on_fail)
        | ETypeFunTest(_,bind,pat1,pat2,on_succ,on_fail)
        | ETypePairTest(_,bind,pat1,pat2,on_succ,on_fail) -> singleton_ty bind + (term on_succ -. pat1 -. pat2) + term on_fail
        | ETypeRecordTest(_,a,bind,on_succ,on_fail) ->
            let on_succ = Map.fold (fun s k v -> s -. v) (term on_succ) a
            singleton_ty bind + on_succ + term on_fail
        | ETypeArrayTest(_,bind,pat,on_succ,on_fail) -> singleton_ty bind + (term on_succ -. pat) + term on_fail
        | ETypeEq(_,t,bind,on_succ,on_fail) -> singleton_ty bind + ty t + term on_succ + term on_fail
    and ty = function
        | TSymbol | TPrim | TNominal | TUnit -> empty
        | TV i -> singleton_ty i
        | TApply(_,a,b) | TPair(_,a,b) | TFun(_,a,b) -> ty a + ty b
        | TUnion(_,a) | TRecord(_,a) -> Map.fold (fun s k v -> s + ty v) empty a
        | TTerm(_,a) -> term a
        | TMacro(_,a) -> a |> List.fold (fun s -> function TMText -> s | TMType x -> s + ty x) empty
        | TArrow(_,a,_,_) -> propagated_vars a
        | TArray(_,a) | TLayout(_,a,_) -> ty a
    
    let next i x = free_vars i env (match annot with Some annot -> x + ty annot | None -> x)
    match x with 
    | Choice1Of4 x -> next 0 (term x)
    | Choice2Of4 x -> next 0 (ty x)
    | Choice3Of4 (id, x) -> next 1 (term x - id)
    | Choice4Of4 (id, x) -> next 1 (ty x -. id)

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

let make_compile_typecase_env (env : Env) x =
    let metavars' = Dictionary(HashIdentity.Reference)
    let metavars = Dictionary(HashIdentity.Structural)
    let rec f (env : Env) x =
        match x with
        | RawTFilledNominal | RawTTerm | RawTForall -> failwith "Compiler error: This case is not supposed to appear in typecase."
        | RawTPrim | RawTSymbol | RawTWildcard | RawTB | RawTVar -> env
        | RawTMetaVar(r,a) ->
            match metavars.TryGetValue a with
            | true, id' -> metavars'.Add(a,fun (id, on_succ, on_fail) -> ETypeEq(r,TV id',id,on_succ,on_fail)); env
            | _ ->
                let id', env = add_ty_var env a
                metavars.Add(a,id')
                metavars'.Add(a,fun (id,on_succ,_) -> ETypeLet(r,id',TV id,on_succ))
                env
        | RawTApply(_,a,b) | RawTFun(_,a,b) | RawTPair(_,a,b) -> f (f env a) b
        | RawTLayout(_,a,_) | RawTArray(_,a) -> f env a
        | RawTUnion(_,a) | RawTRecord(_,a) -> Map.fold (fun s k v -> f s v) env a
        | RawTMacro(_,a) -> a |> List.fold (fun env -> function RawMacroTypeVar(_,a) -> f env a | _ -> env) env

    metavars', f env x

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
                | PatNominal(r,(_,a),b) -> let id', on_succ = step b on_succ in ENominalTest(r,v_ty ve.envs.[pat] a,id,id',on_succ,on_fail)
                | PatFilledDefaultValue(r,a,b) -> EDefaultLitTest(r,a,ty ve.envs.[pat] b,id,on_succ,on_fail)
                | PatDyn(r,a) -> let id' = patvar() in ELet(r,id',EOp(r,Dyn,[EV id]),cp id' a on_succ on_fail)
                | PatUnbox(r,a) -> EOp(r,Unbox,[EV id; cp id a on_succ on_fail])

            cp id pat on_succ on_fail
        List.foldBack loop l EPatternMiss
    and compile_clauses env clauses = List.map (fun (pat,on_succ) -> let x,env = make_compile_pattern_env env pat in x,pat,EPatternMemo(term env on_succ)) clauses
    and pattern_match (env : Env) r body clauses =
        match clauses with
        | [PatVar(_,x), on_succ] ->
            let id,env = add_term_var env x
            ELet(r,id,body,term env on_succ)
        | _ ->
            let id,env = fresh_term_var env
            ELet(r,id,body,compile_pattern id (compile_clauses env clauses))
    and pattern_function env r clauses annot =
        match clauses with
        | [PatVar(_,x), on_succ] ->
            let id,env = add_term_var env x
            let body = term env on_succ
            let free_vars = propagate env (Choice3Of4(id, body)) annot
            EFun(r,free_vars,id,body,annot)
        | _ ->
            let id,env = fresh_term_var env
            let body = compile_pattern id (compile_clauses env clauses)
            let free_vars = propagate env (Choice3Of4(id, body)) annot
            EFun(r,free_vars,id,body,annot)
    and compile_typecase id l =
        let loop ((vars : Dictionary<_,_>, env : Env), pat, on_succ) on_fail =
            let var_count = ref env.ty.i
            let patvar () = let x = !var_count in incr var_count; x
            let rec cp id pat on_succ on_fail =
                let step pat on_succ = let id = patvar() in id, cp id pat on_succ on_fail
                match pat with
                | RawTFilledNominal | RawTTerm | RawTForall -> failwith "Compiler error: This case is not supposed to appear in typecase."
                | RawTWildcard _ -> on_succ
                | RawTMetaVar(_,a) -> vars.[a] (id,on_succ,on_fail)
                | RawTPair(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypePairTest(r,id,a,b,on_succ,on_fail)
                | RawTFun(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypeFunTest(r,id,a,b,on_succ,on_fail)
                | RawTApply(r,a,b) -> 
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypeApplyTest(r,id,a,b,on_succ,on_fail)
                | RawTArray(r,a) ->
                    let a,on_succ = step a on_succ
                    ETypeArrayTest(r,id,a,on_succ,on_fail)
                | RawTRecord(r,a) ->
                    let m,on_succ =
                        Map.foldBack (fun k pat (s, on_succ) ->
                            let id,on_succ = step pat on_succ
                            Map.add k id s, on_succ
                            ) a (Map.empty, on_succ)
                    ETypeRecordTest(r,m,id,on_succ,on_fail)
                | RawTVar | RawTSymbol | RawTB | RawTPrim | RawTMacro | RawTUnion | RawTLayout -> ETypeEq(range_of_texpr pat,ty env pat,id,on_succ,on_fail)

            cp id pat on_succ on_fail
        List.foldBack loop l EPatternMiss
    and typecase (env : Env) r body clauses =
        let id, env = fresh_ty_var env
        let l = clauses |> List.map (fun (pat,on_succ) -> let _,env as x = make_compile_typecase_env env pat in x,pat,EPatternMemo(term env on_succ))
        ETypeLet(r,id,body,compile_typecase id l)
    and ty (env : Env) x =
        let f = ty env
        match x with
        | RawTWildcard -> failwith "Compiler error: Annotation with wildcards should have been stripped."
        | RawTMetaVar -> failwith "Compiler error: This should have been compiled away in typecase."
        | RawTForall -> failwith "Compiler error: Foralls are not allowed at the type level."
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
        | RawAnnot(_,RawDefaultLit(r,a),b) -> EDefaultLit(r,a,ty env b)
        | RawB r -> EB r
        | RawV(r,a) -> v_term env a
        | RawBigV(r,a) -> EApply(r,v_term env a,EB r)
        | RawLit(r,a) -> ELit(r,a)
        | RawSymbolCreate(r,a) -> ESymbolCreate(r,a)
        | RawType(r,a) -> EType(r,ty env a)
        | RawMatch(r,a,b) -> pattern_match env r (f a) b
        | RawFun(r,a) -> pattern_function env r a None
        | RawAnnot(_,RawFun(r,a),t) -> pattern_function env r a (Some (ty env t))
        | RawTypecase(r,a,b) -> typecase env r (ty env a) b
        | RawFilledForall(r,name,b)
        | RawForall(r,((_,(name,_)),_),b) -> 
            let id, env = add_ty_var env name
            let body = term env b
            let free_vars = propagate env (Choice3Of4(id,body)) None
            EForall(r,free_vars,id,body)
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
        | RawJoinPoint(r,a) -> 
            let body = f a
            let free_vars = propagate env (Choice1Of4 body) None
            EJoinPoint(r,free_vars,body,None)
        | RawAnnot(_,RawJoinPoint(r,a),b) -> 
            let body = f a
            let b = Some (ty env b)
            let free_vars = propagate env (Choice1Of4 body) b
            EJoinPoint(r,free_vars,body,b)
        | RawModuleOpen (_,a,l,on_succ) ->
            let a,b = 
                match top_env.term.[snd a], top_env.ty.[snd a] with
                | ERecord a, TRecord(_, b) ->
                    List.fold (fun (a,b) (_,x) ->
                        match Map.find x a, Map.find x b with
                        | ERecord a, TRecord(_, b) -> a,b
                        | _ -> failwith "Compiler error: Module open's symbol index should have been validated."
                        ) (a,b) l
                | _ -> failwith "Compiler error: Module open should have been validated."
            let env : Env =
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

    let env : Env =
        {
        term = {|env=Map.empty; i=0; i_rec= -1|}
        ty = {|env=Map.empty; i=0|}
        }

    let eval_type ((r,(name,kind)) : HoVar) on_succ env =
        let id, env = add_ty_var env name
        let body = on_succ env
        let free_vars = propagate env (Choice4Of4(id,body)) None
        TArrow(r,free_vars,id,body)
    let eval_type' env l body = List.foldBack eval_type l (fun env -> ty env body) env
    match expr with
    | FType(_,(_,name),l,body) -> {top_env with ty = Map.add name (eval_type' env l body) top_env.ty}
    | FNominal l ->
        let env,_ = List.fold (fun (env,i) (r,(_,name),l,body) -> add_ty env name (TNominal i), i+1) (env, top_env.nominals.Length) l
        let ty,nominals = 
            List.fold (fun (ty, nominals) (r,(_,name),l,body) -> 
                let x = eval_type' env l body
                Map.add name x ty, PersistentVector.conj {|body=x; name=name|} nominals
                ) (top_env.ty, top_env.nominals) l
        {top_env with ty = ty; nominals = nominals}
    | FInl(_,(_,name),body) -> {top_env with term = Map.add name (term env body) top_env.term}
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
        let id,env = add_ty_var env name
        let body = EPrototypeApply(r,top_env.prototypes.Length,TV id)
        let free_vars = propagate env (Choice3Of4(id,body)) None
        let x = EForall(r,free_vars,id,body)
        {top_env with term = Map.add name x top_env.term; prototypes = PersistentVector.conj Map.empty top_env.prototypes}
    | FInstance(_,(_,prot_id),(_,ins_id),l,body) ->
        let env = l |> List.fold (fun s x -> add_ty_var s (typevar_name x) |> snd) env
        let body = term env body
        {top_env with prototypes = PersistentVector.update prot_id (Map.add ins_id body top_env.prototypes.[prot_id]) top_env.prototypes}

type ResolveEnv = Map<int,E * Set<int>>

let resolve_free_vars (env' : Map<Id,FreeVars>) =
    let env = env' |> Map.map (fun k v -> Set(v.term.free_vars))
    Map.fold (fun (env : Map<Id,Set<int>>) k v ->
        let has_visited = HashSet()
        let rec f s k v = if has_visited.Add(k) then Set.fold (fun s k -> if 0 < k then f s k env.[k] else Set.add k s) s v else s
        Map.add k (f Set.empty k v) env
        ) env env
    |> Map.map (fun k free_vars ->
        let k = env'.[k]
        {k with term = {|k.term with free_vars = Set.toArray free_vars|} }
        )

let resolve x =
    let subst (env : ResolveEnv) (x : FreeVars) : FreeVars = 
        let f s x = if 0 < x then match Map.tryFind x env with Some (_,x) -> s + x | None -> s else s
        {x with term = {|x.term with free_vars = Array.fold f Set.empty x.term.free_vars |> Set.toArray|} }
    let rec resolve_recursive (env : ResolveEnv) l =
        let l,e =
            List.mapFold (fun s (id,body) ->
                let r = ref Unchecked.defaultof<_>
                let free_vars, body =
                    match body with
                    | EForall(r,a,b,c) -> a, fun free_vars env -> id, EForall(r,free_vars,b,term env c)
                    | EFun(r,a,b,c,d) -> a, fun free_vars env -> id, EFun(r,free_vars,b,term env c, Option.map (ty env) d)
                    | _ -> failwith "Compiler error: Expected a function or a forall."
                (r, body), Map.add id (subst env free_vars) s
                ) Map.empty l
        let e = resolve_free_vars e
        failwith ""
    and term (env : ResolveEnv) x =
        let f = term env
        match x with
        | ERecursive | ESymbolCreate | EDefaultLit | ELit | EB -> x
        | EV i -> if i < 0 then fst env.[i] else x
        | EType(r,a) -> EType(r,ty env a)
        | EApply(r,a,b) -> EApply(r,f a,f b)
        | ETypeApply(r,a,b) -> ETypeApply(r,f a,ty env b)
        | EFun(r,a,b,c,d) -> EFun(r,subst env a,b,f c,Option.map (ty env) d)
        | EForall(r,a,b,c) -> EForall(r,subst env a,b,f c)
        | ERecBlock(r,a,b) ->
            let a,env = resolve_recursive env a
            ERecBlock(r,a,term env b)
        //| ERecordWith of Range * E list * RecordWith list * RecordWithout list
        //| ERecord of Map<string, E> // Used for modules.
        //| EOp of Range * BlockParsing.Op * E list
        //| EPatternMiss
        //| EJoinPoint of Range * FreeVars * E * T option
        //| EAnnot of Range * E * T
        //| EIfThenElse of Range * E * E * E
        //| EIfThen of Range * E * E
        //| EPairCreate of Range * E * E
        //| ESeq of Range * E * E
        //| EHeapMutableSet of Range * E * E
        //| EReal of Range * E
        //| EMacro of Range * Macro list * T
        //| EPrototypeApply of Range * Id * T
        //| EPatternMemo of E
        //// Regular pattern matching
        //| ELet of Range * Id * E * E
        //| EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
        //| ESymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
        //| ERecordTest of Range * PatRecordMember list * bind: Id * on_succ: E * on_fail: E
        //| EAnnotTest of Range * T * bind: Id * on_succ: E * on_fail: E
        //| ELitTest of Range * Tokenize.Literal * bind: Id * on_succ: E * on_fail: E
        //| EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
        //| ENominalTest of Range * T * bind: Id * pat: Id * on_succ: E * on_fail: E
        //| EDefaultLitTest of Range * string * T * bind: Id * on_succ: E * on_fail: E
        //// Typecase
        //| ETypeLet of Range * Id * T * E
        //| ETypePairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
        //| ETypeFunTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
        //| ETypeRecordTest of Range * Map<string,Id> * bind: Id * on_succ: E * on_fail: E
        //| ETypeApplyTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
        //| ETypeArrayTest of Range * bind: Id * pat: Id * on_succ: E * on_fail: E
        //| ETypeEq of Range * T * bind: Id * on_succ: E * on_fail: E
    and ty env x = x
    ()