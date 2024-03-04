using System.ComponentModel.DataAnnotations;

namespace Aurum.Domain.Entities;

public class Pondan
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Class { get; set; }
    
    public bool IsPondan { get; set; }
}