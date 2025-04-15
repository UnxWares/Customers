import { createInertiaApp } from '@inertiajs/inertia-svelte'
import { mount } from 'svelte'
import '@assets/styles/app.scss'
import "./bootstrap";
import Layout from "./Lib/Layout.svelte";

createInertiaApp({
    resolve: name => {
        const pages = import.meta.glob('./Pages/**/*.svelte', { eager: true });
        let page = pages[`./Pages/${name}.svelte`];
        
        return { default: page.default, layout: page.layout || Layout }
    },
    setup({ el, App, props }) {
        mount(App, { target: el, props })
    },
})