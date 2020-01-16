module Spiral.PrepassGlobalInlining
open Spiral.Parsing

type GIEnv = {values : Map<string,RawExpr>; types : Map<string,RawTypeExpr>}

let global_inline (env : GIEnv) x =
    match x with
    | RawLet(name,RawInl(arg,body),on_succ) -> ()
    | RawRecBlock(l,on_succ) -> failwith ""
    | _ -> failwith "Compiler error"