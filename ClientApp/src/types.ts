export interface Country {
    code: string;
    name: string;
    emoji: string;
}

export interface Currency {
    code: string;
    symbol: string;
    country: string;
}

export interface Language {
    code: string;
    name: string;
}

interface PhonePrefix {
    code: string;
    name: string;
    dialCode: number;
    emoji: string;
}

export interface AppProps {
    locale: string;
    user: { Name: string } | null;
    countries: Country[];
    currencies: Currency[];
    languages: Language[];
    phonePrefixes: PhonePrefix[];
}
