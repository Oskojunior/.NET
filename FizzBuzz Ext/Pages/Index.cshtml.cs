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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> FizzBuzzList { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionAddress = HttpContext.Session.GetString("SessionAddress");
                if (SessionAddress != null)
                    FizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzz>>(SessionAddress);
                else
                    FizzBuzzList = new List<FizzBuzz>();
                FizzBuzz.Calculate();
                FizzBuzz.Date = DateTime.Now.ToString("G");
                FizzBuzzList.Add(FizzBuzz);
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzzList));
                RedirectToPage("./Privacy");

            }
            return Page();
        }
    }
}
