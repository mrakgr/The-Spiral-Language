module Spiral.BlockParsing
open System
open Spiral.ParserCombinators
open Spiral.Tokenize
type Range = {line : int; from : int; nearTo : int}
let range_to_vscrange (x : Range) : Config.VSCRange = {line=x.line; character=x.from}, {line=x.line; character=x.nearTo}
type Env = {
    tokens : (Range * SpiralToken) []
    comments : Tokenize.LineComment option []
    i : int ref
    semicolon_line : int
    symbol_line : int
    is_top_down : bool
    } with

    member d.Index with get() = d.i.contents and set(i) = d.i := i

type PatternCompilationErrors =
    | DisjointOrPattern
    | InvalidOp of string
    | DuplicateVar of string
    | DuplicateRecordKeyword of string
    | DuplicateRecordInjection of string

type ParserErrors =
    | InvalidPattern of PatternCompilationErrors []
    | ExpectedKeyword of TokenKeyword
    | ExpectedOperator'
    | ExpectedOperator of string
    | ExpectedUnaryOperator'
    | ExpectedUnaryOperator of string
    | ExpectedVar
    | ExpectedVarOrOpAsNameOfRecStatement
    | ExpectedVarOrOpAsNameOfGlobalStatement
    | ExpectedSmallVar
    | ExpectedBigVar
    | ExpectedLit
    | ExpectedSymbolPaired
    | SymbolPairedShouldStartWithUppercase
    | ExpectedSymbol
    | ExpectedBracket of Bracket * BracketState
    | ExpectedStatement
    | ExpectedKeywordPatternInObject
    | ExpectedEob
    | ExpectedFunctionAsBodyOfRecStatement
    | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp
    | ExpectedStatementBody
    | ExpectedGlobalFunction
    | StatementLastInBlock
    | InvalidSemicolon
    | InbuiltOpNotFound of string
    | UnexpectedEob
    | ForallNotAllowed

let inline try_current_template (d : Env) on_succ on_fail =
    let i = d.Index
    if 0 <= i && i < d.tokens.Length then on_succ d.tokens.[i]
    else on_fail()

let inline try_current d f = try_current_template d (fun (p,t) -> f (range_to_vscrange p, t)) (fun () -> Error [])
let print_current d = try_current d (fun x -> printfn "%A" x; Ok()) // For parser debugging purposes.
let inline line_template d f = try_current_template d (fst >> f) (fun _ -> -1)
let col d = line_template d (fun r -> r.from)
let line d = line_template d (fun r -> r.line)
   
let skip' (d : Env) i = d.i := d.i.contents+i
let skip d = skip' d 1

let ok d (p, t) = Ok(t)

let peek_keyword d =
    try_current d <| function
        | p, TokKeyword(t') -> Ok(t')
        | _ -> Error []

let skip_keyword t d =
    try_current d <| function
        | p,TokKeyword t' when t = t' -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedKeyword t]

let read_unary_op d =
    try_current d <| function
        | p, TokUnaryOperator t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_op d =
    try_current d <| function
        | p, TokOperator t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedOperator']

let skip_op t d =
    try_current d <| function
        | p, TokOperator t' when t' = t -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedOperator t]

let skip_unary_op t d =
    try_current d <| function
        | p, TokUnaryOperator t' when t' = t -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedUnaryOperator t]

let read_var d =
    try_current d <| function
        | p, TokVar t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedVar]

let read_small_var d =
    try_current d <| function
        | p, TokVar t' when Char.IsLower(t',0) -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_big_var d =
    try_current d <| function
        | p, TokVar t' when Char.IsUpper(t',0) -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedBigVar]

let read_value d =
    try_current d <| function
        | p, TokValue t' -> skip d; Ok(t')
        | p, _ -> Error [p, ExpectedLit]

let read_default_value d =
    try_current d <| function
        | p, TokDefaultValue t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedLit]

let read_symbol_paired d =
    try_current d <| function
        | p, TokSymbolPaired t' -> skip d; ok d (p,t')
        | p, _ -> Error [p, ExpectedSymbolPaired]

