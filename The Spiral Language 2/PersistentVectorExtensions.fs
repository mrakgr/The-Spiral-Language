module PersistentVector
open System
open FSharpx.Collections

let private range_checks from near_to vec =
    if from <= near_to = false then raise (ArgumentException("`from` must be less or equal to `near_to`."))
    if from < 0 then raise (ArgumentException("`from` must not be negative."))
    if PersistentVector.length vec < near_to then raise (ArgumentException("`near_to` must not be beyond the length of the vector."))

/// O(n+m). Replace the specified range in a vector with the sequence.
let replace from near_to seq vec =
    range_checks from near_to vec
    let rec rest s =
        if from < PersistentVector.length s then
            PersistentVector.unconj s |> fst |> rest
        else
            Seq.fold (fun s x -> PersistentVector.conj x s) s seq
    let rec init s =
        if near_to < PersistentVector.length s then
            let s',x = PersistentVector.unconj s
            PersistentVector.conj x (init s')
        else
            rest s
    init vec

/// O(n). Returns a vector of the supplied length using the supplied function operating on the index.
let mapi f vec = PersistentVector.init (PersistentVector.length vec) (fun i -> f i vec.[i])

/// O(n). Iterates over a vector using the supplied function operating on the index.
let iter f vec = 
    let rec loop i = if i < PersistentVector.length vec then f vec.[i]
    loop 0

/// O(n). Unzips a vector of pairs into pairs of vectors.
let unzip vec = 
    let mutable a = PersistentVector.empty
    let mutable b = PersistentVector.empty
    iter (fun (a',b') -> a <- PersistentVector.conj a' a; b <- PersistentVector.conj b' b) vec
    a,b
        
/// O(n). Concatenates a vector of vectors.
let concat vec = PersistentVector.fold (PersistentVector.append) PersistentVector.empty vec

/// O(near_to-from). Get the vector at a range.
let range from near_to vec =
    range_checks from near_to vec
    PersistentVector.init (near_to-from) (fun i -> vec.[i+from])

/// O(~n). Returns the last element for which a given function returns true. None if such an element does not exist.
let tryFindBack f vec =
    let rec loop i =
        if 0 <= i then 
            let x = PersistentVector.nth i vec
            if f x then Some x else loop (i-1)
        else
            None
    loop (PersistentVector.length vec - 1)