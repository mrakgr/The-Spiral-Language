module MyPicklers

open System

type 'a PU = {
    pickle : 'a -> byte []
    unpickle : int -> byte [] -> 'a * int
    }

let int : int PU = {
    pickle = BitConverter.GetBytes
    unpickle = fun i x -> BitConverter.ToInt32(x,i), i+4
    }

let tup2 (pa : 'a PU) (pb : 'b PU) : ('a * 'b) PU =  {
    pickle = fun (a,b) -> [|pa.pickle a; pb.pickle b|] |> Array.concat
    unpickle = fun i x -> 
        let a,i = pa.unpickle i x
        let b,i = pb.unpickle i x
        (a,b),i
    }

let rec list (pa : 'a PU) : 'a list PU = {
    pickle = fun l ->
        let rec loop = function
            | x :: xs -> [|BitConverter.GetBytes(1); pa.pickle x; loop xs|] |> Array.concat
            | [] -> BitConverter.GetBytes(0)
        loop l
    unpickle = fun i l -> 
        let rec loop i =
            let tag, i = int.unpickle i l
            match tag with
            | 0 ->
                [], i
            | 1 ->
                let x, i = pa.unpickle i l
                let xs, i = loop i
                x :: xs, i
            | _ -> failwith "impossible"
        loop i
    }

let wrap ab ba (pa : 'a PU) : 'b PU = {
    pickle = ba >> pa.pickle
    unpickle = fun i x -> pa.unpickle i x |> fun (a,i) -> ab a, i
    }

let alt (tag : 'a -> int) (l : 'a PU list) : 'a PU = {
    pickle = fun x -> let tag = tag x in [|BitConverter.GetBytes(tag); l.[tag].pickle x|] |> Array.concat
    unpickle = fun i x ->
        let tag,i = int.unpickle i x
        l.[tag].unpickle i x
    }

let rec list' (pa : 'a PU) : 'a list PU = 
    alt (function [] -> 0 | (x :: xs) -> 1) [
        {
        pickle = fun [] -> [||]
        unpickle = fun i l -> [], i
        }
        {
        pickle = fun (x :: xs) -> [|pa.pickle x; (list' pa).pickle xs|] |> Array.concat
        unpickle = fun i l ->
            let x, i = pa.unpickle i l
            let xs, i = (list' pa).unpickle i l
            x :: xs, i
        }
        ]
    
type LR = {left : int; right : int}

let p = list' (wrap (fun (a,b) -> {left=a; right=b}) (fun x -> x.left,x.right) (tup2 int int))
p.pickle ([{left=1;right=2}; {left=3;right=4}]) |> p.unpickle 0 |> printfn "%A"