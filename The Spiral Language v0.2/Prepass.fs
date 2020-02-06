module Spiral.Prepass

open System.Collections.Generic
open Spiral.Utils
open Spiral.Tokenize
open Spiral.Parsing
open System.Text

type VarTag = int
type FreeVars = VarTag []
type StackSize = int
type KeywordTag = int

type Data = {free_vars : int []; stack_size : StackSize}
type ExprData = {type' : Data; value : Data}

type [<ReferenceEquality>] Expr =
    | B
    | V of VarTag
    | Lit of Literal
    | Type of TExpr
    | Inline of Expr * ExprData // Acts as a join point for the prepass specifically.
    | Inl of Expr * ExprData
    | Glob of Expr ref // Used for recursive functions and blocks.
    | Forall of Expr * ExprData
    | KeywordCreate of KeywordTag * Expr []
    | RecordWith of Expr [] * RecordWithPattern []
    | Op of Op * Expr []
    | JoinPoint of TExpr option * Expr
    | Annot of TExpr * Expr
    | Typecase of TExpr * (TExpr * Expr) []
    | Module of Map<KeywordTag, Expr>
    | Let of bind: Expr * on_succ: Expr
    | RecBlock of Expr [] * on_succ: Expr
    | PairTest of bind: VarTag * on_succ: Expr * on_fail: Expr
    | KeywordTest of KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    | RecordTest of RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    | AnnotTest of do_boxing : bool * TExpr * bind: VarTag * on_succ: Expr * on_fail: Expr
    | LitTest of Literal * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnionTest of name: KeywordTag * vars: int * bind: VarTag * on_succ: Expr * on_fail: Expr
    | UnitTest of bind: VarTag * on_succ: Expr * on_fail: Expr
    | Pos of Pos<Expr>
and [<ReferenceEquality>] TExpr =
    | TV of VarTag
    | TPair of TExpr * TExpr
    | TFun of TExpr * TExpr
    | TRecord of Map<KeywordTag,TExpr>
    | TKeyword of KeywordTag * TExpr []
    | TApply of TExpr * TExpr
    | TInl of TExpr * Data
    | TUnit
    | TPrim of PrimitiveType
    | TArray of TExpr
    | TModule of Map<KeywordTag, TExpr>
    | TPos of Pos<TExpr>
    

and RecordTestPattern = RecordTestKeyword of keyword: KeywordTag | RecordTestInjectVar of var: Expr
and RecordWithPattern = 
    | RecordWithKeyword of keyword: KeywordTag * Expr 
    | RecordWithInjectVar of var_string: string * var: Expr * Expr // var_string is here for error reporting purposes.
    | RecordWithoutKeyword of keyword: KeywordTag
    | RecordWithoutInjectVar of var_string: string * var: Expr

type Env<'a> = { global' : Map<string,'a>; free_vars : Dictionary<string,VarTag>; local : Map<string,VarTag>; local_index : int; local_index_max : int ref }
type LocEnv = { type' : Env<TExpr>; value : Env<Expr> }
type KeywordEnv() = 
    let to' = Dictionary(HashIdentity.Structural)
    let from = Dictionary(HashIdentity.Structural)

    member d.To(x: string) =
        match to'.TryGetValue x with
        | true, v -> v
        | false, _ ->
            let tag_keyword = to'.Count
            to'.[x] <- tag_keyword
            from.[tag_keyword] <- x
            tag_keyword

    member d.From(x : int) = from.[x] // Should never fail.

type PrepassError =
    | ErMissingValueVar of string
    | ErMissingModuleItem of string
    | ErMissingTypeVar of string
    | ErMissingModule of string
    | ErNotAModule of string
    | ErLocalShadowsGlobal of string
    | ErTypeFunctionHasFreeValueVar of string
    | ErTypeFunctionHasNonZeroValueStackSize of string
    | ErDefaultValueParse of string

let prepass (var_positions : Dictionary<string,ParserCombinators.PosKey>) (keywords : KeywordEnv) (t_glob : Map<string,TExpr>) (v_glob : Map<string,Expr>) x = 
    let d() = Dictionary(HashIdentity.Structural)
    let env global' = { global'=global'; free_vars=d(); local=Map.empty; local_index = 0; local_index_max = ref 0}
    let fresh_env env' = { type'=env env'.type'.global'; value=env env'.value.global' }
    let dict_rawinline = Dictionary(HashIdentity.Reference)
    let errors = ResizeArray()
    let t_new = ResizeArray()
    let v_new = ResizeArray()

    let add_local a (env : Env<_>) =
        if Map.containsKey a env.global' then errors.Add(ErLocalShadowsGlobal a)
        let env = 
            {env with
                local_index=env.local_index+1
                local=Map.add a env.local_index env.local
                }
        env.local_index_max := max !env.local_index_max env.local_index
        env
    let value_add_local a (env : LocEnv) = {env with value = add_local a env.value}
    let type_add_local a (env : LocEnv) = {env with type' = add_local a env.type'}

    let v_loc env x = 
        match Map.tryFind x env.local with
        | Some v -> v
        | None -> memoize env.free_vars (fun _ -> -1-env.free_vars.Count) x

    let expr_data_of (env_outer : LocEnv) (env_inner : LocEnv): ExprData =
        let inline vars (outer : Env<'a>) (inner : Env<'a>) =
            let kvs = Array.zeroCreate inner.free_vars.Count
            let mutable i = 0
            inner.free_vars |> Seq.iter (fun kv -> kvs.[i] <- kv.Key, -kv.Value; i <- i+1)
            Array.sortInPlaceBy snd kvs
            kvs |> Array.map (fun (k,_) -> v_loc outer k)

        {
        type'= {
            stack_size = !env_inner.type'.local_index_max
            free_vars = vars env_outer.type' env_inner.type'
            }
        value= {
            stack_size = !env_inner.value.local_index_max
            free_vars = vars env_outer.value env_inner.value
            }
        }

    let module_open (t,v as env) a b =
        match Map.tryFind a t with
        | None -> errors.Add(ErMissingModule a); env
        | Some (TModule t') ->
            match Map.tryFind a v with
            | None -> errors.Add(ErMissingModule a); env
            | Some (Module v') ->
                match b with
                | None -> 
                    let f x x' = Map.fold (fun env k v -> Map.add (keywords.From k) v env) x x'
                    f t t', f v v'
                | Some l ->
                    List.fold (fun env (a,b) ->
                        match a with
                        | OpenValue a ->
                            match Map.tryFind (keywords.To a) v' with
                            | Some e ->  t, Map.add (Option.defaultValue a b) e v
                            | None -> errors.Add(ErMissingModuleItem a); env
                        | OpenType a ->
                            match Map.tryFind (keywords.To a) t' with
                            | Some e ->   Map.add (Option.defaultValue a b) e t, v
                            | None -> errors.Add(ErMissingModuleItem a); env
                        ) env l
            | Some _ -> errors.Add(ErNotAModule a); env
        | Some _ -> errors.Add(ErNotAModule a); env

    let parse_default_lit (a : string) on_succ =
        match System.Int64.TryParse(a) with
        | true,x -> on_succ (LitInt64 x)
        | false,_ ->
            match System.Double.TryParse(a) with
            | true,x -> on_succ (LitFloat64 x)
            | false,_ -> errors.Add(ErMissingValueVar a); B

    let rec prepass_value (env : LocEnv) x =
        let v' x = v_loc env.value x
        let v x = 
            match env.value.global'.TryGetValue x with
            | true, v -> v
            | false, _ -> V (v' x)

        match x with
        | RawB -> B
        | RawV x -> v x
        | RawLit x -> Lit x
        | RawDefaultLit x -> parse_default_lit x Lit
        | RawInline e ->
            let e,env' =
                memoize dict_rawinline (fun _ ->
                    let env' = fresh_env env // Note: Since module open's are statements the current semantics should allow passing the env here to be sound.
                    prepass_value env' e, env'
                    ) e
            Inline(e,expr_data_of env env')
        | RawType x -> Type(prepass_type env x)
        | RawInl (a,b) ->
            let env' = fresh_env env |> value_add_local a
            let b = prepass_value env' b
            Inl(b,expr_data_of env env')
        | RawForall (a,b) ->
            let env' = fresh_env env |> type_add_local a
            let b = prepass_value env' b
            Forall(b,expr_data_of env env')
        | RawKeywordCreate (a,b) ->
            let b = Array.map (prepass_value env) b
            KeywordCreate(keywords.To a,b)
        | RawLet (a,b,on_succ) ->
            let b = prepass_value env b
            let on_succ = prepass_value (value_add_local a env) on_succ
            Let(b,on_succ)
        | RawRecordWith (a,b) ->
            let a = Array.map (prepass_value env) a
            let b = 
                Array.map (function
                    | RawRecordWithKeyword(keyword,expr) -> RecordWithKeyword(keywords.To keyword, prepass_value (value_add_local "this" env) expr)
                    | RawRecordWithInjectVar(var,expr) -> RecordWithInjectVar(var,v var, prepass_value (value_add_local "this" env) expr)
                    | RawRecordWithoutKeyword(keyword) -> RecordWithoutKeyword(keywords.To keyword)
                    | RawRecordWithoutInjectVar(var) -> RecordWithoutInjectVar(var,v var)
                    ) b
            RecordWith(a,b)
        | RawOp (a,b) -> Op(a,Array.map (prepass_value env) b)
        | RawJoinPoint(a,b) -> JoinPoint(Option.map (prepass_type env) a, prepass_value env b)
        | RawAnnot(a,b) -> Annot(prepass_type env a, prepass_value env b)
        //| RawTypedOp (a,b,c) -> TypedOp(prepass_type env a, b, Array.map (prepass_value env) c)
        | RawTypecase (a,b) -> Typecase(prepass_type env a, Array.map (fun (a,b) -> prepass_type env a, prepass_value env b) b)
        | RawModuleOpen (a,b,on_succ) -> 
            let t,v = module_open (env.type'.global', env.value.global') a b
            prepass_value {env with type'={env.type' with global'=t}; value = {env.value with global'=v}} on_succ
        | RawRecBlock _ -> failwith "Compiler error: Recursive functions and blocks are only allowed at the top level."
        | RawPairTest (a,b,c,on_succ,on_fail) ->
            let env' = env |> value_add_local a |> value_add_local b
            PairTest(v' c,prepass_value env' on_succ,prepass_value env on_fail) // Note: For all the tests, it should be impossible to pass the globals into them.
        | RawKeywordTest (a,b,c,on_succ,on_fail) ->
            let env' = Array.fold (fun env x -> value_add_local x env) env b
            KeywordTest(keywords.To a,v' c,prepass_value env' on_succ,prepass_value env on_fail)
        | RawRecordTest (a,b,on_succ,on_fail) ->
            let a,env' =
                Array.mapFold (fun env -> function
                    | RawRecordTestKeyword (a,b) -> RecordTestKeyword(keywords.To a), value_add_local b env
                    | RawRecordTestInjectVar (a,b) -> RecordTestInjectVar(v a), value_add_local b env
                    ) env a
            RecordTest(a,v' b,prepass_value env' on_succ,prepass_value env on_fail)
        | RawAnnotTest (true,b,c,on_succ,on_fail) -> AnnotTest(true,prepass_type (value_add_local c env) b,v' c,prepass_value env on_succ,prepass_value env on_fail)
        | RawAnnotTest (false,b,c,on_succ,on_fail) -> AnnotTest(false,prepass_type env b,v' c,prepass_value env on_succ,prepass_value env on_fail)
        | RawValueTest (a,b,on_succ,on_fail) -> LitTest(a,v' b,prepass_value env on_succ,prepass_value env on_fail)
        | RawDefaultLitTest (a,b,on_succ,on_fail) -> parse_default_lit a (fun x -> LitTest(x,v' b,prepass_value env on_succ,prepass_value env on_fail))
        | RawUnionTest (a,b,c,on_succ,on_fail) -> 
            let env' = Array.fold (fun env x -> value_add_local x env) env b
            UnionTest(keywords.To a,b.Length,v' c,prepass_value env' on_succ,prepass_value env on_fail)
        | RawUnitTest (a,on_succ,on_fail) -> UnitTest(v' a,prepass_value env on_succ,prepass_value env on_fail)
        | RawPos x -> Pos(Parsing.Pos(x.Pos,prepass_value env x.Expression))
    and prepass_type (env : LocEnv) x =
        let v' x = v_loc env.type' x
        let v x = 
            match env.type'.global'.TryGetValue x with
            | true, v -> v
            | false, _ -> TV (v' x)
        let f x = prepass_type env x
        match x with
        | RawTVar x -> v x
        | RawTPair (a,b) -> TPair(f a,f b)
        | RawTFun (a,b) -> TFun(f a,f b)
        | RawTConstraint (a,b) -> failwith "Compiler error: Constraints not allowed in the prepass."
        | RawTDepConstraint (a,b) -> failwith "Compiler error: Dependent constraints not allowed in the prepass."
        | RawTRecord x -> TRecord(Map.fold (fun m k v -> Map.add (keywords.To k) (f v) m) Map.empty x)
        | RawTKeyword (a,b) -> TKeyword(keywords.To a,Array.map f b)
        | RawTApply (a,b) -> TApply (f a, f b)
        | RawTForall (a,b) -> failwith "Compiler error: Foralls not allowed in the prepass."
        | RawTInl ((a,_),b) ->
            let env' = fresh_env env |> type_add_local a
            let b = prepass_type env' b
            let d = expr_data_of env env'
            if d.value.free_vars.Length <> 0 then errors.Add(ErTypeFunctionHasFreeValueVar a)
            if d.value.stack_size <> 0 then errors.Add(ErTypeFunctionHasNonZeroValueStackSize a)
            TInl(b, d.type')
        | RawTUnit -> TUnit
        | RawTPrim x -> TPrim x
        | RawTArray x -> TArray(f x)
        | RawTPos x -> TPos(Parsing.Pos(x.Pos,f x.Expression))

    let rec prepass_top (t_glob : Map<string,TExpr>) (v_glob : Map<string,Expr>) x = 
        let assert_free_vars_empty env =
            env.value.free_vars |> Seq.iter (fun kv -> errors.Add(ErMissingValueVar kv.Key))
            env.type'.free_vars |> Seq.iter (fun kv -> errors.Add(ErMissingTypeVar kv.Key))
        match x with
        | RawLet(a,b,on_succ) ->
            let env = {type'=env t_glob; value=env v_glob}
            let b = prepass_value env b
            assert_free_vars_empty env
            v_new.Add(a,b)
            prepass_top t_glob (Map.add a b v_glob) on_succ
        | RawRecBlock(l,on_succ) ->
            let r,v_glob =
                Array.mapFold (fun env (k,_) ->
                    let r = ref Unchecked.defaultof<_>
                    let r' = Glob r
                    v_new.Add(k,r')
                    r, Map.add k r' env
                    ) v_glob l
            let env = {type'=env t_glob; value=env v_glob}
            Array.iter2 (fun r (_,e) -> r := prepass_value env e) r l
            assert_free_vars_empty env
            prepass_top t_glob v_glob on_succ
        | RawModuleOpen(a,b,on_succ) -> 
            let t,v = module_open (t_glob, v_glob) a b
            prepass_top t v on_succ
        | RawB -> ()
        | x -> failwithf "Compiler error in prepass_top.\nGot: %A" x

    prepass_top t_glob v_glob x
    
    if errors.Count > 0 then
        let b = StringBuilder()
        let dict = Dictionary(HashIdentity.Reference)
        let show_position a b = show_position dict a b
        Seq.iter (fun x ->
            match x with
            | ErMissingTypeVar x | ErMissingValueVar x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: Variable {0} not found in the environment.", x) |> ignore
            | ErMissingModule x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: Module {0} not found in the environment.", x) |> ignore
            | ErNotAModule x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: {0} is not a module.", x) |> ignore
            | ErMissingModuleItem x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: {0} cannot be found inside the module.", x) |> ignore
            | ErLocalShadowsGlobal x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: Local variable {0} shadows the global of the same name.", x) |> ignore
            | ErTypeFunctionHasFreeValueVar x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: Type function {0} has free variables on the value level.", x) |> ignore
            | ErTypeFunctionHasNonZeroValueStackSize x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: Type function {0} has open bindings on the value level.", x) |> ignore
            | ErDefaultValueParse x ->
                show_position b var_positions.[x]
                b.AppendFormat("Error: {0} cannot be parsed to either the i64 or f64.", x) |> ignore
            ) errors
        Error (b.ToString())
    else
        Ok (t_new, v_new)
