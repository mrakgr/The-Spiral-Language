module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning.Module

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
    "Poker",[learning;random;console;option;dictionary;list],"The Poker module.",
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

    inl rec facade p _ =
        inl x = p - 1
        ar x, facade x
    facade (dyn num_cards)

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_card x =
    macro.fs () [text: "//In show_card."]
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
            macro.fs () [text: "//In showdown's card show."]
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

        Tuple.map3 (met {d with name reply trace state} old_chips chips -> 
            macro.fs () [text: "//In the reward part."]
            inl reward = chips - old_chips
            inl trace = trace .add_reward reward
            if reward = 1 then log "{0} wins {1} chip." (name,reward)
            elif reward = -1 then log "{0} loses {1} chip." (name,-reward)
            elif reward > 0 then log "{0} wins {1} chips." (name,reward)
            elif reward < 0 then log "{0} loses {1} chips." (name,-reward)
            else ()
            {state trace chips}
            ) players old_chips new_chips

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
            inl on_succ player,d = Option.some ({player without reply name}, d)
            inl on_fail=Option.none ({player without reply name},d)
            if players_called < players_active && (players_active <> 1 || player.pot < call_level) then
                if is_active player then 
                    inl update_player {state bet} = {player with trace = self.add_bet bet; state}

                    player.reply 
                        internal_representation
                        player.state
                        {
                        fold = inl bet -> 
                            inl player = fold (update_player bet)
                            log "{0} folds." player.name
                            on_succ (player, {d with players_active=self-1})
                        call = inl bet -> 
                            inl player = call (update_player bet) call_level
                            inl on_succ d = on_succ (player, d)
                            if player.chips = 0 then
                                log "{0} calls and is all-in!" player.name
                                on_succ {d with players_active=self-1}
                            else
                                log "{0} calls." player.name
                                on_succ {d with players_called=self+1}
                        raise = inl bet x -> 
                            assert (x >= 0) "Cannot raise to negative amounts."
                            inl player = call (update_player bet) (call_level + min_raise + x)
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
            macro.fs () [text: "// In betting's loop."]
            inl rec loop2 (s, i, d) = function
                | player :: x' as l ->
                    inl l = Tuple.append (Tuple.rev s) l
                    inl internal_representation = internal_representation i l
                    inl {reply name} = player
                    match betting { internal_representation player } d with
                    | .Some, (player, d) -> loop2 ({player with reply name} :: s, i+1, d) x'
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
            macro.fs () [text: "// In dealing."]
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
        met f x = 
            macro.fs () [text: "// In hand_rule."]
            match x with {rank=.(_) as x} -> tag_rank x
        compare (f a) (f b)

    inl round players =
        log "A new round is starting..." ()
        log "Chip counts:" ()
        Tuple.iter (inl {name chips} ->
            log "{0} has {1} chips." (name,chips)
            ) players
        dealing players (deck()) |> fst |> betting |> showdown hand_rule
        |> Tuple.map2 (inl {x with reply} {trace state chips} ->
            trace.process
            {x with state chips}
            ) players

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

        Tuple.map (inl x -> dyn {x with chips}) players
        |> loop

    inl reply_random {name} =
        inl rnd = Random()
        inl reply = inl _ _ {fold call raise} ->
            match rnd.next(0i32,5i32) with
            | 0i32 -> fold {state=(); bet=()}
            | 1i32 -> call {state=(); bet=()}
            | _ -> raise {state=(); bet=()} 0

        inl rec trace = function
            | .add_bet _ -> trace
            | .add_reward _ -> trace
            | .process -> ()

        {reply name trace state=()}

    inl Actions = .Fold, .Call, (.Raise, .0)
    inl Action = Tuple.reducel (inl a b -> a \/ b) Actions
    inl Rep = type {pot=int64; chips=int64; hand=Option.none Hand}

    inl reply {fold call raise} a bet =
        match a with
        | .Fold -> fold bet
        | .Call -> call bet
        | .Raise, .(x) -> raise bet x

    inl rec trace_mc {state_type action_type} =
        inl bet_type = .Bet, state_type, action_type, float64 => ()
        inl reward_type = .Reward, float64
        inl trace_type = bet_type \/ reward_type

        inl add_bet = stack inl l (state,action,bck) ->
            inl bck = term_cast bck float64
            inl x = box trace_type (.Bet,state,box action_type action,bck)
            List.cons x l

        inl add_reward = stack inl l x -> 
            inl x = box trace_type (.Reward, to float64 x)
            List.cons x l

        inl process = stack inl l ->
            List.foldl (inl s x -> 
                match x with
                | .Reward,x -> s + x
                | .Bet,_,_,bck -> bck s; s
                ) (dyn 0.0) l 
            |> ignore

        inl rec trace (!dyn l) = function
            | .add_bet -> add_bet l >> trace
            | .add_reward -> add_reward l >> trace
            | .process -> process l

        trace (List.empty trace_type)

    inl reply_q {init learning_rate num_players name} =
        inl state_type = Tuple.repeat num_players Rep
        inl action_type = Action

        inl box = stack (box Action)
        inl dict = Dictionary {elem_type=(state_type,Action),float64}
        inl reply rep state k =
            inl v, a = 
                Tuple.foldl (inl (s,a) (!box x) ->
                    inl v = dict (rep, x) { on_fail=const init; on_succ=id }
                    if v > s then v,x else s,a
                    ) (-infinityf64, box .Fold) Actions
            inl bck v' = dict.set (rep, a) (v + learning_rate * (v' - v))
            reply k a {state bet=rep,a,bck}

        {reply name state=(); trace=trace_mc {state_type action_type}}

    inl reply_dmc {d with bias scale range num_players name} s =
        open Learning float32
        inl state_type = Tuple.repeat num_players Rep
        inl action_type = Action
        inl d = {d with state_type action_type}
        inl net =
            match d with 
            | {distribution_size} -> RL.qr_init d s 
            | {reward_range} -> RL.kl_init d s
            | _ -> RL.square_init d s
            |> heap

        inl net_state_type =
            type
                inl f state = 
                    inl net, state = indiv net, indiv state
                    inl _, {state} = RL.action {d with net state} (var state_type) s    
                    heap state
                inl rec loop x =
                    inl x' = f x
                    if eq_type x x' then x
                    else x \/ f x'
                loop (heap {})

        inl reply s rep state k =
            match state with
            | _,_ | _ -> // Unbox the state.
                inl net, state = indiv net, indiv state
                inl a, {bck state} = RL.action {d with net state} rep s
                inl state = box net_state_type (heap state) |> dyn
                inl bck v' = bck (v' / scale + bias)
                reply k a {state bet=rep,a,bck}

        inl optimize learning_rate s = 
            inl net=indiv net
            Combinator.optimize net (Optimizer.sgd learning_rate) s
        inl trace = trace_mc {state_type action_type}

        {reply optimize name trace state=box net_state_type (heap {}) |> dyn}

    {one_card=game; reply_random reply_q reply_dmc}
    """) |> module_