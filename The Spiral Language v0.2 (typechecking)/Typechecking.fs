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

type TypeError =
    | ExpectedStartKind of TT
    | KindError of TT * TT
    | RecordKeyNotFound of string
    | ExpectedSymbolAsRecordKey of T

exception TypeErrorException of Range * TypeError
exception TermException of Range
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

let rec eval (expr : RawTExpr) (env : Map<string, T>) =
    let f x = eval x env
    let f' x =
        let r = f x
        match tt r with
        | KindStar -> r
        | s -> raise (TypeErrorException(range_of_texpr x, ExpectedStartKind s))
    match expr with
    | RawTB _ -> TyB
    | RawTSymbol(_,x) -> TySymbol x
    | RawTForall(_,(_,a),b) -> TyForall((fst a, typevar (snd a)), f b)
    | RawTPrim(_,x) -> TyPrim x
    | RawTArray(_,x) -> TyArray(f x)
    | RawTVar(r,n) -> env.[n]
    | RawTPair(_,a,b) -> TyPair(f' a, f' b)
    | RawTFun(_,a,b) -> TyFun(f' a, f' b)
    | RawTRecord(_,l) -> TyRecord(Map.map (fun _ -> f') l)
    | RawTApply(r,a,b) -> 
        match f a, f b with
        | TyRecord l, TySymbol n ->
            match Map.tryFind n l with
            | Some x -> x
            | None -> raise (TypeErrorException (r, RecordKeyNotFound n))
        | TyRecord _, b -> raise (TypeErrorException (r, ExpectedSymbolAsRecordKey b))
        | TyInl(env,(name,ka) :: x',body), b ->
            let kb = tt b
            if ka = kb then
                let env = Map.add name b env
                match x' with
                | [] -> substitute_tyvars body env
                | _ -> TyInl(env,x',body)
            else
                raise (TypeErrorException (r, KindError(ka,kb)))
        | a, b ->
            match tt a, tt b with
            | KindFun(ka, ka'), kb when ka = kb -> TyApp(a,b,ka')
            | ka, kb -> raise (TypeErrorException (r, KindError(ka,kb)))
    | RawTMetaVar _
    | RawTWildcard _ -> failwith "Compiler error: Invalid node in this function."
    | RawTTerm(r,_) -> raise (TermException r)

type VariableBoundError =
    | UnboundVar
    | ModuleUnbound
    | ModuleShadowed
    | ModuleShadowedAndUnbound
    | ModuleIndexFailed

let unbound_vars (env_term : Map<string,T>) (env_ty : Map<string,T>) (x : RawExpr) =
    let errors = ResizeArray()
    let rec cterm term ty x =
        let check (a,b) = if Set.contains b term = false && Map.containsKey b env_term = false then errors.Add(a,UnboundVar)
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
            | false, None -> errors.Add(a,ModuleUnbound)
            | true, Some _ -> errors.Add(a,ModuleShadowed)
            | true, None -> errors.Add(a,ModuleShadowedAndUnbound)
            | false, Some (m_term, m_ty) ->
                let rec loop (m_term,m_ty) = function
                    | (r,x) :: x' ->
                        match tryFind x with
                        | Some (m_term, m_ty) -> loop (m_term, m_ty) x'
                        | _ -> errors.Add(r,ModuleIndexFailed)
                    | [] -> 
                        let combine e m = Map.fold (fun s k _ -> Set.add k s) e m
                        cterm (combine term m_term) (combine ty m_ty) on_succ
                loop (m_term, m_ty) l
        | RawSeq(_,a,b) | RawPairCreate(_,a,b) | RawIfThen(_,a,b) | RawApply(_,a,b) -> cterm term ty a; cterm term ty b
        | RawIfThenElse(_,a,b,c) -> cterm term ty a; cterm term ty b; cterm term ty c
    and ctype term ty x =
        let check (a,b) = if Set.contains b ty = false && Map.containsKey b env_ty = false then errors.Add(a,UnboundVar)
        match x with
        | RawTPrim _ | RawTWildcard _ | RawTB _ | RawTSymbol _ | RawTMetaVar _ -> ()
        | RawTVar(a,b) -> check (a,b)
        | RawTPair(_,a,b) | RawTApply(_,a,b) | RawTFun(_,a,b) -> ctype term ty a; ctype term ty b
        | RawTRecord(_,l) -> Map.iter (fun k -> ctype term ty) l
        | RawTForall(_,(_,(a,_)),b) -> ctype term (Set.add a ty) b
        | RawTArray(_,a) -> ctype term ty a
        | RawTTerm (_,a) -> cterm term ty a
    and cpattern term ty x =
        let rec loop term x = 
            let f = loop term
            match x with
            | PatSymbol _ | PatB _ | PatE _ -> Set.empty
            | PatVar(_,b) -> Set.singleton b
            | PatDyn(_,x) | PatUnbox(_,x) -> loop x
            | PatAnnot(_,a,b) -> let r = loop a in ctype (r + term) ty b; r
            | PatPair(_,a,b) -> loop a + loop b
            | PatRecordMembers(_,l) ->
                List.fold (fun s x ->
                    let check (a,b) = if (Set.contains b s || Set.contains b term || Map.containsKey b env_term) = false then errors.Add(a,UnboundVar)
                    match x with
                    | PatRecordMembersSymbol(_,b) -> s + loop b
                    | PatRecordMembersInjectVar(a,b) -> check a
                    ) Set.empty l
            | PatActive of Range * RawExpr * Pattern
            | PatOr of Range * Pattern * Pattern
            | PatAnd of Range * Pattern * Pattern
            | PatValue of Range * Literal
            | PatDefaultValue of Range * VarString
            | PatWhen of Range * Pattern * RawExpr
            | PatNominal of Range * VarString * Pattern
        loop x

    cterm Set.empty Set.empty x

let top_type (name : VarString, vars : TypeVar list, expr : RawTExpr) (env : Map<string, T>) = // TODO: Check for unbound vars.
    let vars = typevars vars
    let body = eval expr (List.fold (fun s (k,v) -> Map.add k (TyVar (k,v)) s) env vars)
    Map.add name (TyInl(Map.empty,vars,body)) env

let tc (l : Bundle list) = 
    ()
    