module Spiral.Prepass
open Infer

type Id = int32
type FreeVarsEnv = {|free_vars : int []; stack_size : int|}
type FreeVars = {term : FreeVarsEnv; ty : FreeVarsEnv}
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
and [<ReferenceEquality>] E =
    | EFun' of Range * FreeVars * Id * E * T option
    | EForall' of Range * FreeVars * Id * E
    | EJoinPoint' of Range * FreeVars * E * T option
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
    | ERecordWith of Range * E list * RecordWith list * RecordWithout list
    | ERecord of Map<string, E> // Used for modules.
    | EOp of Range * BlockParsing.Op * E list
    | EPatternMiss
    | EAnnot of Range * E * T
    | EIfThenElse of Range * E * E * E
    | EIfThen of Range * E * E
    | EPair of Range * E * E
    | ESeq of Range * E * E
    | EHeapMutableSet of Range * E * E
    | EReal of Range * E
    | EMacro of Range * Macro list * T
    | EPrototypeApply of Range * prototype_id: int * T
    | EPatternMemo of E
    | ENominal of Range * E * T
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
and [<ReferenceEquality>] T =
    | TArrow' of Range * FreeVars * Id * T
    | TArrow of Range * Id * T
    | TJoinPoint' of Range * FreeVars * T
    | TJoinPoint of Range * T
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
    | TNominal of Id
    | TArray of Range * T
    | TLayout of Range * T * BlockParsing.Layout

open FSharpx.Collections

open BlockParsing
type TopEnv = {
    prototypes : Map<int,E> PersistentVector
    nominals : {|body : T; name : string|} PersistentVector
    term : Map<string,E>
    ty : Map<string,T>
    }

open System.Collections.Generic

type PropagatedVarsEnv = {| vars : Set<int>; max : int ; min : int |}
type PropagatedVars = {term : PropagatedVarsEnv; ty : PropagatedVarsEnv}

let inline propagate x =
    let dict = Dictionary(HashIdentity.Reference)
    let (+) (a : PropagatedVars) (b : PropagatedVars) : PropagatedVars = {
        term = {|vars = Set.union a.term.vars b.term.vars; max = max a.term.max b.term.max; min = min a.term.min b.term.min |} 
        ty = {|vars = Set.union a.ty.vars b.ty.vars; max = max a.ty.max b.ty.max; min = min a.ty.min b.ty.min |} 
        }
    let (-) (a : PropagatedVars) i = {a with term = {|vars = Set.remove i a.term.vars; max = max i a.term.max; min = if 0 <= i then min i a.term.min else a.term.min |} } // Recursive vars are negative and get inlined so they should be ignored when calculating the range of a scope.
    let (-.) (a : PropagatedVars) i = {a with ty = {|vars = Set.remove i a.ty.vars; max = max i a.ty.max; min = if 0 <= i then min i a.ty.min else a.ty.min |} }
    let empty' term ty = let f x = {|vars = x; max=0; min=System.Int32.MaxValue|} in {term = f term; ty = f ty}
    let empty = empty' Set.empty Set.empty
    let singleton_term i = empty' (Set.singleton i) Set.empty
    let singleton_ty i = empty' Set.empty (Set.singleton i)

    let scope_dict = Dictionary<obj,_>(HashIdentity.Reference)
    let scope x (v : PropagatedVars) = scope_dict.Add(x,v); empty' v.term.vars v.ty.vars
    let rec term x =
        let singleton = singleton_term
        match x with
        | EForall' | EJoinPoint' | EFun' | EPatternMiss | ERecord | ERecursive | ESymbol | ELit | EB -> empty
        | EV i -> singleton i
        | EPrototypeApply(_,_,a) | EType(_,a) | EDefaultLit(_,_,a) -> ty a
        | EHeapMutableSet(_,a,b) | ESeq(_,a,b) | EPair(_,a,b) | EIfThen(_,a,b) | EApply(_,a,b) -> term a + term b
        | ENominal(_,a,b) | EAnnot(_,a,b) | ETypeApply(_,a,b) -> term a + ty b
        | EForall(_,i,a) -> scope x (term a - i)
        | EJoinPoint(_,a,t) -> scope x (match t with Some t -> term a + ty t | None -> term a)
        | EFun(_,i,a,t) -> scope x (term a - i + (match t with Some t -> term a + ty t | None -> term a))
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
        | EIfThenElse(_,a,b,c) -> term a + term b + term c
        | EReal(_,a) -> term a
        | EMacro(_,a,b) -> List.fold (fun s -> function MType x -> s + ty x | MTerm x -> s + term x | MText -> s) (ty b) a
        | EPatternMemo a -> Utils.memoize dict term a
        // Regular pattern matching
        | ELet(_,a,b,c) -> (term b - a) + term c
        | EPairTest(_,bind,pat1,pat2,on_succ,on_fail) -> singleton bind + (term on_succ - pat1 - pat2) + term on_fail
        | ESymbolTest(_,_,bind,on_succ,on_fail) 
        | EUnitTest(_,bind,on_succ,on_fail) 
        | ELitTest(_,_,bind,on_succ,on_fail) -> singleton bind + term on_succ + term on_fail
        | ERecordTest(_,a,bind,on_succ,on_fail) ->
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
        | TJoinPoint' | TArrow' | TSymbol | TPrim | TNominal | TUnit -> empty
        | TV i -> singleton_ty i
        | TApply(_,a,b) | TPair(_,a,b) | TFun(_,a,b) -> ty a + ty b
        | TUnion(_,a) | TRecord(_,a) -> Map.fold (fun s k v -> s + ty v) empty a
        | TTerm(_,a) -> term a
        | TMacro(_,a) -> a |> List.fold (fun s -> function TMText -> s | TMType x -> s + ty x) empty
        | TArrow(r,i,a) as x -> scope x (ty a -. i)
        | TJoinPoint(_,a) as x -> scope x (ty a)
        | TArray(_,a) | TLayout(_,a,_) -> ty a
    
    let _ = match x with Choice1Of2 x -> term x | Choice2Of2 x -> ty x
    scope_dict

