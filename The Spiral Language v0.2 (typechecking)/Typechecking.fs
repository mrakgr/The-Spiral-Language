module Spiral.Typechecking

open Spiral.Config
open Spiral.BlockParsing
open Spiral.Blockize

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

let tt = function
    | TyHigherOrder(_,x) | TyApp(_,_,x) | TyMetavar(_,x) | TyVar(_,x) -> x
    | TyB | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyPair _ | TySymbol _ | TyArray _ -> KindStar
    | TyInl(_,x,_) -> List.foldBack (fun (_,a) b -> KindFun(a,b)) x KindStar

let rec typevar = function
    | RawKindStar -> KindStar
    | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
let typevars (l : TypeVar list) = List.map (fun (_,(a,b)) -> a, typevar b) l

type VariableBoundError =
    | UnboundVar
    | ModuleUnbound
    | ModuleShadowed
    | ModuleShadowedAndUnbound
    | ModuleIndexFailed

type TypeError =
    | ExpectedStartKind of TT
    | KindError of TT * TT
    | RecordKeyNotFound of string
    | ExpectedSymbolAsRecordKey of T
    | UnboundVariable of VariableBoundError
    | ExpectedSymbolAsUnionKey
    | DuplicateKeyInUnion

exception TypeErrorException of (Range * TypeError) list
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
            | TyInl(env,(name,ka) :: x',body), b ->
                let kb = tt b
                if ka = kb then
                    let env = Map.add name b env
                    match x' with
                    | [] -> substitute_tyvars body env
                    | _ -> TyInl(env,x',body)
                else
                    raise (TypeErrorException [r, KindError(ka,kb)])
            | a, b ->
                match tt a, tt b with
                | KindFun(ka, ka'), kb when ka = kb -> TyApp(a,b,ka')
                | ka, kb -> raise (TypeErrorException [r, KindError(ka,kb)] )
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

let tc (l : Bundle list) = 
    ()
    