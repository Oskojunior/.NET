using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Exercise_2.Models;

namespace Exercise_2.Pages
{
    public class AddressModel : PageModel
    {
        public Address Address { get; set; }
        public List<Address> Lista { get; set; }
        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");

            if (SessionAddress != null)
            {
                Lista = JsonConvert.DeserializeObject<List<Address>>(SessionAddress);

            }
            else
            {
                Lista = new List<Address>();
            }
            Lista.Reverse();
        }
    }
}
