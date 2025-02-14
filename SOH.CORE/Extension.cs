using Microsoft.Extensions.DependencyInjection;
using SOH.CORE.Interfaces;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace SOH.CORE
{
    public static class Extension
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
