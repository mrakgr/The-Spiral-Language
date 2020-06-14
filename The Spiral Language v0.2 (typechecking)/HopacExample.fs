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

Fib.main |> run