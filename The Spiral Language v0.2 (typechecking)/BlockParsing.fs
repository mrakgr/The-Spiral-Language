module Spiral.BlockParsing
let f p d = let x = p d in printfn "%A" x; x

open System
open Spiral.ParserCombinators
open Spiral.Tokenize
type Range = Config.VSCRange
type Env = {
    tokens : (Range * SpiralToken) []
    comments : Tokenize.LineComment option []
    i : int ref
    is_top_down : bool
    } with

    member d.Index with get() = d.i.contents and set(i) = d.i := i

type PatternCompilationErrors =
    | DisjointOrPatternVar
    | DuplicateVar
    | ShadowedVar
    | DuplicateRecordSymbol
    | DuplicateRecordInjection

type ParserErrors =
    | InvalidPattern of PatternCompilationErrors
    | ExpectedKeyword of TokenKeyword
    | ExpectedOperator'
    | ExpectedOperator of string
    | ExpectedUnaryOperator'
    | ExpectedUnaryOperator of string
    | ExpectedUnit
    | ExpectedVar
    | ExpectedVarOrOpAsNameOfRecStatement
    | ExpectedVarOrOpAsNameOfGlobalStatement
    | ExpectedSmallVar
    | ExpectedBigVar
    | ExpectedLit
    | ExpectedSymbolPaired
    | SymbolPairedShouldStartWithUppercase
    | ExpectedSymbol
    | ExpectedParenthesis of Parenthesis * ParenthesisState
    | ExpectedOpenParenthesis
    | ExpectedStatement
    | ExpectedEob
    | ExpectedFunctionAsBodyOfRecStatement
    | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp
    | MissingFunctionBody
    | ExpectedGlobalFunction
    | ExpectedExpression
    | InbuiltOpNotFound
    | UnknownOperator
    | UnexpectedEob
    | UnexpectedAndInlRec
    | ForallNotAllowed
    | TypecaseNotAllowed
    | MetavarNotAllowed
    | TermNotAllowed
    | UnknownError
    | ExpectedAtLeastOneToken
    | DuplicateRecordTypeVar
    | DuplicateForallVar
    | DuplicateTermRecordSymbol
    | DuplicateTermRecordInjection
    | DuplicateRecFunctionName

let inline try_current_template (d : Env) on_succ on_fail =
    let i = d.Index
    if i < d.tokens.Length then on_succ d.tokens.[i]
    else on_fail()

let inline try_current d f = try_current_template d (fun (p,t) -> f (p, t)) (fun () -> Error [])
let print_current d = try_current d (fun x -> printfn "%A" x; Ok()) // For parser debugging purposes.
let inline line_template d f = try_current_template d (fst >> f) (fun _ -> -1)
let col d = line_template d (fun (r,_) -> r.character)
let line d = line_template d (fun (r,_) -> r.line)
   
let skip' (d : Env) i = d.i := d.i.contents+i
let skip d = skip' d 1

let skip_keyword t d =
    try_current d <| function
        | p,TokKeyword t' when t = t' -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedKeyword t]

let skip_keyword' t d =
    try_current d <| function
        | p,TokKeyword t' when t = t' -> skip d; Ok p
        | p, _ -> Error [p, ExpectedKeyword t]

let read_unary_op d =
    try_current d <| function
        | p, TokUnaryOperator t' -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_unary_op' d =
    try_current d <| function
        | p, TokUnaryOperator t' -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_op d =
    try_current d <| function
        | p, TokOperator t' -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedOperator']

let read_op' d =
    try_current d <| function
        | p, TokOperator t' -> skip d; Ok(p,t')
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
        | p, TokVar(t',r) -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedVar]

let read_var' d =
    try_current d <| function
        | p, TokVar(t',r) -> skip d; Ok(p,t',r)
        | p, _ -> Error [p, ExpectedVar]

let read_var'' d =
    try_current d <| function
        | p, TokVar(t',r) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedVar]

let read_big_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedBigVar]

let read_small_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedSmallVar]

let read_small_var' d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_type_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> skip d; r := SemanticTokenLegend.type_variable; Ok(t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_value d =
    try_current d <| function
        | p, TokValue t' -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedLit]

let read_default_value d =
    try_current d <| function
        | p, TokDefaultValue t' -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedLit]

