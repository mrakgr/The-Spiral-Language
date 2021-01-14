import { send } from "process"
import * as zmq from "zeromq"

const port = 13111

const request = async (file: object): Promise<any> => {
    const sock = new zmq.Request()
    const uri = `tcp://localhost:${port}`
    sock.connect(uri)
    const msg = JSON.stringify(file)
    await sock.send(msg)
    console.log(`Sent: ${msg}`)
    const [x] = await sock.receive()
    sock.disconnect(uri)
    return 0 < x.byteLength ? JSON.parse(x.toString()) : null
}

console.log("Hello.");

request({qwe: true})
request({asd: false})

console.log("Done.");

