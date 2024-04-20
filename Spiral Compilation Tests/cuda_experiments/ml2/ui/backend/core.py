from flask import Flask
from flask_socketio import SocketIO


app = Flask(__name__, static_url_path="")
app.config['SECRET_KEY'] = 'secret!'
socketio = SocketIO(app)
