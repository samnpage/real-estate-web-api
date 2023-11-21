using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealEstate.Data.Entities;

public class TransactionEntity
{
    [Key]
    public int Id { get; set; }

    // --

    [ForeignKey(nameof(Listing))]
    public int ListingId { get; set; }
    public virtual ListingEntity Listing { get; set; } = null!;

    [ForeignKey(nameof(Buyer))]
    public int BuyerId { get; set; }
    public virtual BuyerEntity Buyer { get; set; } = null!;
    public int AskingPrice { get; set; }
    [Required]
    public int SalePrice { get; set; }
    public DateTime TransactionDate { get; set; }
}