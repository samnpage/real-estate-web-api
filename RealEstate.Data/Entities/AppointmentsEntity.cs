using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace RealEstate.Data.Entities
{
    public class AppointmentsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AgentId { get; set; }

        [Required]
        public int BuyerId{ get; set; }

        [Required]
        public int ListingId { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public string FeedBack{ get; set; }= string.Empty;
    }
}