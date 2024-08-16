using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Serilog;
using Serilog.Events;
using Serilog.Parsing;

namespace Eticaret.Application
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logTemplate;
        private readonly LogEventLevel _logLevel;

        public RequestLoggingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;

            // appsettings.json dosyasından log şablonu ve log seviyesi alınıyor
            _logTemplate = configuration["Logging:RequestLogging:Template"] ?? "";
            _logLevel = Enum.TryParse(configuration["Logging:RequestLogging:LogLevel"], out LogEventLevel level)
                ? level
                : LogEventLevel.Information;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                await HandleLoggingAsync(context, stopwatch);
            }
        }

        private Task HandleLoggingAsync(HttpContext context, Stopwatch stopwatch)
        {
            var logEvent = new LogEvent(
                DateTimeOffset.Now,
                context.Response.StatusCode >= 400 ? LogEventLevel.Warning : _logLevel,
                null,
                new MessageTemplate(_logTemplate, new List<MessageTemplateToken>()),
                new List<LogEventProperty>
                {
                    new LogEventProperty("RequestMethod", new ScalarValue(context.Request.Method)),
                    new LogEventProperty("RequestPath", new ScalarValue(context.Request.Path)),
                    new LogEventProperty("StatusCode", new ScalarValue(context.Response.StatusCode)),
                    new LogEventProperty("Elapsed", new ScalarValue(stopwatch.Elapsed.TotalMilliseconds))
                });

            Log.Logger.Write(logEvent);
            return Task.CompletedTask;
        }
    }
}
