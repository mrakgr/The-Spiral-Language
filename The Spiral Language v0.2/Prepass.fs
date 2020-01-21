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
    | MissingVar
    | B
    | V of VarTag
    | Value of Tokenize.Value
    | Inline of Expr * ExprData // Acts as a join point for the prepass specifically.
    | Type of TExpr * ExprData
    | Inl of Expr * ExprData
    | Forall of Expr * ExprData
    | KeywordCreate of KeywordTag * Expr []
    | RecordWith of Expr [] * RecordWithPattern []
    | Op of Op * Expr []
    | TypedOp of ret_type: TExpr * Op * Expr []
    | Typecase of TExpr * (TExpr * Expr) []
    | ModuleOpen of string * (string * string option) list option * on_succ: Expr
    | Let of bind: Expr * on_succ: Expr
    | RecBlock of Expr [] * on_succ: Expr
    | PairTest of bind: VarTag * on_succ: Expr * on_fail: Expr
    | KeywordTest of KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordTest of RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    | AnnotTest of do_boxing : bool * TExpr * bind: VarTag * on_succ: Expr * on_fail: Expr
    | ValueTest of Tokenize.Value * bind: VarTag * on_succ: Expr * on_fail: Expr
    | DefaultValueTest of string * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnionTest of name: KeywordTag * vars: int * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnitTest of bind: VarTag * on_succ: Expr * on_fail: Expr
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

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: VarTag
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of VarString * var: VarTag * Expr // VarString here is for error messages in the partial evaluator.
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of VarString * var: VarTag

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

let prepass_body (keywords : KeywordEnv) (t_glob : Dictionary<string,TExpr>) (v_glob : Dictionary<string,Expr>) x = 
    let d() = Dictionary(HashIdentity.Structural)
    let env() = { exists=Set.empty; free_vars=d(); local=Map.empty; local_index = 0; local_index_max = ref 0}
    let fresh_env() = { type'=env(); value=env() }
    let dict_rawinline = Dictionary(HashIdentity.Reference)
    let v_missing_vars = ResizeArray()
    let t_missing_vars = ResizeArray()

    let expr_data_of (env_outer : LocEnv) (env_inner : LocEnv) (type_stack_size,value_stack_size): ExprData =
        let inline vars f (outer : Dictionary<string,'a>) (inner : Dictionary<string,'a>) =
            let kvs = Array.zeroCreate inner.Count
            let mutable i = 0
            inner |> Seq.iter (fun kv -> kvs.[i] <- kv.Key, -(f kv.Value); i <- i+1)
            Array.sortInPlaceBy snd kvs
            kvs |> Array.map (fun (k,_) -> f outer.[k])

        {
        type'= {
            stack_size = type_stack_size
            free_vars = vars (function TV(v) -> v | _ -> failwith "impossible TV") env_outer.type'.free_vars env_inner.type'.free_vars
            }
        value= {
            stack_size = value_stack_size
            free_vars = vars (function V(t) -> t | _ -> failwith "imposisble V") env_outer.value.free_vars env_inner.value.free_vars
            }
        }

    let value_add_local a (env : LocEnv) =
        {env with value = 
                    {env.value with
                        exists=Set.add a env.value.exists
                        local_index=env.value.local_index+1
                        local_index_max=max (env.value.local_index+1) !env.value.local_index_max
                        local=Map.add a (V env.value.local_index) env.value.local
                        }
            }

    let type_add_local a (env : LocEnv) =
        {env with type' = 
                    {env.type' with
                        exists=Set.add a env.type'.exists
                        local_index=env.type'.local_index+1
                        local_index_max=max (env.type'.local_index+1) !env.type'.local_index_max
                        local=Map.add a (TV env.type'.local_index) env.type'.local
                        }
            }

    let max' (t,v) (t',v') = max t t', max v v'
    let value_sz_add i (t,v) = t,v+i
    let type_sz_add i (t,v) = t+i,v
    let vlet env a b =
        let e,sz = b (value_add_local a env)
        e, value_sz_add 1 sz
    let tlet env a b =
        let e,sz = b (type_add_local a env)
        e, type_sz_add 1 sz

    let rec value_prepass (env : LocEnv) x =
        let em = 0, 0
        match x with
        | RawB -> B, em
        | RawV x -> 
            if Set.contains x env.value.exists then
                match Map.tryFind x env.value.local with
                | Some v -> v
                | None -> memoize env.value.free_vars (fun _ -> V (-1-env.value.free_vars.Count)) x
            else
                match v_glob.TryGetValue x with
                | true, v -> v
                | false, _ -> v_missing_vars.Add(x); MissingVar
            , em
        | RawValue x -> Value x, em
        | RawInline e ->
            memoize dict_rawinline (fun _ ->
                let env' = fresh_env()
                let e, sz = value_prepass env e
                Inline(e,expr_data_of env env' sz)
                ) x, em
        | RawType x -> type_prepass env x
        | RawInl (a,b) ->
            let env' = fresh_env()
            let e, sz = vlet env' a (fun env -> value_prepass env b)
            Inl(e,expr_data_of env env' sz), em
        | RawForall (a,b) ->
            let env' = fresh_env()
            let e, sz = tlet env' a (fun env -> value_prepass env b)
            Forall(e,expr_data_of env env' sz), em
        | RawKeywordCreate (a,b) ->
            let b,sz =
                Array.mapFold (fun sz x ->
                    let x,sz' = value_prepass env x
                    x,max' sz sz'
                    ) em b
            KeywordCreate(keywords.To a,b),sz
        | RawLet (a,b,on_succ) ->
            let b,sz = value_prepass env b
            let on_succ,sz' = vlet env a (fun env -> value_prepass env on_succ)
            Let(b,on_succ),max' sz sz'
        | RawRecordWith (a,b) ->
            let a,sz = Array.mapFold (fun sz x -> let x,sz' = value_prepass env a in x,max' sz sz') em a
            let b,sz = 
                Array.mapFold (fun sz -> function
                    | RawRecordWithKeyword(keyword,expr) -> 
                        let expr, sz' = vlet env "this" expr
                        RecordWithKeyword(keywords.To keyword, )
                    | RawRecordWithInjectVar(var,expr) -> RecordWithInjectVar(var,v var, f' (env_add "this" env) expr)
                    | RawRecordWithoutKeyword(keyword) -> RecordWithoutKeyword(string_to_keyword keyword)
                    | RawRecordWithoutInjectVar(var) -> RecordWithoutInjectVar(var,v var)
                    ) sz b
        | RawOp (a,b) -> failwith ""
        | RawTypedOp (a,b,c) -> failwith ""
        | RawTypecase (a,b) -> failwith ""
        | RawModuleOpen (a,b,on_succ) -> failwith ""
        
        | RawRecBlock (a,on_succ) -> failwith ""
        | RawPairTest (a,b,c,on_succ,on_fail) -> failwith ""
        | RawKeywordTest (a,b,c,on_succ,on_fail) -> failwith ""
        | RawRecordTest (a,b,on_succ,on_fail) -> failwith ""
        | RawAnnotTest (a,b,c,on_succ,on_fail) -> failwith ""
        | RawValueTest (a,b,on_succ,on_fail) -> failwith ""
        | RawDefaultValueTest (a,b,on_succ,on_fail) -> failwith ""
        | RawUnionTest (a,b,c,on_succ,on_fail) -> failwith ""
        | RawUnitTest (a,on_succ,on_fail) -> failwith ""
        | RawPos x -> failwith ""
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

    value_prepass (fresh_env()) x