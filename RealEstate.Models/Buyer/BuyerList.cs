namespace RealEstate.Models.Buyer;
public class BuyerList
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int PrefSqFt { get; set; }
    public DateTime DateCreated { get; set; }
}