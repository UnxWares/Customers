using System.Globalization;
using PhoneNumbers;

namespace Customers.Helpers;

public class CountryPhonePrefix
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int DialCode { get; set; }
    public string Emoji { get; set; }
}

public static class PhoneDataGenerator
{
    public static List<CountryPhonePrefix> GetPhonePrefixes()
    {
        var phoneUtil = PhoneNumberUtil.GetInstance();
        var regions = phoneUtil.GetSupportedRegions();
        var countries = new List<CountryPhonePrefix>();

        foreach (var code in regions)
        {
            try
            {
                var regionInfo = new RegionInfo(code);
                var name = regionInfo.EnglishName;
                var dialCode = phoneUtil.GetCountryCodeForRegion(code);
            
                countries.Add(new CountryPhonePrefix
                {
                    Code = code,
                    Name = name,
                    DialCode = dialCode,
                    Emoji = CountryHelper.GetFlagEmoji(code)
                });
            }
            catch (ArgumentException)
            {
                // Ignore
            }
        }
        
        return countries
            .DistinctBy(c => c.Code)
            .OrderBy(c => c.Name)
            .ToList();
    }
}