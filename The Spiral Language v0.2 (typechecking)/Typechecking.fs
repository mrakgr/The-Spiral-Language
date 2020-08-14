module Spiral.Typechecking
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

and [<ReferenceEquality>] Var = V of scope: int * Constraint Set * TT * display_name: string

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
    | TyMetavar of Var * T option ref
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
    | NominalInPatternUnbox of int
    | TypeInGlobalEnvIsNotNominal of T
    | UnionInPatternNominal of int
    | ConstraintError of Constraint

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

let var_kind (V(_,_,k,_)) = k
let var_name (V(_,_,_,name)) = name
let rec tt = function
    | TyHigherOrder(_,x) | TyApply(_,_,x) | TyMetavar(V(_,_,x,_),_) | TyVar(V(_,_,x,_)) -> x
    | TyB | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyPair _ | TySymbol _ | TyArray _ -> KindType
    | TyInl(v,a) -> KindFun(var_kind v,tt a)
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

type AuxEnv = {
    hoc : Map<int,HigherOrderCases>
    union_cases : Map<string,int>
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

let assert_bound_vars' (top_env : Env) term ty x =
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
            | PatNominal(_,a,b) -> (if Map.containsKey (snd a) top_env.ty = false then errors.Add(fst a,UnboundVariable)); f b
        loop term x

    match x with
    | Choice1Of2 x -> cterm term ty x
    | Choice2Of2 x -> ctype term ty x
    errors
let assert_bound_vars (top_env : Env) term ty x =
    let errors = assert_bound_vars' top_env term ty x
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

open Spiral.Tokenize
let infer (aux : AuxEnv) (top_env : Env) (env : Env) expr : T =
    let errors = ResizeArray()
    let scope = ref 0
    let fresh_kind () = KindMetavar {contents'=None}
    let fresh_var'' x = TyMetavar (x, ref None)
    let fresh_var' kind = fresh_var'' (V(!scope,Set.empty,kind,null))
    let fresh_subst_var cons kind = fresh_var'' (V(!scope,cons,kind,null))
    let forall_subst_all x =
        let rec loop m x = 
            match visit_t x with
            | TyForall(V(_,cons,kind,_) & a,b) -> loop ((a, fresh_subst_var cons kind) :: m) b
            | x -> subst m x
        loop [] x

    let forall_subst_single (V(_,cons,kind,_) & a,b) =
        subst [a, fresh_var'' (V(!scope,cons,kind,null))] b

    // Note: Loosening the annotation requirement for type definitions would necessitate an occurs check in kinds.
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

        let rec scope_lower scope x =
            let f = scope_lower scope
            match x with
            | TyMetavar(_,{contents=Some x} & link) -> go x link f
            | TyMetavar(V(scope',q,w,e),_) when scope < scope' -> fresh_var'' (V(scope,q,w,e))
            | TyVar(V(scope',_,_,name)) when scope < scope' -> errors.Add(r,ForallVarScopeError(name,got,expected)); fresh_var''(V(scope,Set.empty,fresh_kind(),null))
            | TyVar _ | TyMetavar _ | TyConstraint _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> x
            | TyPair(a,b) -> TyPair(f a, f b)
            | TyRecord l -> TyRecord(Map.map (fun _ -> f) l)
            | TyFun(a,b) -> TyFun(f a, f b)
            | TyForall(a,b) -> TyForall(a,f b)
            | TyArray a -> TyArray(f a)
            | TyApply(a,b,c) -> TyApply(f a, f b, c)
            | TyInl(a,b) -> TyInl(a,f b)

        let rec occurs_check i x =
            let f = occurs_check i
            match visit_t x with
            | TyConstraint _ | TyVar _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> ()
            | TyForall(_,a) | TyInl(_,a) | TyArray a -> f a
            | TyApply(a,b,_) | TyFun(a,b) | TyPair(a,b) -> f a; f b
            | TyRecord l -> Map.iter (fun _ -> f) l
            | TyMetavar(i',_) -> if i = i' then er()

        let rec loop (a'',b'') = 
            match visit_t a'', visit_t b'' with
            | TyMetavar(V(scope,cons,kind,_) & a',link), TyMetavar(V(scope',cons',kind',_) & b',_) ->
                if a' <> b' then
                    unify_kind kind kind'
                    link := fresh_var'' (V(min scope scope',cons+cons',kind',null)) |> Some
            | (TyMetavar(V(scope',cons,kind,_) & a',link), b | b, TyMetavar(V(scope',cons,kind,_) & a',link)) ->
                occurs_check a' b
                unify_kind kind (tt b)
                Set.fold (fun x con ->
                    match x with
                    | TyMetavar _ -> x
                    | _ -> 
                        let on_succ () = x
                        let on_fail () = errors.Add(r,ConstraintError con); fresh_var' (fresh_kind())
                        constraint_process x con on_succ on_fail
                    ) b cons
                |> scope_lower scope'
                |> fun b -> link := Some b
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
            | TyForall(a,b), TyForall(a',b') | TyInl(a,b), TyInl(a',b') ->
                unify_kind (var_kind a) (var_kind a')
                loop (forall_subst_single (a,b),b')
            | _ -> er ()

        try loop (got, expected)
        with :? TypeErrorException as e -> errors.AddRange e.Data0

    let rec apply_record r s l x =
        let f = apply_record r s
        match x with
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
        assert_bound_vars' top_env (keys_of env.term) (keys_of env.ty) (Choice1Of2 a) |> errors.AddRange

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

    let fresh_var () = fresh_var' KindType
    let rec term (env : Env) s x =
        let f = term env
        let f' x = let v = fresh_var() in f v x; term_subst v
        let v (r,x) = Map.tryFind x env.term |> Option.orElseWith (fun () -> Map.tryFind x top_env.term) |> Option.map term_subst
        match x with
        | RawB r -> unify r s TyB
        | RawV(r,x) ->
            match v (r,x) with
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
                            match v (r,a) with
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
                            match v (r,a) with
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
        | RawForall(r,(_,(name,k)),b) -> 
            let rec typevar = function
                | RawKindWildcard -> fresh_kind()
                | RawKindStar -> KindType
                | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
            let k = typevar k
            let v = V(!scope,Set.empty,k,name)
            let body = fresh_var()
            unify r s (TyForall(v,body))
            term {env with ty = Map.add name (fresh_var'' v) env.ty} body b
        //| RawMatch of Range * body: RawExpr * (Pattern * RawExpr) list
        //| RawRecBlock of Range * ((Range * VarString) * RawExpr) list * on_succ: RawExpr
        | RawTypecase _ -> failwith "Compiler error: `typecase` should not appear in the top down segment."
    and ty (env : Env) s x =
        let f s x = ty env s x
        let v x = Map.tryFind x env.ty |> Option.orElseWith (fun () -> Map.tryFind x top_env.ty)
        match x with
        | RawTWildcard _ -> ()
        | RawTB r -> unify r s TyB
        | RawTSymbol(r,x) -> unify r s (TySymbol x)
        | RawTPrim(r,x) -> unify r s (TyPrim x)
        | RawTArray(r,x) -> let v = fresh_var() in unify r s (TyArray v); f v x
        | RawTVar(r,n) -> 
            match v n with
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
        | RawTForall(r,(_,(a,k)),b) ->
            let k = typevar k
            let v = V(!scope,Set.empty,k,a)
            let x = fresh_var'' v
            unify r s (TyForall(v, x))
            ty {env with ty=Map.add a (TyVar v) env.ty} x b
        | RawTApply(r,a',b) ->
            let f' k x = let v = fresh_var' k in f v x; term_subst v
            match f' (fresh_kind()) a' with
            | TyRecord l -> 
                match f' KindType b with
                | TySymbol x ->
                    match Map.tryFind x l with
                    | Some x -> unify r s x
                    | None -> errors.Add(r,RecordIndexFailed x)
                | b -> errors.Add(r,ExpectedSymbolAsRecordKey b)
            | TyInl(a,body) -> let v = fresh_var' (var_kind a) in f v b; unify r s (subst [a,v] body)
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
            let h = TyHigherOrder(i,List.foldBack (fun x s -> KindFun(var_kind x,s)) l KindType)
            let l' = List.map (fun (V(_,cons,kind,_) as x) -> x, fresh_subst_var cons kind) l
            List.fold (fun s (_,x) -> match tt s with KindFun(_,k) -> TyApply(s,x,k) | _ -> failwith "impossible") h l', l'
        let rec ho_index = function 
            | TyApply(a,_,_) -> ho_index a 
            | TyHigherOrder(i,_) -> ValueSome i
            | _ -> ValueNone
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
                match term_subst s with
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
                    match aux.hoc.[i] with
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
                    match Map.tryFind name aux.union_cases with
                    | Some i -> assume i
                    | None -> errors.Add(r,CasePatternNotFound name); f (fresh_var()) a
            | PatUnbox _ -> failwith "Compiler error: Malformed PatUnbox."
            | PatNominal(_,(r,name),a) ->
                match Map.tryFind name top_env.ty with
                | Some x -> 
                    match ho_index x with
                    | ValueSome i ->
                        match aux.hoc.[i] with
                        | HOCNominal(vars,v) -> let x,m = ho_make i vars in unify r s x; f (subst m v) a
                        | HOCUnion _ -> errors.Add(r,UnionInPatternNominal i); f (fresh_var()) a
                    | ValueNone -> errors.Add(r,TypeInGlobalEnvIsNotNominal x); f (fresh_var()) a
                | _ -> errors.Add(r,UnboundVariable); f (fresh_var()) a
        loop env s a
    let v =
        let v = fresh_var()
        match expr with
        | Choice1Of2 x -> term env v x; term_subst v
        | Choice2Of2 x -> ty env v x; term_subst v
    if 0 < errors.Count then raise (TypeErrorException (Seq.toList errors))
    else v

let var_of (name,kind) = V(0,Set.empty,kind,name)
let typevars (l : TypeVar list) = List.map (fun (_,(a,b)) -> var_of (a, typevar b)) l
let add_var s x = Map.add (var_name x) (TyVar x) s
let add_vars ty vars = List.fold add_var ty vars
let set_vars vars = List.map var_name vars |> Set
let top_type (name : VarString, vars : TypeVar list, expr : RawTExpr) aux (top_env : Env) =
    let vars = typevars vars
    let body =
        assert_bound_vars top_env Set.empty (set_vars vars) (Choice2Of2 expr)
        infer aux top_env {term=Map.empty; ty=add_vars Map.empty vars} (Choice2Of2 expr)
    let inl = List.foldBack (fun x s -> TyInl(x,s)) vars body
    {top_env with ty = Map.add name inl top_env.ty}

type TopHigherOrder =
    | HOUnion of name: string * id: int * (string * TT) list * RawTExpr list
    | HONominal of name: string * id: int * (string * TT) list * RawTExpr

let top_higher_order (l : TopHigherOrder list) (aux : AuxEnv) (top_env : Env) =
    let top_env = 
        List.fold (fun s (HOUnion(name,i,vars,_) | HONominal(name,i,vars,_)) ->
            let tt = List.foldBack (fun (_,x) s -> KindFun(x,s)) vars KindType
            Map.add name (TyHigherOrder(i,tt)) s
            ) top_env.ty l
        |> fun ty -> {top_env with ty=ty}
    let errors = ResizeArray()
    let hoc =
        List.fold (fun (aux : AuxEnv) x ->
            match x with
            | HOUnion(_,i,vars,l) ->
                let vars = List.map var_of vars
                List.fold (fun cases expr ->
                    try assert_bound_vars top_env Set.empty (set_vars vars) (Choice2Of2 expr)
                        match infer aux top_env {term=Map.empty; ty=add_vars Map.empty vars} (Choice2Of2 expr) with
                        | TyPair(TySymbol x, b) -> 
                            if Map.containsKey x cases then errors.Add(range_of_texpr expr, DuplicateKeyInUnion); cases
                            else Map.add x b cases
                        | _ -> errors.Add (range_of_texpr expr, ExpectedSymbolAsUnionKey); cases
                    with :? TypeErrorException as x -> errors.AddRange(x.Data0); cases
                    ) Map.empty l
                |> fun l -> {
                    union_cases = Map.fold (fun s k _ -> Map.add k i s) aux.union_cases l
                    hoc = Map.add i (HOCUnion(vars,l)) aux.hoc
                    }
            | HONominal(_,i,vars,expr) ->
                let vars = List.map var_of vars
                try assert_bound_vars top_env Set.empty (set_vars vars) (Choice2Of2 expr)
                    {aux with hoc = Map.add i (HOCNominal(vars, infer aux top_env {term=Map.empty; ty=add_vars Map.empty vars} (Choice2Of2 expr))) aux.hoc}
                with :? TypeErrorException as x -> errors.AddRange(x.Data0); aux
            ) aux l
    if 0 < errors.Count then raise (TypeErrorException (Seq.toList errors))
    hoc, top_env

let top_prototype (name,a,vars,expr) aux (top_env : Env) =
    let tt = List.foldBack (fun (_,x) s -> KindFun(x,s)) vars KindType
    let vars = List.map var_of vars
    let l = var_of (a,tt) :: vars
    assert_bound_vars top_env Set.empty (set_vars vars) (Choice2Of2 expr)
    let body = 
        infer aux top_env {term=Map.empty; ty=add_vars Map.empty vars} (Choice2Of2 expr)
        |> List.foldBack (fun a b -> TyForall(a,b)) l
    {top_env with term = Map.add name body top_env.term}

open Spiral.Blockize
let tc (l : Bundle list) = 
    ()