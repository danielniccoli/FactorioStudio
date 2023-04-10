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
        modelBuilder.Entity<Blueprint>()
            .ToContainer(nameof(Blueprints))
            .HasPartitionKey(o => o.Id)
            .UseETagConcurrency();

        base.OnModelCreating(modelBuilder);
    }
}
