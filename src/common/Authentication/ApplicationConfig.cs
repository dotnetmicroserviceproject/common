using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace common.Authentication
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationConfig(this IServiceCollection services, IConfiguration configurations)
        {

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            return services;
        }

    }
}
