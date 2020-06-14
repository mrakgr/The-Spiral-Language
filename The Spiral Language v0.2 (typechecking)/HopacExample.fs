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
    let split req res1 res2 = Job.delay <| fun () ->
        let res1, res2 = Ch (), Ch()
        Job.start (
            let rec loop (res1, res2) =
                Ch.take req >>= function
                    | Some _ as x -> Ch.give res1 x >>=. loop (res2, res1)
                    | None -> Ch.give res1 None >>=. Ch.give res2 None
            Ch.take req >>= function
                | Some _ as a ->
                | None -> Job.unit()
            loop (res2, res1)
            )
        >>-. (res1, res2)

    let merge req1 req2 res =
        Job.start (
            let rec loop_one req = Ch.take req >>= fun x -> 
                Ch.give res x >>=. if Option.isSome x then loop_one req else Job.unit()
            let rec loop_both () =
                Ch.take req1 >>= function 
                    | None -> loop_one req2
                    | Some a as a' ->
                        Ch.take req2 >>= function
                            | None -> Ch.give res a' >>=. loop_one req1
                            | Some b as b' -> 
                                let f a b = Ch.give res a >>=. Ch.give res b >>= loop_both
                                if a < b then f a' b' else f b' a'
            loop_both ()
            )

    let rec sort req = Job.delay <| fun () ->
        let res = Ch()
        Job.start (
            split req (fun s1 s2 ->
                sort s1 >>= fun s1 ->
                sort s2 >>= fun s2 ->
                merge res s1 s2
                ) (merge res)
        ) >>-. res

    let give_array c l = Job.start (Array.iterJob (Some >> Ch.give c) l >>=. Ch.give c None)
    let rec read_all msg c = Job.foreverServer (Ch.take c >>- printfn "%s - %A" msg)

    let test_split = job {
        let l = [|3;2;1|]
        let c = Ch ()
        do! give_array c l
        let! s1,s2 = split (Some 4) c
        let res = Ch ()
        do! merge s1 s2 res
        do! read_all "res" res
        }

    let main = job {
        let l = [|4;3;2;1|]
        let c = Ch ()
        do! give_array c l
        let! r = sort c
        do! read_all "r" r
        }



MergeSort.main |> run
System.Console.ReadKey()