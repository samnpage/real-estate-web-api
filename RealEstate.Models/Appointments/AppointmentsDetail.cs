 namespace ElevenNote.Models.Agents;

public class AppointmentsDetail
{
    public int Id { get; set; }
    public int AgentId{ get; set; } 
    public int BuyerId { get; set; } 
    public int ListingId { get; set; }
    public DateTime DateCreated { get; set; }
}  