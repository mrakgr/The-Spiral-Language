module Spiral.MockTypechecker

open Spiral.BlockParsing
open Spiral.Blockize

// These bundles have their range offsets distributed into them.
type BundleRecType =
    | BundleUnion of Range * TypeVar list * RawTExpr list
    | BundleNominal of Range * TypeVar list * RawTExpr

type BundleRecTerm = BundleRecInl of Range * (Range * VarString) * RawExpr * is_top_down: bool

type BundleTop =
    | BundleRecType of BundleRecType list
    | BundleRecTerm of BundleRecTerm list
    | BundleInl of Range * (Range * VarString) * RawExpr * is_top_down: bool
    | BundlePrototype of Range * VarString * VarString * TypeVar list * RawTExpr
    | BundleType of Range * VarString * TypeVar list * RawTExpr
    | BundleInstance of Range * VarString * VarString * TypeVar list * RawExpr

let add_offset offset (range : Range) : Range = let a,b = range in {a with line=offset + a.line}, {b with line=offset + b.line}
let add_offset_typevar offset (a,b) = add_offset offset a, b
let add_offset_typevar_list offset x = List.map (add_offset_typevar offset) x

let rec fold_offset_ty offset x = 
    let f = fold_offset_ty offset
    let g = add_offset offset
    let g' x = add_offset_typevar offset x
    match x with
    | RawTWildcard r -> RawTWildcard(g r)
    | RawTB r -> RawTB(g r)
    | RawTMetaVar(r,a) -> RawTMetaVar(g r,a)
    | RawTVar(r,a) -> RawTVar(g r,a)
    | RawTPair(r,a,b) -> RawTPair(g r,f a,f b)
    | RawTFun(r,a,b) -> RawTFun(g r,f a,f b)
    | RawTRecord(r,a) -> RawTRecord(g r,Map.map (fun _ -> f) a)
    | RawTSymbol(r,a) -> RawTSymbol(g r,a)
    | RawTApply(r,a,b) -> RawTApply(g r,f a,f b)
    | RawTForall(r,a,b) -> RawTForall(g r,g' a,f b)
    | RawTPrim(r,a) -> RawTPrim(g r,a)
    | RawTArray(r,a) -> RawTArray(g r,f a)
    | RawTTerm(r,a) -> RawTTerm(g r,fold_offset_term offset a)
and fold_offset_term offset x = 
    let f = fold_offset_term offset
    let ty = fold_offset_ty offset
    let g = add_offset offset
    let g' x = add_offset_typevar offset x
    let g'' x = add_offset_typevar_list offset x
    match x with
    | RawB r -> RawB (g r)
    | RawV(r,a) -> RawV (g r, a)
    | RawLit(r,a) -> RawLit (g r, a)
    | RawDefaultLit(r,a) -> RawDefaultLit (g r, a)
    | RawSymbolCreate(r,a) -> RawSymbolCreate (g r, a)
    | RawType(r,a) -> RawType(g r, a)
    | RawMatch(r,a,b) -> RawMatch(g r,f a,List.map (fun (a,b) -> fold_offset_pattern offset a, f b) b)
    | RawFun(r,a) -> RawFun(g r, List.map (fun (a,b) -> fold_offset_pattern offset a, f b) a)
    | RawForall(r,a,b) -> RawForall(g r,g' a,f b)
    | RawRecBlock(r,a,b) -> RawRecBlock(g r,List.map (fun ((r,a),b) -> (g r,a),f b) a,f b)
    | RawRecordWith(r,a,b,c) -> 
        let b =
            b |> List.map (function
                | RawRecordWithSymbol((r,a),b) -> RawRecordWithSymbol((g r,a), f b)
                | RawRecordWithSymbolModify((r,a),b) -> RawRecordWithSymbolModify((g r,a), f b)
                | RawRecordWithInjectVar((r,a),b) -> RawRecordWithInjectVar((g r,a), f b)
                | RawRecordWithInjectVarModify((r,a),b) -> RawRecordWithInjectVarModify((g r,a), f b)
                )
        let c =
            c |> List.map (function
                | RawRecordWithoutSymbol(r,a) -> RawRecordWithoutSymbol(g r,a)
                | RawRecordWithoutInjectVar(r,a) -> RawRecordWithoutInjectVar(g r,a)
                )
        RawRecordWith(g r, List.map f a,b,c)
    | RawOp(r,a,b) -> RawOp(g r,a,List.map f b)
    | RawJoinPoint(r,a) -> RawJoinPoint(g r, f a)
    | RawAnnot(r,a,b) -> RawAnnot(g r, f a, ty b)
    | RawTypecase(r,a,b) -> RawTypecase(g r,ty a,List.map (fun (a,b) -> ty a, f b) b)
    | RawModuleOpen(r,a,b,c) -> RawModuleOpen(g r,g' a,g'' b,f c)
    | RawApply(r,a,b) -> RawApply(g r,f a,f b)
    | RawIfThenElse(r,a,b,c) -> RawIfThenElse(g r,f a,f b,f c)
    | RawIfThen(r,a,b) -> RawIfThen(g r,f a,f b)
    | RawPairCreate(r,a,b) -> RawPairCreate(g r,f a,f b)
    | RawSeq(r,a,b) -> RawSeq(g r,f a,f b)
    | RawReal(r,a) -> RawReal(g r,f a)
and fold_offset_pattern offset x = 
    let f = fold_offset_pattern offset
    let term = fold_offset_term offset
    let ty = fold_offset_ty offset
    let g = add_offset offset
    let g' x = add_offset_typevar offset x
    match x with
    | PatB r -> PatB(g r)
    | PatE r -> PatE(g r)
    | PatVar(r,a) -> PatVar(g r,a)
    | PatDyn(r,a) -> PatDyn(g r,f a)
    | PatUnbox(r,a) -> PatUnbox(g r,f a)
    | PatAnnot(r,a,b) -> PatAnnot(g r,f a,ty b)
    | PatPair(r,a,b) -> PatPair(g r,f a,f b)
    | PatSymbol(r,a) -> PatSymbol(g r,a)
    | PatRecordMembers(r,a) ->
        let a =
            a |> List.map (function
                | PatRecordMembersSymbol((r,a),b) -> PatRecordMembersSymbol((g r,a),f b)
                | PatRecordMembersInjectVar((r,a),b) -> PatRecordMembersInjectVar((g r,a),f b)
                )
        PatRecordMembers(g r, a)
    | PatActive(r,a,b) -> PatActive(g r,term a,f b)
    | PatOr(r,a,b) -> PatOr(g r,f a,f b)
    | PatAnd(r,a,b) -> PatAnd(g r,f a,f b)
    | PatValue(r,a) -> PatValue(g r,a)
    | PatDefaultValue(r,a) -> PatDefaultValue(g r,a)
    | PatWhen(r,a,b) -> PatWhen(g r,f a,term b)
    | PatNominal(r,a,b) -> PatNominal(g r,g' a,f b)

let bundle (l : Bundle) =
    match l with
    | [] -> failwith "Compiler error: Bundle should have at least one statement."
    | (_, TopAnd _) :: x' -> failwith "Compiler error: TopAnd should be eliminated during the first bundling step."
    | (_, TopRecInl _) :: _ as l ->
        l |> List.map (function
            | (offset, TopRecInl(r,a,b,c)) -> BundleRecInl(add_offset offset r, a, fold_offset_term offset b, c)
            | _ -> failwith "Compiler error: Recursive inl statements can only be followed by statements of the same type."
            )
        |> BundleRecTerm
    | (_, (TopUnion _ | TopNominal _)) :: _ as l ->
        l |> List.map (function 
            | (offset, TopNominal(r,a,b)) -> BundleNominal(add_offset offset r, add_offset_typevar_list offset a, fold_offset_ty offset b)
            | (offset, TopUnion(r,a,b)) -> BundleUnion(add_offset offset r, add_offset_typevar_list offset a, List.map (fold_offset_ty offset) b)
            | _ -> failwith "Compiler error: Recursive type statements can only be followed by statements of the same type."
            )
        |> BundleRecType
    | [offset, TopInl(r,a,b,c)] -> BundleInl(add_offset offset r, a, fold_offset_term offset b, c)
    | [offset, TopPrototype(r,a,b,c,d)] -> BundlePrototype(add_offset offset r, a, b, add_offset_typevar_list offset c, fold_offset_ty offset d)
    | [offset, TopType(r,a,b,c)] -> BundleType(add_offset offset r, a, add_offset_typevar_list offset b, fold_offset_ty offset c)
    | [offset, TopInstance(r,a,b,c,d)] -> BundleInstance(add_offset offset r, a, b, add_offset_typevar_list offset c, fold_offset_term offset d)
    | (_, (TopInl _ | TopPrototype _ | TopType _ | TopInstance _)) :: _ -> failwith "Compiler error: Regular top level statements should be singleton bundles."
        
// A mock typechecker to serve as scaffolding for editor support.
let mock x =
    let ranges = ResizeArray()
    let g x = ranges.Add(x, sprintf "id %i" ranges.Count)
    let rec ty = function
        | RawTTerm _ | RawTWildcard _ | RawTB _ | RawTMetaVar _ | RawTSymbol _ | RawTPrim _ -> ()
        | RawTVar(r,a) -> g r
        | RawTApply(_,a,b) | RawTPair(_,a,b) | RawTFun(_,a,b) -> ty a; ty b
        | RawTRecord(_,a) -> Map.iter (fun _ -> ty) a
        | RawTForall(_,_,a) | RawTArray(_,a) -> ty a
    and term x = 
        let p x = List.iter (fun (a,b) -> pattern a; term b) x
        match x with
        | RawReal _ | RawDefaultLit _ | RawSymbolCreate _ | RawLit _ | RawB _ -> ()
        | RawV(r,_) -> g r
        | RawType(_,a) -> ty a
        | RawMatch(_,a,b) -> term a; p b
        | RawFun(_,a) -> p a
        | RawJoinPoint(_,a) | RawForall(_,_,a) -> term a
        | RawRecBlock(_,a,b) -> List.iter (fun (a,b) -> g (fst a); term b) a; term b
        | RawRecordWith(_,a,b,c) -> 
            List.iter term a
            b |> List.iter (function
                | RawRecordWithSymbol(_,a) | RawRecordWithSymbolModify(_,a) -> term a
                | RawRecordWithInjectVar((r,_),a) | RawRecordWithInjectVarModify((r,_),a) -> g r; term a
                )
            c |> List.iter (function RawRecordWithoutSymbol _ -> () | RawRecordWithoutInjectVar(r,_) -> g r)
        | RawOp(_,_,a) -> List.iter term a
        | RawAnnot(_,a,b) -> term a; ty b
        | RawTypecase(_,a,b) -> ty a; List.iter (fun (a,b) -> ty a; term b) b
        | RawModuleOpen(_,a,_,b) -> g (fst a); term b
        | RawIfThen(_,a,b) | RawPairCreate(_,a,b) | RawSeq(_,a,b) | RawApply(_,a,b) -> term a; term b
        | RawIfThenElse(_,a,b,c) -> term a; term b; term c
    and pattern = function
        | PatValue _ | PatDefaultValue _ | PatSymbol _ | PatB _ | PatE _ -> ()
        | PatVar(r,_) -> g r
        | PatNominal(_,_,a) | PatDyn(_,a) | PatUnbox(_,a) -> pattern a
        | PatAnnot(_,a,b) -> pattern a; ty b
        | PatAnd(_,a,b) | PatOr(_,a,b) | PatPair(_,a,b) -> pattern a; pattern b
        | PatRecordMembers(_,a) ->
            a |> List.iter (function
                | PatRecordMembersSymbol((r,a),b) -> pattern b
                | PatRecordMembersInjectVar((r,a),b) -> g r; pattern b
                )
        | PatActive(_,a,b) -> term a; pattern b
        | PatWhen(_,a,b) -> pattern a; term b
        
    match x with
    | BundleRecType a ->
        a |> List.iter (function
            | BundleNominal(_,_,a) -> ty a
            | BundleUnion(_,_,a) -> List.iter ty a
            )
    | BundleRecTerm a ->
        a |> List.iter (function 
            | BundleRecInl(_,a,b,true) -> g (fst a); term b
            | BundleRecInl(_,_,_,false) -> ()
            )
    | BundleInl(_,a,b,true) -> g (fst a); term b
    | BundleInl(_,_,_,false) -> ()
    | BundlePrototype(_,_,_,_,d) -> ty d
    | BundleType(_,_,_,c) -> ty c
    | BundleInstance(_,_,_,_,d) -> term d

    let a = ranges.ToArray()
    let b = if 0 < a.Length then ["some error", fst a.[a.Length/2]] else []
    a,b

open Hopac
open Hopac.Infixes
open Hopac.Extensions

let server_typechecking (uri : string) = Job.delay <| fun () ->
    let req = Ch ()

    let rec waiting () = req ^=> extracting
    and extracting subreq = 
        waiting () <|> (IVar.read subreq ^=> fun (bundle,res) -> 
            let x = List.map (fun _ -> IVar()) bundle
            Hopac.start (IVar.fill res x)
            let x = List.zip bundle x
            processing x x
            )
    and processing data = function
        | [] -> waiting ()
        | (x,res) :: x' ->
            waiting () <|> Alt.prepareFun (fun () -> 
                Hopac.start (bundle x |> mock |> IVar.fill res)
                processing data x'
                )

    Job.server (waiting()) >>-. req

let server_hover (uri : string) = Job.delay <| fun () ->
    let req_tc, req_hov = Ch (), Ch ()

    let eval_req data (pos : Config.VSCPos) = 
        data |> List.tryPick (fun (offset, b) -> if offset <= pos.line then Some b else None)
        |> function  Some x -> x | None -> IVar()

    let value_of (pos : Config.VSCPos) ranges =
        ranges |> Array.tryPick (fun ((a,b) : Config.VSCRange, r : string) ->
            if pos.line = a.line && (a.character <= pos.character && pos.character < b.character) then Some r else None
            )

    let rec waiting data ret = 
        let ret_signal_none x = Option.iter ((|>) None) ret; x
        (req_tc ^=> (ret_signal_none >> extracting))
        <|> (req_hov ^=> (ret_signal_none >> processing data))
    and extracting subreq =
        (IVar.read subreq ^=> fun (bundle,res) -> IVar.read res ^=> fun x -> waiting (List.map2 (fun a b -> fst (List.head a), b) bundle x) None)
    and processing data (pos, ret) =
        waiting data (Some ret)
        <|> Alt.prepareFun (fun () -> IVar.read (eval_req data pos) ^=> fun (range,_) -> value_of pos range |> ret; waiting data None)

    Job.server (waiting [] None) >>-. (req_tc, req_hov)