module Spiral.WDiff

open System
open System.IO
open System.Collections.Generic
open FSharpx.Collections

open VSCTypes
open Spiral
open Spiral.Tokenize
open Spiral.BlockSplitting
open Spiral.TypecheckingUtils
open Spiral.Infer

type SpiEdit = {|from: int; nearTo: int; lines: string []|}
type TokReq =
    | DocumentAll of string []
    | DocumentEdit of SpiEdit

let liner lines req =
    let replace (edit : SpiEdit) = PersistentVector.replace edit.from edit.nearTo edit.lines lines
    match req with
    | DocumentAll text -> replace {|from=0; nearTo=lines.Length; lines=text|}
    | DocumentEdit edit -> replace edit