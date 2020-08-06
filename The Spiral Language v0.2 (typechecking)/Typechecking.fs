module Spiral.Typechecking
open Spiral.Config
type TT =
    | KindStar
    | KindFun of TT * TT
    | KindMetavar of int

type T =
    | TyB
    | TyPrim of PrimitiveType
    | TySymbol of string
    | TyPair of T * T
    | TyRecord of Map<string, T>
    | TyFun of T * T
    | TyForall of (string * TT) * T
    | TyArray of T
    | TyHigherOrder of int * TT
    | TyApp of T * T * TT // Regular type functions (TyInl) get reduced, while this represents the staged reduction of nominals.
    | TyInl of Map<string,T> * (string * TT) list * T
    | TyVar of string * TT // Staged type vars. Should only appear in TyInl's body. 
    | TyMetavar of int * TT

type VariableBoundError =
    | UnboundVar
    | ModuleUnbound
    | ModuleShadowed
    | ModuleShadowedAndUnbound
    | ModuleIndexFailed

type TypeError =
    | ExpectedStarKind of TT
    | KindError of T * T
    | RecordKeyNotFound of string
    | ExpectedSymbolAsRecordKey of T
    | UnboundVariable of VariableBoundError
    | ExpectedSymbolAsUnionKey
    | DuplicateKeyInUnion
    | TermError of T * T
    | ForallVarScopeError of string * T * T
    | ForallMetavarScopeError of string * T * T
    | MetavarsNotAllowedInRecordWith
    | ExpectedRecord
    | ExpectedRecordAsResultOfIndex of string
    | RecordIndexFailed of string
    | ExpectedSymbolInRecordWith

open Spiral.BlockParsing
exception TypeErrorException of (Range * TypeError) list

let tt = function
    | TyHigherOrder(_,x) | TyApp(_,_,x) | TyMetavar(_,x) | TyVar(_,x) -> x
    | TyB | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyPair _ | TySymbol _ | TyArray _ -> KindStar
    | TyInl(_,x,_) -> List.foldBack (fun (_,a) b -> KindFun(a,b)) x KindStar

let rec typevar = function
    | RawKindStar -> KindStar
    | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
let typevars (l : TypeVar list) = List.map (fun (_,(a,b)) -> a, typevar b) l

let rec substitute_tyvars (body : T) (env : Map<string, T>) =
    let f x = substitute_tyvars x env
    match body with
    | TyB | TyPrim _ | TyHigherOrder _ | TyMetavar _ | TySymbol _ -> body
    | TyPair(a,b) -> TyPair(f a, f b)
    | TyRecord l -> TyRecord(Map.map (fun _ -> f) l)
    | TyFun(a,b) -> TyFun(f a, f b)
    | TyForall((name,_) & k,a) -> substitute_tyvars a (Map.add name (TyVar k) env)
    | TyArray x -> TyArray (f x)
    | TyApp(a,b,k) -> TyApp(f a, f b, k)
    | TyVar(n,_) -> env.[n]
    | TyInl _ -> failwith "Compiler error: TyInl should already have been substituted during eval."

let rec metavars = function
    | RawTVar _ | RawTTerm _ | RawTPrim _ | RawTWildcard _ | RawTB _ | RawTSymbol _ -> Set.empty
    | RawTMetaVar(_,a) -> Set.singleton a
    | RawTForall(_,(_,(_,_)),a) | RawTArray(_,a) -> metavars a
    | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b) -> metavars a + metavars b
    | RawTRecord(_,l) -> Map.fold (fun s _ v -> s + metavars v) Set.empty l

