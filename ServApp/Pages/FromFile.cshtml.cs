using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServApp.Models;
using ServApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServApp.Pages
{
    public class FromFileModel : PageModel
    {
        private readonly JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; set; }

        public FromFileModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}