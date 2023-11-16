using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.Appointment
{
    public class UpdateAppointment
    {

        public int AgentId { get; set; }

        public int BuyerId { get; set; }

        public int ListingId { get; set; }

        public string FeedBack { get; set; } = string.Empty;
    }
}