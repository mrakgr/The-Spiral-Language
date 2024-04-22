import {LitElement, css, html} from 'lit';
import {customElement, property} from 'lit/decorators.js';
import {io} from 'socket.io-client'

type RPSEvents = 
    | ['start_game', true]

@customElement('spiral-ui')
class SpiralUI extends LitElement {
    static classes = css`
        .main {
            display: flex;
            flex-direction: row;
        }

        rps-menu {
            flex: 1
        }

        .game-area {
            flex: 3
        }
    `

    constructor(){
        super()
        const socket = io('/game');
        socket.on('connect', function() {
            socket.emit('update', {data: 'I\'m connected!'});
        });
        this.addEventListener('rps', (ev) => {
            ev.stopPropagation()
            socket.emit('update', {data: 'Starting the game.'});
        })
    }
    
    render(){
        return html`
            <div class='main'>
                <rps-menu></rps-menu>
                <div class='game-area'>
                    Game Area
                </div>
                <div></div>
            </div>
        `
    }
}


class RPSElement extends LitElement {
    dispatch_rps_event = (detail : RPSEvents) => {
        this.dispatchEvent(new CustomEvent('rps', {bubbles: true, composed: true, detail}))
    }
}

@customElement('rps-menu')
class RPSMenu extends RPSElement {

    static classes = css`
        /* :host {
            flex: 1
        } */
    `
    
    start_game = () => this.dispatch_rps_event(['start_game', true])

    render() {
        return html`
            <div>
                <button @click=${this.start_game}>Start Game</button>
            </div>
        `
    }
}