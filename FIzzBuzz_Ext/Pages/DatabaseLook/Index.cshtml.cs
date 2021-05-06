using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FIzzBuzz_Ext.Data;
using FIzzBuzz_Ext.Models;
using Microsoft.AspNetCore.Authorization;

namespace FIzzBuzz_Ext.Pages.DatabaseLook
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FIzzBuzz_Ext.Data.FizzBuzzContext _context;

        public IndexModel(FIzzBuzz_Ext.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            var FizzBuzzes = from x in _context.FizzBuzz 
                             orderby x.Date descending
                             select x;

            FizzBuzz = await FizzBuzzes.Take(20).ToListAsync();
        }
    }
}
