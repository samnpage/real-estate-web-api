using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.ListingsModels.cs
{
    public class HomeListings
    {
        public string? Address1 {get; set;}

        public string? Address2 {get; set;}

        public string? City {get; set;}

        public string? State {get; set;}

        public decimal Price{get; set;}

        public string ZipCode {get; set;} = string.Empty;

        public int SquareFootage {get; set;}
        public int HomeStyleId { get; set; } = 0;
        public string? HomeStyle {get; set;}
    }
}