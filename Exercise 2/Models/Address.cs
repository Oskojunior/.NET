using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_2.Models
{
    public class Address
    {
        [Display(Name = "Favourite Street")]
        [Required(ErrorMessage = "This field is mandatory")]
        public string Street { get; set; }
        [Display(Name = "ZIPPO")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Not the Zip Code"), Required]
        public string ZipCode { get; set; }
        [Display(Name = "Town")]
        [Required]
        public string City { get; set; }
        [Display(Name = "Numb-er")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Not a house number"), Required]
        public string Number { get; set; }

    }
}
