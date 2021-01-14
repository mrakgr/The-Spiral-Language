import { send } from "process"
import * as zmq from "zeromq"

const port = 13111;

(async () => {
    const sock = new zmq.Reply()
    const uri = `tcp://*:${port}`
    await sock.bind(uri)
    while (true) {
        const [x] = await sock.receive()
        const msg = x.toString()
        console.log(`Received: ${msg}`);
        sock.send(null)
    }
})();

console.log("Hello.");
