module Spiral.PartEval.Prepass
open Spiral
open VSCTypes
open Spiral.Infer

type Id = int32
type ScopeEnv = {|free_vars : int []; stack_size : int|}
type Scope = {term : ScopeEnv; ty : ScopeEnv}
type Range = {path : string; range : VSCRange}

type Macro =
    | MText of string
    | MTerm of E
    | MType of T
    | MLitType of T
and TypeMacro =
    | TMText of string
    | TMType of T
    | TMLitType of T
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
    | EFun of Range * Id * E * T option
    | EFun' of Range * Scope * Id * E * T option
    | EForall of Range * Id * E
    | EForall' of Range * Scope * Id * E
    | ERecursiveFun' of Range * Scope * Id * E ref * T option
    | ERecursiveForall' of Range * Scope * Id * E ref
    | ERecursive of E ref // For global mutually recursive functions
    | EPatternRef of E ref
    | EJoinPoint of Range * E * T option * backend: (Range * string) option * name: string option
    | EJoinPoint' of Range * Scope * E * T option * backend: (Range * string) option * name: string option
    | EB of Range
    | EV of Id
    | ELit of Range * Tokenize.Literal
    | EDefaultLit of Range * string * T
    | ESymbol of Range * string
    | EType of Range * T
    | EApply of Range * E * E
    | EArray of Range * E list * T
    | ETypeApply of Range * E * T
    | ERecBlock of Range * (Id * E) list * on_succ: E
    | ERecordWith of Range * (Range * E) list * RecordWith list * RecordWithout list
    | EModule of Map<string, E>
    | EOp of Range * BlockParsing.Op * E list
    | EPatternMiss of E
    | ETypePatternMiss of T
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
    | EUnbox of Range * symbol: string * Id * body: E * on_succ: E * on_fail: E
    | EPairTest of Range * bind: Id * pat1: Id * pat2: Id * on_succ: E * on_fail: E
    | ESymbolTest of Range * string * bind: Id * on_succ: E * on_fail: E
    | ERecordTest of Range * PatRecordMember list * bind: Id * on_succ: E * on_fail: E
    | EAnnotTest of Range * T * bind: Id * on_succ: E * on_fail: E
    | EUnitTest of Range * bind: Id * on_succ: E * on_fail: E
    | ENominalTest of Range * T * bind: Id * pat: Id * on_succ: E * on_fail: E
    | ELitTest of Range * Tokenize.Literal * bind: Id * on_succ: E * on_fail: E
    | EDefaultLitTest of Range * string * T * bind: Id * on_succ: E * on_fail: E
    | ETypecase of Range * T * (T * E) list

and [<ReferenceEquality>] T =
    | TArrow' of Scope * Id * T
    | TArrow of Id * T
    | TJoinPoint' of Range * Scope * T
    | TJoinPoint of Range * T
    | TPatternRef of T ref
    | TB of Range
    | TLit of Range * Tokenize.Literal
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
    | TMetaV of Id

