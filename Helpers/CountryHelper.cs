namespace Customers.Helpers;

public static class CountryHelper
{
    public static string GetFlagEmoji(string countryCode) =>
        string.Concat(countryCode.ToUpper().Select(c => char.ConvertFromUtf32(c + 127397)));
}