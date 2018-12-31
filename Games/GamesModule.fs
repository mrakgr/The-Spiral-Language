module Games.Module

open Spiral.Types
open Spiral.Lib
open Learning
open Learning.Lib
open Cuda.Lib

let player_tabular =
    (
    "PlayerTabular",[dictionary;resize_array;array],"The tabular player.",
    """
inl base {init elem_type=!(Tuple.wrap) elem_type} =
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
    """) |> module_