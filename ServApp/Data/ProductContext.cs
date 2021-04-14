using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ServApp.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductContext(DbContextOptions options) : base(options) {
        }
    }
}