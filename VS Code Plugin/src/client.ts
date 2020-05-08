import * as ipc from "node-ipc";


ipc.config.id   = 'world';
ipc.config.retry= 1500;
ipc.connectTo(
    'world',
    () => {
        ipc.of.world.on(
            'connect',
            () => {
                ipc.log('## connected to world ##', (<any>ipc.config).delay);
                ipc.of.world.emit(
                    'message',  //any event or message type your server listens for
                    'hello'
                )
            }
        );
        ipc.of.world.on(
            'disconnect',
            function(){
                ipc.log('disconnected from world');
            }
        );
        ipc.of.world.on(
            'message',  //any event or message type your server listens for
            (data: any) => {
                ipc.log('got a message from world : ', data);
            }
        );
    }
);