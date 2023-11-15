using System.ComponentModel.DataAnnotations;

public class HomeStyle
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}