module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning
open Learning.Lib
open Cuda.Lib

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
    "Poker",[array;learning;random;console;option;dictionary;resize_array;object],"The Poker module.",
    """
inl Suits = .Spades :: () //, .Clubs, .Hearts, .Diamonds
inl Suit = Tuple.reducel (inl a b -> a \/ b) Suits
inl Ranks = .Two, .Three, .Four, .Five, .Six, .Seven, .Eight, .Nine, .Ten, .Jack, .Queen, .King, .Ace
inl Rank = Tuple.reducel (inl a b -> a \/ b) Ranks
inl Card = type {rank=Rank}

inl num_cards = 
    inl l = Tuple.foldl (inl s _ -> s+1) 0
    l Suits * l Ranks

inl tag_rank = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Ranks |> fst
inl tag_suit = Tuple.foldl (inl (s,v) k -> {s with $k=v}, v+1i32) ({},0i32) Suits |> fst
   
inl rnd = Random(42i32)
inl unshuffled = 
    Tuple.map (inl rank ->
        box Card {rank=box Rank rank}
        //Tuple.map (inl suit -> box Card {rank=box Rank rank; suit=box Suit suit}) Suits
        ) Ranks
    //|> Tuple.concat

inl deck _ =
    inl ar = macro.fs (array Card) [fs_array_args: unshuffled]
    assert (array_length ar = num_cards) "The number of cards in the deck must be total all the possible cards."
    Array.shuffle_inplace rnd ar

    inl deck = heapm {ar p=dyn num_cards}

    inl _ ->
        inl x = deck.p - 1
        deck.p <- x
        deck.ar x

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_card x =
    macro.fs () [text: "//In show_card."]
    inl {rank=.(a)} = x 
    a
    //inl {rank=.(a) suit=.(b)} = x 
    //string_format "{0}-{1}" (a, b)

inl {d with max_stack_size num_players} ->
    inl range = max_stack_size+1

    inl log =
        match d with
        | {log} -> log
        | _ _ _ -> ()
    inl Hand = Card // for one card poker
    inl show_hand = show_card

    inl Actions = .Fold, .Call, {raise=type Union.int {from=0; near_to=3} int64}
    inl Action = Tuple.reducel (inl a b -> a \/ b) Actions
    inl Chips = Union.int {from=0; near_to=max_stack_size+1}
    inl NilHand = type Hand \/ ()
    inl Rep = type {pot=Chips int64; chips=Chips int64; hand=NilHand}
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
            | () -> win b a
            | a' ->
                match b.hand with
                | () -> win a b
                | b' -> 
                    match hand_rule a' b' with
                    | 1i32 -> win a b
                    | 0i32 -> tie players
                    | _ -> win b a
        | _ -> 
            inl get_active = Array.filter (inl x -> x.pot > 0)
            inl get_winners active = 
                inl win_hand =
                    Array.foldl (inl s player ->
                        match s with
                        | () -> player.hand
                        | a ->
                            match player.hand with
                            | () -> box NilHand a
                            | b -> if rule a b = 1i32 then box NilHand a else box NilHand b
                        ) (box NilHand ()) active

                Array.filter (inl x -> 
                    match x.hand with
                    | () -> false
                    | x -> win_hand = x
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
            | () -> ()
            | hand -> log "{0} shows {1}" (x.name, show_hand hand)
            
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
            if i' <> i then {chips=Chips x.chips; pot=Chips x.pot; hand=dyn (box NilHand ())}
            else {chips=Chips x.chips; pot=Chips x.pot; hand=x.hand}
            ) players

    inl betting players =
        inl is_active x = x.chips > 0 && x.hand_is
        met betting {internal_representation player} {d with min_raise call_level players_called players_active} =
            macro.fs () [text: "//In betting"]
            inl on_succ = Option.some
            inl on_fail = Option.none d
            if players_called < players_active && (players_active <> 1 || player.pot < call_level) then
                if is_active player then 
                    match player.bet internal_representation with
                    | .Fold ->
                        player.fold
                        log "{0} folds." player.name
                        on_succ {d with players_active=self-1}
                    | .Call ->
                        player.call call_level
                        if player.chips = 0 then
                            log "{0} calls and is all-in!" player.name
                            on_succ {d with players_active=self-1}
                        else
                            log "{0} calls." player.name
                            on_succ {d with players_called=self+1}
                    | {raise={value=x}} ->
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
            inl hand = deck () |> box NilHand |> dyn
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
            | () -> false
            | _ -> true
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
        fold=inl s -> s.data.pot_hand.hand <- box NilHand () |> dyn
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
    inl rnd = Random(42i32)
    inl action state = {action = Union.length_one_hot Action |> to int32 |> rnd.next |> to int64 |> Union.from_one_hot Action}

    {action}
    """) |> module_

