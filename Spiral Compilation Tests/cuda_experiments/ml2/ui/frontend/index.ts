import {LitElement, html} from 'lit';
import {customElement, property} from 'lit/decorators.js';
import {io} from 'socket.io-client'

@customElement('spiral-ui')
class SpiralUI extends LitElement {
    constructor(){
        super()
        const socket = io('/game');
        socket.on('connect', function() {
            socket.emit('update', {data: 'I\'m connected!'});
        });
    }
    
    render(){
        return html`
            <h1>Hello World</h1>
        `
    }
}

// customElements.define('spiral-ui',SpiralUI)
