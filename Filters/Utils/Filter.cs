using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Utils
{
    public class Filter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result;
            if (result is PageResult)
            {
                var pageModel = ((PageResult)result);
                string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
                pageModel.ViewData["filterMessage"] = "IP: " + ip;
            }
            await next.Invoke();
        }
    }
}
