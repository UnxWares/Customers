namespace Customers.Helpers;

public record CurrencyDto(string Country, string Code, string Symbol);

public static class CurrencyHelper
{
    public static List<CurrencyDto> GetCommonCurrencies()
    {
        return new List<CurrencyDto>
        {
            new("Europe",                  "EUR", "€"),
            new("United States",           "USD", "$"),
            new("United Kingdom",          "GBP", "£"),
            new("Canada",                  "CAD", "$"),
        };
    }
}