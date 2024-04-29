from typing import Any, Callable, Never, TypedDict, Literal

from flask import request
from flask_socketio import Namespace, emit # type: ignore

RPS_Players = Literal["Computer", "Human"]
RPS_Action = Literal["Rock", "Paper", "Scissors"]
RPS_Events = \
    tuple[Literal["start_game"], Literal[True]] \
    | tuple[Literal["player_changed"], list[RPS_Players]] \
    | tuple[Literal["action_selected"], RPS_Action]
RPS_Game_State = \
    tuple[Literal["game_not_started"], Literal[True]] \
    | tuple[Literal["waiting_for_action_from_player_id"], int] \
    | tuple[Literal["game_over"], list[RPS_Action]] \

class UI_State(TypedDict):
    pl_type : list[RPS_Players]
    game_state : RPS_Game_State
    messages : list[str]

class Game_State(TypedDict):
    past_actions: list[RPS_Action]

class Main_State(TypedDict):
    ui_state : UI_State
    game_state : Game_State

def ui_init() -> UI_State: return {
    "pl_type": ["Computer", "Human"],
    "game_state": ("game_not_started", True),
    "messages": ["Waiting to start the game..."],
}
def game_init() -> Game_State: return {
    "past_actions": []
}
def main_init() -> Main_State: return {
    "ui_state": ui_init(),
    "game_state": game_init()
}
def assert_never(x : Never) -> Never: raise TypeError(f"Unexpected tag.\nGot: ${x}")

class GameNamespace(Namespace):
    user_state : dict[str, Main_State] = {}

    def sid(self) -> str: return request.sid # type: ignore
    def emit_update(self, data: UI_State): emit('update', data)

    def on_connect(self):
        print(f'Client connected: {self.sid()}')
        state = main_init()
        GameNamespace.user_state[self.sid()] = state
        self.emit_update(state["ui_state"])

    def on_disconnect(self):
        GameNamespace.user_state.pop(self.sid())
        print(f'Client disconnected: {self.sid()}')

    def on_update(self, msg : RPS_Events):
        state = GameNamespace.user_state[self.sid()]
        ui_state = state["ui_state"]
        game_state = state["game_state"]

        def random_action() -> RPS_Action:
            from game.rps.main import main
            funs = main()
            return funs.random_action()
        # def random_action() -> RPS_Action:
        #     import random
        #     return random.choice(["Rock", "Paper", "Scissors"])

        def game_step(action : RPS_Action | None = None):
            """
            The game loop. The action passed into it should only be from the UI, all the other cases are None.
            """
            match ui_state["game_state"]:
                case ("game_not_started", _) | ("game_over", _):
                    pass
                case ("waiting_for_action_from_player_id", id) if id < 2:
                    assert len(game_state["past_actions"]) == id, "The number of past actions must equal the player id."
                    match ui_state["pl_type"][id]:
                        case "Computer":
                            assert action == None, "The computer player should never be receiving an action."
                            action = random_action()
                            ui_state["game_state"] = ("waiting_for_action_from_player_id", id+1)
                            game_state["past_actions"] = [*game_state["past_actions"], action]
                            game_step()
                        case "Human":
                            match action:
                                case None:
                                    pass # Wait for the action from the UI.
                                case _:
                                    ui_state["game_state"] = ("waiting_for_action_from_player_id", id+1)
                                    game_state["past_actions"] = [*game_state["past_actions"], action]
                                    game_step()
                        case t:
                            assert_never(t)
                case ("waiting_for_action_from_player_id", _):
                    def showdown_messages(actions : list[RPS_Action]):
                        match actions:
                            case ["Rock", "Rock"] | ["Paper", "Paper"] | ["Scissors", "Scissors"]:
                                return [f"Both players show {actions[0]}!", "It's a tie!"]
                            case _:
                                msg = [f"Player 0 shows {actions[0]} and player 1 shows {actions[1]}!"]
                                match actions:
                                    case ["Rock", "Paper"] | ["Scissors", "Rock"] | ["Paper", "Scissors"]:
                                        msg.append("Player 1 wins!")
                                    case _:
                                        msg.append("Player 0 wins!")
                                return msg
                            
                    actions = game_state["past_actions"]
                    ui_state["game_state"] = ("game_over",actions)
                    ui_state["messages"] = showdown_messages(actions)
                    game_state["past_actions"] = []
                case t:
                    assert_never(t)

        match msg:
            case ["player_changed", pl_type]:
                ui_state["pl_type"] = pl_type
                game_step()
            case ["start_game", _]:
                ui_state["game_state"] = ("waiting_for_action_from_player_id", 0)
                ui_state["messages"] = ["Rock-Paper-Scissors!"]
                game_state["past_actions"] = []
                game_step()
            case ["action_selected", action]:
                game_step(action)
            case t:
                assert_never(t)

        self.emit_update(ui_state)
