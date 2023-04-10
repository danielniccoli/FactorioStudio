using Microsoft.EntityFrameworkCore;
using System;

namespace FactorioStudio.Data;

public class BlueprintService
{
    private readonly FactorioStudioContext _context;

    public BlueprintService(FactorioStudioContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public IList<Blueprint> Blueprint { get; set; } = default!;

    public async Task<List<Blueprint>> GetAllBlueprintsAsync()
    {
        return await _context.Blueprints.ToListAsync();
    }
}


