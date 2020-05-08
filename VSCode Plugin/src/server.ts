import * as ipc from "node-ipc";

ipc.config.id   = 'world';
ipc.config.retry= 1500;

ipc.serve(
    () => {
        ipc.server.on(
            'message',
            (data,socket) => {
                ipc.log('got a message : ', data);
                ipc.server.emit(
                    socket,
                    'message',  //this can be anything you want so long as
                                //your client knows.
                    data+' world!'
                );
            }
        );
        ipc.server.on(
            'socket.disconnected',
            (socket, destroyedSocketID) => {
                ipc.log('client ' + destroyedSocketID + ' has disconnected!');
            }
        );
    }
);

ipc.server.start();

