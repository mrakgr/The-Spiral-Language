module Spiral.BlockBundling

open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Hopac.Stream

open VSCTypes
open FSharpx.Collections
open Spiral.BlockSplitting
open Spiral.BlockParsing

// These bundles are top statements that have their range offsets distributed into them.
type [<ReferenceEquality>] Bundle =
    | BundleType of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | BundleNominal of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | BundleNominalRec of (VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr) list
    | BundleInl of Comments * VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
    | BundleRecInl of (Comments * VSCRange * (VSCRange * VarString) * RawExpr) list * is_top_down: bool
    | BundlePrototype of Comments * VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawTExpr
    | BundleInstance of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawExpr
    | BundleOpen of VSCRange * (VSCRange * VarString) * (VSCRange * SymbolString) list

let bundle_range = function
    | BundleType(r,_,_,_) | BundleNominal(r,_,_,_) | BundleInl(_,r,_,_,_) 
    | BundlePrototype(_,r,_,_,_,_) | BundleInstance(r,_,_,_,_) | BundleOpen(r,_,_) -> r
    | BundleNominalRec l -> List.head l |> fun (r,_,_,_) -> r
    | BundleRecInl(l,_) -> List.head l |> fun (_,r,_,_) -> r

let add_offset offset (range : VSCRange) : VSCRange = 
    let f (a : VSCPos) = {|a with line=offset + a.line|}
    let a,b = range
    f a, f b
let add_offset_hovar offset (a,b) = add_offset offset a, b
let add_offset_hovar_list offset x = List.map (add_offset_hovar offset) x
let add_offset_typevar offset ((a,b),c) = (add_offset offset a, b), add_offset_hovar_list offset c
let add_offset_typevar_list offset x = List.map (add_offset_typevar offset) x

let rec fold_offset_ty offset x = 
    let f = fold_offset_ty offset
    let g = add_offset offset
    match x with
    | RawTWildcard r -> RawTWildcard(g r)
    | RawTLit(r,a) -> RawTLit(g r, a)
    | RawTB r -> RawTB(g r)
    | RawTMetaVar(r,a) -> RawTMetaVar(g r,a)
    | RawTVar(r,a) -> RawTVar(g r,a)
    | RawTArray(r,a) -> RawTArray(g r,f a)
    | RawTPair(r,a,b) -> RawTPair(g r,f a,f b)
    | RawTFun(r,a,b) -> RawTFun(g r,f a,f b)
    | RawTRecord(r,a) -> RawTRecord(g r,Map.map (fun _ -> f) a)
    | RawTUnion(r,a,b) -> RawTUnion(g r,Map.map (fun _ -> f) a,b)
    | RawTSymbol(r,a) -> RawTSymbol(g r,a)
    | RawTApply(r,a,b) -> RawTApply(g r,f a,f b)
    | RawTForall(r,a,b) -> RawTForall(g r,add_offset_typevar offset a,f b)
    | RawTExists(r,a,b) -> RawTExists(g r,add_offset_typevar_list offset a,f b)
    | RawTPrim(r,a) -> RawTPrim(g r,a)
    | RawTTerm(r,a) -> RawTTerm(g r,fold_offset_term offset a)
    | RawTMacro(r,a) -> RawTMacro(g r,fold_offset_macro offset a)
    | RawTFilledNominal(r,a) -> RawTFilledNominal(g r,a)
    | RawTLayout(r,a,b) -> RawTLayout(g r,f a,b)
and fold_offset_macro offset a =
    let g = add_offset offset
    List.map (function
        | RawMacroText(r,a) -> RawMacroText(g r,a)
        | RawMacroTermVar(r,a) -> RawMacroTermVar(g r,fold_offset_term offset a)
        | RawMacroTypeVar(r,a) -> RawMacroTypeVar(g r,fold_offset_ty offset a)
        | RawMacroTypeLitVar(r,a) -> RawMacroTypeLitVar(g r,fold_offset_ty offset a)
        ) a
