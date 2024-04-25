from typing import Any, Never, TypedDict, Literal

from flask import request
from flask_socketio import Namespace, emit # type: ignore

        # type RPS_Events = 
        #     | ['start_game', true]
        #     | ['player_changed', RPS_Players[]]
        #     | ['action_selected', RPS_Action]

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

class Main_State(TypedDict):
    ui_state : UI_State
    # game_state : RPS_Game_State

def ui_init() -> UI_State: return {
    "pl_type": ["Computer", "Human"],
    "game_state": ("game_not_started", True),
    "messages": ["Waiting to start the game..."],
}
# def game_init() -> RPS_Game_State: return []
def main_init() -> Main_State: return {
    "ui_state": ui_init(),
    # "game_state": ()
}
user_state : dict[str, Main_State] = {}
def assert_never(x : Never) -> Never: raise TypeError(f"Unexpected tag.\nGot: ${x}")

class GameNamespace(Namespace):
    def sid(self) -> str: return request.sid # type: ignore
    def emit_update(self, data: UI_State): emit('update', data)

    def on_connect(self):
        print(f'Client connected: {self.sid()}')
        state = main_init()
        user_state[self.sid()] = state
        self.emit_update(state["ui_state"])

    def on_disconnect(self):
        user_state.pop(self.sid())
        print(f'Client disconnected: {self.sid()}')

    def on_update(self, msg : RPS_Events):
        state = user_state[self.sid()]
        ui_state = state["ui_state"]

        match msg:
            case ["player_changed", pl_type]:
                ui_state["pl_type"] = pl_type
            case ["start_game", _]:
                ui_state["game_state"] = ("waiting_for_action_from_player_id", 0)
                ui_state["messages"] = ["Rock-Paper-Scissors!"]
            case ["action_selected", action]:
                print(f"Got action: {action}")
            case t:
                assert_never(t)

        self.emit_update(ui_state)
