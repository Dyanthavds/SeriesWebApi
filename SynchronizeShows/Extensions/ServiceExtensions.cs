using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynchronizeShows.Services;
using SynchronizeShows.Services.Interfaces;
using XprtzSerieApp.Database;

namespace SynchronizeShows.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSynchronizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<ShowContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<ITvMazeApiService, TvMazeApiService>();
            services.AddScoped<ISynchronizationService, SynchronizationService>();
        }
    }
}
