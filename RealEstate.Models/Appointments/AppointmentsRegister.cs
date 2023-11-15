
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models.Appointments;

public class AppointmentsRegister
{


    public int AgentId { get; set; }

    public int BuyerId { get; set; }

    public int ListingId { get; set; }

    [Required]
    public string FeedBack { get; set; } = string.Empty;

    public DateTime DateScheduled { get; set; }
   
}



