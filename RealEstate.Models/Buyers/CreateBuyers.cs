using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Buyers;
public class CreateBuyers
{
    [Required, MinLength(4), MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MinLength(4), MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone, MaxLength(14)]
    public int Phone { get; set; }

    [MaxLength(100)]
    public int PrefSqFt { get; set; }
}