module Printable =
    type PMacro =
        | MText of string
        | MTerm of PE
        | MType of PT
        | MLitType of PT
    and PTypeMacro =
        | TMText of string
        | TMType of PT
        | TMLitType of PT
    and PRecordWith =
        | RSymbol of string * PE
        | RSymbolModify of string * PE
        | RVar of PE * PE
        | RVarModify of PE * PE
    and PRecordWithout =
        | WSymbol of string
        | WVar of PE
    and PPatRecordMember =
        | Symbol of string * Id
        | Var of PE * Id
    and [<ReferenceEquality>] PE =
        | EFun' of Scope * Id * PE * PT option
        | EForall' of Scope * Id * PE
        | ERecursiveFun' of Scope * Id * PE * PT option
        | ERecursiveForall' of Scope * Id * PE
        | ERecursive of PE
        | EJoinPoint of PE * PT option * string option
        | EJoinPoint' of Scope * PE * PT option * string option
        | EArray of PE list * PT
        | EFun of Id * PE * PT option
        | EForall of Id * PE
        | EB
        | EV of Id
        | ELit of Tokenize.Literal
        | EDefaultLit of string * PT
        | ESymbol of string
        | EType of PT
        | EApply of PE * PE
        | ETypeApply of PE * PT
        | ERecBlock of (Id * PE) list * on_succ: PE
        | ERecordWith of PE list * PRecordWith list * PRecordWithout list
        | EModule of Map<string, PE>
        | EOp of BlockParsing.Op * PE list
        | EPatternMiss of PE
        | ETypePatternMiss of PT
        | EAnnot of PE * PT
        | EIfThenElse of PE * PE * PE
        | EIfThen of PE * PE
        | EPair of PE * PE
        | ESeq of PE * PE
        | EHeapMutableSet of PE * PE list * PE
        | EReal of PE
        | EMacro of PMacro list * PT
        | EPrototypeApply of prototype_id: GlobalId * PT
        | EPatternMemo of PE
        | ENominal of PE * PT
        // Regular pattern matching
        | ELet of Id * PE * PE
        | EUnbox of Id * string * PE * PE * PE
        | EPairTest of bind: Id * pat1: Id * pat2: Id * on_succ: PE * on_fail: PE
        | ESymbolTest of string * bind: Id * on_succ: PE * on_fail: PE
        | ERecordTest of PPatRecordMember list * bind: Id * on_succ: PE * on_fail: PE
        | EAnnotTest of PT * bind: Id * on_succ: PE * on_fail: PE
        | EUnitTest of bind: Id * on_succ: PE * on_fail: PE
        | ENominalTest of PT * bind: Id * pat: Id * on_succ: PE * on_fail: PE
        | ELitTest of Tokenize.Literal * bind: Id * on_succ: PE * on_fail: PE
        | EDefaultLitTest of string * PT * bind: Id * on_succ: PE * on_fail: PE
        | ETypecase of PT * (PT * PE) list
        | EOmmitedRecursive
    and [<ReferenceEquality>] PT =
        | TArrow' of Scope * Id * PT
        | TArrow of Id * PT
        | TJoinPoint' of Scope * PT
        | TJoinPoint of PT
        | TB
        | TLit of Tokenize.Literal
        | TV of Id
        | TMetaV of Id
        | TPair of PT * PT
        | TFun of PT * PT
        | TRecord of Map<string,PT>
        | TModule of Map<string,PT>
        | TUnion of Map<string,PT> * BlockParsing.UnionLayout
        | TSymbol of string
        | TApply of PT * PT
        | TPrim of BlockParsing.PrimitiveType
        | TTerm of PE
        | TMacro of PTypeMacro list
        | TNominal of GlobalId
        | TArray of PT
        | TLayout of PT * BlockParsing.Layout

    let eval x =
        let recs = System.Collections.Generic.HashSet(HashIdentity.Reference)
        let rec term = function
            | E.ETypecase(r,a,b) -> ETypecase(ty a,b |> List.map (fun (a,b) -> ty a, term b))
            | E.EPatternRef a -> term !a
            | E.EFun'(_,a,b,c,d) -> EFun'(a,b,term c,Option.map ty d)
            | E.EForall'(_,a,b,c) -> EForall'(a,b,term c)
            | E.EArray(_,a,b) -> EArray(List.map term a,ty b)
            | E.ERecursiveFun'(_,a,b,c,d) -> 
                let r = !c
                let r = if recs.Add(r) then term r else EOmmitedRecursive
                ERecursiveFun'(a,b,r,Option.map ty d)
            | E.ERecursiveForall'(_,a,b,c) -> 
                let r = !c
                let r = if recs.Add(r) then term r else EOmmitedRecursive
                ERecursiveForall'(a,b,r)
            | E.ERecursive a -> 
                let r = !a
                if isNull (box r) then EOmmitedRecursive
                else
                    let r = if recs.Add(r) then term r else EOmmitedRecursive
                    ERecursive r
            | E.EJoinPoint(_,a,b,d,_) -> EJoinPoint(term a,Option.map ty b,Option.map snd d)
            | E.EJoinPoint'(_,a,b,c,d,_) -> EJoinPoint'(a,term b,Option.map ty c,Option.map snd d)
            | E.EFun(_,a,b,c) -> EFun(a,term b,Option.map ty c)
            | E.EForall(_,a,b) -> EForall(a,term b)
            | E.EB _ -> EB
            | E.EV i -> EV i
            | E.ELit(_,a) -> ELit(a)
            | E.EDefaultLit(_,a,b) -> EDefaultLit(a,ty b)
            | E.ESymbol(_,a) -> ESymbol a
            | E.EType(_,a) -> EType(ty a)
            | E.EApply(_,a,b) -> EApply(term a,term b)
            | E.ETypeApply(_,a,b) -> ETypeApply(term a,ty b)
            | E.ERecBlock(_,a,b) -> ERecBlock(List.map (fun (a,b) -> a, term b) a,term b)
            | E.ERecordWith(_,a,b,c) ->
                let a = a |> List.map (fun (_,a) -> term a)
                let b = b |> List.map (function
                    | RecordWith.RSymbol((_,a),b) -> RSymbol(a,term b)
                    | RecordWith.RSymbolModify((_,a),b) -> RSymbolModify(a,term b)
                    | RecordWith.RVar((_,a),b) -> RVar(term a,term b)
                    | RecordWith.RVarModify((_,a),b) -> RVarModify(term a,term b)
                    )
                let c = c |> List.map (function
                    | RecordWithout.WSymbol(_,a) -> WSymbol a
                    | RecordWithout.WVar(_,a) -> WVar(term a)
                    )
                ERecordWith(a,b,c)
            | E.EModule a -> EModule(Map.map (fun _ -> term) a)
            | E.EOp(_,a,b) -> EOp(a,List.map term b)
            | E.EPatternMiss a -> EPatternMiss(term a)
            | E.ETypePatternMiss a -> ETypePatternMiss(ty a)
            | E.EAnnot(_,a,b) -> EAnnot(term a,ty b)
            | E.EIfThenElse(_,a,b,c) -> EIfThenElse(term a,term b,term c)
            | E.EIfThen(_,a,b) -> EIfThen(term a,term b)
            | E.EPair(_,a,b) -> EPair(term a,term b)
            | E.ESeq(_,a,b) -> ESeq(term a,term b)
            | E.EHeapMutableSet(_,a,b,c) -> EHeapMutableSet(term a,List.map (snd >> term) b,term c)
            | E.EReal(_, a) -> EReal(term a)
            | E.EMacro(_,a,b) ->
                let a = a |> List.map (function
                    | Macro.MText a -> MText a
                    | Macro.MTerm a -> MTerm(term a)
                    | Macro.MType a -> MType(ty a)
                    | Macro.MLitType a -> MLitType(ty a)
                    )
                EMacro(a,ty b)
            | E.EPrototypeApply(_,a,b) -> EPrototypeApply(a,ty b)
            | E.EPatternMemo a -> EPatternMemo(term a)
            | E.ENominal(_,a,b) -> ENominal(term a,ty b)
            // Regular pattern matching
            | E.ELet(_,a,b,c) -> ELet(a,term b,term c)
            | E.EUnbox(_,q,a,b,c,d) -> EUnbox(a,q,term b,term c,term d)
            | E.EPairTest(_,a,b,c,d,e) -> EPairTest(a,b,c,term d,term e)
            | E.ESymbolTest(_,a,b,c,d) -> ESymbolTest(a,b,term c,term d)
            | E.ERecordTest(_,a,b,c,d) ->
                let a = a |> List.map (function
                    | PatRecordMember.Symbol((_,a),b) -> Symbol(a,b)
                    | PatRecordMember.Var((_,a),b) -> Var(term a,b)
                    )
                ERecordTest(a,b,term c,term d)
            | E.EAnnotTest(_,a,b,c,d) -> EAnnotTest(ty a,b,term c,term d)
            | E.EUnitTest(_,a,b,c) -> EUnitTest(a,term b,term c)
            | E.ENominalTest(_,a,b,c,d,e) -> ENominalTest(ty a,b,c,term d,term e)
            | E.ELitTest(_,a,b,c,d) -> ELitTest(a,b,term c,term d)
            | E.EDefaultLitTest(_,a,b,c,d,e) -> EDefaultLitTest(a,ty b,c,term d,term e)
        and ty = function
            | T.TPatternRef a -> ty !a
            | T.TArrow'(a,b,c) -> TArrow'(a,b,ty c)
            | T.TArrow(a,b) -> TArrow(a,ty b)
            | T.TJoinPoint'(_,a,b) -> TJoinPoint'(a,ty b)
            | T.TJoinPoint(_,a) -> TJoinPoint(ty a)
            | T.TB _ -> TB
            | T.TLit(_,x) -> TLit x
            | T.TV a -> TV a
            | T.TMetaV a -> TMetaV a
            | T.TPair(_,a,b) -> TPair(ty a,ty b)
            | T.TFun(_,a,b) -> TFun(ty a,ty b)
            | T.TRecord(_,a) -> TRecord(Map.map (fun _ -> ty) a)
            | T.TModule a -> TModule(Map.map (fun _ -> ty) a)
            | T.TUnion(_,(a,b)) -> TUnion(Map.map (fun _ -> ty) a,b)
            | T.TSymbol(_,a) -> TSymbol a
            | T.TApply(_,a,b) -> TApply(ty a, ty b)
            | T.TPrim a -> TPrim a
            | T.TTerm(_,a) -> TTerm(term a)
            | T.TMacro(_,a) -> 
                let a = a |> List.map (function
                    | TypeMacro.TMText a -> TMText a
                    | TypeMacro.TMType a -> TMType(ty a)
                    | TypeMacro.TMLitType a -> TMLitType(ty a)
                    )
                TMacro(a)
            | T.TNominal a -> TNominal a
            | T.TArray a -> TArray(ty a)
            | T.TLayout(a,b) -> TLayout(ty a,b)

        match x with
        | Choice1Of2(x,ret) -> ret (term x)
        | Choice2Of2(x,ret) -> ret (ty x)

