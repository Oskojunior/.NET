using FIzzBuzz_Ext.Data;
using FIzzBuzz_Ext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIzzBuzz_Ext.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> FizzBuzzList { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionAddress = HttpContext.Session.GetString("SessionAddress");
                FizzBuzzList = FizzBuzz.ConvertToList(SessionAddress);
                FizzBuzz.Calculate();
                FizzBuzz.Date = DateTime.Now.ToString("G");
                FizzBuzzList.Add(FizzBuzz);
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzzList));

                _context.FizzBuzz.Add(FizzBuzz);
                _context.SaveChanges();
            }
        }
    }
}