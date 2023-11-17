using System.ComponentModel.DataAnnotations;

namespace RealEstate.Data.Entities
{
    public class HomeStyle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}