module Spiral.Typechecking
open Spiral.BlockParsing
open Spiral.Infer

let var_of (name,kind) = {scope=0; constraints=Set.empty; kind=kind; name=name}
let typevars (l : TypeVar list) = List.map (fun (_,(a,b)) -> var_of (a, typevar b)) l
let add_var s x = Map.add x.name (TyVar x) s
let add_vars ty vars = List.fold add_var ty vars
let set_vars vars = List.map (fun x -> x.name) vars |> Set
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

let top_inl (r,name,expr,is_top_down) aux (top_env : Env) =
    if is_top_down then
        failwith ""
    else
        failwith ""

open Spiral.Blockize
let tc (l : Bundle list) = 
    ()