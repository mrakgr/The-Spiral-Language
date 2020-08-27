module Spiral.Infer

open Spiral.Config

type [<ReferenceEquality>] 'a ref' = {mutable contents' : 'a}
type TT =
    | KindType
    | KindConstraint
    | KindFun of TT * TT
    | KindMetavar of TT option ref'

type ConstraintId =
    | CINumber // * -> /

let id_to_kind x = 
    let (^) a b = KindFun(a,b) // ^ is right assoc
    match x with
    | CINumber -> KindType ^ KindConstraint

type Constraint =
    | CNumber

and [<ReferenceEquality>] Var = {
    scope : int
    constraints : Constraint Set // Must be stated up front and needs to be static in forall vars
    kind : TT // Is not supposed to have metavars.
    mutable name : string // Is what gets printed.
    }

and [<ReferenceEquality>] MVar = {
    mutable scope : int
    mutable constraints : Constraint Set // Must be stated up front and needs to be static in forall vars
    kind : TT // Has metavars, and so is mutable.
    }

and T =
    | TyB
    | TyPrim of PrimitiveType
    | TySymbol of string
    | TyPair of T * T
    | TyRecord of Map<string, T>
    | TyFun of T * T
    | TyArray of T
    | TyHigherOrder of int * TT
    | TyConstraint of ConstraintId
    | TyApply of T * T * TT // Regular type functions (TyInl) get reduced, while this represents the staged reduction of nominals.
    | TyInl of Var * T
    | TyForall of Var * T
    | TyMetavar of MVar * T option ref
    | TyVar of Var

type TypeError =
    | KindError of TT * TT
    | KindError' of T * T
    | RecordKeyNotFound of string
    | ExpectedSymbolAsRecordKey of T
    | UnboundVariable
    | UnboundModule
    | ModuleIndexFailedInOpen
    | ExpectedSymbolAsUnionKey
    | DuplicateKeyInUnion
    | TermError of T * T
    | ForallVarScopeError of string * T * T
    | ForallVarConstraintError of string * T * T
    | ForallMetavarScopeError of string * T * T
    | MetavarsNotAllowedInRecordWith
    | ExpectedRecord of T
    | ExpectedRecordAsResultOfIndex of string
    | RecordIndexFailed of string
    | ExpectedSymbolInRecordWith
    | RealFunctionInTopDown
    | RealNominalInTopDownPattern
    | MissingRecordFieldsInPattern of string list
    | CasePatternNotFoundForType of int
    | CasePatternNotFound of string
    | CannotInferCasePatternFromTermInEnv of T
    | NominalInPatternUnbox of int
    | TypeInGlobalEnvIsNotNominal of T
    | UnionInPatternNominal of int
    | ConstraintError of Constraint * T
    | ExpectedAnnotation
    | ExpectedSinglePattern
    | RecursiveAnnotationHasMetavars

