using System.ComponentModel.DataAnnotations;

namespace RealEstate.Data.Entities;
public class BuyersEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public int Phone { get; set; }

    public int PrefSqFt { get; set; }

    public DateTime DateCreated { get; set; }
}