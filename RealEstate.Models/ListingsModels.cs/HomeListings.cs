using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.ListingsModels.cs
{
    public class HomeListings
    {
        public int Id {get; set;}

        public string? HomeStyle {get; set;}

        public string? Address1 {get; set;}

        public string? Address2 {get; set;}

        public string? City {get; set;}

        public string? State {get; set;}

        public decimal Price{get; set;}

        public int ZipCode {get; set;}

        public int SquareFootage {get; set;}


    }
}