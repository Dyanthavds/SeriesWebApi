using Microsoft.EntityFrameworkCore;
using XprtzSerieApp.Database;

namespace XprtzSerieApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddShowDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShowContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IShowRepository,ShowRepository>();
        }
    }
}
