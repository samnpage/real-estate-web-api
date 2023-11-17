using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Transaction;
public class CreateTransaction
{
    [Required]
    public int ListingId { get; set; }
    public int BuyerId { get; set; }
    public int SalePrice { get; set; }
}