using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Appointment;

public class AppointmentRegister
{
    public int AgentId { get; set; }

    public int BuyerId { get; set; }

    public int ListingId { get; set; }

    [Required]
    public string FeedBack { get; set; } = string.Empty;

    public DateTime DateScheduled { get; set; }
}