let assert_bound_vars' (env_term : Map<string,T>) (env_ty : Map<string,T>) x =
    let errors = ResizeArray()
    let rec cterm term ty x =
        let check (a,b) = if Set.contains b term = false && Map.containsKey b env_term = false then errors.Add(a,UnboundVariable UnboundVar)
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
            let tryFind x =
                match Map.tryFind x env_term, Map.tryFind x env_ty with
                | Some (TyRecord a), Some (TyRecord b) -> Some (a,b)
                | _ -> None
            let bound_local,bound_global = Set.contains b term, tryFind b
            match bound_local, bound_global with
            | false, None -> errors.Add(a,UnboundVariable ModuleUnbound)
            | true, Some _ -> errors.Add(a,UnboundVariable ModuleShadowed)
            | true, None -> errors.Add(a,UnboundVariable ModuleShadowedAndUnbound)
            | false, Some (m_term, m_ty) ->
                let rec loop (m_term,m_ty) = function
                    | (r,x) :: x' ->
                        match tryFind x with
                        | Some (m_term, m_ty) -> loop (m_term, m_ty) x'
                        | _ -> errors.Add(r,UnboundVariable ModuleIndexFailed)
                    | [] -> 
                        let combine e m = Map.fold (fun s k _ -> Set.add k s) e m
                        cterm (combine term m_term) (combine ty m_ty) on_succ
                loop (m_term, m_ty) l
        | RawSeq(_,a,b) | RawPairCreate(_,a,b) | RawIfThen(_,a,b) | RawApply(_,a,b) -> cterm term ty a; cterm term ty b
        | RawIfThenElse(_,a,b,c) -> cterm term ty a; cterm term ty b; cterm term ty c
    and ctype term ty x =
        let check (a,b) = if Set.contains b ty = false && Map.containsKey b env_ty = false then errors.Add(a,UnboundVariable UnboundVar)
        match x with
        | RawTPrim _ | RawTWildcard _ | RawTB _ | RawTSymbol _ | RawTMetaVar _ -> ()
        | RawTVar(a,b) -> check (a,b)
        | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b) -> ctype term ty a; ctype term ty b
        | RawTRecord(_,l) -> Map.iter (fun _ -> ctype term ty) l
        | RawTForall(_,(_,(a,_)),b) -> ctype term (Set.add a ty) b
        | RawTArray(_,a) -> ctype term ty a
        | RawTTerm (_,a) -> cterm term ty a
    and cpattern term' ty x =
        let rec loop term x = 
            let f = loop term
            match x with
            | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatB _ | PatE _ -> term
            | PatVar(_,b) -> Set.add b term
            | PatDyn(_,x) | PatUnbox(_,x) -> f x
            | PatPair(_,a,b) -> loop (loop term a) b
            | PatRecordMembers(_,l) ->
                List.fold (fun s -> function
                    | PatRecordMembersSymbol(_,x) -> loop s x
                    | PatRecordMembersInjectVar((a,b),x) ->
                        if Set.contains b term = false && Map.containsKey b env_term = false then errors.Add(a,UnboundVariable UnboundVar)
                        loop s x
                    ) term l
            | PatActive(_,a,b) -> cterm (term' + term) ty a; f b
            | PatAnd(_,a,b) | PatOr(_,a,b) -> loop (loop term a) b
            | PatAnnot(_,a,b) -> let r = f a in ctype (term' + r) ty b; r // TODO: I am doing it like this so I can reuse this code later for variable highting.
            | PatWhen(_,a,b) -> let r = f a in cterm (term' + r) ty b; r
            | PatNominal(_,a,b) -> (if Map.containsKey (snd a) env_ty = false then errors.Add(fst a,UnboundVariable UnboundVar)); f b
        term' + loop Set.empty x

    match x with
    | Choice1Of2 x -> cterm Set.empty Set.empty x
    | Choice2Of2 x -> ctype Set.empty Set.empty x
    errors
let assert_bound_vars (env_term : Map<string,T>) (env_ty : Map<string,T>) x =
    let errors = assert_bound_vars' env_term env_ty x
    if 0 < errors.Count then raise (TypeErrorException (errors |> Seq.toList))

let inline eval on_term expr env =
    let rec loop expr (env : Map<string, T>) = 
        let f x = loop x env
        let f' x =
            let r = f x
            match tt r with
            | KindStar -> r
            | s -> raise (TypeErrorException [range_of_texpr x, ExpectedStarKind s])
        match expr with
        | RawTB _ -> TyB
        | RawTSymbol(_,x) -> TySymbol x
        | RawTForall(_,(_,(name,kind)),b) -> let kind = typevar kind in TyForall((name, kind), loop b (Map.add name (TyVar(name,kind)) env))
        | RawTPrim(_,x) -> TyPrim x
        | RawTArray(_,x) -> TyArray(f' x)
        | RawTVar(_,n) -> env.[n]
        | RawTPair(_,a,b) -> TyPair(f' a, f' b)
        | RawTFun(_,a,b) -> TyFun(f' a, f' b)
        | RawTRecord(_,l) -> TyRecord(Map.map (fun _ -> f') l)
        | RawTApply(r,a,b) -> 
            match f a, f b with
            | TyRecord l, TySymbol n ->
                match Map.tryFind n l with
                | Some x -> x
                | None -> raise (TypeErrorException [r, RecordKeyNotFound n])
            | TyRecord _, b -> raise (TypeErrorException [r, ExpectedSymbolAsRecordKey b])
            | TyInl(env,(name,ka) :: x',body) & a, b ->
                let kb = tt b
                if ka = kb then
                    let env = Map.add name b env
                    match x' with
                    | [] -> substitute_tyvars body env
                    | _ -> TyInl(env,x',body)
                else
                    raise (TypeErrorException [r, KindError(a,b)])
            | a, b ->
                match tt a, tt b with
                | KindFun(ka, ka'), kb when ka = kb -> TyApp(a,b,ka')
                | _ -> raise (TypeErrorException [r, KindError(a,b)] )
        | RawTMetaVar _
        | RawTWildcard _ -> failwith "Compiler error: Metavars and wildcards are not allowed as inputs to this function."
        | RawTTerm(r,a) -> on_term (r,a)
    loop expr env

let eval_no_term expr env_ty = eval (fun _ -> failwith "Compiler error: Terms should not appear in `type` statements.") expr env_ty
let eval_term expr env_ty =
    let count_term = ref 0
    eval (fun _ -> let i = !count_term in incr count_term; TyMetavar(i,KindStar)) expr env_ty, !count_term

type Env = { ty : Map<string,T>; term : Map<string,T> }

let add_var s (k,v) = Map.add k (TyVar (k,v)) s
let add_vars ty vars = List.fold add_var ty vars
let top_type (name : VarString, vars : TypeVar list, expr : RawTExpr) (env : Env) =
    let vars = typevars vars
    let body =
        let env_ty = add_vars env.ty vars
        assert_bound_vars env.term env_ty (Choice2Of2 expr)
        eval_no_term expr env_ty
    {env with ty = Map.add name (TyInl(Map.empty,vars,body)) env.ty}

type TopHigherOrder =
    | HOUnion of name: string * id: int * (string * TT) list * RawTExpr list
    | HONominal of name: string * id: int * (string * TT) list * RawTExpr

type HigherOrderCases =
    | HOCUnion of (string * TT) list * Map<string,T>
    | HOCNominal of (string * TT) list * T
    | HOCRealNominal of (string * TT) list * RawTExpr

let top_higher_order (l : TopHigherOrder list) hoc (env : Env) =
    let env_ty =
        List.fold (fun s (HOUnion(name,i,vars,_) | HONominal(name,i,vars,_)) ->
            let tt = List.foldBack (fun (_,x) s -> KindFun(x,s)) vars KindStar
            Map.add name (TyHigherOrder(i,tt)) s
            ) env.ty l
    let errors = ResizeArray()
    let hoc =
        List.fold (fun hoc x ->
            match x with
            | HOUnion(_,i,vars,l) ->
                let env_ty = add_vars env_ty vars
                List.fold (fun cases expr ->
                    try assert_bound_vars env.term env_ty (Choice2Of2 expr)
                        match eval_no_term expr env_ty with
                        | TyPair(TySymbol x, b) -> 
                            if Map.containsKey x cases then errors.Add(range_of_texpr expr, DuplicateKeyInUnion); cases
                            else Map.add x b cases
                        | _ -> errors.Add (range_of_texpr expr, ExpectedSymbolAsUnionKey); cases
                    with :? TypeErrorException as x -> errors.AddRange(x.Data0); cases
                    ) Map.empty l
                |> fun l -> Map.add i (HOCUnion(vars,l)) hoc
            | HONominal(_,i,vars,expr) ->
                let env_ty = add_vars env_ty vars
                try assert_bound_vars env.term env_ty (Choice2Of2 expr)
                    let b, count_term = eval_term expr env_ty
                    let v = if 0 < count_term then HOCRealNominal(vars,expr) else HOCNominal(vars,b)
                    Map.add i v hoc
                with :? TypeErrorException as x -> errors.AddRange(x.Data0); hoc
            ) hoc l
    if 0 < errors.Count then raise (TypeErrorException (errors |> Seq.toList))
    hoc, {env with ty=env_ty}

let top_prototype (name,a,b,expr) (env : Env) =
    let tt = List.foldBack (fun (_,x) s -> KindFun(x,s)) b KindStar
    let l = (a,tt) :: b
    let env_ty = add_vars env.ty l
    assert_bound_vars env.term env_ty (Choice2Of2 expr)
    let body = eval_no_term expr env_ty |> List.foldBack (fun a b -> TyForall(a,b)) l
    {env with term = Map.add name body env.term}

open Spiral.Tokenize

let top_inl (r,name,body) (top_env : Env) =
    let errors = ResizeArray()
    let term' = ResizeArray()
    let kind = ResizeArray()
    let forallvar_scopes = System.Collections.Generic.Dictionary(HashIdentity.Reference)
    let fresh_kind () = let x = KindMetavar kind.Count in kind.Add(x); x
    let fresh_var () = let x = TyMetavar(term'.Count,fresh_kind()) in term'.Add(x); x

    let rec kind_get i =
        match kind.[i] with
        | KindMetavar i' when i <> i' -> let x = kind_get i' in kind.[i] <- x; x
        | x -> x

    let rec kind_subst = function
        | KindMetavar i -> kind_get i
        | KindFun(a,b) -> KindFun(kind_subst a,kind_subst b)
        | KindStar -> KindStar

    let rec term_get i =
        match term'.[i] with
        | TyMetavar(i',_) when i <> i' -> let x = term_get i' in term'.[i] <- x; x
        | x -> x

    let rec term_subst = function
        | TyVar _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ as x -> x
        | TyPair(a,b) -> TyPair(term_subst a, term_subst b)
        | TyRecord l -> TyRecord(Map.map (fun _ -> term_subst) l)
        | TyFun(a,b) -> TyFun(term_subst a, term_subst b)
        | TyForall(a,b) -> TyForall(a,term_subst b)
        | TyArray a -> TyArray(term_subst a)
        | TyApp(a,b,c) -> TyApp(term_subst a, term_subst b, c)
        | TyMetavar(i,_) -> term_get i
        | TyInl _ -> failwith "Compiler error: TyInl should have been substituted away by this point."

    let rec forall_eval (m : Map<string,T>) x =
        let f = forall_eval m
        match x with
        | TyMetavar _ | TyHigherOrder _ | TyB | TyPrim _ | TySymbol _ -> x
        | TyPair(a,b) -> TyPair(f a, f b)
        | TyRecord l -> TyRecord(Map.map (fun _ -> f) l)
        | TyFun(a,b) -> TyFun(f a, f b)
        | TyArray a -> TyArray(f a)
        | TyApp(a,b,c) -> TyApp(f a, f b, c)
        | TyVar(a,_) -> m.[a]
        | TyForall(a,b) -> forall_eval (Map.add (fst a) (TyVar a) m) b
        | TyInl _ -> failwith "Compiler error: TyInl should have been dealt with."

    let forall_subst_all x =
        let rec loop (m : Map<string,T>) = function
            | TyForall((n,k),b) ->
                let v = TyMetavar(term'.Count,k)
                term'.Add(v)
                let m = Map.add n x m
                loop m b
            | x -> forall_eval m x
        loop Map.empty x

    let forall_subst_single ((n,k),b) =
        let v = TyMetavar(term'.Count,k)
        term'.Add(v)
        let m = Map.add n v Map.empty
        forall_eval m b

    let unify_kind er (a : TT) (b : TT) : unit =
        let rec loop = function
            | KindStar, KindStar -> ()
            | KindFun(a,a'), KindFun(b,b') -> loop (a,b); loop (a',b')
            | KindMetavar a & a', KindMetavar b & b' -> if a < b then kind.[b] <- a' else kind.[a] <- b'
            | KindMetavar a, b | b, KindMetavar a -> kind.[a] <- b
            | _ -> raise (TypeErrorException [er])
        loop (kind_subst a, kind_subst b)
    let unify (r : Range) (got : T) (expected : T) : unit = 
        let unify_kind = unify_kind (r, KindError (got, expected))
        let er () = raise (TypeErrorException [r, TermError(got, expected)])
        let rec occurs_check i = 
            let f = occurs_check i
            function
            | TyHigherOrder _ | TyB | TyVar _ | TyPrim _ | TySymbol _ -> ()
            | TyForall (_,a) | TyArray a -> f a
            | TyApp(a,b,_) | TyFun(a,b) | TyPair(a,b) -> f a; f b
            | TyRecord l -> Map.iter (fun _ -> f) l
            | TyInl _ -> failwith "Compiler error: TyInl should not be here."
            | TyMetavar (i',_) -> if i = i' then er()
        let rec loop = function
            | TyVar(a,_), TyVar(b,_) when a <> b -> er ()
            | TyVar(a,_), TyVar(b,_) when System.Object.ReferenceEquals(a,b) = false -> raise (TypeErrorException [r, ForallVarScopeError(a,got,expected)])
            | (TyVar(a,_), TyMetavar(i,_) | TyMetavar(i,_), TyVar(a,_)) when i < forallvar_scopes.[a] -> raise (TypeErrorException [r,ForallMetavarScopeError(a,got,expected)])
            | TyMetavar(a,ka), TyMetavar(b,kb) ->
                unify_kind ka kb
                if a < b then term'.[b] <- got else term'.[a] <- expected
            | (TyMetavar(a,ka), b | b, TyMetavar(a,ka)) ->
                occurs_check a b
                unify_kind ka (tt b)
                term'.[a] <- b
            | (TyPair(a,b), TyPair(a',b') | TyFun(a,a'), TyFun(b,b') | TyApp(a,a',_), TyApp(b,b',_)) -> loop (a,b); loop (a',b')
            | TyRecord l, TyRecord l' ->
                let a,b = Map.toArray l, Map.toArray l'
                if a.Length <> b.Length then er ()
                else Array.iter2 (fun (_,a) (_,b) -> loop (a,b)) a b
            | TyHigherOrder(i,_), TyHigherOrder(i',_) -> if i <> i' then er()
            | TyB, TyB -> er()
            | TyPrim x, TyPrim x' -> if x <> x' then er()
            | TySymbol x, TySymbol x' -> if x <> x' then er()
            | TyArray a, TyArray b -> loop (a,b)
            | (TyForall(a,b), TyForall(a',b')) ->
                unify_kind (snd a) (snd a')
                loop (forall_subst_single(a,b), forall_subst_single(a',b'))
            | (TyInl _, _ | _, TyInl _) -> failwith "Compiler error: TyInl should have been substituted away by this time."
            | _ -> er ()

        try loop (term_subst got, term_subst expected)
        with :? TypeErrorException as e -> errors.AddRange e.Data0
           
    let rec term (env : Env) s x = 
        let f = term env
        let f' x = let v = fresh_var() in f v x; term_subst v
        let v x = Map.tryFind x env.term |> Option.orElseWith (fun () -> Map.tryFind x top_env.term)
        match x with
        | RawB r -> unify r s TyB
        | RawV(r,x) ->
            match v x with
            | Some x -> unify r s (forall_subst_all x)
            | None -> errors.Add(r, UnboundVariable UnboundVar)
        | RawLit(r,x) ->
            match x with
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
            |> unify r s
        | RawDefaultLit _ -> ()
        | RawSymbolCreate (r,x) -> unify r s (TySymbol x)
        | RawType(_,x) -> ty env s x
        | RawIfThenElse(_,cond,tr,fl) -> f (TyPrim BoolT) cond; f s tr; f s fl
        | RawIfThen(_,cond,tr) -> f (TyPrim BoolT) cond; f s tr
        | RawPairCreate(r,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify r s (TyPair(q, w))
            f q a; f w b
        | RawSeq(_,a,b) -> f TyB a; f s b
        | RawReal(_,a) -> assert_bound_vars' env.term env.ty (Choice1Of2 a) |> errors.AddRange
        | RawOp(_,_,l) -> List.iter (fun a -> assert_bound_vars' env.term env.ty (Choice1Of2 a) |> errors.AddRange) l
        | RawJoinPoint(_,a) -> f s a
        | RawApply(r,a',b) -> 
            match f' a' with
            | TyRecord l -> 
                let rec loop l = function
                    | TySymbol x ->
                        match Map.tryFind x l with
                        | Some x -> unify r s x
                        | None -> errors.Add(r,RecordIndexFailed x)
                    | TyPair(TySymbol x, b) ->
                        match Map.tryFind x l with
                        | Some (TyRecord l) -> loop l b
                        | Some a -> unify r a (TyFun(b,s))
                        | None -> errors.Add(r,RecordIndexFailed x)
                    | x -> errors.Add(r,ExpectedSymbolAsRecordKey x)
                loop l (f' b)
            | a -> let v = fresh_var() in unify (range_of_expr a') a (TyFun(v,s)); f v b
        | RawAnnot(_,a,b) -> ty env s b; f s a
        | RawForall(r,(_,(a,k)),b) ->
            let k = typevar k
            
            let v = TyVar(a,k)
            let i = term'.Count
            term'.Add(v)
            forallvar_scopes.Add(a,i)
            
            let x = fresh_var()
            unify r s (TyForall((a,k), x))
            term {env with ty=Map.add a v env.ty} x b
        | RawModuleOpen(_,(a,b),l,on_succ) ->
            let tryFind x =
                match Map.tryFind x top_env.term, Map.tryFind x top_env.ty with
                | Some (TyRecord a), Some (TyRecord b) -> Some (a,b)
                | _ -> None
            let bound_local, bound_global = Map.containsKey b env.term, tryFind b
            match bound_local, bound_global with
            | false, None -> errors.Add(a,UnboundVariable ModuleUnbound); env
            | true, Some _ -> errors.Add(a,UnboundVariable ModuleShadowed); env
            | true, None -> errors.Add(a,UnboundVariable ModuleShadowedAndUnbound); env
            | false, Some (m_term, m_ty) ->
                let rec loop (m_term,m_ty) = function
                    | (r,x) :: x' ->
                        match tryFind x with
                        | Some (m_term, m_ty) -> loop (m_term, m_ty) x'
                        | _ -> errors.Add(r,UnboundVariable ModuleIndexFailed); env
                    | [] -> 
                        let combine e m = Map.foldBack Map.add m e
                        {env with term=combine env.term m_term; ty=combine env.ty m_ty}
                loop (m_term, m_ty) l
            |> fun env -> term env s on_succ
        | RawRecordWith(r,l,withs,withouts) ->
            let i = errors.Count
            let record x =
                match f' x with
                | TyRecord m -> m
                | TyMetavar _ -> raise (TypeErrorException (if errors.Count = i then [range_of_expr x, MetavarsNotAllowedInRecordWith] else []))
                | _ -> raise (TypeErrorException [range_of_expr x, ExpectedRecord])
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
                            match v a |> Option.map term_subst with
                            | Some (TySymbol a) -> next ((r,a),b)
                            | Some x -> errors.Add(r, ExpectedSymbolAsRecordKey x); m
                            | None -> errors.Add(r, UnboundVariable UnboundVar); m
                        match x with
                        | RawRecordWithSymbol(a,b) -> with_symbol (a,b)
                        | RawRecordWithSymbolModify(a,b) -> with_symbol_modify (a,b)
                        | RawRecordWithInjectVar(a,b) -> with_injext with_symbol (a,b)
                        | RawRecordWithInjectVarModify(a,b) -> with_injext with_symbol_modify (a,b)
                        ) m withs
                let m =
                    List.fold (fun m -> function
                        | RawRecordWithoutSymbol(_,a) -> Map.remove a m
                        | RawRecordWithoutInjectVar(_,a) ->
                            match v a |> Option.map term_subst with
                            | Some (TySymbol a) -> Map.remove a m
                            | Some x -> errors.Add(r, ExpectedSymbolAsRecordKey x); m
                            | None -> errors.Add(r, UnboundVariable UnboundVar); m
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
        //| RawMatch of Range * body: RawExpr * (Pattern * RawExpr) list
        //| RawFun of Range * (Pattern * RawExpr) list
        //| RawRecBlock of Range * ((Range * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
        | RawTypecase _ -> failwith "Compiler error: `typecase` should not appear in the top down segment."
        | _ -> failwith "TODO"
    and ty (env : Env) s x =
        let f s x = ty env s x
        let f' s x = let s' = tt s in unify_kind (range_of_texpr x, ExpectedStarKind s') s' KindStar; f s x
        match x with
        | RawTWildcard _ -> ()
        | RawTB r -> unify r s TyB
        | RawTSymbol(r,x) -> unify r s (TySymbol x)
        | RawTPrim(r,x) -> unify r s (TyPrim x)
        | RawTArray(r,x) -> let v = fresh_var() in unify r s (TyArray v); f' v x
        | RawTVar(r,n) -> Map.tryFind n env.ty |> Option.iter (unify r s)
        | RawTPair(r,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify r s (TyPair(q,w))
            f' q a; f' w b
        | RawTFun(r,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify r s (TyFun(q,w))
            f' q a; f' w b
        | RawTRecord(_,l) -> 
            let l' = Map.map (fun _ _ -> fresh_var()) l
            unify r s (TyRecord l')
            Map.iter (fun k s -> f' s l.[k]) l'
        | RawTForall(_,(_,(name,kind)),b) -> let kind = typevar kind in TyForall((name, kind), loop b (Map.add name (TyVar(name,kind)) env))
        | RawTApply(r,a,b) -> 
            match f a, f b with
            | TyRecord l, TySymbol n ->
                match Map.tryFind n l with
                | Some x -> x
                | None -> raise (TypeErrorException [r, RecordKeyNotFound n])
            | TyRecord _, b -> raise (TypeErrorException [r, ExpectedSymbolAsRecordKey b])
            | TyInl(env,(name,ka) :: x',body) & a, b ->
                let kb = tt b
                if ka = kb then
                    let env = Map.add name b env
                    match x' with
                    | [] -> substitute_tyvars body env
                    | _ -> TyInl(env,x',body)
                else
                    raise (TypeErrorException [r, KindError(a,b)])
            | a, b ->
                match tt a, tt b with
                | KindFun(ka, ka'), kb when ka = kb -> TyApp(a,b,ka')
                | _ -> raise (TypeErrorException [r, KindError(a,b)] )
        | RawTMetaVar _ -> failwith "Compiler error: This particular metavar is only for typecase's clauses. This happens during the bottom-up segment."
        | RawTTerm(r,a) -> failwith "Compiler error: Terms are not allowed in types during the top-down segment."
    ()

open Spiral.Blockize
let tc (l : Bundle list) = 
    ()