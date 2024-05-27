import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';
import { map } from 'lit/directives/map.js';
import { io } from 'socket.io-client'

const assert_tag_is_never = (tag : never): never => { throw new Error(`Invalid tag. Got: ${tag}`)};
const min = (a : number,b : number) => a < b ? a : b;
const max = (a : number,b : number) => a >= b ? a : b;
const clamp = (x : number, _min : number, _max : number) => 
    _min <= _max && !isNaN(x) && !isNaN(_min) && !isNaN(_max) 
    ? min(max(_min,x), _max) 
    : (() => {throw Error(`Invalid args in clamp. Got: ${[x,_min,_max]}`)})();

enum Hand_Rank {
    High_Card,
    Pair,
    Two_Pair,
    Triple,
    Straight,
    Flush,
    Full_House,
    Quads,
    Straight_Flush
}

type Hand = [Hand_Rank, Card[]]

enum Card_Rank {
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

enum Card_Suit {
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

type Card = [Card_Rank, Card_Suit]
type CardInt = number
const suit_of = (x : CardInt): Card_Suit => x % 4 // Mask by 11
const rank_of = (x : CardInt): Card_Rank => x / 4 % 16 // Shift two to the right and then mask by 1111
const card_of = (x : CardInt): Card => [rank_of(x),suit_of(x)]

type Action = ["A_Raise",number] | ["A_Call",[]] | ["A_Fold",[]]
type Players = ["Computer",[]] | ["Human",[]]
const players : Players[] = [["Computer",[]], ["Human",[]]]

type Street =
    | ["Preflop", []]
    | ["Flop", CardInt[]]
    | ["Turn", CardInt[]]
    | ["River", CardInt[]]

type Game_Config = {
    min_raise : number
}

type Table = {
    pot: [number, number],
    stack: [number, number],
    street: Street,
    pl_card: [CardInt[], CardInt[]],
    round_turn: number,
    config : Game_Config,
}

type Game_Events =
    | ['StartGame', []]
    | ['PlayerChanged', Players[]]
    | ['ActionSelected', Action]

type Game_State =
    | ["GameNotStarted", []]
    | ["WaitingForActionFromPlayerId", Table]
    | ["GameOver", Table]
    
type Message =
    | ["PlayerGotCards", [number, Card[]]]
    | ["CommunityCardsAre", Card[]]
    | ["PlayerAction", [number, Action]]
    | ["Showdown", {winner_id : number; chips_won : number; hands_shown : [Hand, Hand]}]

type UI_State = {
    pl_type : Players[];
    ui_game_state : Game_State;
    messages : Message[];
}

// Creates a span with the specified gap in pixels.
const gap = (pixels : number) => html`<span style="flex-basis: ${pixels}px;"></span>`

@customElement('nl-holdem-ui')
class UI extends LitElement {
    @property({type: Object}) state : UI_State = {
        pl_type: players,
        ui_game_state: ["GameNotStarted", []],
        messages: []
    };

    socket = io('/hu_nl_holdem_game')

