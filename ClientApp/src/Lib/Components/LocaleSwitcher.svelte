<script lang="ts">
    import { _, locale } from "svelte-i18n";
    
    let { currentLocale } = $props();

    interface SelectorEvent {
        preventDefault: () => void;
        target: {
            value: string;
        };
    }
    
    function changeLocale(event) {
        event.preventDefault();
        $locale = event.target.value;
        
        window.location.reload();
    }
</script>

<div>
    <select value={currentLocale} onchange={(e) => changeLocale(e)}>
        <option value="en">{$_('general.english')}</option>
        <option value="fr">{$_('general.french')}</option>
    </select>
</div>