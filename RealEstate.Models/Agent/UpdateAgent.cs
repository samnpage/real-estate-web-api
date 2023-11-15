using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Agent;
public class UpdateAgent
{
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}