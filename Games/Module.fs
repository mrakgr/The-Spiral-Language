module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module
open System.Collections.Generic
open System.Security.Policy

let dictionary =
    (
    "Dictionary",[],"The Dictionary module.",
    """
inl ty elem_type = fs [text: "System.Collections.Generic.Dictionary"; types: elem_type]
inl {d with elem_type} ->
    inl elem_type = type elem_type
    inl key, value = elem_type
    inl ty = ty elem_type
    inl capacity = 
        match d with
        | {capacity} -> capacity : int32
        | _ -> 64i32
    inl id =
        match d with
        | {id} -> id
        | _ -> .structural
    inl x = 
        match id with
        | .structural -> macro.fs ty [type: ty; iter: "(",",",")", [arg: capacity; text: "HashIdentity.Structural"]]
        | .reference -> macro.fs ty [type: ty; iter: "(",",",")", [arg: capacity; text: "HashIdentity.Reference"]]
    inl elem_type = stack {key value}
    function
    | .set i v ->
        assert (eq_type elem_type.key i) {msg="The index's type is not the equal to that of the key."; key i}
        assert (eq_type elem_type.value v) {msg="The second argument's type is not the equal to that of the value."; value v}
        macro.fs () [arg: x; text: ".["; arg: i; text: "] <- "; arg: v]
    | i {on_succ on_fail} ->
        assert (eq_type key i) {msg="The index's type is not the equal to that of the key."; key i}
        macro.fs () [arg: x; text: ".TryGetValue"; args: i; text: " |> fun (a,b) -> ";]
        inl a = macro.fs bool [text: "a"]
        inl b = macro.fs elem_type.value [text: "b"]
        if a then on_succ b else on_fail ()
    """) |> module_