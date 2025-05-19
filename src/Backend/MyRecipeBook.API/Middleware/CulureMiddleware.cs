using System.Globalization;
using System.Linq;

namespace MyRecipeBook.API.Middleware
{
    public class CulureMiddleware(RequestDelegate _next)

    {
      

        public async Task Invoke(HttpContext context)
        {
            var allCulture = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
            
            var cultureInfo = new CultureInfo("en");
            
            if (allCulture.Any(cult => cult.Name.Equals(requestCulture) && string.IsNullOrWhiteSpace(requestCulture) == false))
            {
                cultureInfo = new CultureInfo(requestCulture);
            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
