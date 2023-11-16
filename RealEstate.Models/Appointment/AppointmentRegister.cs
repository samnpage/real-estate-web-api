using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Appointment;

public class AppointmentRegister
{
    public int AgentId { get; set; }

    public int BuyerId { get; set; }

    public int ListingId { get; set; }

    public string FeedBack { get; set; } = string.Empty;

}



