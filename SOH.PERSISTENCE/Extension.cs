using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;
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
            services.AddDataProtection();

            services.AddIdentity<SR_Users, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            return services;
        }
    }
}
