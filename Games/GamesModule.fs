module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning
open Learning.Lib
open Cuda.Lib

let poker: SpiralModule =
    {
    name="Poker"
    prerequisites=[array; learning; random; console; option; dictionary; resize_array; object]
    opens=[]
    description="The Poker module."
    code=
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
    """
    }

let player_random: SpiralModule =
    {
    name="PlayerRandom"
    prerequisites=[random]
    opens=[]
    description="The player which selects actions at random."
    code=
    """
inl {State Action} ->
    inl rnd = Random(42i32)
    inl action state = {action = Union.length_one_hot Action |> to int32 |> rnd.next |> to int64 |> Union.from_one_hot Action}

    {action}
    """
    }

let player_tabular: SpiralModule =
    {
    name="PlayerTabular"
    prerequisites=[dictionary; resize_array; array]
    opens=[]
    description="The tabular player."
    code=
    """
inl base {init elem_type=!(Tuple.wrap) elem_type} = // Is capable of taking multiple `{Observation Action}` or just `{Observation}` atoms.
    inl float = float32
    inl zero = to float 0
    inl one = to float 1
    inl dicts = 
        Tuple.map (inl x ->
            match x with
            | {Observation Action} -> {x with dict = Dictionary {elem_type=int32, array float}}
            | {Observation} -> {x with dict = Dictionary {elem_type=int32, float}}
            ) elem_type
    
    inl rec act {learning_rate discount trace} obs =
        inl rec loop = function
            | {Observation=(_: obs) Action dict} :: _ ->
                inl near_to = Union.length_one_hot Action
                inl ar =
                    inl i = Union.to_one_hot obs |> to int32
                    dict i {
                        on_fail = inl _ -> 
                            inl ar = Array.init near_to (const init)
                            dict.set i ar
                            ar
                        on_succ = id
                        }

                inl V, a =
                    Loops.for {from=0; near_to state=dyn (-infinityf32, 0); body=inl {state=s,a i} ->
                        inl V = ar i
                        if V > s then V,i else s,a
                        }

                {
                action=Union.from_one_hot Action a
                bck=inl V' -> 
                    ar a <- V + learning_rate * (V' - V)
                    discount * (trace * V' + (one - trace) * V)
                }
            | {Observation=(_: obs) dict} :: _ ->
                inl i = Union.to_one_hot obs |> to int32
                inl V =
                    dict i {
                        on_fail = inl _ -> dict.set i init; init
                        on_succ = id
                        }

                {
                bck=inl V' -> 
                    dist.set i (V + learning_rate * (V' - V))
                    discount * (trace * V' + (one - trace) * V)
                }
            | _ :: next -> loop next
            | () -> error_type {message = "The type of the argument matches none of the `elem_type`s."; argument=obs; elem_type}
        loop dicts

    inl reward !dyn rew = { bck = inl V' -> rew + V' }

    {act reward}

inl template {init elem_type learning_rate discount trace} =
    inl float = float32
    inl zero = to float 0
    inl bcks = ResizeArray.create {elem_type=float => float}

    inl player = base {init elem_type}

    inl act obs =
        inl {x with bck} = player.act {learning_rate discount trace} obs
        bcks.add (term_cast bck float)
        match x with
        | {action} -> action
        | _ -> ()

    inl reward x = 
        inl {bck} = player.reward (to float x |> dyn)
        bcks.add (term_cast bck float)

    inl optimize _ = bcks.foldr (<|) zero |> ignore; bcks.clear

    {act reward optimize}

{
template
} |> stackify
    """
    }

let poker_players: SpiralModule =
    {
    name="PokerPlayers"
    prerequisites=[player_random; player_tabular; list]
    opens=[]
    description="The poker players module."
    code=
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

    inl player_tabular {name init learning_rate discount trace} = 
        inl player = PlayerTabular.template {init elem_type={Observation=State; Action}; learning_rate trace discount}
        inl methods = {basic_methods with
            bet=inl s rep -> s.data.player.act rep
            showdown=inl s reward -> s.data.player.reward reward
            game_over=inl s -> s.data.player.optimize()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; player}

    inl Learning = Learning float32

    inl player_ac {rate network name discount} cd =
        open Learning
        inl input_size = Union.length_dense State
        inl num_actions = Union.length_one_hot Action

        inl network, _ = init cd input_size (network, RL.ac num_actions)
        inl player = 
            Agent.rl.initialize
                {rate discount network context=cd; error=Error.softmax_cross_entropy; Observation=State; Action}

        inl methods = {basic_methods with
            bet=inl s rep -> s.data.player.act rep
            showdown=inl s reward -> s.data.player.reward (to float32 reward); s.data.player.backward; s.data.player.optimize; s.data.player.truncate
            game_over=inl s -> ()
            }

        Object
            .member_add methods
            .data_add {name; win=ref 0; player}

    {
    player_random player_rules player_tabular player_ac
    } |> stackify
    """
    }
