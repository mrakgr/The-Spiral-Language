module Spiral.BlockParsing
//let f p d = let x = p d in printfn "%A" x; x

open System
open VSCTypes
open Spiral.Tokenize
open Spiral.ParserCombinators

type SymbolString = string
type VarString = string
type NominalString = string

type PrimitiveType =
    | UInt8T | UInt16T | UInt32T | UInt64T
    | Int8T | Int16T | Int32T | Int64T
    | Float32T | Float64T
    | BoolT | StringT | CharT

type Layout = Heap | HeapMutable

type Op =
    // imports
    | Global

    // Python
    | ToPythonRecord
    | ToPythonNamedTuple

    // Branching
    | While

    // Layout
    | LayoutToHeap
    | LayoutToHeapMutable
    | LayoutIndex

    // Type
    | TypeToVar
    | TypeToSymbol
    | TypeLitToLit
    | LitToTypeLit

    // Closure conversion
    | Dyn

    // Nominal 
    | NominalCreate // Also creates the union

    // Union
    | Unbox
    | Unbox2
    | UnionTag
    | UnionUntag
    | UnionToRecord

    // String
    | StringLength
    | StringIndex
    | StringSlice

    // Array
    | ArrayCreate
    | ArrayLength
    | ArrayIndex
    | ArrayIndexSet

    // Record
    | RecordMap
    | RecordIter
    | RecordFilter
    | RecordFold
    | RecordFoldBack
    | RecordLength

    // Record Type
    | RecordTypeMap
    | RecordTypeIter
    | RecordTypeFold
    | RecordTypeFoldBack
    | RecordTypeLength
    | RecordTypeTryFind

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
    | TypeEq
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

    // Unary math ops
    | Neg
    | Tanh
    | Log
    | Exp
    | Sqrt
    | NanIs
    | Conv

    // Infinity
    | Infinity

    // Static Is
    | LitIs
    | PrimIs
    | SymbolIs
    | VarIs
    | UnionIs
    | HeapUnionIs
    | LayoutIs
    | NominalIs
    | FunctionIs
    | PrototypeHas

    // Static Type Is
    | PrimTypeIs
    | SymbolTypeIs
    | UnionTypeIs
    | HeapUnionTypeIs
    | LayoutTypeIs
    | NominalTypeIs
    

    // Panic
    | FailWith

    // Static unary operations
    | PrintStatic
    | PrintRaw
    | ErrorType
    | NominalStrip
    
    // Serialization helpers
    | VarTag
    | TagToSymbol
    | FunctionTermSlotsGet
    | FunctionTermSlotsSet
    | SizeOf
    | FreeVars

type PatternCompilationErrors =
    | DisjointOrPatternVar
    | DuplicateVar
    | ShadowedVar
    | DuplicateRecordSymbol
    | DuplicateRecordInjection

type ParserErrors =
    | InvalidPattern of PatternCompilationErrors
    | ExpectedKeyword of TokenKeyword
    | ExpectedStringOpen | ExpectedStringClose
    | ExpectedMacroOpen | ExpectedMacroClose
    | ExpectedMacroVar | ExpectedMacroTypeVar | ExpectedMacroTypeLitVar 
    | ExpectedText | ExpectedEscapedChar | ExpectedUnescapedChar
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
    | SymbolPairedShouldStartWithUppercaseInTypeScope
    | ExpectedSymbol
    | ExpectedParenthesis of Parenthesis * ParenthesisState
    | ExpectedOpenParenthesis
    | ExpectedStatement
    | ExpectedEob
    | ExpectedFunctionAsBodyOfRecStatement
    | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp
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
    | DuplicateRecordTypeVar
    | DuplicateForallVar
    | DuplicateConstraint
    | DuplicateTermRecordSymbol
    | DuplicateTermRecordInjection
    | DuplicateRecFunctionName
    | BottomUpNumberParseError of string * string
    | ExpectedPairedSymbolInUnion
    | DuplicateUnionKey
    | MetavarShadowedByVar
    | VarShadowedByMetavar
    | ListLiteralsNotAllowedInBottomUp

type RawKindExpr =
    | RawKindWildcard
    | RawKindStar
    | RawKindFun of RawKindExpr * RawKindExpr

type UnionLayout = UStack | UHeap

type HoVar = VSCRange * (VarString * RawKindExpr)
type TypeVar = HoVar * (VSCRange * VarString) list
type RawMacro =
    | RawMacroText of VSCRange * string
    | RawMacroTermVar of VSCRange * RawExpr
    | RawMacroTypeVar of VSCRange * RawTExpr
    | RawMacroTypeLitVar of VSCRange * RawTExpr
and RawRecordWith =
    | RawRecordWithSymbol of (VSCRange * SymbolString) * RawExpr
    | RawRecordWithSymbolModify of (VSCRange * SymbolString) * RawExpr
    | RawRecordWithInjectVar of (VSCRange * VarString) * RawExpr
    | RawRecordWithInjectVarModify of (VSCRange * VarString) * RawExpr
and RawRecordWithout =
    | RawRecordWithoutSymbol of VSCRange * SymbolString
    | RawRecordWithoutInjectVar of VSCRange * VarString
and PatRecordMember =
    | PatRecordMembersSymbol of (VSCRange * SymbolString) * name: Pattern
    | PatRecordMembersInjectVar of (VSCRange * VarString) * name: Pattern
and Pattern =
    | PatB of VSCRange
    | PatE of VSCRange
    | PatVar of VSCRange * VarString
    | PatDyn of VSCRange * Pattern
    | PatUnbox of VSCRange * symbol: string * Pattern
    | PatAnnot of VSCRange * Pattern * RawTExpr
    | PatPair of VSCRange * Pattern * Pattern
    | PatSymbol of VSCRange * string
    | PatRecordMembers of VSCRange * PatRecordMember list
    | PatOr of VSCRange * Pattern * Pattern
    | PatAnd of VSCRange * Pattern * Pattern
    | PatValue of VSCRange * Literal
    | PatDefaultValue of VSCRange * VarString
    | PatWhen of VSCRange * Pattern * RawExpr
    | PatNominal of VSCRange * (VSCRange * VarString) *  (VSCRange * VarString) list * Pattern
    | PatArray of VSCRange * Pattern list
    | PatFilledDefaultValue of VSCRange * VarString * RawTExpr // Filled in by the inferencer.
and RawExpr =
    | RawB of VSCRange
    | RawV of VSCRange * VarString
    | RawLit of VSCRange * Literal
    | RawDefaultLit of VSCRange * string
    | RawSymbol of VSCRange * SymbolString
    | RawType of VSCRange * RawTExpr
    | RawMatch of VSCRange * body: RawExpr * (Pattern * RawExpr) list
    | RawFun of VSCRange * (Pattern * RawExpr) list
    | RawForall of VSCRange * TypeVar * RawExpr
    | RawRecBlock of VSCRange * ((VSCRange * VarString) * RawExpr) list * on_succ: RawExpr // The bodies of a block must be RawFun or RawForall.
    | RawRecordWith of VSCRange * RawExpr list * RawRecordWith list * RawRecordWithout list
    | RawOp of VSCRange * Op * RawExpr list
    | RawJoinPoint of VSCRange * backend: (VSCRange * string) option * RawExpr * name: string option
    | RawAnnot of VSCRange * RawExpr * RawTExpr
    | RawTypecase of VSCRange * RawTExpr * (RawTExpr * RawExpr) list
    | RawOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list * on_succ: RawExpr
    | RawApply of VSCRange * RawExpr * RawExpr
    | RawIfThenElse of VSCRange * RawExpr * RawExpr * RawExpr
    | RawIfThen of VSCRange * RawExpr * RawExpr
    | RawPair of VSCRange * RawExpr * RawExpr
    | RawSeq of VSCRange * RawExpr * RawExpr
    | RawHeapMutableSet of VSCRange * RawExpr * RawExpr list * RawExpr
    | RawReal of VSCRange * RawExpr
    | RawMacro of VSCRange * RawMacro list
    | RawArray of VSCRange * RawExpr list
    | RawMissingBody of VSCRange
    | RawFilledForall of VSCRange * string * RawExpr // Filled in by the inferencer.
