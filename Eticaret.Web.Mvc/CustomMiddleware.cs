using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Eticaret.Web.Mvc;
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["token"];
        if (!string.IsNullOrEmpty(token))
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var userClaims = new List<Claim>
                {
                      new Claim(ClaimTypes.NameIdentifier, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value ?? ""),
                    new Claim(ClaimTypes.Name, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value ?? ""),
                    new Claim(ClaimTypes.Email, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value ?? ""),
                    new Claim(ClaimTypes.GivenName, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value ?? ""),
                     new Claim(ClaimTypes.Role, jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "")
                };

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                context.User = new ClaimsPrincipal(claimsIdentity);
            }
            catch (Exception)
            {
                // Token doğrulama hatası, kullanıcıyı yetkisiz yapabiliriz veya hata verebiliriz
                //context.Response.Cookies.Delete("token");//!
            }
        }
        await _next(context);
    }
}

