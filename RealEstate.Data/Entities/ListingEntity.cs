using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Data.Entities
{
    public class ListingEntity
    {
        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        [MaxLength(80)]
        public string? Address1 {get; set;}
        
        [Required]
        [MaxLength(10)]
        public string? Address2{get;set;}
        
        [Required]
        [MaxLength(30)]
        public string? City {get; set;}
        
        [Required]
        [MaxLength(30)]
        public string? State {get; set;}

        [Required]
        [MaxLength(10)]
        public string ZipCode {get; set;} = string.Empty;

        public int SquareFootage {get; set;}

        public decimal Price {get; set;}
        
        [MaxLength(300)]
        public string? FeedBack {get; set;}

        [ForeignKey(nameof(HomeStyle))]
        public int HomeStyleId{get; set;}
        public virtual HomeStyle HomeStyle { get; set; } = null!;
    }
}