open FSharpx.Collections
open BlockParsing
type PrepassTopEnv = {
    prototypes_next_tag : int
    prototypes_instances : Map<GlobalId * GlobalId,E>
    nominals_next_tag : int
    nominals : Map<GlobalId,{|body : T; name : string|}>
    term : Map<string,E>
    ty : Map<string,T>
    }

let top_env_empty = {
    prototypes_next_tag = 0
    prototypes_instances = Map.empty
    nominals_next_tag = 0
    nominals = Map.empty
    term = Map.empty
    ty = Map.empty
    }

let union small big = {
    prototypes_next_tag = max small.prototypes_next_tag big.prototypes_next_tag
    prototypes_instances = Map.foldBack Map.add small.prototypes_instances big.prototypes_instances
    nominals_next_tag = max small.nominals_next_tag big.nominals_next_tag
    nominals = Map.foldBack Map.add small.nominals big.nominals
    term = Map.foldBack Map.add small.term big.term
    ty = Map.foldBack Map.add small.ty big.ty
    }
    
let in_module m (a : PrepassTopEnv) =
    {a with 
        ty = Map.add m (TModule a.ty) Map.empty
        term = Map.add m (EModule a.term) Map.empty
        }

open System.Collections.Generic

type PropagatedVarsEnv = {|vars : Set<int>; range : (int * int) option|}
type PropagatedVars = {term : PropagatedVarsEnv; ty : PropagatedVarsEnv}

