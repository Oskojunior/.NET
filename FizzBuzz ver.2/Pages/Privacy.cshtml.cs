using FizzBuzz_ver._2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz_ver._2.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> FizzBuzzList { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");

            if (SessionAddress != null)
            {
                FizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzz>>(SessionAddress);

            }
            else
            {
                FizzBuzzList = new List<FizzBuzz>();
            }
            FizzBuzzList.Reverse();
        }
    }
    
}