let read_symbol_paired d =
    try_current d <| function
        | p, TokSymbolPaired(t',r) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSymbolPaired]

let read_symbol_paired' d =
    try_current d <| function
        | p, TokSymbolPaired(t',r) -> skip d; Ok(p,t',r)
        | p, _ -> Error [p, ExpectedSymbolPaired]

let to_lower (x : string) = Char.ToLower(x.[0]).ToString() + x.[1..]

let read_symbol d =
    try_current d <| function
        | p, TokSymbol(t',r) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSymbol]

let skip_parenthesis a b d =
    try_current d <| function
        | p, TokParenthesis(a',b') when a = a' && b = b' -> skip d; Ok()
        | p, _ -> Error [p, ExpectedParenthesis(a,b)]

let inline peek_open_parenthesis f d =
    try_current d <| function
        | p, TokParenthesis(a',Open) -> f d
        | p, _ -> Error [p, ExpectedOpenParenthesis]

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

    // Record
    | RecordMap
    | RecordFilter
    | RecordFoldL
    | RecordFoldR
    | RecordLength

    // Branching
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

    // Array
    | ArrayCreate
    | ArrayLength
    | ArrayIndex
    | ArrayIndexSet
   
    // Static unary operations
    | PrintStatic
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
type TypeVar = Range * (VarString * RawKindExpr)

type RawRecordWith =
    | RawRecordWithSymbol of (Range * SymbolString) * RawExpr
    | RawRecordWithSymbolModify of (Range * SymbolString) * RawExpr
    | RawRecordWithInjectVar of (Range * VarString) * RawExpr
    | RawRecordWithInjectVarModify of (Range * SymbolString) * RawExpr
and RawRecordWithout =
    | RawRecordWithoutSymbol of Range * SymbolString
    | RawRecordWithoutInjectVar of Range * VarString
and PatRecordMember =
    | PatRecordMembersSymbol of (Range * SymbolString) * name: Pattern
    | PatRecordMembersInjectVar of (Range * VarString) * name: Pattern
and Pattern =
    | PatB of Range
    | PatE of Range
    | PatVar of Range * VarString
    | PatDyn of Range * Pattern
    | PatUnbox of Range * Pattern
    | PatAnnot of Range * Pattern * RawTExpr
    | PatPair of Range * Pattern * Pattern
    | PatSymbol of Range * string
    | PatRecordMembers of Range * PatRecordMember list
    | PatActive of Range * RawExpr * Pattern
    | PatOr of Range * Pattern * Pattern
    | PatAnd of Range * Pattern * Pattern
    | PatValue of Range * Literal
    | PatDefaultValue of Range * VarString
    | PatWhen of Range * Pattern * RawExpr
    | PatNominal of Range * VarString * Pattern
and RawExpr =
    | RawB of Range
    | RawV of Range * VarString
    | RawLit of Range * Literal
    | RawDefaultLit of Range * string
    | RawSymbolCreate of Range * SymbolString
    | RawType of Range * RawTExpr
    | RawMatch of Range * body: RawExpr * (Pattern * RawExpr) list
    | RawFun of Range * (Pattern * RawExpr) list
    | RawForall of Range * TypeVar * RawExpr
    | RawRecBlock of Range * ((Range * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawInl or RawForall.
    | RawRecordWith of Range * RawExpr list * RawRecordWith list * RawRecordWithout list
    | RawOp of Range * Op * RawExpr list
    | RawJoinPoint of Range * RawExpr
    | RawAnnot of Range * RawExpr * RawTExpr
    | RawTypecase of Range * RawTExpr * (RawTExpr * RawExpr) list
    | RawModuleOpen of Range * (Range * VarString) * (Range * SymbolString) list * on_succ: RawExpr
    | RawApply of Range * RawExpr * RawExpr
    | RawIfThenElse of Range * RawExpr * RawExpr * RawExpr
    | RawIfThen of Range * RawExpr * RawExpr
    | RawPairCreate of Range * RawExpr * RawExpr
    | RawSeq of Range * RawExpr * RawExpr
    | RawReal of Range * RawExpr
and RawTExpr =
    | RawTWildcard of Range
    | RawTB of Range
    | RawTMetaVar of Range * VarString
    | RawTVar of Range * VarString
    | RawTPair of Range * RawTExpr * RawTExpr
    | RawTFun of Range * RawTExpr * RawTExpr
    | RawTRecord of Range * Map<string,RawTExpr>
    | RawTSymbol of Range * SymbolString
    | RawTApply of Range * RawTExpr * RawTExpr
    | RawTForall of Range * TypeVar * RawTExpr
    | RawTPrim of Range * PrimitiveType
    | RawTArray of Range * RawTExpr
    | RawTTerm of Range * RawExpr

let (+.) (a,_) (_,b) = a,b
let range_of_typevar ((r,(_,_)) : TypeVar) = r
let range_of_record_with = function
    | RawRecordWithSymbol((r,_),_)
    | RawRecordWithSymbolModify((r,_),_)
    | RawRecordWithInjectVar((r,_),_)
    | RawRecordWithInjectVarModify((r,_),_) -> r
let range_of_record_without = function
    | RawRecordWithoutSymbol(r,_)
    | RawRecordWithoutInjectVar(r,_) -> r
let range_of_pattern = function
    | PatB r
    | PatE r
    | PatVar(r,_)
    | PatDyn(r,_)
    | PatUnbox(r,_)
    | PatSymbol(r,_)
    | PatValue(r,_)
    | PatDefaultValue(r,_)
    | PatRecordMembers(r,_)
    | PatAnnot(r,_,_)
    | PatPair(r,_,_)
    | PatActive(r,_,_)
    | PatOr(r,_,_)
    | PatAnd(r,_,_)
    | PatWhen(r,_,_)
    | PatNominal(r,_,_) -> r
let range_of_pat_record_member = function
    | PatRecordMembersSymbol((r,_),x)
    | PatRecordMembersInjectVar((r,_),x) -> r +. range_of_pattern x
let range_of_expr = function
    | RawB r
    | RawV(r,_)
    | RawLit(r,_)
    | RawDefaultLit(r,_)
    | RawSymbolCreate(r,_)
    | RawType(r,_)
    | RawJoinPoint(r,_)
    | RawMatch(r,_,_)
    | RawFun(r,_)
    | RawReal(r,_)
    | RawRecBlock(r,_,_)
    | RawOp(r,_,_)
    | RawAnnot(r,_,_)
    | RawTypecase(r,_,_)
    | RawForall(r,_,_)
    | RawApply(r,_,_)
    | RawPairCreate(r,_,_)
    | RawIfThen(r,_,_)
    | RawSeq(r,_,_)
    | RawRecordWith(r,_,_,_)
    | RawIfThenElse(r,_,_,_)
    | RawModuleOpen(r,_,_,_) -> r
let range_of_texpr = function
    | RawTWildcard r
    | RawTB r
    | RawTMetaVar(r,_)
    | RawTVar(r,_)
    | RawTRecord(r,_)
    | RawTSymbol(r,_)
    | RawTPrim(r,_)
    | RawTArray(r,_)
    | RawTTerm(r,_)
    | RawTPair(r,_,_)
    | RawTFun(r,_,_)
    | RawTApply(r,_,_)
    | RawTForall(r,_,_) -> r

let on_succ x _ = Ok x
let rounds a d = (skip_parenthesis Round Open >>. a .>> skip_parenthesis Round Close) d
let curlies a d = (skip_parenthesis Curly Open >>. a .>> skip_parenthesis Curly Close) d
let squares a d = (skip_parenthesis Square Open >>. a .>> skip_parenthesis Square Close) d

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let inline range exp s =
    let i = index s
    exp s |> Result.map (fun x ->
        let i' = index s
        if i < i' then fst s.tokens.[i] +. fst s.tokens.[i'-1], x : Range * _
        else
            failwith "Compiler error: The parser passed into `range` has to consume at least one token for it to work."
        )

let rec kind d = (sepBy1 ((skip_op "*" >>% RawKindStar) <|> rounds kind) (skip_op "->") |>> List.reduceBack (fun a b -> RawKindFun (a,b))) d
let forall_var d = range ((read_type_var |>> fun x -> x, RawKindStar) <|> rounds ((read_type_var .>> skip_op ":") .>>. kind)) d

let duplicates er x = 
    let h = Collections.Generic.HashSet()
    x |> List.choose (fun (r,n) -> if h.Add n = false then Some(r,er) else None)
let forall d = 
    (skip_keyword SpecForall >>. (many1 forall_var) .>> skip_op "." 
    >>= fun x _ -> duplicates DuplicateForallVar x |> function [] -> Ok x | er -> Error er) d
let inline type_forall next d = (pipe2 (forall <|>% []) next (List.foldBack (fun x s -> RawTForall(range_of_typevar x +. range_of_texpr s,x,s)))) d 

let inline indent i op next d = if op i (col d) then next d else Error []

let record_var d = (read_var <|> rounds read_op) d

let patterns_validate pats = 
    let pos = Collections.Generic.Dictionary(HashIdentity.Reference)
    let errors = ResizeArray()
    let rec loop pat =
        match pat with
        | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatE | PatB -> Set.empty
        | PatVar(r,x) -> 
            pos.Add(x,r)
            Set.singleton x
        | PatDyn(_,p) | PatAnnot (_,p,_) | PatNominal(_,_,p) | PatActive (_,_,p) | PatUnbox(_,p) | PatWhen(_,p,_) -> loop p
        | PatRecordMembers(_,items) ->
            let symbols = Collections.Generic.HashSet()
            let injects = Collections.Generic.HashSet()
            let x =
                List.map (fun item ->
                    match item with
                    | PatRecordMembersSymbol((r,keyword),name) ->
                        if symbols.Add(keyword) = false then errors.Add (r, InvalidPattern DuplicateRecordSymbol); Set.empty else loop name
                    | PatRecordMembersInjectVar((r,var),name) ->
                        if injects.Add(var) = false then errors.Add (r, InvalidPattern DuplicateRecordInjection); Set.empty else loop name
                    ) items
            match x with _ :: _ :: _ -> Set.intersectMany x |> Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DuplicateVar)) | _ -> ()
            Set.unionMany x
        | PatPair(_,a,b) | PatAnd(_,a,b) -> 
            let a, b = loop a, loop b
            Set.intersect a b |> Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DuplicateVar))
            a + b
        | PatOr(_,a,b) -> 
            let a, b = loop a, loop b
            let f = Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DisjointOrPatternVar))
            f (a-b); f (b-a)
            a
    
    List.fold (fun s x ->
        let s' = loop x
        Set.intersect s s' |> Set.iter (fun x -> errors.Add(pos.[x],InvalidPattern ShadowedVar))
        s + s'
        ) Set.empty pats |> ignore
    errors |> Seq.toList

