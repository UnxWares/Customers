using System.Globalization;
using Customers.Helpers;
using InertiaCore;
using ISO3166;
using Microsoft.AspNetCore.Mvc.Filters;
using Nager.Country;

namespace Customers.Middlewares;

public class InertiaSharedDataMiddleware : IAsyncActionFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public InertiaSharedDataMiddleware(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var currentCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        var countries = Country.List.Select(c => new
        {
            Code = c.TwoLetterCode,
            Name = c.Name,
            Emoji = CountryHelper.GetFlagEmoji(c.TwoLetterCode),
        }).ToList();
        
        var languages = CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            .Select(c => new
            {
                Code = c.TwoLetterISOLanguageName,
                Name = c.EnglishName
            })
            .Distinct()
            .ToList();

        var user = _httpContextAccessor.HttpContext?.User;

        var currentUser = user?.Identity?.IsAuthenticated == true
            ? new
            {
                Name = user.Identity.Name,
                IsAuthenticated = true
            }
            : null;
        
        Inertia.Share(new Dictionary<string, object?>
        {
            ["locale"] = currentCulture,
            ["user"] = currentUser,
            ["countries"] = countries,
            ["currencies"] = CurrencyHelper.GetCommonCurrencies(),
            ["languages"] = languages,
            ["phonePrefixes"] = PhoneDataGenerator.GetPhonePrefixes()
        });
        
        await next();
    }
}