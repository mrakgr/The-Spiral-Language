module Spiral.PartEval.Prepass
open Spiral
open VSCTypes
open Spiral.Infer

type Id = int32
type ScopeEnv = {|free_vars : int []; stack_size : int|}
type Scope = {term : ScopeEnv; ty : ScopeEnv}
type Range = { path : string; range : VSCRange }

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
and [<ReferenceEquality>] E =
    | EFun' of Range * Scope * Id * E * T option
    | EForall' of Range * Scope * Id * E
    | EJoinPoint' of Range * Scope * E * T option
    | EFun of Range * Id * E * T option
    | EForall of Range * Id * E
    | EJoinPoint of Range * E * T option
    | EB of Range
    | EV of Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * T
    | ESymbol of Range * string
    | EType of Range * T
    | EApply of Range * E * E
    | ETypeApply of Range * E * T
    | ERecursive of E ref
    | ERecBlock of Range * (Id * E) list * on_succ: E
    | ERecordWith of Range * (Range * E) list * RecordWith list * RecordWithout list
    | EModule of Map<string, E>
    | EOp of Range * BlockParsing.Op * E list
    | EPatternMiss of E
    | EAnnot of Range * E * T
    | EIfThenElse of Range * E * E * E
    | EIfThen of Range * E * E
    | EPair of Range * E * E
    | ESeq of Range * E * E
    | EHeapMutableSet of Range * E * (Range * E) list * E
    | EReal of Range * E
    | EMacro of Range * Macro list * T
    | EPrototypeApply of Range * prototype_id: GlobalId * T
    | EPatternMemo of E
    | ENominal of Range * E * T
    // Regular pattern matching
    | ELet of Range * Id * E * E
    | EUnbox of Range * Id * E * E
    | EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ESymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
    | ERecordTest of Range * PatRecordMember list * bind: Id * on_succ: E * on_fail: E
    | EAnnotTest of Range * T * bind: Id * on_succ: E * on_fail: E
    | EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
    | ENominalTest of Range * T * bind: Id * pat: Id * on_succ: E * on_fail: E
    | ELitTest of Range * Tokenize.Literal * bind: Id * on_succ: E * on_fail: E
    | EDefaultLitTest of Range * string * T * bind: Id * on_succ: E * on_fail: E
    // Typecase
    | ETypeLet of Range * Id * T * E
    | ETypePairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeFunTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeRecordTest of Range * Map<string,Id> * bind: Id * on_succ: E * on_fail: E
    | ETypeApplyTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ETypeArrayTest of Range * bind: Id * pat: Id * on_succ: E * on_fail: E
    | ETypeEq of Range * T * bind: Id * on_succ: E * on_fail: E
and [<ReferenceEquality>] T =
    | TArrow' of Scope * Id * T
    | TArrow of Id * T
    | TJoinPoint' of Range * Scope * T
    | TJoinPoint of Range * T
    | TB of Range
    | TV of Id
    | TPair of Range * T * T
    | TFun of Range * T * T
    | TRecord of Range * Map<string,T>
    | TModule of Map<string,T>
    | TUnion of Range * (Map<string,T> * BlockParsing.UnionLayout)
    | TSymbol of Range * string
    | TApply of Range * T * T
    | TPrim of BlockParsing.PrimitiveType
    | TTerm of Range * E
    | TMacro of Range * TypeMacro list
    | TNominal of GlobalId
    | TArray of T
    | TLayout of T * BlockParsing.Layout

open FSharpx.Collections
open BlockParsing
type PrepassTopEnv = {
    prototypes_next_tag : int
    prototypes_instances : Map<GlobalId * GlobalId,E>
    nominals_next_tag : int
    nominals : Map<GlobalId,{|body : T; name : string|}>
    term : Map<string,E>
    ty : Map<string,T>
    has_errors : bool
    }

let top_env_empty = {
    prototypes_next_tag = 0
    prototypes_instances = Map.empty
    nominals_next_tag = 0
    nominals = Map.empty
    term = Map.empty
    ty = Map.empty
    has_errors = false
    }

let union small big = {
    prototypes_next_tag = max small.prototypes_next_tag big.prototypes_next_tag
    prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
    nominals_next_tag = max small.nominals_next_tag big.nominals_next_tag
    nominals = Map.foldBack Map.add small.nominals big.nominals
    term = Map.foldBack Map.add small.term big.term
    ty = Map.foldBack Map.add small.ty big.ty
    has_errors = small.has_errors || big.has_errors
    }
    
let in_module m (a : PrepassTopEnv) =
    {a with 
        ty = Map.add m (TModule a.ty) Map.empty
        term = Map.add m (EModule a.term) Map.empty
        }

open System.Collections.Generic

type PropagatedVarsEnv = {|vars : Set<int>; range : (int * int) option|}
type PropagatedVars = {term : PropagatedVarsEnv; ty : PropagatedVarsEnv}