// Attaches scopes to all the nodes.
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
        | EFun' _ | EForall' _ | ERecursiveFun' _ | ERecursiveForall' _ | ERecursive _ | EJoinPoint' _ | EModule _ | ESymbol _ | ELit _ | EB _ -> empty
        | EPatternRef a -> term !a
        | EV i -> singleton_term i
        | EPrototypeApply(_,_,a) | EType(_,a) | ETypePatternMiss a | EDefaultLit(_,_,a) -> ty a
        | ESeq(_,a,b) | EPair(_,a,b) | EIfThen(_,a,b) | EApply(_,a,b) -> term a + term b
        | EArray(_,a,b) -> List.fold (fun s x -> s + term x) (ty b) a
        | ENominal(_,a,b) | EAnnot(_,a,b) | ETypeApply(_,a,b) -> term a + ty b
        | EForall(_,i,a) -> scope x (term a -. i)
        | EJoinPoint(_,a,t,_,_) -> scope x (match t with Some t -> term a + ty t | None -> term a)
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
        | EMacro(_,a,b) -> List.fold (fun s -> function MLitType x | MType x -> s + ty x | MTerm x -> s + term x | MText _ -> s) (ty b) a
        | EPatternMemo a -> Utils.memoize dict term a
        // Regular pattern matching
        | ELet(_,bind,body,on_succ) -> term on_succ - bind + term body
        | EUnbox(_,_,bind,body,on_succ,on_fail) -> term on_succ - bind + term body + term on_fail
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
        | ETypecase(_,a,b) -> 
            List.fold (fun s (a,b) -> 
                let a = ty a
                let mutable b = term b
                match a.ty.range with
                | Some(a,a') -> for i=a to a' do b <- b -. i
                | None -> ()
                s + a + b
                ) (ty a) b
    and ty = function
        | TJoinPoint' _ | TArrow' _ | TSymbol _ | TPrim _ | TNominal _ | TLit _ | TB _ -> empty
        | TPatternRef a -> ty !a
        | TV i -> singleton_ty i
        | TMetaV i -> {empty with ty = {|empty.ty with range = Some(i,i)|} }
        | TApply(_,a,b) | TPair(_,a,b) | TFun(_,a,b) -> ty a + ty b
        | TUnion(_,(a,_)) | TRecord(_,a) | TModule a -> Map.fold (fun s k v -> s + ty v) empty a
        | TTerm(_,a) -> term a
        | TMacro(_,a) -> a |> List.fold (fun s -> function TMText _ -> s | TMLitType x | TMType x -> s + ty x) empty
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
        {term = {|x.term with vars = fv.term|}; ty = {|x.ty with vars = Set.union fv.ty x.ty.vars|} }
    let subst env (x : obj) = match scope.TryGetValue(x) with true, v -> scope.[x] <- subst' env v | _ -> ()
    let rec term (env : ResolveEnv) x =
        let f = term env
        match x with
        | EForall' _ | EFun' _ | ERecursiveForall' _ | ERecursiveFun' _ | ERecursive _ | EJoinPoint' _ | EModule _ | EV _ | ESymbol _ | ELit _ | EB _ -> ()
        | EPatternRef a -> f !a
        | EDefaultLit(_,_,a) | EPrototypeApply(_,_,a) | EType(_,a) | ETypePatternMiss a -> ty env a
        | EJoinPoint(_,a,b,_,_) | EFun(_,_,a,b) -> subst env x; f a; Option.iter (ty env) b
        | EForall(_,_,a) -> subst env x; f a
        | ERecBlock(r,a,b) ->
            // Goes over all the functions in a recursive block, resolving them.
            // The reason why this is sound is because the outer blocks are progressively resolved as they go in.
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
                    {term = {|v.term with vars = x.term |}; ty = {|v.ty with vars=x.ty|} }
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
        | ENominal(_,a,b) | ETypeApply(_,a,b) | EAnnot(_,a,b) -> f a; ty env b
        | EOp(_,_,a) -> List.iter f a
        | EPatternMiss a | EReal(_,a) -> f a
        | EArray(_,a,b) -> List.iter f a; ty env b
        | EUnitTest(_,_,a,b) | ESymbolTest(_,_,_,a,b) | EPairTest(_,_,_,_,a,b) | ELitTest(_,_,_,a,b)
        | ELet(_,_,a,b) | EIfThen(_,a,b) | EPair(_,a,b) | ESeq(_,a,b) | EApply(_,a,b) -> f a; f b
        | EHeapMutableSet(_,a,b,c) -> f a; List.iter (snd >> f) b; f c
        | EUnbox(_,_,_,a,b,c) | EIfThenElse(_,a,b,c) -> f a; f b; f c
        | EMacro(_,a,b) ->
            a |> List.iter (function MLitType a | MType a -> ty env a | MTerm a -> f a | MText _ -> ())
            ty env b
        | EPatternMemo a -> Utils.memoize dict f a
        | ERecordTest(_,l,_,a,b) -> 
            l |> List.iter (function Symbol _ -> () | Var((_,a),_) -> f a)
            f a; f b
        | EDefaultLitTest(_,_,t,_,a,b) | ENominalTest(_,t,_,_,a,b) | EAnnotTest(_,t,_,a,b) -> ty env t; f a; f b
        | ETypecase(_,a,b) -> ty env a; b |> List.iter (fun (a,b) -> ty env a; term env b)

    and ty (env : ResolveEnv) x = 
        let f = ty env
        match x with
        | TJoinPoint' _ | TArrow' _ | TNominal _ | TPrim _ | TSymbol _ | TV _ | TMetaV _ | TLit _ | TB _ -> ()
        | TPatternRef a -> f !a
        | TArrow(_,a) -> subst env x; f a
        | TApply(_,a,b) | TFun(_,a,b) | TPair(_,a,b) -> f a; f b
        | TRecord(_,a) | TModule a | TUnion(_,(a,_)) -> Map.iter (fun _ -> f) a
        | TTerm(_,a) -> term env a
        | TMacro(_,a) -> a |> List.iter (function TMText _ -> () | TMLitType a | TMType a -> f a)
        | TJoinPoint(_,a) | TLayout(a,_) | TArray(a) -> f a

    match x with
    | Choice1Of2 x -> term Map.empty x
    | Choice2Of2 x -> ty Map.empty x

type LowerSubEnv = {|var : Map<int,int>; adj : int|}
type LowerEnv = {term : LowerSubEnv; ty : LowerSubEnv }
type LowerEnvRec = Map<int,LowerEnv -> E>
let lower (scope : Dictionary<obj,PropagatedVars>) x =
    let dict = Dictionary(HashIdentity.Reference)
    let scope (env : LowerEnv) x =
        let v = scope.[x]
        let fv v env = v |> Set.toArray |> Array.map (fun i -> Map.find i env)
        let sz = function Some(min',max') -> max' - min' + 1 | None -> 0
        let scope : Scope = {
            term = {|free_vars = fv v.term.vars env.term.var; stack_size = sz v.term.range|}
            ty = {|free_vars = fv v.ty.vars env.ty.var; stack_size = sz v.ty.range|}
            }

        let vars v = Set.fold (fun (s,i) x -> Map.add x i s,i+1) (Map.empty, 0) v |> fst
        let adj len = function Some(min',_) -> len - min' | None -> 0
        let env : LowerEnv = {
            term = {|var = vars v.term.vars; adj = adj scope.term.free_vars.Length v.term.range|}
            ty = {|var = vars v.ty.vars; adj = adj scope.ty.free_vars.Length v.ty.range|}
            }

        scope, env

    let adj_term (env : LowerEnv) i = 
        let i' = i + env.term.adj
        i', {env with term = {|env.term with var = Map.add i i' env.term.var|}}
    let adj_ty (env : LowerEnv) i =
        let i' = i + env.ty.adj
        i', {env with ty = {|env.ty with var = Map.add i i' env.ty.var|}}

    let rec term (env_rec : LowerEnvRec) (env : LowerEnv) x = 
        let f = term env_rec env
        let g = ty env_rec
        match x with
        | EForall' _ | EJoinPoint' _ | EFun' _ | ERecursiveForall' _ | ERecursiveFun' _ | ERecursive _ | EModule _ | ESymbol _ | ELit _ | EB _ -> x
        | EPatternRef a -> f !a
        | EFun(r,pat,body,t) -> 
            let scope, env = scope env x 
            let pat, env = adj_term env pat
            assert (scope.term.free_vars.Length = pat)
            EFun'(r,scope,pat,term env_rec env body,Option.map (g env) t)
        | EForall(r,pat,body) ->
            let scope, env = scope env x 
            let pat, env = adj_ty env pat
            assert (scope.ty.free_vars.Length = pat)
            EForall'(r,scope,pat,term env_rec env body)
        | EJoinPoint(r,body,t,q,name) ->
            let scope, env = scope env x 
            EJoinPoint'(r,scope,term env_rec env body,Option.map (g env) t,q,name)
        | EV i when 0 <= i -> EV env.term.var.[i]
        | EV i -> env_rec.[i] env
        | EDefaultLit(r,a,b) -> EDefaultLit(r,a,g env b)
        | EType(r,a) -> EType(r,g env a)
        | ETypePatternMiss a -> ETypePatternMiss(g env a)
        | EApply(r,a,b) -> EApply(r,f a,f b)
        | ETypeApply(r,a,b) -> ETypeApply(r,f a,g env b)
        | ENominal(r,a,b) -> ENominal(r,f a,g env b)
        | ERecBlock(r,a,b) ->
            let l,env_rec =
                List.mapFold (fun (env_rec : LowerEnvRec) (i,body) ->
                    let re = ref Unchecked.defaultof<_>
                    let eval env_rec = 
                        let _,env = scope env body
                        re :=
                            match body with
                            | EFun(_,i,body,_) ->
                                let _,env = adj_term env i
                                term env_rec env body
                            | EForall(_,i,body) -> 
                                let _,env = adj_ty env i
                                term env_rec env body
                            | _ -> failwith "Compiler error: Expected a fun or a forall."
                    let body env =
                        let scope,env = scope env body
                        match body with
                        | EFun(r,i,_,d) -> 
                            let i,_ = adj_term env i
                            ERecursiveFun'(r,scope,i,re,d)
                        | EForall(r,i,_) -> 
                            let i,_ = adj_ty env i
                            ERecursiveForall'(r,scope,i,re)
                        | _ -> failwith "Compiler error: Expected a fun or a forall."
                    eval,Map.add i body env_rec
                    ) env_rec a
            List.iter (fun eval -> eval env_rec) l
            term env_rec env b
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
        | EAnnot(r,a,b) -> EAnnot(r,f a,g env b)
        | EIfThenElse(r,a,b,c) -> EIfThenElse(r,f a,f b,f c)
        | EIfThen(r,a,b) -> EIfThen(r,f a,f b)
        | EArray(r,a,b) -> EArray(r,List.map f a, g env b)
        | EPair(r,a,b) -> EPair(r,f a,f b)
        | ESeq(r,a,b) -> ESeq(r,f a,f b)
        | EHeapMutableSet(r,a,b,c) -> EHeapMutableSet(r,f a,List.map (fun (a,b) -> a, f b) b,f c)
        | EPatternMiss a -> EPatternMiss(f a)
        | EReal(r,a) -> EReal(r,f a)
        | EMacro(r,a,b) -> 
            let a = a |> List.map (function
                | MText _ as x -> x
                | MLitType a -> MLitType(g env a)
                | MType a -> MType(g env a)
                | MTerm a -> MTerm(f a)
                )
            EMacro(r,a,g env b)
        | EPrototypeApply(r,a,b) -> EPrototypeApply(r,a,g env b)
        | EPatternMemo x -> Utils.memoize dict f x
        // Regular pattern matching
        | ELet(r,pat,body,on_succ) -> 
            let body = term env_rec env body
            let pat,env = adj_term env pat
            let on_succ = term env_rec env on_succ
            ELet(r,pat,body,on_succ)
        | EUnbox(r,q,pat,body,on_succ,on_fail) ->
            let body = term env_rec env body
            let on_fail = term env_rec env on_fail
            let pat,env = adj_term env pat
            let on_succ = term env_rec env on_succ
            EUnbox(r,q,pat,body,on_succ,on_fail)
        | EPairTest(r,i,pat1,pat2,on_succ,on_fail) -> 
            let on_fail = term env_rec env on_fail
            let i = env.term.var.[i]
            let pat1,env = adj_term env pat1
            let pat2,env = adj_term env pat2
            let on_succ = term env_rec env on_succ
            EPairTest(r,i,pat1,pat2,on_succ,on_fail)
        | ESymbolTest(r,a,i,on_succ,on_fail) -> 
            let on_fail = term env_rec env on_fail
            let i = env.term.var.[i]
            let on_succ = term env_rec env on_succ
            ESymbolTest(r,a,i,on_succ,on_fail)
        | ERecordTest(r,a,i,on_succ,on_fail) ->
            let on_fail = term env_rec env on_fail
            let b = env.term.var.[i]
            let a, env = 
                List.mapFold (fun env x ->
                    match x with
                    | Symbol(a,b) -> let b,env = adj_term env b in Symbol(a,b), env
                    | Var((r,a),b) -> let b,env = adj_term env b in Var((r,f a),b), env
                    ) env a
            ERecordTest(r,a,b,term env_rec env on_succ,on_fail)
        | EAnnotTest(r,a,i,on_succ,on_fail) -> EAnnotTest(r,g env a,env.term.var.[i],f on_succ,f on_fail)
        | ELitTest(r,a,i,on_succ,on_fail) -> ELitTest(r,a,env.term.var.[i],f on_succ,f on_fail)
        | EUnitTest(r,i,on_succ,on_fail) -> EUnitTest(r,env.term.var.[i],f on_succ,f on_fail)
        | ENominalTest(r,a,i,pat,on_succ,on_fail) ->
            let on_fail = term env_rec env on_fail
            let i = env.term.var.[i]
            let pat, env = adj_term env pat
            let on_succ = term env_rec env on_succ
            ENominalTest(r,g env a,i,pat,on_succ,on_fail)
        | EDefaultLitTest(r,a,b,i,on_succ,on_fail) -> EDefaultLitTest(r,a,g env b,env.term.var.[i],f on_succ,f on_fail)
        | ETypecase(r,a,b) -> 
            let b = b |> List.map (fun (a,b) -> 
                let metavars = Dictionary()
                let mutable env_case = env
                let a = 
                    ty' (Utils.memoize metavars (fun i ->
                        let i, env = adj_ty env_case i
                        env_case <- env
                        TMetaV i
                        )) env_rec env_case a
                a, term env_rec env_case b
                )
            ETypecase(r,g env a,b)
    and ty env_rec env x = ty' (fun _ -> failwith "Compiler error: TMetaV should not appear here.") env_rec env x
    and ty' case_tmetav env_rec env x =
        let f = ty' case_tmetav env_rec env
        match x with
        | TMetaV i -> case_tmetav i
        | TJoinPoint' _ | TArrow' _ | TNominal  _ | TPrim _ | TSymbol _ | TLit _ | TB _ as x -> x
        | TPatternRef a -> f !a
        | TJoinPoint(r,a) as x ->
            let scope, env = scope env x
            TJoinPoint'(r,scope,ty env_rec env a)
        | TArrow(a,b) as x ->  
            let scope, env = scope env x
            let a, env = adj_ty env a
            TArrow'(scope,a,ty env_rec env b)
        | TV i -> TV(env.ty.var.[i])
        | TPair(r,a,b) -> TPair(r,f a,f b)
        | TFun(r,a,b) -> TFun(r,f a,f b)
        | TRecord(r,a) -> TRecord(r,Map.map (fun _ -> f) a)
        | TModule a -> TModule(Map.map (fun _ -> f) a)
        | TUnion(r,(a,b)) -> TUnion(r,(Map.map (fun _ -> f) a,b))
        | TApply(r,a,b) -> TApply(r,f a,f b)
        | TTerm(r,a) -> TTerm(r,term env_rec env a)
        | TMacro(r,a) ->
            let a = a |> List.map (function 
                | TMText _ as x -> x
                | TMType a -> TMType(f a)
                | TMLitType a -> TMLitType(f a)
                )
            TMacro(r,a)
        | TArray(a) -> TArray(f a)
        | TLayout(a,b) -> TLayout(f a,b)
    let env : LowerEnv = {
        term = {|var = Map.empty; adj = 0|}
        ty = {|var = Map.empty; adj = 0|}
        }
    match x with
    | Choice1Of2(x,ret) -> ret (term Map.empty env x)
    | Choice2Of2(x,ret) -> ret (ty Map.empty env x)

