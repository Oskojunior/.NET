using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class CheckBrowserMiddleware
    {
        private readonly RequestDelegate next;

        public CheckBrowserMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector detector)
        {
            var browser = detector.Browser;

            List<string> browsers = new List<string>
            {
                BrowserNames.Edge,
                BrowserNames.EdgeChromium,
                BrowserNames.InternetExplorer
            };

            if (browsers.Contains(browser.Name))
            {
                await httpContext.Response.WriteAsync("Przeglądarka nie jest obsługiwana");
            }
            else
            {
                await this.next.Invoke(httpContext);
            }
        }
    }

   public static class CheckBrowserMiddlewareExtentions
    {
        public static IApplicationBuilder UseCheckBrowserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckBrowserMiddleware>();
        }
    }
}
