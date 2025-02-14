using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOH.CORE.Interfaces;
using SOH.PERSISTENCE.Data;
using SOH.PERSISTENCE.Mapper;
using SOH.PERSISTENCE.Repository;

namespace SOH.PERSISTENCE
{
    public static class Extension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.AddDbContext<AplicationDbContext>(opt => opt.UseSqlServer(configuration["sql:cn"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            return services;
        }
    }
}
