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

let poker =
    (
    "Poker",[random;console;option],"The Poker module.",
    """
inl Suits = .Spades, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank; suit=Suit}

inl num_cards = 
    inl l = Tuple.foldl (inl s _ -> s+1) 0
    l Suits * l Ranks

inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Suits |> fst
   
inl deck _ =
    met knuth_shuffle rnd ln ar =
        inl swap i j =
            inl item = ar i
            ar i <- ar j
            ar j <- item

        Loops.for {from=0; near_to=ln-1; body=inl {i} -> swap i (rnd.next(to int32 i, to int32 ln))}

    inl unshuffled = 
        Tuple.map (inl rank ->
            Tuple.map (inl suit -> box Card {rank=box Rank rank; suit=box Suit suit}) Suits
            ) Ranks
        |> Tuple.concat

    inl ty = array Card
    inl ar = macro.fs ty [fs_array_args: unshuffled; text: ": "; type: ty]
    assert (array_length ar = num_cards) "The number of cards in the deck must be 52."
    inl rnd = Random()
    knuth_shuffle rnd num_cards ar

    inl rec facade p _ =
        inl x = p - 1
        ar x, facade x
    facade (dyn num_cards)

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_card x =
    inl {rank=.(a) suit=.(b)} = x 
    string_format "{0}-{1}" (a, b)

inl log ->
    inl Hand = Card // for one card poker
    inl show_hand = show_card

    inl showdown rule players =
        inl is_active {pot} = pot > 0
        inl iterator_template is_active =
            {
            foldl = inl f s players -> Tuple.foldl2 (inl s player is_active -> if is_active then f s player else s) s players is_active
            foldl_map = inl f s players -> Tuple.foldl_map2 (inl s player is_active -> if is_active then f s player else player,s) s players is_active
            }

        log "Showdown:" ()
        Tuple.iter (met x ->
            if is_active x then
                match x.hand with
                | .Some, hand -> log "{0} shows {1}" (x.name, show_hand hand)
                | _ -> ()
            ) players

        inl old_chips = Tuple.map (inl {chips + pot} -> chips + pot) players

        met rec loop players =
            inl is_active = Tuple.map is_active players
            inl {foldl foldl_map} = iterator_template is_active

            foldl (inl s player ->
                match s with
                | .Some, a ->
                    match player.hand with
                    | .Some, b -> if rule a b = 1i32 then Option.some a else Option.some b
                    | .None -> Option.some a
                | .None -> player.hand
                ) (Option.none Hand)
            |> function
                | .Some, winning_hand ->
                    inl min_pot = foldl (inl s {pot} -> min s pot) (macro.fs int64 [text: "System.Int64.MaxValue"]) players
                    inl players, pot = 
                        foldl_map (inl s {player with pot} -> 
                            inl taken = min min_pot pot
                            {player with pot=pot-taken}, s + taken) 0 players

                    inl winners = 
                        foldl_map (inl _ x ->
                            match x.hand with
                            | .Some, hand -> if rule winning_hand hand = 0i32 then true, () else false, ()
                            | _ -> false
                            ) () players |> fst
                    inl {foldl foldl_map} = iterator_template winners

                    inl num_winners = foldl (inl s _ -> s + 1) 0 players

                    inl could_be_odd = pot % num_winners <> 0
                    inl pot = pot / num_winners
                    foldl_map (inl s x ->
                        inl odd_chip = if s && could_be_odd then 0 else 1
                        {x with chips=self + pot + odd_chip}, false
                        ) true players 
                    |> fst
                    |> loop
                | .None ->
                    Tuple.map (inl x -> x.chips) players
            : Tuple.map (inl x -> x.chips) players
        inl new_chips = Tuple.map (inl {hand chips pot} -> {hand chips pot}) players |> loop
        inl rewards = Tuple.map2 (inl old new -> new - old) old_chips new_chips

        Tuple.iter (met player reward -> 
            player.reply.unwrap reward
            if reward > 0 then log "{0} wins {1} chips." (x.name,reward)
            elif reward < 0 then log "{0} loses {1} chips." (x.name,-reward)
            else ()
            ) players rewards

        new_chips

    inl internal_representation i {board players} =
        {
        players=
            Tuple.mapi (inl i' {chips pot hand} ->
                if i' <> i then {chips pot hand=dyn (Option.none Hand)}
                else {chips pot hand}
                ) players
        board
        }

    inl hand_is = function
        | .Some, _ -> true
        | _ -> false

    inl fold player = {player with hand = Option.none Hand}
    inl call {player with chips} x = 
        inl x = min chips x
        {player with chips=self-x; pot=self+x}

    inl betting state =
        inl is_active {chips hand} = chips > 0 && hand_is hand
        met betting {internal_representation player} {d with min_raise call_level players_called players_active} =
            inl on_succ=Option.some
            inl on_fail=Option.none (player,d)
            if players_called < players_active then
                if is_active player then
                    player.reply internal_representation
                        {
                        fold = inl player -> 
                            inl player = fold player
                            log "{0} folds." player.name
                            on_succ (player, {d with players_active=self-1})
                        call = inl player -> 
                            inl player,_ = call player call_level
                            inl on_succ d = player, d
                            if player.chips = 0 then
                                log "{0} calls and is all-in!" player.name
                                on_succ {d with players_active=self-1}
                            else
                                log "{0} calls." player.name
                                on_succ {d with players_called=self+1}
                        raise = inl player x -> 
                            assert (x > 0) "Cannot raise to negative amounts."
                            inl player, call_level' = call player (call_level + min_raise + x)
                            inl on_succ {gt lte} =
                                if call_level' > call_level then on_succ (player, gt {d with call_level = call_level'; min_raise = call_level'-call_level} )
                                else on_succ (player, lte d)
                                
                            if player.chips = 0 then
                                on_succ {
                                    gt = inl d -> 
                                        log "{0} raises to {1} and is all-in!" (player.name, call_level')
                                        {d with players_active=self-1; players_called=dyn 0}
                                    lte = inl d -> 
                                        log "{0} calls and is all-in!" player.name
                                        {d with players_active=self-1}
                                    }
                            else
                                log "{0} raises to {1}." (player.name, call_level')
                                on_succ {
                                    gt = inl d -> {d with players_called=dyn 1}
                                    lte = inl _ -> failwith on_fail "Should not be possible to raise to less than the call level without running out of chips."
                                    }
                        }
                else
                    on_succ (player,d)
            else
                on_fail

        met rec loop players d =
            inl rec loop2 (s, i, d) = function
                | player :: x' ->
                    inl internal_representation = internal_representation i state
                    match betting { internal_representation player } d with
                    | .Some, (player, d) -> loop2 (player :: s, i+1, d) x'
                    | .None -> Tuple.append (Tuple.rev s) x'
                | () -> loop (Tuple.rev s) d
            loop2 ((),dyn 0,d)
            : players
        
        log "Betting:" ()
        loop state.players
            {
            min_raise=dyn 2
            call_level = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 state.players |> dyn
            players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players |> dyn
            players_called = dyn 0
            }

    """) |> module_