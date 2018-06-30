using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Data;
using DTO.Models.Request;

namespace BIZ.DI.Middleware
{
    public class MiddlewareRepository : IMiddleware
    {
        ApplicationDbContext ctx;
        public MiddlewareRepository(ApplicationDbContext applicationDbContext)
        {
            ctx = applicationDbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["Key"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                ctx.Add(new Request()
                {
                    DT = DateTime.Now,
                    MiddlewareActivation = "IMiddlewareMiddleware",
                    Value = keyValue
                });

                await ctx.SaveChangesAsync();
            }

            await next(context);
        }
    }
}