let propagate x =
    let dict = Dictionary(HashIdentity.Reference)
    let (+*) a b = 
        match a,b with
        | Some(min',max'), Some(min'',max'') -> Some(min min' min'', max max' max'')
        | Some(a,b), _ | _, Some(a,b) -> Some(a,b)
        | None, None -> None
    let (+) (a : PropagatedVars) (b : PropagatedVars) : PropagatedVars = {
        term = {|vars = Set.union a.term.vars b.term.vars; range = a.term.range +* b.term.range |} 
        ty = {|vars = Set.union a.ty.vars b.ty.vars; range = a.ty.range +* b.ty.range |} 
        }
    let (-*) a i =
        if 0 <= i then 
            match a with 
            | Some(min',max') -> Some(min min' i, max max' i)
            | None -> Some(i,i)
        else a // Recursive vars are negative and get inlined so they should be ignored when calculating the range of a scope.
    let (-) (a : PropagatedVars) i = {a with term = {|vars = Set.remove i a.term.vars; range = a.term.range -* i |} }
    let (-.) (a : PropagatedVars) i = {a with ty = {|vars = Set.remove i a.ty.vars; range = a.ty.range -* i |} }
    let empty' term ty = let f x = {|vars = x; range=None|} in {term = f term; ty = f ty}
    let empty = empty' Set.empty Set.empty
    let singleton_term i = empty' (Set.singleton i) Set.empty
    let singleton_ty i = empty' Set.empty (Set.singleton i)

    let scope_dict = Dictionary<obj,_>(HashIdentity.Reference)
    let scope x (v : PropagatedVars) = scope_dict.Add(x,v); empty' v.term.vars v.ty.vars
    let rec term x =
        match x with
        | EForall' _ | EJoinPoint' _ | EFun' _ | EModule _ | ERecursive _ | ESymbol _ | ELit _ | EB _ -> empty
        | EV i -> singleton_term i
        | EPrototypeApply(_,_,a) | EType(_,a) | EDefaultLit(_,_,a) -> ty a
        | ESeq(_,a,b) | EPair(_,a,b) | EIfThen(_,a,b) | EApply(_,a,b) -> term a + term b
        | ENominal(_,a,b) | EAnnot(_,a,b) | ETypeApply(_,a,b) -> term a + ty b
        | EForall(_,i,a) -> scope x (term a -. i)
        | EJoinPoint(_,a,t) -> scope x (match t with Some t -> term a + ty t | None -> term a)
        | EFun(_,i,a,t) -> scope x (match t with Some t -> term a - i + ty t | None -> term a - i)
        | ERecBlock(_,l,on_succ) ->
            let s = List.fold (fun s (_,body) -> s + term body) (term on_succ) l
            List.fold (fun s (id,_) -> s - id) s l
        | ERecordWith(_,a,b,c) ->
            let fold f a b = List.fold f b a
            List.fold (fun s (_,a) -> s + term a) empty a
            |> fold (fun s -> function
                    | RSymbolModify(_,a) | RSymbol(_,a) -> s + term a
                    | RVar((_,a),b) | RVarModify((_,a),b) -> s + term a + term b
                    ) b
            |> fold (fun s -> function
                | WSymbol _ -> s
                | WVar(_,a) -> s + term a
                ) c
        | EOp(_,_,a) -> List.fold (fun s a -> s + term a) empty a
        | EHeapMutableSet(_,a,b,c) -> term a + List.fold (fun s (_,a) -> s + term a) empty b + term c
        | EIfThenElse(_,a,b,c) -> term a + term b + term c
        | EPatternMiss a | EReal(_,a) -> term a
        | EMacro(_,a,b) -> List.fold (fun s -> function MType x -> s + ty x | MTerm x -> s + term x | MText _ -> s) (ty b) a
        | EPatternMemo a -> Utils.memoize dict term a
        // Regular pattern matching
        | ELet(_,bind,body,on_succ) | EUnbox(_,bind,body,on_succ) -> term on_succ - bind + term body
        | EPairTest(_,bind,pat1,pat2,on_succ,on_fail) -> singleton_term bind + (term on_succ - pat1 - pat2) + term on_fail
        | ESymbolTest(_,_,bind,on_succ,on_fail) 
        | EUnitTest(_,bind,on_succ,on_fail) 
        | ELitTest(_,_,bind,on_succ,on_fail) -> singleton_term bind + term on_succ + term on_fail
        | ERecordTest(_,a,bind,on_succ,on_fail) ->
            let on_succ_and_injects =
                let on_succ = List.fold (fun s (Symbol(_,a) | Var(_,a)) -> s - a) (term on_succ) a
                List.fold (fun s -> function Var((_,a),_) -> s + term a | Symbol _ -> s) on_succ a // Though it is less efficient, I am using two passes here to guard against future changes to pattern compilation breaking this part by accident.
            singleton_term bind + term on_fail + on_succ_and_injects
        | EDefaultLitTest(_,_,t,bind,on_succ,on_fail)
        | EAnnotTest(_,t,bind,on_succ,on_fail) -> singleton_term bind + ty t + term on_succ + term on_fail
        | ENominalTest(_,t,bind,pat,on_succ,on_fail) -> singleton_term bind + ty t + (term on_succ - pat) + term on_fail
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
        | TJoinPoint' _ | TArrow' _ | TSymbol _ | TPrim _ | TNominal _ | TB _ -> empty
        | TV i -> singleton_ty i
        | TApply(_,a,b) | TPair(_,a,b) | TFun(_,a,b) -> ty a + ty b
        | TUnion(_,(a,_)) | TRecord(_,a) | TModule a -> Map.fold (fun s k v -> s + ty v) empty a
        | TTerm(_,a) -> term a
        | TMacro(_,a) -> a |> List.fold (fun s -> function TMText _ -> s | TMType x -> s + ty x) empty
        | TArrow(i,a) as x -> scope x (ty a -. i)
        | TJoinPoint(_,a) as x -> scope x (ty a)
        | TArray(a) | TLayout(a,_) -> ty a
    
    let _ = match x with Choice1Of2 x -> term x | Choice2Of2 x -> ty x
    scope_dict

type ResolveEnvValue = {|term : Set<Id>; ty : Set<Id> |}
type ResolveEnv = Map<int, ResolveEnvValue>
let resolve_recursive_free_vars env =
    Map.fold (fun (env : ResolveEnv) k v ->
        let has_visited = HashSet()
        let rec f (s : ResolveEnvValue) k v = 
            if has_visited.Add(k) then 
                let s = Set.fold (fun s k -> if k < 0 then f s k env.[k] else {|s with term = Set.add k s.term|}) s v.term
                Set.fold (fun s k -> {|s with ty = Set.add k s.ty|}) s v.ty
            else s
        Map.add k (f {|term=Set.empty; ty=Set.empty|} k v) env
        ) env env

