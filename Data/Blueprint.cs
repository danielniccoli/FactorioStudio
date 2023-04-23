using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FactorioStudio.Data;

public class Blueprint
{
    public Guid Id { get; set; }
    public string? Json { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }

}
