<script lang="ts">
    import { _ } from "svelte-i18n";

    interface Props {
        password?: string;
        confirmPassword?: string;
    }

    let {password = $bindable(""), confirmPassword = $bindable("")}: Props = $props();

    let passwordStrength = $state(0);
    let passwordFeedback = $state("");
    let passwordColor = $state("red");

    // Password validation state
    let meetsLength = $state(false);
    let meetsUppercase = $state(false);
    let meetsLowercase = $state(false);
    let meetsNumber = $state(false);
    let meetsSpecial = $state(false);

    function checkPasswordStrength(pass: string) {
        // Reset checks
        meetsLength = false;
        meetsUppercase = false;
        meetsLowercase = false;
        meetsNumber = false;
        meetsSpecial = false;

        // If password is empty, return 0 strength
        if (pass.length === 0) {
            passwordStrength = 0;
            passwordFeedback = "";
            passwordColor = "red";
            return;
        }

        // Check length (at least 12 characters)
        meetsLength = pass.length >= 12;

        // Check for uppercase letters
        meetsUppercase = /[A-Z]/.test(pass);

        // Check for lowercase letters
        meetsLowercase = /[a-z]/.test(pass);

        // Check for numbers
        meetsNumber = /[0-9]/.test(pass);

        // Check for at least 2 special characters
        const specialChars = (pass.match(/[^A-Za-z0-9]/g) || []).length;
        meetsSpecial = specialChars >= 2;

        // Calculate strength (0-4)
        passwordStrength = [meetsLength, meetsUppercase, meetsLowercase, meetsNumber, meetsSpecial].filter(Boolean).length;

        // Update feedback and color
        if (passwordStrength <= 1) {
            passwordFeedback = $_('password.strength.veryWeak');
            passwordColor = "red";
        } else if (passwordStrength === 2) {
            passwordFeedback = $_('password.strength.weak');
            passwordColor = "orangered";
        } else if (passwordStrength === 3) {
            passwordFeedback = $_('password.strength.medium');
            passwordColor = "orange";
        } else if (passwordStrength === 4) {
            passwordFeedback = $_('password.strength.strong');
            passwordColor = "yellowgreen";
        } else if (passwordStrength === 5) {
            passwordFeedback = $_('password.strength.veryStrong');
            passwordColor = "green";
        }
    }
</script>

<div class="form-group">
    <div class="input-container password-container">
        <label for="password">{$_('password.label')}*</label>
        <div class="password-input-wrapper">
            <input
                    id="password"
                    type="password"
                    bind:value={password}
                    oninput={() => checkPasswordStrength(password)}>

            <div class="password-requirements-tooltip">
                <span class="info-icon">i</span>
                <div class="tooltip-content">
                    <h4>{$_('password.requirements.title')}:</h4>
                    <ul>
                        <li class={meetsLength ? "met" : ""}>
                            <span class="check-icon">{meetsLength ? "✓" : "✗"}</span>
                            {$_('password.requirements.minLength')}
                        </li>
                        <li class={meetsUppercase ? "met" : ""}>
                            <span class="check-icon">{meetsUppercase ? "✓" : "✗"}</span>
                            {$_('password.requirements.uppercase')}
                        </li>
                        <li class={meetsLowercase ? "met" : ""}>
                            <span class="check-icon">{meetsLowercase ? "✓" : "✗"}</span>
                            {$_('password.requirements.lowercase')}
                        </li>
                        <li class={meetsNumber ? "met" : ""}>
                            <span class="check-icon">{meetsNumber ? "✓" : "✗"}</span>
                            {$_('password.requirements.number')}
                        </li>
                        <li class={meetsSpecial ? "met" : ""}>
                            <span class="check-icon">{meetsSpecial ? "✓" : "✗"}</span>
                            {$_('password.requirements.special')}
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="password-strength-meter">
            <div class="strength-bar">
                <div
                        class="strength-level"
                        style="width: {passwordStrength * 20}%; background-color: {passwordColor}">
                </div>
            </div>
            <div class="strength-text" style="color: {passwordColor}">
                {passwordFeedback}
            </div>
        </div>
    </div>

    <div class="input-container">
        <label for="confirmPassword">{$_('password.confirm')}*</label>
        <input
                id="confirmPassword"
                type="password"
                bind:value={confirmPassword}>

        {#if confirmPassword && password !== confirmPassword}
            <div class="password-mismatch">
                {$_('password.mismatch')}
            </div>
        {/if}
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

  .password-input-wrapper {
    position: relative;
    display: flex;
    align-items: center;

    input {
      width: 100%;

      &:focus {
        outline: none;
        border-color: var(--primary-color);
      }
    }

    .password-requirements-tooltip {
      position: relative;
      margin-left: 8px;
      display: inline-block;

      .info-icon {
        display: flex;
        align-items: center;
        justify-content: center;
        width: 18px;
        height: 18px;
        border-radius: 50%;
        background-color: var(--accent-color);
        color: white;
        font-size: 0.7rem;
        font-style: italic;
        font-weight: bold;
        cursor: pointer;
      }

      .tooltip-content {
        display: none;
        position: absolute;
        bottom: 25px;
        right: 25px;
        width: 200px;
        background-color: white;
        border: 1px solid #ddd;
        border-radius: 5px;
        padding: 8px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
        z-index: 10;

        h4 {
          margin: 0 0 5px 0;
          font-size: 0.8rem;
        }

        ul {
          list-style: none;
          padding: 0;
          margin: 0;

          li {
            font-size: 0.7rem;
            color: #666;
            margin-bottom: 3px;
            display: flex;
            align-items: center;

            &.met {
              color: green;
            }

            .check-icon {
              margin-right: 5px;
              font-weight: bold;
            }
          }
        }
      }

      &:hover .tooltip-content {
        display: block;
      }
    }
  }

  .password-strength-meter {
    margin-top: 3px;
    width: 90%;

    .strength-bar {
      height: 6px;
      background-color: #e0e0e0;
      border-radius: 2px;
      overflow: hidden;

      .strength-level {
        height: 100%;
        transition: width 0.3s ease, background-color 0.3s ease;
      }
    }

    .strength-text {
      font-size: 0.65rem;
      margin-top: 2px;
      text-align: left;
      font-weight: 500;
    }
  }

  .password-mismatch {
    color: red;
    font-size: 0.65rem;
    margin-top: 2px;
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