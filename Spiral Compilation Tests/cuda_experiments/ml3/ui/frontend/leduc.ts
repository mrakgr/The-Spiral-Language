import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';
import { map } from 'lit/directives/map.js';
import { io } from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error(`Invalid tag. Got: ${tag}`)};

type Option<t> = ["Some",t] | ["None",[]]
type Card = ["King",[]] | ["Queen",[]] | ["Jack",[]]
const card : Card[] = [["King",[]], ["Queen",[]], ["Jack",[]]]
type Action = ["Raise",[]] | ["Call",[]] | ["Fold",[]]
type Players = ["Computer",[]] | ["Human",[]]
const players : Players[] = [["Computer",[]], ["Human",[]]]
type Table = {
    pot: [number, number]
    community_card: Option<Card>,
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
        this.addEventListener('game', (ev) => {
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
                <leduc-game></leduc-game>
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

@customElement('leduc-pot')
class Leduc_Pot extends LitElement {
    @property({type: Number}) pot = 0;

    static styles = css`
        :host {
            display: block;
            border: 2px dashed black;
            width: fit-content;
            font-size: 2em;
            padding: 5px;
        }
    ` 

    render() {
        return html`${this.pot}`
    }
}

@customElement('leduc-card')
class Leduc_Card extends LitElement {
    @property({type: Array}) card : Option<Card> = ["Some", card[0]];
    @property({type: Boolean}) card_visible = true;

    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            border: 4px solid black;
            height: fit-content;
            width: fit-content;
            padding: 10px;
            background-color: burlywood;
            user-select: none;
            text-align: center;
            font-family: var(--sl-font-mono);
            font-size: var(--sl-font-size-2x-large);
        }

        div {
            white-space: pre;
        }
    `

    render(){
        return html`<div>${this.card_visible && this.card[0] === "Some" ? this.card[1][0][0] : " "}</div>`
    }
}

@customElement('leduc-game')
class Leduc_Game extends GameElement {
    // @property({type: Array}) state : Game_State = ["GameNotStarted", []]
    @property({type: Array}) state : Game_State = ["WaitingForActionFromPlayerId", [1, {
        community_card: ["None",[]],
        pl_cards: [card[0], card[1]],
        pot: [4,3]
    }]]

    static styles = css`
        :host {
            display: flex;
            flex-direction: column;
            box-sizing: border-box;
            background-color: white;
            padding: 20px;
            border: 3px solid;
            border-radius: 5px;
            align-items: center;
            justify-content: space-between
        }
        
        .row {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            align-items: center;
            width: 100%;
        }

        .flex-1 {
            flex: 1;
        }

        .flex-pot {
            display: flex;
            flex: 1;
            justify-content: flex-end;
        }

        .flex-card {
            display: flex;
            flex-basis: 200px;
            justify-content: center;
        }
        
        .flex-actions {
            display: flex;
            flex: 1;
            flex-direction: row;
            justify-content: flex-start;
        }

        button {
            font-size: inherit;
        }
        `

    on_action = (action : Action) => () => {
        this.dispatch_game_event(["ActionSelected", action])
    }

    render_state(){
        const [tag,arg] = this.state
        const some = (x : Card) : Option<Card> => ["Some", x]
        const f = (is_current : boolean, card_visible : boolean, id : number, table : Table) => html`
            <div class="row">
                <div class="flex-pot">
                    <leduc-pot .pot=${table.pot[id]}></leduc-pot>
                </div>
                <div class="flex-card">
                    <leduc-card .card=${some(table.pl_cards[id])} ?card_visible=${card_visible}></leduc-card>
                </div>
                ${
                    is_current
                    ? html`
                        <div class="flex-actions">
                            <sl-button @click=${this.on_action(["Raise",[]])}>Raise</sl-button>
                            <sl-button @click=${this.on_action(["Call",[]])}>Call</sl-button>
                            <sl-button @click=${this.on_action(["Fold",[]])}>Fold</sl-button>
                        </div>
                        `
                    : html`
                        <div class="flex-1"></div>
                    `
                }
            </div>
        `
        
        switch (tag){
            case "GameNotStarted": return html`
                <div>
                    Please start the game...
                </div>
            `
            case "WaitingForActionFromPlayerId":{ 
                const [id, table] = arg;
                const f_ = (c : number) => f(id === c, id === c, c, table)
                return html`
                    ${f_(0)}
                    <div>
                        <leduc-card .card=${table.community_card}></leduc-card>
                    </div>
                    ${f_(1)}
                    `
                }
            case "GameOver": {
                const table = arg;
                return html`
                    ${f(false, true, 0, table)}
                    <div>
                        <leduc-card .card=${table.community_card}></leduc-card>
                    </div>
                    ${f(false, true, 1, table)}
                `
            }
        }
    }

    render() {
        return html`${this.render_state()}`
    }
}