let to_lower (x : string) = Char.ToLower(x.[0]).ToString() + x.[1..]
let read_symbol_paired_uplow d =
    try_current d <| function
        | p, TokSymbolPaired t' -> 
            if Char.IsUpper(t',0) then skip d; ok d (p, to_lower t')
            else Error [p, SymbolPairedShouldStartWithUppercase]
        | p, _ -> Error [p, ExpectedSymbolPaired]

let read_symbol d =
    try_current d <| function
        | p, TokSymbol t' -> skip d; Ok(t')
        | p, _ -> Error [p, ExpectedSymbol]

let skip_brackets a b d =
    try_current d <| function
        | p, TokBracket(a',b') when a = a' && b = b' -> skip d; Ok()
        | p, _ -> Error [p, ExpectedBracket(a,b)]

type SymbolString = string
type VarString = string
type NominalString = string

type Literal = Tokenize.Literal

type Op =
    // Type
    | TypeAnnot
    | TypeToVar

    // Closure conversion
    | Dyn

    // Union unboxing
    | Unbox

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice

    // Tuple
    | TupleCreate

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Braching
    | If
    | While

    // BinOps
    | Add
    | Sub
    | Mult 
    | Div 
    | Mod 
    | Pow
    | LTE
    | LT
    | EQ
    | NEQ
    | GT
    | GTE 
    | BoolAnd
    | BoolOr
    | BitwiseAnd
    | BitwiseOr
    | BitwiseXor
    | ShiftLeft
    | ShiftRight

    // Application related
    | Apply

    // Array
    | ArrayCreate
    | ArrayLength
    | ArrayIndex
    | ArrayIndexSet
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | LitIs
    | PrimIs
    | SymbolIs
    | EqType

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | NanIs

    // Infinity
    | Infinity

type PrimitiveType =
    | UInt8T
    | UInt16T
    | UInt32T
    | UInt64T
    | Int8T
    | Int16T
    | Int32T
    | Int64T
    | Float32T
    | Float64T
    | BoolT
    | StringT
    | CharT


type RawKindExpr =
    | RawKindStar
    | RawKindFun of RawKindExpr * RawKindExpr

type RawRecordTestPattern =
    | RawRecordTestSymbol of symbol: SymbolString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString

type RawRecordWithPattern =
    | RawRecordWithSymbol of SymbolString * RawExpr
    | RawRecordWithSymbolModify of SymbolString * RawExpr
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithInjectSymbolModify of SymbolString * RawExpr
    | RawRecordWithoutSymbol of SymbolString
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersSymbol of symbol: SymbolString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern
and Pattern =
    | PatB
    | PatE
    | PatVar of VarString
    | PatOperator of VarString // Isn't actually a pattern. Is just here to help the inl/let statement parser.
    | PatDyn of Pattern
    | PatUnbox of Pattern
    | PatAnnot of Pattern * RawTExpr
    | PatPair of Pattern * Pattern
    | PatSymbol of string
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatOr of Pattern * Pattern
    | PatAnd of Pattern * Pattern
    | PatValue of Literal
    | PatDefaultValue of VarString
    | PatWhen of Pattern * RawExpr
    | PatNominal of VarString * Pattern
and RawExpr =
    | RawB
    | RawV of VarString
    | RawLit of Literal
    | RawDefaultLit of string
    | RawSymbolCreate of SymbolString
    | RawType of RawTExpr
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawLet of Pattern * RawExpr * on_succ: RawExpr
    | RawInl of (Pattern * RawExpr) list
    | RawForall of VarString * RawKindExpr * RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawJoinPoint of RawExpr
    | RawAnnot of RawTExpr * RawExpr
    | RawMatch of RawExpr * (RawExpr * RawExpr) []
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of VarString list * on_succ: RawExpr
and RawTExpr =
    | RawTMetaVar of VarString
    | RawTVar of VarString
    | RawTPair of RawTExpr * RawTExpr
    | RawTFun of RawTExpr * RawTExpr
    | RawTRecord of Map<string,RawTExpr>
    | RawTSymbol of SymbolString
    | RawTApply of RawTExpr * RawTExpr
    | RawTForall of (VarString * RawKindExpr) * RawTExpr
    | RawTB
    | RawTPrim of PrimitiveType
    | RawTArray of RawTExpr

