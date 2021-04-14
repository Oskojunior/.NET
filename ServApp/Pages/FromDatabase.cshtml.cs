using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServApp.Data;
using ServApp.Models;

namespace ServApp.Pages
{
    public class FromDatabaseModel : PageModel
    {
        public readonly ProductContext Context;
        public List<Product> Products { get; set; }

        public FromDatabaseModel(ProductContext context)
        {
            Context = context;
        }

        public void OnGet()
        {
            Products = Context.Product.ToList();
        }
    }
}
