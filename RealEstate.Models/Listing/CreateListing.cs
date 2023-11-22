using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.Listing
{
    public class CreateListing
    {
        public string Address1 {get; set;} = string.Empty;

        public string Address2 {get; set;} = string.Empty;

        public string City {get; set;} = string.Empty;

        public string State {get; set;} = string.Empty;

        public string ZipCode {get; set;} = string.Empty;

        public int SquareFootage {get; set;}

        public decimal Price {get; set;}


        public int HomeStyleId {get; set;} 


    }
}