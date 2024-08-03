using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace server_api.Extensions
{

    public static class CorsPolicyServiceExtensions
    {
        public readonly static string AllowSpecificOrigins = "_allowSpecificOrigins";
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder =>
                    {
                        // builder.WithOrigins("http://localhost:4200", "https://localhost:4200", "http://192.168.0.7:8085"
                        // , "http://192.168.0.7:9083", "http://192.168.1.13:8082/ar", "http://192.168.1.13:8082/fr"
                        // , "http://192.168.1.13:8082", "http://192.168.1.13:8083")
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}