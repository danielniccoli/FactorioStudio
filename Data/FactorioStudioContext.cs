using Microsoft.EntityFrameworkCore;

namespace FactorioStudio.Data;

public class FactorioStudioContext : DbContext
{

    public FactorioStudioContext(DbContextOptions<FactorioStudioContext> options) : base(options)
    {
    }

    public DbSet<Blueprint> Blueprints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blueprint>().Property(e => e.Id).ToJsonProperty("id");
        modelBuilder.Entity<Blueprint>().Property(e => e.Label).ToJsonProperty("label");
        modelBuilder.Entity<Blueprint>().Property(e => e.Description).ToJsonProperty("description");
        modelBuilder.Entity<Blueprint>().Property(e => e.Json).ToJsonProperty("blueprint");

        modelBuilder.Entity<Blueprint>()
            .ToContainer(nameof(Blueprints))
            .HasPartitionKey(o => o.Id)
            .HasNoDiscriminator()
            .UseETagConcurrency();

        base.OnModelCreating(modelBuilder);
    }
}
