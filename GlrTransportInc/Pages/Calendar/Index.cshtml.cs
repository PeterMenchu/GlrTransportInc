using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc.Pages.Calendar
{
    public class IndexModel : PageModel
    {
        /*public void OnGet()
        {
        }*/
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public IndexModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FreightBill> FreightBill { get; set; }

        public async Task OnGetAsync()
        {
            FreightBill = await _context.FreightBill.ToListAsync();
        }
    }
}
