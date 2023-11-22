using Microsoft.EntityFrameworkCore;
using XprtzSerieApp.Database.Entities;

namespace XprtzSerieApp.Database;

public class ShowContext : DbContext
{
    public ShowContext(DbContextOptions<ShowContext> options) : base(options)
    {
    }

    public DbSet<ShowEntity> Shows { get; set; }
}