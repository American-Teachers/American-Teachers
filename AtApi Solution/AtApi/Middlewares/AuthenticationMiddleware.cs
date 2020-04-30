using AtApi.Service.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;

        public AuthenticationMiddleware(RequestDelegate next, IAuthService authService)
        {
            _next = next;
            _authService = authService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                var user = _authService.ValidateAsync(context.User);
            }
            finally
            {
                await _next(context);
            }
        }
    }
}
