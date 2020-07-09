module Spiral.BlockParsing
open Spiral.ParserCombinators

type Env = {
    l : Tokenize.LineToken [] []
    row : int ref
    col : int ref
    semicolon_line : int
    keyword_line : int
    is_top_down : bool
    } with

    member t.Index with get() = t.row.contents, t.col.contents and set(row,col) = t.row := row; t.col := col

let index (t : Env) = t.Index
let index_set v (t : Env) = t.Index <- v

let top_let s = failwith "TODO" s
let top_inl s = failwith "TODO" s
let top_nominal s = failwith "TODO" s
let top_proto s = failwith "TODO" s
let top_union s = failwith "TODO" s
let comments s = failwith "TODO" s

let top_statement s =
    let i = index s
    let inline (+) a b = alt i a b
    comments (top_let + top_inl + top_nominal + top_proto + top_union) s