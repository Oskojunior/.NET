using FIzzBuzz_Ext.Areas.Identity.Data;
using FIzzBuzz_Ext.Data;
using FIzzBuzz_Ext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<FIzzBuzz_ExtUser> _userManager;
        private readonly SignInManager<FIzzBuzz_ExtUser> _signInManager;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> FizzBuzzList { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context, UserManager<FIzzBuzz_ExtUser> userManager, SignInManager<FIzzBuzz_ExtUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        private void SetAuthor()
        {
            if (_signInManager.IsSignedIn(User))
            {
                FizzBuzz.Author = _userManager.GetUserName(User);
            }
            else
            {
                FizzBuzz.Author = "";
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var SessionAddress = HttpContext.Session.GetString("SessionAddress");
                FizzBuzzList = FizzBuzz.ConvertToList(SessionAddress);
                FizzBuzz.Calculate();
                SetAuthor();
                FizzBuzz.Date = DateTime.Now.ToString("G");
                FizzBuzzList.Add(FizzBuzz);
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzzList));

                _context.FizzBuzz.Add(FizzBuzz);
                _context.SaveChanges();
            }
        }
    }
}