    constructor(){
        super()
        this.socket.on('update', (state : UI_State) => {
            this.state = state;
        });
        this.addEventListener('game', (ev) => {
            ev.stopPropagation();
            console.log(ev);
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
        
        nl-holdem-menu {
            flex: 1;
        }
        
        .game_area {
            display: flex;
            flex-direction: column;
            flex: 5;
        }

        nl-holdem-game {
            flex: 4;
        }
        
        nl-holdem-history {
            flex: 1;
        }
    `

    render(){ 
        return html`
            <nl-holdem-menu .pl_type=${this.state.pl_type}></nl-holdem-menu>
            ${gap(10)}
            <div class="game_area">
                <nl-holdem-game .state=${this.state.ui_game_state}></nl-holdem-game>
                ${gap(10)}
                <nl-holdem-history .messages=${this.state.messages}></nl-holdem-history>
            </div>
        `
    }
}

class GameElement extends LitElement {
    dispatch_game_event = (detail : Game_Events) => {
        this.dispatchEvent(new CustomEvent('game', {bubbles: true, composed: true, detail}))
    }
}

@customElement('nl-holdem-menu')
class Menu extends GameElement {
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

@customElement('nl-holdem-history')
class History extends GameElement {
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

        .red {
            color: red;
        }
    `

    @property({type: Array}) messages : Message[] = []

    protected updated(_changedProperties: PropertyValueMap<any> | Map<PropertyKey, unknown>): void {
        // Scroll the message window to the bottom on ever new message.
        this.scrollTo({top: this.scrollHeight});
    }

    print_card = ([rank,suit] : Card) => `${print_rank(rank)}${print_suit(suit)}`
    print_cards = (x : Card[]) => x.map(this.print_card).join(" ")
    print_action = ([tag,arg] : Action) => {
        switch (tag) {
            case 'A_Raise': return `raises ${arg} chips`
            case 'A_Call': return "calls"
            case 'A_Fold': return "folds"
        }
    }
    print_hand_score = (tag : Hand) => {

    }
    print_hand = ([tag,cards] : Hand) => this.print_cards(cards)

    print_message = (x : Message) : string[] => {
        const [tag,arg] = x
        switch (tag) {
            case 'PlayerGotCards': {
                return [`Player ${arg[0]} got ${this.print_cards(arg[1])}`]
            }
            case 'CommunityCardsAre': {
                return [`Table: ${this.print_cards(arg)}`]
            }
            case 'PlayerAction': {
                return [`Player ${arg[0]} ${this.print_action(arg[1])}.`]
            }
            case 'Showdown': {
                const {winner_id, chips_won, hands_shown} = arg
                return [
                    `Player 0 shows a ${this.print_hand_score(hands_shown[0])} - ${this.print_hand(hands_shown[0])}.`,
                    `Player 1 shows a ${this.print_hand_score(hands_shown[1])} - ${this.print_hand(hands_shown[1])}'.`,
                    winner_id === -1
                    ? "The game is a tie."
                    : `Player ${winner_id} wins ${chips_won} chips!`,
                    "The game is over."
                ]
            }
            default : return assert_tag_is_never(tag)
        }
    }
    
    render() {
        return html`
            ${map((this.messages).flatMap(this.print_message), x => html`
                <div>${x}</div>
            `)}
        `
    }
}

@customElement('nl-holdem-pot')
class UI_Pot extends LitElement {
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

const color_of_suit = (tag : Card_Suit) => {
    switch (tag) {
        case Card_Suit.Spades: return "black"
        case Card_Suit.Hearts: return "red"
        case Card_Suit.Diamonds: return "blue"
        case Card_Suit.Clubs: return "green"
    }
}

const print_suit = (tag : Card_Suit) => html`<span style="color: ${color_of_suit};">${Card_Suit[tag]}</span>`
const print_rank = (tag : Card_Rank) => {
    switch (tag) {
        case Card_Rank.Ace: return "A"
        case Card_Rank.King: return "K"
        case Card_Rank.Queen: return "Q"
        case Card_Rank.Jack: return "J"
        case Card_Rank.Ten: return "T"
        case Card_Rank.Nine: return "9"
        case Card_Rank.Eight: return "8"
        case Card_Rank.Seven: return "7"
        case Card_Rank.Six: return "6"
        case Card_Rank.Five: return "5"
        case Card_Rank.Four: return "4"
        case Card_Rank.Three: return "3"
        case Card_Rank.Two: return "2"
    }
}

@customElement('poker-card')
class Poker_Card extends LitElement {
    @property({type: Number}) card : CardInt = 34
    @property({type: Boolean}) is_visible = true;

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

    print_card = (x : CardInt) => {
        const [rank,suit] = card_of(x);
        html`<span style="color: ${color_of_suit(suit)}">${print_rank(rank)}</span>`
    }
    render() {
        return html`${this.is_visible ? this.print_card(this.card) : " "}`
    }

}

@customElement('poker-cards')
class Poker_Cards extends LitElement {
    static styles = css`
        :host {
            display: flex;
            flex-direction: row;
        }

        div {
            white-space: pre;
        }
`
    @property({type: Array}) cards : CardInt[] = [];
    @property({type: Boolean}) is_visible = true;

    print_card = ([rank,suit] : Card) => `${print_rank(rank)}${print_suit(suit)}`
    print_cards = (x : Card[]) => x.map(this.print_card).join(" ")

    render(){
        return this.cards.map(card => html`<poker-card .card=${card} ?is_visible=${this.is_visible}></poker-card>`)
    }
}

@customElement('nl-holdem-game')
class Game extends GameElement {
    @property({type: Array}) state : Game_State = ["WaitingForActionFromPlayerId", {
        pl_card: [[1,2],[3,4]],
        stack: [96,97],
        pot: [4,3],
        round_turn: 0,
        street: ["Flop",[5,6,7]],
        config: {
            min_raise: 2
        }
    }]

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
            display: flex;
            flex: 1;
            justify-content: center;
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

        sl-range {
            width: 100%;
        }
        `

    @property({type: Number}) raise_amount : number | undefined;

    on_action = (action : Action) => () => {
        this.dispatch_game_event(["ActionSelected", action])
    }

    render_state(){
        const [tag,arg] = this.state
        const f = (is_current : boolean, card_visible : boolean, id : number, table : Table) => {
            const is_raise_disabled = table.stack.every(x => x === 0)
            const max_raise = table.stack.reduce(min,Infinity)
            const min_raise = table.stack.reduce(min,table.config.min_raise)
            const pot_btn = (raise_amount : number) => {
                raise_amount = clamp(Math.floor(raise_amount),min_raise,max_raise)
                return html`
                    <sl-button size="small" ?disabled=${is_raise_disabled} @click=${this.on_action(["A_Raise",raise_amount])}>
                        Raise ${raise_amount}
                    </sl-button>`
                    }
            const raise_amount = this.raise_amount ?? min_raise
            const pot = table.pot.reduce((a,b) => a+b,0)
            return html`
                <div class="row">
                    <div class="flex-card">
                        <nl-holdem-pot .pot=${table.pot[id]}></nl-holdem-pot>
                        <poker-cards .cards=${table.pl_card[id]} ?card_visible=${card_visible}></poker-cards>
                    </div>
                    ${
                        is_current
                        ? html`
                            <div class="flex-actions">
                                <sl-button size="small" ?disabled=${table.pot[0] === table.pot[1]} @click=${this.on_action(["A_Fold",[]])}>Fold</sl-button>
                                <sl-button size="small" @click=${this.on_action(["A_Call",[]])}>Call</sl-button>
                                ${pot_btn(pot / 2)}
                                ${pot_btn(pot)}
                                ${pot_btn(raise_amount)}
                                <sl-range 
                                    ?disabled=${is_raise_disabled} 
                                    .value=${raise_amount} 
                                    .min=${min_raise} .max=${max_raise} .step=${table.config.min_raise}
                                    @sl-input=${(x : any) => { this.raise_amount = x.target.value}}
                                    ></sl-range>
                            </div>
                            `
                        : html`
                            <div class="flex-1"></div>
                        `
                    }
                </div>
            `}
        
        switch (tag){
            case "GameNotStarted": return html`
                <div>
                    Please start the game...
                </div>
            `
            case "WaitingForActionFromPlayerId":{ 
                const table = arg;
                const player_turn = table.round_turn % 2;
                const f_ = (c : number) => f(player_turn === c, player_turn === c, c, table)
                return html`
                    ${f_(0)}
                    <div class="row">
                        <poker-cards class="flex-1" .cards=${table.street[1]}></poker-cards>
                        <div class="flex-1"></div>
                    </div>
                    ${f_(1)}
                    `
                }
            case "GameOver": {
                const table = arg;
                return html`
                    ${f(false, true, 0, table)}
                    <div>
                        <poker-cards .cards=${table.street[1]}></poker-cards>
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