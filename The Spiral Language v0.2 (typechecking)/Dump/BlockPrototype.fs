module Spiral.BlockPrototype

open System
open System.Threading
open System.Collections.Generic
open Hopac
open Hopac.Infixes
open Hopac.Extensions
open Config

type E = string * Range
type T =
| Init of Result<string, E []>
| Body of Result<string, E []>

let block parse i (x : string []) =
    let seq_init = ResizeArray()
    let seq_body = ResizeArray()
    let seq_errors = ResizeArray()

    let rec body i =
        if i < Array.length x then
            match parse x.[i] with
            | Init _ -> i
            | Body(Ok x) -> seq_body.Add x; body (i+1)
            | Body(Error l) -> seq_errors.AddRange l; body (i+1)
        else
            i

    let rec initial i =
        if i < Array.length x then
            match parse x.[i] with
            | Init(Ok x) -> seq_init.Add x; initial (i+1)
            | Init(Error l) -> seq_errors.AddRange l; initial (i+1)
            | Body(Ok x) -> seq_body.Add x; body (i+1)
            | Body(Error l) -> seq_errors.AddRange l; body (i+1)
        else
            i

    let i = initial i

    if seq_errors.Count > 0 then Error(seq_errors.ToArray())
    else Ok(i, {|init=seq_init.ToArray(); body=seq_body.ToArray()|})