let inl_or_let_process (r, (is_let, is_rec, name, foralls, pats, body)) _ =
    match body with
    // TODO: Rather than return an error during parsing for this particular error, for the typechecking pass I'll replace it with a metavariable stump.
    | None -> Error [r, MissingFunctionBody]
    | Some body ->
        let name, pats =
            match name with
            | PatUnbox(_,PatPair(_,PatSymbol(r,name), pat)) -> PatVar(r,name), pat :: pats
            | _ -> name, pats
        let dyn_if_let x = if is_let then x else PatDyn(range_of_pattern x, x)
        match is_rec, name, foralls, pats with
        | _, PatVar _, _, _ -> 
            match patterns_validate (if is_rec then name :: pats else pats) with
            | [] -> 
                let body = 
                    List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[dyn_if_let pat,body])) pats body
                    |> List.foldBack (fun typevar body -> RawForall(range_of_typevar typevar +. range_of_expr body,typevar,body)) foralls
                match is_rec, body with
                | false, _ | true, (RawFun _ | RawForall _) -> Ok((r,name,body),is_rec)
                | true, _ -> Error [r, ExpectedFunctionAsBodyOfRecStatement]
            | ers -> Error ers
        | false, _, [], [] -> 
            match patterns_validate [name] with
            | [] -> Ok((r,dyn_if_let name,body),is_rec)
            | ers -> Error ers
        | true, _, _, _ -> Error [range_of_pattern name, ExpectedVarOrOpAsNameOfRecStatement]
        | false, _, _, _ -> Error [range_of_pattern name, ExpectedSinglePatternWhenStatementNameIsNorVarOrOp]

