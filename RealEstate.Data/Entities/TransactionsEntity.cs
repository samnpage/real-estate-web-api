using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TransactionsEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Id")]
    public int ListingId { get; set; }
    [ForeignKey("Id")]
    public int BuyerId { get; set; }
    [ForeignKey("Price")]
    public int AskingPrice { get; set; }
    [Required]
    public int SalePrice { get; set; }
    public DateTime TransactionDate { get; set; }
}