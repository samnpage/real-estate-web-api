namespace RealEstate.Models.Agent;

public class AgentDetail
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public DateTime DateCreated { get; set; }
}