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
    | MetavarNotAllowed
    | ValueExprNotAllowed

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

let read_unary_op' d =
    try_current d <| function
        | p, TokUnaryOperator t' -> skip d; Ok(p,t')
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

type RawRecordWith =
    | RawRecordWithSymbol of SymbolString * RawExpr
    | RawRecordWithSymbolModify of SymbolString * RawExpr
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithInjectSymbolModify of SymbolString * RawExpr
and RawRecordWithout =
    | RawRecordWithoutSymbol of SymbolString
    | RawRecordWithoutInjectVar of VarString
and PatRecordMember =
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
    | PatRecordMembers of PatRecordMember list
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
    | RawLet of (Pattern * RawExpr) list * body: RawExpr
    | RawInl of (Pattern * RawExpr) list
    | RawForall of VarString * RawKindExpr * RawExpr
    | RawRecBlock of (VarString * RawExpr) [] * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
    | RawRecordWith of RawExpr list * RawRecordWith list * RawRecordWithout list
    | RawOp of Op * RawExpr []
    | RawJoinPoint of RawExpr
    | RawAnnot of RawExpr * RawTExpr
    | RawTypecase of RawTExpr * (RawTExpr * RawExpr) []
    | RawModuleOpen of VarString * SymbolString list * on_succ: RawExpr
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
    | RawTValueExpr of RawExpr

