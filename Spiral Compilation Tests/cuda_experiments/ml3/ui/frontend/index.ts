import "./rps"; // Needed to import the rps web components.
import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';

@customElement('games-ui')
class Games_UI extends LitElement {
    render() {
        return html`
            <rps-ui></rps-ui>
        `
    }
}