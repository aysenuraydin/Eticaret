using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using IdentityModel;

namespace Eticaret.Web.Mvc;
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    //! hoca yaptı
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["token"];
        if (!string.IsNullOrEmpty(token))
        {
            context.Request.Headers.Append("Authorization", $"Bearer {token}");
            context.Items.Add("jwt", token); //!
        }
        await _next(context);
    }
}

