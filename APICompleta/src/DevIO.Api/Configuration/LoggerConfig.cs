using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(options =>
            {
                options.ApiKey = "0166569c97f74094b777267e88da2c9b";
                options.LogId = new Guid("efe2f32b-ca8a-4558-8161-45997939f52e");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(options =>
            //    {
            //        options.ApiKey = "0166569c97f74094b777267e88da2c9b";
            //        options.LogId = new Guid("efe2f32b-ca8a-4558-8161-45997939f52e");
            //    });

            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
