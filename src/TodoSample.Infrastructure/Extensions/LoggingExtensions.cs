using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TodoSample.Infrastructure.Extensions
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddLoggingToPipeline(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var loggerFactory = services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
            loggerFactory.AddSerilog(Log.Logger);

            return services;
        }
    }
}
