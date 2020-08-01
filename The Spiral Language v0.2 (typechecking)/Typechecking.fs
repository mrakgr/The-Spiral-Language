module Spiral.Typechecking

open Spiral.Config
open Spiral.BlockParsing
open Spiral.Blockize

type TT =
    | KindStar
    | KindFun of TT * TT
    | KindMetavar of int

type T =
    | TyB
    | TyPrim of PrimitiveType
    | TySymbol of string
    | TyPair of T * T
    | TyRecord of Map<string, T>
    | TyFun of T * T
    | TyForall of (string * TT) * T
    | TyArray of T
    | TyHigherOrder of int * TT
    | TyApp of T * T * TT // Regular type functions (TyInl) get reduced, while this represents the staged reduction of nominals.
    | TyInl of Map<string,T> * (string * TT) list * T
    | TyVar of string * TT // Staged type vars. Should only appear in TyInl's body. 
    | TyMetavar of int * TT

let tt = function
    | TyHigherOrder(_,x) | TyApp(_,_,x) | TyMetavar(_,x) | TyVar(_,x) -> x
    | TyPrim _ | TyForall _ | TyFun _ | TyRecord _ | TyPair _ | TySymbol _ | TyArray _ -> KindStar
    | TyInl(_,x,_) -> List.foldBack (fun (_,a) b -> KindFun(a,b)) x KindStar

let rec typevar = function
    | RawKindStar -> KindStar
    | RawKindFun(a,b) -> KindFun(typevar a, typevar b)
let typevars (l : TypeVar list) =
    List.map (fun (_,(a,b)) -> a, typevar b) l

let rec eval (expr : RawTExpr) (env : Map<string, T>) =
    let f x = eval x env
    match expr with
    | RawTB _ -> TyB
    | RawTSymbol(r,x) -> TySymbol x
    | RawTForall(r,(_,a),b) -> TyForall((fst a, typevar (snd a)), f b)
    | RawTPrim(_,x) -> TyPrim x
    | RawTArray(_,x) -> TyArray(f x)
    | RawTMetaVar _
    | RawTWildcard _
    | RawTTerm _ -> failwith "Compiler error: Invalid node in this function."
    | RawTVar(r,n) -> env.[n]
    | RawTPair(r,a,b) -> TyPair(f a, f b)
    | RawTFun(r,a,b) -> TyFun(f a, f b)
    | RawTRecord(r,l) -> TyRecord(Map.map (fun _ -> f) l)
    | RawTApply -> failwith "TODO"

let top_type (name : VarString, vars : TypeVar list, expr : RawTExpr) (env : Map<string, T>) =
    let vars = typevars vars
    let body = eval expr (List.fold (fun s (k,v) -> Map.add k (TyVar (k,v)) s) env vars)
    Map.add name (TyInl(Map.empty,vars,body)) env

let tc (l : Bundle list) = 
    ()
    