and RawTExpr =
    | RawTWildcard of VSCRange
    | RawTB of VSCRange
    | RawTMetaVar of VSCRange * VarString
    | RawTLit of VSCRange * Literal
    | RawTVar of VSCRange * VarString
    | RawTPair of VSCRange * RawTExpr * RawTExpr
    | RawTFun of VSCRange * RawTExpr * RawTExpr
    | RawTArray of VSCRange * RawTExpr
    | RawTRecord of VSCRange * Map<string,RawTExpr>
    | RawTSymbol of VSCRange * SymbolString
    | RawTApply of VSCRange * RawTExpr * RawTExpr
    | RawTForall of VSCRange * TypeVar * RawTExpr
    | RawTPrim of VSCRange * PrimitiveType
    | RawTTerm of VSCRange * RawExpr
    | RawTMacro of VSCRange * RawMacro list
    | RawTUnion of VSCRange * Map<string,RawTExpr> * UnionLayout
    | RawTLayout of VSCRange * RawTExpr * Layout
    | RawTFilledNominal of VSCRange * GlobalId // Filled in by the inferencer.

let (+.) (a,_) (_,b) = a,b
let range_of_hovar ((r,_) : HoVar) = r
let range_of_typevar ((x,_) : TypeVar) = range_of_hovar x
let typevar_name (((_,(name,_)),_) : TypeVar) = name
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
    | PatUnbox(r,_,_)
    | PatSymbol(r,_)
    | PatValue(r,_)
    | PatDefaultValue(r,_)
    | PatRecordMembers(r,_)
    | PatArray(r,_)
    | PatAnnot(r,_,_)
    | PatPair(r,_,_)
    | PatOr(r,_,_)
    | PatAnd(r,_,_)
    | PatWhen(r,_,_)
    | PatFilledDefaultValue(r,_,_)
    | PatNominal(r,_,_,_) -> r
let range_of_pat_record_member = function
    | PatRecordMembersSymbol((r,_),x)
    | PatRecordMembersInjectVar((r,_),x) -> r +. range_of_pattern x
let range_of_expr = function
    | RawB r
    | RawMissingBody r
    | RawMacro(r,_)
    | RawV(r,_)
    | RawLit(r,_)
    | RawDefaultLit(r,_)
    | RawSymbol(r,_)
    | RawType(r,_)
    | RawJoinPoint(r,_,_,_)
    | RawArray(r,_)
    | RawMatch(r,_,_)
    | RawFun(r,_)
    | RawReal(r,_)
    | RawRecBlock(r,_,_)
    | RawOp(r,_,_)
    | RawAnnot(r,_,_)
    | RawTypecase(r,_,_)
    | RawForall(r,_,_)
    | RawFilledForall(r,_,_)
    | RawApply(r,_,_)
    | RawPair(r,_,_)
    | RawIfThen(r,_,_)
    | RawSeq(r,_,_)
    | RawHeapMutableSet(r,_,_,_)
    | RawRecordWith(r,_,_,_)
    | RawIfThenElse(r,_,_,_)
    | RawOpen(r,_,_,_) -> r
    
let range_of_texpr = function
    | RawTWildcard r
    | RawTB r
    | RawTLit(r,_)
    | RawTMacro(r,_)
    | RawTMetaVar(r,_)
    | RawTVar(r,_)
    | RawTArray(r,_)
    | RawTRecord(r,_)
    | RawTUnion(r,_,_)
    | RawTSymbol(r,_)
    | RawTPrim(r,_)
    | RawTTerm(r,_)
    | RawTFilledNominal(r,_)
    | RawTPair(r,_,_)
    | RawTFun(r,_,_)
    | RawTApply(r,_,_)
    | RawTLayout(r,_,_)
    | RawTForall(r,_,_) -> r

type VectorCord = {|row : int; col : int|}
type Env = {
    semantic_updates : (VectorCord * SemanticTokenLegend) ResizeArray
    tokens_cords : VectorCord []
    tokens : (VSCRange * SpiralToken) []
    comments : LineComment option []
    i : int ref
    is_top_down : bool
    } with

    member d.Index with get() = d.i.contents and set(i) = d.i := i

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

let skip_string_open d =
    try_current d <| function
        | p,TokStringOpen -> skip d; Ok(p)
        | p, _ -> Error [p, ExpectedStringOpen]

let skip_string_close d =
    try_current d <| function
        | p,TokStringClose -> skip d; Ok(p)
        | p, _ -> Error [p, ExpectedStringClose]

let skip_macro_open d =
    try_current d <| function
        | p,TokMacroOpen -> skip d; Ok(p)
        | p, _ -> Error [p, ExpectedMacroOpen]

let skip_macro_close d =
    try_current d <| function
        | p,TokMacroClose -> skip d; Ok(p)
        | p, _ -> Error [p, ExpectedMacroClose]

let read_text d =
    let (+.) a b =
        match a with
        | Some a -> Some (a +. b)
        | None -> Some b
    let rec loop (a : VSCRange option) (str : Text.StringBuilder) =
        try_current d <| function
            | b,TokText x -> skip d; loop (a +. b) (str.Append(x))
            | b,(TokEscapedChar x | TokUnescapedChar x) -> skip d; loop (a +. b) (str.Append(x))
            | b, _ -> 
                if Option.isNone a then Error [b, ExpectedText; b, ExpectedEscapedChar; b, ExpectedUnescapedChar]
                else Ok(Option.get a, str.ToString())
    loop None (Text.StringBuilder())

let read_macro_var d =
    try_current d <| function
        | p, TokMacroTermVar x -> skip d; Ok(RawMacroTermVar(p,RawV(p,x)))
        | p, TokMacroTypeVar x -> skip d; Ok(RawMacroTypeVar(p,RawTVar(p,x)))
        | p, TokMacroTypeLitVar x -> skip d; Ok(RawMacroTypeLitVar(p,RawTVar(p,x)))
        | p,_ -> Error [p, ExpectedMacroVar]

