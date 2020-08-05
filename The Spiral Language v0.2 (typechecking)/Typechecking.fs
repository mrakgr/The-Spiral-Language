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
    | ExpectedStartKind of TT
    | KindError of T * T
    | RecordKeyNotFound of string
    | ExpectedSymbolAsRecordKey of T
    | UnboundVariable of VariableBoundError
    | ExpectedSymbolAsUnionKey
    | DuplicateKeyInUnion
    | TermError of T * T
    | ForallVarScopeError of string * T * T
    | ForallMetavarScopeError of string * T * T

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

let assert_bound_vars (env_term : Map<string,T>) (env_ty : Map<string,T>) x =
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
    if 0 < errors.Count then raise (TypeErrorException (errors |> Seq.toList))

let inline eval on_term expr env =
    let rec loop expr (env : Map<string, T>) = 
        let f x = loop x env
        let f' x =
            let r = f x
            match tt r with
            | KindStar -> r
            | s -> raise (TypeErrorException [range_of_texpr x, ExpectedStartKind s])
        match expr with
        | RawTB _ -> TyB
        | RawTSymbol(_,x) -> TySymbol x
        | RawTForall(_,(_,(name,kind)),b) -> let kind = typevar kind in TyForall((name, kind), loop b (Map.add name (TyVar(name,kind)) env))
        | RawTPrim(_,x) -> TyPrim x
        | RawTArray(_,x) -> TyArray(f x)
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

let top_inl (r,name,body) =
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

    let unify (r : Range) (got : T) (expected : T) : unit = 
        let unify_kind (a : TT) (b : TT) : unit =
            let rec loop = function
                | KindStar, KindStar -> ()
                | KindFun(a,a'), KindFun(b,b') -> loop (a,b); loop (a',b')
                | KindMetavar a & a', KindMetavar b & b' -> if a < b then kind.[b] <- a' else kind.[a] <- b'
                | KindMetavar a, b | b, KindMetavar a -> kind.[a] <- b
                | _ -> raise (TypeErrorException [r, KindError (got, expected)])
            loop (kind_subst a, kind_subst b)
        let er () = raise (TypeErrorException [r, TermError(got, expected)])
        let rec loop = function
            | TyVar(a,_), TyVar(b,_) when a <> b -> er ()
            | TyVar(a,_), TyVar(b,_) when System.Object.ReferenceEquals(a,b) = false -> raise (TypeErrorException [r, ForallVarScopeError(a,got,expected)])
            | (TyVar(a,_), TyMetavar(i,_) | TyMetavar(i,_), TyVar(a,_)) when i < forallvar_scopes.[a] -> raise (TypeErrorException [r,ForallMetavarScopeError(a,got,expected)])
            | TyMetavar(a,ka), TyMetavar(b,kb) -> 
                unify_kind ka kb
                if a < b then term'.[b] <- got else term'.[a] <- expected
            | (TyMetavar(a,ka), b | b, TyMetavar(a,ka)) -> 
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
           
    let rec term x (env : Env) = 
        let f x = term x env
        match x with
        | RawB _ -> TyB
        | RawV(r,x) ->
            match Map.tryFind x env.term with
            | Some x -> forall_subst_all x
            | None -> errors.Add(r, UnboundVariable UnboundVar); fresh_var()
        | RawLit(_,x) ->
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
        | RawDefaultLit _ -> fresh_var()
        | RawSymbolCreate (_,x) -> TySymbol x
        | RawType(_,x) -> ty x env
        | RawIfThenElse(_,cond,tr,fl) ->
            unify (range_of_expr cond) (f cond) (TyPrim BoolT)
            let tr = f tr
            unify (range_of_expr fl) (f fl) tr
            tr
        | RawIfThen(_,cond,tr) ->
            unify (range_of_expr cond) (f cond) (TyPrim BoolT)
            let x = f tr
            unify (range_of_expr tr) x TyB
            x
        | RawPairCreate(_,a,b) -> TyPair(f a, f b)
        | RawSeq(_,a,b) ->
            unify (range_of_expr a) (f a) TyB
            f b
        | RawReal(_,a) ->
            try assert_bound_vars env.term env.ty (Choice1Of2 a)
            with :? TypeErrorException as e -> errors.AddRange(e.Data0)
            fresh_var()
        | RawOp(_,_,l) ->
            List.iter (fun a ->
                try assert_bound_vars env.term env.ty (Choice1Of2 a)
                with :? TypeErrorException as e -> errors.AddRange(e.Data0)
                ) l
            fresh_var()
        | RawJoinPoint(_,a) -> f a
        | RawApply(_,a,b) -> 
            let q,w = fresh_var(), fresh_var()
            unify (range_of_expr a) (f a) (TyFun(q,w))
            unify (range_of_expr b) (f b) q
            w
        | RawAnnot(_,a,b) ->
            let x = f a
            let b = ty b env
            unify (range_of_expr a) x b
            x
        | RawForall(_,(_,(a,k)),b) ->
            let k = typevar k
            let v = TyVar(a,k)
            let i = term'.Count
            fresh_var() |> ignore
            forallvar_scopes.Add(a,i)
            TyForall((a,k), term b {env with ty=Map.add a v env.ty})
        //| RawModuleOpen of Range * (Range * VarString) * (Range * SymbolString) list * on_succ: RawExpr
        //| RawRecordWith of Range * RawExpr list * RawRecordWith list * RawRecordWithout list
        //| RawMatch of Range * body: RawExpr * (Pattern * RawExpr) list
        //| RawFun of Range * (Pattern * RawExpr) list
        //| RawRecBlock of Range * ((Range * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
        | RawTypecase _ -> failwith "Compiler error: `typecase` should not appear in the top down segment."
        | _ -> failwith "TODO"
    ()

open Spiral.Blockize
let tc (l : Bundle list) = 
    ()