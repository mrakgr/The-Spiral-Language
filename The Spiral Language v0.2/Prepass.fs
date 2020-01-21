module Spiral.Prepass

open System.Collections.Generic
open Spiral.Utils
open Spiral.Parsing

type VarTag = int
type FreeVars = VarTag []
type StackSize = int
type KeywordTag = int

type Data = {free_vars : int []; stack_size : StackSize}
type ExprData = {type' : Data; value : Data}

type [<ReferenceEquality>] Expr =
    | Error of string
    | B
    | V of VarTag
    | Value of Tokenize.Value
    | Type of TExpr
    | Inline of Expr * ExprData // Acts as a join point for the prepass specifically.
    | Inl of Expr * ExprData
    | Forall of Expr * ExprData
    | KeywordCreate of KeywordTag * Expr []
    | RecordWith of Expr [] * RecordWithPattern []
    | Op of Op * Expr []
    | TypedOp of ret_type: TExpr * Op * Expr []
    | Typecase of TExpr * (TExpr * Expr) []
    | Module of Map<KeywordTag, Expr>
    | ModuleOpen of Expr [] * on_succ: Expr
    | Let of bind: Expr * on_succ: Expr
    | RecBlock of Expr [] * on_succ: Expr
    | PairTest of bind: Expr * on_succ: Expr * on_fail: Expr
    | KeywordTest of KeywordTag * bind: Expr * on_succ: Expr * on_fail: Expr
    | RecordTest of RecordTestPattern [] * bind: Expr * on_succ: Expr * on_fail: Expr
    | AnnotTest of do_boxing : bool * TExpr * bind: Expr * on_succ: Expr * on_fail: Expr
    | ValueTest of Tokenize.Value * bind: Expr * on_succ: Expr * on_fail: Expr
    | DefaultValueTest of string * bind: Expr * on_succ: Expr * on_fail: Expr
    | UnionTest of name: KeywordTag * vars: int * bind: Expr * on_succ: Expr * on_fail: Expr
    | UnitTest of bind: Expr * on_succ: Expr * on_fail: Expr
    | Pos of Pos<Expr>
and [<ReferenceEquality>] TExpr =
    | TV of VarTag
    | TPair of TExpr * TExpr
    | TFun of TExpr * TExpr
    | TRecord of Map<string,TExpr>
    | TKeyword of KeywordTag * TExpr []
    | TApply of TExpr * TExpr
    | TInl of TExpr * ExprData
    | TUnit
    | TPrim of PrimitiveType
    | TArray of TExpr
    | TPos of Pos<TExpr>

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: Expr
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of var: Expr * Expr
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of var: Expr

type Env<'a> = { exists : Set<string>; free_vars : Dictionary<string,'a>; local : Map<string,'a>; local_index : int; local_index_max : int ref }
type LocEnv = { type' : Env<TExpr>; value : Env<Expr> }
type KeywordEnv = 
    {
    to' : Dictionary<string,int>
    from : Dictionary<int,string>
    }

    member d.To(x: string) =
        match d.to'.TryGetValue x with
        | true, v -> v
        | false, _ ->
            let tag_keyword = d.to'.Count
            d.to'.[x] <- tag_keyword
            d.from.[tag_keyword] <- x
            tag_keyword

    member d.From(x : int) = d.from.[x] // Should never fail.

type PrepassError =
    | ErMissingValueVar of string
    | ErMissingModuleItem of string
    | ErMissingTypeVar of string
    | ErMissingModule of string

let prepass_body (keywords : KeywordEnv) (t_glob : Dictionary<string,TExpr>) (v_glob : Dictionary<string,Expr>) x = 
    let d() = Dictionary(HashIdentity.Structural)
    let env exists = { exists=exists; free_vars=d(); local=Map.empty; local_index = 0; local_index_max = ref 0}
    let fresh_env env' = { type'=env env'.type'.exists; value=env env'.value.exists}
    let fresh_env'() = { type'=env Set.empty; value=env Set.empty }
    let dict_rawinline = Dictionary(HashIdentity.Reference)
    let errors = ResizeArray()

    let expr_data_of (env_outer : LocEnv) (env_inner : LocEnv): ExprData =
        let inline vars f (outer : Dictionary<string,'a>) (inner : Dictionary<string,'a>) = // TODO: Not correct.
            let kvs = Array.zeroCreate inner.Count
            let mutable i = 0
            inner |> Seq.iter (fun kv -> kvs.[i] <- kv.Key, -(f kv.Value); i <- i+1)
            Array.sortInPlaceBy snd kvs
            kvs |> Array.map (fun (k,_) -> f outer.[k])

        {
        type'= {
            stack_size = !env_inner.type'.local_index_max
            free_vars = vars (function TV(v) -> v | _ -> failwith "impossible TV") env_outer.type'.free_vars env_inner.type'.free_vars
            }
        value= {
            stack_size = !env_inner.value.local_index_max
            free_vars = vars (function V(t) -> t | _ -> failwith "imposisble V") env_outer.value.free_vars env_inner.value.free_vars
            }
        }

    let value_add_local a (env : LocEnv) =
        let env = 
            {env with value = 
                        {env.value with
                            exists=Set.add a env.value.exists
                            local_index=env.value.local_index+1
                            local=Map.add a (V env.value.local_index) env.value.local
                            }
                }
        env.value.local_index_max := max !env.value.local_index_max env.value.local_index
        env

    let type_add_local a (env : LocEnv) =
        let env = 
            {env with type' = 
                        {env.type' with
                            exists=Set.add a env.type'.exists
                            local_index=env.type'.local_index+1
                            local=Map.add a (TV env.type'.local_index) env.type'.local
                            }
                }
        env.type'.local_index_max := max !env.type'.local_index_max env.value.local_index
        env

    let er_missing_value_var x = errors.Add(ErMissingValueVar x); Error (sprintf "missing value var %s" x)
    let er_missing_type_var x = errors.Add(ErMissingTypeVar x); Error (sprintf "missing type var %s" x)
    let er_missing_module_item x = errors.Add(ErMissingModuleItem x); Error (sprintf "missing module item %s" x)
    let er_missing_module x = errors.Add(ErMissingModule x); Error (sprintf "missing module %s" x)

    let rec value_prepass (env : LocEnv) x =
        let v x = 
            if Set.contains x env.value.exists then
                match Map.tryFind x env.value.local with
                | Some v -> v
                | None -> memoize env.value.free_vars (fun _ -> V (-1-env.value.free_vars.Count)) x
            else
                match v_glob.TryGetValue x with
                | true, v -> v
                | false, _ -> er_missing_value_var x
        match x with
        | RawB -> B
        | RawV x -> v x
        | RawValue x -> Value x
        | RawInline e -> // TODO: Completely broken.
            let e,tc,vc =
                memoize dict_rawinline (fun _ ->
                    let t_max,v_max = !env.type'.local_index_max, !env.value.local_index_max
                    let env' = fresh_env env
                    let e = value_prepass env e
                    let t_max',v_max' = !env.type'.local_index_max, !env.value.local_index_max
                    Inline(e,expr_data_of env env'),t_max'-t_max,v_max'-v_max
                    ) x
            
            e
        | RawType x -> Type(type_prepass env x)
        | RawInl (a,b) ->
            let env' = fresh_env env |> value_add_local a
            let b = value_prepass env' b
            Inl(b,expr_data_of env env')
        | RawForall (a,b) ->
            let env' = fresh_env env |> type_add_local a
            let b = value_prepass env' b
            Forall(b,expr_data_of env env')
        | RawKeywordCreate (a,b) ->
            let b = Array.map (value_prepass env) b
            KeywordCreate(keywords.To a,b)
        | RawLet (a,b,on_succ) ->
            let b = value_prepass env b
            let on_succ = value_prepass (value_add_local a env) on_succ
            Let(b,on_succ)
        | RawRecordWith (a,b) ->
            let a = Array.map (value_prepass env) a
            let b = 
                Array.map (function
                    | RawRecordWithKeyword(keyword,expr) -> RecordWithKeyword(keywords.To keyword, value_prepass (value_add_local "this" env) expr)
                    | RawRecordWithInjectVar(var,expr) -> RecordWithInjectVar(v var, value_prepass (value_add_local "this" env) expr)
                    | RawRecordWithoutKeyword(keyword) -> RecordWithoutKeyword(keywords.To keyword)
                    | RawRecordWithoutInjectVar(var) -> RecordWithoutInjectVar(v var)
                    ) b
            RecordWith(a,b)
        | RawOp (a,b) -> Op(a,Array.map (value_prepass env) b)
        | RawTypedOp (a,b,c) -> TypedOp(type_prepass env a, b, Array.map (value_prepass env) c)
        | RawTypecase (a,b) -> Typecase(type_prepass env a, Array.map (fun (a,b) -> type_prepass env a, value_prepass env b) b)
        | RawModuleOpen (a,b,on_succ) -> 
            match v_glob.TryGetValue a with
            | false, _ -> er_missing_value_var a
            | true, Module x ->
                match b with
                | None -> 
                    let env = Map.fold (fun env k v -> value_add_local (keywords.From k) env) env x
                    ModuleOpen(Map.toArray x |> Array.map snd, value_prepass env on_succ)
                | Some l ->
                    let l,env =
                        List.mapFold (fun env (a,b) ->
                            match Map.tryFind (keywords.To a) x with
                            | Some e -> e
                            | None -> er_missing_module_item a
                            , value_add_local (Option.defaultValue a b) env
                            ) env l
                    ModuleOpen(List.toArray l, value_prepass env on_succ)
            | true, _ -> er_missing_module a
        | RawRecBlock (a,on_succ) ->
            let env = Array.fold (fun env (a,_) -> value_add_local a env) env a
            RecBlock(Array.map (snd >> value_prepass env) a, value_prepass env on_succ)
        | RawPairTest (a,b,c,on_succ,on_fail) ->
            let env = env |> value_add_local a |> value_add_local b
            PairTest(v c,value_prepass env on_succ,value_prepass env on_fail)
        | RawKeywordTest (a,b,c,on_succ,on_fail) ->
            let env = Array.fold (fun env x -> value_add_local x env) env b
            KeywordTest(keywords.To a,v c,value_prepass env on_succ,value_prepass env on_fail)
        | RawRecordTest (a,b,on_succ,on_fail) ->
            let a,env =
                Array.mapFold (fun env -> function
                    | RawRecordTestKeyword (a,b) -> RecordTestKeyword(keywords.To a), value_add_local b env
                    | RawRecordTestInjectVar (a,b) -> RecordTestInjectVar(v a), value_add_local b env
                    ) env a
            RecordTest(a,v b,value_prepass env on_succ,value_prepass env on_fail)
        | RawAnnotTest (a,b,c,on_succ,on_fail) -> AnnotTest(a,type_prepass env b,v c,value_prepass env on_succ,value_prepass env on_fail)
        | RawValueTest (a,b,on_succ,on_fail) -> ValueTest(a,v b,value_prepass env on_succ,value_prepass env on_fail)
        | RawDefaultValueTest (a,b,on_succ,on_fail) -> DefaultValueTest(a,v b,value_prepass env on_succ,value_prepass env on_fail)
        | RawUnionTest (a,b,c,on_succ,on_fail) -> 
            let env = Array.fold (fun env x -> value_add_local x env) env b
            UnionTest(keywords.To a,b.Length,v c,value_prepass env on_succ,value_prepass env on_fail)
        | RawUnitTest (a,on_succ,on_fail) -> UnitTest(v a,value_prepass env on_succ,value_prepass env on_fail)
        | RawPos x -> Pos(Parsing.Pos(x.Pos,value_prepass env x.Expression))
    and type_prepass (env : LocEnv) x =
        match x with
        | RawTVar x -> failwith ""
        | RawTPair (a,b) -> failwith ""
        | RawTFun (a,b) -> failwith ""
        | RawTConstraint (a,b) -> failwith ""
        | RawTDepConstraint (a,b) -> failwith ""
        | RawTRecord x -> failwith ""
        | RawTKeyword (a,b) -> failwith ""
        | RawTApply (a,b) -> failwith ""
        | RawTForall (a,b) -> failwith ""
        | RawTInl (a,b) -> failwith ""
        | RawTUnit -> failwith ""
        | RawTPrim x -> failwith ""
        | RawTArray x -> failwith ""
        | RawTPos x -> failwith ""

    value_prepass (fresh_env'()) x