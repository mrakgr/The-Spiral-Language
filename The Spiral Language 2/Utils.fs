module Spiral.Utils

open System.Collections.Generic
open System.Runtime.CompilerServices

let list_try_zip a b = try Some (List.zip a b) with _ -> None

let inline get_default (memo_dict: Dictionary<_,_>) k def =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> def()
let inline memoize' (memo_dict: ConditionalWeakTable<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v
let inline memoize (memo_dict: Dictionary<_,_>) f k =
    match memo_dict.TryGetValue k with
    | true, v -> v
    | false, _ -> let v = f k in memo_dict.Add(k,v); v
let lines (str : string) = str.Split([|"\r\n";"\r";"\n"|],System.StringSplitOptions.None)
let inline remove (dict : Dictionary<_,_>) x on_succ on_fail =
    let mutable q = Unchecked.defaultof<_>
    if dict.Remove(x, &q) then on_succ q else on_fail ()
let file_uri (x : string) = if x.StartsWith '/' then "file://" + x else "file:///" + x

//open Hopac
//open Hopac.Infixes
//open Hopac.Extensions
//open Hopac.Stream

//let print_ch = Ch<string>()
//let pr x = Hopac.run (Ch.send print_ch (x.ToString()))