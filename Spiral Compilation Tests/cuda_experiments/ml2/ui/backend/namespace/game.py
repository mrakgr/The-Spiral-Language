from typing import NamedTuple

from flask import request
from core import socketio
from flask_socketio import Namespace, emit

# type UI_State = {
#     pl_type : RPS_Players[];
# }
def init_state(): return {
    "pl_type": ["Computer", "Human"]
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
        match msg:
            case ["player_changed", pl_type]:
                state["pl_type"] = pl_type
        emit('update', state)
