#nowarn "40"
open Hopac
open Hopac.Infixes
open Hopac.Extensions

module Sieve =
    let counter i = let c = Ch() in Job.iterateServer i (fun i -> Ch.give c i >>-. (i+1)) >>-. c

    let filter p req =
        let res = Ch()
        let loop = req >>= fun i -> if i % p <> 0 then Ch.give res i else Alt.unit()
        Job.foreverServer loop >>-. res

    let sieve = Job.delay <| fun () ->
        let primes = Ch()
        let head c = Ch.take c >>= fun p -> Ch.give primes p >>=. filter p c
        counter 2 >>= (fun i -> Job.iterateServer i head) >>-. primes

    let main = job {
        let! c = sieve
        for i= 1 to 10 do
            do! Ch.take c >>- printfn "%i"
        }

module Fib =
    let add req1 req2 res = Job.foreverServer (Ch.take req1 >>= fun a -> Ch.take req2 >>= fun b -> Ch.give res (a+b))
    let delay init req res = Job.iterateServer init (fun x -> Ch.give res x >>=. Ch.take req)
    let copy req res1 res2 = Job.foreverServer (Ch.take req >>= fun x -> Ch.give res1 x >>=. Ch.give res2 x)

    let fib = Job.delay <| fun () ->
        let res = Ch ()
        let c1,c2,c3,c4,c5 = Ch (),Ch (),Ch (),Ch (),Ch ()
        delay 0 c4 c5 >>=.
        copy c2 c3 c4 >>=.
        add c3 c5 c1 >>=.
        copy c1 c2 res >>=.
        Ch.send c1 1 >>-.
        res

    let main = job {
        let! c = fib
        for i=1 to 10 do 
            do! Ch.take c >>- printfn "%i"
        }

module MergeSort =
    let rec split req res1 res2 =
        Ch.take req >>= function
            | Some _ as x -> Ch.give res1 x >>=. split req res2 res1
            | None -> Ch.give res1 None >>=. Ch.give res2 None

    let merge req1 req2 res =
        let rec loop a b =
            let f (x, req) b = Ch.give res x >>=. Ch.take req >>= fun x -> loop (x, req) b
            match fst a, fst b with
            | Some a', Some b' -> if a' < b' then f a b else f b a
            | Some _, None -> f a b
            | None, Some _ -> f b a
            | None, None -> Ch.give res None :> _ Job
        Ch.take req1 >>= fun a -> 
        Ch.take req2 >>= fun b ->
        loop (a,req1) (b,req2)
    
    let rec sort = Job.delay <| fun () ->
        let c = Ch()

        Job.start (
            Ch.take c >>= function
                | None -> Ch.give c None :> _ Job
                | Some _ as v1 ->
                    Ch.take c >>= function
                        | None -> Ch.give c v1 >>=. Ch.give c None
                        | Some _ as v2 ->
                            sort >>= fun c1 ->
                            Ch.give c1 v1 >>=.
                            sort >>= fun c2 ->
                            Ch.give c2 v2 >>=.
                            split c c1 c2 >>=.
                            merge c1 c2 c
        ) >>-. c

    let give_array c l = Job.start (Array.iterJob (Some >> Ch.give c) l >>=. Ch.give c None)
    let rec read_all msg c = Job.foreverServer (Ch.take c >>- printfn "%s - %A" msg)

    let main = job {
        let l = [|6;5;4;3;2;1|]
        let! c = sort
        do! give_array c l
        do! read_all "c" c
        }

// This particular example is not transcribed directly from the book, but is instead implemented using
// streams. The way it is done in the book is too much of a mess so I switched to this. I just could not
// bear it and it was a good opportunity to get familiar with streams since I am going to be using them
// to do editor support for Spiral.
module PowerSeries =
    open Hopac.Stream
    let rec add F G = F >>=* function Nil -> G | Cons(f,F') -> G >>=* function Nil -> F | Cons(g,G') -> cons (f+g) (add F' G')
    let mul_by_const c F = Stream.mapFun (fun x -> c * x) F
    let mul_by_term F = Stream.cons 0.0 F
    let rec mul (F : _ Stream) (G : _ Stream) : _ Stream =
        let ht F on_head = F >>=* function Nil -> Stream.nil | Cons(h,t) -> on_head (h,t)
        ht F <| fun (f,F) ->
        ht G <| fun (g,G) ->
        cons (f*g) (add (mul_by_term (mul F G)) (add (mul_by_const f G) (mul_by_const g F)))

    let main = 
        let l = [1.0;2.0;3.0;4.0;5.0;6.0] |> Stream.ofSeq
        ((mul l l |> Stream.toSeq) >>- (Seq.toArray >> printfn "%A"))
        
PowerSeries.main |> run