let inline inl_or_let exp pattern =
    range (tuple6 ((skip_keyword SpecInl >>% true) <|> (skip_keyword SpecLet >>% false))
            ((skip_keyword SpecRec >>% true) <|>% false) pattern
            (forall <|>% []) (many pattern) (skip_op "=" >>. opt exp))
    >>= inl_or_let_process

let inline and_inl_or_let exp pattern =
    range (tuple6 (skip_keyword SpecAnd >>. ((skip_keyword SpecInl >>% true) <|> (skip_keyword SpecLet >>% false)))
            (fun _ -> Ok true) pattern
            (forall <|>% []) (many pattern) (skip_op "=" >>. opt exp))
    >>= inl_or_let_process

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
    | "." -> ValueSome(3, Associativity.Right)
    | "," -> ValueSome(5, Associativity.Right)
    | ":>" -> ValueSome(35, Associativity.Right)
    | ":?>" -> ValueSome(35, Associativity.Right)
    | "**" -> ValueSome(80, Associativity.Right)
    | _ -> ValueNone

// Since `.` is an operator in Spiral, unlike in F# it does not filter out `.`s. Instead it just trims the right side until 
// it finds (or fails to find) a match.
let rec precedence_associativity name = 
    if 0 < String.length name then
        match inbuilt_operators name with
        | ValueNone -> precedence_associativity (name.[0..name.Length-2])
        | v -> v
    else ValueNone

let op (d : Env) =
    range read_op d |> Result.bind (fun (o,x) ->
        match x with
        | "=>" | "|" | ":" | ";" -> skip' d -1; Error [] // Separators get special handling for sake of better error messages.
        | _ ->
            match precedence_associativity x with // TODO: Might be good to memoize this.
            | ValueNone -> Error [o, UnknownOperator]
            | ValueSome(p,a) ->
                match x with
                | "." -> Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    RawSeq(r,a,b)
                    )
                | "&&" -> Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    RawIfThenElse(r,a,b,RawLit(o,LitBool false))
                    )
                | "||" -> Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    RawIfThenElse(r,a,RawLit(o,LitBool true),b)
                    )
                | "," -> Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    RawPairCreate(r,a,b)
                    )
                | x -> Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    RawApply(r,RawApply(ra +. o,RawV(o,x),a),b)
                    )
        )

let private string_to_op_dict = Collections.Generic.Dictionary(HashIdentity.Structural)
Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
|> Array.iter (fun x -> string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op)
let string_to_op x = string_to_op_dict.TryGetValue x

let symbol_paired_concat k =
    let b = Text.StringBuilder()
    List.iter (fun (_, x : string) -> b.Append(x).Append('_') |> ignore) k
    b.ToString()

