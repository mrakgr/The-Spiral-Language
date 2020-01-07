module Spiral.Parsing
open Spiral.Tokenize
open Spiral.ParserCombinators
open System
open System.Text

type Associativity = FParsec.Associativity

type VarString = string * PosKey
type KeywordString = string

type Pos<'a>(pos : PosKey, expr : 'a) =
    member _.Expression = expr
    member _.Pos = pos
    override _.ToString() = sprintf "%A" expr

type Op =
    // Type
    | TypeExpr

    // Unsafe casts
    | UnsafeConvert

    // StringOps
    | StringLength
    | StringIndex
    | StringSlice
    | StringFormat
    | StringConcat

    // Pair
    | PairCreate

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

    // Join points
    | JoinPointEntryMethod
    | JoinPointAnnotEntryMethod
    
    // Application related
    | Apply
    | TermCast // Term cast also places the closure join point directly.
    | TypeAnnot

    // Array
    | ArrayCreateDotNet
    | ReferenceCreate
    | ArrayLength

    // Getters
    | GetArray
    | GetReference

    // Setters
    | SetArray
    | SetReference
   
    // Static unary operations
    | PrintStatic
    | ErrorNonUnit
    | ErrorType
    | ErrorPatMiss
    | Dynamize
    | IsLit
    | IsPrim

    // UnOps
    | Neg
    | FailWith

    // Auxiliary math ops
    | Tanh
    | Log
    | Exp
    | Sqrt
    | IsNan

    // Infinity
    | Infinity

type RawRecordTestPattern = 
    | RawRecordTestKeyword of keyword: KeywordString * name: VarString
    | RawRecordTestInjectVar of var: VarString * name: VarString
and RawRecordWithPattern = 
    | RawRecordWithKeyword of KeywordString * RawExpr 
    | RawRecordWithInjectVar of VarString * RawExpr
    | RawRecordWithoutKeyword of KeywordString 
    | RawRecordWithoutInjectVar of VarString
and PatRecordMembersItem =
    | PatRecordMembersKeyword of keyword: KeywordString * name: Pattern
    | PatRecordMembersInjectVar of var: VarString * name: Pattern

and Pattern =
    | PatVar of VarString
    | PatVarBox of VarString
    | PatVarAnnot of VarString * RawTypeExpr
    | PatVarAnnotBox of VarString * RawTypeExpr
    | PatForallAnnot of VarString * RawTypeExpr

    | PatPair of Pattern * Pattern
    | PatKeyword of string * Pattern list
    | PatRecordMembers of PatRecordMembersItem list
    | PatActive of RawExpr * Pattern
    | PatUnion of Pattern list
    | PatOr of Pattern list
    | PatAnd of Pattern list
    | PatLit of Value
    | PatDefaultLit of string
    | PatWhen of Pattern * RawExpr
    | PatPos of Pos<Pattern>