let rounds a d = (skip_brackets Round Open >>. a .>> skip_brackets Round Close) d
let curlies a d = (skip_brackets Curly Open >>. a .>> skip_brackets Curly Close) d
let squares a d = (skip_brackets Square Open >>. a .>> skip_brackets Square Close) d

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let eof d = 
    let i = index d
    let len = d.tokens.Length
    if i = len then Ok() 
    elif 0 <= i && i < len then let r,_ = d.tokens.[i] in Error [{line=r.line; from=r.nearTo; nearTo=r.nearTo+1}, ExpectedEob]
    else failwith "Compiler error: The block parser's pointer is out of bounds in the eof parser."

let rec kind d = (sepBy1 ((skip_op "*" >>% RawKindStar) <|> rounds kind) (skip_op "->") |>> List.reduceBack (fun a b -> RawKindFun (a,b))) d

let inline range exp s =
    let i = index s
    exp s |> Result.map (fun x ->
        let i' = index s
        if i < i' then
            let r, r' = fst s.tokens.[i], fst s.tokens.[i'-1]
            ({line=r.line; character=r.from}, {line=r'.line; character=r'.nearTo} : Config.VSCRange), x
        else
            failwith "Compiler error: The parser passed into `range` has to consume at least one token for it to work."
        )

let forall_var d = ((read_small_var |>> fun x -> x, RawKindStar) <|> rounds ((read_small_var .>> skip_op ":") .>>. kind)) d
let forall' d = (skip_keyword SpecForall >>. many1 forall_var .>> skip_op ".") d
let forall is_forall_allowed d = (range forall' >>= fun (r,x) _ -> if is_forall_allowed then Ok x else Error [r, ForallNotAllowed]) d

let symbol_paired_process_type a b = 
    let l = a :: b
    let k,v = List.unzip l 
    let b = Text.StringBuilder()
    List.iter (fun (x : string) -> b.Append(x).Append('_') |> ignore) k
    List.reduceBack (fun a b -> RawTPair(a,b)) (RawTSymbol (b.ToString()) :: v)

let inline record_var d = (read_var <|> rounds read_op) d
let rec type_template is_forall_allowed d =
    let recurse = type_template is_forall_allowed
    let inline pairs next = sepBy1 next (skip_op "*") |>> List.reduceBack (fun a b -> RawTPair(a,b))
    let inline functions next = sepBy1 next (skip_op "->") |>> List.reduceBack (fun a b -> RawTFun(a,b))
    let inline forall next = pipe2 (forall is_forall_allowed <|>% []) next (List.foldBack (fun x s -> RawTForall(x,s)))
    let inline record next = curlies (sepBy ((record_var .>> skip_op ":") .>>. next) (skip_op ";")) |>> (Map.ofList >> RawTRecord)
    let symbol = read_symbol |>> RawTSymbol
    let symbol_paired next d =
        let i = col d
        let inline indent next d = if i <= index d then next d else Error []
        ((pipe2 (read_symbol_paired_uplow .>>. next) (many (indent read_symbol_paired .>>. next)) symbol_paired_process_type) <|> next) d
    let var = read_var |>> function
        | "i8" -> RawTPrim Int8T
        | "i16" -> RawTPrim Int16T
        | "i32" -> RawTPrim Int32T
        | "i64" -> RawTPrim Int64T
        | "u8" -> RawTPrim UInt8T
        | "u16" -> RawTPrim UInt16T
        | "u32" -> RawTPrim UInt32T
        | "u64" -> RawTPrim UInt64T
        | "f32" -> RawTPrim Float32T
        | "f64" -> RawTPrim Float64T
        | "string" -> RawTPrim StringT
        | "bool" -> RawTPrim BoolT
        | "char" -> RawTPrim CharT
        | x when Char.IsUpper(x,0) -> RawTPair(RawTSymbol(to_lower x), RawTB)
        | x -> RawTVar x
    let inline parenths next = rounds (next <|>% RawTB)
    let apply next d = 
        let i = col d
        let inline indent next d = if i < index d then next d else Error []
        (pipe2 next (many (indent next)) 
            (fun a b -> List.reduce (fun a b -> match a with RawTVar "array" -> RawTArray b | _ -> RawTApply(a,b)) (a :: b))) d

    let i = index d
    let inline (+) a b = alt i a b
    ((var + parenths recurse + record recurse + symbol) |> apply |> pairs |> functions |> symbol_paired |> forall) d

let symbol_paired_process_pattern l = 
    match l |> List.map (function a, b -> a, defaultArg b (PatVar a)) |> List.unzip with
    | (k :: k' as keys), v ->
        let body keys =
            let b = Text.StringBuilder()
            List.iter (fun (x : string) -> b.Append(x).Append('_') |> ignore) keys
            List.reduceBack (fun a b -> PatPair(a,b)) (PatSymbol (b.ToString()) :: v)
        if Char.IsLower(k,0) then body keys else body (to_lower k :: k') |> PatUnbox
    | _ -> failwith "Compiler error: Should be at least one key in symbol_paired_process_pattern"

let rec pattern_template is_outer expr s =
    let inline recurse is_outer = pattern_template is_outer expr

    let inline pat_when pattern = pattern .>>. (opt (skip_keyword SpecWhen >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let inline pat_as pattern = pattern .>>. (opt (skip_keyword SpecAs >>. pattern )) |>> function a, Some b -> PatAnd(a,b) | a, None -> a
    let pat_symbol_paired pattern = many1 (read_symbol_paired .>>. opt pattern) |>> symbol_paired_process_pattern <|> pattern
    let inline pat_pair pattern = sepBy1 pattern (skip_op ",") |>> List.reduceBack (fun a b -> PatPair(a,b))
    let inline pat_or pattern = sepBy1 pattern (skip_op "|") |>> List.reduce (fun a b -> PatOr(a,b))
    let inline pat_and pattern = sepBy1 pattern (skip_op "&") |>> List.reduce (fun a b -> PatAnd(a,b))
    
    let inline pat_type pattern = 
        pipe2 pattern (opt (skip_op ":" >>. fun d -> type_template d.is_top_down d))
            (fun a -> function Some b -> PatAnnot(a,b) | None -> a)
    let pat_wildcard = skip_keyword SpecWildcard >>% PatE
    let inline pat_var pattern =
        read_var >>= fun a d ->
            if Char.IsLower(a,0) then
                if is_outer then Ok (PatVar a)
                else (opt pattern |>> function Some b -> PatNominal(a,b) | None -> PatVar a) d
            else
                PatPair(PatSymbol(to_lower a), PatB) |> PatUnbox |> Ok
            
    let inline pat_active pattern s =
        if is_outer then Error []
        else (skip_unary_op "!" >>. ((read_small_var |>> RawV) <|> rounds expr) .>>. pattern |>> PatActive) s
    let pat_value = (read_value |>> PatValue) <|> (read_default_value |>> PatDefaultValue)
    let inline pat_record_item pattern =
        pipe3 (opt (skip_unary_op "$")) record_var (opt (skip_op "=" >>. pattern)) (fun dollar a b ->
            let b = defaultArg b (PatVar a)
            match dollar with
            | Some _ -> PatRecordMembersInjectVar(a,b)
            | None -> PatRecordMembersSymbol(a,b)
            )
    let inline pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_symbol = read_symbol |>> PatSymbol
    let inline pat_dyn pattern = skip_unary_op "~" >>. pattern |>> PatDyn
    let inline pat_rounds pattern s =
        let i = index s
        let inline (+) a b = alt i a b
        rounds (pattern + (read_op |>> PatOperator) + (fun _ -> Ok PatB)) s

    let body s = 
        let i = index s
        let inline (+) a b = alt i a b
        (pat_active (recurse true) + pat_wildcard + pat_var (recurse true) + pat_dyn (recurse true) 
        + pat_value + pat_record (recurse true) + pat_symbol + pat_rounds (recurse false)) s
    if is_outer then (body |> pat_pair |> pat_symbol_paired) s
    else (body |> pat_type |> pat_and |> pat_pair |> pat_symbol_paired |> pat_or |> pat_as |> pat_when) s

let pattern_validate pat =
    let errors = ResizeArray()
    let vars = Collections.Generic.HashSet()
    let rec loop pat =
        match pat with
        | PatOperator x -> errors.Add(InvalidOp x); Set.empty
        | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatE | PatB -> Set.empty
        | PatVar x -> (if vars.Add x = false then errors.Add(DuplicateVar x)); Set.singleton x
        | PatDyn p | PatAnnot (p,_) | PatNominal(_,p) | PatActive (_,p) | PatUnbox p | PatWhen(p, _) -> loop p
        | PatPair(a,b) -> loop a + loop b
        | PatRecordMembers items ->
            let symbols = Collections.Generic.HashSet()
            let injects = Collections.Generic.HashSet()
            List.fold (fun s item ->
                match item with
                | PatRecordMembersSymbol(keyword,name) ->
                    if symbols.Add(keyword) = false then errors.Add(DuplicateRecordKeyword keyword)
                    s + loop name
                | PatRecordMembersInjectVar(var,name) ->
                    if injects.Add(var) = false then errors.Add(DuplicateRecordInjection var)
                    s + loop name
                ) Set.empty items
        | PatAnd(a,b) -> loop a + loop b
        | PatOr(a,b) -> let a, b = loop a, loop b in if a = b then a else errors.Add(DisjointOrPattern); a
    loop pat |> ignore
    errors.ToArray()

let inline pattern x = pattern_template true x
let inline inl_or_let exp =
    range (tuple6 (skip_keyword SpecInl <|> skip_keyword SpecLet) (opt (skip_keyword SpecRec)) (range (pattern exp)) 
            (forall' <|>% []) (many (range (pattern exp))) (skip_op "=" >>. opt exp))
    >>= fun (r, (inl_or_let, is_rec, name, foralls, pats, body)) s ->
        match body with
        // TODO: Rather than return an error during parsing for this particular error, for the typechecking pass I'll replace it with a metavariable stump.
        | None -> Error [r, ExpectedStatementBody]
        | Some body ->
            let name, pats =
                match name with
                | r, PatUnbox(PatPair(PatSymbol name, pat)) -> (r, PatVar name), (r, pat) :: pats
                | _ -> name, pats
            let body = 
                let dyn_if_let x = match inl_or_let with SpecInl -> x | _ -> PatDyn x
                List.foldBack (fun (_,pat) body -> RawInl [dyn_if_let pat,body]) pats body
                |> List.foldBack (fun (a,b) body -> RawForall(a,b,body)) foralls
            match is_rec, name, foralls, pats, body with
            | None, (_, (PatVar _ | PatOperator _)), _, _, _
            | Some _, (_, (PatVar _ | PatOperator _)), _, _, (RawInl _ | RawForall _) -> 
                match List.choose (fun (r,x) -> let x = pattern_validate x in if 0 < x.Length then Some (r, InvalidPattern x) else None) pats with
                | [] -> Ok(r,name,body)
                | ers -> Error ers
            | Some _, (_, (PatVar _ | PatOperator _)), _, _, _ -> Error [r, ExpectedFunctionAsBodyOfRecStatement]
            | None, _, [], [], _ -> Ok(r,name,body)
            | Some _, _, _, _, _ -> Error [fst name, ExpectedVarOrOpAsNameOfRecStatement]
            | None, _, _, _, _ -> Error [fst name, ExpectedSinglePatternWhenStatementNameIsNorVarOrOp]

type TopStatement =
    | TopAnd of TopStatement
    | TopInl of VarString * RawExpr

let inline top_let_or_let exp = 
    (inl_or_let exp >>= fun x _ ->
        match x with
        | _, (_ , (PatVar name | PatOperator name)), (RawForall _ | RawInl _ as body) -> Ok(TopInl(name, body))
        | r, (_ , (PatVar _ | PatOperator _)), _ -> Error [r, ExpectedGlobalFunction]
        | _, (r , _), _ -> Error [r, ExpectedVarOrOpAsNameOfGlobalStatement]
        )

let comments line_near_to character (s : Env) = 
    let rec loop line d =
        if line < 0 then 
            match s.comments.[line] with
            | Some(r,text) when r.from = character -> loop (line-1) (text :: d)
            | _ -> d
        else d
    loop (line_near_to-1) []
    |> String.concat "\n"
    |> fun x -> x.TrimEnd()

let top_statement s =
    let i = index s
    let inline (+) a b = alt i a b
    (top_let + top_inl) s