type ResolveEnv = Map<int,Set<Id>>
let resolve_recursive_free_vars env =
    Map.fold (fun (env : ResolveEnv) k v ->
        let has_visited = HashSet()
        let rec f s k v = if has_visited.Add(k) then Set.fold (fun s k -> if 0 < k then f s k env.[k] else Set.add k s) s v else s
        Map.add k (f Set.empty k v) env
        ) env env

let inline resolve (scope : Dictionary<obj,PropagatedVars>) x =
    let dict = Dictionary(HashIdentity.Reference)
    let subst' (env : ResolveEnv) (x : PropagatedVars) : PropagatedVars = 
        let f s x = 
            if x < 0 then 
                match Map.tryFind x env with 
                | Some x -> s + x 
                | None -> Set.add x s
            else Set.add x s
        let fv_term = Set.fold f Set.empty x.term.vars
        {x with term = {|x.term with vars = fv_term|} }
    let subst env (x : obj) = match scope.TryGetValue(x) with true, v -> scope.[x] <- subst' env v | _ -> ()
    let rec term (env : ResolveEnv) x =
        let f = term env
        match x with
        | EForall' | EFun' | EJoinPoint' | EPatternMiss | ERecord | EV | ERecursive | ESymbol | EDefaultLit | ELit | EB -> ()
        | EPrototypeApply(_,_,a) | EType(_,a) -> ty env a
        | EJoinPoint(_,a,b) | EFun(_,_,a,b) -> subst env x; f a; Option.iter (ty env) b
        | EForall(_,_,a) -> subst env x; f a
        | ERecBlock(r,a,b) ->
            let l =
                List.fold (fun s (id,body) ->
                    let x = subst' env scope.[body]
                    Map.add id x.term.vars s
                    ) Map.empty a
                |> resolve_recursive_free_vars
            let env = Map.foldBack Map.add l env
            a |> List.iter (fun (id,body) -> 
                Utils.remove scope (body :> _)
                    (fun v -> term env body; scope.[body] <- {v with term = {|v.term with vars = env.[id]|} })
                    (fun () -> failwith "impossible")
                )
            term env b
        | ERecordWith(_,a,b,c) ->
            List.iter f a
            b |> List.iter (function
                | RSymbolModify(_,a) | RSymbol(_,a) -> f a
                | RVarModify((_,a),b) | RVar((_,a),b) -> f a; f b)
            c |> List.iter (function 
                | WSymbol -> ()
                | WVar(_,a) -> f a)
        | ENominal(_,a,b) | ETypeLet(_,_,b,a) | ETypeApply(_,a,b) | EAnnot(_,a,b) -> f a; ty env b
        | EOp(_,_,a) -> List.iter f a
        | EReal(_,a) -> f a
        | ETypePairTest(_,_,_,_,a,b) | ETypeFunTest(_,_,_,_,a,b) | ETypeRecordTest(_,_,_,a,b) | ETypeApplyTest(_,_,_,_,a,b) | ETypeArrayTest(_,_,_,a,b)
        | EUnitTest(_,_,a,b) | ESymbolTest(_,_,_,a,b) | EPairTest(_,_,_,_,a,b) | ELitTest(_,_,_,a,b)
        | ELet(_,_,a,b) | EIfThen(_,a,b) | EPair(_,a,b) | ESeq(_,a,b) | EHeapMutableSet(_,a,b) | EApply(_,a,b) -> f a; f b
        | EIfThenElse(_,a,b,c) -> f a; f b; f c
        | EMacro(_,a,b) ->
            a |> List.iter (function MType a -> ty env a | MTerm a -> f a | MText -> ())
            ty env b
        | EPatternMemo a -> Utils.memoize dict f a
        | ERecordTest(_,l,_,a,b) -> 
            l |> List.iter (function Symbol -> () | Var((_,a),_) -> f a)
            f a; f b
        | ETypeEq(_,t,_,a,b) | EDefaultLitTest(_,_,t,_,a,b) | ENominalTest(_,t,_,_,a,b) | EAnnotTest(_,t,_,a,b) -> ty env t; f a; f b

    and ty (env : ResolveEnv) x = 
        let f = ty env
        match x with
        | TJoinPoint' | TArrow' | TNominal | TPrim | TSymbol | TV | TUnit -> ()
        | TArrow(_,_,a) -> subst env x; f a
        | TApply(_,a,b) | TFun(_,a,b) | TPair(_,a,b) -> f a; f b
        | TRecord(_,a) | TUnion(_,a) -> Map.iter (fun _ -> f) a
        | TTerm(_,a) -> term env a
        | TMacro(_,a) -> a |> List.iter (function TMText -> () | TMType a -> f a)
        | TJoinPoint(_,a) | TLayout(_,a,_) | TArray(_,a) -> f a

    match x with
    | Choice1Of2 x -> term Map.empty x
    | Choice2Of2 x -> ty Map.empty x