and RawExpr =
    | RawB
    | RawV of VarString 
    | RawLit of Value
    | RawInline of RawExpr // Acts as a join point for the prepass specifically.
    | RawInl of VarString * RawExpr
    | RawForall of VarString * RawExpr
    | RawTypeInl of VarString * RawExpr
    | RawLet of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawCase of var: VarString * bind: RawExpr * on_succ: RawExpr
    | RawRecBlock of (VarString * RawExpr) []
    | RawPairTest of vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordTest of KeywordString * vars: VarString [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawRecordTest of RawRecordTestPattern [] * bind: VarString * on_succ: RawExpr * on_fail: RawExpr
    | RawKeywordCreate of KeywordString * RawExpr []
    | RawRecordWith of RawExpr [] * RawRecordWithPattern []
    | RawOp of Op * RawExpr []
    | RawPos of Pos<RawExpr>
    | RawPattern of (VarString * (Pattern * RawExpr) []) // These parenthesis are here so the pattern compilation can be memoized via reference identity.
and RawTypeExpr =
    | RawTPair of RawTypeExpr * RawTypeExpr
    | RawTFun of RawTypeExpr * RawTypeExpr
    | RawTConstraint of RawTypeExpr * RawTypeExpr
    | RawTDepConstraint of RawTypeExpr * RawTypeExpr
    | RawTRecord of Map<string,RawTypeExpr>
    | RawTKeyword of string * RawTypeExpr []
    | RawTVar of string
    | RawTApply of RawTypeExpr * RawTypeExpr
    | RawTForall of (string * RawTypeTypeExpr) [] * RawTypeExpr
    | RawTUnit
    | RawTPos of Pos<RawTypeExpr>
and RawTypeTypeExpr =
    | RawTType
    | RawTTFun of RawTypeTypeExpr * RawTypeTypeExpr

type ParserExpr =
    | ParserStatement of (RawExpr -> RawExpr)
    | ParserExpr of RawExpr

let v x = RawV x
let lit x = RawLit x
let inline_ = function RawInline _ as x -> x | x -> RawInline x
let inl x y = RawInl(y,x)
let keyword_ k l = RawKeywordCreate(k,l)
let keyword_unary_ k = RawKeywordCreate(k,[||])
let l bind body on_succ = RawLet(bind,body,on_succ)
let case bind body on_succ = RawCase(bind,body,on_succ)
let if_ cond on_succ on_fail = RawOp(If,[|cond;on_succ;on_fail|])
let pair_test x bind on_succ on_fail = RawPairTest(x,bind,on_succ,on_fail)
let keyword_test keyword x bind on_succ on_fail = RawKeywordTest(keyword,x,bind,on_succ,on_fail)
let record_test x bind on_succ on_fail = RawRecordTest(x,bind,on_succ,on_fail)
let record_with binds patterns = RawRecordWith(binds,patterns)
    
let op x args = RawOp(x,args)
//let vv x = op ListCreate x
let B = RawB
//let pattern arg clauses = RawPattern(arg,clauses)

let unop op' a = op op' [|a|]
let binop op' a b = op op' [|a;b|]
let eq x y = binop EQ x y
let ap x y = binop Apply x y
let rec ap' f l = Array.fold ap f l

// The seemingly useless function application is there to filter unused arguments from the environment and move the rest to `env_global`.
let join_point_entry_method y = inline_ (op JoinPointEntryMethod [|y|])

let inline expr_indent i op expr d = if op i (col d) then expr d else Error []

let semicolon (d: ParserEnv) = if d.Line <> d.semicolon_line then semicolon' d else d.FailWith(InvalidSemicolon) 

let exprpos expr d =
    let expr_pos pos x = RawPos(Pos(pos,x))
    let pos = pos' d
    (expr |>> function RawInline _ | RawRecBlock _ | RawInl _ | RawForall _ | RawTypeInl _ as x -> x | x -> expr_pos pos x) d
let patpos expr d =
    let pat_pos pos x = PatPos(Pos(pos,x))
    (expr |>> pat_pos (pos' d)) d

let inline concat_keyword'' f x =
    let strb = StringBuilder()
    let pattern = 
        List.map (fun ((str : string, pos : PosKey as strpos), pat) -> 
            strb.Append(str).Append(':') |> ignore
            f strpos pat
            ) x
    strb.ToString(), pattern

let concat_keyword' x = concat_keyword'' (fun strpos -> function None -> PatVar strpos | Some pat -> pat) x

type FunsOrCons = Funs | Cons

let rec type_ (d : ParserEnv) =
    let recurse d = type_ d
    let assert_allowed msg (d : ParserEnv) = if d.is_easy_phase then Ok() else d.Skip'(-1); d.FailWith msg
    let pairs next = sepBy1 next product |>> List.reduceBack (fun a b -> RawTPair(a,b))
    let arr_funs_cons next = 
        pipe2 next (many (((arr_fun >>% Funs) <|> (arr_cons >>. assert_allowed ConstraintNotAllowed >>% Cons)) .>>. next))
            (fun a l -> 
                let rec loop a = function   
                    | [] -> a
                    | (Funs, b) :: l -> RawTFun(a,loop b l)
                    | (Cons, b) :: l -> RawTConstraint(a,loop b l)
                loop a l)
    let arr_depcon next d = 
        pipe2 next (opt (arr_depcon >>. assert_allowed DepConstraintNotAllowed >>. next)) (fun a -> function Some b -> RawTDepConstraint(a,b) | None -> a) d
    let forall next (d : ParserEnv) = 
        let var = var' |>> fun x -> x, RawTType
        let var_annot = 
            let rec ttype' d = 
                let ttype = ttype >>% RawTType
                let ttfun next = many1 next |>> List.reduceBack (fun a b -> RawTTFun(a,b))
                ttfun (ttype <|> rounds ttype') d
            rounds ((var' .>> colon) .>>. ttype') 
        (pipe2 (forall >>. assert_allowed TypeForallNotAllowed >>. many1 (var <|> var_annot) .>> dot) next (fun l x -> RawTForall(List.toArray l,x))
         <|> next) d
    let record next = curlies (many ((var' .>> colon) .>>. next)) |>> (Map.ofList >> RawTRecord)
    let keyword next = 
        (keyword_unary |>> fun x -> RawTKeyword(fst x,[||]))
        <|> (many (keyword .>>. next) |>> (concat_keyword'' (fun _ t -> t) >> fun (a, b) -> RawTKeyword(a, List.toArray b)))
    let var = var' |>> RawTVar
    let parenths next = rounds (next <|>% RawTUnit)
    let tapply next = many1 next |>> List.reduce (fun a b -> RawTApply(a,b))

    (
    choice [|var; parenths recurse; record recurse; keyword recurse|] 
    |> tapply |> pairs |> arr_depcon |> arr_funs_cons |> forall
    ) d

let (^<|) a b = a b // High precedence, right associative <| operator

let rec pattern_template expr s =
    let inline recurse s = pattern_template expr s

    let pat_when pattern = pattern .>>. (opt (when_ >>. expr)) |>> function a, Some b -> PatWhen(a,b) | a, None -> a
    let pat_as pattern = pattern .>>. (opt (as_ >>. pattern )) |>> function a, Some b -> PatAnd [a;b] | a, None -> a
    let pat_or pattern = sepBy1 pattern or_ |>> function [x] -> x | x -> PatOr x
    let pat_keyword_fun l = concat_keyword'' (fun strpos -> function Some pat -> pat | None -> PatVar strpos) l
    let pat_keyword pattern = many1 (keyword .>>. opt pattern) |>> (pat_keyword_fun >> PatKeyword) <|> pattern
    let pat_pair pattern = sepBy1 pattern comma |>> List.reduceBack (fun a b -> PatPair(a,b))
    let pat_and pattern = sepBy1 pattern and_ |>> function [x] -> x | x -> PatAnd x
    let pat_expr = (var |>> v) <|> rounds expr
    let pat_type pattern = pattern .>>. opt (colon >>. type_) |>> function a,Some b as x-> PatTypeEq(a,b) | a, None -> a
    let pat_wildcard = wildcard >>= fun _  d -> Ok(PatVar("", pos' d))
    let pat_var = var |>> PatVar
    let pat_active pattern = unary_one >>. pat_expr .>>. pattern |>> PatActive 
    let pat_unbox pattern = unary_three >>. ((var |>> PatVar) <|> rounds pattern) |>> PatUnbox
    let pat_lit = lit_ |>> PatLit
    let pat_record_item pattern =
        let inline templ var k = pipe2 var (opt (eq >>. pattern)) (fun a -> function Some b -> k(a,b) | None -> k(a,PatVar a))
        templ (var <|> op_as_var) PatRecordMembersKeyword <|> templ (unary_four >>. var) PatRecordMembersInjectVar
    let pat_record pattern = curlies (many (pat_record_item pattern)) |>> PatRecordMembers
    let pat_keyword_unary = keyword_unary |>> fun keyword -> PatKeyword(keyword,[])
    let pat_rounds pattern = rounds (pattern <|> (op_as_var |>> PatVar) <|>% PatTuple []) 
        
    pat_when ^<| pat_as ^<| pat_or ^<| pat_keyword ^<| pat_pair ^<| pat_and ^<| pat_type
    ^<| choice [|pat_wildcard; pat_var; pat_active recurse; pat_unbox recurse; pat_lit; pat_record recurse; pat_keyword_unary; pat_rounds recurse|] <| s

let inline pattern expr s = patpos (pattern_template expr) s
