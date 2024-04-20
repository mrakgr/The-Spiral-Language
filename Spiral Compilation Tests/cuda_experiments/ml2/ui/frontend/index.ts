import {LitElement, html} from 'lit';
import {customElement, property} from 'lit/decorators.js';

@customElement('spiral-ui')
class SpiralUI extends LitElement {
    render(){
        return html`
            <h1>Hello World</h1>
        `
    }
}

// customElements.define('spiral-ui',SpiralUI)
