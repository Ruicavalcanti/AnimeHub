using AnimeHub.Domain.Abstractions;
using AnimeHub.Infrastructure.Context;
using AnimeHub.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AnimeHub.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var sqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions =>
        {
            sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        }));


            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<IUnitOfWork, UnityOfWork>();
            var mediator = AppDomain.CurrentDomain.Load("AnimeHub.Application");
            services.AddMediatR(s => s.RegisterServicesFromAssemblies(mediator));
            return services;
        }
    }
}
