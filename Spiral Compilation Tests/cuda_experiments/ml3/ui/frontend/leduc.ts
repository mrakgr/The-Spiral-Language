import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';
import { map } from 'lit/directives/map.js';
import { io } from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error(`Invalid tag. Got: ${tag}`)};

type Card = ["King",[]] | ["Queen",[]] | ["Jack",[]]
type Action = ["Raise",[]] | ["Call",[]] | ["Fold",[]]
type Players = ["Computer",[]] | ["Human",[]]
const players : Players[] = [["Computer",[]], ["Human",[]]]
type Table = {
    pot: [number, number]
    community_card: Card,
    pl_cards: [Card, Card]
}

type Game_Events =
    | ['StartGame', []]
    | ['PlayerChanged', Players[]]
    | ['ActionSelected', Action]

type Game_State =
    | ["GameNotStarted", []]
    | ["WaitingForActionFromPlayerId", [number, Table]]
    | ["GameOver", Table]
    
// type Message =
//     | ["ShowdownResult", {
//         community_card: Card | null,
//         pl_cards: [Card, Card]
//     }]
//     | ["WaitingToStart",[]]
//     | ["GameStarted",[]]

type UI_State = {
    pl_type : Players[];
    game_state : Game_State;
    // messages : Message;
}

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('leduc-ui')
class Leduc_UI extends LitElement {
    @property({type: Object}) state : UI_State = {
        pl_type: players,
        game_state: ["GameNotStarted", []],
        // messages: ["WaitingToStart",[]]
    };

    socket = io('/leduc-game')
    constructor(){
        super()
        this.socket.on('update', (state : UI_State) => {
            this.state = state;
        });
        this.addEventListener('leduc', (ev) => {
            ev.stopPropagation();
            this.socket.emit('update', (ev as CustomEvent<Game_Events>).detail);
        })
    }

    static styles = css`
        :host {
            display: flex;
            flex-direction: row;
            box-sizing: border-box;
            height: 100%;
        }
        
        leduc-menu {
            flex: 1;
        }
        
        .game_area {
            display: flex;
            flex-direction: column;
            flex: 5;
        }

        leduc-game {
            flex: 6;
        }
        
        leduc-history {
            flex: 1;
        }
    `

    render(){
        return html`
            <leduc-menu .pl_type=${this.state.pl_type}></leduc-menu>
            ${gap(10)}
            <div class="game_area">
                <leduc-game .state=${this.state.game_state}></leduc-game>
                ${gap(10)}
                <leduc-history></leduc-history>
            </div>
        `
    }
}

class GameElement extends LitElement {
    dispatch_game_event = (detail : Game_Events) => {
        this.dispatchEvent(new CustomEvent('game', {bubbles: true, composed: true, detail}))
    }
}

@customElement('leduc-menu')
class Leduc_Menu extends GameElement {
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

    @property({type: Array}) pl_type : Players[] = players;
    
    start_game = () => this.dispatch_game_event(['StartGame', []])
    on_change = (pl_id : number) => (ev : any) => {
        const find_player = () => {
            const pl_name : string = ev.target.value
            for (const pl of players) {
                if (pl[0] === pl_name) {
                    return pl;
                }
            }
            throw Error("Cannot find the player.")
        }
        const pl_type = this.pl_type.map((x,i) => i !== pl_id ? x : find_player());
        this.dispatch_game_event(["PlayerChanged", pl_type])
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

@customElement('leduc-history')
class Leduc_History extends GameElement {
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

    @property({type: Array}) message = ["TODO"]

    protected updated(_changedProperties: PropertyValueMap<any> | Map<PropertyKey, unknown>): void {
        // Scroll the message window to the bottom on ever new message.
        this.scrollTo({top: this.scrollHeight});
    }

    // print_message = (x : Message) : string[] => {
    //     const [tag,arg] = x
    //     switch (tag) {
    //         case 'ShowdownResult': {
    //             if (arg[0][0] === arg[1][0]) {
    //                 return [
    //                     `Both players show ${arg[0][0]}!`,
    //                     "It's a tie!"
    //                 ]
    //             } else {
    //                 return [
    //                     `Player 0 shows ${arg[0][0]} and player 1 shows ${arg[1][0]}!`,
    //                     ((arg[0][0] === "Rock" && arg[1][0] === "Paper") 
    //                     || (arg[0][0] === "Scissors" && arg[1][0] === "Rock") 
    //                     || (arg[0][0] === "Paper" && arg[1][0] === "Scissors"))
    //                     ? "Player 1 wins!"
    //                     : "Player 0 wins!"
    //                 ]
    //             }
    //         }
    //         case 'WaitingToStart': return ["Waiting to start the game..."]
    //         case 'GameStarted': return ["Rock-Paper-Scissors!"]
    //         default : return assert_tag_is_never(tag)
    //     }
    // }

    
    render() {
        return html`
            ${map((this.message), x => html`
                <div>${x}</div>
            `)}
        `
    }
}


@customElement('leduc-game')
class Leduc_Game extends GameElement {
    @property({type: Array}) state : Game_State = ["GameNotStarted", []]

    on_action = (action : Action) => () => {
        this.dispatch_game_event(["ActionSelected", action])
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
                <sl-button @click=${this.on_action(["Raise",[]])}>Raise</sl-button>
                <sl-button @click=${this.on_action(["Call",[]])}>Call</sl-button>
                <sl-button @click=${this.on_action(["Fold",[]])}>Fold</sl-button>
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

                `
            case "GameOver": return html`

            `
        }
    }

    render() {
        return html`${this.render_state()}`
    }
}