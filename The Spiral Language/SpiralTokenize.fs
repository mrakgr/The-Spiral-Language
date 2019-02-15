module Spiral.Parsing
open System
open Types

// Parser open
open FParsec
open System.Text
open System.Collections.Generic

// Globals
let private keyword_to_string_dict = Dictionary(HashIdentity.Structural)
let private string_to_keyword_dict = Dictionary(HashIdentity.Structural)
let private string_to_op_dict = Dictionary(HashIdentity.Structural)
let mutable private tag_keyword = 0

let _ =
    Microsoft.FSharp.Reflection.FSharpType.GetUnionCases(typeof<Op>)
    |> Array.iter (fun x ->
        string_to_op_dict.[x.Name] <- Microsoft.FSharp.Reflection.FSharpValue.MakeUnion(x,[||]) :?> Op
        )
let string_to_op x = string_to_op_dict.TryGetValue x

let string_to_keyword (x: string) =
    match string_to_keyword_dict.TryGetValue x with
    | true, v -> v
    | false, _ ->
        tag_keyword <- tag_keyword + 1
        string_to_keyword_dict.[x] <- tag_keyword
        keyword_to_string_dict.[tag_keyword] <- x
        tag_keyword
let keyword_to_string x = keyword_to_string_dict.[x] // Should never fail.

let show_primt = function
    | UInt8T -> "uint8"
    | UInt16T -> "uint16"
    | UInt32T -> "uint32"
    | UInt64T -> "uint64"
    | Int8T -> "int8"
    | Int16T -> "int16"
    | Int32T -> "int32"
    | Int64T -> "int64"
    | Float32T -> "float32"
    | Float64T -> "float64"
    | BoolT -> "bool"
    | StringT -> "string"
    | CharT -> "char"

let show_value = function
    | LitUInt8 x -> sprintf "%iu8" x
    | LitUInt16 x -> sprintf "%iu16" x
    | LitUInt32 x -> sprintf "%iu32" x
    | LitUInt64 x -> sprintf "%iu64" x
    | LitInt8 x -> sprintf "%ii8" x
    | LitInt16 x -> sprintf "%ii16" x
    | LitInt32 x -> sprintf "%ii32" x
    | LitInt64 x -> sprintf "%ii64" x
    | LitFloat32 x -> sprintf "%ff32" x
    | LitFloat64 x -> sprintf "%ff64" x
    | LitBool x -> sprintf "%b" x
    | LitString x -> sprintf "%s" x
    | LitChar x -> sprintf "%c" x

let show_art = function
    | ArtDotNetHeap -> "array"
    | ArtDotNetReference -> "ref"
    | ArtCudaGlobal _ -> "array_cuda_global"
    | ArtCudaShared -> "array_cuda_shared"
    | ArtCudaLocal -> "array_cuda_local"

let show_layout_type = function
    | LayoutStack -> "layout_stack"
    | LayoutHeap -> "layout_heap"
    | LayoutHeapMutable -> "layout_heap_mutable"

let inline show_keyword show (keyword,l: _[]) =
    if l.Length > 0 then
        let a = (keyword_to_string keyword).Split([|':'|], StringSplitOptions.RemoveEmptyEntries)
        Array.map2 (fun a l -> String.concat "" [|a;": ";show l|]) a l
        |> String.concat " "
    else
        keyword_to_string keyword

let inline show_map show v = 
    let body = 
        Map.toArray v
        |> Array.map (fun (k,v) -> sprintf "%s=%s" (keyword_to_string k) (show v))
        |> String.concat "; "

    sprintf "{%s}" body

let inline show_list show l = sprintf "(%s)" (List.map show l |> String.concat ", ")

