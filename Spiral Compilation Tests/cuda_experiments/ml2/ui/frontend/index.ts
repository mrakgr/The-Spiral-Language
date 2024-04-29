import {LitElement, PropertyValueMap, css, html} from 'lit';
import {customElement, property} from 'lit/decorators.js';
import { live } from 'lit/directives/live.js';
import { map } from 'lit/directives/map.js';
import {io} from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error("Invalid tag.")};
const assert_type_in = <T>(x : T, in_ : T[]): T => in_.includes(x) ? x : (() => { throw Error("The element in not in the list.") })()

type RPS_Action = "Rock" | "Paper" | "Scissors"
type RPS_Players = "Computer" | "Human"
const rps_players : RPS_Players[] = ["Computer", "Human"]

type RPS_Events =
    | ['start_game', true]
    | ['player_changed', RPS_Players[]]
    | ['action_selected', RPS_Action]

type RPS_Game_State =
    | ["game_not_started", true]
    | ["waiting_for_action_from_player_id", number]
    | ["game_over", RPS_Action[]]

type UI_State = {
    pl_type : RPS_Players[];
    game_state : RPS_Game_State;
    messages : string[];
}

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('rps-ui')
class RPS_UI extends LitElement {
    @property({type: Object}) state : UI_State = {
        pl_type: ["Computer", "Human"],
        game_state: ["game_not_started", true],
        messages: ["Waiting to start the game..."]
    };

    socket = io('/game')
    constructor(){
        super()
        this.socket.on('update', (state : UI_State) => {
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
                <rps-game .state=${this.state.game_state}></rps-game>
                ${gap(10)}
                <rps-history .messages=${this.state.messages}></rps-history>
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
            background-color: hsl(0,100%,98%);
            padding: 4px;
            border: 3px solid;
            border-radius: 5px;
            height: 100%;
            font-size: 2em;
            align-items: center;
        }

        div {
            display: flex;
            flex-direction: column;
            align-items: center;
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
                <label for="pl1">Player 0:</label>
                <select name="pl1" id="pl1" .value=${live(this.pl_type[0])} @change=${this.on_change(0)}>
                    <option value="Computer">Computer</option>
                    <option value="Human">Human</option>
                </select>
            </div>
            ${gap(10)}
            <div>
                <label for="pl2">Player 1:</label>
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


@customElement('rps-game')
class RPS_Game extends RPS_Element {
    @property({type: Array}) state : RPS_Game_State = ["game_not_started", true]

    on_action = (action : RPS_Action) => () => {
        this.dispatch_rps_event(["action_selected", action])
    }

    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            box-sizing: border-box;
            background-color: white;
            padding: 80px;
            border: 3px solid;
            border-radius: 5px;
            font-size: 2em;
            align-items: center;
            justify-content: space-between
        }

        .actions {
            flex-direction: row;
        }

        button {
            font-size: inherit;
        }
    `

    render_state(){
        const [tag,arg] = this.state
        const f_false = html`
            <div>
                The opponent is pondering...
            </div>
        `
        const f_true = html`
            <div class="actions">
                <button @click=${this.on_action("Rock")}>Rock</button>
                <button @click=${this.on_action("Paper")}>Paper</button>
                <button @click=${this.on_action("Scissors")}>Scissors</button>
            </div>
        `
        const f = (c : boolean) => c ? f_true : f_false;

        switch (tag){
            case "game_not_started": return html`
                <div>
                    Please start the game...
                </div>
            `
            case "waiting_for_action_from_player_id": return html`
                ${f(arg === 0)}
                <div>
                    Game in progress...
                </div>
                ${f(arg === 1)}
                `
            case "game_over": return html`
                <div>
                    ${arg[0]}
                </div>
                <div>
                    ${arg[1]}
                </div>
            `
        }
    }

    render() {
        return html`
            ${this.render_state()}
            `
    }
}