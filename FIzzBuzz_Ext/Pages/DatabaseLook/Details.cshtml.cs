using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FIzzBuzz_Ext.Data;
using FIzzBuzz_Ext.Models;
using FIzzBuzz_Ext.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace FIzzBuzz_Ext.Pages.DatabaseLook
{
    public class DetailsModel : PageModel
    {
        private readonly FIzzBuzz_Ext.Data.FizzBuzzContext _context;
        private readonly UserManager<FIzzBuzz_ExtUser> _userManager;

        public DetailsModel(FIzzBuzz_Ext.Data.FizzBuzzContext context, UserManager<FIzzBuzz_ExtUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public FizzBuzz FizzBuzz { get; set; }
        public string Author;
        public string UserName;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }


            UserName = _userManager.GetUserName(User);
            Author = FizzBuzz.Author;

            return Page();
        }
    }
}