let inline go' x link next = let x = next x in link.contents' <- Some x; x
let rec visit_tt = function
    | KindMetavar({contents'=Some x} & link) -> go' x link visit_tt
    | a -> a

let inline go x link next = let x = next x in link := Some x; x
let rec visit_t = function
    | TyMetavar(_,{contents=Some x} & link) -> go x link visit_t
    | a -> a

open Spiral.BlockParsing
exception TypeErrorException of (Range * TypeError) list

let rec tt = function
    | TyHigherOrder(_,x) | TyApply(_,_,x) | TyMetavar({kind=x},_) | TyVar({kind=x}) -> x
    | TyB | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyPair _ | TySymbol _ | TyArray _ -> KindType
    | TyInl(v,a) -> KindFun(v.kind,tt a)
    | TyConstraint id -> id_to_kind id

let rec typevar = function
    | RawKindWildcard | RawKindStar -> KindType
    | RawKindFun(a,b) -> KindFun(typevar a, typevar b)

let rec metavars = function
    | RawTVar _ | RawTTerm _ | RawTPrim _ | RawTWildcard _ | RawTB _ | RawTSymbol _ -> Set.empty
    | RawTMetaVar(_,a) -> Set.singleton a
    | RawTForall(_,(_,(_,_)),a) | RawTArray(_,a) -> metavars a
    | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b) -> metavars a + metavars b
    | RawTRecord(_,l) -> Map.fold (fun s _ v -> s + metavars v) Set.empty l

type HigherOrderCases =
    | HOCUnion of Var list * Map<string,T>
    | HOCNominal of Var list * T

open FSharpx.Collections
type TopEnv = {
    hoc : HigherOrderCases PersistentVector
    ty : Map<string,T>
    term : Map<string,T>
    }
type Env = { ty : Map<string,T>; term : Map<string,T> }

let module_open (top_env : Env) (r : Range) b l =
    let tryFind env x =
        match Map.tryFind x env.term, Map.tryFind x env.ty with
        | Some (TyRecord a), Some (TyRecord b) -> ValueSome {term=a; ty=b}
        | _ -> ValueNone
    match tryFind top_env b with
    | ValueNone -> Error(r, UnboundModule)
    | ValueSome env ->
        let rec loop env = function
            | (r,x) :: x' ->
                match tryFind env x with
                | ValueSome env -> loop env x'
                | _ -> Error(r, ModuleIndexFailedInOpen)
            | [] -> Ok env
        loop env l

let validate_bound_vars (top_env : Env) term ty x =
    let errors = ResizeArray()
    let rec cterm term ty x =
        let check (a,b) = if Set.contains b term = false && Map.containsKey b top_env.term = false then errors.Add(a,UnboundVariable)
        match x with
        | RawSymbolCreate _ | RawDefaultLit _ | RawLit _ | RawB _ -> ()
        | RawV(a,b) -> check (a,b)
        | RawType(_,x) -> ctype term ty x
        | RawMatch(_,body,l) -> cterm term ty body; List.iter (fun (a,b) -> cterm (cpattern term ty a) ty b) l
        | RawFun(_,l) -> List.iter (fun (a,b) -> cterm (cpattern term ty a) ty b) l
        | RawForall(_,(_,(a,_)),b) -> cterm term (Set.add a ty) b
        | RawRecBlock(_,l,on_succ) -> 
            let term = List.fold (fun s ((_,x),_) -> Set.add x s) term l
            List.iter (fun (_,x) -> cterm term ty x) l
            cterm term ty on_succ
        | RawRecordWith(_,a,b,c) ->
            List.iter (cterm term ty) a
            List.iter (function
                | RawRecordWithSymbol(_,e) | RawRecordWithSymbolModify(_,e) -> cterm term ty e
                | RawRecordWithInjectVar(v,e) | RawRecordWithInjectVarModify(v,e) -> check v; cterm term ty e
                ) b
            List.iter (function RawRecordWithoutSymbol _ -> () | RawRecordWithoutInjectVar (a,b) -> check (a,b)) c
        | RawOp(_,_,l) -> List.iter (cterm term ty) l
        | RawReal(_,x) | RawJoinPoint(_,x) -> cterm term ty x
        | RawAnnot(_,a,b) -> cterm term ty a; ctype term ty b
        | RawTypecase(_,a,b) -> 
            ctype term ty a
            List.iter (fun (a,b) -> 
                ctype term ty a
                cterm term (ty + metavars a) b
                ) b
        | RawModuleOpen(_,(a,b),l,on_succ) ->
            match module_open top_env a b l with
            | Ok x ->
                let combine e m = Map.fold (fun s k _ -> Set.add k s) e m
                cterm (combine term x.term) (combine ty x.ty) on_succ
            | Error e -> errors.Add(e)
        | RawSeq(_,a,b) | RawPairCreate(_,a,b) | RawIfThen(_,a,b) | RawApply(_,a,b) -> cterm term ty a; cterm term ty b
        | RawIfThenElse(_,a,b,c) -> cterm term ty a; cterm term ty b; cterm term ty c
    and ctype term ty x =
        match x with
        | RawTPrim _ | RawTWildcard _ | RawTB _ | RawTSymbol _ | RawTMetaVar _ -> ()
        | RawTVar(a,b) -> if Set.contains b ty = false && Map.containsKey b top_env.ty = false then errors.Add(a,UnboundVariable)
        | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b) -> ctype term ty a; ctype term ty b
        | RawTRecord(_,l) -> Map.iter (fun _ -> ctype term ty) l
        | RawTForall(_,(_,(a,_)),b) -> ctype term (Set.add a ty) b
        | RawTArray(_,a) -> ctype term ty a
        | RawTTerm (_,a) -> cterm term ty a
    and cpattern term ty x =
        //let is_first = System.Collections.Generic.HashSet()
        let rec loop term x = 
            let f = loop term
            match x with
            | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatB _ | PatE _ -> term
            | PatVar(_,b) -> 
                //if is_first.Add b then () // TODO: I am doing it like this so I can reuse this code later for variable highting.
                Set.add b term
            | PatDyn(_,x) | PatUnbox(_,x) -> f x
            | PatPair(_,a,b) -> loop (loop term a) b
            | PatRecordMembers(_,l) ->
                List.fold (fun s -> function
                    | PatRecordMembersSymbol(_,x) -> loop s x
                    | PatRecordMembersInjectVar((a,b),x) ->
                        if Set.contains b term = false && Map.containsKey b top_env.term = false then errors.Add(a,UnboundVariable)
                        loop s x
                    ) term l
            | PatActive(_,a,b) -> cterm term ty a; f b
            | PatAnd(_,a,b) | PatOr(_,a,b) -> loop (loop term a) b
            | PatAnnot(_,a,b) -> let r = f a in ctype r ty b; r 
            | PatWhen(_,a,b) -> let r = f a in cterm r ty b; r
            | PatNominal(_,(r,a),b) -> 
                if Set.contains a ty = false && Map.containsKey a top_env.ty = false then errors.Add(r,UnboundVariable)
                f b
        loop term x

    match x with
    | Choice1Of2 x -> cterm term ty x
    | Choice2Of2 x -> ctype term ty x
    errors

let assert_bound_vars (top_env : Env) term ty x =
    let errors = validate_bound_vars top_env term ty x
    if 0 < errors.Count then raise (TypeErrorException (Seq.toList errors))

