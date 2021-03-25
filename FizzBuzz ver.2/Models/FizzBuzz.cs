using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz_ver._2.Models
{
    public class FizzBuzz
    {
        [Range(1,1000), Required(ErrorMessage ="Number not found")]
        public int Number { get; set; }
        public string Outcome { get; set; }

        public string Date { get; set; }
        public void Calculate()
        {
            if (this.Number % 3 == 0 && this.Number % 5 == 0)
                this.Outcome = "Otrzymano: FizzBuzz";
            else if (this.Number % 3 == 0)
                this.Outcome = "Otrzymano: Fizz";
            else if (this.Number % 5 == 0)
                this.Outcome = "Otrzymano: Buzz";
            else
                this.Outcome = "Liczba: " + this.Number + " nie spełnia kryteriów Fizz / Buzz";
        }
    }
}
