using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;


namespace GlrTransportInc.Pages.Calendar
{
    public class CalendarModel : PageModel
    {
        public static List<string> BillName = new List<string>();
        
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public CalendarModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FreightBill> FreightBill { get;set; }

        public async Task OnGetAsync()
        {
            FreightBill = await _context.FreightBill.ToListAsync();
            foreach (var item in FreightBill)
            {
                BillName.Add(item.Customer);
            }
        }
    }
}