let rec subst (m : (Var * T) list) x =
    let f = subst m
    match x with
    | TyConstraint _ | TyMetavar _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> x
    | TyPair(a,b) -> TyPair(f a, f b)
    | TyRecord l -> TyRecord(Map.map (fun _ -> f) l)
    | TyFun(a,b) -> TyFun(f a, f b)
    | TyArray a -> TyArray(f a)
    | TyApply(a,b,c) -> TyApply(f a, f b, c)
    | TyVar a -> List.tryPick (fun (v,x) -> if a = v then Some x else None) m |> Option.defaultValue x
    | TyForall(a,b) -> TyForall(a, f b)
    | TyInl(a,b) -> TyInl(a, f b)

let inline constraint_process x con on_succ on_fail =
    match con, x with
    | CNumber, TyPrim (UInt8T | UInt16T | UInt32T | UInt64T | Int8T | Int16T | Int32T | Int64T | Float32T | Float64T) -> on_succ ()
    | _ -> on_fail ()

let rec kind_subst = function
    | KindMetavar ({contents'=Some x} & link) -> go' x link kind_subst
    | KindMetavar _ | KindConstraint | KindType as x -> x
    | KindFun(a,b) -> KindFun(kind_subst a,kind_subst b)

let rec term_subst = function
    | TyMetavar(_,{contents=Some x} & link) -> go x link term_subst
    | TyMetavar _ | TyConstraint _ | TyVar _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ as x -> x
    | TyPair(a,b) -> TyPair(term_subst a, term_subst b)
    | TyRecord l -> TyRecord(Map.map (fun _ -> term_subst) l)
    | TyFun(a,b) -> TyFun(term_subst a, term_subst b)
    | TyForall(a,b) -> TyForall(a,term_subst b)
    | TyArray a -> TyArray(term_subst a)
    | TyApply(a,b,c) -> TyApply(term_subst a, term_subst b, c)
    | TyInl(a,b) -> TyInl(a,term_subst b)

let rec foralls_get = function
    | RawForall(_,a,b) -> let a', b = foralls_get b in a :: a', b
    | b -> [], b

let rec kind_force = function
    | KindMetavar ({contents'=Some x} & link) -> go' x link kind_subst
    | KindMetavar link -> let x = KindType in link.contents' <- Some x; x
    | KindConstraint | KindType as x -> x
    | KindFun(a,b) -> KindFun(kind_subst a,kind_subst b)

let rec has_metavars x =
    let f = has_metavars
    match visit_t x with
    | TyVar _ | TyConstraint _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> false
    | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
    | TyApply(a,b,_) | TyFun(a,b) | TyPair(a,b) -> f a && f b
    | TyRecord l -> Map.exists (fun _ -> f) l
    | TyMetavar(x,_) -> true

let loc_env (x : TopEnv) = {term=x.term; ty=x.ty}

let var_of (name,kind) = {scope=0; constraints=Set.empty; kind=kind; name=name}
let typevars (l : TypeVar list) = List.map (fun (_,(a,b)) -> var_of (a, typevar b)) l
let add_var s x = Map.add x.name (TyVar x) s
let add_vars ty vars = List.fold add_var ty vars
let names_of vars = List.map (fun x -> x.name) vars |> Set

open Spiral.Tokenize
let lit = function
    | LitUInt8 _ -> TyPrim UInt8T
    | LitUInt16 _ -> TyPrim UInt16T
    | LitUInt32 _ -> TyPrim UInt32T
    | LitUInt64 _ -> TyPrim UInt64T
    | LitInt8 _ -> TyPrim Int8T
    | LitInt16 _ -> TyPrim Int16T
    | LitInt32 _ -> TyPrim Int32T
    | LitInt64 _ -> TyPrim Int64T
    | LitFloat32 _ -> TyPrim Float32T
    | LitFloat64 _ -> TyPrim Float64T
    | LitBool _ -> TyPrim BoolT
    | LitString _ -> TyPrim StringT
    | LitChar _ -> TyPrim CharT

open Spiral.TypecheckingUtils
let infer (top_env' : TopEnv) (env : Env) expr =
    let hoc = top_env'.hoc
    let top_env = loc_env top_env'
    let errors = ResizeArray()
    let scope = ref 0

    let fresh_kind () = KindMetavar {contents'=None}
    let fresh_var'' x = TyMetavar (x, ref None)
    let fresh_var' kind = fresh_var'' {scope= !scope; constraints=Set.empty; kind=kind}
    let fresh_subst_var cons kind = fresh_var'' {scope= !scope; constraints=cons; kind=kind}
    let forall_subst_all x =
        let rec loop m x = 
            match visit_t x with
            | TyForall(a,b) -> loop ((a, fresh_subst_var a.constraints a.kind) :: m) b
            | x -> subst m x
        loop [] x

    let typevar_to_var ((r,(name,kind)) : TypeVar) : Var = {scope= !scope; constraints=Set.empty; kind=typevar kind; name=name}
    let generalize (forall_vars : Var list) (body : T) = 
        let scope = !scope
        let h = System.Collections.Generic.HashSet()
        let generalized_metavars = ResizeArray()
        let rec replace_metavars x =
            let f = replace_metavars
            match x with
            | TyMetavar(_,{contents=Some x} & link) -> go x link f
            | TyMetavar(x, link) when scope = x.scope ->
                let v = TyVar {scope=x.scope; constraints=x.constraints; kind=kind_force x.kind; name=null}
                link := Some v
                replace_metavars v
            | TyVar v -> (if v.name = null && h.Add(v) then generalized_metavars.Add(v)); x
            | TyMetavar _ | TyConstraint _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ as x -> x
            | TyPair(a,b) -> TyPair(f a, f b)
            | TyRecord l -> TyRecord(Map.map (fun _ -> f) l)
            | TyFun(a,b) -> TyFun(f a, f b)
            | TyForall(a,b) -> TyForall(a,f b)
            | TyArray a -> TyArray(f a)
            | TyApply(a,b,c) -> TyApply(f a,f b,c)
            | TyInl(a,b) -> TyInl(a,f b)

        let f x s = TyForall(x,s)
        Seq.foldBack f generalized_metavars body
        |> List.foldBack f forall_vars 

    let inline unify_kind' er (got : TT) (expected : TT) : unit =
        let rec loop (a'',b'') =
            match visit_tt a'', visit_tt b'' with
            | KindType, KindType
            | KindConstraint, KindConstraint -> ()
            | KindFun(a,a'), KindFun(b,b') -> loop (a,b); loop (a',b')
            | KindMetavar a, KindMetavar b & b' -> if a <> b then a.contents' <- Some b'
            | KindMetavar link, b | b, KindMetavar link -> link.contents' <- Some b
            | _ -> er()
        loop (got, expected)
    let unify_kind r got expected = unify_kind' (fun () -> raise (TypeErrorException [r, KindError (got, expected)])) got expected

    let unify (r : Range) (got : T) (expected : T) : unit =
        let unify_kind = unify_kind' (fun () -> raise (TypeErrorException [r, KindError' (got, expected)]))
        let er () = raise (TypeErrorException [r, TermError(got, expected)])

        // Does occurs checking.
        // Does scope checking in forall vars.
        // Does constraint subset checking in forall vars.
        let rec validate_unification i x =
            let f = validate_unification i
            match visit_t x with
            | TyConstraint _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> ()
            | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
            | TyApply(a,b,_) | TyFun(a,b) | TyPair(a,b) -> f a; f b
            | TyRecord l -> Map.iter (fun _ -> f) l
            | TyVar x -> 
                if i.scope < x.scope then raise (TypeErrorException [r,ForallVarScopeError(x.name,got,expected)])
                if i.constraints.IsSubsetOf x.constraints = false then raise (TypeErrorException [r,ForallVarConstraintError(x.name,got,expected)]) 
            | TyMetavar(x,_) -> if i = x then er() elif i.scope < x.scope then x.scope <- i.scope

        let rec loop (a'',b'') = 
            match visit_t a'', visit_t b'' with
            | TyMetavar(a,link), TyMetavar(b,_) & b' ->
                if a <> b then
                    unify_kind a.kind b.kind
                    b.scope <- min a.scope b.scope
                    b.constraints <- a.constraints + b.constraints
                    link := Some b'
            | (TyMetavar(a',link), b | b, TyMetavar(a',link)) ->
                validate_unification a' b
                unify_kind a'.kind (tt b)
                Set.fold (fun ers con ->
                    let on_succ () = ers
                    let on_fail () = (r,ConstraintError(con, b)) :: ers
                    constraint_process b con on_succ on_fail
                    ) [] a'.constraints
                |> function
                    | [] -> link := Some b
                    | constraint_errors -> raise (TypeErrorException constraint_errors)
            | TyVar a, TyVar b when a = b -> ()
            | (TyPair(a,b), TyPair(a',b') | TyFun(a,a'), TyFun(b,b') | TyApply(a,a',_), TyApply(b,b',_)) -> loop (a,b); loop (a',b')
            | TyRecord l, TyRecord l' ->
                let a,b = Map.toArray l, Map.toArray l'
                if a.Length <> b.Length then er ()
                else Array.iter2 (fun (_,a) (_,b) -> loop (a,b)) a b
            | TyHigherOrder(i,_), TyHigherOrder(i',_) when i = i' -> ()
            | TyB, TyB -> ()
            | TyPrim x, TyPrim x' when x = x' -> ()
            | TySymbol x, TySymbol x' when x = x' -> ()
            | TyConstraint x, TyConstraint x' when x = x' -> ()
            | TyArray a, TyArray b -> loop (a,b)
            // Note: Unifying these two only makes sense if the expected is fully inferred already.
            | TyForall(a,b), TyForall(a',b') | TyInl(a,b), TyInl(a',b') when a.kind = a'.kind -> loop (b, subst [a',TyVar a] b')
            | _ -> er ()

        try loop (got, expected)
        with :? TypeErrorException as e -> errors.AddRange e.Data0

    let rec apply_record r s l x =
        let f = apply_record r s
        match visit_t x with
        | TySymbol x ->
            match Map.tryFind x l with
            | Some x -> unify r s x
            | None -> errors.Add(r,RecordIndexFailed x)
        | TyPair(TySymbol x, b) ->
            match Map.tryFind x l with
            | Some (TyRecord l) -> f l b
            | Some a -> unify r a (TyFun(b,s))
            | None -> errors.Add(r,RecordIndexFailed x)
        | x -> errors.Add(r,ExpectedSymbolAsRecordKey x)
           
    let assert_bound_vars env a =
        let keys_of m = Map.fold (fun s k _ -> Set.add k s) Set.empty m
        validate_bound_vars top_env (keys_of env.term) (keys_of env.ty) (Choice1Of2 a) |> errors.AddRange

    let fresh_var () = fresh_var' KindType
    let rec term (env : Env) s x =
        let f = term env
        let f' x = let v = fresh_var() in f v x; visit_t v
        let v x = Map.tryFind x env.term |> Option.orElseWith (fun () -> Map.tryFind x top_env.term) |> Option.map visit_t
        match x with
        | RawB r -> unify r s TyB
        | RawV(r,x) ->
            match v x with
            | Some (TySymbol "<real>") -> errors.Add(r,RealFunctionInTopDown)
            | Some x -> unify r s (forall_subst_all x)
            | None -> errors.Add(r, UnboundVariable)
        | RawLit(r,x) -> unify r s (lit x)
        | RawDefaultLit _ -> ()
        | RawSymbolCreate(r,x) -> unify r s (TySymbol x)
        | RawType(_,x) -> ty env s x
        | RawIfThenElse(_,cond,tr,fl) -> f (TyPrim BoolT) cond; f s tr; f s fl
        | RawIfThen(_,cond,tr) -> f (TyPrim BoolT) cond; f s tr
        | RawPairCreate(r,a,b) ->
            let q,w = fresh_var(), fresh_var()
            unify r s (TyPair(q, w))
            f q a; f w b
        | RawSeq(_,a,b) -> f TyB a; f s b
        | RawReal(_,a) -> assert_bound_vars env a
        | RawOp(_,_,l) -> List.iter (assert_bound_vars env) l
        | RawJoinPoint(_,a) -> f s a
        | RawApply(r,a',b) ->
            match f' a' with
            | TyRecord l -> apply_record r s l (f' b)
            | a -> let v = fresh_var() in unify (range_of_expr a') a (TyFun(v,s)); f v b
        | RawAnnot(_,a,b) -> ty env s b; f s a
        | RawModuleOpen(_,(a,b),l,on_succ) ->
            match module_open top_env a b l with
            | Ok x ->
                let combine e m = Map.foldBack Map.add m e
                term {term = combine env.term x.term; ty = combine env.ty x.ty} s on_succ
            | Error e -> errors.Add(e)
        | RawRecordWith(r,l,withs,withouts) ->
            let i = errors.Count
            let record x =
                match f' x with
                | TyRecord m -> m
                | TyMetavar _ -> raise (TypeErrorException (if errors.Count = i then [range_of_expr x, MetavarsNotAllowedInRecordWith] else []))
                | a -> raise (TypeErrorException [range_of_expr x, ExpectedRecord a])
            let symbol x =
                match f' x with
                | TySymbol x -> x
                | TyMetavar _ -> raise (TypeErrorException (if errors.Count = i then [range_of_expr x, MetavarsNotAllowedInRecordWith] else []))
                | _ -> raise (TypeErrorException [range_of_expr x, ExpectedSymbolInRecordWith])
            let tc (l,m) =
                let m =
                    List.fold (fun m x -> 
                        let with_symbol ((_,a),b) = 
                            let v = fresh_var()
                            f v b
                            Map.add a v m
                        let with_symbol_modify ((r,a),b) =
                            let x = Map.tryFind a m |> Option.defaultWith (fun () -> errors.Add(r,RecordIndexFailed a); fresh_var())
                            let v = fresh_var()
                            f (TyFun(x,v)) b
                            Map.add a v m
                        let inline with_injext next ((r,a),b) =
                            match v a with
                            | Some (TySymbol a) -> next ((r,a),b)
                            | Some x -> errors.Add(r, ExpectedSymbolAsRecordKey x); m
                            | None -> errors.Add(r, UnboundVariable); m
                        match x with
                        | RawRecordWithSymbol(a,b) -> with_symbol (a,b)
                        | RawRecordWithSymbolModify(a,b) -> with_symbol_modify (a,b)
                        | RawRecordWithInjectVar(a,b) -> with_injext with_symbol (a,b)
                        | RawRecordWithInjectVarModify(a,b) -> with_injext with_symbol_modify (a,b)
                        ) m withs
                let m =
                    List.fold (fun m -> function
                        | RawRecordWithoutSymbol(_,a) -> Map.remove a m
                        | RawRecordWithoutInjectVar(r,a) ->
                            match v a with
                            | Some (TySymbol a) -> Map.remove a m
                            | Some x -> errors.Add(r, ExpectedSymbolAsRecordKey x); m
                            | None -> errors.Add(r, UnboundVariable); m
                        ) m withouts
                    |> TyRecord |> List.foldBack (fun (m,a) m' -> Map.add a m' m |> TyRecord) l
                if i = errors.Count then unify r s m
            try match l with
                | x :: x' ->
                    List.mapFold (fun m x ->
                        let sym = symbol x
                        match Map.tryFind sym m with
                        | Some (TyRecord m') -> (m,sym), m'
                        | Some _ -> raise (TypeErrorException [range_of_expr x, ExpectedRecordAsResultOfIndex sym])
                        | None -> raise (TypeErrorException [range_of_expr x, RecordIndexFailed sym])
                        ) (record x) x'
                | [] -> [], Map.empty
            with :? TypeErrorException as e -> errors.AddRange e.Data0; [], Map.empty
            |> tc
        | RawFun(r,l) ->
            let q,w = fresh_var(), fresh_var()
            unify r s (TyFun(q,w))
            List.iter (fun (a,b) -> term (pattern env q a) w b) l
        | RawForall _ -> failwith "Compiler error: Should be handled in let statements."
        | RawMatch(_,(RawForall _ | RawFun _) & body,[PatVar(_,name), on_succ]) -> term (standard_let env (name, body)) s on_succ
        | RawRecBlock(_,l',on_succ) -> term (recursive_let env l') s on_succ
        | RawMatch(_,body,l) ->
            let body_var = fresh_var()
            let l = List.map (fun (a,on_succ) -> pattern env body_var a, on_succ) l
            f body_var body
            List.iter (fun (env,on_succ) -> term env s on_succ) l
        | RawTypecase _ -> failwith "Compiler error: `typecase` should not appear in the top down segment."
    and standard_let env (name, body) =
        incr scope
        let vars,body = foralls_get body
        let vars = List.map typevar_to_var vars
        let body_var = fresh_var()
        term {env with ty = List.fold (fun s x -> Map.add x.name (TyVar x) s) env.ty vars} body_var body
        let env = {env with term = Map.add name (generalize vars body_var) env.term }
        decr scope
        env
    and recursive_let env l' =
        incr scope
        let env =
            let has_foralls = List.exists (function (_,RawForall _) -> true | _ -> false) l'
            if has_foralls then
                let i = errors.Count
                let l,m =
                    List.mapFold (fun s ((_,name),body) ->
                        let vars,body = foralls_get body
                        let vars = List.map typevar_to_var vars
                        let ty = List.fold (fun s x -> Map.add x.name (TyVar x) s) env.ty vars
                        let body_var = term_annotations {env with ty = ty} body
                        let term env = term {env with ty = ty} body_var body
                        term, Map.add name (List.foldBack (fun x s -> TyForall(x,s)) vars body_var) s
                        ) env.term l'
                
                if errors.Count = i then
                    l |> List.iter ((|>) {env with term = m})
                    {env with term = m}
                else
                    List.fold (fun s ((_,name),_) -> 
                        let v = {scope= !scope; constraints=Set.empty; kind=KindType; name="x"}
                        Map.add name (TyForall(v, TyVar v)) s
                        ) env.term l'
                    |> fun term -> {env with term = term}
            else 
                let l, m = 
                    List.mapFold (fun s ((_,name),body) -> 
                        let body_var = fresh_var()
                        let term env = term env body_var body
                        let gen env : Env = {env with term = Map.add name (generalize [] body_var) env.term}
                        (term, gen), Map.add name body_var s
                        ) env.term l'
                let _ =
                    let env = {env with term=m}
                    List.iter (fun (term, _) -> term env) l
                List.fold (fun env (_,gen) -> gen env) env l
        decr scope
        env
    and term_annotations env x =
        let f t = 
            let i = errors.Count
            let v = fresh_var()
            ty env v t
            let v = term_subst v
            if i = errors.Count && has_metavars v = false then errors.Add(range_of_texpr t, RecursiveAnnotationHasMetavars)
            v
        match x with
        | RawFun(_,[(PatAnnot(_,_,t) | PatDyn(_,PatAnnot(_,_,t))),body]) -> TyFun(f t, term_annotations env body)
        | RawFun(_,[pat,body]) -> errors.Add(range_of_pattern pat, ExpectedAnnotation); TyFun(fresh_var(), term_annotations env body)
        | RawFun(r,_) -> errors.Add(r, ExpectedSinglePattern); TyFun(fresh_var(), fresh_var())
        | RawJoinPoint(_, RawAnnot(_,_,t)) | RawAnnot(_,_,t) -> f t
        | x -> errors.Add(range_of_expr x,ExpectedAnnotation); fresh_var()
    and ty (env : Env) s x =
        let f s x = ty env s x
        match x with
        | RawTWildcard _ -> ()
        | RawTB r -> unify r s TyB
        | RawTSymbol(r,x) -> unify r s (TySymbol x)
        | RawTPrim(r,x) -> unify r s (TyPrim x)
        | RawTArray(r,x) -> let v = fresh_var() in unify r s (TyArray v); f v x
        | RawTVar(r,x) -> 
            match Map.tryFind x env.ty |> Option.orElseWith (fun () -> Map.tryFind x top_env.ty) with
            | Some x -> unify r s x
            | None -> errors.Add(r, UnboundVariable)
        | RawTPair(r,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify r s (TyPair(q,w))
            f q a; f w b
        | RawTFun(r,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify r s (TyFun(q,w))
            f q a; f w b
        | RawTRecord(r,l) -> 
            let l' = Map.map (fun _ _ -> fresh_var()) l
            unify r s (TyRecord l')
            Map.iter (fun k s -> f s l.[k]) l'
        | RawTForall _ -> failwith "Compiler error: Needs special handling. Foralls can only appear in prototype definitions right now so it should be handled there."
        | RawTApply(r,a',b) ->
            let f' k x = let v = fresh_var' k in f v x; visit_t v
            match f' (fresh_kind()) a' with
            | TyRecord l -> 
                match f' KindType b with
                | TySymbol x ->
                    match Map.tryFind x l with
                    | Some x -> unify r s x
                    | None -> errors.Add(r,RecordIndexFailed x)
                | b -> errors.Add(r,ExpectedSymbolAsRecordKey b)
            | TyInl(a,body) -> let v = fresh_var' a.kind in f v b; unify r s (subst [a,v] body)
            | a -> 
                let q,w = fresh_kind(), fresh_kind()
                unify_kind (range_of_texpr a') (tt a) (KindFun(q,w))
                let x = fresh_var' q
                f x b
                unify r s (TyApply(a,x,w))
        | RawTTerm(r,a) -> assert_bound_vars env a; unify r s (TySymbol "<term>")
        | RawTMetaVar _ -> failwith "Compiler error: This particular metavar is only for typecase's clauses. This happens during the bottom-up segment."
    and pattern env s a = 
        let is_first = System.Collections.Generic.HashSet()
        let ho_make (i : int) (l : Var list) =
            let h = TyHigherOrder(i,List.foldBack (fun (x : Var) s -> KindFun(x.kind,s)) l KindType)
            let l' = List.map (fun (x : Var) -> x, fresh_subst_var x.constraints x.kind) l
            List.fold (fun s (_,x) -> match tt s with KindFun(_,k) -> TyApply(s,x,k) | _ -> failwith "impossible") h l', l'
        let rec ho_index = function 
            | TyApply(a,_,_) -> ho_index a 
            | TyHigherOrder(i,_) -> ValueSome i
            | _ -> ValueNone
        let rec ho_fun = function
            | TyFun(_,a) | TyForall(_,a) -> ho_fun a
            | a -> ho_index a
        let rec loop env s a =
            let f = loop env
            let v x = Map.tryFind x env.term |> Option.orElseWith (fun () -> Map.tryFind x top_env.term)
            match a with
            | PatB r -> unify r s TyB; env
            | PatE _ -> env
            | PatVar(r,a) ->
                if is_first.Add a then {env with term=Map.add a s env.term}
                else unify r s env.term.[a]; env
            | PatDyn(_,a) -> f s a
            | PatAnnot(_,a,b) -> ty env s b; f s a
            | PatWhen(_,a,b) -> let env = f s a in term env (TyPrim BoolT) b; env
            | PatPair(r,a,b) ->
                let q,w = fresh_var(), fresh_var()
                unify r s (TyPair(q,w))
                pattern (pattern env q a) w b
            | PatSymbol(r,a) -> unify r s (TySymbol a); env
            | PatActive(r,a,b) ->
                let w,z = fresh_var(),fresh_var()
                unify r z (TyFun(s, w))
                term env z a
                f w b
            | PatOr(_,a,b) | PatAnd(_,a,b) -> pattern (pattern env s a) s b
            | PatValue(r,a) -> unify r s (lit a); env
            | PatDefaultValue _ -> env
            | PatRecordMembers(r,l) ->
                let l =
                    List.choose (function
                        | PatRecordMembersSymbol((r,a),b) -> Some (a,b)
                        | PatRecordMembersInjectVar((r,a),b) ->
                            match v a with
                            | Some (TySymbol a) -> Some (a,b)
                            | Some x -> errors.Add(r, ExpectedSymbolAsRecordKey x); None
                            | None -> errors.Add(r, UnboundVariable); None
                        ) l
                match visit_t s with
                | TyRecord l' ->
                    let l, missing =
                        List.mapFoldBack (fun (a,b) missing ->
                            match Map.tryFind a l' with
                            | Some x -> (x,b), missing
                            | None -> (fresh_var(),b), a :: missing
                            ) l []
                    if List.isEmpty missing = false then errors.Add(r, MissingRecordFieldsInPattern missing)
                    List.fold (fun env (a,b) -> pattern env a b) env l
                | s ->
                    let l, env =
                        List.mapFold (fun env (a,b) -> 
                            let v = fresh_var()
                            (a, v), pattern env v b
                            ) env l
                    unify r s (l |> Map |> TyRecord)
                    env
            | PatUnbox(r,PatPair(_,PatSymbol(_,name), a)) ->
                let assume i =
                    match hoc.[i] with
                    | HOCUnion(vars,cases) ->
                        let x,m = ho_make i vars
                        unify r s x
                        match Map.tryFind name cases with
                        | Some v -> f (subst m v) a
                        | None -> errors.Add(r,CasePatternNotFoundForType i); f (fresh_var()) a
                    | HOCNominal _ -> errors.Add(r,NominalInPatternUnbox i); f (fresh_var()) a
                match term_subst s |> ho_index with
                | ValueSome i -> assume i
                | ValueNone ->
                    match v name with
                    | Some x -> 
                        match term_subst x |> ho_fun with
                        | ValueSome i -> assume i
                        | ValueNone -> errors.Add(r,CannotInferCasePatternFromTermInEnv x); f (fresh_var()) a
                    | None -> errors.Add(r,CasePatternNotFound name); f (fresh_var()) a
            | PatUnbox _ -> failwith "Compiler error: Malformed PatUnbox."
            | PatNominal(_,(r,name),a) ->
                match Map.tryFind name env.ty |> Option.orElseWith (fun () -> Map.tryFind name top_env.ty) with
                | Some x -> 
                    match ho_index x with
                    | ValueSome i ->
                        match hoc.[i] with
                        | HOCNominal(vars,v) -> let x,m = ho_make i vars in unify r s x; f (subst m v) a
                        | HOCUnion _ -> errors.Add(r,UnionInPatternNominal i); f (fresh_var()) a
                    | ValueNone -> errors.Add(r,TypeInGlobalEnvIsNotNominal x); f (fresh_var()) a
                | _ -> errors.Add(r,UnboundVariable); f (fresh_var()) a
        loop env s a

    match expr with
    | BundleType(_,(_,name),vars,expr) ->
        let vars = typevars vars
        let v = fresh_var()
        ty {term=Map.empty; ty=add_vars Map.empty vars} v expr
        let inl = List.foldBack (fun x s -> TyInl(x,s)) vars (visit_t v)
        {top_env' with ty = Map.add name inl top_env.ty}
    | BundleRecType l ->
        let l,_ =
            List.mapFold (fun i -> function
                | BundleNominal(_,(_,name),vars,l) -> Choice1Of2(i,name,typevars vars,l), i+1
                | BundleUnion(_,(_,name),vars,l) -> Choice2Of2(i,name,typevars vars,l), i+1
                ) hoc.Length l
        let env_ty = 
            List.fold (fun s (Choice1Of2(i,name,vars,_) | Choice2Of2(i,name,vars,_)) ->
                let tt = List.foldBack (fun (x : Var) s -> KindFun(x.kind,s)) vars KindType
                Map.add name (TyHigherOrder(i,tt)) s
                ) top_env.ty l
        let hoc =
            List.fold (fun hoc x ->
                match x with
                | Choice1Of2(_,_,vars,expr) ->
                    let v = fresh_var()
                    ty {term=Map.empty; ty=add_vars env_ty vars} v expr 
                    PersistentVector.conj (HOCNominal(vars, visit_t v)) hoc
                | Choice2Of2(_,_,vars,l) ->
                    List.fold (fun cases expr ->
                        let v = fresh_var()
                        ty {term=Map.empty; ty=add_vars env_ty vars} v expr 
                        match visit_t v with
                        | TyPair(TySymbol x, b) -> 
                            if Map.containsKey x cases then errors.Add(range_of_texpr expr, DuplicateKeyInUnion); cases
                            else Map.add x b cases
                        | _ -> errors.Add (range_of_texpr expr, ExpectedSymbolAsUnionKey); cases
                        ) Map.empty l
                    |> fun l -> PersistentVector.conj (HOCUnion(vars,l)) hoc
                ) hoc l
        {top_env' with hoc = hoc; ty = env_ty}
    | BundlePrototype(_,(_,name),vars,expr) ->
        let vars = typevars vars
        let tt = List.foldBack (fun (x : Var) s -> KindFun(x.kind,s)) vars KindType
        let l = var_of (name,tt) :: vars
        let v = fresh_var()
        ty {term=Map.empty; ty=add_vars Map.empty vars} v expr
        let body = List.foldBack (fun a b -> TyForall(a,b)) l (visit_t v)
        {top_env' with term = Map.add name body top_env.term}
    | BundleInl(_,(_,name),a,true) -> 
        let env = standard_let {term=Map.empty; ty=Map.empty} (name,a)
        {top_env' with term = Map.foldBack Map.add env.term top_env.term}
    | BundleInl(_,(_,name),a,false) ->
        assert_bound_vars {term=Map.empty; ty=Map.empty} a
        {top_env' with term = Map.add name (TySymbol "<real>") top_env.term }
    | BundleRecTerm l ->
        match l with 
        | BundleRecInl(_,_,_,true) :: _ -> 
            let l = List.map (function BundleRecInl(_,a,b,_) -> a,b) l
            (recursive_let {term=Map.empty; ty=Map.empty} l).term
        | _ ->
            let env_term = List.fold (fun s (BundleRecInl(_,(_,a),_,_)) -> Map.add a (TySymbol "<real>") s) env.term l
            l |> List.iter (fun (BundleRecInl(_,_,x,_)) -> assert_bound_vars {term = env_term; ty = Map.empty} x)
            env_term
        |> fun env_term -> {top_env' with term = Map.foldBack Map.add env_term top_env.term}
    | BundleInstance _ -> failwith "TODO: Instances not implemented yet."
    |> fun x -> if 0 < errors.Count then raise (TypeErrorException (Seq.toList errors)) else x