let player_tabular =
    (
    "PlayerTabular",[dictionary;array],"The tabular player.",
    """
inl {State Action init learning_rate} ->
    inl near_to = Union.length_one_hot Action
    inl dict = Dictionary {elem_type=int32, type array_create float32 near_to}
    inl action state =
        assert (eq_type State state) "The input to this function must have a type equal to State."
        inl ar = 
            inl i = Union.to_one_hot state |> to int32
            dict i {
                on_fail = inl _ -> 
                    inl ar = Array.init near_to (const init)
                    dict.set i ar
                    ar
                on_succ = id
                }

        inl v, a =
            Loops.for {from=0; near_to state=dyn (-infinityf32, 0); body=inl {state=s,a i} ->
                inl v = ar i
                if v > s then v,i else s,a
                }

        {
        action=Union.from_one_hot Action a
        bck=inl v' -> 
            inl x = v + learning_rate * (v' - v)
            ar a <- x
            x
        }

    {action}
    """) |> module_

let poker_players =
    (
    "PokerPlayers",[player_random;player_tabular;list],"The poker players module.",
    """
inl {basic_methods State Action} ->
    inl player_random {name} =
        inl {action} = PlayerRandom {Action State}

        inl methods = {basic_methods with
            bet=inl s rep -> s.data.action rep .action
            showdown=inl s v -> ()
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action}

    inl player_rules {name} =
        inl methods = {basic_methods with
            bet=inl s players -> 
                inl limit = Tuple.foldl (inl s x -> max s x.pot.value) 0 players
                /// TODO: Replace find with pick.
                inl self = Tuple.find (inl x -> match x.hand with () -> false | _ -> true) players
                match self.hand with
                | () -> failwith Action "No self in the internal representation."
                | x ->
                    match x.rank with
                    | .Ten | .Jack | .Queen | .King | .Ace -> 
                        inl {raise} = Tuple.find (function {raise} -> true | _ -> false) (split Action)
                        box Action {raise={raise with value=0}}
                    | _ -> if self.pot.value >= limit || self.chips.value = 0 then box Action .Call else box Action .Fold
            showdown=inl s v -> ()
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0}

    inl player_tabular_mc {name init learning_rate} =
        inl {action} = PlayerTabular {Action State init learning_rate}
        inl trace = ResizeArray.create {elem_type=type heap (action State .bck)}

        inl methods = {basic_methods with
            bet=inl s rep -> 
                inl {action bck} = s.data.action rep
                s.data.trace.add (heap bck)
                action
            showdown=inl s v -> s.data.trace.foldr (inl bck v -> bck v |> ignore; v) (dyn (to float32 v)) |> ignore; s.data.trace.clear
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action trace}

    inl player_tabular_sarsa {name init learning_rate} =
        inl {action} = PlayerTabular {Action State init learning_rate}
        inl trace = ResizeArray.create {elem_type=type heap (action State .bck)}

        inl methods = {basic_methods with
            bet=inl s rep -> 
                inl {action bck} = s.data.action rep
                s.data.trace.add (heap bck)
                action
            showdown=inl s v -> s.data.trace.foldr (inl bck v -> bck v) (dyn (to float32 v)) |> ignore; s.data.trace.clear
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; action trace}

    inl Learning = Learning float32

    inl player_pg {name actor learning_rate} cd =
        open Learning
        inl action = RL.action {State Action final=RL.sampling_pg}

        inl input_size = Union.length_dense State
        inl num_actions = Union.length_one_hot Action

        inl net,_ = Tuple.append (Tuple.wrap actor) (RL.Layer.pg {size=num_actions} :: ()) |> init cd input_size
        //inl net,_ = Tuple.append (Tuple.wrap actor) (Feedforward.linear num_actions :: ()) |> init cd input_size

        inl run = 
            Union.mutable_function 
                (inl {state={state with net} input={input cd}} ->
                    inl {action net bck} = action {net input} cd
                    inl bck x = 
                        Struct.foldr (inl bck _ -> bck {x with learning_rate}) bck ()
                        Struct.foldr (inl {bck} -> Struct.foldr (inl bck _ -> bck {learning_rate}) bck) net ()
                    {state={net bck}; out=action}
                    )
                {state={net}; input={input=State; cd}}

        inl methods = {basic_methods with
            bet=inl s input -> s.data.run {input cd=s.data.cd}
            showdown=inl s reward -> 
                inl l = s.data.run.reset
                inl reward = dyn (to float32 reward)
                List.foldl (inl _ -> function {bck} -> bck {reward} | _ -> ()) () l

                Optimizer.standard learning_rate s.data.cd s.data.net
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; net run}

    inl player_mc_ac {d with name learning_rate discount_factor} cd =
        open Learning
        inl action = RL.action {State Action final=RL.sampling_pg}

        inl input_size = Union.length_dense State
        inl num_actions = Union.length_one_hot Action

        inl learning_rate = {
            actor=learning_rate
            critic=learning_rate ** 0.85f32
            shared=learning_rate
            }

        // The RL layers use the PRONG updates.
        inl actor = match d with {actor} -> Tuple.append (Tuple.wrap actor) (RL.Layer.pg {size=num_actions}  :: ()) | _ -> RL.Layer.pg {size=num_actions}
        inl critic = match d with {critic} -> critic :: RL.Layer.mc {} :: () | _ -> RL.Layer.mc {}
        // The feedforward linear layers do not use PRONG updates.
        //inl actor = match d with {actor} -> Tuple.append (Tuple.wrap actor) (Feedforward.linear num_actions  :: ()) | _ -> Feedforward.linear num_actions
        //inl critic = match d with {critic} -> critic :: Feedforward.linear 1 :: () | _ -> Feedforward.linear 1
        inl shared = match d with {shared} -> shared | _ -> ()

        inl shared, shared_size = init cd input_size shared
        inl actor, _ = init cd shared_size actor
        inl critic, _ = init cd shared_size critic

        inl block_critic_gradients =
            match d with
            | {block_critic_gradients} -> block_critic_gradients
            | _ -> true

        inl run = 
            Union.mutable_function 
                (inl {state={state with shared actor critic} input={input cd}} ->
                    assert (eq_type State input) "The input must be equal to the state type."
                    inl input = 
                        inl tns = Union.to_dense input |> Tensor.array_as_tensor
                        cd.CudaTensor.from_host_tensor tns .reshape (inl x -> 1, Union.length_dense State)
                    inl shared, shared_out = run cd input shared
                    inl actor, actor_out = run cd shared_out actor
                    inl {out bck=actor_bck} = RL.sampling_pg actor_out cd
                    inl critic, critic_out = 
                        if block_critic_gradients then run cd (primal shared_out) critic
                        else run cd shared_out critic

                    inl bck x = 
                        inl {value bck=critic_bck} = RL.Value.mc critic_out cd x
                        critic_bck {learning_rate=learning_rate.critic}
                        actor_bck {reward=value}
                        inl f learning_rate network = Struct.foldr (inl {bck} -> Struct.foldr (inl bck _ -> bck {learning_rate=learning_rate}) bck) network ()
                        f learning_rate.critic critic; f learning_rate.actor actor; f learning_rate.shared shared
                        
                    inl action = Union.from_one_hot Action (cd.CudaTensor.get (out 0))
                    {state={actor critic shared bck}; out=action}
                    )
                {state={shared actor critic}; input={input=State; cd}}

        inl methods = {basic_methods with
            bet=inl s input -> s.data.run {input cd=s.data.cd}
            showdown=inl s reward -> 
                inl l = s.data.run.reset
                inl reward = dyn (to float32 reward)
                inl original = discount_factor
                List.foldl (inl discount_factor x -> 
                    match x with
                    | {bck} -> bck {discount_factor reward} 
                    | _ -> ()
                    original*discount_factor
                    ) discount_factor l
                |> ignore

                inl cd = s.data.cd
                inl f learning_rate = Optimizer.standard learning_rate cd

                f learning_rate.shared s.data.shared
                f learning_rate.actor s.data.actor
                f learning_rate.critic s.data.critic
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; actor shared critic run}

    {
    player_random player_rules player_tabular_mc player_tabular_sarsa player_pg player_mc_ac
    } |> stackify
    """) |> module_
