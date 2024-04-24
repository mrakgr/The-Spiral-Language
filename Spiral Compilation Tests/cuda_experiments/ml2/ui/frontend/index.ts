import {LitElement, PropertyValueMap, css, html} from 'lit';
import {customElement, property} from 'lit/decorators.js';
import { live } from 'lit/directives/live.js';
import { map } from 'lit/directives/map.js';
import {io} from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error("Invalid tag.")};
const assert_type_in = <T>(x : T, in_ : T[]): T => in_.includes(x) ? x : (() => { throw Error("The element in not in the list.") })()

type RPS_Actions = "Rock" | "Paper" | "Scissors"
type RPS_Players = "Computer" | "Human"
const rps_players : RPS_Players[] = ["Computer", "Human"]

type RPS_Events = 
    | ['start_game', true]
    | ['player_changed', RPS_Players[]]


// type RPS_State = 
//     | ["game_done", {
//         player_1_action : RPS_Actions
//         player_2_action : RPS_Actions
//     }]
//     | ["game_not_started", true]
//     | ["game_waiting", {
//         player_1_action : RPS_Actions | null
//         player_2_action : RPS_Actions | null
//     }]

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('spiral-ui')
class Spiral_UI extends LitElement {
    static styles = css`
        :host {
            display: block;
            box-sizing: border-box;
            height: 100vh;
            padding: 8px;
            border: 6px solid;
            border-color: #5b0000;
            border-radius: 3px;
        }

        .main {
            display: flex;
            flex-direction: row;
            height: 100%;
            box-sizing: border-box;
        }

        rps-menu {
            flex: 1;
        }

        .game-area {
            flex: 6;
        }
    `

    @property({type: Array}) pl_type : RPS_Players[] = ["Computer", "Human"];

    on_rps = ([tag, arg] : RPS_Events) => {
        switch (tag){
            case "player_changed":
                this.pl_type = arg;
                break;
            case 'start_game':
                break;
            default:
                assert_tag_is_never(tag);
        }
    }

    constructor(){
        super()
        const socket = io('/game');
        socket.on('connect', function() {
            socket.emit('update', {data: `I'm connected!`});
        });
        this.addEventListener('rps', (ev) => {
            ev.stopPropagation();
            this.on_rps((ev as CustomEvent<RPS_Events>).detail)
        })
    }

    render(){
        return html`
            <div class='main'>
                <rps-menu .pl_type=${this.pl_type}></rps-menu>
                ${gap(10)}
                <div class='game-area'>
                    Game Area
                </div>
                <div></div>
            </div>
        `
    }
}

class RPS_Element extends LitElement {
    dispatch_rps_event = (detail : RPS_Events) => {
        this.dispatchEvent(new CustomEvent('rps', {bubbles: true, composed: true, detail}))
    }
}

@customElement('rps-menu')
class RPS_Menu extends RPS_Element {
    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            box-sizing: border-box;
            background-color: #d7d7d7;
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
            height: 100%;
            font-size: 2em;
        }

        button {
            width: 100%;
            font-size: inherit;
            height: 2.5em;
        }
        
        select {
            font-size: inherit;
        }
    `

    @property({type: Array}) pl_type : RPS_Players[] = ["Computer", "Human"];
    
    start_game = () => this.dispatch_rps_event(['start_game', true])
    on_change = (pl_id : number) => (ev : any) => {
        const pl_type = this.pl_type.map((x,i) => assert_type_in(i !== pl_id ? x : ev.target.value, rps_players));
        this.dispatch_rps_event(["player_changed", pl_type])
    }

    render() {
        return html`
            <div>
                <button @click=${this.start_game}>Start Game</button>
            </div>
            ${gap(10)}
            <div>
                <label for="pl1">Player 1:</label>
                <select name="pl1" id="pl1" .value=${live(this.pl_type[0])} @change=${this.on_change(0)}>
                    <option value="Computer">Computer</option>
                    <option value="Human">Human</option>
                </select>
            </div>
            ${gap(10)}
            <div>
                <label for="pl2">Player 2:</label>
                <select name="pl2" id="pl2" .value=${live(this.pl_type[1])} @change=${this.on_change(1)}>
                    <option value="Computer">Computer</option>
                    <option value="Human">Human</option>
                </select>
            </div>
            `
    }
}

@customElement('rps-game')
class RPS_Game extends RPS_Element {
    static styles = css`
        :host {
            display: block;
            background-color: #d7d7d7;
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
            min-height: 80vh;
        }

        button {
            width: 100%;
        }
    `
    
    start_game = () => this.dispatch_rps_event(['start_game', true])

    render() {
        return html`
            <button @click=${this.start_game}>Start Game</button>
        `
    }
}

@customElement('rps-history')
class RPS_History extends RPS_Element {
    static styles = css`
        :host {
            display: block;
            background-color: #d7d7d7;
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
        }
    `

    @property({type: Array}) messages : string [] = []
    
    render() {
        return html`
            ${map(this.messages, x => html`
                <div>${x}</div>
            `)}
        `
    }
}