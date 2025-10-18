using common.MassTransit;
using common.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


namespace common.OpenTelemetry
{
    public static class Extensions
    {
        public static IServiceCollection AddTracing(
            this IServiceCollection services,
            IConfiguration config)
        {
            var serviceSettings = config.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
            var jaegerSettings = config.GetSection(nameof(JaegerSettings)).Get<JaegerSettings>();

            services.AddConsumeObserver<ConsumeObserver>();
            services.AddOpenTelemetry().WithTracing(builder =>
            {
                builder.AddSource(serviceSettings.ServiceName)
                       .AddSource("MassTransit")
                       .SetResourceBuilder(
                           ResourceBuilder.CreateDefault()
                                .AddService(serviceName: serviceSettings.ServiceName))
                        .AddHttpClientInstrumentation()
                        .AddAspNetCoreInstrumentation()
                        .AddJaegerExporter(options =>
                        {
                            var jaegerSettings = config.GetSection(nameof(JaegerSettings))
                                                              .Get<JaegerSettings>();
                            options.AgentHost = jaegerSettings.Host;
                            options.AgentPort = jaegerSettings.Port;
                        });
            });
         

            return services;
        }

        public static IServiceCollection AddMetrics(
            this IServiceCollection services,
            IConfiguration config)
        {
                var settings = config.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

                services.AddOpenTelemetry()
                    .WithMetrics(builder =>
                    {
                        builder
                            .AddMeter(settings.ServiceName)
                            .AddMeter("MassTransit")
                            .AddHttpClientInstrumentation()
                            .AddAspNetCoreInstrumentation()
                            .AddPrometheusExporter();
                    });

            return services;
        }
    }
}