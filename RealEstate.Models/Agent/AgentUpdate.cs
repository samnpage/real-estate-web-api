using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Agent;
public class AgentUpdate
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MinLength(4)]
    public string UserName { get; set; } = string.Empty;
}