let module_open = range ((skip_keyword SpecOpen >>. read_small_var') .>>. (many read_symbol))
let bar i d = indent i (<=) (skip_op "|") d

let inline unit' f d =
    let i = index d
    if i+1 < d.tokens.Length then
        let a,b = d.tokens.[i], d.tokens.[i+1]
        let r = fst a +. fst b
        match snd a, snd b with
        | TokParenthesis(Round,Open), TokParenthesis(Round,Close) -> skip' d 2; Ok(f r)
        | _ -> Error [fst a, ExpectedUnit]
    else
        Error []

let inline pat_pair next = 
    sepBy1 next (skip_op ",") 
    |>> List.reduceBack (fun a b -> PatPair(range_of_pattern a +. range_of_pattern b,a,b))

type RootTypeFlags = {
    allow_metavars : bool
    allow_term : bool
    allow_wildcard : bool
    }

let root_type_defaults = {
    allow_metavars = false
    allow_term = false
    allow_wildcard = false
    }

let rec pat_nominal d =
    (pat_var >>= fun x d -> 
        match x with
        | PatVar(ra,a) -> (opt root_pattern_var |>> function Some b -> PatNominal(ra +. range_of_pattern b,a,b) | None -> x) d
        | _ -> Ok x) d
and pat_var d =
    (read_var' |>> fun (r,a,re) ->
        if Char.IsUpper(a,0) then 
            re := SemanticTokenLegend.symbol
            PatUnbox(r,PatPair(r,PatSymbol(r,to_lower a), PatB r))
        else PatVar(r,a)
        ) d
and pat_wildcard d = (skip_keyword' SpecWildcard |>> PatE) d
and pat_dyn d = (range (skip_unary_op "~" >>. root_pattern_var) |>> PatDyn) d
and root_pattern s =
    let body s = 
        let pat_unit = unit' PatB
        let pat_active = 
            range (skip_unary_op "!" >>. ((read_small_var' |>> RawV) <|> rounds root_term) .>>. root_pattern_var) 
            |>> fun (r,(a,b)) -> PatActive(r,a,b)
        let pat_value = (read_value |>> PatValue) <|> (read_default_value |>> PatDefaultValue)
        let pat_record_item =
            let inj = skip_unary_op "$" >>. read_small_var' |>> fun a -> PatRecordMembersInjectVar,a
            let var = range record_var |>> fun a -> PatRecordMembersSymbol,a
            ((inj <|> var) .>>. (opt (skip_op "=" >>. root_pattern_pair)))
            |>> fun ((f,a),b) -> f (a, defaultArg b (PatVar a))
        let pat_record = range (curlies (many pat_record_item)) |>> PatRecordMembers
        let pat_symbol = read_symbol |>> PatSymbol
        let pat_rounds = rounds (root_pattern <|> (read_op' |>> PatVar))
        let (+) = alt (index s)
        (pat_unit + pat_rounds + pat_nominal + pat_wildcard + pat_dyn + pat_value + pat_record + pat_symbol + pat_active) s

    let pat_type = 
        pipe2 body (opt (skip_op ":" >>. fun d -> root_type {root_type_defaults with allow_term=d.is_top_down=false; allow_wildcard=d.is_top_down} d))
            (fun a -> function Some b -> PatAnnot(range_of_pattern a +. range_of_texpr b,a,b) | None -> a)
    let pat_and = sepBy1 pat_type (skip_op "&") |>> List.reduce (fun a b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b))
    let pat_pair = pat_pair pat_and
    let pat_symbol_paired = 
        let next = pat_pair
        (many1 (read_symbol_paired' .>>. opt next) |>> fun l ->
            let f ((r,a,re),b) = (r, a), Option.defaultWith (fun () -> re := SemanticTokenLegend.variable; PatVar(r,a)) b
            match l |> List.map f |> List.unzip with
            | (r,x) :: k', v ->
                List.reduceBack (fun a b -> PatPair(range_of_pattern a +. range_of_pattern b,a,b))
                    (PatSymbol(r,symbol_paired_concat ((r,to_lower x) :: k')) :: v)
                |> fun l -> if Char.IsUpper(x,0) then PatUnbox(range_of_pattern l,l) else l
            | _ -> failwith "Compiler error: Should be at least one key in symbol_paired_process_pattern"
            )
        <|> next
    let pat_or = sepBy1 pat_symbol_paired (skip_op "|") |>> List.reduce (fun a b -> PatOr(range_of_pattern a +. range_of_pattern b,a,b))
    let pat_as = pat_or .>>. (opt (skip_keyword SpecAs >>. pat_or )) |>> function a, Some b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b) | a, None -> a
    let pat_when = pat_as .>>. (opt (skip_keyword SpecWhen >>. root_term)) |>> function a, Some b -> PatWhen(range_of_pattern a +. range_of_expr b,a,b) | a, None -> a
    pat_when s
and root_pattern_var d = 
    let (+) = alt (index d)
    (pat_var + pat_wildcard + pat_dyn + peek_open_parenthesis root_pattern) d
and root_pattern_pair d = pat_pair root_pattern_var d

and root_type (flags : RootTypeFlags) d =
    let next = root_type flags
    let cases d =
        let wildcard d = if flags.allow_wildcard then (skip_keyword' SpecWildcard |>> RawTWildcard) d else Error []
        let metavar d = if flags.allow_metavars then (skip_unary_op "~" >>. read_var'' |>> RawTMetaVar) d else Error []
        let term d = if flags.allow_term then (range (skip_unary_op "`" >>. ((read_var'' |>> RawV) <|> rounds root_term)) |>> RawTTerm) {d with is_top_down=false} else Error []
        let record =
            range (curlies (sepBy ((range record_var .>> skip_op ":") .>>. next) (skip_op ";")))
            >>= fun (r,x) _ ->
                x |> List.map fst |> duplicates DuplicateRecordTypeVar
                |> function [] -> Ok(RawTRecord(r,x |> List.map (fun ((_,n),x) -> n,x) |> Map.ofList)) | er -> Error er
        let symbol = read_symbol |>> RawTSymbol
    
        let var = read_var' |>> fun (o,x,r) ->
            if Char.IsUpper(x,0) then
                r := SemanticTokenLegend.symbol
                RawTPair(o,RawTSymbol(o,to_lower x), RawTB o)
            else
                r := SemanticTokenLegend.type_variable
                match x with
                | "i8" -> RawTPrim(o,Int8T)
                | "i16" -> RawTPrim(o,Int16T)
                | "i32" -> RawTPrim(o,Int32T)
                | "i64" -> RawTPrim(o,Int64T)
                | "u8" -> RawTPrim(o,UInt8T)
                | "u16" -> RawTPrim(o,UInt16T)
                | "u32" -> RawTPrim(o,UInt32T)
                | "u64" -> RawTPrim(o,UInt64T)
                | "f32" -> RawTPrim(o,Float32T)
                | "f64" -> RawTPrim(o,Float64T)
                | "string" -> RawTPrim(o,StringT)
                | "bool" -> RawTPrim(o,BoolT)
                | "char" -> RawTPrim(o,CharT)
                | x -> RawTVar(o, x)
        let (+) = alt (index d)
        (unit' RawTB + rounds next + wildcard + term + metavar + var + record + symbol) d
    let apply d = 
        (pipe2 cases (many (indent (col d) (<) cases)) 
            (fun a b -> 
                List.reduce (fun a b -> 
                    match a with 
                    | RawTVar(ra, "array") -> RawTArray(ra +. range_of_texpr b, b)
                    | _ -> RawTApply(range_of_texpr a +. range_of_texpr b,a,b)
                    ) (a :: b))) d
    let pairs = sepBy1 apply (skip_op "*") |>> List.reduceBack (fun a b -> RawTPair(range_of_texpr a +. range_of_texpr b,a,b))
    let functions = sepBy1 pairs (skip_op "->") |>> List.reduceBack (fun a b -> RawTFun(range_of_texpr a +. range_of_texpr b,a,b))
    let symbol_paired d = 
        let next = functions
        ((many1 (indent (col d) (<=) read_symbol_paired .>>. next) >>= fun l _ ->
            match List.unzip l with
            | [], _ -> failwith "Compiler error: Single item expected."
            | (r,x) :: k', v ->
                if Char.IsUpper(x,0) then
                    List.reduceBack (fun a b -> RawTPair(range_of_texpr a +. range_of_texpr b,a,b)) 
                        (RawTSymbol(r,symbol_paired_concat ((r,to_lower x) :: k')) :: v) |> Ok
                else
                    Error [r, SymbolPairedShouldStartWithUppercase]
            )
        <|> next) d
    symbol_paired d

and root_term d =
    let rec expressions d =
        let next = root_term
        let case_var = 
            read_var' |>> fun (r,x,re) -> 
                if Char.IsUpper(x,0) then 
                    re := SemanticTokenLegend.symbol
                    RawApply(r, RawV(r,to_lower x), RawB r) 
                else RawV(r,x)
        let case_unit = unit' RawB
        let case_rounds = rounds ((read_op' |>> RawV) <|> next)
        let case_fun =
            (skip_keyword SpecFun >>. many1 root_pattern_pair .>>. (skip_op "=>" >>. next))
            >>= fun (pats, body) _ ->
                match patterns_validate pats with
                | [] -> List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body |> Ok
                | ers -> Error ers
            
        let case_forall =
            tuple3 forall (many root_pattern_pair) (skip_op "=>" >>. next)
            >>= fun (foralls, pats, body) d ->
                match patterns_validate pats with
                | [] -> 
                    List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body
                    |> List.foldBack (fun a body -> RawForall(range_of_typevar a +. range_of_expr body,a,body)) foralls |> Ok
                | ers -> Error ers

        let case_value = read_value |>> RawLit
        let case_default_value = read_default_value |>> RawDefaultLit
        let case_if_then_else d = 
            let i = col d
            let inline f' keyword = range (skip_keyword keyword >>. next)
            let inline f keyword = indent i (<=) (f' keyword)
            (pipe4 (f' SpecIf) (f SpecThen) (many (f SpecElif .>>. f SpecThen)) (opt (f SpecElse))
                (fun cond tr elifs fl -> 
                    let f cond tr = function
                        | Some fl -> fst fl, RawIfThenElse(fst cond +. fst fl,snd cond,snd tr,snd fl)
                        | None -> fst tr, RawIfThen(fst cond +. fst tr,snd cond,snd tr)
                    let fl = List.foldBack (fun (cond,tr) fl -> f cond tr fl |> Some) elifs fl
                    f cond tr fl |> snd)) d
        
        let case_match =
            let clauses d = 
                let bar = bar (col d)
                (optional bar >>. sepBy1 (root_pattern .>>. (skip_op "=>" >>. next)) bar
                >>= fun l _ ->
                    match patterns_validate (List.map fst l) with
                    | [] -> Ok l
                    | e -> Error e
                    ) d

            (range (skip_keyword SpecFunction >>. clauses) |>> RawFun)
            <|> (range ((skip_keyword SpecMatch >>. next .>> skip_keyword SpecWith) .>>. clauses) |>> fun (a,(b,c)) -> RawMatch(a,b,c))

        let case_typecase d =
            let clauses d = 
                let bar = bar (col d)
                (optional bar >>. sepBy1 (root_type {root_type_defaults with allow_metavars=true; allow_wildcard=true} .>>. (skip_op "=>" >>. next)) bar) d

            if d.is_top_down then Error [] else
                (range ((skip_keyword SpecTypecase >>. root_type {root_type_defaults with allow_term=true} .>> skip_keyword SpecWith) .>>. clauses)
                |>> fun (r, (a, b)) -> RawTypecase(r,a,b)) d

        let case_record =
            let record_body = skip_op "=" >>. next
            let record_create_body = range record_var .>>. record_body |>> RawRecordWithSymbol
            let record_create = range (sepBy record_create_body (skip_op ";")) |>> fun (r,withs) -> (r,[],withs,[])
            let record_with_bodies =
                record_create_body <|> (read_unary_op' >>= fun (r,x) d ->
                    match x with
                    | "#" -> (range record_var .>>. record_body |>> RawRecordWithSymbolModify) d
                    | "$" -> (range read_small_var .>>. record_body |>> RawRecordWithInjectVar) d
                    | "#$" -> (range read_small_var .>>. record_body |>> RawRecordWithInjectVarModify) d
                    | _ -> Error [r, ExpectedUnaryOperator "#"; r, ExpectedUnaryOperator "$"; r, ExpectedUnaryOperator "#$"]
                    )
            let record_without_bodies = (range record_var |>> RawRecordWithoutSymbol) <|> (skip_unary_op "$" >>. read_small_var' |>> RawRecordWithoutInjectVar)
            let record_with =
                range
                    (tuple4 read_small_var'
                        (many ((read_symbol |>> RawSymbolCreate) <|> (skip_op "$" >>. read_small_var' |>> RawV)))
                        ((skip_keyword SpecWith >>. sepBy record_with_bodies (skip_op ";")) <|>% [])
                        ((skip_keyword SpecWithout >>. many record_without_bodies) <|>% []))
                |>> fun (r,(name, acs, withs, withouts)) -> (r,RawV name :: acs,withs,withouts)
        
            restore 2 (curlies record_with) <|> curlies record_create
            >>= fun (_,_,withs,withouts as x) _ ->
                [
                withs |> List.choose (function RawRecordWithSymbol(a,_) | RawRecordWithSymbolModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordSymbol
                withs |> List.choose (function RawRecordWithInjectVar(a,_) | RawRecordWithInjectVarModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordInjection
                withouts |> List.choose (function RawRecordWithoutSymbol(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordSymbol
                withouts |> List.choose (function RawRecordWithoutInjectVar(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordInjection
                ] |> List.concat |> function [] -> Ok(RawRecordWith x) | er -> Error er

        let case_join_point = skip_keyword SpecJoin >>. next |>> fun x -> RawJoinPoint(range_of_expr x,x)
        let case_real = skip_keyword SpecReal >>. (fun d -> next {d with is_top_down=false}) |>> fun x -> RawReal(range_of_expr x,x)

        let case_symbol = read_symbol |>> RawSymbolCreate

        let case_unary_op = 
            read_unary_op' >>= fun (o,a) d ->
                let type_expr d = ((read_small_var' |>> RawTVar) <|> (rounds (fun d -> root_type {root_type_defaults with allow_term=true} d))) d
                match a with
                | "!!!!" -> 
                    (range (read_big_var .>>. (rounds (sepBy1 expressions (skip_op ","))))
                    >>= fun (r,((ra,a), b)) _ ->
                        match string_to_op a with
                        | true, op' -> Ok(RawOp(r,op',b))
                        | false, _ -> Error [ra,InbuiltOpNotFound]) d
                | "`" -> if d.is_top_down then Error [] else (range type_expr |>> RawType) d
                | "``" -> if d.is_top_down then Error [] else (range type_expr |>> fun (r,x) -> RawOp(o +. r,TypeToVar,[RawType(r,x)])) d
                | _ -> (expressions |>> fun b -> RawApply(o +. range_of_expr b,RawV(o, "~" + a),b)) d

        let (+) = alt (index d)

        (case_value + case_default_value + case_var + case_join_point + case_real + case_symbol
        + case_typecase + case_match + case_typecase + case_unit + case_rounds + case_record
        + case_if_then_else + case_fun + case_forall + case_unary_op) d

    let application_tight d =
        let next = expressions
        let inline expr_tight (d: Env) = 
            let i = index d
            if 0 < i && i < d.tokens.Length then
                let r,r' = snd (fst d.tokens.[i-1]), fst (fst d.tokens.[i])
                if r.line = r'.line && r.character = r'.character then next d else Error []
            else Error []

        pipe2 next (many expr_tight) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

    let application (d: Env) =
        let next = application_tight
        pipe2 next (many (indent (col d) (<) next)) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

    let operators d =
        let term = application
        let op = op

        /// Pratt parser
        let rec led left (prec,asoc,m) d =
            match asoc with
            | Associativity.Right -> (tdop (prec-1) |>> fun right -> m (left, right)) d
            | _ -> (tdop prec |>> fun right -> m (left, right)) d

        and tdop rbp d =
            let rec loop left d = 
                ((op >>= fun (prec,_,_ as v) d ->
                    if rbp < prec then (led left v >>= loop) d
                    else skip' d -1; Error []) <|>% left) d
            (term >>= loop) d

        pipe2 (tdop Int32.MinValue)
            (opt (skip_op ":" >>. (fun d -> root_type {root_type_defaults with allow_term=d.is_top_down=false; allow_wildcard=d.is_top_down} d)))
            (fun a -> function Some b -> RawAnnot(range_of_expr a +. range_of_texpr b,a,b) | _ -> a)
            d

    let symbol_paired d =
        let next = operators
        ((many1 (indent (col d) (<=) read_symbol_paired' .>>. opt next) |>> fun l ->
            let f ((r,a,re),b) = (r, a), Option.defaultWith (fun () -> re := SemanticTokenLegend.variable; RawV(r,a)) b
            match l |> List.map f |> List.unzip with
            | (r,x) :: k', v ->
                let name = r, symbol_paired_concat ((r,to_lower x) :: k')
                let body = List.reduceBack (fun a b -> RawPairCreate(range_of_expr a +. range_of_expr b,a,b)) v
                if Char.IsUpper(x,0) then RawApply(r +. range_of_expr body, RawV name, body)
                else RawPairCreate(r +. range_of_expr body, RawSymbolCreate name, body)
            | _ -> failwith "Compiler error: Should be at least one key in symbol_paired_process_pattern"
            )
        <|> next) d

    let statements d =
        let next = symbol_paired
        let inl_or_let =
            (inl_or_let root_term root_pattern_pair .>>. many (and_inl_or_let root_term root_pattern_pair))
            >>= fun x _ -> 
                match x with
                | ((r,name,body),false), [] -> Ok(fun on_succ -> RawMatch(r,body,[name,on_succ]))
                | ((_,_,_),false), l -> l |> List.map (fun ((r,_,_),_) -> r, UnexpectedAndInlRec) |> Error
                | x, xs ->
                    let l = x :: xs |> List.map (function 
                        | (r,PatVar(o,name),body),true -> r, ((o,name), body)
                        | _ -> failwith "Compiler error: Recursive inl/let statements should always have PatVar or PatOperator for names and should always be recursive."
                        )
                    let r = l |> List.map fst |> List.reduce (+.)
                    l |> List.map (snd >> fst) 
                    |> duplicates DuplicateRecFunctionName
                    |> function [] -> Ok(fun on_succ -> RawRecBlock(r, List.map snd l, on_succ)) | er -> Error er
        let module_open = module_open |>> fun (r,(name,acs)) on_succ -> RawModuleOpen(r,name,acs,on_succ)
        let statement_parsers d =
            let (+) = alt (index d)
            (inl_or_let + module_open) d
        
        let i = col d
        let inline if_ x = indent i x
        let stmts = 
            many1 (if_ (=) (range statement_parsers)) .>>. opt ((if_ (<=) (skip_keyword SpecIn) >>. root_term) <|> if_ (=) next)
            >>= fun (a,b) _ -> match b with Some b -> Ok(a,b) | None -> Error [List.last a |> fst, ExpectedExpression]
        let expr = if_ (=) next |>> fun x -> [],x
        (many1 (stmts <|> expr)
        |>> fun x -> 
            List.foldBack (fun (stmts,expr) s -> 
                let process_statements s = List.foldBack (fun (_,a) b -> a b) stmts s
                match s with
                | ValueNone -> ValueSome (process_statements expr)
                | ValueSome expr' -> ValueSome (process_statements (RawSeq(range_of_expr expr +. range_of_expr expr',expr,expr')))
                ) x ValueNone |> ValueOption.get
            ) d

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
    | TopAnd of Range * TopStatement
    | TopInl of Range * VarString * RawExpr * is_top_down: bool
    | TopRecInl of Range * VarString * RawExpr * is_top_down: bool
    | TopUnion of Range * TypeVar list * RawTExpr list
    | TopNominal of Range * TypeVar list * RawTExpr
    | TopPrototype of Range * VarString * VarString * TypeVar list * RawTExpr
    | TopType of Range * VarString * TypeVar list * RawTExpr
    | TopInstance of Range * VarString * VarString * TypeVar list * RawExpr

let top_inl_or_let_process is_top_down = function
    | (r,PatVar(_,name),(RawForall _ | RawFun _ as body)),false -> Ok(TopInl(r,name,body,is_top_down))
    | (r,PatVar(_,name),(RawForall _ | RawFun _ as body)),true -> Ok(TopRecInl(r,name,body,is_top_down))
    | (r,PatVar _,_),_ -> Error [r, ExpectedGlobalFunction]
    | (_,x,_),_ -> Error [range_of_pattern x, ExpectedVarOrOpAsNameOfGlobalStatement]
let top_inl_or_let d = (inl_or_let root_term root_pattern_pair >>= fun x d -> top_inl_or_let_process d.is_top_down x) d

let top_union d =
    let clauses d =
        let bar = bar (col d)
        (optional bar >>. sepBy1 (root_type root_type_defaults) bar) d

    (range ((skip_keyword SpecUnion >>. many forall_var .>> skip_op "=") .>>. clauses) |>> fun (r,(a,b)) -> TopUnion(r,a,b)) d

let top_nominal d = (range ((skip_keyword SpecNominal >>. many forall_var .>> skip_op "=") .>>. root_type {root_type_defaults with allow_term=true}) |>> fun (r,(a,b)) -> TopNominal(r,a,b)) d
let top_prototype d = 
    (range 
        (tuple4
            (skip_keyword SpecPrototype >>. read_small_var) read_type_var (many forall_var) 
            (skip_op ":" >>. type_forall (root_type root_type_defaults)))
    |>> fun (r,(a,b,c,d)) -> TopPrototype(r,a,b,c,d)) d
let top_type d = (range (tuple3 (skip_keyword SpecType >>. read_small_var) (many forall_var) (skip_op "=" >>. root_type root_type_defaults)) |>> fun (r,(a,b,c)) -> TopType(r,a,b,c)) d
let top_instance d =
    (range
        (tuple5 (skip_keyword SpecInstance >>. read_small_var) (read_type_var .>>. many forall_var)
            (skip_op ":" >>. forall <|>% []) (many root_pattern_pair)
            (skip_op "=" >>. root_term))
    >>= fun (r,(prototype_name, (nominal_name, nominal_foralls), foralls, pats, body)) _ ->
            match patterns_validate pats with
            | [] ->
                let body =
                    List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body
                    |> List.foldBack (fun a body -> RawForall(range_of_typevar a,a,body)) foralls
                Ok(TopInstance(r,prototype_name,nominal_name,nominal_foralls,body))
            | ers -> Error ers) d

let top_and_inl_or_let d = 
    (restore 1 (range (and_inl_or_let root_term root_pattern_pair)) 
    >>= fun (r,x) d -> top_inl_or_let_process d.is_top_down x |> Result.map (fun x -> TopAnd(r,x))) d
let inline top_and f = restore 1 (range (skip_keyword SpecAnd >>. f)) |>> TopAnd

let top_statement s =
    let (+) = alt (index s)
    (top_inl_or_let + top_union + top_nominal + top_prototype + top_type + top_instance 
    + top_and_inl_or_let + top_and top_nominal + top_and top_union) s

let parse (s : Env) =
    if 0 < s.tokens.Length then
        match top_statement s with
        | Ok _ as x -> if s.Index = s.tokens.Length then x else Error [fst s.tokens.[s.Index], ExpectedEob]
        | Error [] ->
            if s.Index = s.tokens.Length then Error [fst (Array.last s.tokens), UnexpectedEob]
            else Error [fst s.tokens.[s.Index], ExpectedEob]
        | Error _ as l -> l
    else
        Error [({line=0; character=0}, {line=0; character=1}), ExpectedAtLeastOneToken]