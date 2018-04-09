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
stack inl {d with elem_type} ->
    inl elem_type = type elem_type
    inl key, value = elem_type
    inl ty = fs [text: "System.Collections.Generic.Dictionary"; types: elem_type]
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
    function
    | .count ->
        macro.fs int32 [arg: x; text: ".Count"]
    | .set i v ->
        assert (eq_type key i) {msg="The index's type is not the equal to that of the key."; key i}
        assert (eq_type value v) {msg="The second argument's type is not the equal to that of the value."; value v}
        macro.fs () [arg: x; text: ".["; arg: i; text: "] <- "; arg: v]
    | i {on_succ on_fail} ->
        assert (eq_type key i) {msg="The index's type is not the equal to that of the key."; key i}
        macro.fs () [arg: x; text: ".TryGetValue"; text: " <| "; arg: i; text: " |> fun (a,b) -> ";]
        inl a = macro.fs bool [text: "a"]
        inl b = macro.fs value [text: "b"]
        if a then on_succ b else on_fail ()
    |> stack
    """) |> module_

let poker =
    (
    "Poker",[random;console;option;dictionary],"The Poker module.",
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
   
inl rnd = Random()
inl unshuffled = 
    Tuple.map (inl rank ->
        Tuple.map (inl suit -> box Card {rank=box Rank rank; suit=box Suit suit}) Suits
        ) Ranks
    |> Tuple.concat

inl deck _ =
    met knuth_shuffle rnd ln ar =
        inl swap i j =
            inl item = ar i
            ar i <- ar j
            ar j <- item

        Loops.for {from=0; near_to=ln-1; body=inl {i} -> swap i (rnd.next(to int32 i, to int32 ln))}

    inl ar = macro.fs (array Card) [fs_array_args: unshuffled]
    assert (array_length ar = num_cards) "The number of cards in the deck must be 52."
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

        inl old_chips = Tuple.map (inl {chips pot} -> chips + pot) players

        met rec loop players =
            macro.fs () [text: "//In showdown"]
            inl is_active = Tuple.map is_active players
            inl {foldl foldl_map} = iterator_template is_active

            foldl (inl s player ->
                match s with
                | .Some, a ->
                    match player.hand with
                    | .Some, b -> if rule a b = 1i32 then Option.some a else Option.some b
                    | .None -> Option.some a
                | .None -> player.hand
                ) (Option.none Hand) players
            |> function
                | .Some, winning_hand ->
                    inl min_pot = foldl (inl s {pot} -> min s pot) (macro.fs int64 [text: "System.Int64.MaxValue"]) players
                    inl players, pot = 
                        foldl_map (inl s {player with pot} -> 
                            inl taken = min min_pot pot
                            {player with pot=pot-taken}, s + taken
                            ) 0 players
                    
                    inl winners = 
                        Tuple.map2 (inl is_active x ->
                            if is_active then
                                match x.hand with
                                | .Some, hand -> rule winning_hand hand = 0i32
                                | _ -> false
                            else false
                            ) is_active players
                    inl {foldl foldl_map} = iterator_template winners
                    inl num_winners = foldl (inl s _ -> s + 1) 0 players

                    inl could_be_odd = pot % num_winners <> 0
                    inl pot = pot / num_winners
                    foldl_map (inl s {x with chips} ->
                        inl odd_chip = if could_be_odd then s else 0
                        {x with chips=chips + pot + odd_chip}, 1
                        ) 0 players 
                    |> fst
                    |> loop
                | .None ->
                    Tuple.map (inl {chips pot} -> chips + pot) players
            : Tuple.map (const 0) players
        inl new_chips = Tuple.map (inl {hand chips pot} -> {hand chips pot}) players |> loop
        inl rewards = Tuple.map2 (inl old new -> new - old) old_chips new_chips

        Tuple.iter2 (met {d with name reply} reward -> 
            match d with
            | {trace} -> trace (to float64 reward)
            | _ -> ()
            if reward = 1 then log "{0} wins {1} chip." (name,reward)
            elif reward = -1 then log "{0} loses {1} chip." (name,-reward)
            elif reward > 0 then log "{0} wins {1} chips." (name,reward)
            elif reward < 0 then log "{0} loses {1} chips." (name,-reward)
            else ()
            ) players rewards

        new_chips

    inl internal_representation i players =
        Tuple.mapi (inl i' {chips pot hand} ->
            if i' <> i then {chips pot hand=dyn (Option.none Hand)}
            else {chips pot hand}
            ) players

    inl hand_is = function
        | .Some, _ -> true
        | _ -> false

    inl fold player = {player with hand = Option.none Hand}
    inl call {player with pot chips} x = 
        inl x = min chips (x - pot)
        {player with chips=self-x; pot=self+x}

    inl betting players =
        inl is_active {chips hand} = chips > 0 && hand_is hand
        met betting {internal_representation player} {d with min_raise call_level players_called players_active} =
            macro.fs () [text: "//In betting"]
            inl on_succ=Option.some
            inl on_fail=Option.none (player,d)
            if players_called < players_active && (players_active <> 1 || player.pot < call_level) then
                if is_active player then 
                    inl update_player trace = 
                        match trace with
                        | () -> player
                        | _ -> {player with trace = term_cast (trace >> self) float64}

                    player.reply internal_representation
                        {
                        fold = inl trace -> 
                            inl player = fold (update_player trace)
                            log "{0} folds." player.name
                            on_succ (player, {d with players_active=self-1})
                        call = inl trace -> 
                            inl player = call (update_player trace) call_level
                            inl on_succ d = on_succ (player, d)
                            if player.chips = 0 then
                                log "{0} calls and is all-in!" player.name
                                on_succ {d with players_active=self-1}
                            else
                                log "{0} calls." player.name
                                on_succ {d with players_called=self+1}
                        raise = inl trace x -> 
                            assert (x >= 0) "Cannot raise to negative amounts."
                            inl player = call (update_player trace) (call_level + min_raise + x)
                            inl call_level' = player.pot
                            inl on_succ {gt lte} =
                                if call_level' > call_level then 
                                    {d with call_level = call_level'; min_raise = max min_raise (call_level'-call_level)}
                                    |> inl d -> on_succ (player, gt d)
                                else on_succ (player, lte d)
                                
                            if player.chips = 0 then
                                on_succ {
                                    gt = inl d -> 
                                        log "{0} raises to {1} and is all-in!" (player.name, call_level')
                                        {d with players_active=self-1; players_called=0}
                                    lte = inl d -> 
                                        log "{0} calls and is all-in!" player.name
                                        {d with players_active=self-1}
                                    }
                            else
                                log "{0} raises to {1}." (player.name, call_level')
                                on_succ {
                                    gt = inl d -> {d with players_called=1}
                                    lte = inl d -> failwith d "Should not be possible to raise to less than the call level without running out of chips."
                                    }
                        }
                else on_succ (player,d)
            else
                on_fail

        met rec loop players (!dyn d) =
            inl rec loop2 (s, i, d) = function
                | player :: x' as l ->
                    inl l = Tuple.append (Tuple.rev s) l
                    inl internal_representation = internal_representation i l
                    match betting { internal_representation player } d with
                    | .Some, (player, d) -> loop2 (player :: s, i+1, d) x'
                    | .None -> l
                | () -> loop (Tuple.rev s) d
            loop2 ((),dyn 0,d) players
            : players
        
        log "Betting:" ()
        loop players
            {
            min_raise=2
            call_level = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 players
            players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 players
            players_called = 0
            }

    inl dealing players deck = 
        met f ante deck {name chips} =
            macro.fs () [text: "//In dealing"]
            inl player = call {chips pot=0} ante
            inl hand, deck =
                inl ante = player.pot
                if ante > 0 then 
                    log "{0} antes up {1}" (name, ante)
                    inl card,deck = deck()
                    Option.some card, deck
                else
                    Option.none Hand, deck
            {player with hand}, deck

        inl f ante deck {player with name chips} =
            inl {hand chips pot}, deck = f ante deck {name chips}
            {player with hand chips pot}, deck

        inl ante, big_ante = 1, 2
        inl rec loop deck = function
            | a :: b :: () -> 
                inl a, deck = f ante deck a
                inl b, deck = f big_ante deck b
                a :: b :: (), deck
            | a :: b -> 
                inl a, deck = f 0 a
                inl b, deck = loop deck b
                a :: b, deck
        log "Dealing:" ()
        loop deck players

    inl hand_rule a b =
        met f x = match x with {rank=.(_) as x} -> tag_rank x
        compare (f a) (f b)

    inl round players = 
        log "A new round is starting..." ()
        log "Chip counts:" ()
        Tuple.iter (inl {name chips} ->
            log "{0} has {1} chips." (name,chips)
            ) players
        inl new_chips = dealing players (deck()) |> fst |> betting |> showdown hand_rule
        Tuple.map2 (inl x chips -> {x with chips}) players new_chips

    inl game chips players =
        inl is_active {chips} = chips > 0
        inl is_finished players =
            inl players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 players
            players_active = 1

        met rec loop players =
            inl a :: b as players = round players
            if is_finished players then 
                log "The game is over." ()
                Tuple.map (inl {name chips} ->
                    if chips > 0 then log "{0} wins with {1} chips!" (name, chips)
                    {name chips}
                    ) players
            else 
                loop (Tuple.append b (a :: ()))
            : Tuple.map (inl {name chips} -> {name chips}) players
        Tuple.map (inl x -> {x with chips}) players
        |> Tuple.map (module_map (inl _ x -> join x))
        //|> Tuple.map (function
        //    | {chips name reply trace} -> {chips=join chips; name=join name; reply=join reply; trace=join trace}
        //    | {chips name reply} -> {chips=join chips; name=join name; reply=join reply}
        //    )
        |> function a,b -> a,b | x -> x
        |> loop

    inl reply_random =
        inl rnd = Random()
        inl _ {fold call raise} ->
            match rnd.next(0i32,5i32) with
            | 0i32 -> fold ()
            | 1i32 -> call ()
            | _ -> raise () 0

    inl reply_rules players {fold call raise} =
        inl limit = Tuple.foldl (inl s x -> max s x.pot) 0 players
        /// TODO: Replace find with pick.
        inl self = Tuple.find (inl x -> match x.hand with .Some, _ -> true | _ -> false) players
        match self.hand with
        | .Some, x ->
            match x.rank with
            | .Ten | .Jack | .Queen | .King | .Ace -> raise () 0
            | _ -> if self.pot >= limit || self.chips = 0 then call () else fold ()
        | .None -> failwith (type fold ()) "No self in the internal representation."

    inl Actions = .Fold, .Call, (.Raise, 0)
    inl Action = Tuple.reducel (inl a b -> a \/ b) Actions
    inl Rep = type {pot=int64; chips=int64; hand=Option.none Hand}

    inl reply_q {init learning_rate num_players} =
        inl dict = Dictionary {elem_type=(Tuple.repeat num_players Rep,Action),float64}
        inl box = stack (box Action)
        inl players {fold call raise} ->
            inl v, a = 
                Tuple.foldl (inl (s,a) (!box x) ->
                    inl v = dict (players, x) { on_fail=const init; on_succ=id }
                    if v > s then v,x else s,a
                    ) (-infinityf64, box .Fold) Actions

            inl trace v' =
                dict.set (players, a) (v + learning_rate * (v' - v))
                // This last line determines what kind of updates are done.
                // Returning v' means doing Monte Carlo updates.
                // Returning v means doing Q learning.
                v'

            match a with
            | .Fold -> fold trace
            | .Call -> call trace
            | .Raise, x -> raise trace x

    {one_card=game; reply_random reply_rules reply_q}
    """) |> module_