using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Transaction;
public class CreateTransaction
{
    [Required]
    public int SalePrice { get; set; }
}