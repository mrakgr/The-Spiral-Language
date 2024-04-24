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

type UI_State = {
    pl_type : RPS_Players[];
}

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('rps-ui')
class RPS_UI extends LitElement {

    @property({type: Object}) state : UI_State = {
        pl_type: ["Computer", "Human"]
    };

    socket = io('/game')
    constructor(){
        super()
        this.socket.on('update', (state) => {
            console.log(state);
            this.state = state;
        });
        this.addEventListener('rps', (ev) => {
            ev.stopPropagation();
            this.socket.emit('update', (ev as CustomEvent<RPS_Events>).detail);
        })
    }

    static styles = css`
        :host {
            display: flex;
            flex-direction: row;
            box-sizing: border-box;
            height: 100vh;
            padding: 8px;
            border: 6px solid;
            border-color: #5b0000;
            border-radius: 3px;
        }
        
        rps-menu {
            flex: 1;
        }
        
        .game_area {
            display: flex;
            flex-direction: column;
            flex: 6;
        }

        rps-game {
            flex: 6;
        }
        
        rps-history {
            flex: 1;
        }
    `
    render(){
        return html`
            <rps-menu .pl_type=${this.state.pl_type}></rps-menu>
            ${gap(10)}
            <div class="game_area">
                <rps-game></rps-game>
                ${gap(10)}
                <rps-history></rps-history>
            </div>
        `
    }
}

class RPS_Element extends LitElement {
    dispatch_rps_event = (detail : RPS_Events) => {
        this.dispatchEvent(new CustomEvent('rps', {bubbles: true, composed: true, detail}))
    }
}

@customElement('rps-game')
class RPS_Game extends RPS_Element {
    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            box-sizing: border-box;
            background-color: white;
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
            font-size: 2em;
        }
    `

    render() {
        return html`
            
            `
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

@customElement('rps-history')
class RPS_History extends RPS_Element {
    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            box-sizing: border-box;
            background-color: white;
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
            font-size: 2em;
            overflow: auto;
        }

        div {
            color: gray;
        }
    `

    @property({type: Array}) messages : string [] = ["qwe", "asd"]

    protected updated(_changedProperties: PropertyValueMap<any> | Map<PropertyKey, unknown>): void {
        // Scroll the message window to the bottom on ever new message.
        this.scrollTo({top: this.scrollHeight});
    }
    
    render() {
        return html`
            ${map(this.messages, x => html`
                <div>${x}</div>
            `)}
        `
    }
}