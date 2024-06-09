namespace Eticaret.Api;
public class UnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Yetkisiz erişim hatası var mı kontrol edin
        if (context.Response.StatusCode == 401)
        {
            // Oturum açma işlemini başlatın veya yeniden yönlendirin
            // Örneğin, bir cookie veya JWT oluşturarak oturum açabilir veya bir giriş sayfasına yönlendirebilirsiniz
            context.Response.Redirect("/Auth/Login");
            return;
        }

        // Sonraki middleware'a devam edin
        await _next(context);
    }
}