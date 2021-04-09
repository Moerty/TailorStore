using TailorStore.Application.Common.Interfaces;
using TailorStore.Infrastructure.Persistence;
using TailorStore.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TailorStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TailorStoreDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            //services
            //    .AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddScoped<IImageService, ImageService>();
            //services.AddTransient<IIdentityService, IdentityService>();
            //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            return services;
        }
    }
}