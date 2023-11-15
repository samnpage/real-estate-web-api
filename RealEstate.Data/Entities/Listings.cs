using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Data.Entities
{
    public class Listings
    {
        [Key]
        [Required]
        public int Id {get; set;}

        public string? Address1 {get; set;}

        public string? Address2{get;set;}

        public string? City {get; set;}

        public string? State {get; set;}

        public int ZipCode {get; set;}

        public int SquareFootage {get; set;}

        public decimal Price {get; set;}
        
        [MaxLength(300)]
        public string? FeedBack {get; set;}
        [ForeignKey("HomeStyle")]
        public string? HomeStyle{get; set;}
    }
}