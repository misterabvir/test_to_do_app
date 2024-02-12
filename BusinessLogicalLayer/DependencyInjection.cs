using BusinessLogicalLayer.Services;
using BusinessLogicalLayer.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicalLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicalLayer(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ITaskService, ProblemService>();
            return services;
        }
    }
}
