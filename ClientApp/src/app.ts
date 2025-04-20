import { createInertiaApp } from '@inertiajs/inertia-svelte'
import { mount } from 'svelte'
import '@assets/styles/app.scss'
import "./bootstrap";
import "./Lib/I18n";
import Layout from "./Lib/Layout.svelte";
import { polyfillCountryFlagEmojis } from "country-flag-emoji-polyfill";
import App from "./App.svelte";

/* Fix chromium emojis issue on Windows */
polyfillCountryFlagEmojis();

createInertiaApp({
    resolve: name => {
        const pages = import.meta.glob('./Pages/**/*.svelte', { eager: true });
        let page = pages[`./Pages/${name}.svelte`];
        
        return { default: page.default, layout: page.layout || Layout }
    },
    setup({ el, App: InertiaApp, props }) {
        mount(App, {
            target: el,
            props: {
                initialPage: props.initialPage,
                resolveComponent: props.resolveComponent
            }
        })
    },
})