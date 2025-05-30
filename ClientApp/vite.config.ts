import {defineConfig} from 'vite'
import {svelte} from '@sveltejs/vite-plugin-svelte'
import laravel from "laravel-vite-plugin";
import path from "path";
import { mkdirSync } from "fs";

const outDir = "../wwwroot/build";

// https://vite.dev/config/
export default defineConfig({
    plugins: [
        // Using laravel-vite-plugin package because it offers Vite 
        // configuration options that are also useful for other
        // server frameworks such as ASP.NET Core.
        laravel({
            input: ["src/app.ts"],
            publicDirectory: outDir,
            // When your application is built using traditional server-side
            // rendering with Blade, Vite can improve your development workflow
            // by automatically refreshing the browser when you make changes
            // to view files in your application. To get started, you can
            // simply specify the refresh option as true.
            // When the refresh option is true, saving files in the following
            // directories will trigger the browser to perform a full page refresh
            // while you are running npm run dev:
            // - app/View/Components/**
            // - lang/**
            // - resources/lang/**
            // - resources/views/**
            // - routes/**
            // If these default paths do not suit your needs, you can specify
            // your own list of paths to watch:
            // refresh: ['resources/views/**'],
            // For more information check the Laravel docs on Vite.
            // What is currently not known to me is what is the root folder
            // that it takes into account if you specify your own list
            // of paths to watch.
            refresh: true,
        }),
        svelte()
    ],
    base: "/",
    assetsInclude: ['**/*.svg', '**/*.png', '**/*.jpg', '**/*.jpeg', '**/*.mp4', '**/*.webm'],
    resolve: {
        alias: {
            "@": path.resolve(__dirname, "src"),
            "@assets": path.resolve(__dirname, "src/assets"),
        },
    },
    build: {
        outDir,
        assetsDir: "assets",
        assetsInlineLimit: 4096,
        emptyOutDir: true,
    },
})
