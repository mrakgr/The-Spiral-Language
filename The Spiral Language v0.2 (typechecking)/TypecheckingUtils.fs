module Spiral.TypecheckingUtils

open VSCTypes
open Spiral.BlockParsing

type BundleItem = { offset : int; statement : TopStatement}
type Bundle = BundleItem list

// These bundles have their range offsets distributed into them.
type BundleTop =
    | BundleType of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | BundleNominal of VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr
    | BundleNominalRec of (VSCRange * (VSCRange * VarString) * HoVar list * RawTExpr) list
    | BundleInl of VSCRange * (VSCRange * VarString) * RawExpr * is_top_down: bool
    | BundleRecInl of (VSCRange * (VSCRange * VarString) * RawExpr) list * is_top_down: bool
    | BundlePrototype of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawTExpr
    | BundleInstance of VSCRange * (VSCRange * VarString) * (VSCRange * VarString) * TypeVar list * RawExpr

let bundle_top_range = function
    | BundleType(r,_,_,_) | BundleNominal(r,_,_,_) | BundleInl(r,_,_,_) | BundlePrototype(r,_,_,_,_) | BundleInstance(r,_,_,_,_) -> r
    | BundleNominalRec l -> List.head l |> fun (r,_,_,_) -> r
    | BundleRecInl(l,_) -> List.head l |> fun (r,_,_) -> r

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
        ) a
and fold_offset_term offset x = 
    let f = fold_offset_term offset
    let ty = fold_offset_ty offset
    let g = add_offset offset
    match x with
    | RawB r -> RawB (g r)
    | RawV(r,a) -> RawV (g r,a)
    | RawBigV(r,a) -> RawBigV (g r,a)
    | RawLit(r,a) -> RawLit (g r,a)
    | RawDefaultLit(r,a) -> RawDefaultLit (g r,a)
    | RawSymbol(r,a) -> RawSymbol (g r,a)
    | RawType(r,a) -> RawType(g r,a)
    | RawMatch(r,a,b) -> RawMatch(g r,f a,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) b)
    | RawFun(r,a) -> RawFun(g r,List.map (fun (a,b) -> fold_offset_pattern offset a,f b) a)
    | RawForall(r,a,b) -> RawForall(g r,add_offset_typevar offset a,f b)
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
    | RawJoinPoint(r,a) -> RawJoinPoint(g r,f a)
    | RawAnnot(r,a,b) -> RawAnnot(g r,f a,ty b)
    | RawTypecase(r,a,b) -> RawTypecase(g r,ty a,List.map (fun (a,b) -> ty a,f b) b)
    | RawModuleOpen(r,a,b,c) -> RawModuleOpen(g r,add_offset_hovar offset a,add_offset_hovar_list offset b,f c)
    | RawApply(r,a,b) -> RawApply(g r,f a,f b)
    | RawIfThenElse(r,a,b,c) -> RawIfThenElse(g r,f a,f b,f c)
    | RawIfThen(r,a,b) -> RawIfThen(g r,f a,f b)
    | RawPair(r,a,b) -> RawPair(g r,f a,f b)
    | RawSeq(r,a,b) -> RawSeq(g r,f a,f b)
    | RawHeapMutableSet(r,a,b,c) -> RawHeapMutableSet(g r,f a,List.map f b,f c)
    | RawReal(r,a) -> RawReal(g r,f a)
    | RawMissingBody r -> RawMissingBody(g r)
    | RawMacro(r,a) -> RawMacro(g r,fold_offset_macro offset a)
    | RawFilledPairStrip(r,a,b) -> RawFilledPairStrip(g r,a,f b)
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
        PatRecordMembers(g r,a)
    | PatOr(r,a,b) -> PatOr(g r,f a,f b)
    | PatAnd(r,a,b) -> PatAnd(g r,f a,f b)
    | PatValue(r,a) -> PatValue(g r,a)
    | PatDefaultValue(r,a) -> PatDefaultValue(g r,a)
    | PatWhen(r,a,b) -> PatWhen(g r,f a,term b)
    | PatNominal(r,a,b) -> PatNominal(g r,g' a,f b)

let bundle_top (l : Bundle) =
    match l with
    | [] -> failwith "Compiler error: Bundle should have at least one statement."
    | {statement=TopAnd _} :: x' -> failwith "Compiler error: TopAnd should be eliminated during the first bundling step."
    | {statement=TopRecInl _} :: _ as l ->
        l |> List.mapFold (fun _ -> function
            | {offset=i; statement=TopRecInl(r,a,b,c)} -> (add_offset i r, add_offset_hovar i a, fold_offset_term i b), c
            | _ -> failwith "Compiler error: Recursive inl statements can only be followed by statements of the same type."
            ) true
        |> BundleRecInl
    | {statement=TopNominalRec _} :: _ as l ->
        l |> List.map (function 
            | {offset=i; statement=TopNominalRec(r,a,b,c)} -> (add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c)
            | _ -> failwith "Compiler error: Recursive type statements can only be followed by statements of the same type."
            )
        |> BundleNominalRec
    | [{offset=i; statement=TopInl(r,a,b,c)}] -> BundleInl(add_offset i r, add_offset_hovar i a, fold_offset_term i b, c)
    | [{offset=i; statement=TopPrototype(r,a,b,c,d)}] -> BundlePrototype(add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_ty i d)
    | [{offset=i; statement=TopNominal(r,a,b,c)}] -> BundleNominal(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c)
    | [{offset=i; statement=TopType(r,a,b,c)}] -> BundleType(add_offset i r, add_offset_hovar i a, add_offset_hovar_list i b, fold_offset_ty i c)
    | [{offset=i; statement=TopInstance(r,a,b,c,d)}] -> BundleInstance(add_offset i r, add_offset_hovar i a, add_offset_hovar i b, add_offset_typevar_list i c, fold_offset_term i d)
    | {statement=TopInl _ | TopPrototype _ | TopNominal _ | TopType _ | TopInstance _} :: _ -> failwith "Compiler error: Regular top level statements should be singleton bundles."
