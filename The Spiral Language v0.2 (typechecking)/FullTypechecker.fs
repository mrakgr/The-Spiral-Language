module Spiral.FullTypechecker
open Spiral.BlockParsing
open Spiral.TypecheckingUtils
        
// A mock typechecker to serve as scaffolding for editor support.
let mock id_count x =
    let ranges = ResizeArray()
    let g x = ranges.Add(x, sprintf "id %i" (id_count + ranges.Count))
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
            | BundleNominal(_,_,_,a) -> ty a
            | BundleUnion(_,_,_,a) -> List.iter ty a
            )
    | BundleRecTerm a ->
        a |> List.iter (function 
            | BundleRecInl(_,a,b,true) -> g (fst a); term b
            | BundleRecInl(_,_,_,false) -> ()
            )
    | BundleInl(_,a,b,true) -> g (fst a); term b
    | BundleInl(_,_,_,false) -> ()
    | BundlePrototype(_,_,_,a) | BundleType(_,_,_,a) -> ty a
    | BundleInstance(_,_,_,_,d) -> term d

    let a = ranges.ToArray()
    let b = if 0 < a.Length then ["some error", fst a.[a.Length/2]] else []
    (a,b), id_count + a.Length

open Hopac
open Hopac.Infixes
open Hopac.Extensions

let server_typechecking (uri : string) = Job.delay <| fun () ->
    let req = Ch ()

    let rec waiting data = req ^=> extracting data
    and extracting data subreq = 
        waiting data <|> (IVar.read subreq ^=> fun (bundle,res) -> 
            let rec loop = function // Does memoization by fetching previous computed values.
                | [], bundle -> List.map (fun _ -> IVar()) bundle
                | (a, ivar) :: a', (b :: b' as bundle) -> if a = b then ivar :: loop (a',b') else loop ([], bundle)
                | _, [] -> []
            let x = loop (data, bundle)
            Hopac.start (IVar.fill res x)
            let x = List.zip bundle x
            processing 0 x x
            )
    and processing state data = function
        | [] -> waiting data
        | (x,res) :: x' ->
            waiting data <|> Alt.prepareFun (fun () -> 
                if res.Full then IVar.read res ^=> fun (_,state) -> processing state data x'
                else 
                    let (_,state as x) = bundle x |> mock state
                    Hopac.start (IVar.fill res x)
                    processing state data x'
                )

    Job.server (waiting []) >>-. req

let server_hover (uri : string) = Job.delay <| fun () ->
    let req_tc, req_hov = Ch (), Ch ()

    let block_at data (pos : Config.VSCPos) = 
        let rec loop = function // tryPick from the back
            | (offset,b) :: x' ->
                match loop x' with
                | ValueSome _ as x -> x
                | ValueNone -> if offset <= pos.line then ValueSome b else ValueNone
            | [] -> ValueNone
        loop data |> function ValueSome x -> x | ValueNone -> IVar()

    let hover_msg_at (pos : Config.VSCPos) ranges =
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
        <|> Alt.prepareFun (fun () -> IVar.read (block_at data pos) ^=> fun ((range,_),_) -> hover_msg_at pos range |> ret; waiting data None)

    Job.server (waiting [] None) >>-. (req_tc, req_hov)