let rec show_ty = function
    | PrimT x -> show_primt x
    | KeywordT(C(keyword,l)) -> show_keyword show_ty (keyword,l)
    | ListT l -> show_list show_ty l.node
    | MapT v -> show_map show_ty v.node
    | ObjectT _ -> "<object>"
    | FunctionT _ | RecFunctionT _ -> "<function>"
    | LayoutT (C(layout_type,body,_)) ->
        sprintf "%s (%s)" (show_layout_type layout_type) (show_consed_typed_data body)
    | TermCastedFunctionT (a,b) ->
        sprintf "(%s => %s)" (show_ty a) (show_ty b)
    | UnionT l ->
        let body =
            Set.toArray l.node
            |> Array.map show_ty
            |> String.concat " | "
        sprintf "union {%s}" body
    | RecUnionT (name, _) -> name
    | ArrayT (a,b) -> sprintf "%s (%s)" (show_art a) (show_ty b)
    | MacroT x -> x

and show_typed_data = function
    | TyT x -> sprintf "type (%s)" (show_ty x)
    | TyV(T(_,t)) -> sprintf "var (%s)" (show_ty t)
    | TyKeyword(keyword,l) -> show_keyword show_typed_data (keyword,l)
    | TyList l -> show_list show_typed_data l
    | TyMap a -> show_map show_typed_data a
    | TyObject _ -> "<object>"
    | TyFunction _ | TyRecFunction _ -> "<function>"
    | TyBox(a,b) -> sprintf "(%s : %s)" (show_typed_data a) (show_ty b)
    | TyLit v -> sprintf "lit %s" (show_value v)

and show_consed_typed_data = function
    | CTyT x -> sprintf "type (%s)" (show_ty x)
    | CTyV(_,t) -> sprintf "var (%s)" (show_ty t)
    | CTyKeyword(C(keyword,l)) -> show_keyword show_consed_typed_data (keyword,l)
    | CTyList l -> show_list show_consed_typed_data l.node
    | CTyMap a -> show_map show_consed_typed_data a.node
    | CTyObject _ -> "<object>"
    | CTyFunction _ | CTyRecFunction _ -> "<function>"
    | CTyBox(a,b) -> sprintf "(%s : %s)" (show_consed_typed_data a) (show_ty b)
    | CTyLit v -> sprintf "lit %s" (show_value v)

let pos (s: CharStream) = {column=int s.Column; line=int s.Line}
let tok start end_ = {start=start; end_=end_}

type TokenOperator = {
    name: string
    associativity: Associativity
    precedence: int
    }

type TokenSpecial =
    | SpecMatch
    | SpecFunction
    | SpecWith
    | SpecWithout
    | SpecAs
    | SpecWhen
    | SpecInl
    | SpecInm
    | SpecInb
    | SpecRec
    | SpecIf
    | SpecThen
    | SpecElif
    | SpecElse
    | SpecTrue
    | SpecFalse
    | SpecOpen
    | SpecJoin
    | SpecType
    | SpecTypeCatch
    | SpecWildcard

type SpiralToken =
    | TokVar of TokenPosition * string
    | TokNumber of TokenPosition * Value
    | TokMessage of TokenPosition * string
    | TokMessageUnary of TokenPosition * string
    | TokOperator of TokenPosition * TokenOperator
    | TokBracketRound of TokenPosition * SpiralToken list
    | TokBracketCurly of TokenPosition * SpiralToken list
    | TokBracketSquare of TokenPosition * SpiralToken list
    | TokComma of TokenPosition
    | TokSemicolon of TokenPosition
    | TokAnnotatedOne of TokenPosition * SpiralToken // ! Used for the active pattern and inbuilt ops.
    | TokAnnotatedTwo of TokenPosition * SpiralToken // @ Used for parser macros
    | TokAnnotatedThree of TokenPosition * SpiralToken // # Used for the unboxing pattern.
    | TokAnnotatedFour of TokenPosition * SpiralToken // $ Used for the injection in patterns and in RecordWith
    | TokSpecial of TokenPosition * TokenSpecial

