import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';
import { map } from 'lit/directives/map.js';
import { io } from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error(`Invalid tag. Got: ${tag}`)};

type RPS_Action = ["Rock",[]] | ["Paper",[]] | ["Scissors",[]]
type RPS_Players = ["Computer",[]] | ["Human",[]]
const rps_players : RPS_Players[] = [["Computer",[]], ["Human",[]]]

type RPS_Events =
    | ['StartGame', []]
    | ['PlayerChanged', RPS_Players[]]
    | ['ActionSelected', RPS_Action]

type RPS_Game_State =
    | ["GameNotStarted", []]
    | ["WaitingForActionFromPlayerId", number]
    | ["GameOver", RPS_Action[]]
    
type Message =
    | ["ShowdownResult", [RPS_Action, RPS_Action]]
    | ["WaitingToStart",[]]
    | ["GameStarted",[]]

type UI_State = {
    pl_type : RPS_Players[];
    game_state : RPS_Game_State;
    messages : Message;
}

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('rps-ui')
class RPS_UI extends LitElement {
    @property({type: Object}) state : UI_State = {
        pl_type: rps_players,
        game_state: ["GameNotStarted", []],
        messages: ["WaitingToStart",[]]
    };

    socket = io('/rps_game')
    constructor(){
        super()
        this.socket.on('update', (state : UI_State) => {
            this.state = state;
        });
        this.addEventListener('game', (ev) => {
            ev.stopPropagation();
            this.socket.emit('update', (ev as CustomEvent<RPS_Events>).detail);
        })
    }

    static styles = css`
        :host {
            display: flex;
            flex-direction: row;
            box-sizing: border-box;
            height: 100%;
        }
        
        rps-menu {
            flex: 1;
        }
        
        .game_area {
            display: flex;
            flex-direction: column;
            flex: 5;
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
                <rps-history .message=${this.state.messages}></rps-history>
            </div>
        `
    }
}

class RPS_Element extends LitElement {
    dispatch_rps_event = (detail : RPS_Events) => {
        this.dispatchEvent(new CustomEvent('game', {bubbles: true, composed: true, detail}))
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
            padding: var(--sl-spacing-x-small);
            border: 3px solid;
            border-radius: 5px;
            height: 100%;
            align-items: center;
        }

        div {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        sl-select {
            text-align: center
        }
    `

    @property({type: Array}) pl_type : RPS_Players[] = rps_players;
    
    start_game = () => this.dispatch_rps_event(['StartGame', []])
    on_change = (pl_id : number) => (ev : any) => {
        const find_player = () => {
            const pl_name : string = ev.target.value
            for (const pl of rps_players) {
                if (pl[0] === pl_name) {
                    return pl;
                }
            }
            throw Error("Cannot find the player.")
        }
        const pl_type = this.pl_type.map((x,i) => i !== pl_id ? x : find_player());
        this.dispatch_rps_event(["PlayerChanged", pl_type])
    }

    render() {
        return html`
            <div>
                <sl-button @click=${this.start_game}>Start Game</sl-button>
            </div>
            ${gap(20)}
            <div>
                <sl-select name="pl1" id="pl1" .value=${this.pl_type[0][0]} @sl-change=${this.on_change(0)}>
                    <div slot="label">Player 0:</div>
                    <sl-option value="Computer">Computer</sl-option>
                    <sl-option value="Human">Human</sl-option>
                </sl-select>
            </div>
            ${gap(20)}
            <div>
                <sl-select name="pl2" id="pl2" .value=${this.pl_type[1][0]} @sl-change=${this.on_change(1)}>
                    <div slot="label">Player 1:</div>
                    <sl-option value="Computer">Computer</sl-option>
                    <sl-option value="Human">Human</sl-option>
                </sl-select>
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
            overflow: auto;
            font-family: var(--sl-font-mono);
        }

        div {
            color: gray;
        }
    `

    @property({type: Array}) message : Message = ["GameStarted",[]]

    protected updated(_changedProperties: PropertyValueMap<any> | Map<PropertyKey, unknown>): void {
        // Scroll the message window to the bottom on ever new message.
        this.scrollTo({top: this.scrollHeight});
    }

    print_message = (x : Message) : string[] => {
        const [tag,arg] = x
        switch (tag) {
            case 'ShowdownResult': {
                if (arg[0][0] === arg[1][0]) {
                    return [
                        `Both players show ${arg[0][0]}!`,
                        "It's a tie!"
                    ]
                } else {
                    return [
                        `Player 0 shows ${arg[0][0]} and player 1 shows ${arg[1][0]}!`,
                        ((arg[0][0] === "Rock" && arg[1][0] === "Paper") 
                        || (arg[0][0] === "Scissors" && arg[1][0] === "Rock") 
                        || (arg[0][0] === "Paper" && arg[1][0] === "Scissors"))
                        ? "Player 1 wins!"
                        : "Player 0 wins!"
                    ]
                }
            }
            case 'WaitingToStart': return ["Waiting to start the game..."]
            case 'GameStarted': return ["Rock-Paper-Scissors!"]
            default : return assert_tag_is_never(tag)
        }
    }

    
    render() {
        return html`
            ${map(this.print_message(this.message), x => html`
                <div>${x}</div>
            `)}
        `
    }
}


@customElement('rps-game')
class RPS_Game extends RPS_Element {
    @property({type: Array}) state : RPS_Game_State = ["GameNotStarted", []]

    on_action = (action : RPS_Action) => () => {
        this.dispatch_rps_event(["ActionSelected", action])
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
            align-items: center;
            justify-content: space-between;
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
                <sl-button @click=${this.on_action(["Rock",[]])}>Rock</sl-button>
                <sl-button @click=${this.on_action(["Paper",[]])}>Paper</sl-button>
                <sl-button @click=${this.on_action(["Scissors",[]])}>Scissors</sl-button>
            </div>
        `
        const f = (c : boolean) => c ? f_true : f_false;

        switch (tag){
            case "GameNotStarted": return html`
                <div>
                    Please start the game...
                </div>
            `
            case "WaitingForActionFromPlayerId": return html`
                ${f(arg === 0)}
                <div>
                    Game in progress...
                </div>
                ${f(arg === 1)}
                `
            case "GameOver": return html`
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
        return html`${this.render_state()}`
    }
}