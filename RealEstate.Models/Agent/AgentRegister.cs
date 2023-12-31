using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Agent;
public class AgentRegister
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, MinLength(4)]
    public string UserName { get; set; } = string.Empty;

    [Required, MinLength(4)]
    public string Password { get; set; } = string.Empty;

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}