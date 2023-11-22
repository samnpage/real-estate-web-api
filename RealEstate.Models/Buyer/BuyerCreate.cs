using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Buyer;
public class BuyerCreate
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone, MaxLength(15)]
    public string Phone { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int PrefSqFt { get; set; }
}