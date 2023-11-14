namespace RealEstate.Models.Buyers;
public class ListBuyers
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Phone { get; set; }
    public int PrefSqFt { get; set; }
    public DateTime DateCreated { get; set; }
}