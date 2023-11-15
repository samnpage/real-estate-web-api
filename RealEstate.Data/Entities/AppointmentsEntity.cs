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

        [Required, ForeignKey(nameof(agent))]
        public int AgentId { get; set; }
        public AgentEntity agent { get; set; }= null!;

        [Required ,ForeignKey(nameof(buyer))]
        public BuyersEntity  buyer{ get; set; }=null!;
        public int BuyerId{ get; set; }

        [Required, ForeignKey(nameof(listing))]
        public int ListingId { get; set; }
        public ListingEntity listing { get; set; }=null!;
        public DateTime DateScheduled{ get; set; }

        [Required]
        public string FeedBack{ get; set; }= string.Empty;
        }
    }
