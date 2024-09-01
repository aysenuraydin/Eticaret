using Eticaret.Web.Mvc.Constants;

namespace Eticaret.Web.Mvc.Middlewares;
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies[JWTSettings.TOKEN_NAME];
        if (!string.IsNullOrEmpty(token))
        {
            context.Request.Headers.Append("Authorization", $"Bearer {token}");
            context.Items.Add(JWTSettings.JWT, token);
        }
        await _next(context);
    }
}

