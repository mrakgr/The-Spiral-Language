module Poker.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

let poker =
    (
    "Poker",[random],"The Poker module",
    """
inl Suits = .Spades, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.redulel (\/) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.redulel (\/) Ranks
inl Card = type {rank=Rank; suit=Suit}

//inl spades, clubs, hearts, diamonds = Tuple.map (box Suit) ()
//inl two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace = Tuple.map (box Rank) Ranks
inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) {} Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) {} Suits |> fst
   
inl deck _ =
    inl knuth_shuffle rnd ln ar =
        inl swap i j =
            inl item = ar i
            ar i <- ar j
            ar j <- item

        Loops.for {from=0; near_to=ln-1; body=inl {i} -> swap i (rnd.next(i, ln))}

    inl unshuffled = 
        Tuple.map (inl rank ->
            Tuple.map (inl suit -> box Card {rank suit}) suit
            ) rank
        |> Tuple.concat

    inl ty = array Card
    inl ar = macro.fs ty [fs_array_args: unshuffled; text: ": "; type: ty]
    inl num_cards = 52
    assert (array_length ar = num_cards) "The number of cards in the deck must be 52."
    inl rnd = Random()
    inl data = heapm {ar rnd p=num_cards}
    function
    | .reset -> join
        knuth_shuffle data.rnd num_cards data.ar
        data.p <- num_cards
    | .take -> join
        inl x = data.p - 1
        data.p <- x
        data.ar x

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
inl showdown rule state =
    inl players = state.players
    inl is_active x {on_succ on_fail} = 
        if x.pot > 0 then 
            match x.hand with
            | .Some, x -> on_succ x
            | _ -> on_fail
        else on_fail

    met rec loop _ =
        Tuple.redulel (inl a b ->
            inl on_fail = Option.none Card
            is_active a {
                on_fail
                on_succ = inl a_hand ->
                    is_active b {
                        on_fail
                        on_succ = inl b_hand -> if rule a_hand b_hand = -1i32 then Option.some a_hand else Option.some b_hand
                        }
                }
            )
        |> function
            | .Some, winning_hand ->
                inl min_pot = Tuple.foldl (inl a b -> min a b.pot) 0 players
                inl num_winners = 
                    Tuple.foldl (inl s x ->
                        is_active x {
                            on_fail = s
                            on_succ = inl hand -> if rule winning_hand hand = 0i32 then s+1 else s
                            }
                        ) 0 players
                inl could_be_odd = min_pot % num_winners <> 0
                inl pot = min_pot / num_winners
                Tuple.foldl (inl s x ->
                    is_active x {
                        on_fail = s
                        on_succ = inl hand ->
                            if rule winning_hand hand = 0i32 then
                                inl odd_chip = if could_be_odd && num_winners-1 <> s then 1 else 0
                                x.chips_add (pot + odd_chip)
                                s+1
                            else
                                s
                        }
                    ) 0 players |> ignore
                loop ()
            | .None ->
                ()
        : ()
    loop ()

inl internal_representation i state =
    {
    players=
        Tuple.mapi (inl i' x -> 
            if i' <> i then {chips=x.chips; pot=x.pot; hand=Option.none Card}
            else {chips=x.chips; pot=x.pot; hand=x.hand}
            ) state.players
    board=state.board
    }

inl betting state =
    inl is_active x = x.chips > 0 && x.hand_is
    met f {i player} next {d with players_called limit active_players} =
        if active_players > 1 && players_called < active_players then
            if is_active player then
                player.reply (internal_representation i state)
                    {
                    fold = inl _ -> player.fold; next {d with active_players=self-1}
                    call = inl _ -> player.call limit; next {d with players_called=self+1}
                    raise = inl x -> next {d with limit=player.raise limit x; players_called=dyn 0}
                    }
            else
                next d
        : ()
        
    inl players=Tuple.mapi (inl i player -> {i player}) state.players
    met rec loop d = Tuple.foldr f players loop {d with players_called=dyn 0} : ()
    loop {
        active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players |> dyn
        limit = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 state.players |> dyn
        }

inl player player_chips reply =
    inl data = 
        {
        chips=dyn player_chips
        hand=dyn (Option.None Card)
        pot=dyn 0
        } |> heapm

    inl call x =
        inl chips, pot = data.chips, data.pot
        inl x = min chips (x - pot)
        data.chips <- chips - x
        data.pt <- pot + x

    function
    | .hand_set x -> data.hand <- Option.some x
    | .fold -> data.hand <- Option.None Card
    | .call x -> call x
    | .raise a c -> 
        inl b = a - data.pot
        call (a + b + c)
    | .pot_take x -> 
        inl pot = data.pot
        inl x = min pot x
        data.pot <- pot - x; x
    | .chips_add x ->
        data.chips <- data.chips + x
    | .hand_is ->
        match data.hand with
        | .None -> false
        | _ -> true
    | .reply -> reply
    | x -> data x

inl init {player_replies player_chips} = 
    inl rec facade d = function
        | .move_button ->
            inl a :: b = d.players
            facade {d with players=Tuple.append b (a :: ())}
        | x -> d x

    inl players = Tuple.map (player player_chips) player_replies
    /// One card poker has no board.
    inl board = ()
    inl deck = deck()
    facade {players board deck}

inl one_card =
    inl hand_rule = inl a b -> 
        inl f .(_) as x = tag_rank x
        compare (f a) (f b)

    inl dealing = inl state ->
        inl is_active x = x.chips > 0
        inl f ante player =
            if is_active player then 
                if ante > 0 then player.call ante
                player.hand_set state.deck.take

        inl ante, big_ante = 1, 2
        inl rec loop = function
            | a :: b :: () -> f ante a; f big_ante b
            | a :: b -> f 0 a; loop b
        loop state.players

    inl is_finished state =
        inl is_active x = x.chips > 0
        inl active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players
        active_players = 1

    inl round state = 
        state.deck.reset
        dealing state
        betting state
        showdown hand_rule state

    inl game =
        met rec loop state =
            round state
            if is_finished state then state else loop state.move_button
            : ()
        loop << init
    """) |> module_