type LowerSubEnv<'x> = {|var : Map<int,'x>; adj : int|}
type LowerEnv = {term : LowerSubEnv<E>; ty : LowerSubEnv<T> }
let inline lower (scope : Dictionary<obj,PropagatedVars>) x =
    let dict = Dictionary(HashIdentity.Reference)
    let scope (env : LowerEnv) x =
        let v = scope.[x]
        let fv_term =
            v.term.vars |> Set.toArray 
            |> Array.map (fun i ->
                match Map.tryFind i env.term.var with
                | Some(EV i) -> i
                | None -> i + env.term.adj
                | Some _ -> failwith "Compiler error: Expected a variable in the environment."
                ) 
        let stack_size_term = max 0 (v.term.max - v.term.min)

        let fv_ty = 
            v.ty.vars |> Set.toArray 
            |> Array.map (fun i ->
                match Map.tryFind i env.ty.var with
                | Some(TV i) -> i
                | None -> i + env.term.adj
                | Some _ -> failwith "Compiler error: Expected a variable in the environment."
                ) 
        let stack_size_ty = max 0 (v.ty.max - v.ty.min)
        let free_vars : FreeVars = {
            term = {|free_vars = fv_term; stack_size = stack_size_term|}
            ty = {|free_vars = fv_ty; stack_size = stack_size_ty|}
            }

        let var_term,_ = Array.fold (fun (s,i) x -> Map.add x (EV i) s,i+1) (Map.filter (fun k _ -> k < 0) env.term.var, 0) fv_term
        let adj_term = if v.term.min = System.Int32.MaxValue then 0 else fv_term.Length - v.term.min

        let var_ty,_ = Array.fold (fun (s,i) x -> Map.add x (TV i) s,i+1) (Map.empty, 0) fv_ty
        let adj_ty = if v.ty.min = System.Int32.MaxValue then 0 else fv_ty.Length - v.ty.min

        let env : LowerEnv = {
            term = {|var = var_term; adj = adj_term|}
            ty = {|var = var_ty; adj = adj_ty|}
            }

        free_vars, env

    let adj' (env : LowerEnv) i = i + env.term.adj

    let rec term (env : LowerEnv) x = 
        let f = term env
        let adj = adj' env
        match x with
        | EForall' | EJoinPoint' | EFun' | EPatternMiss | ERecord | ERecursive | ESymbol | ELit | EB -> x
        | EFun(r,a,b,c) -> 
            let free_vars, env = scope env x 
            EFun'(r,free_vars,adj' env a,term env b,Option.map (ty env) c)
        | EForall(r,a,b) ->
            let free_vars, env = scope env x 
            EForall'(r,free_vars,adj' env a,term env b)
        | EJoinPoint(r,a,b) ->
            let free_vars, env = scope env x 
            EJoinPoint'(r,free_vars,term env a,Option.map (ty env) b)
        | EV i -> match Map.tryFind i env.term.var with Some i -> i | None -> EV(adj i)
        | EDefaultLit(r,a,b) -> EDefaultLit(r,a,ty env b)
        | EType(r,a) -> EType(r,ty env a)
        | EApply(r,a,b) -> EApply(r,f a,f b)
        | ETypeApply(r,a,b) -> ETypeApply(r,f a,ty env b)
        | ENominal(r,a,b) -> ENominal(r,f a,ty env b)
        | ERecBlock(r,a,b) ->
            let add_term k v (env : LowerEnv) = { env with term = {|env.term with var = Map.add k v env.term.var|} }
            let a, env =
                List.mapFold (fun env (id,body) ->
                    let re = ref Unchecked.defaultof<_>
                    let body env = let x = term env body in re := x; id, x
                    body, add_term id (ERecursive re) env
                    ) env a
            let env = List.fold (fun env x -> let id,body = x env in add_term id body env) env a
            term env b
        | ERecordWith(r,a,b,c) ->
            let a = List.map f a
            let b = b |> List.map (function
                | RSymbol(a,b) -> RSymbol(a,f b)
                | RSymbolModify(a,b) -> RSymbolModify(a,f b)
                | RVar((r,a),b) -> RVar((r,f a),f b)
                | RVarModify((r,a),b) -> RVarModify((r,f a),f b)
                )
            let c = c |> List.map (function
                | WSymbol as x -> x
                | WVar(r,a) -> WVar(r,f a)
                )
            ERecordWith(r,a,b,c)
        | EOp(r,a,b) -> EOp(r,a,List.map f b)
        | EAnnot(r,a,b) -> EAnnot(r,f a,ty env b)
        | EIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | EIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | EPair(r,a,b) -> EPair(r,f a,f b)
        | ESeq(r,a,b) -> ESeq(r,f a,f b)
        | EHeapMutableSet(r,a,b) -> EHeapMutableSet(r,f a,f b)
        | EReal(r,a) -> EReal(r,f a)
        | EMacro(r,a,b) -> 
            let a = a |> List.map (function
                | MText as x -> x
                | MType a -> MType(ty env a)
                | MTerm a -> MTerm(f a)
                )
            EMacro(r,a,ty env b)
        | EPrototypeApply(r,a,b) -> EPrototypeApply(r,a,ty env b)
        | EPatternMemo x -> Utils.memoize dict f x
        // Regular pattern matching
        | ELet(r,a,b,c) -> ELet(r,adj a,f b,f c)
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
        let adj = adj' env
        match x with
        | TJoinPoint' | TArrow' | TNominal  | TPrim | TSymbol | TUnit -> x
        | TJoinPoint(r,a) ->
            let free_vars, env = scope env x 
            TJoinPoint'(r,free_vars,ty env a)
        | TArrow(r,a,b) ->  
            let free_vars, env = scope env a
            TArrow'(r,free_vars,adj' env a,ty env b)
        | TV i -> match Map.tryFind i env.ty.var with Some i -> i | None -> TV(adj i)
        | TPair(r,a,b) -> TPair(r,f a,f b)
        | TFun(r,a,b) -> TFun(r,f a,f b)
        | TRecord(r,a) -> TRecord(r,Map.map (fun _ -> f) a)
        | TUnion(r,a) -> TUnion(r,Map.map (fun _ -> f) a)
        | TApply(r,a,b) -> TApply(r,f a,f b)
        | TTerm(r,a) -> TTerm(r,term env a)
        | TMacro(r,a) ->
            let a = a |> List.map (function 
                | TMText as x -> x
                | TMType a -> TMType(f a)
                )
            TMacro(r,a)
        | TArray(r,a) -> TArray(r,f a)
        | TLayout(r,a,b) -> TLayout(r,f a,b)
    let env : LowerEnv = {
        term = {|var = Map.empty; adj = 0|}
        ty = {|var = Map.empty; adj = 0|}
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

let process_term (x : E) =
    let scope = propagate (Choice1Of2 x)
    resolve scope (Choice1Of2 x)
    lower scope (Choice1Of2(x,id))

let process_ty (x : T) =
    let scope = propagate (Choice2Of2 x)
    resolve scope (Choice2Of2 x)
    lower scope (Choice2Of2(x,id))

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

            cp id pat on_succ (EPatternMemo on_fail)
        List.foldBack loop l EPatternMiss
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

            cp id pat on_succ (EPatternMemo on_fail)
        List.foldBack loop l EPatternMiss
    and typecase (env : Env) r body clauses =
        let id, env = fresh_ty_var env
        let l = clauses |> List.map (fun (pat,on_succ) -> let _,env as x = make_compile_typecase_env env pat in x,pat,term env on_succ)
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
            | TRecord(_,a') & a, TSymbol(_,b') & b ->
                match Map.tryFind b' a' with
                | Some x -> x
                | None -> TApply(r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
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
        | RawSymbolCreate(r,a) -> ESymbol(r,a)
        | RawType(r,a) -> EType(r,ty env a)
        | RawMatch(r,a,b) -> pattern_match env r (f a) b
        | RawFun(r,a) -> pattern_function env r a None
        | RawAnnot(_,RawFun(r,a),t) -> pattern_function env r a (Some (ty env t))
        | RawTypecase(r,a,b) -> typecase env r (ty env a) b
        | RawFilledForall(r,name,b)
        | RawForall(r,((_,(name,_)),_),b) -> 
            let id, env = add_ty_var env name
            EForall(r,id,term env b)
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
        | RawJoinPoint(r,a) -> EJoinPoint(r,f a,None)
        | RawAnnot(_,RawJoinPoint(r,a),b) -> EJoinPoint(r,f a,Some (ty env b))
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
            let env : Env = {
                term = {|env.term with env = Map.foldBack Map.add a env.term.env|}
                ty = {|env.ty with env = Map.foldBack Map.add b env.ty.env|}
                }
            term env on_succ
        | RawApply(r,a,b) ->
            match f a, f b with
            | ERecord a' & a, ESymbol(_,b') & b ->
                match Map.tryFind b' a' with
                | Some x -> x
                | None -> EApply(r,a,b) // TODO: Will be an error during partial evaluation time. Could be substituted for an exception here, but I do not want to have errors during the prepass.
            | a,EType(_,b) -> ETypeApply(r,a,b)
            | a,b -> EApply(r,a,b)
        | RawIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | RawIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | RawPairCreate(r,a,b) -> EPair(r,f a,f b)
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
        TArrow(r,id,on_succ env)
    let eval_type' env l body = List.foldBack eval_type l body env |> process_ty
    match expr with
    | FType(_,(_,name),l,body) -> {top_env with ty = Map.add name (eval_type' env l (fun env -> ty env body)) top_env.ty}
    | FNominal l ->
        let term,env,_ = 
            List.fold (fun (term,env,i) (r,(_,name),l,body) -> 
                let nom = TNominal i
                let term = 
                    let t,i = l |> List.fold (fun (nom,i) _ -> TApply(r,nom,TV i), i+1) (nom,0)
                    let rec wrap_foralls i x = if 0 < i then let i = i-1 in wrap_foralls i (EForall(r,i,x)) else process_term x
                    match body with
                    | RawTUnion(_,l) -> Map.fold (fun term name _ -> Map.add name (wrap_foralls i (EFun(r,0,ENominal(r,EPair(r, ESymbol(r,name), EV 0),t),Some t))) term) term l
                    | _ -> Map.add name (wrap_foralls i (EFun(r,0,ENominal(r,EV 0,t),Some t))) term
                term, add_ty env name nom, i+1
                ) (top_env.term, env, top_env.nominals.Length) l
        let ty,nominals =
            List.fold (fun (ty', nominals) (_,(_,name),l,body) -> 
                let x = eval_type' env l (fun env -> TJoinPoint(range_of_texpr body, ty env body))
                Map.add name x ty', PersistentVector.conj {|body=x; name=name|} nominals
                ) (top_env.ty, top_env.nominals) l
        {top_env with term = term; ty = ty; nominals = nominals}
    | FInl(_,(_,name),body) -> {top_env with term = Map.add name (term env body |> process_term) top_env.term}
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
                ) top_env.term l
        {top_env with term = term}
    | FPrototype(r,(_,name),_,_,_) ->
        let id,env = add_ty_var env name
        let x = EForall(r,id,EPrototypeApply(r,top_env.prototypes.Length,TV id)) |> process_term
        {top_env with term = Map.add name x top_env.term; prototypes = PersistentVector.conj Map.empty top_env.prototypes}
    | FInstance(_,(_,prot_id),(_,ins_id),l,body) ->
        let env = l |> List.fold (fun s x -> add_ty_var s (typevar_name x) |> snd) env
        let body = term env body |> process_term
        {top_env with prototypes = PersistentVector.update prot_id (Map.add ins_id body top_env.prototypes.[prot_id]) top_env.prototypes}