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

inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32

met show_card x =
    inl {rank=.(a) suit=.(b)} = x 
    string_format "{0}-{1}" (a, b)

inl log ->
    inl Hand = Card // for one card poker
    inl show_hand = show_card

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
        
        loop players
            {
            min_raise=2
            call_level = Tuple.foldl (inl s x -> if is_active x then max s x.pot else s) 0 players
            players_active = Tuple.foldl (inl s x -> if is_active x then s+1 else s) 0 players
            players_called = 0
            }

    inl round players = 
        Tuple.map (inl player -> {player with hand=box Hand {rank=box Rank .Ace; suit=box Suit .Hearts} |> Option.some |> dyn; pot=dyn 0}) players
        |> betting
        |> ignore

    inl game chips players =
        Tuple.map (inl x -> {x with chips}) players
        |> Tuple.map (inl x ->
                inl x = 
                    join 
                        macro.fs () [text: "//Free vars"]
                        x
                inl x = 
                    join 
                        macro.fs () [text: "//Free vars2"]
                        x
                x
                )
        //|> Tuple.map (module_map (inl _ x -> join x))
        //|> Tuple.map (function
        //    | {chips name reply trace} -> {chips name reply trace}
        //    | {chips name reply} -> {chips name reply}
        //    )
        |> round

    inl reply_random =
        inl rnd = Random()
        inl _ {fold call raise} ->
            match rnd.next(0i32,5i32) with
            | 0i32 -> fold ()
            | 1i32 -> call ()
            | _ -> raise () 0

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

    {one_card=game; reply_random reply_q}
    """) |> module_