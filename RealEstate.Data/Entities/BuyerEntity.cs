using System.ComponentModel.DataAnnotations;

namespace RealEstate.Data.Entities;
public class BuyerEntity
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone, MaxLength(14)]
    public string Phone { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int PrefSqFt { get; set; }

    public DateTime DateCreated { get; set; }
}