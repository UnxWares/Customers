import { register, init } from "svelte-i18n";

register("en", () => import("@/Locales/en.json"));
register("fr", () => import("@/Locales/fr.json"));

init({
    fallbackLocale: "en",
    initialLocale: "en"
})