let read_macro_type_var d =
    try_current d <| function
        | p, TokMacroTypeVar x -> skip d; Ok(RawMacroTypeVar(p,RawTVar(p,x)))
        | p, TokMacroTypeLitVar x -> skip d; Ok(RawMacroTypeLitVar(p,RawTVar(p,x)))
        | p,_ -> Error [p, ExpectedMacroTypeVar]

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
        | p, TokUnaryOperator(t',_) -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_unary_op' d =
    try_current d <| function
        | p, TokUnaryOperator(t',_) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedUnaryOperator']

let read_op d =
    try_current d <| function
        | p, TokOperator(t',_) -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedOperator']

let read_op' d =
    try_current d <| function
        | p, TokOperator(t',_) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedOperator']

let update_semantic (d : Env) = let i = d.Index in fun x -> d.semantic_updates.Add(d.tokens_cords.[i], x)
let read_op_type d =
    try_current d <| function
        | p, TokOperator(t',r) -> update_semantic d SemanticTokenLegend.type_variable; skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedOperator']

let skip_op t d =
    try_current d <| function
        | p, TokOperator(t',_) when t' = t -> skip d; Ok p
        | p, _ -> Error [p, ExpectedOperator t]

let skip_unary_op t d =
    try_current d <| function
        | p, TokUnaryOperator(t',_) when t' = t -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedUnaryOperator t]

let read_var d =
    try_current d <| function
        | p, TokVar(t',_) -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedVar]

let read_var' d =
    try_current d <| function
        | p, TokVar(t',_) -> let r = update_semantic d in skip d; Ok(p,t',r)
        | p, _ -> Error [p, ExpectedVar]

let read_var'' d =
    try_current d <| function
        | p, TokVar(t',_) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedVar]

let read_big_var d =
    try_current d <| function
        | p, TokVar(t',_) when Char.IsUpper(t',0) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedBigVar]

let read_var_as_symbol d =
    try_current d <| function
        | p, TokVar(t',_) -> update_semantic d SemanticTokenLegend.symbol; skip d; Ok t'
        | p, _ -> Error [p, ExpectedVar]

let read_big_var_as_symbol d =
    try_current d <| function
        | p, TokVar(t',_) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.symbol; skip d; Ok t'
        | p, _ -> Error [p, ExpectedBigVar]

let read_big_var_as_keyword d =
    try_current d <| function
        | p, TokVar(t',_) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.keyword; skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedBigVar]

let read_small_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> skip d; Ok t'
        | p, _ -> Error [p, ExpectedSmallVar]

let read_small_var' d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_big_type_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.type_variable; skip d; Ok(t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_big_type_var' d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) -> update_semantic d SemanticTokenLegend.type_variable; skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_small_type_var d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> update_semantic d SemanticTokenLegend.type_variable; skip d; Ok(t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_small_type_var' d =
    try_current d <| function
        | p, TokVar(t',r) when Char.IsUpper(t',0) = false -> update_semantic d SemanticTokenLegend.type_variable; skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSmallVar]

let read_value d =
    try_current d <| function
        | p, TokValue t' -> 
            skip d
            if d.Index < d.tokens.Length then 
                match snd d.tokens.[d.Index] with 
                | TokValueSuffix -> skip d 
                | _ -> ()
            Ok(p,t')
        | p, _ -> Error [p, ExpectedLit]

let read_symbol d =
    try_current d <| function
        | p, TokSymbol(t',r) -> skip d; Ok(p,t')
        | p, _ -> Error [p, ExpectedSymbol]

let skip_parenthesis a b d =
    try_current d <| function
        | p, TokParenthesis(a',b') when a = a' && b = b' -> skip d; Ok()
        | p, _ -> Error [p, ExpectedParenthesis(a,b)]

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
        if i < i' then fst s.tokens.[i] +. fst s.tokens.[i'-1], x : VSCRange * _
        else
            failwith "Compiler error: The parser passed into `range` has to consume at least one token for it to work."
        )

let rec kind d = (sepBy1 ((skip_op "*" >>% RawKindStar) <|> rounds kind) (skip_op "->") |>> List.reduceBack (fun a b -> RawKindFun (a,b))) d

let duplicates er x = 
    let h = Collections.Generic.HashSet()
    x |> List.choose (fun (r : VSCRange,n : string) -> if h.Add n = false then Some(r,er) else None)

let inline indent i op next d = if op i (col d) then next d else Error []

let record_var d = (read_var_as_symbol <|> rounds read_op) d

let patterns_validate pats = 
    let pos = Collections.Generic.Dictionary(HashIdentity.Reference)
    let errors = ResizeArray()
    let rec loop pat =
        match pat with
        | PatFilledDefaultValue _ | PatDefaultValue _ | PatValue _ | PatSymbol _ | PatE _ | PatB _ -> Set.empty
        | PatArray(_,x) -> 
            List.fold (fun s x -> 
                let x = loop x
                let inters = Set.intersect s x
                if Set.isEmpty inters = false then inters |> Set.iter (fun x -> errors.Add(pos.[x], InvalidPattern DuplicateVar))
                s + x
                ) Set.empty x
        | PatVar(r,x) -> 
            pos.Add(x,r)
            Set.singleton x
        | PatDyn(_,p) | PatAnnot (_,p,_) | PatNominal(_,_,_,p) | PatUnbox(_,_,p) | PatWhen(_,p,_) -> loop p
        | PatRecordMembers(_,items) ->
            let symbols = Collections.Generic.HashSet()
            let injects = Collections.Generic.HashSet()
            let vars = Collections.Generic.HashSet()
            List.iter (fun item ->
                match item with
                | PatRecordMembersSymbol((r,keyword),name) ->
                    if symbols.Add(keyword) = false then errors.Add (r, InvalidPattern DuplicateRecordSymbol); Set.empty else loop name
                | PatRecordMembersInjectVar((r,var),name) ->
                    if injects.Add(var) = false then errors.Add (r, InvalidPattern DuplicateRecordInjection); Set.empty else loop name
                |> Set.iter (fun x -> if vars.Add x = false then errors.Add (pos.[x], InvalidPattern DuplicateVar))
                ) items
            Set vars
        | PatPair(_,a,b) | PatAnd(_,a,b) -> 
            let a, b = loop a, loop b
            Set.intersect b a |> Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DuplicateVar))
            a + b
        | PatOr(_,a,b) -> 
            let a, b = loop a, loop b
            let f = Set.iter (fun x -> errors.Add (pos.[x], InvalidPattern DisjointOrPatternVar))
            f (a-b); f (b-a)
            a
    
    List.fold (fun s x ->
        let s' = loop x
        Set.intersect s' s |> Set.iter (fun x -> errors.Add(pos.[x],InvalidPattern ShadowedVar))
        s + s'
        ) Set.empty pats |> ignore
    errors |> Seq.toList

let join_point name = function // Has the effect of removing nested join points due to not duplicating them.
    | RawJoinPoint(a,b,c,_) -> RawJoinPoint(a,b,c,name)
    | x -> RawJoinPoint(range_of_expr x, None, x, name)
let join_point_backend (a,b) = RawJoinPoint(range_of_expr b, Some a, b, None)

/// Some places need unique string refs, so this is to keep the compiler from interning static strings.
let unintern a b = sprintf "%s%c" a b

let rec let_join_point name = function
    | RawForall(r,a,b) -> RawForall(r,a,let_join_point name b)
    | RawFun(r,[a,b]) -> RawFun(r,[PatDyn(range_of_pattern a, a), let_join_point name b])
    | RawFun(r,l) -> 
        let empty = fst r, fst r
        let n = unintern " ar" 'g'
        let a = PatDyn(empty,PatVar(empty,n))
        let b = RawMatch(empty,RawV(empty,n),List.map (fun (a,b) -> PatDyn(range_of_pattern a, a),b) l)
        RawFun(r,[a,join_point name b])
    | x -> join_point name x

let let_join_point' name = function
    | RawForall _ | RawFun _ as x -> let_join_point name x
    | x -> x

let inl_or_let_process (r, (is_let, is_rec, name, foralls, pats, body)) _ =
    match is_rec, name, foralls, pats with
    | false, _, [], [] -> 
        match patterns_validate [name] with
        | [] -> Ok((r,name,(if is_let then let_join_point' (match name with PatVar(_,name) -> Some name | _ -> None) body else body)),is_rec)
        | ers -> Error ers
    | _, PatVar(_,name'), _, _ -> 
        match patterns_validate (if is_rec then name :: pats else pats) with
        | [] -> 
            let body = 
                let dyn_if_let x = if is_let then PatDyn(range_of_pattern x, x) else x
                (if is_let then let_join_point (Some name') body else body)
                |> List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[dyn_if_let pat,body])) pats
                |> List.foldBack (fun typevar body -> RawForall(range_of_typevar typevar +. range_of_expr body,typevar,body)) foralls
            match is_rec, body with
            | false, _ | true, (RawFun _ | RawForall _) -> Ok((r,name,body),is_rec)
            | true, _ -> Error [r, ExpectedFunctionAsBodyOfRecStatement]
        | ers -> Error ers
    | true, _, _, _ -> Error [range_of_pattern name, ExpectedVarOrOpAsNameOfRecStatement]
    | false, _, _, _ -> Error [range_of_pattern name, ExpectedSinglePatternWhenStatementNameIsNorVarOrOp]

let ho_var d : Result<HoVar,_> = range ((read_small_type_var |>> fun x -> x, RawKindWildcard) <|> rounds ((read_small_type_var .>> skip_op ":") .>>. kind)) d
let forall_var d : Result<TypeVar,_> = (ho_var .>>. (curlies (sepBy (read_small_type_var' <|> rounds read_op_type) (skip_op ";")) <|>% [])) d
let forall d = 
    (skip_keyword SpecForall >>. many1 forall_var .>> skip_op "." 
    >>= fun q _ -> 
        let x' = q |> List.collect (fun (_,l) -> duplicates DuplicateConstraint l)
        let x = q |> List.map (fun ((r,(a,_)),_) -> r,a) |> duplicates DuplicateForallVar
        match List.append x x' with [] -> Ok q | er -> Error er
        ) d

let inline annotated_body sep exp ty =
    pipe2 (opt (skip_op ":" >>. ty))
        (skip_op sep .>>. opt exp)
        (fun a (r,b) ->
            let b = match b with Some b -> b | None -> RawMissingBody r
            match a with
            | Some a -> RawAnnot(range_of_expr b +. range_of_texpr a,b,a)
            | None -> b)

let inline inl_or_let exp pattern ty =
    range (tuple6 ((skip_keyword SpecInl >>% false) <|> (skip_keyword SpecLet >>% true))
            ((skip_keyword SpecRec >>% true) <|>% false) pattern
            (forall <|>% []) (many pattern) (annotated_body "=" exp ty))
    >>= inl_or_let_process

let inline and_inl_or_let exp pattern ty =
    range (tuple6 (skip_keyword SpecAnd >>. ((skip_keyword SpecInl >>% false) <|> (skip_keyword SpecLet >>% true)))
            (fun _ -> Ok true) pattern
            (forall <|>% []) (many pattern) (annotated_body "=" exp ty))
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
    | "<-" -> ValueSome(4, Associativity.Left)
    
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
    | "." -> ValueSome(2, Associativity.Right)
    | "," -> ValueSome(6, Associativity.Right)
    | ":>" -> ValueSome(35, Associativity.Right)
    | ":?>" -> ValueSome(35, Associativity.Right)
    | "**" -> ValueSome(80, Associativity.Right)
    | _ -> ValueNone

// The `.` operator has special behavior similar to F#.
let rec precedence_associativity name = 
    if 0 < String.length name then
        if 1 < String.length name && name.[0] = '.' then precedence_associativity name.[1..]
        else
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
                let inline f on_succ = Ok(p,a,fun (a,b) -> 
                    let ra, rb = range_of_expr a, range_of_expr b
                    let r = ra +. rb
                    on_succ(r,a,b)
                    )
                match x with
                | "." -> f RawSeq
                | "&&" -> f (fun (r,a,b) -> RawIfThenElse(r,a,b,RawLit(o,LitBool false)))
                | "||" -> f (fun (r,a,b) -> RawIfThenElse(r,a,RawLit(o,LitBool true),b))
                | "," -> f RawPair
                | "<-" -> f (fun (r,a,c) ->
                    let rec loop l = function
                        | RawApply(_,a,b) -> loop (b :: l) a
                        | a -> a, l
                    let a,b = loop [] a
                    RawHeapMutableSet(r,a,b,c)
                    )
                | x -> f (fun (r,a,b) -> RawApply(r,RawApply(r +. o,RawV(o,x),a),b))
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

let inline pat_pair next = 
    sepBy1 next (skip_op ",") 
    |>> List.reduceBack (fun a b -> PatPair(range_of_pattern a +. range_of_pattern b,a,b))

type RootTypeFlags = {
    allow_typecase_metavars : bool
    allow_term : bool
    allow_wildcard : bool
    }

let root_type_defaults = {
    allow_typecase_metavars = false
    allow_term = false
    allow_wildcard = false
    }

let default_float = Float64T
let default_int = Int32T
let bottom_up_number (r : VSCRange,x : string) =
    let inline f string_to_val val_to_lit val_dsc =
        match string_to_val x with
        | true, x -> Ok(r, val_to_lit x)
        | false, _ -> Error [r, BottomUpNumberParseError(x,val_dsc)]
    if x.Contains '.' then
        match default_float with
        | Float32T -> f Single.TryParse LitFloat32 "f32"
        | Float64T -> f Double.TryParse LitFloat64 "f64"
        | x -> failwithf "Compiler error: Invalid default float type. Got: %A" x
    else
        match default_int with
        | Int8T -> f SByte.TryParse LitInt8 "i8"
        | Int16T -> f Int16.TryParse LitInt16 "i16"
        | Int32T -> f Int32.TryParse LitInt32 "i32"
        | Int64T -> f Int64.TryParse LitInt64 "i64"
        | UInt8T -> f Byte.TryParse LitUInt8 "u8"
        | UInt16T -> f UInt16.TryParse LitUInt16 "u16"
        | UInt32T -> f UInt32.TryParse LitUInt32 "u32"
        | UInt64T -> f UInt64.TryParse LitUInt64 "u64"
        | x -> failwithf "Compiler error: Invalid default int type. Got: %A" x

let typecase_validate x _ =
    let metavars = Collections.Generic.HashSet()    
    let vars = Collections.Generic.HashSet()
    let errors = ResizeArray()
    let rec f = function
        | RawTFilledNominal _ | RawTTerm _ | RawTForall _ -> failwith "Compiler error: This case is not supposed to appear in typecase."
        | RawTLit _ | RawTPrim _ | RawTSymbol _ | RawTB _ | RawTWildcard _ -> ()
        | RawTMetaVar(r,a) -> if vars.Contains(a) then errors.Add(r,MetavarShadowedByVar) else metavars.Add(a) |> ignore
        | RawTVar(r,a) -> if metavars.Contains(a) then errors.Add(r,VarShadowedByMetavar) else vars.Add(a) |> ignore
        | RawTApply(_,a,b) | RawTFun(_,a,b) | RawTPair(_,a,b) -> f a; f b
        | RawTLayout(_,a,_) | RawTArray(_,a) -> f a
        | RawTUnion(_,a,_) | RawTRecord(_,a) -> Map.iter (fun _ -> f) a
        | RawTMacro(_,a) -> a |> List.iter (function RawMacroTypeVar(_,a) -> f a | _ -> ())
    f x
    if 0 < errors.Count then Error (Seq.toList errors) else Ok(x)

// Parses an expression only if it is directly next to the previous one.
let inline expr_tight next (d: Env) = 
    let i = index d
    if 0 < i && i < d.tokens.Length then
        let r,r' = snd (fst d.tokens.[i-1]), fst (fst d.tokens.[i])
        if r.line = r'.line && r.character = r'.character then next d else Error []
    else Error []

let inline read_default_value on_top on_bot d =
    try_current d <| function
        | p, TokDefaultValue t' -> 
            skip d
            if d.is_top_down then Ok(on_top (p,t'))
            else bottom_up_number (p,t') |> Result.map on_bot
        | p, _ -> Error [p, ExpectedLit]
let read_string = tuple3 skip_string_open ((read_text |>> snd) <|>% "") skip_string_close
let pat_var d = (read_small_var' |>> PatVar) d
let rec root_pattern_var_nominal_union s =
    (read_var' >>= fun (r,a,re) s ->
        if Char.IsUpper(a,0) then
            (opt root_pattern_var |>> fun b ->
                re SemanticTokenLegend.symbol
                let b = match b with Some b -> b | None -> PatE r
                PatUnbox(r,a,b)
                ) s
        else 
            (many (expr_tight read_symbol) >>= fun syms s ->
                match syms with
                | [] ->
                    (opt root_pattern_var |>> fun b ->
                        match b with
                        | Some b ->
                            re SemanticTokenLegend.type_variable
                            PatNominal(r +. range_of_pattern b,(r,a),syms,b)
                        | None ->
                            PatVar(r,a)
                        ) s
                | _ ->
                    (root_pattern_var |>> fun b ->
                        re SemanticTokenLegend.type_variable
                        PatNominal(r +. range_of_pattern b,(r,a),syms,b)
                        ) s
                ) s
        ) s
and root_pattern_wildcard d = (skip_keyword' SpecWildcard |>> PatE) d
and root_pattern_dyn d = (range (skip_unary_op "~" >>. root_pattern_var) |>> PatDyn) d
and root_pattern_record d = 
    let pat_record_item =
        let inj = skip_unary_op "$" >>. read_small_var' |>> fun a -> PatRecordMembersInjectVar,a
        let var = range record_var |>> fun a -> PatRecordMembersSymbol,a
        ((inj <|> var) .>>. (opt (skip_op "=" >>. root_pattern_pair)))
        |>> fun ((f,a),b) -> f (a, defaultArg b (PatVar a))
    (range (curlies (many pat_record_item)) |>> PatRecordMembers) d
and root_pattern_type s = 
    pipe2 root_pattern (opt (skip_op ":" >>. root_type_annot))
        (fun a -> function Some b -> PatAnnot(range_of_pattern a +. range_of_texpr b,a,b) | None -> a) s
and root_pattern_rounds d = 
    (range (rounds ((((read_op' |>> PatVar) <|> root_pattern_type) |>> fun x _ -> x) <|>% PatB))
    |>> fun (r,x) -> x r) d
and root_pattern s =
    let pat_list_pair r a b = PatUnbox(r,"Cons",PatPair(r,a,b))
    let body s = 
        let pat_value = (read_value |>> PatValue) <|> (read_default_value PatDefaultValue PatValue)
        let pat_string = read_string |>> (fun (a,x,b) -> PatValue(a +. b,LitString x))
        let pat_symbol = read_symbol |>> PatSymbol
        let pat_array = skip_unary_op ";" >>. range (squares (sepBy root_pattern_type (skip_op ";"))) |>> fun (r,x) -> PatArray(r,x)
        let pat_list = 
            range (squares (sepBy root_pattern_type (skip_op ";")))
            |>> fun ((r,_),x) -> let r = r,r in List.foldBack (pat_list_pair r) x (PatUnbox(r,"Nil",PatB r))
        let (+) = alt (index s)
        (root_pattern_rounds + root_pattern_var_nominal_union + root_pattern_wildcard + root_pattern_dyn + pat_value + pat_string 
        + root_pattern_record + pat_symbol + pat_array + pat_list) s

    let pat_and = sepBy1 body (skip_op "&") |>> List.reduce (fun a b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b))
    let pat_pair = pat_pair pat_and
    let pat_cons = range (sepBy1 pat_pair (skip_op "::")) |>> fun (r,x) -> List.reduceBack (pat_list_pair r) x
    let pat_or = sepBy1 pat_cons (skip_op "|") |>> List.reduce (fun a b -> PatOr(range_of_pattern a +. range_of_pattern b,a,b))
    let pat_as = pat_or .>>. (opt (skip_keyword SpecAs >>. pat_or )) |>> function a, Some b -> PatAnd(range_of_pattern a +. range_of_pattern b,a,b) | a, None -> a
    pat_as s
and root_pattern_when d = (root_pattern .>>. (opt (skip_keyword SpecWhen >>. root_term)) |>> function a, Some b -> PatWhen(range_of_pattern a +. range_of_expr b,a,b) | a, None -> a) d
and root_pattern_var d = 
    let (+) = alt (index d)
    (pat_var + root_pattern_wildcard + root_pattern_dyn + root_pattern_rounds + root_pattern_record) d
and root_pattern_pair d = pat_pair root_pattern_var d
and root_type_annot d = root_type {root_type_defaults with allow_term=d.is_top_down=false; allow_wildcard=d.is_top_down} d
and root_type_record (flags : RootTypeFlags) d =
    (range (curlies (sepBy ((range record_var .>> skip_op ":") .>>. root_type flags) (optional (skip_op ";"))))
    >>= fun (r,x) _ ->
        x |> List.map fst |> duplicates DuplicateRecordTypeVar
        |> function [] -> Ok(RawTRecord(r,x |> List.map (fun ((_,n),x) -> n,x) |> Map.ofList)) | er -> Error er
        ) d
and root_type_union (flags : RootTypeFlags) d =
    let bar = bar (col d)
    (range (optional bar >>. sepBy1 (range read_big_var_as_symbol .>>. opt (skip_op ":" >>. root_type flags)) bar)
    >>= fun (r,x) _ ->
        x |> List.map fst |> duplicates DuplicateUnionKey
        |> function 
            | [] -> Ok(r,x |> List.map (fun ((r,n),x) -> n, match x with Some x -> x | None -> RawTB r) |> Map.ofList)
            | er -> Error er
        ) d
and root_type (flags : RootTypeFlags) d =
    let next = root_type flags
    let cases d =
        let wildcard d = if flags.allow_wildcard then (skip_keyword' SpecWildcard |>> RawTWildcard) d else Error []
        // This metavar case only occurs in typecase during the bottom-up segment. It should not be confused with metavars during top-down type inference.
        let metavar d = if flags.allow_typecase_metavars then (skip_unary_op "~" >>. read_var' |>> fun (a,b,r) -> r SemanticTokenLegend.type_variable; RawTMetaVar(a,b)) d else Error []
        let term d = if flags.allow_term then (range (skip_unary_op "`" >>. ((read_var'' |>> RawV) <|> rounds root_term)) |>> RawTTerm) {d with is_top_down=false} else Error []
        let symbol = read_symbol |>> RawTSymbol
        let record = root_type_record flags
        let lit = (read_value |>> RawTLit) <|> (read_string |>> fun (a,b,c) -> RawTLit(a +. c, LitString b))
        let var = read_var' |>> fun (o,x,r) ->
            r SemanticTokenLegend.type_variable
            RawTVar(o, x)
        let rounds =
            range (rounds ((next |>> fun x _ -> x) <|>% RawTB))
            |>> fun (r,x) -> x r
        let macro = pipe3 skip_macro_open (many ((read_text |>> RawMacroText) <|> read_macro_type_var)) skip_macro_close (fun a l b -> RawTMacro(a +. b, l))
        let (+) = alt (index d)
        (rounds + lit + wildcard + term + metavar + var + record + symbol + macro) d

    let fold_applies a b = List.fold (fun a b -> RawTApply(range_of_texpr a +. range_of_texpr b,a,b)) a b
    let apply_tight d = pipe2 cases (many (expr_tight cases)) fold_applies d
    let apply d = pipe2 apply_tight (many (indent (col d) (<) apply_tight)) fold_applies d
    
    let pairs = sepBy1 apply (skip_op "*") |>> List.reduceBack (fun a b -> RawTPair(range_of_texpr a +. range_of_texpr b,a,b))
    let functions = sepBy1 pairs (skip_op "->") |>> List.reduceBack (fun a b -> RawTFun(range_of_texpr a +. range_of_texpr b,a,b))
    functions d

and root_term d =
    let rec expressions d =
        let next = root_term
        let case_var = read_var'' |>> RawV
        let case_value = read_value |>> RawLit
        let case_rounds = 
            range (rounds ((((read_op' |>> RawV) <|> next) |>> fun x _ -> x) <|>% RawB))
            |>> fun (r,x) -> x r
        let case_fun =
            (skip_keyword SpecFun >>. many1 root_pattern_pair .>>. (annotated_body "=>" next root_type_annot))
            >>= fun (pats, body) _ ->
                match patterns_validate pats with
                | [] -> List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body |> Ok
                | ers -> Error ers
            
        let case_forall d =
            if d.is_top_down then Error [] else
                (tuple3 forall (many root_pattern_pair) (annotated_body "=>" next root_type_annot)
                >>= fun (foralls : TypeVar list, pats, body) _ ->
                    match patterns_validate pats with
                    | [] -> 
                        List.foldBack (fun pat body -> RawFun(range_of_pattern pat +. range_of_expr body,[pat,body])) pats body
                        |> List.foldBack (fun a body -> RawForall(range_of_typevar a +. range_of_expr body,a,body)) foralls |> Ok
                    | ers -> Error ers) d

        let case_default_value = read_default_value RawDefaultLit RawLit
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
                (optional bar >>. sepBy1 (root_pattern_when .>>. (skip_op "=>" >>. next)) bar
                >>= fun l _ ->
                    match l |> List.collect (fun (a,_) -> patterns_validate [a]) with
                    | [] -> Ok l
                    | e -> Error e
                    ) d

            (range (skip_keyword SpecFunction >>. clauses) |>> RawFun)
            <|> (range ((skip_keyword SpecMatch >>. next .>> skip_keyword SpecWith) .>>. clauses) |>> fun (a,(b,c)) -> RawMatch(a,b,c))

        let case_typecase d =
            let clauses d = 
                let bar = bar (col d)
                let typecase = root_type {root_type_defaults with allow_typecase_metavars=true; allow_wildcard=true} >>= typecase_validate
                (optional bar >>. sepBy1 (typecase .>>. (skip_op "=>" >>. next)) bar) d

            if d.is_top_down then Error [] else
                (range ((skip_keyword SpecTypecase >>. root_type {root_type_defaults with allow_term=true} .>> skip_keyword SpecWith) .>>. clauses)
                |>> fun (r, (a, b)) -> RawTypecase(r,a,b)) d

        let case_record =
            let create = skip_op "=" >>. next
            let modify = skip_op "#=" >>. next
            let var = range record_var
            let inject = skip_unary_op "$" >>. range read_small_var
            let record_create_body =
                (var .>>. opt create |>> function (a,Some b) -> RawRecordWithSymbol(a,b) | (a,None) -> RawRecordWithSymbol(a,RawV(a)))
                <|> (inject .>>. create |>> RawRecordWithInjectVar)
            let record_create = range (curlies (sepBy record_create_body (optional (skip_op ";")))) |>> fun (r,withs) -> (r,[],withs,[])
            let record_with_bodies =
                (var >>= fun a ->
                    ((modify |>> fun b -> RawRecordWithSymbolModify(a,b))
                    <|> (opt create |>> function Some b -> RawRecordWithSymbol(a,b) | None -> RawRecordWithSymbol(a,RawV(a)))))
                <|> (inject >>= fun a ->
                    ((modify |>> fun b -> RawRecordWithInjectVarModify(a,b))
                    <|> (create |>> fun b -> RawRecordWithInjectVar(a,b))))
            let record_without_bodies = (var |>> RawRecordWithoutSymbol) <|> (inject |>> RawRecordWithoutInjectVar)
            let record_with =
                range
                    (curlies
                        (tuple4 read_small_var'
                            (many ((read_symbol |>> RawSymbol) <|> (skip_op "$" >>. read_small_var' |>> RawV)))
                            ((skip_keyword SpecWith >>. sepBy record_with_bodies (optional (skip_op ";"))) <|>% [])
                            ((skip_keyword SpecWithout >>. many record_without_bodies) <|>% [])))
                |>> fun (r,(name, acs, withs, withouts)) -> (r,RawV name :: acs,withs,withouts)

            restore 2 record_create <|> record_with
            >>= fun (_,_,withs,withouts as x) _ ->
                [
                withs |> List.choose (function RawRecordWithSymbol(a,_) | RawRecordWithSymbolModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordSymbol
                withs |> List.choose (function RawRecordWithInjectVar(a,_) | RawRecordWithInjectVarModify(a,_) -> Some a | _ -> None) |> duplicates DuplicateTermRecordInjection
                withouts |> List.choose (function RawRecordWithoutSymbol(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordSymbol
                withouts |> List.choose (function RawRecordWithoutInjectVar(a,b) -> Some(a,b) | _ -> None) |> duplicates DuplicateTermRecordInjection
                ] |> List.concat |> function [] -> Ok(RawRecordWith x) | er -> Error er

        let case_join_point = skip_keyword SpecJoin >>. next |>> join_point None
        let case_join_point_backend = skip_keyword SpecJoinBackend >>. (read_big_var_as_keyword .>>. next) |>> join_point_backend
        let case_real = skip_keyword SpecReal >>. (fun d -> next {d with is_top_down=false}) |>> fun x -> RawReal(range_of_expr x,x)
        let case_symbol = read_symbol |>> RawSymbol
        let case_list = range (squares sequence_body) >>= fun (r,l) d -> 
            if d.is_top_down then
                let r = fst r, fst r
                List.foldBack (fun a b -> 
                    RawApply(r,RawV(r,unintern "Con" 's'),RawPair(r,a,b))
                    ) l (RawV(r,unintern "Ni" 'l')) |> Ok
            else
                Error [r, ListLiteralsNotAllowedInBottomUp]

        let case_string = read_string |>> fun (a, x, b) -> RawLit(a +. b,LitString x)
        let case_macro = pipe3 skip_macro_open (many ((read_text |>> RawMacroText) <|> read_macro_var)) skip_macro_close (fun a l b -> RawMacro(a +. b, l))

        let (+) = alt (index d)

        (case_value + case_default_value + case_var + case_join_point + case_join_point_backend + case_real + case_symbol
        + case_typecase + case_match + case_typecase + case_rounds + case_list + case_record
        + case_if_then_else + case_fun + case_forall + case_string + case_macro) d

    and application_tight d =
        let next = expressions
        pipe2 next (many (expr_tight next)) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

    and sequence_body d = (many (indent (col d) (=) (sepBy1 operators (skip_op ";"))) |>> List.concat) d
    and unary_op d =
        let next = application_tight
        let f = 
            read_unary_op' >>= fun (o,a) d ->
                let type_expr d = 
                    choice [|
                        read_small_type_var' |>> RawTVar
                        read_value |>> RawTLit
                        read_string |>> fun (a,b,c) -> RawTLit(a +. c, LitString b)
                        rounds (root_type {root_type_defaults with allow_term=true})
                        |] d
                let term_expr d =
                    choice [|
                        read_var'' |>> RawV
                        read_value |>> RawLit
                        read_default_value RawDefaultLit RawLit
                        read_string |>> fun (a,b,c) -> RawLit(a +. c, LitString b)
                        rounds root_term
                        |] d
                match a with
                | ";" -> (range (squares sequence_body) |>> fun (r,x) -> RawArray(r,x)) d
                | "!!!!" -> 
                    (range (read_big_var .>>. (rounds (sepBy1 (fun d -> unary_op {d with is_top_down=false}) (skip_op ","))))
                    >>= fun (r,((ra,a), b)) _ ->
                        match string_to_op a with
                        | true, op' -> Ok(RawOp(r,op',b))
                        | false, _ -> Error [ra,InbuiltOpNotFound]) d
                | "`" -> if d.is_top_down then Error [] else (range type_expr |>> RawType) d
                | "`@" -> 
                    if d.is_top_down then Error [] else 
                        (range term_expr |>> fun (r,x) -> 
                            let r' = o +. r 
                            RawType(r', RawTTerm(r',RawOp(r',LitToTypeLit,[x])))
                            ) d
                | "``" -> if d.is_top_down then Error [] else (range type_expr |>> fun (r,x) -> RawOp(o +. r,TypeToVar,[RawType(r,x)])) d
                | _ -> (next |>> fun b -> RawApply(o +. range_of_expr b,RawV(o, "~" + a),b)) d
        (f <|> next) d

    and application (d: Env) =
        let next = unary_op
        pipe2 next (many (indent (col d) (<) next)) (List.fold (fun a b -> RawApply(range_of_expr a +. range_of_expr b,a,b))) d

    and operators d =
        let term = application
        let i = col d
        let op = indent i (<=) op

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
            (opt (indent i (<=) (skip_op ":" >>. root_type_annot)))
            (fun a -> function Some b -> RawAnnot(range_of_expr a +. range_of_texpr b,a,b) | _ -> a)
            d

    let statements d =
        let next = operators
        let inl_or_let =
            (inl_or_let root_term root_pattern_pair root_type_annot .>>. many (and_inl_or_let root_term root_pattern_pair root_type_annot))
            >>= fun x _ -> 
                match x with
                | ((r,name,body),false), [] -> Ok(fun on_succ -> RawMatch(r,body,[name,on_succ]))
                | ((_,_,_),false), l -> l |> List.map (fun ((r,_,_),_) -> r, UnexpectedAndInlRec) |> Error
                | x, xs ->
                    let l = x :: xs |> List.map (function 
                        | (r,PatVar(o,name),body),true -> r, ((o,name), body)
                        | _ -> failwith "Compiler error: Recursive inl/let statements should always have PatVar for names and should always be recursive."
                        )
                    let r = l |> List.map fst |> List.reduce (+.)
                    l |> List.map (snd >> fst) 
                    |> duplicates DuplicateRecFunctionName
                    |> function [] -> Ok(fun on_succ -> RawRecBlock(r, List.map snd l, on_succ)) | er -> Error er
        let module_open = module_open |>> fun (r,(name,acs)) on_succ -> RawOpen(r,name,acs,on_succ)
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

let comments (s : Env) = 
    let line_near_to = line s
    let rec loop line d =
        if 0 <= line then 
            match s.comments.[line] with
            | Some(r,text) -> 
                let text = text.TrimEnd()
                loop (line-1) ((if text = "" then "\n" else text + " ") :: d)
            | _ -> d
        else d
    loop (line_near_to-1) []
    |> String.concat ""
    |> fun x -> Ok(x.TrimEnd())

type Comments = string

type [<ReferenceEquality>] TopStatement =
    | TopAnd of VSCRange * TopStatement
    | TopInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
    | TopRecInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
    | TopNominal of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | TopNominalRec of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | TopType of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | TopPrototype of Comments * VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawTExpr
    | TopInstance of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawExpr
    | TopOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list

let top_inl_or_let_process comments is_top_down = function
    | (r,PatVar(r',name),(RawForall _ | RawFun _ as body)),false -> Ok(TopInl(comments,r,(r',name),body,is_top_down))
    | (r,PatVar(r',name),(RawForall _ | RawFun _ as body)),true -> Ok(TopRecInl(comments,r,(r',name),body,is_top_down))
    | (r,PatVar _,_),_ -> Error [r, ExpectedGlobalFunction]
    | (_,x,_),_ -> Error [range_of_pattern x, ExpectedVarOrOpAsNameOfGlobalStatement]
let top_inl_or_let d = ((comments .>>. inl_or_let root_term root_pattern_pair root_type_annot) >>= fun (comments,x) d -> top_inl_or_let_process comments d.is_top_down x) d

let process_union (r,(layout,n,a,(r',b))) _ =
    match layout with
    | UHeap -> Ok(TopNominalRec(r,n,a,RawTUnion(r',b,layout)))
    | UStack -> Ok(TopNominal(r,n,a,RawTUnion(r',b,layout)))

let union_clauses d = root_type_union root_type_defaults d
let top_union d = ((range (tuple4 (skip_keyword SpecUnion >>. ((skip_keyword SpecRec >>% UHeap) <|>% UStack)) read_small_type_var' (many ho_var .>> skip_op "=") union_clauses)) >>= process_union) d
let top_nominal d = 
    (range (tuple3 (skip_keyword SpecNominal >>. read_small_type_var') (many ho_var .>> skip_op "=") (root_type {root_type_defaults with allow_term=true}))
    |>> fun (r,(n,a,b)) -> TopNominal(r,n,a,b)) d

let inline type_forall next d = (pipe2 (forall <|>% []) next (List.foldBack (fun x s -> RawTForall(range_of_typevar x +. range_of_texpr s,x,s)))) d 
let top_prototype d = 
    (range 
        (tuple5 comments
            (skip_keyword SpecPrototype >>. (read_small_var' <|> rounds read_op')) read_small_type_var' (many forall_var) 
            (skip_op ":" >>. type_forall (root_type root_type_defaults)))
    |>> fun (r,(com,a,b,c,d)) -> TopPrototype(com,r,a,b,c,d)) d
let top_instance d =
    (range
        (tuple4 (skip_keyword SpecInstance >>. (read_small_var' <|> rounds read_op')) read_small_type_var' (many forall_var) (skip_op "=" >>. root_term))
    >>= fun (r,(prototype_name, nominal_name, nominal_foralls, body)) _ ->
            Ok(TopInstance(r,prototype_name,nominal_name,nominal_foralls,body))
            ) d
let top_type d = (range (tuple3 (skip_keyword SpecType >>. read_small_type_var') (many ho_var) (skip_op "=" >>. root_type root_type_defaults)) |>> fun (r,(a,b,c)) -> TopType(r,a,b,c)) d

let top_and_inl_or_let d = 
    (comments .>>. restore 1 (range (and_inl_or_let root_term root_pattern_pair root_type_annot)) 
    >>= fun (comments,(r,x)) d -> top_inl_or_let_process comments d.is_top_down x |> Result.map (fun x -> TopAnd(r,x))) d

let inline top_and f = restore 1 (range (skip_keyword SpecAnd >>. f)) |>> TopAnd
let top_and_union d = top_and ((range (tuple4 (skip_keyword SpecUnion >>% UHeap) read_small_type_var' (many ho_var .>> skip_op "=") union_clauses)) >>= process_union) d
let top_open d = (module_open |>> fun (r,(name,acs)) -> TopOpen(r,name,acs)) d

let top_statement s =
    let (+) = alt (index s)
    (top_inl_or_let + top_union + top_nominal + top_prototype + top_type + top_instance + top_and_inl_or_let + top_and_union + top_open) s

type ParserErrorsList = (VSCRange * ParserErrors) list
type ParseResult = Result<TopStatement,ParserErrorsList>
let parse (s : Env) : ParseResult =
    if 0 < s.tokens.Length then
        match top_statement s with
        | Ok _ as x -> if s.Index = s.tokens.Length then x else Error [fst s.tokens.[s.Index], ExpectedEob]
        | Error [] ->
            if s.Index = s.tokens.Length then Error [fst (Array.last s.tokens), UnexpectedEob]
            else Error [fst s.tokens.[s.Index], ExpectedEob]
        | Error _ as l -> l
    else
        Error []

let show_parser_error = function
    | MetavarShadowedByVar -> "The metavariable is shadowed by a variable."
    | VarShadowedByMetavar -> "The variable is shadowed by a metavariable."
    | ExpectedPairedSymbolInUnion -> "The union clause should be pair whose left side is a symbol."
    | ExpectedEscapedChar -> "escaped character"
    | ExpectedUnescapedChar -> "unescaped character"
    | ExpectedMacroVar -> "variable"
    | ExpectedMacroTypeVar -> "type variable"
    | ExpectedMacroTypeLitVar -> "type literal variable"
    | ExpectedText -> "text"
    | ExpectedMacroOpen -> "$\""
    | ExpectedStringOpen -> "\""
    | ExpectedMacroClose | ExpectedStringClose -> "\""
    | ExpectedKeyword x ->
        match x with
        | SpecIn -> "in"
        | SpecAnd -> "and"
        | SpecFun -> "fun"
        | SpecMatch -> "match"
        | SpecTypecase -> "typecase"
        | SpecFunction -> "function"
        | SpecWith -> "with"
        | SpecWithout -> "without"
        | SpecAs -> "as"
        | SpecWhen -> "when"
        | SpecInl -> "inl"
        | SpecLet -> "let"
        | SpecForall -> "forall"
        | SpecInm -> "inm"
        | SpecInb -> "inb"
        | SpecRec -> "rec"
        | SpecIf -> "if"
        | SpecThen -> "then"
        | SpecElif -> "elif"
        | SpecElse -> "else"
        | SpecJoin -> "join"
        | SpecJoinBackend -> "join_backend"
        | SpecType -> "type"
        | SpecNominal -> "nominal"
        | SpecReal -> "real"
        | SpecUnion -> "union"
        | SpecOpen -> "open"
        | SpecWildcard -> "_"
        | SpecInstance -> "instance"
        | SpecPrototype -> "prototype"
    | ExpectedParenthesis(Round,Open) -> "("
    | ExpectedParenthesis(Curly,Open) -> "{"
    | ExpectedParenthesis(Square,Open) -> "["
    | ExpectedParenthesis(Round,Close) -> ")"
    | ExpectedParenthesis(Curly,Close) -> "}"
    | ExpectedParenthesis(Square,Close) -> "]"
    | ExpectedOpenParenthesis -> "(, { or ["
    | ExpectedOperator' -> "operator"
    | ExpectedOperator x -> x
    | ExpectedUnaryOperator' -> "unary operator"
    | ExpectedUnaryOperator x -> x
    | ExpectedUnit -> "()"
    | ExpectedSmallVar -> "lowercase variable"
    | ExpectedBigVar -> "uppercase variable"
    | ExpectedVar -> "variable"
    | ExpectedLit -> "literal"
    | ExpectedSymbol -> "symbol"
    | ExpectedSymbolPaired -> "paired symbol"
    | ExpectedStatement -> "statement"
    | ExpectedFunctionAsBodyOfRecStatement -> "Rec statements should all return functions known at parse time."
    | ExpectedGlobalFunction -> "Global inl/let statements should all return functions known at parse time."
    | ExpectedSinglePatternWhenStatementNameIsNorVarOrOp -> "Unexpected pattern."
    | ExpectedVarOrOpAsNameOfGlobalStatement -> "The first pattern of a global statement should either be a variable or compile down to it."
    | ExpectedVarOrOpAsNameOfRecStatement -> "The first pattern of a recursive statement should either be a variable or compile down to it."
    | ExpectedExpression -> "A sequence of statements should end in an expression."
    | InbuiltOpNotFound -> "Not found among the inbuilt operations."
    | UnknownOperator -> "Operator does not have known precedence and associativity."
    | ForallNotAllowed -> "Forall not allowed here."
    | InvalidPattern DisjointOrPatternVar -> "Both branches of an or pattern need to have the same variables. This one is disjoint."
    | InvalidPattern DuplicateVar -> "Duplicate pattern variable."
    | InvalidPattern ShadowedVar -> "Shadowed pattern variable."
    | MetavarNotAllowed -> "Metavariable is not allowed here."
    | SymbolPairedShouldStartWithUppercaseInTypeScope -> "Paired symbol should start with uppercase in type scope."
    | TermNotAllowed -> "The term is not allowed here."
    | TypecaseNotAllowed -> "Typecase is not allowed here."
    | UnexpectedAndInlRec -> "The first statement of a recursive block has to be marked as recursive."
    | ExpectedEob -> "Failed to parse this token."
    | UnexpectedEob -> "Unexpected end of block past this token."
    | UnknownError -> "Compiler error: Parsing failed at this position with no error message and without consuming all the tokens in a block."
    | DuplicateRecordTypeVar -> "Duplicate record type variable."
    | DuplicateForallVar -> "Duplicate forall variable."
    | DuplicateConstraint -> "Duplicate constraint."
    | InvalidPattern DuplicateRecordSymbol
    | DuplicateTermRecordSymbol -> "Duplicate record symbol."
    | InvalidPattern DuplicateRecordInjection
    | DuplicateTermRecordInjection -> "Duplicate record injection."
    | DuplicateRecFunctionName -> "Shadowing of functions by the members of the same mutually recursive block is not allowed."
    | BottomUpNumberParseError (x, val_dsc) -> sprintf "The string %s cannot be safely parsed as %s." x val_dsc
    | DuplicateUnionKey -> "Duplicate union keys are not allowed."
    | ListLiteralsNotAllowedInBottomUp -> "List literals are not allowed in the bottom-up segment."