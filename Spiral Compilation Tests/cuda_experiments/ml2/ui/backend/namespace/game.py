from typing import NamedTuple

from flask import request
from core import socketio
from flask_socketio import Namespace, emit

# type UI_State = {
#     pl_type : RPS_Players[];
#     game_state : RPS_Game_State;
#     messages : string[];
# }
def init_state(): return {
    "pl_type": ["Computer", "Human"],
    "game_state": ["game_not_started", True],
    "messages": ["Waiting to start the game..."],
}
user_state : dict[str, any] = {}

class GameNamespace(Namespace):
    def on_connect(self):
        print(f'Client connected: {request.sid}')
        user_state[request.sid] = init_state()
        emit('update', user_state[request.sid])

    def on_disconnect(self):
        user_state.pop(request.sid)
        print(f'Client disconnected: {request.sid}')

    def on_update(self, msg):
        state : dict = user_state[request.sid]

        # type RPS_Events = 
        #     | ['start_game', true]
        #     | ['player_changed', RPS_Players[]]
        #     | ['action_selected', RPS_Action]
        match msg:
            case ["player_changed", pl_type]:
                state["pl_type"] = pl_type
            case ["start_game", _]:
                state["game_state"] = ["waiting_for_action_from_player_id", 0]
                state["messages"] = ["Rock-Paper-Scissors!"]
            case ["action_selected", action]:
                print(f"Got action: {action}")

        emit('update', state)
