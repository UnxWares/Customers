<script lang="ts">
    import { page } from '@inertiajs/inertia-svelte'
    import type { AppProps } from "@/types";
    
    const { countries, currencies, languages, user } = $page.props as AppProps;
    
    let selectedCountry = $state('');
    let selectedCurrency = $state('');
    let selectedLanguage = $state('');
</script>

<h1>Hello from svelte</h1>

{#if user}
    <p>Bienvenue, {user.Name}</p>
{:else}
    <p>Utilisateur non connecté</p>
{/if}


<h2>🌍 Sélection du pays</h2>
<select bind:value={selectedCountry}>
    <option value="" disabled>Choisissez un pays</option>
    {#each countries as country}
        <option value={country.code}>
            {country.emoji} {country.name} ({country.code})
        </option>
    {/each}
</select>

<h2>💰 Sélection de la devise</h2>
<select bind:value={selectedCurrency}>
    <option value="" disabled>Choisissez une devise</option>
    {#each currencies as currency}
        <option value={currency.code}>
            {currency.symbol} - {currency.code} ({currency.country})
        </option>
    {/each}
</select>

<h2>🗣️ Sélection de la langue</h2>
<select bind:value={selectedLanguage}>
    <option value="" disabled>Choisissez une langue</option>
    {#each languages as lang}
        <option value={lang.code}>
            {lang.name} ({lang.code})
        </option>
    {/each}
</select>

<hr />
<p>🌐 Vous avez choisi :</p>
<ul>
    <li>Pays : {selectedCountry}</li>
    <li>Devise : {selectedCurrency}</li>
    <li>Langue : {selectedLanguage}</li>
</ul>