type Env = {
    term : {| env : Map<string,E>; i : Id; i_rec : Id |}
    ty : {| env : Map<string,T>; i : Id |}
    }

let add_term (e : Env) k v = let term = e.term in {e with term = {|term with i = term.i+1; env = Map.add k v term.env|} }
let add_term_rec (e : Env) k v = let term = e.term in {e with term = {|term with i_rec = term.i_rec-1; env = Map.add k v term.env|} }
let add_ty (e : Env) k v = let ty = e.ty in {e with ty = {|ty with i = ty.i+1; env = Map.add k v ty.env|} }
let add_wildcard (e : Env) = let ty = e.ty in {e with ty = {|ty with i = ty.i+1|} }

let add_term_var (e : Env) k = e.term.i, add_term e k (EV e.term.i)
let fresh_term_var (e : Env) = e.term.i, (let term = e.term in {e with term = {|term with i = term.i+1|} })
let fresh_ty_var (e : Env) = e.ty.i, (let ty = e.ty in {e with ty = {|ty with i = ty.i+1|} })
let add_term_rec_var (e : Env) k = e.term.i_rec, add_term_rec e k (EV e.term.i_rec)
let add_ty_var (e : Env) k = e.ty.i, add_ty e k (TV e.ty.i)
let add_ty_wildcard (e : Env) = e.ty.i, add_wildcard e

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
    let p r = {path=path; range=r}
    let at_tag i = { package_id = package_id; module_id = module_id; tag = i }
    let v_term (env : Env) x = Map.tryFind x env.term.env |> Option.defaultWith (fun () -> top_env.term.[x])
    let v_ty (env : Env) x =  Map.tryFind x env.ty.env |> Option.defaultWith (fun () -> top_env.ty.[x])
    
    // The functions in this block are basically renaming string id to int ids, in addition to pattern compilation.
    let rec compile_pattern (id : Id) (env : Env) (clauses : (Pattern * RawExpr) list) =
        let mutable var_count = env.term.i
        let patvar () = let x = var_count in var_count <- var_count+1; x
        let loop (pat, on_succ) on_fail =
            let mutable dict = Map.empty
            let pat_refs_term = ResizeArray()
            //let pat_ref_term x = let re = ref Unchecked.defaultof<_> in pat_refs_term.Add(x,dict,re); EPatternRef re
            let pat_ref_term' x k =
                let re = ref Unchecked.defaultof<_>
                let r = k (EPatternRef re)
                pat_refs_term.Add(x,dict,re)
                r
            let pat_refs_ty = ResizeArray()
            let pat_ref_ty x = let re = ref Unchecked.defaultof<_> in pat_refs_ty.Add(x,dict,re); TPatternRef re
            let rec cp id pat on_succ on_fail =
                let v x =
                    match Map.tryFind x dict with
                    | Some x -> x
                    | None -> let v = patvar() in dict <- Map.add x v dict; v
                let step pat on_succ =
                    match pat with
                    | PatVar(_,x) -> v x, on_succ
                    | _ -> let id = patvar() in id, cp id pat on_succ on_fail
                match pat with
                | PatDefaultValue _ -> failwith "Compiler error: The default value should be filled."
                | PatE _ -> on_succ
                | PatB r -> EUnitTest(p r,id,on_succ,on_fail)
                | PatVar(r,a) -> ELet(p r,v a,EV id,on_succ)
                | PatAnnot(r,a,b) -> EAnnotTest(p r,pat_ref_ty b,id,cp id a on_succ on_fail,on_fail)
                | PatPair(r,a,b) -> 
                    // Evaling the b then a causes the call args to be rotated in join points during peval. 
                    // This is not a problem, but it might be surprising if you aren't aware why that is happening.
                    // Swapping the next two statements would fix it for pairs.
                    let b,on_succ = step b on_succ
                    let a,on_succ = step a on_succ
                    EPairTest(p r,id,a,b,on_succ,on_fail)
                | PatArray(r,a) ->
                    let r = p r
                    let ar_ids,on_succ = List.mapFoldBack step a on_succ
                    let a_length = List.length a
                    let on_succ,_ = 
                        List.foldBack (fun id' (on_succ,i) -> 
                            ELet(r,id',EOp(r,ArrayIndex,[EV id; ELit(r,Tokenize.LitInt32 i)]),on_succ), i-1
                            ) ar_ids (on_succ, a_length - 1)
                    let id_length = EOp(r,ArrayLength,[EType(r,TPrim UInt64T); EV id])
                    let pat_length = ELit(r,Tokenize.LitUInt64(uint64 a_length))
                    EIfThenElse(r,EOp(r,EQ,[id_length;pat_length]),on_succ,on_fail)
                | PatSymbol(r,a) -> ESymbolTest(p r,a,id,on_succ,on_fail)
                | PatRecordMembers(r,items) ->
                    let inject_vars = Dictionary(HashIdentity.Reference)
                    List.iter (function
                        | PatRecordMembersSymbol _ -> ()
                        | PatRecordMembersInjectVar((_,var),_) -> 
                            match dict.TryGetValue(var) with
                            | true, x -> inject_vars.[var] <- EV x
                            | _ -> inject_vars.[var] <- v_term env var
                        ) items
                    let binds, on_succ =
                        List.mapFoldBack (fun item on_succ ->
                            match item with
                            | PatRecordMembersSymbol((r,keyword),name) -> let arg, on_succ = step name on_succ in Symbol((p r,keyword),arg), on_succ
                            | PatRecordMembersInjectVar((r,var),name) -> let arg, on_succ = step name on_succ in Var((p r,inject_vars.[var]),arg), on_succ
                            ) items on_succ
                    ERecordTest(p r,binds,id,on_succ,on_fail)
                | PatOr(r,a,b) -> let on_succ = EPatternMemo on_succ in cp id a on_succ (cp id b on_succ on_fail)
                | PatAnd(r,a,b) -> let on_fail = EPatternMemo on_fail in cp id a (cp id b on_succ on_fail) on_fail
                | PatValue(r,x) -> ELitTest(p r,x,id,on_succ,on_fail)
                | PatWhen(r,p',e) -> pat_ref_term' e (fun e -> cp id p' (EIfThenElse(p r, e, on_succ, on_fail)) on_fail)
                | PatNominal(r,(_,a),l,b) -> 
                    let id', on_succ = step b on_succ
                    let a = List.fold (fun s (r',x) -> TApply(p (r +. r'),s,TSymbol(p r',x))) (v_ty env a) l
                    ENominalTest(p r,a,id,id',on_succ,on_fail)
                | PatFilledDefaultValue(r,a,b) -> EDefaultLitTest(p r,a,pat_ref_ty b,id,on_succ,on_fail)
                | PatDyn(r,a) -> let id' = patvar() in ELet(p r,id',EOp(p r,Dyn,[EV id]),cp id' a on_succ on_fail)
                | PatUnbox(r,q,a) -> let id' = patvar() in EUnbox(p r,q,id',EV id,cp id' a on_succ on_fail,on_fail)
            (pat_refs_term, pat_refs_ty), pat_ref_term' on_succ (fun on_succ -> cp id pat on_succ (EPatternMemo on_fail))

        let l, e = List.mapFoldBack loop clauses (EPatternMiss(EV id))
        l |> List.iter (fun (terms,tys) -> // The reason I am not evaling it in place is because of the var count. I need to deal with the patterns first before replacing the strings in the body.
            let env dict = {env with term = {|env.term with i=var_count; env=dict |> Map.fold (fun s k v -> Map.add k (EV v) s) env.term.env|} }
            terms |> Seq.iter (fun (a,dict,b) -> b := term (env dict) a)
            tys |> Seq.iter (fun (a,dict,b) -> b := ty (env dict) a)
            )
        e
    and pattern_match (env : Env) r body clauses =
        match clauses with
        | [PatVar(_,x), on_succ] ->
            let id,env = add_term_var env x
            ELet(r,id,body,term env on_succ)
        | _ ->
            let id,env = fresh_term_var env
            ELet(r,id,body,compile_pattern id env clauses)
    and pattern_function env r clauses annot =
        match clauses with
        | [PatVar(_,x), on_succ] ->
            let id,env = add_term_var env x
            EFun(r,id,term env on_succ,annot)
        | _ ->
            let id,env = fresh_term_var env
            EFun(r,id,compile_pattern id env clauses,annot)
    and ty env x = ty' (fun _ -> failwith "Compiler error: RawTMetaVar should not appear here.") env x
    and ty' case_metavar (env : Env) x =
        let f = ty' case_metavar env
        match x with
        | RawTMetaVar(_,name) -> case_metavar (Some name)
        | RawTWildcard _ -> case_metavar None
        | RawTForall _ -> failwith "Compiler error: Foralls are not allowed at the type level."
        | RawTB r -> TB (p r)
        | RawTLit (r, x) -> TLit(p r,x)
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
                | RawMacroTypeLitVar(r,a) -> TMLitType(f a)
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
        | RawLit(r,a) -> ELit(p r,a)
        | RawSymbol(r,a) -> ESymbol(p r,a)
        | RawType(r,a) -> EType(p r,ty env a)
        | RawMatch(r,a,b) -> pattern_match env (p r) (f a) b
        | RawFun(r,a) -> pattern_function env (p r) a None
        | RawAnnot(_,RawFun(r,a),t) -> pattern_function env (p r) a (Some (ty env t))
        | RawArray(r,a) -> failwith "Compiler error: The array should have been annotated in `fill` by prepass time."
        | RawAnnot(_,RawArray(r,a),b) -> EArray(p r,List.map f a,ty env b)
        | RawTypecase(r,a,b) ->
            let b = b |> List.map (fun (t,e) ->
                let metavars = Dictionary()
                let mutable env_case = env
                let t = 
                    let f (id,env) = env_case <- env; TMetaV id
                    ty' (function
                        | None -> add_ty_wildcard env_case |> f
                        | Some name -> Utils.memoize metavars (add_ty_var env_case >> f) name
                        ) env t
                t, term env_case e
                )
            ETypecase(p r,ty env a,b)
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
        | RawJoinPoint(r,q,a,name) -> EJoinPoint(p r,f a,None,Option.map (fun (r',w) -> p r',w) q,name)
        | RawAnnot(_,RawJoinPoint(r,q,a,name),b) -> EJoinPoint(p r,f a,Some (ty env b),Option.map (fun (r',w) -> p r',w) q,name)
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
                | RawMacroTypeLitVar(r,a) -> MLitType(ty env a)
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

    let nominal_term term nom r name l body bodyt =
        let t,i = l |> List.fold (fun (nom,i) _ -> TApply(r,nom,TV i), i+1) (nom,0)
        let rec wrap_foralls i x = if 0 < i then let i = i-1 in wrap_foralls i (EForall(r,i,x)) else process_term x
        match body with
        | RawTUnion(_,l,_) -> 
            Map.fold (fun term name body ->
                let body =
                    match body with
                    | RawTB _ -> ENominal(r,EPair(r, ESymbol(r,name), EB r),t)
                    | _ -> EFun(r,0,ENominal(r,EPair(r, ESymbol(r,name), EV 0),t),Some(TFun(r,bodyt,t)))
                Map.add name (wrap_foralls i body) term
                ) term l
        | _ ->
            let body =
                match body with
                | RawTB _ -> ENominal(r,EB r,t)
                | _ -> EFun(r,0,ENominal(r,EV 0,t),Some(TFun(r,bodyt,t)))
            Map.add name (wrap_foralls i body) term

    {|
    base_type = process_ty
    filled_top = fun x ->
        match x with
        | FType(_,(_,name),l,body) -> AInclude {top_env_empty with ty = Map.add name (eval_type' env l (fun env -> ty env body)) Map.empty}
        | FNominal(r,(_,name),l,body) ->
            let i = at_tag top_env.nominals_next_tag
            let nom = TNominal i
            let bodyt = eval_type' env l (fun env -> TJoinPoint(p (range_of_texpr body), ty env body))
            let term = nominal_term Map.empty nom (p r) name l body bodyt
            let ty = Map.add name nom Map.empty
            let nominals = Map.add i {|body=bodyt; name=name|} Map.empty
            AInclude {top_env_empty with term = term; ty = ty; nominals = nominals; nominals_next_tag=i.tag+1}
        | FNominalRec l ->
            let env,_ = 
                List.fold (fun (env,i) (r,(_,name),l,body) -> 
                    add_ty env name (TNominal (at_tag i)), i+1
                    ) (env, top_env.nominals_next_tag) l
            let term,ty,nominals,i =
                List.fold (fun (term,ty', nominals, i) (r,(_,name),l,body) -> 
                    let at_tag_i = at_tag i
                    let nom = TNominal at_tag_i
                    let bodyt = eval_type' env l (fun env -> TJoinPoint(p (range_of_texpr body), ty env body))
                    let term = nominal_term term nom (p r) name l body bodyt
                    term,Map.add name nom ty', Map.add at_tag_i {|body=bodyt; name=name|} nominals, i+1
                    ) (Map.empty, Map.empty, Map.empty, top_env.nominals_next_tag) l
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
    