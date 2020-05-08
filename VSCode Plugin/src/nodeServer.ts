import * as net from "net";
import * as path from "path";

const PATH = path.join('\\\\?\\pipe', 'my', 'ctl');
const server = net.createServer();
server.on("connection",x => {
    console.log("Got a connection.");
    x.on("data", data => {
        const s = String(data);
        console.log(s);
        if (s === "close") { 
            console.log("Will close.");
            server.close(); }
    });
    x.on("close", had_error => {
        console.log("The connection closed.");
    })
})
server.on("listening",() => {
    console.log("Listening...");
})
server.on("close",() => {
    console.log("Closing.");
});
server.listen(PATH);
