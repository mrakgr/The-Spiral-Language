from core import socketio, app
from routes import main_page
from namespace.game import GameNamespace

def run_debug(): 
    """
    Runs the applicaation in debug mode with SocketIO support.
    """
    socketio.run(app,debug=True) # type: ignore
    
app.register_blueprint(main_page)
socketio.on_namespace(GameNamespace('/game'))

if __name__ == "__main__": run_debug()