let resolve (scope : Dictionary<obj,PropagatedVars>) x =
    let dict = Dictionary(HashIdentity.Reference)
    let subst' (env : ResolveEnv) (x : PropagatedVars) : PropagatedVars = 
        let f (s : ResolveEnvValue) x = 
            if x < 0 then 
                match Map.tryFind x env with 
                | Some x -> {|term=Set.union s.term x.term; ty=Set.union s.ty x.ty|}
                | None -> {|s with term=Set.add x s.term|}
            else {|s with term=Set.add x s.term|}
        let fv = Set.fold f {|term=Set.empty; ty=Set.empty|} x.term.vars
        {x with term = {|x.term with vars = fv.term|}; ty = {|x.ty with vars = Set.union fv.ty x.ty.vars|} }
    let subst env (x : obj) = match scope.TryGetValue(x) with true, v -> scope.[x] <- subst' env v | _ -> ()
    let rec term (env : ResolveEnv) x =
        let f = term env
        match x with
        | EForall' _ | EFun' _ | EJoinPoint' _ | EModule _ | EV _ | ERecursive _ | ESymbol _ | EDefaultLit _ | ELit _ | EB _ -> ()
        | EPrototypeApply(_,_,a) | EType(_,a) -> ty env a
        | EJoinPoint(_,a,b) | EFun(_,_,a,b) -> subst env x; f a; Option.iter (ty env) b
        | EForall(_,_,a) -> subst env x; f a
        | ERecBlock(r,a,b) ->
            let env = 
                let l =
                    List.fold (fun s (id,body) ->
                        let x = subst' env scope.[body]
                        Map.add id {|term=x.term.vars; ty=x.ty.vars|} s
                        ) Map.empty a
                    |> resolve_recursive_free_vars
                Map.foldBack Map.add l env
            a |> List.iter (fun (id,body) ->
                scope.[body] <- 
                    let x = env.[id]
                    let v = scope.[body]
                    {v with term = {|v.term with vars = x.term |}; ty = {|v.ty with vars=x.ty|} }
                term env body
                )
            term env b
        | ERecordWith(_,a,b,c) ->
            List.iter (snd >> f) a
            b |> List.iter (function
                | RSymbolModify(_,a) | RSymbol(_,a) -> f a
                | RVarModify((_,a),b) | RVar((_,a),b) -> f a; f b)
            c |> List.iter (function 
                | WSymbol _ -> ()
                | WVar(_,a) -> f a)
        | ENominal(_,a,b) | ETypeLet(_,_,b,a) | ETypeApply(_,a,b) | EAnnot(_,a,b) -> f a; ty env b
        | EOp(_,_,a) -> List.iter f a
        | EPatternMiss a | EReal(_,a) -> f a
        | ETypePairTest(_,_,_,_,a,b) | ETypeFunTest(_,_,_,_,a,b) | ETypeRecordTest(_,_,_,a,b) | ETypeApplyTest(_,_,_,_,a,b) | ETypeArrayTest(_,_,_,a,b)
        | EUnitTest(_,_,a,b) | ESymbolTest(_,_,_,a,b) | EPairTest(_,_,_,_,a,b) | ELitTest(_,_,_,a,b)
        | ELet(_,_,a,b) | EUnbox(_,_,a,b) | EIfThen(_,a,b) | EPair(_,a,b) | ESeq(_,a,b) | EApply(_,a,b) -> f a; f b
        | EHeapMutableSet(_,a,b,c) -> f a; List.iter (snd >> f) b; f c
        | EIfThenElse(_,a,b,c) -> f a; f b; f c
        | EMacro(_,a,b) ->
            a |> List.iter (function MType a -> ty env a | MTerm a -> f a | MText _ -> ())
            ty env b
        | EPatternMemo a -> Utils.memoize dict f a
        | ERecordTest(_,l,_,a,b) -> 
            l |> List.iter (function Symbol _ -> () | Var((_,a),_) -> f a)
            f a; f b
        | ETypeEq(_,t,_,a,b) | EDefaultLitTest(_,_,t,_,a,b) | ENominalTest(_,t,_,_,a,b) | EAnnotTest(_,t,_,a,b) -> ty env t; f a; f b

    and ty (env : ResolveEnv) x = 
        let f = ty env
        match x with
        | TJoinPoint' _ | TArrow' _ | TNominal _ | TPrim _ | TSymbol _ | TV _ | TB _ -> ()
        | TArrow(_,a) -> subst env x; f a
        | TApply(_,a,b) | TFun(_,a,b) | TPair(_,a,b) -> f a; f b
        | TRecord(_,a) | TModule a | TUnion(_,(a,_)) -> Map.iter (fun _ -> f) a
        | TTerm(_,a) -> term env a
        | TMacro(_,a) -> a |> List.iter (function TMText _ -> () | TMType a -> f a)
        | TJoinPoint(_,a) | TLayout(a,_) | TArray(a) -> f a

    match x with
    | Choice1Of2 x -> term Map.empty x
    | Choice2Of2 x -> ty Map.empty x

