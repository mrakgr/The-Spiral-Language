module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

let poker =
    (
    "Poker",[random;console;option],"The Poker module",
    """
inl log = Console.writeline

inl Suits = .Spades, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank; suit=Suit}

//inl spades, clubs, hearts, diamonds = Tuple.map (box Suit) ()
//inl two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace = Tuple.map (box Rank) Ranks
inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Suits |> fst
   
inl deck _ =
    inl knuth_shuffle rnd ln ar =
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
inl show_hand {rank=.(a) suit=.(b)} = string_format "{0}-{1}" (a, b)

inl showdown rule state =
    inl players = state.players
    inl is_active x {on_succ on_fail} = 
        if x.pot > 0 then 
            match x.hand with
            | .Some, x -> on_succ x
            | _ -> on_fail
        else on_fail

    log "Showdown:"
    Tuple.iter (inl x ->
        is_active x {
            on_fail=()
            on_succ=inl hand -> string_format "{0} shows {1}" (x.name, show_hand hand) |> log
            }
        ) players

    inl old_chips = Tuple.map (inl x -> x.chips + x.pot) players

    met rec loop _ =
        Tuple.reducel (inl a b ->
            inl on_fail = Option.none Card
            is_active a {
                on_fail
                on_succ = inl a_hand ->
                    is_active b {
                        on_fail
                        on_succ = inl b_hand -> if rule a_hand b_hand = -1i32 then Option.some a_hand else Option.some b_hand
                        }
                }
            ) players
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

    Tuple.iter2 (inl old_chips x -> 
        inl chips = x.chips
        if old_chips < chips then string_format "{0} wins {1} chips." (x.name,chips-old_chips) |> log
        elif old_chips > chips then string_format "{0} loses {1} chips." (x.name,old_chips-chips) |> log
        else ()
        ) old_chips players

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
                    fold = inl _ -> 
                        player.fold
                        string_format "{0} folds." player.name |> log
                        next {d with active_players=self-1}
                    call = inl _ -> 
                        player.call limit
                        if player.chips = 0 then
                            string_format "{0} calls and is all-in!" player.name |> log
                        else
                            string_format "{0} calls." player.name |> log
                        next {d with players_called=self+1}
                    raise = inl x -> 
                        inl limit=max limit (player.raise limit x)
                        if player.chips = 0 then
                            string_format "{0} raises to {1} and is all-in!" (player.name, limit) |> log
                        else
                            string_format "{0} raises to {1}." (player.name, limit) |> log
                        next {d with limit players_called=dyn 0}
                    }
            else
                next d
        : ()
        
    inl players=Tuple.mapi (inl i player -> {i player}) state.players
    met rec loop d = Tuple.foldr f players loop {d with players_called=dyn 0} : ()
    log "Betting:"
    loop {
        active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players |> dyn
        limit = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 state.players |> dyn
        }

inl player player_chips {reply name} =
    inl data = 
        {
        chips=dyn player_chips
        hand=dyn (Option.none Card)
        pot=dyn 0
        } |> heapm

    inl call x =
        inl chips, pot = data.chips, data.pot
        inl x = min chips (x - pot)
        data.chips <- chips - x
        inl pot = pot + x
        data.pot <- pot
        pot

    function
    | .hand_set x -> data.hand <- Option.some x
    | .fold -> data.hand <- Option.none Card
    | .call x -> call x |> ignore
    | .raise a c -> 
        inl b = a - data.pot
        call (a + b + c)
    | .pot_take x -> 
        inl pot = data.pot
        inl x = min pot x
        data.pot <- pot - x
    | .chips_add x ->
        data.chips <- data.chips + x
    | .hand_is ->
        match data.hand with
        | .None -> false
        | _ -> true
    | .reply -> reply
    | .name -> name
    | x -> data x

inl init {players player_chips} = 
    inl rec facade d = function
        | .move_button ->
            inl a :: b = d.players
            facade {d with players=Tuple.append b (a :: ())}
        | x -> d x

    inl players = Tuple.map (player player_chips) (dyn players)
    /// One card poker has no board.
    inl board = ()
    inl deck = deck()
    facade {players board deck}

inl random_reply =
    inl rnd = Random()
    inl state {fold call raise} ->
        match rnd.next(0i32,5i32) with
        | 0i32 -> fold()
        | 1i32 -> call()
        | _ -> raise 0

inl one_card =
    inl hand_rule = inl a b -> 
        inl f {rank=.(_) as x} = tag_rank x
        compare (f a) (f b)

    inl dealing = inl state ->
        inl is_active x = x.chips > 0
        inl f ante player =
            if is_active player then 
                if ante > 0 then 
                    string_format "{0} antes up {1}" (player.name, ante) |> log
                    player.call ante
                player.hand_set state.deck.take

        inl ante, big_ante = 1, 2
        inl rec loop = function
            | a :: b :: () -> f ante a; f big_ante b
            | a :: b -> f 0 a; loop b
        log "Dealing:"
        loop state.players

    inl is_finished state =
        inl is_active x = x.chips > 0
        inl active_players = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 state.players
        active_players = 1

    inl round state = 
        log "A new round is starting..."
        state.deck.reset
        dealing state
        betting state
        showdown hand_rule state

    inl game =
        met rec loop state =
            round state
            if is_finished state then 
                log "The game is over."
                Tuple.iter (inl x ->
                    inl chips = x.chips
                    if chips > 0 then string_format "{0} wins with {1} chips!" (x.name, chips) |> log
                    ) state.players
            else 
                loop state.move_button
            : ()
        loop << init

    game

{
random_reply
one_card
} |> stackify
    """) |> module_
