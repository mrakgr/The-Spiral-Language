from core import socketio, app
from routes import main_page
from namespace.rps_game import RPS_Namespace
from namespace.leduc_game import Leduc_Namespace
from namespace.hu_nl_holdem_game import HU_NL_Holdem_Namespace

def run_debug(): 
    """
    Runs the applicaation in debug mode with SocketIO support.
    """
    socketio.run(app,debug=True) # type: ignore
    
app.register_blueprint(main_page)
socketio.on_namespace(RPS_Namespace('/rps_game'))
socketio.on_namespace(Leduc_Namespace('/leduc_game'))
socketio.on_namespace(HU_NL_Holdem_Namespace('/hu_nl_holdem_game'))

if __name__ == "__main__": run_debug()