and fold_offset_term offset x = 
    let f = fold_offset_term offset
    let ty = fold_offset_ty offset
    let g = add_offset offset
    match x with
    | RawB r -> RawB (g r)
    | RawV(r,a) -> RawV (g r,a)
    | RawLit(r,a) -> RawLit (g r,a)
    | RawDefaultLit(r,a) -> RawDefaultLit (g r,a)
    | RawSymbol(r,a) -> RawSymbol (g r,a)
    | RawType(r,a) -> RawType(g r, ty a)
    | RawMatch(r,a,b) -> RawMatch(g r,f a,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) b)
    | RawFun(r,a) -> RawFun(g r,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) a)
    | RawForall(r,a,b) -> RawForall(g r,add_offset_typevar offset a,f b)
    | RawExists(r,a,b) -> RawExists(g r,Option.map (List.map ty) a, f b)
    | RawFilledForall(r,a,b) -> RawFilledForall(g r,a,f b)
    | RawRecBlock(r,a,b) -> RawRecBlock(g r,List.map (fun ((r,a),b) -> (g r,a),f b) a,f b)
    | RawRecordWith(r,a,b,c) -> 
        let b =
            b |> List.map (function
                | RawRecordWithSymbol((r,a),b) -> RawRecordWithSymbol((g r,a),f b)
                | RawRecordWithSymbolModify((r,a),b) -> RawRecordWithSymbolModify((g r,a),f b)
                | RawRecordWithInjectVar((r,a),b) -> RawRecordWithInjectVar((g r,a),f b)
                | RawRecordWithInjectVarModify((r,a),b) -> RawRecordWithInjectVarModify((g r,a),f b)
                )
        let c =
            c |> List.map (function
                | RawRecordWithoutSymbol(r,a) -> RawRecordWithoutSymbol(g r,a)
                | RawRecordWithoutInjectVar(r,a) -> RawRecordWithoutInjectVar(g r,a)
                )
        RawRecordWith(g r, List.map f a,b,c)
    | RawOp(r,a,b) -> RawOp(g r,a,List.map f b)
    | RawJoinPoint(r,q,a,b) -> RawJoinPoint(g r,Option.map (fun (r',w) -> g r',w) q,f a,b)
    | RawAnnot(r,a,b) -> RawAnnot(g r,f a,ty b)
    | RawTypecase(r,a,b) -> RawTypecase(g r,ty a,List.map (fun (a,b) -> ty a,f b) b)
    | RawOpen(r,a,b,c) -> RawOpen(g r,add_offset_hovar offset a,add_offset_hovar_list offset b,f c)
    | RawApply(r,a,b) -> RawApply(g r,f a,f b)
    | RawIfThenElse(r,a,b,c) -> RawIfThenElse(g r,f a,f b,f c)
    | RawIfThen(r,a,b) -> RawIfThen(g r,f a,f b)
    | RawPair(r,a,b) -> RawPair(g r,f a,f b)
    | RawSeq(r,a,b) -> RawSeq(g r,f a,f b)
    | RawHeapMutableSet(r,a,b,c) -> RawHeapMutableSet(g r,f a,List.map f b,f c)
    | RawReal(r,a) -> RawReal(g r,f a)
    | RawMissingBody r -> RawMissingBody(g r)
    | RawMacro(r,a) -> RawMacro(g r,fold_offset_macro offset a)
    | RawArray(r,a) -> RawArray(g r,List.map f a)
and fold_offset_pattern offset x = 
    let f = fold_offset_pattern offset
    let term = fold_offset_term offset
    let ty = fold_offset_ty offset
    let g = add_offset offset
    let g' x = add_offset_hovar offset x
    match x with
    | PatFilledDefaultValue _ -> failwith "Compiler error: Later stages only."
    | PatB r -> PatB(g r)
    | PatE r -> PatE(g r)
    | PatVar(r,a) -> PatVar(g r,a)
    | PatDyn(r,a) -> PatDyn(g r,f a)
    | PatUnbox(r,q,a) -> PatUnbox(g r,q,f a)
    | PatAnnot(r,a,b) -> PatAnnot(g r,f a,ty b)
    | PatPair(r,a,b) -> PatPair(g r,f a,f b)
    | PatSymbol(r,a) -> PatSymbol(g r,a)
    | PatRecordMembers(r,a) ->
        let a = a |> List.map (function
            | PatRecordMembersSymbol((r,a),b) -> PatRecordMembersSymbol((g r,a),f b)
            | PatRecordMembersInjectVar((r,a),b) -> PatRecordMembersInjectVar((g r,a),f b)
            )
        PatRecordMembers(g r,a)
    | PatOr(r,a,b) -> PatOr(g r,f a,f b)
    | PatAnd(r,a,b) -> PatAnd(g r,f a,f b)
    | PatValue(r,a) -> PatValue(g r,a)
    | PatDefaultValue(r,a) -> PatDefaultValue(g r,a)
    | PatWhen(r,a,b) -> PatWhen(g r,f a,term b)
    | PatNominal(r,a,b,c) -> PatNominal(g r,g' a,List.map g' b,f c)
    | PatExists(r,a,b) -> PatExists(g r,List.map g' a,f b)
    | PatArray(r,a) -> PatArray(g r,List.map f a)
    
let bundle_blocks (blocks : TopStatement Block list) =
    match blocks with
    | [] -> None
    | {block=TopAnd _} :: x' -> failwith "Compiler error: TopAnd should be eliminated during the first bundling step."
    | {block=TopRecInl _} :: _ as l ->
        l |> List.mapFold (fun _ -> function
            | {offset=i; block=TopRecInl(com,r,a,b,c)} -> (com, add_offset i r, add_offset_hovar i a, fold_offset_term i b), c
            | _ -> failwith "Compiler error: Recursive inl statements can only be followed by statements of the same type."
            ) true
        |> BundleRecInl |> Some
    | {block=TopNominalRec _} :: _ as l ->
        l |> List.map (function 
            | {offset=i; block=TopNominalRec(r,a,b,c)} -> (add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c)
            | _ -> failwith "Compiler error: Recursive type statements can only be followed by statements of the same type."
            )
        |> BundleNominalRec |> Some
    | [{offset=i; block=TopInl(com,r,a,b,c)}] -> BundleInl(com, add_offset i r, add_offset_hovar i a, fold_offset_term i b, c) |> Some
    | [{offset=i; block=TopPrototype(com,r,a,b,c,d)}] -> BundlePrototype(com,add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_ty i d) |> Some
    | [{offset=i; block=TopNominal(r,a,b,c)}] -> BundleNominal(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c) |> Some
    | [{offset=i; block=TopType(r,a,b,c)}] -> BundleType(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c) |> Some
    | [{offset=i; block=TopInstance(r,a,b,c,d)}] -> BundleInstance(add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_term i d) |> Some
    | [{offset=i; block=TopOpen(r,a,b)}] -> BundleOpen(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b) |> Some
    | {block=TopInl _ | TopPrototype _ | TopNominal _ | TopType _ | TopInstance _ | TopOpen _} :: _ -> failwith "Compiler error: Regular top level statements should be singleton bundles."

let add_line_to_range line ((a,b) : VSCRange) = {|a with line=line+a.line|}, {|b with line=line+b.line|}

let process_error v = 
    let messages, expecteds = v |> List.distinct |> List.partition (fun x -> System.Char.IsUpper(x,0))
    let ex () = match expecteds with [x] -> sprintf "Expected: %s" x | x -> sprintf "Expected one of: %s" (String.concat ", " x)
    let f l = String.concat "\n" l
    if List.isEmpty expecteds then f messages
    elif List.isEmpty messages then ex ()
    else f (ex () :: "" :: "Other error messages:" :: messages)

let show_block_parsing_error line (l : ParserErrorsList) : RString list =
    l |> List.groupBy fst
    |> List.map (fun (k,v) -> 
        let k = add_line_to_range line k
        let v = List.map (snd >> show_parser_error) v
        k, process_error v
        )

type ParsedBlock = {result : ParseResult; semantic_tokens : LineTokens}
type ParserState = {
    is_top_down : bool
    blocks : (LineTokens * ParsedBlock Promise Block) list
    }
type BlockBundleValue = {bundle : Bundle option; errors : RString list}
type BlockBundleState = (TopStatement Block list * BlockBundleValue) Stream
type private BlockBundleStateInner = {errors : RString list; tmp : TopStatement Block list; state : BlockBundleState}

let wdiff_block_bundle_init : BlockBundleState = Promise.Now.never()
/// Bundles the blocks with the `and` statements. Also collects the parser errors.
/// Does diffing to ref preserve the bundles.
let wdiff_block_bundle (state : BlockBundleState) (l : ParserState) : BlockBundleState =
    let (+.) a b = add_line_to_range a b

    let empty = {state=wdiff_block_bundle_init; tmp=[]; errors=[]}
    let move_temp (s : BlockBundleStateInner) next =
        let o' = List.rev s.tmp
        let fl () = (o',{bundle=bundle_blocks o'; errors=Seq.toList s.errors}), next empty
        if Promise.Now.isFulfilled s.state then
            match Promise.Now.get s.state with
            | Cons((o,q),xs) when o = o' -> (o,{bundle=q.bundle; errors=Seq.toList s.errors}), next {state=xs; tmp=[]; errors=[]}
            | _ -> fl ()
        else fl ()
        |> Cons |> Promise.Now.withValue

    let inline iter (s : BlockBundleStateInner) l f = 
        match l with
        | (_,x) :: x' -> let offset = x.offset in x.block >>** fun {result=a} -> f (offset,a,x')
        | [] -> move_temp s (fun _ -> Promise.Now.withValue Nil)
    let rec init (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
        match x with
        | Ok (TopAnd(r,_)) -> init {s with errors = (offset +. r, "Invalid `and` statement.") :: s.errors} x'
        | Ok (TopRecInl _ as a) -> recinl {s with tmp = {offset=offset; block=a} :: s.tmp} x'
        | Ok (TopNominalRec _ as a) -> rectype {s with tmp = {offset=offset; block=a} :: s.tmp} x'
        | Ok a -> move_temp {s with tmp = {offset=offset; block=a} :: s.tmp} (fun s -> init s x')
        | Error er -> init {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'
    and recinl (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
        match x with
        | Ok (TopAnd(_, TopRecInl _ & a)) -> recinl {s with tmp = {offset=offset; block=a} :: s.tmp} x'
        | Ok (TopAnd(r, _)) -> recinl {s with errors = (offset +. r, "inl/let recursive statements can only be followed by `and` inl/let statements.") :: s.errors} x'
        | Ok _ -> move_temp s (fun s -> init s l)
        | Error er -> recinl {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'
    and rectype (s : BlockBundleStateInner) l = iter s l <| fun (offset,x,x') -> 
        match x with
        | Ok (TopAnd(_, TopNominalRec _ & a)) -> rectype {s with tmp = {offset=offset; block=a} :: s.tmp} x'
        | Ok (TopAnd(r, _)) -> rectype {s with errors = (offset +. r, "`union rec` can only be followed by `and union`.") :: s.errors} x'
        | Ok _ -> move_temp s (fun s -> init s l)
        | Error er -> rectype {s with errors = List.append (show_block_parsing_error offset er) s.errors} x'

    init {empty with state=state} l.blocks

let semantic_tokens (l : ParserState) = 
    let rec loop s = function
        | (_,x) :: xs -> x.block >>= fun x -> loop (PersistentVector.append s x.semantic_tokens) xs
        | [] -> Job.result s
    loop PersistentVector.empty l.blocks