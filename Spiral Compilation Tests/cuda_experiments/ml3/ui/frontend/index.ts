import '@shoelace-style/shoelace/dist/themes/light.css';
import '@shoelace-style/shoelace/dist/components/button/button.js';
import '@shoelace-style/shoelace/dist/components/tab/tab.js';
import '@shoelace-style/shoelace/dist/components/tab-group/tab-group.js';
import '@shoelace-style/shoelace/dist/components/tab-panel/tab-panel.js';
import '@shoelace-style/shoelace/dist/components/icon/icon.js';
import '@shoelace-style/shoelace/dist/components/select/select.js';
import '@shoelace-style/shoelace/dist/components/option/option.js';
import '@shoelace-style/shoelace/dist/components/range/range.js';
import { setBasePath } from '@shoelace-style/shoelace/dist/utilities/base-path.js';

setBasePath('/bundles/shoelace/');

import "./rps"; // Needed to import the rps web components.
import "./leduc";
import "./hu_nl_holdem";
import { LitElement, PropertyValueMap, css, html } from 'lit';
import { customElement, property } from 'lit/decorators.js';

@customElement('games-ui')
class Games_UI extends LitElement {
    static styles = css`
        :host {
            display: block;
            height: 100vh;
            box-sizing: border-box;
        }

        sl-tab-group,
        sl-tab-group::part(base),
        sl-tab-group::part(body),
        sl-tab-panel,
        sl-tab-panel::part(base),
        sl-tab-panel::part(body) {
            height: 100%;
        }

        /* sl-tab-panel::part(base) {
            padding: 10px;
        }

        sl-tab::part(base)
        {
            padding: 15px;
        } */
    `

    render() {
        return html`
            <sl-tab-group>
                <sl-tab slot="nav" panel="rps">RPS</sl-tab>
                <sl-tab slot="nav" panel="leduc">Leduc</sl-tab>
                <sl-tab slot="nav" panel="nl-holdem" active>NL Holdem</sl-tab>
                <sl-tab-panel name="rps">
                    <rps-ui></rps-ui>
                </sl-tab-panel>
                <sl-tab-panel name="leduc">
                    <leduc-ui></leduc-ui>
                </sl-tab-panel>
                <sl-tab-panel name="nl-holdem">
                    <nl-holdem-ui></nl-holdem-ui>
                </sl-tab-panel>
            </sl-tab-group>
        `
    }
}