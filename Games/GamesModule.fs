module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning
open Learning.Main.Lib
open Learning.Cuda.Lib

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
    "Poker",[learning;random;console;option;dictionary;resize_array;object],"The Poker module.",
    """
inl Suits = .Spades :: () //, .Clubs, .Hearts, .Diamonds
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
        macro.fs () [text: "//In Knuth shuffle"]
        inl swap i j =
            inl item = ar i
            ar i <- ar j
            ar j <- item

        Loops.for {from=0; near_to=ln-1; body=inl {i} -> swap i (rnd.next(to int32 i, to int32 ln))}

    inl ar = macro.fs (array Card) [fs_array_args: unshuffled]
    assert (array_length ar = num_cards) "The number of cards in the deck must be 52."
    knuth_shuffle rnd num_cards ar

    inl deck = heapm {ar p=dyn num_cards}

    inl _ ->
        inl x = deck.p - 1
        deck.p <- x
        deck.ar x

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_card x =
    macro.fs () [text: "//In show_card."]
    inl {rank=.(a) suit=.(b)} = x 
    string_format "{0}-{1}" (a, b)

inl {d with max_stack_size num_players} ->
    inl range = max_stack_size+1
    inl scale = max_stack_size / num_players |> to float64

    inl log =
        match d with
        | {log} -> log
        | _ _ _ -> ()
    inl Hand = Card // for one card poker
    inl show_hand = show_card

    inl Actions = .Fold, .Call, (.Raise, .0)
    inl Action = Tuple.reducel (inl a b -> a \/ b) Actions
    inl Rep = type {pot=int64; chips=int64; hand=Option.none Hand}
    inl State = Tuple.repeat num_players Rep

    inl hand_rule a b =
        met f x = 
            macro.fs () [text: "// In hand_rule."]
            match x with {rank=.(_) as x} -> tag_rank x
        compare (f a) (f b)

    inl showdown players = 
        inl old_chips = Tuple.map (inl x -> x.chips + x.pot) players
        match players with
        | a,b -> 
            met win a b = 
                inl min_pot = min a.pot b.pot
                a.chips_give (a.pot_take min_pot + b.pot_take min_pot + a.pot_take a.pot)
                b.chips_give (b.pot_take b.pot)

            inl tie = Tuple.iter (inl x -> x.pot_take x.pot |> x.chips_give)

            match a.hand with
            | .Some, a' ->
                match b.hand with
                | .Some, b' -> 
                    match hand_rule a' b' with
                    | 1i32 -> win a b
                    | 0i32 -> tie players
                    | _ -> win b a
                | .None -> win a b
            | .None -> win b a

        | _ -> 
            inl get_active = Array.filter (inl x -> x.pot > 0)
            inl get_winners active = 
                inl win_hand =
                    Array.foldl (inl s player ->
                        match s with
                        | .Some, a ->
                            match player.hand with
                            | .Some, b -> if rule a b = 1i32 then Option.some a else Option.some b
                            | .None -> Option.some a
                        | .None -> player.hand
                        ) (Option.none Hand) active

                Array.filter (inl x -> 
                    match x.hand with
                    | .Some, x -> win_hand = x
                    | .None -> false
                    ) active

            inl get_min_pot active = Array.foldl (inl s x -> min s x.pot) (macro.fs int64 [text: "System.Int64.MaxValue"]) active
            inl take_min_pot active min_pot = Array.foldl (inl s x -> s + x.pot_take min_pot) (dyn 0) active
            inl give_pot winners pot = 
                inl num_winners = array_length winners
                inl odd_chips = pot % num_winners
                inl pot = pot / num_winners
                Array.foldl (inl s x -> 
                    inl odd_chip = if s > 0 then 1 else 0
                    x.chips_give (pot + odd_chip)
                    s-1
                    ) odd_chips winners

            met rec loop players = 
                inl active = get_active players
                if array_length active > 0 then
                    inl winners = get_winners active
                    get_min_pot active
                    |> take_min_pot active
                    |> give_pot winners
                    loop players
                : ()
            
            loop <| Array.from_tuple players
        Tuple.iter2 (inl x old_chips ->
            inl reward = x.chips - old_chips
            match x.hand with
            | .Some, hand -> log "{0} shows {1}" (x.name, show_hand hand)
            | _ -> ()
            x.showdown reward
            inl name = x.name
            if reward = 1 then log "{0} wins {1} chip." (name,reward)
            elif reward = -1 then log "{0} loses {1} chip." (name,-reward)
            elif reward > 0 then log "{0} wins {1} chips." (name,reward)
            elif reward < 0 then log "{0} loses {1} chips." (name,-reward)
            else ()
            ) players old_chips

    inl internal_representation i players =
        Tuple.mapi (inl i' x ->
            if i' <> i then {chips=x.chips; pot=x.pot; hand=dyn (Option.none Hand)}
            else {chips=x.chips; pot=x.pot; hand=x.hand}
            ) players

    inl betting players =
        inl is_active x = x.chips > 0 && x.hand_is
        met betting {internal_representation player} {d with min_raise call_level players_called players_active} =
            macro.fs () [text: "//In betting"]
            inl on_succ = Option.some
            inl on_fail = Option.none d
            if players_called < players_active && (players_active <> 1 || player.pot < call_level) then
                if is_active player then 
                    player.bet
                        internal_representation
                        {
                        fold = inl _ -> 
                            player.fold
                            log "{0} folds." player.name
                            on_succ {d with players_active=self-1}
                        call = inl _ -> 
                            player.call call_level
                            if player.chips = 0 then
                                log "{0} calls and is all-in!" player.name
                                on_succ {d with players_active=self-1}
                            else
                                log "{0} calls." player.name
                                on_succ {d with players_called=self+1}
                        raise = inl x -> 
                            assert (x >= 0) "Cannot raise to negative amounts."
                            player.call (call_level + min_raise + x)
                            inl call_level' = player.pot
                            inl on_succ {gt lte} =
                                if call_level' > call_level then 
                                    {d with call_level = call_level'; min_raise = max min_raise (call_level'-call_level)}
                                    |> inl d -> on_succ (gt d)
                                else on_succ (lte d)
                                
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
                else on_succ d
            else
                on_fail

        met rec loop players (!dyn d) =
            macro.fs () [text: "// In betting's loop."]
            Tuple.foldr (inl player next (i, d) ->
                inl internal_representation = internal_representation i players
                match betting { internal_representation player } d with
                | .Some, d -> next (i+1, d)
                | .None -> ()
                ) players (inl _,d -> loop players d) (dyn 0, d)
            : ()
        
        log "Betting:" ()
        loop players
            {
            min_raise=2
            call_level = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 players
            players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 players
            players_called = 0
            }

    inl dealing players deck =
        macro.fs () [text: "// In dealing."]
        inl f ante x =
            inl hand = deck () |> Option.some |> dyn
            inl pot = dyn 0
            inl x = x.data_add {pot_hand = heapm {pot hand}}
            x.call ante
            inl ante = x.pot
            if ante > 0 then log "{0} antes up {1}" (x.name, ante)
            x

        inl ante, big_ante = 1, 2
        inl rec loop = function
            | a :: b :: () -> 
                inl a = f ante a
                inl b = f big_ante b
                a :: b :: ()
            | a :: b -> 
                inl a = f 0 a
                inl b = loop b
                a :: b
        log "Dealing:" ()
        loop players

    inl round players =
        log "A new round is starting..." ()
        log "Chip counts:" ()
        Tuple.iter (inl x ->
            log "{0} has {1} chips." (x.name,x.chips)
            ) players
        inl players = dealing players (deck()) // Adds pot and hand fields to the players.
        betting players
        showdown players

    inl game chips players =
        assert (Tuple.length players = num_players) "The number of players needs to be equal to the defined one."
        assert (chips * num_players <= max_stack_size) "The potential largest stack size needs to be in range."
        inl is_active x = x.chips > 0
        inl is_finished players =
            inl players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 players
            players_active <= 1

        met rec loop players =
            inl a :: b = players
            round players
            if is_finished players then
                log "The game is over." ()
                Tuple.iter (inl x ->
                    inl chips = x.chips
                    if chips > 0 then 
                        log "{0} wins with {1} chips!" (x.name, chips)
                        x.win
                    x.game_over
                    ) players
            else
                loop (Tuple.append b (a :: ()))
            : ()

        Tuple.map (inl x -> x.data_add {chips=ref chips}) players
        |> loop

    inl basic_methods = 
        {
        chips=inl s -> s.data.chips ()
        pot=inl s -> s.data.pot_hand.pot
        hand=inl s -> s.data.pot_hand.hand
        hand_is=inl s -> 
            match s.data.pot_hand.hand with
            | .Some, _ -> true
            | .None -> false
        chips_give=inl s v -> s.data.chips := s.chips + v
        pot_take=inl s v -> 
            inl pot = s.pot 
            inl pot' = pot - v |> max 0
            s.data.pot_hand.pot <- pot'
            pot - pot'
        pot_give=inl s v -> s.data.pot_hand.pot <- s.pot + v
        call=inl s v ->
            inl x = min s.chips (v - s.pot)
            s.chips_give (-x)
            s.pot_give x
        fold=inl s -> s.data.pot_hand.hand <- Option.none Hand |> dyn
        win=inl s -> 
            inl win=s.data.win
            win := win() + 1
        name=inl s -> s.data.name
        cd=inl s -> s.data.cd
        state=inl s -> s.data.state
        net=inl s -> s.data.net
        }

    {basic_methods Action State game}
    """) |> module_

