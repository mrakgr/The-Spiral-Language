import * as net from "net";
import * as path from "path";

const PATH = path.join('\\\\?\\pipe', 'my/ctl');
const client = net.createConnection(PATH);
client.write("Hello");
client.write("close");