let is_identifier_starting_char c = isAsciiLetter c || c = '_'
let is_identifier_char c = is_identifier_starting_char c || c = ''' || isDigit c 
let is_operator_char c = 
    let inline f x = c = x
    f '%' || f '^' || f '&' || f '|' || f '*' || f '/' || f '+' || f '-' || f '<' 
    || f '>' || f '=' || f '.' || f ':' || f '?'

let var (s:CharStream<_>) = 
    let start = pos s

    let f x (s: CharStream<_>) =
        if s.Skip(':') then
            let end_ = pos s
            TokMessage(tok start end_,x)
        else
            let end_ = pos s
            let pos = tok start end_
            match x with
            | "match" -> TokSpecial(pos,SpecMatch) | "function" -> TokSpecial(pos,SpecFunction)
            | "with" -> TokSpecial(pos,SpecWith) | "without" -> TokSpecial(pos,SpecWithout)
            | "as" -> TokSpecial(pos,SpecAs) | "when" -> TokSpecial(pos,SpecWhen)
            | "inl" -> TokSpecial(pos,SpecInl) | "inm" -> TokSpecial(pos,SpecInm)
            | "inb" -> TokSpecial(pos,SpecInb) | "rec" -> TokSpecial(pos,SpecRec)
            | "if" -> TokSpecial(pos,SpecIf) | "then" -> TokSpecial(pos,SpecThen)
            | "elif" -> TokSpecial(pos,SpecElif) | "else" -> TokSpecial(pos,SpecElse)
            | "true" -> TokSpecial(pos,SpecTrue) | "false" -> TokSpecial(pos,SpecFalse)
            | "open" -> TokSpecial(pos,SpecOpen) | "join" -> TokSpecial(pos,SpecJoin)
            | "type" -> TokSpecial(pos,SpecType) | "type_catch" -> TokSpecial(pos,SpecTypeCatch)
            | "_" -> TokSpecial(pos,SpecWildcard)
            | x -> TokVar(pos,x)
        |> Reply

    (many1Satisfy2L is_identifier_starting_char is_identifier_char "identifier" >>= f .>> spaces) s

let default_number_format =  
    NumberLiteralOptions.AllowFraction
    ||| NumberLiteralOptions.AllowExponent
    ||| NumberLiteralOptions.AllowHexadecimal
    ||| NumberLiteralOptions.AllowBinary
            
let number_format_with_minus = default_number_format ||| NumberLiteralOptions.AllowMinusSign

let number (s: CharStream<_>) = 
        let inline parser (s: CharStream<_>) = 
            let parse_num_lit number_format s = numberLiteral number_format "number" s
            if s.Peek() = '-' && isDigit (s.Peek(1)) then parse_num_lit number_format_with_minus s
            else parse_num_lit default_number_format s

        let inline safe_parse f on_succ er_msg x = 
            match f x with
            | true, x -> Reply(on_succ x)
            | false, _ -> Reply(ReplyStatus.FatalError,messageError er_msg)

        let inline default_int x = safe_parse Int64.TryParse LitInt64 "default int parse failed" x
        let inline default_float x = safe_parse Double.TryParse LitFloat64 "default float parse failed" x

        let followedBySuffix x is_x_integer (s: CharStream<_>) =
            let guard f =
                let a = s.Peek()
                if is_identifier_starting_char a || isDigit a then Reply(Error, expected "non-identifier character or digit")
                else f x
            if s.Skip('i') then
                if s.Skip('8') then guard (safe_parse SByte.TryParse LitInt8 "int8 parse failed")
                elif s.Skip('1') && s.Skip('6') then guard (safe_parse Int16.TryParse LitInt16 "int16 parse failed")
                elif s.Skip('3') && s.Skip('2') then guard (safe_parse Int32.TryParse LitInt32 "int32 parse failed")
                elif s.Skip('6') && s.Skip('4') then guard (safe_parse Int64.TryParse LitInt64 "int64 parse failed")
                else Reply(Error, expected "8,16,32 or 64")
            elif s.Skip('u') then
                if s.Skip('8') then guard (safe_parse Byte.TryParse LitUInt8 "uint8 parse failed")
                elif s.Skip('1') && s.Skip('6') then guard (safe_parse UInt16.TryParse LitUInt16 "uint16 parse failed")
                elif s.Skip('3') && s.Skip('2') then guard (safe_parse UInt32.TryParse LitUInt32 "uint32 parse failed")
                elif s.Skip('6') && s.Skip('4') then guard (safe_parse UInt64.TryParse LitUInt64 "uint64 parse failed")
                else Reply(Error, expected "8,16,32 or 64")
            elif s.Skip('f') then
                if s.Skip('3') && s.Skip('2') then guard (safe_parse Single.TryParse LitFloat32 "float32 parse failed")
                elif s.Skip('6') && s.Skip('4') then guard (safe_parse Double.TryParse LitFloat64 "float64 parse failed")
                else Reply(Error, expected "32 or 64")
            elif is_x_integer then guard default_int
            else guard default_float

        let start = pos s
        let reply = parser s
        if reply.Status = Ok then
            let nl = reply.Result // the parsed NumberLiteral
            try 
                let f x = TokNumber(tok start (pos s), x)
                ((followedBySuffix nl.String nl.IsInteger |>> f) .>> spaces) s
            with
            | :? System.OverflowException as e ->
                s.Skip(-nl.String.Length)
                Reply(FatalError, messageError e.Message)
        else // reconstruct error reply
            Reply(reply.Status, reply.Error)

let message_unary s =
    let start = pos s
    let f x s = Reply(TokMessageUnary(tok start (pos s), x))

    let x = s.Peek2()
    if x.Char0 = '.' && is_identifier_starting_char x.Char1 then
        s.Skip()
        ((manySatisfy is_identifier_char <?> "unary message") >>= f .>> spaces) s
    else
        Reply(Error, expected "unary message")

let inbuilt_operators =
    let dict_operator = Dictionary(HashIdentity.Structural)
    let add_infix_operator assoc str prec = dict_operator.Add(str, {name=str; precedence=prec; associativity=assoc})

    let left_assoc_ops = 
        let f = add_infix_operator Associativity.Left
        f "+" 60; f "-" 60; f "*" 70; f "/" 70; f "%" 70
        f "<|" 10; f "|>" 10; f "<<" 10; f ">>" 10

        let f str = add_infix_operator Associativity.None str 40
        f "<="; f "<"; f "="; f ">"; f ">="; f "<>"
        f "<<<"; f ">>>"; f "&&&"; f "|||"

    let right_associative_ops =
        let f str prec = add_infix_operator Associativity.Right str prec
        f "||" 20; f "&&" 30; f "::" 50; f "^^^" 45
        f "=>" 0; f "->" 0; f ":>" 35; f ":?>" 35; f "**" 80
         
    dict_operator

// Similarly to F#, Spiral filters out the '.' from the operator name and then tries to match to the nearest inbuilt operator
// for the sake of assigning associativity and precedence.
let op pos name' = 
    match inbuilt_operators.TryGetValue name' with
    | true, v -> v
    | false, _ ->
        let name = String.filter ((<>) '.') name'
        let rec loop l =
            if l > 0 then
                let name = name.[0..l-1]
                match inbuilt_operators.TryGetValue name with
                | false, _ -> loop (l - 1)
                | true, v -> 
                    let x = {v with name=name'}
                    inbuilt_operators.Add(name',x)
                    x
            else
                raise (TokenizationError(sprintf "The `%s` operator is not supported." name', pos))
        loop name.Length

let operator s = 
    let start = pos s
    let f name s = 
        let pos = tok start (pos s)
        Reply(TokOperator(pos,op pos name))
    (many1SatisfyL is_operator_char "operator"  >>= f .>> spaces) s