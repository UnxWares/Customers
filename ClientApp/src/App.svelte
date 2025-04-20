<script lang="ts">
    import {InertiaApp} from "@inertiajs/inertia-svelte";
    import {Inertia} from "@inertiajs/inertia";
    import "@/Lib/I18n";
    import {_, isLoading} from "svelte-i18n";
    import Loader from "@/Lib/Components/Loader.svelte";

    let {initialPage, resolveComponent} = $props() as any;
</script>

{#if $isLoading}
    <div class="loader-container">
        <Loader />
    </div>
{:else}
    <InertiaApp
            {initialPage}
            {resolveComponent}
    />
{/if}

<style lang="scss">
    .loader-container {
      width: 100%;
      height: 100vh;
      overflow: hidden;
      display: flex;
      justify-content: center;
      align-items: center;
    }
</style>