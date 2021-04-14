using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FIzzBuzz_Ext.Models
{
    public class FizzBuzz
    {
        public int Id { get; set; }

        [Range(1, 1000), Required(ErrorMessage = "Number not found")]
        public int Number { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Outcome { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
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
        public static List<FizzBuzz> ConvertToList(string SessionAddress)
        {
            if (SessionAddress != null)
                return JsonConvert.DeserializeObject<List<FizzBuzz>>(SessionAddress);
            else
                return new List<FizzBuzz>();
        }
    }
}