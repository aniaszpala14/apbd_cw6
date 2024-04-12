using System.ComponentModel.DataAnnotations;

namespace projekt2.Models.DTOs;

public class AddAnimal
{
    [MaxLength(20)]
    [MinLength(3)]
    [Required]
    public string Name { get; set; }
    
}