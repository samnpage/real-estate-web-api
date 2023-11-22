namespace RealEstate.Models.Transaction;
public class TransactionDetail
{
    public int Id { get; set; }
    public int ListingId { get; set; }
    public int BuyerId { get; set; }
    public int SalePrice { get; set; }
    public DateTime TransactionDate { get; set; }
}