let rounds a d = (skip_brackets Round Open >>. a .>> skip_brackets Round Close) d
let curlies a d = (skip_brackets Curly Open >>. a .>> skip_brackets Curly Close) d
let squares a d = (skip_brackets Square Open >>. a .>> skip_brackets Square Close) d

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let eob d = 
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
let forall allow_forall d = (range forall' >>= fun (r,x) _ -> if allow_forall then Ok x else Error [r, ForallNotAllowed]) d

let symbol_paired_process_type a b = 
    let l = a :: b
    let k,v = List.unzip l 
    let b = Text.StringBuilder()
    List.iter (fun (x : string) -> b.Append(x).Append('_') |> ignore) k
    List.reduceBack (fun a b -> RawTPair(a,b)) (RawTSymbol (b.ToString()) :: v)

let inline indent i op next d = if op i (index d) then next d else Error []

let record_var d = (read_var <|> rounds read_op) d

let symbol_paired_process_pattern l = 
    match l |> List.map (function a, b -> a, defaultArg b (PatVar a)) |> List.unzip with
    | (k :: k' as keys), v ->
        let body keys =
            let b = Text.StringBuilder()
            List.iter (fun (x : string) -> b.Append(x).Append('_') |> ignore) keys
            List.reduceBack (fun a b -> PatPair(a,b)) (PatSymbol (b.ToString()) :: v)
        if Char.IsLower(k,0) then body keys else body (to_lower k :: k') |> PatUnbox
    | _ -> failwith "Compiler error: Should be at least one key in symbol_paired_process_pattern"

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

let patterns_validate pats = List.choose (fun (r,x) -> let x = pattern_validate x in if 0 < x.Length then Some (r, InvalidPattern x) else None) pats

let inline inl_or_let exp pattern =
    range (tuple6 (skip_keyword SpecInl <|> skip_keyword SpecLet) (opt (skip_keyword SpecRec)) (range pattern) 
            (forall' <|>% []) (many (range pattern)) (skip_op "=" >>. opt exp))
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
                match patterns_validate pats with
                | [] -> Ok(r,name,body)
                | ers -> Error ers
            | Some _, (_, (PatVar _ | PatOperator _)), _, _, _ -> Error [r, ExpectedFunctionAsBodyOfRecStatement]
            | None, _, [], [], _ -> Ok(r,name,body)
            | Some _, _, _, _, _ -> Error [fst name, ExpectedVarOrOpAsNameOfRecStatement]
            | None, _, _, _, _ -> Error [fst name, ExpectedSinglePatternWhenStatementNameIsNorVarOrOp]

type Associativity = FParsec.Associativity
let inbuilt_operators x = 
    match x with
    | "+" -> ValueSome(60, Associativity.Left)
    | "-" -> ValueSome(60, Associativity.Left)
    | "*" -> ValueSome(70, Associativity.Left)
    | "/" -> ValueSome(70, Associativity.Left)
    | "%" -> ValueSome(70, Associativity.Left)
    | "|>" -> ValueSome(10, Associativity.Left)
    | ">>" -> ValueSome(10, Associativity.Left)
    
    | "<=" -> ValueSome(40, Associativity.None)
    | "<" -> ValueSome(40, Associativity.None)
    | "=" -> ValueSome(40, Associativity.None)
    | "`=" -> ValueSome(40, Associativity.None)
    | ">" -> ValueSome(40, Associativity.None)
    | ">=" -> ValueSome(40, Associativity.None)
    | "<>" -> ValueSome(40, Associativity.None)
    | "<<<" -> ValueSome(40, Associativity.None)
    | ">>>" -> ValueSome(40, Associativity.None)
    | "&&&" -> ValueSome(40, Associativity.None)
    | "|||" -> ValueSome(40, Associativity.None)

    | "||" -> ValueSome(20, Associativity.Right)
    | "&&" -> ValueSome(30, Associativity.Right)
    | "::" -> ValueSome(50, Associativity.Right)
    | "^" -> ValueSome(45, Associativity.Right)
    | "<|" -> ValueSome(10, Associativity.Right)
    | "<<" -> ValueSome(10, Associativity.Right)
    | ";" -> ValueSome(3, Associativity.Right)
    | "," -> ValueSome(5, Associativity.Right)
    | ":>" -> ValueSome(35, Associativity.Right)
    | ":?>" -> ValueSome(35, Associativity.Right)
    | "**" -> ValueSome(80, Associativity.Right)
    | _ -> ValueNone

// Similarly to F#, Spiral filters out the '.' from the operator name and then tries to match to the nearest inbuilt operator
// for the sake of assigning associativity and precedence.
let precedence_associativity x = 
    let rec loop (name : string) =
        if name.Length > 0 then
            match inbuilt_operators name with
            | ValueNone -> loop (name.[0..name.Length-2])
            | ValueSome v -> ValueSome(v)
        else
            ValueNone
    loop (String.filter ((<>) '.') x)

let inl l = RawInl l
let v x = RawV x
let l bind body on_succ = RawLet([bind,on_succ],body)
let inline_ = function RawInline _ as x -> x | x -> RawInline x
let if' cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
let ty x = RawType x
let B = RawB

let unop op' a = RawOp(op',[|a|])
let dyn x = unop Dyn x
let binop op' a b = RawOp(op',[|a;b|])
let eq x y = binop EQ x y
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l

let lit' x = RawLit x
let lit_string x = RawLit(LitString x)
let def_lit' x = RawDefaultLit x

let op (d : Env) =
    range read_op d |> Result.bind (fun (r,x) ->
        match precedence_associativity x with // TODO: Might be good to memoize this.
        | ValueNone -> skip' d -1; Error [r, InbuiltOpNotFound x] 
        | ValueSome(p,a) ->
            match x with
            | ";" when (fst r).line = d.semicolon_line -> skip' d -1; Error [r, InvalidSemicolon]
            | ";" -> Ok(p,a,fun (a, b) -> l PatE (unop ErrorNonUnit a) b)
            | "&&" -> Ok(p,a,fun (a, b) -> if' a b (lit' (LitBool false)))
            | "||" -> Ok(p,a,fun (a, b) -> if' a (lit' (LitBool true)) b)
            | "," -> Ok(p,a,fun (a, b) -> binop TupleCreate a b)
            | x -> Ok(p,a,fun (a, b) -> ap (ap (v x) a) b)
        )

let inline level_semicolon_set expr (d: Env) = expr {d with semicolon_line = line d}
let inline level_symbol_set expr (d: Env) = expr {d with symbol_line = line d}
let inline level_reset expr d = expr {d with semicolon_line= -1; symbol_line= -1}

let private string_to_op_dict = Collections.Generic.Dictionary(HashIdentity.Structural)
Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
|> Array.iter (fun x -> string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op)
let string_to_op x = string_to_op_dict.TryGetValue x

let module_open = range ((skip_keyword SpecOpen >>. read_small_var) .>>. (many read_symbol))

type ParserExpr =
    | ParserStatement of Config.VSCRange * (RawExpr -> RawExpr)
    | ParserExpr of RawExpr

let process_parser_exprs (exprs, in') _ =
    let f x s = match x with ParserExpr a -> l PatE (unop ErrorNonUnit a) s | ParserStatement (_,a) -> a s
    match in' with
    | Some in' -> Ok(List.foldBack f exprs in')
    | None -> 
        match List.rev exprs with
        | ParserStatement (r,_) :: _ -> Error [r,StatementLastInBlock]
        | ParserExpr x :: xs -> Ok(List.fold (fun a b -> f b a) x xs)
        | [] -> failwith "Compiler error: At least one statement must be parsed."

let rec root_type allow_metavars allow_value_exprs allow_forall d =
    let recurse = root_type allow_metavars allow_value_exprs allow_forall
    let metavar = 
        range (skip_unary_op "~" >>. read_var) >>= fun (r,x) s -> 
            if allow_metavars then Ok (RawTMetaVar x) else Error [r, ForallNotAllowed]
    let value_expr = 
        range (skip_unary_op "`" >>. ((read_var |>> RawV) <|> rounds root_value)) >>= fun (r,x) s ->
            if allow_value_exprs then Ok(RawTValueExpr x) else Error [r, ValueExprNotAllowed]
    let inline pairs next = sepBy1 next (skip_op "*") |>> List.reduceBack (fun a b -> RawTPair(a,b))
    let inline functions next = sepBy1 next (skip_op "->") |>> List.reduceBack (fun a b -> RawTFun(a,b))
    let inline forall next = pipe2 (forall allow_forall <|>% []) next (List.foldBack (fun x s -> RawTForall(x,s)))
    let inline record next = curlies (sepBy ((record_var .>> skip_op ":") .>>. next) (skip_op ";")) |>> (Map.ofList >> RawTRecord)
    let symbol = read_symbol |>> RawTSymbol
    let symbol_paired next d =
        let i = col d
        ((pipe2 (read_symbol_paired_uplow .>>. next) (many (indent i (<=) read_symbol_paired .>>. next)) symbol_paired_process_type) <|> next) d
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
        (pipe2 next (many (indent i (<) next)) 
            (fun a b -> List.reduce (fun a b -> match a with RawTVar "array" -> RawTArray b | _ -> RawTApply(a,b)) (a :: b))) d

    let (+) = alt (index d)
    ((value_expr + metavar + var + parenths recurse + record recurse + symbol) |> apply |> pairs |> functions |> symbol_paired |> forall) d

and root_pattern is_outer s =
    let inline recurse is_outer = root_pattern is_outer

    let inline pat_when pattern = pattern .>>. (opt (skip_keyword SpecWhen >>. root_value)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let inline pat_as pattern = pattern .>>. (opt (skip_keyword SpecAs >>. pattern )) |>> function a, Some b -> PatAnd(a,b) | a, None -> a
    let pat_symbol_paired pattern = many1 (read_symbol_paired .>>. opt pattern) |>> symbol_paired_process_pattern <|> pattern
    let inline pat_pair pattern = sepBy1 pattern (skip_op ",") |>> List.reduceBack (fun a b -> PatPair(a,b))
    let inline pat_or pattern = sepBy1 pattern (skip_op "|") |>> List.reduce (fun a b -> PatOr(a,b))
    let inline pat_and pattern = sepBy1 pattern (skip_op "&") |>> List.reduce (fun a b -> PatAnd(a,b))
    
    let inline pat_type pattern = 
        pipe2 pattern (opt (skip_op ":" >>. fun d -> root_type false (d.is_top_down = false) d.is_top_down d))
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
        else (skip_unary_op "!" >>. ((read_small_var |>> RawV) <|> rounds root_value) .>>. pattern |>> PatActive) s
    let pat_value = (read_value |>> PatValue) <|> (read_default_value |>> PatDefaultValue)
    let inline pat_record_item pattern =
        let inj = skip_unary_op "$" >>. read_small_var |>> fun a -> PatRecordMembersInjectVar,a
        let var = record_var |>> fun a -> PatRecordMembersSymbol,a
        pipe2 (inj <|> var) (opt (skip_op "=" >>. pattern)) (fun (f,a) b -> f (a, defaultArg b (PatVar a)))
    let inline pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_symbol = read_symbol |>> PatSymbol
    let inline pat_dyn pattern = skip_unary_op "~" >>. pattern |>> PatDyn
    let inline pat_rounds pattern s =
        let (+) = alt (index s)
        rounds (pattern + (read_op |>> PatOperator) + (fun _ -> Ok PatB)) s

    let body s = 
        let (+) = alt (index s)
        (pat_active (recurse true) + pat_wildcard + pat_var (recurse true) + pat_dyn (recurse true) 
        + pat_value + pat_record (recurse true) + pat_symbol + pat_rounds (recurse false)) s
    if is_outer then (body |> pat_pair |> pat_symbol_paired) s
    else (body |> pat_type |> pat_and |> pat_pair |> pat_symbol_paired |> pat_or |> pat_as |> pat_when) s

and root_value d =
    let rec expressions d =
        let next = root_value
        let case_var = read_var |>> fun x -> if Char.IsUpper(x,0) then binop TupleCreate (to_lower x |> v) RawB else v x
        let case_rounds = rounds ((read_op |>> v) <|> (level_reset next <|>% B))

        let case_fun =
            (skip_keyword SpecFun >>. many (range (root_pattern true))) .>>. (skip_op "=>" >>. next)
            >>= fun (pats, body) d ->
                match patterns_validate pats with
                | [] -> List.foldBack (fun (_,pat) body -> RawInl [pat,body]) pats body |> Ok
                | ers -> Error ers
            
        let case_forall =
            tuple3 (skip_keyword SpecForall >>. forall') (many (range (root_pattern true))) (skip_op "=>" >>. next)
            >>= fun (foralls, pats, body) d ->
                match patterns_validate pats with
                | [] -> 
                    List.foldBack (fun (_,pat) body -> RawInl [pat,body]) pats body
                    |> List.foldBack (fun (a,b) body -> RawForall(a,b,body)) foralls |> Ok
                | ers -> Error ers

        let case_value = read_value |>> lit'
        let case_default_value = read_default_value |>> def_lit'
        let case_if_then_else d = 
            let i = col d
            let inline f' keyword = skip_keyword keyword >>. next
            let inline f keyword = indent i (<=) (f' keyword)
            (pipe4 (f' SpecIf) (f SpecThen) (many (f SpecElif .>>. f SpecThen)) (opt (f SpecElse))
                (fun cond tr elifs fl -> 
                    let fl = List.foldBack (fun (cond,tr) fl -> if' cond tr fl) elifs (Option.defaultValue B fl)
                    if' cond tr fl)) d
        
        let bar i d = indent i (<=) (skip_op "|") d
        let case_pattern_match =
            let clauses d = 
                let bar = bar (col d)
                (optional bar >>. sepBy1 (root_pattern false .>>. (skip_op "=>" >>. next)) bar) d

            (skip_keyword SpecFunction >>. clauses |>> inl)
            <|> (pipe2 (skip_keyword SpecMatch >>. next .>> skip_keyword SpecWith) clauses (fun a b -> RawLet(b,a)))

        let case_typecase =
            let clauses d = 
                let bar = bar (col d)
                (optional bar >>. sepBy1 (root_type true false false .>>. (skip_op "=>" >>. next)) bar) d

            pipe2 (skip_keyword SpecTypecase >>. root_type false true false .>> skip_keyword SpecWith) clauses 
                (fun a b -> RawTypecase(a,List.toArray b))

        let case_record = 
            let record_body = (skip_op "=" >>. level_semicolon_set next)
            let record_create_body = record_var .>>. record_body |>> RawRecordWithSymbol
            let record_create = many record_create_body |>> fun withs -> RawRecordWith([],withs,[])
            let record_with_bodies =
                record_create_body <|> (read_unary_op' >>= fun (r,x) d ->
                    match x with
                    | "#" -> (record_var .>>. record_body |>> RawRecordWithSymbolModify) d
                    | "$" -> (read_small_var .>>. record_body |>> RawRecordWithInjectVar) d
                    | "#$" -> (read_small_var .>>. record_body |>> RawRecordWithInjectSymbolModify) d
                    | _ -> Error [r, ExpectedUnaryOperator "#"; r, ExpectedUnaryOperator "$"; r, ExpectedUnaryOperator "#$"]
                    )
            let record_without_bodies = (record_var |>> RawRecordWithoutSymbol) <|> (skip_unary_op "$" >>. read_small_var |>> RawRecordWithoutInjectVar)
            let record_with =
                tuple4 read_small_var
                    (many ((read_symbol |>> RawSymbolCreate) <|> (skip_op "$" >>. read_small_var |>> v)))
                    ((skip_keyword SpecWith >>. many record_with_bodies) <|>% [])
                    ((skip_keyword SpecWithout >>. many record_without_bodies) <|>% [])
                |>> fun (name, acs, withs, withouts) -> RawRecordWith(v name :: acs,withs,withouts)
        
            curlies (restore1 record_with <|> record_create)

        let case_join_point = skip_keyword SpecJoin >>. next |>> (inline_ >> RawJoinPoint)

        let case_symbol = read_symbol |>> RawSymbolCreate
        let case_symbol_paired s =
            if s.symbol_line <> line s then
                let pat s =
                    let i = col s
                    ((indent i (<=) read_symbol_paired) .>>. (opt (indent i (<) (level_symbol_set next)))) s
                (many1 pat |>> fun l ->
                    let a,b = List.unzip l
                    let x,x' = match a with x::x' -> x,x' | _ -> failwith "Compiler error: Expected `many1 pat` to produce an element."
                    let is_upper = Char.IsUpper(x, 0)
                    let a = if is_upper then to_lower x :: x' else a
                    let b = List.map2 (fun a b -> defaultArg b (v a)) a b
                    let a = 
                        let sb = Text.StringBuilder()
                        a |> List.iter (fun x -> sb.Append(x) |> ignore; sb.Append('_') |> ignore)
                        sb.ToString()
                    if is_upper then ap (v a) (List.reduceBack (binop TupleCreate) b)
                    else List.reduceBack (binop TupleCreate) (RawSymbolCreate a :: b)
                    ) s
            else
                Error []

        let case_unary_op = 
            read_unary_op >>= fun a d ->
                match a with
                | "!!!!" -> 
                    (range read_big_var .>>. (rounds (sepBy1 expressions (skip_op ",")))
                    >>= fun ((r, a), b) _ ->
                        match string_to_op a with
                        | true, op' -> Ok(RawOp(op',List.toArray b))
                        | false, _ -> Error [r,InbuiltOpNotFound a]) d
                | "`" -> (((read_small_var |>> RawTVar) <|> rounds (root_type false true false)) |>> RawType) d
                | _ -> (expressions |>> fun b -> ap (v a) b) d

        let (+) = alt (index d)

        (case_value + case_default_value + case_var + case_join_point + case_symbol + case_symbol_paired
        + case_typecase + case_pattern_match + case_typecase + case_rounds + case_record
        + case_if_then_else + case_fun + case_forall + case_unary_op) d

    let application_tight d =
        let next = expressions
        let inline expr_tight (d: Env) = 
            let i = index d
            if 0 < i && i < d.tokens.Length then
                let r,r' = fst d.tokens.[i-1], fst d.tokens.[i]
                if r.line = r'.line && r.nearTo = r'.from then next d else Error []
            else Error []

        pipe2 next (many expr_tight) (List.fold ap) d

    let application (d: Env) =
        let next = application_tight
        let i = col d
        pipe2 next (many (indent i (<) next)) (List.fold ap) d

    let operators d =
        let next = application
        let i = col d
        let term = indent i (<=) next
        let op = indent (i-1) (<=) op

        /// Pratt parser
        let rec led left (prec,asoc,m) d =
            match asoc with
            | Associativity.Right -> (tdop (prec-1) |>> fun right -> m (left, right)) d
            | _ -> (tdop prec |>> fun right -> m (left, right)) d

        and tdop rbp d =
            let rec loop left d = 
                ((op >>=? fun (prec,_,_ as v) d ->
                    if rbp < prec then (led left v >>= loop) d
                    else Error []) <|>% left) d
            (term >>= loop) d

        pipe2 (tdop Int32.MinValue)
            (opt (indent (i-1) (<=) (skip_op ":") >>. indent i (<=) (root_type false true false)))
            (fun a -> function Some b -> RawAnnot(a,b) | _ -> a)
            d

    let statements d =
        let next = operators
        let i = col d
        let (+) = alt i
        let p =
            (inl_or_let root_value (root_pattern true) |>> fun (r,(_,name),body) -> ParserStatement(r,fun on_succ -> l name body on_succ))
            + (module_open |>> fun (r,(name,acs)) -> ParserStatement(r,fun on_succ -> RawModuleOpen(name,acs,on_succ)))
            + (next |>> ParserExpr)
        let inline if_ x  = indent i x
        (many1 (if_ (=) p) .>>. opt (if_ (<=) (skip_keyword SpecIn) >>. if_ (<=) root_value) >>= process_parser_exprs) d

    statements d

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

type TopStatement =
    | TopAnd of TopStatement
    | TopInl of VarString * RawExpr

let top_inl_or_let = 
    (inl_or_let root_value (root_pattern true) >>= fun x _ ->
        match x with
        | _, (_ , (PatVar name | PatOperator name)), (RawForall _ | RawInl _ as body) -> Ok(TopInl(name, body))
        | r, (_ , (PatVar _ | PatOperator _)), _ -> Error [r, ExpectedGlobalFunction]
        | _, (r , _), _ -> Error [r, ExpectedVarOrOpAsNameOfGlobalStatement]
        )

//let top_statement s =
//    let i = index s
//    let inline (+) a b = alt i a b
//    (top_let + top_inl) s