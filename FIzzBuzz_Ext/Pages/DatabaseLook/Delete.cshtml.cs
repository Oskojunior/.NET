using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FIzzBuzz_Ext.Data;
using FIzzBuzz_Ext.Models;
using Microsoft.AspNetCore.Identity;
using FIzzBuzz_Ext.Areas.Identity.Data;

namespace FIzzBuzz_Ext.Pages.DatabaseLook
{
    public class DeleteModel : PageModel
    {
        private readonly FIzzBuzz_Ext.Data.FizzBuzzContext _context;
        private readonly UserManager<FIzzBuzz_ExtUser> _userManager;

        public DeleteModel(FIzzBuzz_Ext.Data.FizzBuzzContext context, UserManager<FIzzBuzz_ExtUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null || FizzBuzz.Author == null || !(FizzBuzz.Author.Equals(_userManager.GetUserName(User))))
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FindAsync(id);

            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
