<script lang="ts">
    import {InertiaApp} from "@inertiajs/inertia-svelte";
    import {Inertia} from "@inertiajs/inertia";
    import "@/Lib/I18n";
    import {_, isLoading} from "svelte-i18n";

    let {initialPage, resolveComponent} = $props() as any;
</script>

{#if $isLoading}
    <p>Loading</p>
{:else}
    <InertiaApp
            {initialPage}
            {resolveComponent}
    />
{/if}