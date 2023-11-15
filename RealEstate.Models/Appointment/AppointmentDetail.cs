namespace RealEstate.Models.Appointment;

public class AppointmentDetail
{
    public int Id { get; set; }
    public int AgentId{ get; set; } 
    public int BuyerId { get; set; } 
    public int ListingId { get; set; }
    public DateTime DateCreated { get; set; }
}  