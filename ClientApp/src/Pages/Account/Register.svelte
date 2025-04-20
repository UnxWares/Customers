<script lang="ts">
    import { _ } from "svelte-i18n";
    import { page } from '@inertiajs/inertia-svelte'
    import logo from "@assets/images/logo.png";
    import PasswordInput from "@/Lib/Components/PasswordInput.svelte";
    import type { AppProps } from "@/types";
    import PhoneNumberInput from "@/Lib/Components/PhoneNumberInput.svelte";

    const { countries, currencies } = $page.props as AppProps;

    let selectedType: "business" | "individual" | "" = $state('');
    let selectedCountry = $state('');
    let selectedCurrency = $state('');
    let password = "";
    let confirmPassword = "";
</script>

<div class="container">
    <div class="form">
        <img class="logo" src={logo} alt={$_('general.logo')} width="200">

        <h1 class="title">{$_('account.creation')}</h1>

        <h2 class="sub-title">{$_('account.selectType')}</h2>
        <div class="type-selector">
            <button class="type-item {selectedType === 'individual' ? 'active' : ''}"
                    onclick="{() => {selectedType = 'individual'}}">
                {$_('account.type.individual')}
            </button>
            <button class="type-item {selectedType === 'business' ? 'active' : ''}"
                    onclick="{() => {selectedType = 'business'}}">
                {$_('account.type.business')}
            </button>
        </div>

        {#if selectedType !== ""}
            <form class="form-info">
                <h2 class="sub-title">{$_('account.information')}</h2>
                <div class="form-group">
                    {#if selectedType === 'individual'}
                        <div class="input-container">
                            <label for="firstName">{$_('account.firstName')}*</label>
                            <input id="firstName" type="text">
                        </div>
                        <div class="input-container">
                            <label for="lastName">{$_('account.lastName')}*</label>
                            <input id="lastName" type="text">
                        </div>
                        <PhoneNumberInput />
                    {:else}
                        <div class="input-container">
                            <label for="businessName">{$_('account.businessName')}*</label>
                            <input id="businessName" type="text">
                        </div>
                        <div class="input-container">
                            <label for="businessId">{$_('account.businessId')}*</label>
                            <input id="businessId" type="text">
                        </div>
                        <div class="input-container">
                            <label for="contactAddress">{$_('account.contactEmail')}*</label>
                            <input id="contactAddress" type="text">
                        </div>
                    {/if}
                </div>

                <h2 class="sub-title">{$_('billing.information')}</h2>
                <div class="form-group">
                    <div class="input-container">
                        <label for="billingAddress">{$_('billing.address')}*</label>
                        <input id="billingAddress" type="text">
                    </div>
                    <div class="input-container">
                        <label for="billingCity">{$_('billing.city')}*</label>
                        <input id="billingCity" type="text">
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-container">
                        <label for="billingState">{$_('billing.state')}*</label>
                        <input id="billingState" type="text">
                    </div>
                    <div class="input-container">
                        <label for="billingPostalCode">{$_('billing.postalCode')}*</label>
                        <input id="billingPostalCode" type="text">
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-container">
                        <label for="billingCountry">{$_('billing.country')}*</label>
                        <select id="billingCountry" bind:value={selectedCountry}>
                            <option value="" disabled>{$_('general.selectCountry')}</option>
                            {#each countries as country}
                                <option value={country.code}>
                                    {country.emoji} {country.name} ({country.code})
                                </option>
                            {/each}
                        </select>
                    </div>
                    <div class="input-container">
                        <label for="preferredCurrency">{$_('billing.preferredCurrency')}*</label>
                        <select id="preferredCurrency" bind:value={selectedCurrency}>
                            <option value="" disabled>{$_('general.selectCurrency')}</option>
                            {#each currencies as currency}
                                <option value={currency.code}>
                                    {currency.symbol} - {currency.code} ({currency.country})
                                </option>
                            {/each}
                        </select>
                    </div>
                </div>

                {#if selectedType === 'business'}
                    <div class="form-group">
                        <div class="input-container">
                            <label for="vatId">{$_('billing.vatNumber')}</label>
                            <input id="vatId" type="text">
                        </div>
                    </div>
                {/if}

                <h2 class="sub-title">{$_('account.security')}</h2>
                <div class="form-group">
                    <div class="input-container">
                        <label for="email">{$_('account.email')}*</label>
                        <input id="email" type="email">
                    </div>
                </div>

                <PasswordInput bind:password bind:confirmPassword />

                <h2 class="sub-title">{$_('account.terms.title')}</h2>
                <div class="form-group">
                    <div class="input-container checkbox-container">
                        <input id="terms" type="checkbox">
                        <label for="terms">
                            {@html $_('account.terms.acceptanceText', {
                                values: {
                                    //@ts-ignore
                                    termsLink: `<a style="color: var(--primary-color);text-decoration: none;" target="_blank" href="https://unxwares.com/terms">${$_('account.terms.termsOfUse')}</a>`,
                                    privacyLink: `<a style="color: var(--primary-color);text-decoration: none;" target="_blank" href="https://unxwares.com/privacy">${$_('account.terms.privacyPolicy')}</a>`,
                                    companyName: 'UnxWares' 
                                }
                            })}*
                        </label>
                    </div>
                </div>

                <button type="submit" class="submit-btn">{$_('account.register')}</button>
            </form>
        {/if}
    </div>
</div>

<style lang="scss">
  .container {
    min-height: 100vh;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 15px;
  }

  .form {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background-color: #F7F7F7;
    border-radius: 10px;
    padding: 15px;
    width: 100%;
    max-width: 500px;

    .title {
      color: var(--accent-color);
      font-size: 1.5rem;
      margin: 5px 0;

      &::after {
        content: "";
        display: block;
        position: relative;
        width: 70%;
        height: 2px;
        left: calc(50% - 35%);
        background-color: var(--accent-color);
      }
    }

    .sub-title {
      font-size: 0.95rem;
      margin-top: 12px;
      margin-bottom: 6px;
      align-self: flex-start;
      width: 100%;
    }

    .type-selector {
      display: flex;
      flex-direction: row;
      justify-content: center;
      align-items: center;
      margin-top: 4px;
      width: 100%;

      .type-item {
        background-image: url('@assets/webp/nav-bg-fill-blue.webp');
        background-repeat: repeat-x;
        background-position: 0 -100%;
        transition: 1s ease;
        color: var(--accent-color);
        padding: 8px 15px;
        cursor: pointer;
        border: 1px solid var(--accent-color);
        flex: 1;
        text-align: center;
        font-size: 0.9rem;

        &.active {
          background-position: center;
          color: white;
        }

        &:nth-child(1) {
          border-radius: 10px 0px 0px 10px;
        }

        &:nth-child(2) {
          border-radius: 0px 10px 10px 0px;
        }

        &:hover {
          background-position: center;
          color: white;
        }
      }
    }

    .form-info {
      display: flex;
      flex-direction: column;
      width: 100%;
      animation: fade-in 1s ease;

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

      .checkbox-container {
        flex-direction: row;
        align-items: center;
        width: 100%;
        flex: 1;

        input {
          width: auto;
          margin-right: 5px;
          color: var(--primary-color);
          border-color: var(--primary-color);
        }

        label {
          margin-bottom: 0;
          font-size: 0.85rem;
        }
      }

      .submit-btn {
        background-image: url('@assets/webp/nav-bg-fill-blue.webp');
        background-repeat: repeat-x;
        background-position: 0 -100%;
        transition: 1s ease;
        color: var(--accent-color);
        padding: 8px 15px;
        cursor: pointer;
        border: 1px solid var(--accent-color);
        border-radius: 8px;
        flex: 1;
        margin-left: 50% - 15%;
        text-align: center;
        font-size: 0.9rem;
        width: 30%;

        &:hover {
          background-position: center;
          color: white;
        }
      }
    }
  }

  /* Animations */
  @keyframes fade-in {
    from {
      opacity: 0;
    }
    to {
      opacity: 1;
    }
  }

  /* Responsive adjustments */
  @media (min-width: 768px) {
    .form-group {
      flex-direction: row !important;
      flex-wrap: wrap;
      justify-content: space-between;

      .input-container {
        width: calc(50% - 5px) !important;
      }
    }
  }
</style>