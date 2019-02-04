module Spiral.PartEval

// Global open
open System
open System.Collections.Generic
open Parsing
open Types

// Globals
let join_point_dict_method = d0()
let join_point_dict_closure = d0()
let join_point_dict_type = d0()
let join_point_dict_cuda = d0()

let spiral_partial_eval (d: LangEnv) x = 
    match x with
    | V(_, x) -> let l = d.env_global.Length in if x < l then d.env_global.[x] else d.env_stack.[x - l]
    //| Lit of Tag * Value
    //| Open of Tag * VarTag * KeywordTag [] * Expr
    //| Function of Tag * Expr * FreeVars * StackSize
    //| RecFunction of Tag * Expr * FreeVars * StackSize
    //| ObjectCreate of ObjectDict * FreeVars
    //| KeywordCreate of Tag * KeywordTag * Expr []
    //| Let of Tag * bind: Expr * on_succ: Expr
    //| Case of Tag * bind: Expr * on_succ: Expr
    //| If of Tag * cond: Expr * on_succ: Expr * on_fail: Expr
    //| ListTakeAllTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| ListTakeNTest of Tag * StackSize * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| KeywordTest of Tag * KeywordTag * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordTest of Tag * RecordTestPattern [] * bind: VarTag * on_succ: Expr * on_fail: Expr
    //| RecordWith of Tag * Expr [] * RecordWithPattern []
    //| ExprPos of Tag * Pos<Expr>
    //| Op of Tag * Op * Expr []
    //failwith ""