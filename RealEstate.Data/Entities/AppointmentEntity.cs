using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Data.Entities
{
    public class AppointmentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }
        public virtual AgentEntity Agent { get; set; } = null!;

        [Required, ForeignKey(nameof(Buyer))]
        public int BuyerId{ get; set; }
        public virtual BuyerEntity Buyer{ get; set; } = null!;

        [Required, ForeignKey(nameof(Listing))]
        public int ListingId { get; set; }
        public virtual ListingEntity Listing { get; set; } = null!;

        public DateTime DateScheduled{ get; set; }

        [Required]
        public string FeedBack{ get; set; }= string.Empty;
        }
    }