let player_random =
    (
    "PlayerRandom",[random],"The player which selects actions at random.",
    """
inl {State Action} ->
    inl rnd = Random()
    inl action state = {out = Union.to_sparse Action .length |> to int32 |> rnd.next |> to int64 |> Union.create Action}

    {action}
    """) |> module_

let player_tabular_mc =
    (
    "PlayerTabularMC",[dictionary],"The tabular MC player.",
    """
inl {State Action init learning_rate} ->
    inl dict = Dictionary {elem_type=(State,Action),float64}
    inl action state =
        inl v, a =
            Tuple.foldl (inl (s,a) (!box x) ->
                inl v = dict (rep, x) { on_fail=const init; on_succ=id }
                if v > s then v,x else s,a
                ) (-infinityf64, Union.head Action |> Union.create Action) (split Action)

        {
        out=a
        bck=inl v' -> dict.set (state, a) (v + learning_rate * (v' - v))
        }

    {action}
    """) |> module_

let union =
    (
    "Union",[tuple;console],"The Union module.",
    """
/// The transforms the argument into an index given a type template.
/// It is a one-hot encode function.
/// type -> x -> int64
inl rec to_sparse ty x =
    inl prod (i,s) ty x =
        inl i', s' = to_sparse ty x
        i + i' * s, s * s'

    inl sum s ty x =
        inl i',s' = to_sparse ty x
        s + i', s + s'

    inl assert_range {from near_to} x =
        assert (eq_type 0 x) "x must be the int64 type."
        assert (x >= from) "x must be greater or equal to its lower bound."
        assert (x < near_to) "x must be lesser than its upper bound."
        x, near_to - from

    match ty, x with
    | _, _ when caseable_box_is ty && caseable_box_is x ->
        inl ty = split ty
        assert (Tuple.length ty = Tuple.length (split x)) "The two types must equal each other."
        case_foldl_map (inl (ty :: ty', s) x ->
            inl (i',s') = sum s ty x
            i', (ty', s')
            ) (ty,0) x
        |> inl i,((),s) -> i,s
    | _ :: _, _ :: _ -> Tuple.foldl2 prod (0,1) ty x
    | .(a), .(b) ->
        assert (a = b) "The two types must equal each other."
        0,1
    | (),() -> 0,1
    | {!block}, {!block} ->
        assert (module_length ty = module_length x) "The two types must equal each other."
        module_foldl (inl k s x -> prod s (ty k) x) (0,1) x
    | {from=.(from) near_to=.(near_to) block=()}, _ -> assert_range {from near_to} x
    
inl to_sparse ty x = to_sparse ty x

inl rec boxy ty =
    match ty with
    | _ when caseable_box_is ty -> Tuple.map boxy (split ty) |> Tuple.reducel (inl a b -> a \/ b)
    | _ :: _ -> Tuple.map boxy ty
    | .(_) | () -> ty
    | {!block} -> module_map boxy ty
    | {from=.(from) near_to=.(near_to) block=()} -> int64

/// Works much the same as a regular box, but converts the special integer ranges into int64 types.
inl box ty = box (boxy ty)

/// Converts an index into a union type.
/// type -> int64 -> x
inl rec from_sparse ty i = 
    inl prod (i,s) ty = 
        inl x, s' = from_sparse ty i
        x, (i / s', s * s')

    match ty with
    | _ when caseable_box_is ty -> 
        inl x, (_, s) = 
            Tuple.foldl_map (inl (i,s) ty ->
                inl x, s' = from_sparse ty i
                (x, s'), (i - s', s + s')
                ) (i, 0) (split ty)

        inl rec loop ((x,s) :: x') i =
            inl x _ = x () |> box ty
            match x' with
            | () -> x () 
            | _ -> if i < s then x () else loop x' (i - s)

        (inl _ -> loop x (i % s)), s
    | _ :: _ -> Tuple.foldl_map prod (i,1) ty |> inl x, (i, s) -> (inl _ -> Tuple.map (inl x -> x()) x), s
    | .(_) | () -> const ty, 1
    | {!block} -> module_foldl_map prod (i,1) ty |> inl x, (i, s) -> (inl _ -> module_map (inl _ x -> x()) x), s
    | {from=.(from) near_to=.(near_to) block=()} -> 
        inl s = near_to - from
        (inl _ -> i % s), s

inl from_sparse ty i = 
    inl x,s = from_sparse ty i
    assert (i < s) "The input to this function must be less than the size of the type."
    x()

inl rec to_dense ar ty x =
    inl to_dense = to_dense ar
    inl prod s ty x =
        inl s' = to_dense ty x
        s + s'

    inl sum s ty x =
        inl i',s' = to_sparse ty x
        s + i', s + s'

    inl assert_range {from near_to} x =
        assert (eq_type 0 x) "x must be the int64 type."
        assert (x >= from) "x must be greater or equal to its lower bound."
        assert (x < near_to) "x must be lesser than its upper bound."
        x, near_to - from

    match ty, x with
    | _, _ when caseable_box_is ty && caseable_box_is x ->
        inl ty = split ty
        assert (Tuple.length ty = Tuple.length (split x)) "The two types must equal each other."
        case_foldl_map (inl (ty :: ty', s) x ->
            inl (i',s') = sum s ty x
            i', (ty', s')
            ) (ty,0) x
        |> inl i,((),s) -> i,s
    | _ :: _, _ :: _ -> Tuple.foldl2 prod (0,1) ty x
    | .(a), .(b) ->
        assert (a = b) "The two types must equal each other."
        0,1
    | (),() -> 0,1
    | {!block}, {!block} ->
        assert (module_length ty = module_length x) "The two types must equal each other."
        module_foldl (inl k s x -> prod s (ty k) x) (0,1) x
    | {from=.(from) near_to=.(near_to) block=()}, _ -> assert_range {from near_to} x

{to_sparse from_sparse box} |> stackify
    """) |> module_