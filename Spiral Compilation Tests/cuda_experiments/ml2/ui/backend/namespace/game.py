from typing import NamedTuple

from flask import request
from core import socketio
from flask_socketio import Namespace, emit

class UserState(NamedTuple):
    games_played : int

user_state : dict[str, UserState] = {}

class GameNamespace(Namespace):
    def on_connect(self):
        print(request.sid)
        user_state[request.sid] = UserState(0)
        print('Client connected')
        # emit('my response', {'data': 'Connected'})
        pass

    def on_disconnect(self):
        print(request.sid)
        user_state.pop(request.sid)
        print('Client disconnected')

    def on_update(self, data):
        print('received message: ' + str(data))
        # emit('my_response', data)