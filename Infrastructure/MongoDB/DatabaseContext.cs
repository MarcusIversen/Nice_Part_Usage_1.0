using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.MongoDB;

public class DatabaseContext : DbContext
{
    private readonly Settings.AppSettings _appSettings;

    public DatabaseContext(IOptions<Settings.AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMongoDB(_appSettings.NicePartUsageDB, "NicePartUsageDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToCollection("Users");
        modelBuilder.Entity<Creation>().ToCollection("Creations");
        modelBuilder.Entity<Score>().ToCollection("Scores");
    }

    public DbSet<User> Users { get; init; }
    public DbSet<Creation> Creations { get; init; }
    public DbSet<Score> Scores { get; init; }
}