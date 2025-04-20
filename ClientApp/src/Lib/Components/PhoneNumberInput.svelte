<script lang="ts">
    import { _ } from "svelte-i18n";
    import {page} from '@inertiajs/inertia-svelte'
    import type {AppProps, PhonePrefix} from "@/types";
    const {phonePrefixes, locale} = $page.props as AppProps;

    let selectedPrefix: PhonePrefix = $state('');
    let phoneNumber = $state('');

    $effect(() => {
        phoneNumber = phoneNumber.replace(/[^0-9]/g, '');
    })
</script>

<div class="form-group">
    <div class="input-container">
        <label for="phoneNumber">{$_('phone.label')}</label>
        <div class="phone-input-wrapper">
            <select bind:value={selectedPrefix}>
                <option value="" disabled>{$_('phone.selectPrefix')}</option>
                {#each phonePrefixes as prefix}
                    <option value={prefix}>
                        {prefix.emoji} {prefix.code} +{prefix.dialCode}
                    </option>
                {/each}
            </select>
            <input id="phoneNumber"
                   type="tel"
                   bind:value={phoneNumber}
                   maxlength="20"
                   placeholder={$_('phone.placeholder')}>
        </div>
    </div>
</div>

<style lang="scss">
  .form-group {
    display: flex;
    flex-direction: column;
    width: 100%;
    margin-bottom: 5px;
  }

  .input-container {
    display: flex;
    flex-direction: column;
    margin-bottom: 8px;
    width: 100%;

    label {
      font-size: 0.75rem;
      margin-bottom: 2px;
      color: #555;
      font-weight: 500;
    }

    input, select {
      border: 1px solid var(--accent-color);
      border-radius: 5px;
      padding: 6px 8px;
      width: 100%;
      box-sizing: border-box;
      font-size: 0.9rem;

      &:focus {
        outline: none;
        border-color: var(--primary-color);
      }
    }
  }

  .phone-input-wrapper {
    position: relative;
    display: flex;
    align-items: center;

    input, select {
      width: 100%;
      height: 100%;

      &:nth-child(1) {
        border-radius: 5px 0px 0px 5px;
        width: 55%;
      }

      &:nth-child(2) {
        border-radius: 0px 5px 5px 0px;
      }
    }
  }
</style>