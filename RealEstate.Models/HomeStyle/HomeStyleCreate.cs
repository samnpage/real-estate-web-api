using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.HomeStyle;
public class CreateHomeStyle
{
    [Required]
    public string Name { get; set; } = null!;
}