type LowerSubEnv<'x> = {|var : Map<int,'x>; adj : int option|}
type LowerEnv = {term : LowerSubEnv<E>; ty : LowerSubEnv<T> }
let lower (scope : Dictionary<obj,PropagatedVars>) x =
    let dict = Dictionary(HashIdentity.Reference)
    let scope (env : LowerEnv) x =
        let v = scope.[x]
        let fv_term =
            v.term.vars |> Set.toArray
            |> Array.map (fun i ->
                match Map.tryFind i env.term.var with
                | Some(EV i) -> i
                | None -> i + env.term.adj.Value
                | Some _ -> failwith "Compiler error: Expected a variable in the environment."
                ) 
        let sz = function Some(min,max) -> max - min + 1 | None -> 0
        let stack_size_term = sz v.term.range

        let fv_ty = 
            v.ty.vars |> Set.toArray
            |> Array.map (fun i ->
                match Map.tryFind i env.ty.var with
                | Some(TV i) -> i
                | None -> i + env.ty.adj.Value
                | Some _ -> failwith "Compiler error: Expected a variable in the environment."
                ) 
        let stack_size_ty = sz v.ty.range
        let scope : Scope = {
            term = {|free_vars = fv_term; stack_size = stack_size_term|}
            ty = {|free_vars = fv_ty; stack_size = stack_size_ty|}
            }

        let var_term,_ = Set.fold (fun (s,i) x -> Map.add x (EV i) s,i+1) (Map.filter (fun k _ -> k < 0) env.term.var, 0) v.term.vars
        let adj len range = Option.map (fun (min,_) -> len - min) range
        let adj_term = adj fv_term.Length v.term.range

        let var_ty,_ = Set.fold (fun (s,i) x -> Map.add x (TV i) s,i+1) (Map.empty, 0) v.ty.vars
        let adj_ty = adj fv_ty.Length v.ty.range

        let env : LowerEnv = {
            term = {|var = var_term; adj = adj_term|}
            ty = {|var = var_ty; adj = adj_ty|}
            }

        scope, env

    let adj_term (env : LowerEnv) i = i + env.term.adj.Value
    let adj_ty (env : LowerEnv) i = i + env.ty.adj.Value

    let rec term (env : LowerEnv) x = 
        let f = term env
        let adj = adj_term env
        match x with
        | EForall' _ | EJoinPoint' _ | EFun' _ | EModule _ | ERecursive _ | ESymbol _ | ELit _ | EB _ -> x
        | EFun(r,a,b,c) -> 
            let scope, env = scope env x 
            let i = adj_term env a
            assert (scope.term.free_vars.Length = i)
            EFun'(r,scope,i,term env b,Option.map (ty env) c)
        | EForall(r,a,b) ->
            let scope, env = scope env x 
            let i = adj_ty env a
            assert (scope.ty.free_vars.Length = i)
            EForall'(r,scope,i,term env b)
        | EJoinPoint(r,a,b) ->
            let scope, env = scope env x 
            EJoinPoint'(r,scope,term env a,Option.map (ty env) b)
        | EV i -> match Map.tryFind i env.term.var with Some i -> i | None -> EV(adj i)
        | EDefaultLit(r,a,b) -> EDefaultLit(r,a,ty env b)
        | EType(r,a) -> EType(r,ty env a)
        | EApply(r,a,b) -> EApply(r,f a,f b)
        | ETypeApply(r,a,b) -> ETypeApply(r,f a,ty env b)
        | ENominal(r,a,b) -> ENominal(r,f a,ty env b)
        | ERecBlock(r,a,b) ->
            let add_term k v (env : LowerEnv) = { env with term = {|env.term with var = Map.add k v env.term.var|} }
            let a, env =
                List.mapFold (fun env (id',body) ->
                    let re = ref Unchecked.defaultof<_>
                    let body env = 
                        let x = term env body
                        let rename_scope (x : Scope) : Scope = {
                            term = {|free_vars = Array.init x.term.free_vars.Length id; stack_size = x.term.stack_size|}
                            ty = {|free_vars = Array.init x.ty.free_vars.Length id; stack_size = x.ty.stack_size|}
                            }
                        re :=
                            match x with
                            | EForall'(a,b,c,d) -> EForall'(a,rename_scope b,c,d)
                            | EFun'(a,b,c,d,e) -> EFun'(a,rename_scope b,c,d,e)
                            | _ -> failwith "Compiler error: Expected a fun or a forall."
                        id', x
                    body, add_term id' (ERecursive re) env
                    ) env a
            let env = List.fold (fun env x -> let id,body = x env in add_term id body env) env a
            term env b
        | ERecordWith(r,a,b,c) ->
            let a = List.map (fun (r,a) -> r, f a) a
            let b = b |> List.map (function
                | RSymbol(a,b) -> RSymbol(a,f b)
                | RSymbolModify(a,b) -> RSymbolModify(a,f b)
                | RVar((r,a),b) -> RVar((r,f a),f b)
                | RVarModify((r,a),b) -> RVarModify((r,f a),f b)
                )
            let c = c |> List.map (function
                | WSymbol _ as x -> x
                | WVar(r,a) -> WVar(r,f a)
                )
            ERecordWith(r,a,b,c)
        | EOp(r,a,b) -> EOp(r,a,List.map f b)
        | EAnnot(r,a,b) -> EAnnot(r,f a,ty env b)
        | EIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | EIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | EPair(r,a,b) -> EPair(r,f a,f b)
        | ESeq(r,a,b) -> ESeq(r,f a,f b)
        | EHeapMutableSet(r,a,b,c) -> EHeapMutableSet(r,f a,List.map (fun (a,b) -> a, f b) b,c)
        | EPatternMiss a -> EPatternMiss(f a)
        | EReal(r,a) -> EReal(r,f a)
        | EMacro(r,a,b) -> 
            let a = a |> List.map (function
                | MText _ as x -> x
                | MType a -> MType(ty env a)
                | MTerm a -> MTerm(f a)
                )
            EMacro(r,a,ty env b)
        | EPrototypeApply(r,a,b) -> EPrototypeApply(r,a,ty env b)
        | EPatternMemo x -> Utils.memoize dict f x
        // Regular pattern matching
        | ELet(r,a,b,c) -> ELet(r,adj a,f b,f c)
        | EUnbox(r,a,b,c) -> EUnbox(r,adj a,f b,f c)
        | EPairTest(r,a,b,c,d,e) -> EPairTest(r,adj a,adj b,adj c,f d,f e)
        | ESymbolTest(r,a,b,c,d) -> ESymbolTest(r,a,adj b,f c,f d)
        | ERecordTest(r,a,b,c,d) ->
            let a = 
                List.map (function
                    | Symbol(a,b) -> Symbol(a,adj b)
                    | Var((r,a),b) -> Var((r,f a),adj b)
                    ) a
            ERecordTest(r,a,adj b,term env c,term env d)
        | EAnnotTest(r,a,b,c,d) -> EAnnotTest(r,ty env a,adj b,f c,f d)
        | ELitTest(r,a,b,c,d) -> ELitTest(r,a,adj b,f c,f d)
        | EUnitTest(r,a,b,c) -> EUnitTest(r,adj a,f b,f c)
        | ENominalTest(r,a,b,c,d,e) -> ENominalTest(r,ty env a,adj b,adj c,term env d,term env e)
        | EDefaultLitTest(r,a,b,c,d,e) -> EDefaultLitTest(r,a,ty env b,adj c,f d,f e)
        // Typecase
        | ETypeLet(r,a,b,c) -> ETypeLet(r,adj a,ty env b,f c)
        | ETypePairTest(r,a,b,c,d,e) -> ETypePairTest(r,adj a,adj b,adj c,f d,f e)
        | ETypeFunTest(r,a,b,c,d,e) -> ETypeFunTest(r,adj a,adj b,adj c,f d,f e)
        | ETypeRecordTest(r,a,b,c,d) -> ETypeRecordTest(r,Map.map (fun _ -> adj) a,adj b,f c,f d)
        | ETypeApplyTest(r,a,b,c,d,e) -> ETypeApplyTest(r,adj a,adj b,adj c,f d,f e)
        | ETypeArrayTest(r,a,b,c,d) -> ETypeArrayTest(r,adj a,adj b,f c,f d)
        | ETypeEq(r,a,b,c,d) -> ETypeEq(r,ty env a,adj b,f c,f d)
    and ty env x =
        let f = ty env
        let adj = adj_ty env
        match x with
        | TJoinPoint' _ | TArrow' _ | TNominal  _ | TPrim _ | TSymbol _ | TB _ -> x
        | TJoinPoint(r,a) ->
            let scope, env = scope env x 
            TJoinPoint'(r,scope,ty env a)
        | TArrow(a,b) ->  
            let scope, env = scope env x
            TArrow'(scope,adj_ty env a,ty env b)
        | TV i -> match Map.tryFind i env.ty.var with Some i -> i | None -> TV(adj i)
        | TPair(r,a,b) -> TPair(r,f a,f b)
        | TFun(r,a,b) -> TFun(r,f a,f b)
        | TRecord(r,a) -> TRecord(r,Map.map (fun _ -> f) a)
        | TModule a -> TModule(Map.map (fun _ -> f) a)
        | TUnion(r,(a,b)) -> TUnion(r,(Map.map (fun _ -> f) a,b))
        | TApply(r,a,b) -> TApply(r,f a,f b)
        | TTerm(r,a) -> TTerm(r,term env a)
        | TMacro(r,a) ->
            let a = a |> List.map (function 
                | TMText _ as x -> x
                | TMType a -> TMType(f a)
                )
            TMacro(r,a)
        | TArray(a) -> TArray(f a)
        | TLayout(a,b) -> TLayout(f a,b)
    let env : LowerEnv = {
        term = {|var = Map.empty; adj = None|}
        ty = {|var = Map.empty; adj = None|}
        }
    match x with
    | Choice1Of2(x,ret) -> ret (term env x)
    | Choice2Of2(x,ret) -> ret (ty env x)

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

type CompilePatternEnv = {vars : Dictionary<VarString,Id>; envs : Dictionary<Pattern,Env> }
let make_compile_pattern_env (env : Env) x = 
    let vars = Dictionary(HashIdentity.Structural)
    let envs = Dictionary(HashIdentity.Reference)
    let rec f env x = 
        match x with
        | PatValue _ | PatDefaultValue _ | PatSymbol _ | PatE _ | PatB _ -> env
        | PatVar(_,a) -> let id,l = add_term_var env a in vars.Add(a,id); l
        | PatOr(_,a,_) | PatDyn(_,a) | PatUnbox(_,a) -> f env a
        | PatFilledDefaultValue _ -> envs.Add(x,env); env
        | PatNominal(_,_,a) | PatAnnot(_,a,_) -> envs.Add(x,env); f env a
        | PatWhen(_,a,_) -> let env = f env a in envs.Add(x,env); env
        | PatAnd(_,a,b) | PatPair(_,a,b) -> f (f env a) b
        | PatRecordMembers(_,l) -> envs.Add(x,env); List.fold (fun s (PatRecordMembersSymbol(_,x) | PatRecordMembersInjectVar(_,x)) -> f s x) env l
            
    {vars=vars; envs=envs}, f env x

let make_compile_typecase_env path (env : Env) x =
    let p r = {path=path; range=r}
    let metavars' = Dictionary(HashIdentity.Reference)
    let metavars = Dictionary(HashIdentity.Structural)
    let rec f (env : Env) x =
        match x with
        | RawTFilledNominal _ | RawTTerm _ | RawTForall _ -> failwith "Compiler error: This case is not supposed to appear in typecase."
        | RawTPrim _ | RawTSymbol _ | RawTWildcard _ | RawTB _ | RawTVar _ -> env
        | RawTMetaVar(r,a) ->
            match metavars.TryGetValue a with
            | true, id' -> metavars'.Add(a,fun (id, on_succ, on_fail) -> ETypeEq(p r,TV id',id,on_succ,on_fail)); env
            | _ ->
                let id', env = add_ty_var env a
                metavars.Add(a,id')
                metavars'.Add(a,fun (id,on_succ,_) -> ETypeLet(p r,id',TV id,on_succ))
                env
        | RawTApply(_,a,b) | RawTFun(_,a,b) | RawTPair(_,a,b) -> f (f env a) b
        | RawTLayout(_,a,_) | RawTArray(_,a) -> f env a
        | RawTUnion(_,a,_) | RawTRecord(_,a) -> Map.fold (fun s k v -> f s v) env a
        | RawTMacro(_,a) -> a |> List.fold (fun env -> function RawMacroTypeVar(_,a) -> f env a | _ -> env) env

    metavars', f env x

let process_term (x : E) =
    let scope = propagate (Choice1Of2 x)
    resolve scope (Choice1Of2 x)
    lower scope (Choice1Of2(x,id))

let process_ty (x : T) =
    let scope = propagate (Choice2Of2 x)
    resolve scope (Choice2Of2 x)
    lower scope (Choice2Of2(x,id))

let module_open (top_env : PrepassTopEnv) env a l =
    let a,b = 
        match top_env.term.[snd a], top_env.ty.[snd a] with
        | EModule a, TModule b ->
            List.fold (fun (a,b) (_,x) ->
                match Map.find x a, Map.find x b with
                | EModule a, TModule b -> a,b
                | _ -> failwith "Compiler error: Module open's symbol index should have been validated."
                ) (a,b) l
        | _ -> failwith "Compiler error: Module open should have been validated."
    {
    term = {|env.term with env = Map.foldBack Map.add a env.term.env|}
    ty = {|env.ty with env = Map.foldBack Map.add b env.ty.env|}
    }
let prepass package_id module_id path (top_env : PrepassTopEnv) =
    assert (top_env.has_errors = false)
    let p r = {path=path; range=r}
    let at_tag i = { package_id = package_id; module_id = module_id; tag = i }
    let v_term (env : Env) x = Map.tryFind x env.term.env |> Option.defaultWith (fun () -> top_env.term.[x])
    let v_ty (env : Env) x =  Map.tryFind x env.ty.env |> Option.defaultWith (fun () -> top_env.ty.[x])
    let rec compile_pattern id (l : (CompilePatternEnv * Pattern * E) list) =
        let loop (ve : CompilePatternEnv, pat, on_succ) on_fail =
            let var_count = ref (id + ve.vars.Count)
            let patvar () = incr var_count; !var_count
            let rec cp id pat on_succ on_fail =
                let step pat on_succ = 
                    match pat with
                    | PatVar(_,x) -> ve.vars.[x], on_succ
                    | _ -> let id = patvar() in id, cp id pat on_succ on_fail
                match pat with
                | PatDefaultValue _ -> failwith "Compiler error: The default value should be filled."
                | PatE _ -> on_succ
                | PatB r -> EUnitTest(p r,id,on_succ,on_fail)
                | PatVar(r,a) -> ELet(p r,ve.vars.[a],EV id,on_succ)
                | PatAnnot(r,a,b) -> EAnnotTest(p r,ty ve.envs.[pat] b,id,cp id a on_succ on_fail,on_fail)
                | PatPair(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    EPairTest(p r,id,a,b,on_succ,on_fail)
                | PatSymbol(r,a) -> ESymbolTest(p r,a,id,on_succ,on_fail)
                | PatRecordMembers(r,items) ->
                    let env = ve.envs.[pat]
                    let binds, on_succ =
                        List.mapFoldBack (fun item on_succ ->
                            match item with
                            | PatRecordMembersSymbol((r,keyword),name) -> let arg, on_succ = step name on_succ in Symbol((p r,keyword),arg), on_succ
                            | PatRecordMembersInjectVar((r,var),name) -> let arg, on_succ = step name on_succ in Var((p r,v_term env var),arg), on_succ
                            ) items on_succ
                    ERecordTest(p r,binds,id,on_succ,on_fail)
                | PatOr(r,a,b) -> let on_succ = EPatternMemo on_succ in cp id a on_succ (cp id b on_succ on_fail)
                | PatAnd(r,a,b) -> let on_fail = EPatternMemo on_fail in cp id a (cp id b on_succ on_fail) on_fail
                | PatValue(r,x) -> ELitTest(p r,x,id,on_succ,on_fail)
                | PatWhen(r,p',e) -> cp id p' (EIfThenElse(p r, term ve.envs.[pat] e, on_succ, on_fail)) on_fail
                | PatNominal(r,(_,a),b) -> let id', on_succ = step b on_succ in ENominalTest(p r,v_ty ve.envs.[pat] a,id,id',on_succ,on_fail)
                | PatFilledDefaultValue(r,a,b) -> EDefaultLitTest(p r,a,ty ve.envs.[pat] b,id,on_succ,on_fail)
                | PatDyn(r,a) -> let id' = patvar() in ELet(p r,id',EOp(p r,Dyn,[EV id]),cp id' a on_succ on_fail)
                | PatUnbox(r,a) -> let id' = patvar() in EUnbox(p r,id',EV id,cp id' a on_succ on_fail)

            cp id pat on_succ (EPatternMemo on_fail)
        List.foldBack loop l (EPatternMiss(EV id))
    and compile_clauses env clauses = List.map (fun (pat,on_succ) -> let x,env = make_compile_pattern_env env pat in x,pat,term env on_succ) clauses
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
            EFun(r,id,term env on_succ,annot)
        | _ ->
            let id,env = fresh_term_var env
            EFun(r,id,compile_pattern id (compile_clauses env clauses),annot)
    and compile_typecase id l =
        let loop ((vars : Dictionary<_,_>, env : Env), pat, on_succ) on_fail =
            let var_count = ref env.ty.i
            let patvar () = let x = !var_count in incr var_count; x
            let rec cp id pat on_succ on_fail =
                let step pat on_succ = let id = patvar() in id, cp id pat on_succ on_fail
                match pat with
                | RawTFilledNominal _ | RawTTerm _ | RawTForall _ -> failwith "Compiler error: This case is not supposed to appear in typecase."
                | RawTWildcard _ -> on_succ
                | RawTMetaVar(_,a) -> vars.[a] (id,on_succ,on_fail)
                | RawTPair(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypePairTest(p r,id,a,b,on_succ,on_fail)
                | RawTFun(r,a,b) ->
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypeFunTest(p r,id,a,b,on_succ,on_fail)
                | RawTApply(r,a,b) -> 
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    ETypeApplyTest(p r,id,a,b,on_succ,on_fail)
                | RawTArray(r,a) ->
                    let a,on_succ = step a on_succ
                    ETypeArrayTest(p r,id,a,on_succ,on_fail)
                | RawTRecord(r,a) ->
                    let m,on_succ =
                        Map.foldBack (fun k pat (s, on_succ) ->
                            let id,on_succ = step pat on_succ
                            Map.add k id s, on_succ
                            ) a (Map.empty, on_succ)
                    ETypeRecordTest(p r,m,id,on_succ,on_fail)
                | RawTVar _ | RawTSymbol _ | RawTB _ | RawTPrim _ | RawTMacro _ | RawTUnion _ | RawTLayout _ -> 
                    ETypeEq(p (range_of_texpr pat),ty env pat,id,on_succ,on_fail)
            cp id pat on_succ (EPatternMemo on_fail)
        List.foldBack loop l (EPatternMiss(EV id))
    and typecase (env : Env) r body clauses =
        let id, env = fresh_ty_var env
        let l = clauses |> List.map (fun (pat,on_succ) -> let _,env as x = make_compile_typecase_env path env pat in x,pat,term env on_succ)
        ETypeLet(r,id,body,compile_typecase id l)
    and ty (env : Env) x =
        let f = ty env
        match x with
        | RawTWildcard _ -> failwith "Compiler error: Annotation with wildcards should have been stripped."
        | RawTMetaVar _ -> failwith "Compiler error: This should have been compiled away in typecase."
        | RawTForall _ -> failwith "Compiler error: Foralls are not allowed at the type level."
        | RawTB r -> TB (p r)
        | RawTVar(r,a) -> v_ty env a
        | RawTPair(r,a,b) -> TPair(p r,f a,f b)
        | RawTFun(r,a,b) -> TFun(p r,f a,f b)
        | RawTRecord(r,l) -> TRecord(p r,Map.map (fun _ -> f) l)
        | RawTUnion(r,a,b) -> TUnion(p r,(Map.map (fun _ -> f) a,b))
        | RawTSymbol(r,a) -> TSymbol(p r,a)
        | RawTApply(r,a,b) ->
            match f a, f b with
            | TRecord(_,a') & a, TSymbol(_,b') & b ->
                match Map.tryFind b' a' with
                | Some x -> x
                | None -> TApply(p r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
            | a,b -> TApply(p r,a,b)
        | RawTPrim(r,a) -> TPrim(a)
        | RawTTerm(r,a) -> TTerm(p r,term env a)
        | RawTMacro(r,l) -> 
            let f = function 
                | RawMacroText(r,a) -> TMText a
                | RawMacroTypeVar(r,a) -> TMType(f a)
                | RawMacroTermVar _ -> failwith "Compiler error: Term vars should not appear on the type level."
            TMacro(p r,List.map f l)
        | RawTArray(r,a) -> TArray(f a)
        | RawTFilledNominal(r,a) -> TNominal a
        | RawTLayout(r,a,b) -> TLayout(f a,b)
    and term env x =
        let f = term env
        match x with
        | RawDefaultLit(r,a) -> failwith "Compiler error: Default values should have been annotated in `fill` by prepass time."
        | RawAnnot(_,RawDefaultLit(r,a),b) -> EDefaultLit(p r,a,ty env b)
        | RawB r -> EB(p r)
        | RawV(r,a) -> v_term env a
        | RawBigV(r,a) -> EApply(p r,v_term env a,EB(p r))
        | RawLit(r,a) -> ELit(p r,a)
        | RawSymbol(r,a) -> ESymbol(p r,a)
        | RawType(r,a) -> EType(p r,ty env a)
        | RawMatch(r,a,b) -> pattern_match env (p r) (f a) b
        | RawFun(r,a) -> pattern_function env (p r) a None
        | RawAnnot(_,RawFun(r,a),t) -> pattern_function env (p r) a (Some (ty env t))
        | RawTypecase(r,a,b) -> typecase env (p r) (ty env a) b
        | RawFilledForall(r,name,b)
        | RawForall(r,((_,(name,_)),_),b) -> 
            let id, env = add_ty_var env name
            EForall(p r,id,term env b)
        | RawRecBlock(r,l,on_succ) ->
            let l,env = List.mapFold (fun env ((r,name),body) -> let id,env = add_term_rec_var env name in (id,body), env) env l
            ERecBlock(p r,List.map (fun (id,body) -> id, term env body) l,term env on_succ)
        | RawRecordWith(r,a,b,c) ->
            let a = List.map (fun a -> p (range_of_expr a), f a) a
            let b = b |> List.map (function
                | RawRecordWithSymbol((r,a),b) -> RSymbol((p r,a),f b)
                | RawRecordWithSymbolModify((r,a),b) -> RSymbolModify((p r,a),f b)
                | RawRecordWithInjectVar((r,a),b) -> RVar((p r,v_term env a),f b)
                | RawRecordWithInjectVarModify((r,a),b) -> RVarModify((p r,v_term env a),f b))
            let c = c |> List.map (function
                | RawRecordWithoutSymbol(r,a) -> WSymbol(p r,a)
                | RawRecordWithoutInjectVar(r,a) -> WVar(p r,v_term env a))
            ERecordWith(p r,a,b,c)
        | RawOp(r,a,b) -> EOp(p r,a,List.map f b)
        | RawJoinPoint(r,a) -> EJoinPoint(p r,f a,None)
        | RawAnnot(_,RawJoinPoint(r,a),b) -> EJoinPoint(p r,f a,Some (ty env b))
        | RawOpen (_,a,l,on_succ) -> term (module_open top_env env a l) on_succ
        | RawApply(r,a,b) ->
            let rec loop = function
                | EModule a' & a, EPair(_,ESymbol(_, b'),b'') & b ->
                    match Map.tryFind b' a' with
                    | Some a -> loop (a,b'')
                    | None -> EApply(p r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
                | EModule a' & a, ESymbol(_,b') & b ->
                    match Map.tryFind b' a' with
                    | Some a -> a
                    | None -> EApply(p r,a,b) // TODO: Ditto.
                | a,EType(_,b) -> ETypeApply(p r,a,b)
                | a,b -> EApply(p r,a,b)
            loop (f a, f b)
        | RawIfThenElse(r,a,b,c) -> EIfThenElse(p r,f a,f b,f c)
        | RawIfThen(r,a,b) -> EIfThen(p r,f a,f b)
        | RawPair(r,a,b) -> EPair(p r,f a,f b)
        | RawSeq(r,a,b) -> ESeq(p r,f a,f b)
        | RawHeapMutableSet(r,a,b,c) -> EHeapMutableSet(p r,f a,List.map (fun a -> p (range_of_expr a), f a) b,f c)
        | RawReal(r,a) -> f a
        | RawMacro _ -> failwith "Compiler error: The macro's annotation should have been added during `fill`."
        | RawAnnot(_,RawMacro(r,a),b) ->
            let a = a |> List.map (function
                | RawMacroText(r,a) -> MText a
                | RawMacroTermVar(r,a) -> MTerm(f a)
                | RawMacroTypeVar(r,a) -> MType(ty env a)
                )
            EMacro(p r,a,ty env b)
        | RawMissingBody _ -> failwith "Compiler error: The missing body cases should have been validated."
        | RawAnnot(r,a,b) -> EAnnot(p r,f a,ty env b)

    let env : Env =
        {
        term = {|env=Map.empty; i=0; i_rec= -1|}
        ty = {|env=Map.empty; i=0|}
        }

    let eval_type ((r,(name,kind)) : HoVar) on_succ env =
        let id, env = add_ty_var env name
        TArrow(id,on_succ env)
    let eval_type' env l body = List.foldBack eval_type l body env |> process_ty

    let nominal_term term nom r name l body =
        let t,i = l |> List.fold (fun (nom,i) _ -> TApply(r,nom,TV i), i+1) (nom,0)
        let rec wrap_foralls i x = if 0 < i then let i = i-1 in wrap_foralls i (EForall(r,i,x)) else process_term x
        match body with
        | RawTUnion(_,l,_) -> Map.fold (fun term name _ -> Map.add name (wrap_foralls i (EFun(r,0,ENominal(r,EPair(r, ESymbol(r,name), EV 0),t),Some t))) term) term l
        | _ -> Map.add name (wrap_foralls i (EFun(r,0,ENominal(r,EV 0,t),Some t))) term

    {|
    base_type = process_ty
    filled_top = fun x ->
        match x with
        | FType(_,(_,name),l,body) -> AInclude {top_env_empty with ty = Map.add name (eval_type' env l (fun env -> ty env body)) Map.empty}
        | FNominal(r,(_,name),l,body) ->
            let i = at_tag top_env.nominals_next_tag
            let term = nominal_term Map.empty (TNominal i) (p r) name l body
            let x = eval_type' env l (fun env -> TJoinPoint(p (range_of_texpr body), ty env body))
            let ty = Map.add name x Map.empty
            let nominals = Map.add i {|body=x; name=name|} Map.empty
            AInclude {top_env_empty with term = term; ty = ty; nominals = nominals; nominals_next_tag=i.tag+1}
        | FNominalRec l ->
            let term,env,_ = 
                List.fold (fun (term,env,i) (r,(_,name),l,body) -> 
                    let nom = TNominal (at_tag i)
                    let term = nominal_term term nom (p r) name l body
                    term, add_ty env name nom, i+1
                    ) (Map.empty, env, top_env.nominals_next_tag) l
            let ty,nominals,i =
                List.fold (fun (ty', nominals, i) (_,(_,name),l,body) -> 
                    let x = eval_type' env l (fun env -> TJoinPoint(p (range_of_texpr body), ty env body))
                    Map.add name x ty', Map.add (at_tag i) {|body=x; name=name|} nominals, i+1
                    ) (Map.empty, Map.empty, top_env.nominals_next_tag) l
            AInclude {top_env_empty with term = term; ty = ty; nominals = nominals; nominals_next_tag=i}
        | FInl(_,(_,name),body) -> AInclude {top_env_empty with term = Map.add name (term env body |> process_term) Map.empty}
        | FRecInl l ->
            let l, env = 
                List.mapFold (fun env (_,(_,name),_ as x) -> 
                    let r = ref Unchecked.defaultof<_>
                    (x,r), add_term_rec env name (ERecursive r)
                    ) env l
            let term = 
                List.fold (fun top_env_term ((_,(_,name),body),r) ->
                    r := term env body |> process_term
                    Map.add name !r top_env_term
                    ) Map.empty l
            AInclude {top_env_empty with term = term}
        | FPrototype(r,(_,name),_,_,_) ->
            let i = at_tag top_env.prototypes_next_tag
            let r = p r
            let x = EForall(r,0,EPrototypeApply(r,i,TV 0)) |> process_term
            AInclude {top_env_empty with term = Map.add name x Map.empty; prototypes_next_tag = i.tag+1}
        | FInstance(_,(_,prot_id),(_,ins_id),body) ->
            AInclude {top_env_empty with prototypes_instances = Map.add (prot_id,ins_id) (term env body |> process_term) Map.empty}
        | FOpen(r,a,b) ->
            let x = module_open top_env env a b
            AOpen {top_env_empty with term=x.term.env; ty=x.ty.env}
    |}

let top_env_default =
    let rec f (m : PersistentHashMap<string,int>) = function
        | TyVar x -> TV m.[x.name] 
        | TyPrim x -> TPrim x
        | TyArray x -> TArray (f m x)
        | TyLayout(a,b) -> TLayout(f m a,b)
        | TyInl(a,b) -> TArrow(m.Count,f (m.Add(a.name,m.Count)) b)
        | _ -> failwith "Compiler error: The base type in Infer is not supported in the prepass yet."

    List.fold (fun (top_env : PrepassTopEnv) (k, x) ->
        {top_env with ty = Map.add k ((prepass -1 0 "<base_types>" top_env).base_type (f PersistentHashMap.empty x)) top_env.ty}
        ) top_env_empty Infer.base_types
    